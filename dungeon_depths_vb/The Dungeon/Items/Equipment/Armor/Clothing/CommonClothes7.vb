Public Class CommonClothes7
    Inherits Armor

    Sub New()
        MyBase.setName("Adventurer's_Clothes")

        id = 254
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.wBoost = 1
        MyBase.aBoost = 1
        MyBase.count = 0
        MyBase.value = 0
        MyBase.compressesBreasts = True
        MyBase.slutVarInd = 191

        bsizeneg2 = New Tuple(Of Integer, Boolean, Boolean)(75, False, True)
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(7, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(76, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(7, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(346, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(14, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(15, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(14, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(15, True, False)

        MyBase.setDesc("Lightweight clothes for a determined adventurer." & DDUtils.RNRN &
                        getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
