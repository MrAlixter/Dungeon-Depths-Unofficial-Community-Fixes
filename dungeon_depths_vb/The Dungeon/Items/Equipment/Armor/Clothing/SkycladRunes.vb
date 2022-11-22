Public Class SkycladRunes
    Inherits Armor

    Public Const ITEM_NAME As String = "Skyclad_Runes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 336
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = False
        hide_dick = False
        swap_gen_clothesbtm = True
        cursed = True

        '|Stats|
        s_boost = 5
        w_boost = 35
        count = 0
        value = 325

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(96, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(440, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(441, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(442, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(443, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(444, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(445, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(446, True, True)
        bsize7 = New Tuple(Of Integer, Boolean, Boolean)(447, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(93, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(430, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(431, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(432, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(433, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(434, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(435, True, True)

        '|Description|
        setDesc("A series of tattooed glyphs that provide a fair amount of protection without the need for pesky clothes." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
