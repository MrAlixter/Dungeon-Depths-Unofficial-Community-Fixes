Public Class CommonClothes7
    Inherits Armor

    Sub New()
        setName("Adventurer's_Clothes")

        id = 254
        tier = Nothing
        usable = false
        w_boost = 1
        MyBase.a_boost = 1
        count = 0
        value = 0
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 191

        bsizeneg2 = New Tuple(Of Integer, Boolean, Boolean)(75, False, True)
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(7, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(76, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(7, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(346, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(14, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(15, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(14, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(15, True, False)

        setDesc("Lightweight clothes for a determined adventurer." & DDUtils.RNRN &
                        getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
