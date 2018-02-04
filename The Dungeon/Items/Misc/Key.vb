Public Class Key
    Inherits Item

    Sub New()
        MyBase.setName("Key")
        MyBase.setDesc("TFng")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 2500
    End Sub
    Public Overrides Sub add(i As Integer)
        If i > 0 Then Form1.beatboss(3) = True
    End Sub
End Class
