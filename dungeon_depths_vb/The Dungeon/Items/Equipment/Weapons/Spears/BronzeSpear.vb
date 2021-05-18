Public Class BronzeSpear
    Inherits Spear

    Sub New()
        '|ID Info|
        setName("Bronze_Spear")
        id = 155
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        MyBase.a_boost = 15
        MyBase.s_boost = -5
        count = 0
        value = 400

        '|Description|
        setDesc("A simple bronze spear.  It's more likely to hit critically than a sword, but also more likely to miss altogether." & DDUtils.RNRN &
                       "Can be thrown using the ""Use"" button." & vbCrLf &
                       "+15 ATK" & vbCrLf &
                       "-5 SPD")
    End Sub
End Class
