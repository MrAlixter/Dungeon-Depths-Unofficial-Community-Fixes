Public Class BracedHeadband
    Inherits Accessory
    'The red headband provides a +1 attack buff
    Sub New()
        MyBase.setName("Braced_Headband")
        MyBase.setDesc("An aggressive looking red headband that looks like it can take a hit thanks to a steel plate." & vbCrLf & _
                       "+5 ATK, +5 DEF, +5 WIL")
        id = 139
        tier = 2
        MyBase.setUsable(False)
        MyBase.aBoost = 5
        MyBase.dBoost = 5
        MyBase.wBoost = 5
        MyBase.count = 0
        MyBase.value = 2200
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(9, False, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(9, False, True)
    End Sub
End Class
