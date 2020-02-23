Public Class BronzeSpear
    Inherits Spear

    Sub New()
        MyBase.setName("Bronze_Spear")
        MyBase.setDesc("A simple bronze spear.  It's more likely to hit critically than a sword, but also more likely to miss altogether." & vbCrLf &
                       "Can be thrown using the ""Use"" button." & vbCrLf &
                       "+15 ATK" & vbCrLf &
                       "-5 SPD")
        id = 155
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.aBoost = 15
        MyBase.sBoost = -5
        MyBase.count = 0
        MyBase.value = 400
    End Sub
End Class
