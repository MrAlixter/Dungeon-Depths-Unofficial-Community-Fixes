Public Class Key
    Inherits Item

    Public Const ITEM_NAME As String = "Key"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 53
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 2500

        '|Description|
        setDesc("A key to open a lock.")
    End Sub
    Public Overrides Sub add(i As Integer)
        'If i > 0 And game.mDun.numCurrFloor < 6 AndAlso Game.mDun.floor_boss(game.mDun.numCurrFloor).Equals("Key") Then
        '    Game.beatboss(game.mDun.numCurrFloor) = True
        'End If
        count += i
    End Sub
End Class
