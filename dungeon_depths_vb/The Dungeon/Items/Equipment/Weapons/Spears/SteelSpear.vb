Public Class SteelSpear
    Inherits Spear

    Sub New()
        '|ID Info|
        setName("Steel_Spear")
        id = 156
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        MyBase.a_boost = 22
        MyBase.s_boost = -5
        count = 0
        value = 1540
        MyBase.weight = 9

        '|Description|
        setDesc("A hearty spear forged from steel.  It's more likely to hit critically than a sword, but also more likely to miss altogether." & DDUtils.RNRN &
                              "Can be thrown using the ""Use"" button." & vbCrLf &
                              "+22 ATK" & vbCrLf &
                              "-5 SPD")
    End Sub
End Class
