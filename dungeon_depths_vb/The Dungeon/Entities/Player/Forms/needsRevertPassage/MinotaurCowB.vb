Public Class MinotaurCowB
    Inherits pForm

    Sub New()
        MyBase.New(2.25, 0.5, 2.0, 1.5, 1.0, 0.5, "Minotaur Cow (B)", True)

        MyBase.overlayusizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(36, False, False)
        MyBase.overlayusize0 = New Tuple(Of Integer, Boolean, Boolean)(37, False, False)
        MyBase.overlayusize1 = New Tuple(Of Integer, Boolean, Boolean)(38, True, False)
        MyBase.overlayusize2 = New Tuple(Of Integer, Boolean, Boolean)(39, True, False)
        MyBase.overlayusize3 = New Tuple(Of Integer, Boolean, Boolean)(40, True, False)
        MyBase.overlayusize4 = New Tuple(Of Integer, Boolean, Boolean)(41, True, False)
        MyBase.overlayusize5 = New Tuple(Of Integer, Boolean, Boolean)(42, True, False)

        MyBase.revertPassage = ""
    End Sub
End Class
