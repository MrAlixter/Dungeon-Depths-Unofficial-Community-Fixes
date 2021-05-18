Public Class BracedHeadband
    Inherits Accessory
    'The red headband provides a +1 attack buff
    Sub New()
        setName("Braced_Headband")
        setDesc("An aggressive looking red headband that looks like it can take a hit thanks to a steel plate." & vbCrLf & _
                       "+5 ATK, +5 DEF, +5 WILL")
        id = 139
        tier = 2
        usable = false
        MyBase.a_boost = 5
        MyBase.d_boost = 5
        w_boost = 5
        count = 0
        value = 1100
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(9, False, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(9, False, True)
    End Sub
End Class
