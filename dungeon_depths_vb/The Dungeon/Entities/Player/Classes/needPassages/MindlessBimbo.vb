Public Class MindlessBimbo
    Inherits pClass
    Sub New()
        MyBase.New(1, 0.005, 0.005, 2, 0.005, 0.0, "Mindless Bimbo")
        MyBase.revertPassage = "You think to yourself... wait, you can think again!  As your mind returns to you, you give a sigh of relief."

        MyBase.canBeTFed = False
    End Sub

    Public Overrides Sub revert()
        MyBase.revert()

        If Game.player1.equippedAcce.getName.Equals("Ring_of_Uvona") Then
            Select Case Int(Rnd() * 6) + 1
                Case 1
                    Game.player1.attack += 1
                Case 2
                    Game.player1.maxMana += 1
                Case 3
                    Game.player1.maxHealth += 1
                Case 4
                    Game.player1.defense += 1
                Case 5
                    Game.player1.will += 1
                Case 6
                    Game.player1.speed += 1
            End Select

            Game.player1.currState.save(Game.player1)
            Game.player1.UIupdate()
        End If
    End Sub
End Class
