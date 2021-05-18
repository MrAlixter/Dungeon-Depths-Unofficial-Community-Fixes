Public Class CommonClothes3
    Inherits Armor

    Sub New()
        setName("Fancy_Clothes")

        id = 187
        tier = Nothing
        usable = false
        w_boost = 1
        MyBase.d_boost = 1
        count = 0
        value = 0
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 191


        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(3, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(260, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(3, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(102, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(6, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(7, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(6, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(7, True, False)

        setDesc("Fancy clothes for a fancy adventurer." & DDUtils.RNRN &
                                    getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
