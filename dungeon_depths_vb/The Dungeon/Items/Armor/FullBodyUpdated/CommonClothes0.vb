Public Class CommonClothes0
    Inherits Armor
    
    Sub New()
        MyBase.setName("Common_Clothes")
        MyBase.setDesc("Common clothes for the common adventurer." & vbCrLf & vbCrLf &
                       "Fits sizes -1 to 2" & vbCrLf & vbCrLf &
                       "+1 DEF" & vbCrLf &
                       "+1 SPD")
        id = 184
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 1
        MyBase.sBoost = 1
        MyBase.count = 0
        MyBase.value = 0
        MyBase.compressesBreasts = True
        MyBase.slutVarInd = 191


        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(257, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(99, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(1, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(1, True, False)
    End Sub
End Class
