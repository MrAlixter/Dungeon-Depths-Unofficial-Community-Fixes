Public Class MagGirlWandP
    Inherits MagGirlWand

    Sub New()
        MyBase.setName("Mag._Girl_Wand_(P)")
        MyBase.setDesc("A mysterious wand used by a mysterious protector." & vbCrLf & "+7 ATK, +20 Max Mana")
        id = 204
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 20
        MyBase.aBoost = 7
        MyBase.count = 0
        MyBase.value = 2000

        mgOutfit = 202
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.pClass.name.Equals("Magical Girl") Then

            Dim magicGirlTF = New MagGirlPTF(2, 0, 0, False)
            magicGirlTF.update()
            p.ongoingTFs.add(magicGirlTF)
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
