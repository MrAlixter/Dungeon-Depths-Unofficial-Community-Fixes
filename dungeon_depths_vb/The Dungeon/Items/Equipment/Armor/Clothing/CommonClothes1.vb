Public Class CommonClothes1
    Inherits Armor

    Sub New()
        setName("Common_Armor")

        id = 185
        tier = Nothing
        usable = false
        MyBase.d_boost = 2
        count = 0
        value = 0
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 191


        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(1, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(258, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(1, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(100, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(2, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(3, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(2, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(3, True, False)

        setDesc("Common armor for the common adventurer." & DDUtils.RNRN &
                                      getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
