Public Class MagSlutWand
    Inherits Wand

    Sub New()
        MyBase.setName("Magical_Girl_Wand​")
        MyBase.setDesc("A heart adorned wand used by a mysterious protector.  Every once in a while, if flickers with a sinister crimson aura" & vbCrLf & "+7 ATK, +20 Max Mana")
        id = 171
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 20
        MyBase.aBoost = 7
        MyBase.count = 0
        MyBase.value = 10
        isCursed = True
    End Sub

    Public Overrides Sub onEquip()
        If Not Game.player1.pClass.name.Equals("Magical Slut") Then
            Dim magicGirlTF = New MagSlutTF(2, 0, 0, False)
            magicGirlTF.update()
            Game.player1.ongoingTFs.Add(magicGirlTF)
        End If
    End Sub

    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
         Dim dmg As Integer = aBoost
        Dim d31 = Int(Rnd() * 5)
        Dim d32 = Int(Rnd() * 5)

        m.takeDMG(dmg + d31 + d32, p)
        Game.pushLstLog(CStr("You fire off a heart-shaped blast, hitting the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
        Game.pushLblCombatEvent(CStr("You fire off a heart-shaped blast, hitting the " & m.name & " for " & dmg + d31 + d32 & " damage!"))
    End Sub
End Class
