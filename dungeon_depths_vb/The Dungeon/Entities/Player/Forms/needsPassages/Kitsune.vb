Public Class Kitsune
    Inherits pForm
    Sub New()
        MyBase.New(1.5, 1.75, 3, 0.75, 1.5, 1, "Kitsune", True)
        MyBase.revertPassage = ""
    End Sub

    Public Overrides Sub revert()
        If Game.player1.prt.iArrInd(pInd.tail).Item1 = 1 Then Game.player1.prt.setIAInd(pInd.tail, 0, True, False)
    End Sub
End Class
