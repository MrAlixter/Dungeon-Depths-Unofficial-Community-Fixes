Public Class SigSpear
    Inherits Spear

    Sub New()
        MyBase.setName("Signature_Spear")
        MyBase.setDesc("A finely crafted spear bearing a trademarked signature.  This spear is specifically designed to be thrown and will not take damage from doing so." & vbCrLf &
                       "Can be thrown using the ""Use"" button." & vbCrLf &
                       "+35 ATK" & vbCrLf &
                       "-2 SPD")
        id = 158
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.aBoost = 35
        MyBase.sBoost = -2
        MyBase.count = 0
        MyBase.value = 3300
    End Sub

    Overrides Sub wThrow(ByRef p As Player, ByRef m As Entity)
        If m Is Nothing Then
            Game.pushLblEvent("You throw the spear across the dungeon at nothing in particular.")
            Game.pushLstLog("You throw the spear across the dungeon at nothing in particular.")
        Else
            Game.pushLstLog("You throw the spear!")
            Dim dmg As Integer = 2 * (p.getATK) + (Me.aBoost) + Int(Rnd() * 3 + 1)
            p.hit(dmg, m)
        End If
    End Sub
End Class
