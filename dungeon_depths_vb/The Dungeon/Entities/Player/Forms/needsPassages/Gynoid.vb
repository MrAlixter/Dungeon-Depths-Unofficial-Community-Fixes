Public Class Gynoid
    Inherits pForm
    Sub New()
        MyBase.New(0.7, 0.7, 1.6, 1.35, 1.5, 0.1, "Gynoid", True)
        MyBase.revertPassage = ""

        MyBase.overlayface = New Tuple(Of Integer, Boolean, Boolean)(76, True, False)
    End Sub
End Class
