Public Class Dowse
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Dowse")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(2)
    End Sub
    Public Overrides Sub effect()
        For indY = -5 To 5
            For indX = -5 To 5
                Dim x = Game.player1.pos.X + indX
                Dim y = Game.player1.pos.Y + indY
                Dim tileTag = Game.currFloor.mBoard(y, x).Tag
                Dim tileText = Game.currFloor.mBoard(y, x).Text
                Dim tileColor = Game.currFloor.mBoard(y, x).forecolor

                If y < Game.mBoardHeight And y >= 0 And x < Game.mBoardWidth And x >= 0 Then
                    If tileText = "H" And tileTag < 2 Then
                        tileColor = Color.Black
                        If tileTag = 1 Then tileTag = 2
                        TextEvent.pushLog("Floor " & Game.mDun.numCurrFloor & ": Staircase Discovered")
                    End If
                    If tileText = "#" And tileTag < 2 Then
                        tileColor = Color.Black
                        If tileTag = 1 Then tileTag = 2
                        TextEvent.pushLog("Chest discovered!")
                    End If
                    If tileText = "+" And tileTag < 2 Then
                        tileColor = Color.Navy
                        If tileTag = 1 Then tileTag = 2
                        TextEvent.pushLog("Trap discovered!")
                    End If
                End If
            Next
        Next
        Game.drawBoard()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Identifies all tiles within 5 steps of the caster."
    End Function
End Class
