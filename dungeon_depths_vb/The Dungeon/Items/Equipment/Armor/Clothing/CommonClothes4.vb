Public Class CommonClothes4
    Inherits Armor

    Sub New()
        setName("Ordinary_Clothes")

        id = 188
        tier = Nothing
        usable = false
        MyBase.m_boost = 1
        MyBase.s_boost = 1
        count = 0
        value = 0
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 191


        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(4, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(261, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(4, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(103, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(8, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(9, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(8, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(9, True, False)

        setDesc("Ordinary clothes for a ordinary adventurer." & DDUtils.RNRN &
                                      getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
