Public Class LargeStick
    Inherits Weapon

    Sub New()
        '|ID Info|
        setName("Large_Stick")
        id = 284
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        MyBase.a_boost = 6
        MyBase.s_boost = -2
        count = 0
        value = 125

        '|Description|
        setDesc("For those who speak softly, sometimes all that's needed is a sturdy branch." & DDUtils.RNRN &
                       "+6 ATK" & vbCrLf &
                       "-2 SPD")
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Return Player.calcDamage(p.getATK + a_boost, m.getDEF)
    End Function
End Class
