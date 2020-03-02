Public Class noAcce
    Inherits Accessory
    Sub New()
        MyBase.setName("Nothing")
        MyBase.setDesc("NO ACCESORY")
        id = Nothing
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.count = 0
        MyBase.value = 0
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    End Sub
End Class
