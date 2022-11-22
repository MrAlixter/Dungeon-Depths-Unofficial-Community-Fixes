Public Class FotiaGaze
    Inherits Spell

    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Fotia's Piercing Gaze")
        MyBase.setUOC(True)
        MyBase.settier(2)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        If Game.combat_engaged Then
            MyBase.getTarget.isStunned = True
            MyBase.getTarget.stunct = 0
            TextEvent.pushAndLog("Fotia's Piercing Gaze!  " & Trim(getTarget.title & " " & getTarget.getName) & " is stunned for 1 turn.")
        Else
            Dim goUp = True
            Dim goDown = True
            Dim goLeft = True
            Dim goRight = True

            For ind = 0 To 20
                Dim x = Game.player1.pos.X - ind
                If x < Game.mBoardWidth And x >= 0 Then
                    Dim tileTagX = Game.currFloor.mBoard(Game.player1.pos.Y, x).Tag
                    If tileTagX = 1 And goLeft Then Game.currFloor.mBoard(Game.player1.pos.Y, x).Tag = 2

                    If tileTagX = 0 Then goLeft = False
                End If

                x = Game.player1.pos.X + ind
                If x < Game.mBoardWidth And x >= 0 Then
                    Dim tileTagX = Game.currFloor.mBoard(Game.player1.pos.Y, x).Tag
                    If tileTagX = 1 And goRight Then Game.currFloor.mBoard(Game.player1.pos.Y, x).Tag = 2

                    If tileTagX = 0 Then goRight = False
                End If

                Dim y = Game.player1.pos.Y - ind
                If y < Game.mBoardHeight And y >= 0 Then
                    Dim tileTagY = Game.currFloor.mBoard(y, Game.player1.pos.X).Tag
                    If tileTagY = 1 And goUp Then Game.currFloor.mBoard(y, Game.player1.pos.X).Tag = 2

                    If tileTagY = 0 Then goUp = False
                End If

                y = Game.player1.pos.Y + ind
                If y < Game.mBoardHeight And y >= 0 Then
                    Dim tileTagY = Game.currFloor.mBoard(y, Game.player1.pos.X).Tag
                    If tileTagY = 1 And goDown Then Game.currFloor.mBoard(y, Game.player1.pos.X).Tag = 2

                    If tileTagY = 0 Then goDown = False
                End If
            Next

            Game.drawBoard()

            TextEvent.pushAndLog("Fotia's Piercing Gaze!  You see the dungeon around you.")
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Stuns its target for 1 turn.  Can be used outside combat to ""see"" a cross of 15 tiles surrounding the player."
    End Function
End Class
