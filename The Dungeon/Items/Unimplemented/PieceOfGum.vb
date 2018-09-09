Public Class PieceOfGum
    Inherits Food

    Sub New()
        MyBase.setName("Piece_of_Gum")
        MyBase.setDesc("An ordinary red gumball with a chicken on it. -10 Hunger")
        id = 1
        If DateTime.Now.Month = 9 And DateTime.Now.Day = 10 Then tier = 2 Else tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 100
        setCalories(10)
    End Sub

    Overrides Sub effect()
        Game.player.perks("rgum") = 1
    End Sub
End Class
