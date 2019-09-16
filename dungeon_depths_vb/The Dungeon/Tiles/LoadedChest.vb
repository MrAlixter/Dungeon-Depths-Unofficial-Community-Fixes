Public Class LoadedChest
    Inherits Chest

    Dim onOpen As Action
    Dim cid As Integer

    Sub New(ByVal p As Point, ByVal contentID As Integer)
        MyBase.New()
        pos = p
        setInv(contentID)
        onOpen = getOnOpen(contentID)
    End Sub
    Sub New(ByVal s As String)
        Dim cArray = s.Split("*")
        pos = New Point(cArray(1), cArray(2))
        onOpen = getOnOpen(CInt(cArray(3)))
        setInv(CInt(cArray(3)))
    End Sub

    Sub setInv(ByVal contentID As Integer)
        cid = contentID
        Select Case contentID
            Case 3 Or 4
                add(53, 1)
        End Select
    End Sub
    Function getOnOpen(ByVal contentID As Integer) As action
        Select Case contentID
            Case 3
                Return AddressOf keyChest
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
        Game.currFloor.beatBoss = False
        Game.preBSBody = Nothing
        Game.mDun.floorboss(4) = "Ooze Empress"
        Game.preBSBody = New State(Game.player)
        Game.player.forcedPath = Game.currFloor.route(Game.player.pos, Game.player.pos)
        Game.player.forcedPath = {Game.player.forcedPath(0)}
        Game.pushLblEvent("Upon opening the chest, you find a familiar key.  Well, that was easy.")
    End Sub
    Sub keyChest()
        Game.player.inv.add(53, 1)
        Game.pushLblEvent("Upon opening the chest, you find a key!")
    End Sub

    Public Overrides Function ToString() As String
        Return "LOADED*" & CStr(pos.X & "*") & CStr(pos.Y & "*") & CStr(cid) & "*"
    End Function
End Class
