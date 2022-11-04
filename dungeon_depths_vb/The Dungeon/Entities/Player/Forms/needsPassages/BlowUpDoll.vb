Public Class BlowUpDoll
    Inherits pForm
    Sub New()
        MyBase.New(0.7, 0.7, 0.7, 0.5, 0.5, 0.75, "Blowup Doll", False)
        MyBase.revertPassage = ""

        MyBase.overlayshouldersneg1 = New Tuple(Of Integer, Boolean, Boolean)(66, False, False)
        MyBase.overlayshoulders0 = New Tuple(Of Integer, Boolean, Boolean)(67, False, False)
        MyBase.overlayshoulders1 = New Tuple(Of Integer, Boolean, Boolean)(68, True, False)

        MyBase.overlaybsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(57, False, False)
        MyBase.overlaybsize0 = New Tuple(Of Integer, Boolean, Boolean)(58, False, False)
        MyBase.overlaybsize1 = New Tuple(Of Integer, Boolean, Boolean)(59, True, False)
        MyBase.overlaybsize2 = New Tuple(Of Integer, Boolean, Boolean)(60, True, False)
        MyBase.overlaybsize3 = New Tuple(Of Integer, Boolean, Boolean)(61, True, False)
        MyBase.overlaybsize4 = New Tuple(Of Integer, Boolean, Boolean)(62, True, False)
        MyBase.overlaybsize5 = New Tuple(Of Integer, Boolean, Boolean)(63, True, False)
        MyBase.overlaybsize6 = New Tuple(Of Integer, Boolean, Boolean)(64, True, False)
        MyBase.overlaybsize7 = New Tuple(Of Integer, Boolean, Boolean)(65, True, False)

        MyBase.overlayusizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(50, False, False)
        MyBase.overlayusize0 = New Tuple(Of Integer, Boolean, Boolean)(51, False, False)
        MyBase.overlayusize1 = New Tuple(Of Integer, Boolean, Boolean)(52, True, False)
        MyBase.overlayusize2 = New Tuple(Of Integer, Boolean, Boolean)(53, True, False)
        MyBase.overlayusize3 = New Tuple(Of Integer, Boolean, Boolean)(54, True, False)
        MyBase.overlayusize4 = New Tuple(Of Integer, Boolean, Boolean)(55, True, False)
        MyBase.overlayusize5 = New Tuple(Of Integer, Boolean, Boolean)(56, True, False)

        canBeBound = False
        canBeTFed = False
    End Sub
End Class
