Public Class MagGirlWand
    Inherits Wand
    Protected mgOutfit As Integer = 10
    Sub New()
        MyBase.setName("Magical_Girl_Wand")
        MyBase.setDesc("A mysterious wand used by a mysterious protector." & vbCrLf & "+7 ATK, +20 Max Mana")
        id = 11
        tier = 3
        MyBase.setUsable(False)
        MyBase.mBoost = 20
        MyBase.aBoost = 7
        MyBase.count = 0
        MyBase.value = 1000
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        If Not p.className.Equals("Magical Girl") Then

            Dim magicGirlTF = New MagGirlTF(2, 0, 0, False)
            p.perks(perk.tfcausingwand) = id
            magicGirlTF.update()
            p.ongoingTFs.add(magicGirlTF)
        End If
    End Sub

    Public Overrides Sub onunEquip(ByRef p As Player, ByRef w As Weapon)
        If p.className.Equals("Magical Girl") And Not w Is Nothing AndAlso Not w.GetType.IsSubclassOf(GetType(Wand)) Then
            Game.pushLstLog("Putting away your wand causes you to change into your regular self!  Heartblast Starcannon spell forgotten...")
            If p.knownSpecials.Contains("Heartblast Starcannon") Then p.knownSpecials.Remove("Heartblast Starcannon")
            p.inv.add(mgOutfit, -1)
            p.magGState.save(p)
            p.revertToPState()
        End If
    End Sub

    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        Dim dmg As Integer = aBoost
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 4)

        m.takeDMG(dmg + d31 + d32, p)
        Game.pushLstLog(CStr("You fire off a heart-shaped blast, hitting the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
        Game.pushLblCombatEvent(CStr("You fire off a heart-shaped blast, hitting the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
    End Sub
End Class
