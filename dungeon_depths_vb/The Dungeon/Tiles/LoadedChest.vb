Public Class LoadedChest
    Inherits Chest

    Dim onOpen As Action

    Sub New(ByVal p As Point, ByVal contentID As Integer)
        MyBase.New()
        pos = p
        setInv(contentID)
        onOpen = getOnOpen(contentID)
    End Sub

    Sub setInv(ByVal contentID As Integer)
        Select Case contentID
            Case 3 Or 4
                add(53, 1)
        End Select
    End Sub
    Function getOnOpen(ByVal contentID As Integer) As action
        Select Case contentID
            Case 4
                Return AddressOf floor4StartChest
        End Select
        Return Nothing
    End Function

    Public Overrides Sub open()
        MyBase.open()
        onOpen()
        onOpen = Nothing
    End Sub

    Sub floor4StartChest()
        Game.player.inv.add(53, 1)
        Game.currfloor.beatBoss = False
        Game.preBSBody = Nothing
        Game.mDun.floorboss(4) = "Ooze Empress"
        Game.preBSBody = New State(Game.player)
        Game.player.forcedPath = Game.currfloor.route(Game.player.pos, Game.player.pos)
        Game.player.forcedPath = {Game.player.forcedPath(0)}
        Game.pushLblEvent("Upon opening the chest, you find a familiar key.  Well, that was easy.")
    End Sub

End Class
