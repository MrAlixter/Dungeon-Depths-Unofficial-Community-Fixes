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

        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(56, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(57, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(223, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(224, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(225, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(47, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(48, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(164, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(165, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(166, True, True)
        MyBase.compress_breast = True

        setDesc("A smutty version of a French maid's outfit." & DDUtils.RNRN & _
                                     getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
