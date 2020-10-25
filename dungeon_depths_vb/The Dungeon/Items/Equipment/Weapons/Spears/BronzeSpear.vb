Public Class BronzeSpear
    Inherits Spear

    Sub New()
        '|ID Info|
        MyBase.setName("Bronze_Spear")
        id = 155
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)

        '|Stats|
        MyBase.aBoost = 15
        MyBase.sBoost = -5
        MyBase.count = 0
        MyBase.value = 400

        '|Description|
        MyBase.setDesc("A simple bronze spear.  It's more likely to hit critically than a sword, but also more likely to miss altogether." & DDUtils.RNRN &
                       "Can be thrown using the ""Use"" button." & vbCrLf &
                       "+15 ATK" & vbCrLf &
                       "-5 SPD")
    End Sub
End Class
