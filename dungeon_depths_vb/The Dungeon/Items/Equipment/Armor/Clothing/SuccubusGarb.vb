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
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(91, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(92, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(11, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(122, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(123, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(124, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(125, True, True)
        MyBase.compress_breast = True

        setDesc("The scanty clothes of a succubus." & DDUtils.RNRN & _
                              getSizeInformation() & vbcrlf & getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        If p.inv.getCountAt(getAName) < 1 Then p.inv.add(getAName, 1)
    End Sub
End Class
