Public Class noAcce
    Inherits Accessory
    Sub New()
        setName("Nothing")
        setDesc("NO accessory")
        tier = Nothing
        usable = false
        count = 0
        value = 0
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    End Sub
End Class
