Public Class RedHeadband
    Inherits Accessory
    'The red headband provides a +1 attack buff
    Sub New()
        setName("Red_Headband")
        setDesc("An aggressive looking red headband." & vbCrLf & _
                       "+1 ATK.")
        id = 67
        tier = Nothing
        usable = false
        MyBase.a_boost = 1
        count = 0
        value = 0
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(2, True, False)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(1, False, False)
    End Sub
End Class
