Public Class WebCasterArach
    Inherits ArachHunt
    Sub New()
        name = "Webcaster Arachne"
        maxHealth = 125
        attack = 35
        defense = 20
        speed = 40
        will = 35
        setInventory({63, 64, 239})
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If Int(Rnd() * 2) = 0 AndAlso Not target.getPlayer Is Nothing AndAlso target.getPlayer.equippedArmor.getName() Then
            Dim dmg = Entity.calcDamage(getATK() * 0.35, target.getDEF)

            Game.pushLblCombatEvent("The " & getName() & " uses Snare!  You are sliced for " & dmg & " damage!")
            Game.pushLstLog("The " & getName() & " uses Snare!  You are sliced for " & dmg & " damage!")

            If target.getPlayer.inv.getCountAt("Spidersilk_Bonds") < 1 Then target.getPlayer.inv.add("Spidersilk_Bonds", 1)
            Equipment.equipArmor(target.getPlayer, "Spidersilk_Bonds", False)
        Else
            MyBase.attackCMD(target)
        End If
    End Sub
End Class
