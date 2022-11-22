Public Class WebCasterArach
    Inherits ArachHunt

    Public Shadows Const BASE_NAME As String = "Webcaster Arachne"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 125
        attack = 35
        defense = 20
        speed = 40
        will = 35

        '|Inventory|
        setInventory({63, 64, 239})

        '|Dialog Variables|

        '|Misc|
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If Not target.getPlayer Is Nothing And target.getPlayer.formName.Contains("Arachne") Then
            despawn("friend")
            Exit Sub
        End If

        If Int(Rnd() * 2) = 0 AndAlso Not target.getPlayer Is Nothing AndAlso Not target.getPlayer.equippedArmor.getName().Equals("Spidersilk_Bonds") Then
            Dim dmg = Entity.calcDamage(getATK() * 0.35, target.getDEF)

            TextEvent.pushCombat("The " & getName() & " uses Snare!  You are sliced for " & dmg & " damage!")
            TextEvent.pushLog("The " & getName() & " uses Snare!  You are sliced for " & dmg & " damage!")

            If target.getPlayer.inv.getCountAt("Spidersilk_Bonds") < 1 Then target.getPlayer.inv.add("Spidersilk_Bonds", 1)
            EquipmentDialogBackend.equipArmor(target.getPlayer, "Spidersilk_Bonds", False)
            target.getPlayer.drawPort()
        Else
            MyBase.attackCMD(target)
        End If
    End Sub
End Class
