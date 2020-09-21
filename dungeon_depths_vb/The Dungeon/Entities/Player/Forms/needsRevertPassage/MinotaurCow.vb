Public Class MinotaurCow
    Inherits pForm
    Sub New()
        MyBase.New(2, 1, 0.75, 1.5, 0.75, 0.5, "Minotaur Cow", True)
        MyBase.revertPassage = ""
    End Sub


    Public Overrides Sub onLVLUp(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 And p.breastSize < 7 Then p.be()
    End Sub
End Class
