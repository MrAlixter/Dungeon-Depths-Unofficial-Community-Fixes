Public Class SpidersilkWhip
    Inherits Weapon

    Sub New()
        MyBase.setName("Spidersilk_Whip")
        MyBase.setDesc("A white silk whip that critically hits more often than a standard sword." & vbCrLf & _
                       "+25 ATK")
        MyBase.setUsable(False)
        MyBase.aBoost = 25
        isMonsterDrop = True
        id = 63
        tier = 3
        MyBase.count = 0
        MyBase.value = 900
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 5 Then
            Return -1
        ElseIf dmg >= 10 Then
            Return -2
        End If
        dmg += (p.attack) + (Me.aBoost)
        Return Player.calcDamage(dmg, m.defence)
    End Function
End Class
