Public Class Arachne
    Inherits pForm
    Sub New()
        MyBase.New(0.8, 1.66, 0.8, 1.0, 2.0, 1.5, "Arachne", True)
        MyBase.revertPassage = ""
    End Sub

    Public Overrides Sub onLVLUp(level As Integer, ByRef p As Player, Optional learnSkills As Boolean = True)
        p.learnSpecial("Snare")
    End Sub
End Class
