Public Class Compass
    Inherits Item

    Public Const ITEM_NAME As String = "Compass"

    'The compass identifies where the stairs are.
    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 0
        tier = 1

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 150

        '|Description|
        setDesc("A compass, used to find the stairs leading down to the next level.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        If Game.currFloor.floorNumber = 8 Or Game.currFloor.floorNumber = 13 Then
            TextEvent.pushAndLog("The compass spins wildly...")
            Exit Sub
        End If

        TextEvent.pushLog("You use the " & getName())

        Dim path = Game.currFloor.route(p.pos, Game.currFloor.stairs)
        For i = 0 To UBound(path) Step 4
            Game.currFloor.mBoard(path(i).Y, path(i).X).Tag = 2
            If Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "" Then Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "x"
        Next
        Game.currFloor.mBoard(path(UBound(path)).Y, path(UBound(path)).X).Tag = 2
        Game.drawBoard()
        count -= 1
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select LootTable.getBracket(floor_num)
            Case LootTable.bracket.f13
                Return Nothing
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function
End Class
