Public Class MaidLingerie
    Inherits Armor
    Sub New()
        setName("Maid_Lingerie")

        id = 169
        tier = Nothing
        usable = false
        MyBase.s_boost = 4
        count = 0
        value = 0

        anti_slut_ind = 72

        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(56, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(57, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(223, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(224, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(225, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(47, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(48, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(164, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(165, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(166, True, True)
        MyBase.compress_breast = True

        setDesc("A smutty version of a French maid's outfit." & DDUtils.RNRN & _
                                     getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
