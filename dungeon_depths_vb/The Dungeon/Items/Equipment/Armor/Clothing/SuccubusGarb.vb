Public Class SuccubusGarb
    Inherits Armor
    Sub New()
        setName("Succubus_Garb")
        id = 74
        tier = Nothing
        usable = false
        MyBase.a_boost = 2
        count = 0
        value = 0
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(91, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(92, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(11, True, True)

        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(122, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(123, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(124, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(125, True, True)
        MyBase.compress_breast = True

        setDesc("The scanty clothes of a succubus." & DDUtils.RNRN & _
                              getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
