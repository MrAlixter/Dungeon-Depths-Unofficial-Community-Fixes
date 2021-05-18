Public Class CommonClothes0
    Inherits Armor
    
    Sub New()
        setName("Common_Clothes")

        id = 184
        tier = Nothing
        usable = false
        MyBase.d_boost = 1
        MyBase.s_boost = 1
        count = 0
        value = 0
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 191


        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(257, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(99, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(1, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(1, True, False)

        setDesc("Common clothes for the common adventurer." & DDUtils.RNRN &
                             getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
