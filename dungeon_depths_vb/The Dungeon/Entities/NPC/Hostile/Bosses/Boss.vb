Public Class Boss
    Inherits Monster
    'The Bosses appear every 5 floors, can not be fled from, and guard the entrance to the next stage
    Sub New(ByVal mIndex As Integer)
        Select Case mIndex
            Case Else
                name = "A Boss"
                health = 60
                maxHealth = 60
                attack = 1
                defence = 1
                speed = 1
                inv.add(1, 1)
        End Select
        pos = Game.player.pos
    End Sub
End Class
