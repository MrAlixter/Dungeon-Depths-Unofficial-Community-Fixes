Public Class SteelSpear
    Inherits Spear

    Sub New()
        MyBase.setName("Steel_Spear")
        MyBase.setDesc("A hearty spear forged from steel.  It's more likely to hit critically than a sword, but also more likely to miss altogether." & vbCrLf &
                       "Can be thrown using the ""Use"" button." & vbCrLf &
                       "+22 ATK" & vbCrLf &
                       "-5 SPD")
        id = 156
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.aBoost = 22
        MyBase.sBoost = -5
        MyBase.count = 0
        MyBase.value = 1540
        MyBase.weight = 9
    End Sub
End Class
