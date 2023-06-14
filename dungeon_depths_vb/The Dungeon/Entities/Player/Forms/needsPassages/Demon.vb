Public Class Demon
    Inherits pForm
    Sub New()
        MyBase.New(0.8, 1.4, 1.4, 0.8, 1.4, 1, "Demon", True)
        MyBase.revertPassage = "The crimson tint fades away from your skin, and your demonic features slowly revert away."
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills As Boolean = True)
        If level = 4 Then
            p.prt.setIAInd(pInd.horns, 16, True, False)
        ElseIf level = 8 Then
            p.prt.setIAInd(pInd.horns, 17, True, False)
        ElseIf level = 12 Then
            p.prt.setIAInd(pInd.horns, 18, True, False)
        ElseIf level < 4 Then
            p.prt.setIAInd(pInd.horns, 15, True, False)
        End If

        p.drawPort()
    End Sub
    Public Overrides Sub deLVL(toLevel As Integer, ByRef p As Player)
        If toLevel = 4 Then
            p.prt.setIAInd(pInd.horns, 16, True, False)
        ElseIf toLevel = 8 Then
            p.prt.setIAInd(pInd.horns, 17, True, False)
        ElseIf toLevel = 12 Then
            p.prt.setIAInd(pInd.horns, 18, True, False)
        ElseIf toLevel < 4 Then
            p.prt.setIAInd(pInd.horns, 15, True, False)
        End If

        p.drawPort()
    End Sub
End Class
