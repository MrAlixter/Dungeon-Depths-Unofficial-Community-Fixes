Public Class Key
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("Key")
        id = 53
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.isRandoTFAcceptable = False

        '|Stats|
        MyBase.count = 0
        MyBase.value = 2500

        '|Description|
        MyBase.setDesc("A key to open a lock.")
    End Sub
    Public Overrides Sub add(i As Integer)
        'If i > 0 And game.mDun.numCurrFloor < 6 AndAlso game.mDun.floorboss(game.mDun.numCurrFloor).Equals("Key") Then
        '    Game.beatboss(game.mDun.numCurrFloor) = True
        'End If
        count += i
    End Sub
End Class
