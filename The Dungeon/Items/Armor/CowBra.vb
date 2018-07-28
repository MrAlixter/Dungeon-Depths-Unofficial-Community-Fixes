Public Class CowBra
    Inherits Armor

    Sub New()
        MyBase.setName("Cow_Print_Bra")
        MyBase.setDesc("A cow print bra created to hold cow sized breasts." & vbCrLf & _
                       "Fits sizes -1 through 7" & vbCrLf & _
                       "+1 DEF")
        id = 71
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 1
        MyBase.count = 0
        MyBase.value = 250
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean)(19, False)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean)(20, False)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean)(104, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean)(105, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean)(106, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean)(107, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean)(108, True)
        MyBase.bsize6 = New Tuple(Of Integer, Boolean)(109, True)
        'MyBase.bsize7 = New Tuple(Of Integer, Boolean)(110, True)
    End Sub
End Class
