Public Class BeeGirl
    Inherits pForm
    Sub New()
        MyBase.New(0.5, 0.9, 0.5, 1.5, 3.0, 0.33, "Bee Girl", False)
        MyBase.revertPassage = ""

        MyBase.overlayshouldersneg1 = New Tuple(Of Integer, Boolean, Boolean)(69, False, False)
        MyBase.overlayshoulders0 = New Tuple(Of Integer, Boolean, Boolean)(70, False, False)
        MyBase.overlayshoulders1 = New Tuple(Of Integer, Boolean, Boolean)(71, True, False)

        canBeBound = False
    End Sub
End Class
