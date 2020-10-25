Public Class SteelSpear
    Inherits Spear

    Sub New()
        '|ID Info|
        MyBase.setName("Steel_Spear")
        id = 156
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)

        '|Stats|
        MyBase.aBoost = 22
        MyBase.sBoost = -5
        MyBase.count = 0
        MyBase.value = 1540
        MyBase.weight = 9

        '|Description|
        MyBase.setDesc("A hearty spear forged from steel.  It's more likely to hit critically than a sword, but also more likely to miss altogether." & DDUtils.RNRN &
                              "Can be thrown using the ""Use"" button." & vbCrLf &
                              "+22 ATK" & vbCrLf &
                              "-5 SPD")
    End Sub
End Class
