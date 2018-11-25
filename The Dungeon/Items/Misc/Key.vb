Public Class Key
    Inherits Item

    Sub New()
        MyBase.setName("Key")
        MyBase.setDesc("A key to open a lock.")
        id = 53
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.count = 0
        MyBase.value = 2500
    End Sub
    Public Overrides Sub add(i As Integer)
        'If i > 0 And Game.floor < 6 AndAlso Game.floorboss(Game.floor).Equals("Key") Then
        '    Game.beatboss(Game.floor) = True
        'End If
        count += i
    End Sub
End Class
