Public Class Mindless
    Inherits pClass
    Sub New()
        MyBase.New(1, 0.005, 0.005, 2, 0.005, 0.0, "Mindless")
        MyBase.revertPassage = "You think to yourself...wait, you can think again!  As your mind returns to you, you give a sigh of relief."
    End Sub

    Public Overrides Sub revert()
        MyBase.revert()

        If Game.player.equippedAcce.getName.Equals("Ring_of_Uvona") Then
            Select Case Int(Rnd() * 6) + 1
                Case 1
                    Game.player.attack += 1
                Case 2
                    Game.player.maxMana += 1
                Case 3
                    Game.player.maxHealth += 1
                Case 4
                    Game.player.defence += 1
                Case 5
                    Game.player.will += 1
                Case 6
                    Game.player.speed += 1
            End Select

            Game.player.currState.save(Game.player)
            Game.player.UIupdate()
        End If
    End Sub
End Class
