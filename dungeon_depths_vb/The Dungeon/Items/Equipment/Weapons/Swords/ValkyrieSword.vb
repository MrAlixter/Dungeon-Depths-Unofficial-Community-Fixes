Public Class ValkyrieSword
    Inherits Sword

    Sub New()
        '|ID Info|
        MyBase.setName("Valkyrie_Sword")
        id = 96
        tier = 3

        '|Item Flags|
        MyBase.setUsable(False)

        '|Stats|
        MyBase.mBoost = 7
        MyBase.aBoost = 22
        MyBase.count = 0
        MyBase.value = 1000

        '|Description|
        MyBase.setDesc("A blazing sword used by a winged protector." & DDUtils.RNRN &
                       getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.className.Equals("Valkyrie") Then
            Dim valkyrieTF = New ValkyrieTF2(1, 0, 0, False)
            valkyrieTF.step1()
            p.perks(perk.tfcausingsword) = id
            p.drawPort()
        End If
    End Sub

    Public Overrides Sub onunEquip(ByRef p As Player, ByRef w As Weapon)
        If p.className.Equals("Valkyrie") And Not w Is Nothing AndAlso Not w.GetType.IsSubclassOf(GetType(Sword)) Then
            Game.pushLstLog("Putting away your sword causes you to change into your regular self!")
            Game.pushLstLog("Putting away your wand causes you to change into your regular self!  Helix Slash special forgotten...")
            If p.knownSpecials.Contains("Helix Slash") Then p.knownSpecials.Remove("Helix Slash")
            If p.knownSpecials.Contains("Blazing Angel Strike") Then p.knownSpecials.Remove("Blazing Angel Strike")
            p.inv.add(95, -1)
            p.revertToPState()
        End If
    End Sub
End Class
