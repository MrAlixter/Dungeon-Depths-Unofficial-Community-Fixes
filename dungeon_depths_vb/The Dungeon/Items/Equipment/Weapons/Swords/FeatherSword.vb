Public Class FeatherSword
    Inherits Sword

    Sub New()
        '|ID Info|
        setName("Featherlight_Rapier")
        id = 6
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        a_boost = 22
        count = 0
        value = 1000

        '|Description|
        setDesc("A nearly weightless sword with a long, slender blade.  The guard above its hilt resembles the plumage of a particularly showy bird." & DDUtils.RNRN &
                "Critical hit rate increases the faster you are than your foe." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)

        If dmg <= 4 Then
            Return -1
        ElseIf dmg >= 11 Or getAltCrit(p, m) Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.a_boost)
        Return Player.calcDamage(dmg, m.defense)
    End Function

    Function getAltCrit(ByRef p As Player, ByRef m As Entity) As Boolean
        If m.getSPD >= p.getSPD Then Return False

        Dim ratio As Double = Math.Min(p.getSPD / m.getSPD, 5.0)

        Return (Rnd() * ratio) > 1.0
    End Function
End Class
