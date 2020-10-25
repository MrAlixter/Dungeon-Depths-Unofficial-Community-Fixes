Public Class Tigress
    Inherits pForm
    Sub New()
        MyBase.New(1, 1.5, 1, 0.75, 1.5, 1, "Tigress", False)
        MyBase.revertPassage = ""

        MyBase.overlayshouldersneg1 = New Tuple(Of Integer, Boolean, Boolean)(26, False, False)
        MyBase.overlayshoulders0 = New Tuple(Of Integer, Boolean, Boolean)(27, False, False)
        MyBase.overlayshoulders1 = New Tuple(Of Integer, Boolean, Boolean)(28, True, False)

        MyBase.overlayusizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(29, False, False)
        MyBase.overlayusize0 = New Tuple(Of Integer, Boolean, Boolean)(30, False, False)
        MyBase.overlayusize1 = New Tuple(Of Integer, Boolean, Boolean)(31, True, False)
        MyBase.overlayusize2 = New Tuple(Of Integer, Boolean, Boolean)(32, True, False)
        MyBase.overlayusize3 = New Tuple(Of Integer, Boolean, Boolean)(33, True, False)
        MyBase.overlayusize4 = New Tuple(Of Integer, Boolean, Boolean)(34, True, False)
        MyBase.overlayusize5 = New Tuple(Of Integer, Boolean, Boolean)(35, True, False)
    End Sub
End Class
