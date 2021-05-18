Public Class EmeraldCirclet
    Inherits Accessory
    'The ruby circlet provides a +1 attack buff
    Sub New()
        setName("Emerald_Circlet")
        setDesc("A large emerald inset on a gold-alloy band, this circlet is commonly worn by archmages." & vbCrLf & _
                       "+10 Mana, +10 SPD")
        id = 140
        tier = 2
        usable = false
        MyBase.m_boost = 10
        MyBase.s_boost = 10
        count = 0
        value = 1100
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(10, False, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(10, False, True)
    End Sub
End Class
