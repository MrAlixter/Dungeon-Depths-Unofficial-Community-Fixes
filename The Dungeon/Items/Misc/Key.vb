Public Class Key
    Inherits Item

    Sub New()
        MyBase.setName("Key")
        MyBase.setDesc("TFng")
        id = 53
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 2500
    End Sub
    Public Overrides Sub add(i As Integer)
        If i > 0 And Game.beatboss(Game.floor).Equals("Key") Then
            Game.beatboss(Game.floor) = True
        End If
    End Sub
End Class
