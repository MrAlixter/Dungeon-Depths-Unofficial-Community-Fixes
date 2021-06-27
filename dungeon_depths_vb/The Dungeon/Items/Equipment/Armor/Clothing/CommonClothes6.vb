Public Class CommonClothes6
    Inherits Armor

    Sub New()
        setName("Sneaky_Clothes")

        id = 190
        tier = Nothing
        usable = false
        MyBase.a_boost = 1
        MyBase.s_boost = 1
        count = 0
        value = 0
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 191


        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(6, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(263, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(6, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(124, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(12, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(13, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(12, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(13, True, False)

        setDesc("Sneaky clothes for a sneaky adventurer." & DDUtils.RNRN &
                                      getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
