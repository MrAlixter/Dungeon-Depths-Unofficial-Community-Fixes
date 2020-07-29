Public Class Succubus
    Inherits pForm
    Sub New()
        MyBase.New(0.66, 2.0, 2.0, 0.75, 1.5, 1, "Succubus", True)
        MyBase.revertPassage = "You roll your eyes dismissively as the magenta tint leaves your skin, and your demonic features slowly revert away."
    End Sub

    Public Overrides Sub onLVLUp(level As Integer, ByRef p As Player)
        If level = 4 Then

        ElseIf level = 8 Then

        ElseIf level = 12 Then

        End If
    End Sub
    Public Overrides Sub deLVL(toLevel As Integer, ByRef p As Player)

    End Sub
End Class
