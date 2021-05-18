Public Class CommonClothes8
    Inherits Armor

    Sub New()
        setName("Regular_Clothes")

        id = 285
        tier = Nothing
        usable = false
        w_boost = 2
        count = 0
        value = 0
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 191

        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(8, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(83, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(8, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(363, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(16, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(17, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(16, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(17, True, False)

        setDesc("Regular clothes for the everyday adventurer." & DDUtils.RNRN &
                        getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
