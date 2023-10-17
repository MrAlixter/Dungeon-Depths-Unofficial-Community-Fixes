Public Class SuccubusGarb
    Inherits Armor

    Public Const ITEM_NAME As String = "Succubus_Garb"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 74
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        is_sexy = True

        '|Stats|
        a_boost = 2
        count = 0
        value = 25

        '|Image Index|
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(91, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(92, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(11, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(122, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(123, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(124, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(125, True, True)

        '|Description|
        setDesc("The scanty clothes of a succubus." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        If p.inv.getCountAt(getAName) < 1 Then p.inv.add(getAName, 1)
    End Sub
End Class
