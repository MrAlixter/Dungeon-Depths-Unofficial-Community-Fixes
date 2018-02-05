Public Class SnakePotion
    Inherits Potion
    Sub New()
        MyBase.setRealName("Snake_Potion")
        MyBase.setDesc("A peculiar looking potion")
        MyBase.value = 250
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Game.player
        p.inventorynames(26) = "Snake_Potion"

        Dim D2 As Integer = (Int(Rnd() * 2))
        Select Case D2
            Case 0
                'snake tf
            Case Else
                'naga tf
        End Select
    End Sub
End Class
