Public Class GooGirl
    Inherits pForm
    Sub New()
        MyBase.New(0.4, 1, 1, 2.5, 1.25, 0.1, "Goo Girl", True)
        MyBase.revertPassage = "Your body is feeling much more solid than before. You get the feeling healing won't be as easy as it was when you were semi-liquid."
    End Sub

    Public Overrides Sub revert()
        MyBase.revert()
        Game.player1.perks(perk.slimehair) = -1
    End Sub
End Class
