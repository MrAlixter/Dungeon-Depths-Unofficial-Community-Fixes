Public Class CommonClothes2
    Inherits Armor

    Sub New()
        MyBase.setName("Common_Garb")
        MyBase.setDesc("Common garb for the common adventurer." & DDUtils.RNRN &
                       "Fits sizes -1 to 2" & DDUtils.RNRN &
                       "+1 DEF" & vbCrLf &
                       "+1 Max Mana")
        id = 186
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 1
        MyBase.mBoost = 1
        MyBase.count = 0
        MyBase.value = 0
        MyBase.compressesBreasts = True
        MyBase.slutVarInd = 191


        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(2, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(259, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(2, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(101, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(4, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(5, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(4, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(5, True, False)
    End Sub
End Class
