Public Class ChainBikini
    Inherits Armor

    Public Const ITEM_NAME As String = "Chain_Bikini"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 438
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        show_underboob = True
        is_sexy = True

        '|Stats|
        d_boost = 3
        count = 0
        value = 28

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(119, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(525, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(526, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(527, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(528, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(529, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(510, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(511, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(512, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(513, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(514, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(515, True, True)

        '|Description|
        setDesc("A skimpy swimsuit made of interlocked steel rings." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
