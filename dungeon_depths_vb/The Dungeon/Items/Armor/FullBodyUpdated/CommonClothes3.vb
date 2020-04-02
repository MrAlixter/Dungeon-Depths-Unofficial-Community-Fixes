Public Class CommonClothes3
    Inherits Armor

    Sub New()
        MyBase.setName("Fancy_Clothes")
        MyBase.setDesc("Fancy clothes for a fancy adventurer." & vbCrLf & vbCrLf &
                       "Fits sizes -1 to 2" & vbCrLf & vbCrLf &
                       "+1 WIL" & vbCrLf &
                       "+1 DEF")
        id = 187
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.wboost = 1
        MyBase.dBoost = 1
        MyBase.count = 0
        MyBase.value = 0
        MyBase.compressesBreasts = True
        MyBase.slutVarInd = 191


        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(3, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(260, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(3, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(102, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(6, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(7, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(6, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(7, True, False)
    End Sub
End Class
