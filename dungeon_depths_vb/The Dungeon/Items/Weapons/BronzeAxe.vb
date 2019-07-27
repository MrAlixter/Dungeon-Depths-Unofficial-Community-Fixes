Public Class BronzeAxe
    Inherits Weapon

    Sub New()
        MyBase.setName("Bronze_Battle_Axe")
        MyBase.setDesc("A curved, double-headed bronze axe with a simple wooden handle.  Some might call this a ""Labrys""." & vbCrLf &
                       "+12 ATK")
        id = 84
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 12
        MyBase.count = 0
        MyBase.value = 235
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 6) + Int(Rnd() * 5) + 2
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 10 Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.aBoost)
        Return Player.calcDamage(dmg, m.defence)
    End Function
End Class
