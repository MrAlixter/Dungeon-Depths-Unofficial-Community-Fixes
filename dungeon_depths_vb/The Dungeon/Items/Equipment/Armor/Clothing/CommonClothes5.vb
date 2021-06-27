Public Class CommonClothes5
    Inherits Armor

    Sub New()
        setName("Common_Kimono")

        id = 189
        tier = Nothing
        usable = false
        MyBase.a_boost = 2
        count = 0
        value = 0
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 191


        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(5, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(262, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(5, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(123, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(10, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(11, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(10, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(11, True, False)

        setDesc("Traditional clothes for a katana-wielding adventurer." & DDUtils.RNRN &
                                    getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
