Public Class CommonClothes5
    Inherits Armor

    Sub New()
        MyBase.setName("Common_Kimono")
        MyBase.setDesc("Traditional clothes for a katana-wielding adventurer." & DDUtils.RNRN &
                       "Fits sizes -1 to 2" & DDUtils.RNRN &
                       "+2 ATK")
        id = 189
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 2
        MyBase.count = 0
        MyBase.value = 0
        MyBase.compressesBreasts = True
        MyBase.slutVarInd = 191


        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(5, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(262, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(5, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(123, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(10, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(11, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(10, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(11, True, False)
    End Sub
End Class
