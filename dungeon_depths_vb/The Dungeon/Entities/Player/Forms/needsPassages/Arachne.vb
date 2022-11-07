Public Class Arachne
    Inherits pForm
    Sub New()
        MyBase.New(0.8, 1.66, 0.8, 1.0, 2.0, 1.5, "Arachne", True)
        MyBase.revertPassage = ""
    End Sub

    Public Overrides Sub onLVLUp(level As Integer, ByRef p As Player, Optional learnSkills As Boolean = True)
        p.learnSpecial("Snare")
    End Sub

    Public Overrides Sub revert()
        If Game.player1.prt.iArrInd(pInd.tail).Item1 = 2 Then Game.player1.prt.setIAInd(pInd.tail, 0, True, False)
    End Sub
End Class

