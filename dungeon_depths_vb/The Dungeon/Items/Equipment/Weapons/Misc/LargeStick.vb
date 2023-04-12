Public Class LargeStick
    Inherits Weapon

    Public Const ITEM_NAME As String = "Large_Stick"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 284
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        a_boost = 6
        s_boost = -2
        count = 0
        value = 125

        '|Description|
        setDesc("For those who speak softly, sometimes all that's needed is a sturdy branch." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Return Player.calcDamage(p.getATK + getABoost(p), m.getDEF)
    End Function
End Class
