Public Class CommonClothes6
    Inherits Armor

    Sub New()
        MyBase.setName("Sneaky_Clothes")
        MyBase.setDesc("Sneaky clothes for a sneaky adventurer." & vbCrLf & vbCrLf &
                       "Fits sizes -1 to 2" & vbCrLf & vbCrLf &
                       "+1 ATK" & vbCrLf &
                       "+1 SPD")
        id = 190
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 1
        MyBase.sBoost = 1
        MyBase.count = 0
        MyBase.value = 0
        MyBase.compressesBreasts = True
        MyBase.slutVarInd = 191


        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(6, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(263, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(6, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(124, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(12, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(13, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(12, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(13, True, False)
    End Sub
End Class
