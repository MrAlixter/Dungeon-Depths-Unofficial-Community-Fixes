Public Class RubyCirclet
    Inherits Accessory
    'The ruby circlet provides a +1 attack buff
    Sub New()
        setName("Ruby_Circlet")
        setDesc("A ruby inset on a gold band, this circlet is commonly worn by mages." & vbCrLf & _
                       "+2 Mana.")
        id = 68
        tier = Nothing
        usable = false
        MyBase.m_boost = 2
        count = 0
        value = 0
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(3, True, False)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(2, False, False)
    End Sub
End Class
