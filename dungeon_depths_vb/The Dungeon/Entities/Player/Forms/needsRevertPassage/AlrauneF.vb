Public Class AlrauneF
    Inherits pForm
    Sub New()
        MyBase.New(2.5, 0.65, 1.35, 0.6, 0.2, 1.1, "Alraune", True)
        MyBase.revertPassage = ""
    End Sub

    Public Overrides Sub revert()
        MyBase.revert()
        Do While Game.player1.knownSpells.Contains("Mesmeric Bloom")
            Game.player1.knownSpells.Remove("Mesmeric Bloom")
        Loop
        TextEvent.pushLog("""Mesmeric Bloom"" spell forgotten!")
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills As Boolean = True)
        If Not learnSkills Then Exit Sub

        If level = 4 And Not p.knownSpecials.Contains("Lurk") Then p.knownSpecials.Add("Lurk") : TextEvent.pushLog("Lurk special learned!")
    End Sub
End Class
