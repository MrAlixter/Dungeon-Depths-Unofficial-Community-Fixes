Public Class Slime
    Inherits pForm
    Sub New()
        MyBase.New(0.4, 1, 1, 2.5, 0.75, 0.75, "Slime", True)
        MyBase.revertPassage = "Your body is feeling much more solid than before. You get the feeling healing won't be as easy as it was when you were semi-liquid."
    End Sub

    Public Overrides Sub revert()
        MyBase.revert()
        Game.player.perks("slimehair") = -1
    End Sub
End Class
