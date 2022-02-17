Public Class SteelBikini
    Inherits Armor

    Public Const ITEM_NAME As String = "Steel_Bikini"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 7
        tier = Nothing

        '|Item Flags|
        usable = False
        anti_slut_ind = 5
        compress_breast = True
        show_underboob = True

        '|Stats|
        d_boost = 6
        count = 0
        value = 250

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(27, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(16, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(17, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(18, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(20, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(152, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(153, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(154, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(155, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(156, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(157, True, True)

        '|Description|
        setDesc("A skimpy steel swimsuit that gives a new meaning to ""breast plates""." & DDUtils.RNRN & _
                                   getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
