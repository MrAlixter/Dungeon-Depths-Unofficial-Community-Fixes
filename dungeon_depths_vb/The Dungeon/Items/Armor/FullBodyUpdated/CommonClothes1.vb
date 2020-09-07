Public Class CommonClothes1
    Inherits Armor

    Sub New()
        MyBase.setName("Common_Armor")
        MyBase.setDesc("Common armor for the common adventurer." & DDUtils.RNRN &
                       "Fits sizes -1 to 2" & DDUtils.RNRN &
                       "+2 DEF")
        id = 185
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 2
        MyBase.count = 0
        MyBase.value = 0
        MyBase.compressesBreasts = True
        MyBase.slutVarInd = 191


        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(1, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(258, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(1, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(100, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(2, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(3, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(2, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(3, True, False)
    End Sub
End Class
