Public Class CombatUnit
    Inherits pForm
    Sub New()
        MyBase.New(0.8, 1.75, 1.75, 1.75, 2.5, 0.6, "Combat Unit", True)
        MyBase.revertPassage = ""

        MyBase.overlayshouldersneg1 = New Tuple(Of Integer, Boolean, Boolean)(72, False, False)
        MyBase.overlayshoulders0 = New Tuple(Of Integer, Boolean, Boolean)(73, False, False)
        MyBase.overlayshoulders1 = New Tuple(Of Integer, Boolean, Boolean)(74, False, False)

        MyBase.overlayface = New Tuple(Of Integer, Boolean, Boolean)(75, True, False)
    End Sub
End Class
