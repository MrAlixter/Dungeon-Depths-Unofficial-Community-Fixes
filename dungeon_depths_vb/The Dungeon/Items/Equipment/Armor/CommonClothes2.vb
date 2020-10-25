Public Class CommonClothes2
    Inherits Armor

    Sub New()
        MyBase.setName("Common_Garb")

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

        MyBase.setDesc("Common garb for the common adventurer." & DDUtils.RNRN &
                                      getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
