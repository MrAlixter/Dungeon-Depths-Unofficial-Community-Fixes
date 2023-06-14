Public Class Succubus
    Inherits pForm
    Sub New()
        MyBase.New(0.66, 2.0, 2.0, 0.75, 1.5, 1, "Succubus", True)
        MyBase.revertPassage = "You roll your eyes dismissively as the magenta tint leaves your skin, and your demonic features slowly revert away."
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills as Boolean = True)
        If level = 4 Then
            p.prt.setIAInd(pInd.horns, 7, True, False)
            p.prt.setIAInd(pInd.eyes, 12, True, True)
            p.prt.haircolor = Color.FromArgb(255, 217, 0, 24)
        ElseIf level = 8 Then
            p.prt.setIAInd(pInd.horns, 8, True, False)
            p.prt.setIAInd(pInd.eyes, 47, True, True)
            p.prt.haircolor = Color.FromArgb(255, 175, 0, 97)
        ElseIf level = 12 Then
            p.prt.setIAInd(pInd.horns, 9, True, False)
            p.prt.setIAInd(pInd.eyes, 48, True, True)
            p.prt.haircolor = Color.FromArgb(255, 41, 16, 38)
        ElseIf level < 4 Then
            p.prt.setIAInd(pInd.horns, 3, True, False)
            p.prt.setIAInd(pInd.eyes, 12, True, True)
        End If

        p.drawPort()
    End Sub
    Public Overrides Sub deLVL(toLevel As Integer, ByRef p As Player)
        If toLevel = 4 Then
            p.prt.setIAInd(pInd.horns, 3, True, False)
            p.prt.setIAInd(pInd.eyes, 12, True, True)
            p.prt.haircolor = Color.FromArgb(255, 155, 0, 0)
        ElseIf toLevel = 8 Then
            p.prt.setIAInd(pInd.horns, 7, True, False)
            p.prt.setIAInd(pInd.eyes, 47, True, True)
            p.prt.haircolor = Color.FromArgb(255, 175, 0, 97)
        ElseIf toLevel = 12 Then
            p.prt.setIAInd(pInd.horns, 9, True, False)
            p.prt.setIAInd(pInd.eyes, 48, True, True)
            p.prt.haircolor = Color.FromArgb(255, 41, 16, 38)
        ElseIf toLevel < 4 Then
            p.prt.setIAInd(pInd.horns, 3, True, False)
            p.prt.setIAInd(pInd.eyes, 12, True, True)
        End If

        p.drawPort()
    End Sub
End Class
