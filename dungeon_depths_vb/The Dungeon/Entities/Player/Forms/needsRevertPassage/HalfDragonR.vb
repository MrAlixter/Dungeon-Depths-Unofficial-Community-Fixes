Public Class HalfDragonR
    Inherits pForm

    Sub New()
        MyBase.New(1, 1.5, 1, 1.5, 0.75, 1, "Half-Dragon (R)", False)
        MyBase.revertPassage = ""

        MyBase.overlaybsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(6, False, False)
        MyBase.overlaybsize0 = New Tuple(Of Integer, Boolean, Boolean)(7, False, False)
        MyBase.overlaybsize1 = New Tuple(Of Integer, Boolean, Boolean)(8, True, False)
        MyBase.overlaybsize2 = New Tuple(Of Integer, Boolean, Boolean)(9, True, False)
        MyBase.overlaybsize3 = New Tuple(Of Integer, Boolean, Boolean)(10, True, False)
        MyBase.overlaybsize4 = New Tuple(Of Integer, Boolean, Boolean)(11, True, False)
        MyBase.overlaybsize5 = New Tuple(Of Integer, Boolean, Boolean)(12, True, False)
        MyBase.overlaybsize6 = New Tuple(Of Integer, Boolean, Boolean)(13, True, False)
        MyBase.overlaybsize7 = New Tuple(Of Integer, Boolean, Boolean)(14, True, False)

        mybase.overlayusizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(15, False, False)
        MyBase.overlayusize0 = New Tuple(Of Integer, Boolean, Boolean)(16, False, False)
        MyBase.overlayusize1 = New Tuple(Of Integer, Boolean, Boolean)(17, True, False)
        MyBase.overlayusize2 = New Tuple(Of Integer, Boolean, Boolean)(18, True, False)
        MyBase.overlayusize3 = New Tuple(Of Integer, Boolean, Boolean)(19, True, False)
        MyBase.overlayusize4 = New Tuple(Of Integer, Boolean, Boolean)(20, True, False)
        MyBase.overlayusize5 = New Tuple(Of Integer, Boolean, Boolean)(21, True, False)

        MyBase.overlayface = New Tuple(Of Integer, Boolean, Boolean)(22, True, False)

        canBeBound = False
    End Sub
End Class
