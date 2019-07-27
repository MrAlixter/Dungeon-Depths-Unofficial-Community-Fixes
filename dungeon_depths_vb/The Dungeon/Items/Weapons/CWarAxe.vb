Public Class CWarAxe
    Inherits Weapon

    Sub New()
        MyBase.setName("Corse_War_Axe")
        MyBase.setDesc("A roughly finished, yet sturdy steel axe attached to a  beaten up wooden shaft.  Its uneven constuction, while boosting attack, also decreases speed slightly." & vbCrLf &
                       "+25 ATK, -10 DEF")
        id = 118
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 25
        MyBase.sBoost = -10
        MyBase.count = 0
        MyBase.value = 1000
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 6 + 1) + Int(Rnd() * 6 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 11 Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.aBoost)
        Return Player.calcDamage(dmg, m.defence)
    End Function
End Class
