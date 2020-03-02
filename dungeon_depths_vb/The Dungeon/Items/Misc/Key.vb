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

        MyBase.isRandoTFAcceptable = False
    End Sub
    Public Overrides Sub add(i As Integer)
        'If i > 0 And game.mDun.numCurrFloor < 6 AndAlso game.mDun.floorboss(game.mDun.numCurrFloor).Equals("Key") Then
        '    Game.beatboss(game.mDun.numCurrFloor) = True
        'End If
        count += i
    End Sub
End Class
