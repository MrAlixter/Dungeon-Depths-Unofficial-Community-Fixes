Public Class Arachne
    Inherits pForm
    Sub New()
        MyBase.New(0.8, 1.66, 0.8, 1.0, 2.0, 1.5, "Arachne", True)
        MyBase.revertPassage = ""
    End Sub

    Public Overrides Sub onLVLUp(level As Integer, ByRef p As Player, Optional learnSkills As Boolean = True)
        If level = 3 And Not p.knownSpecials.Contains("Snare") Then p.knownSpecials.Add("Snare") : Game.pushLstLog("Snare special learned!")
    End Sub
End Class
