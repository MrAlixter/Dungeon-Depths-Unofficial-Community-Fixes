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
        MyBase.value = 50
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(19, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(20, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(104, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(105, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(106, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(107, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(108, True, True)
        MyBase.bsize6 = New Tuple(Of Integer, Boolean, Boolean)(109, True, True)
        MyBase.bsize7 = New Tuple(Of Integer, Boolean, Boolean)(110, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
