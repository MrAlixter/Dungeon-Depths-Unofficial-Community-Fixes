Public Class PlantBikini
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Plant_Bikini")
        id = 303
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = False
        show_underboob = True
        hide_dick = True

        '|Stats|
        h_boost = 25
        m_boost = 25
        count = 0
        value = 1984

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(90, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(395, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(396, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(397, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(398, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(399, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(86, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(379, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(380, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(381, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(382, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(383, True, True)

        '|Description|
        setDesc("A wrap of leaves, flowers, and vines that makes up for its lack of support by bolstering one's health and mana." & DDUtils.RNRN &
                getSizeInformation() & vbCrLf &
                getStatInformation())
    End Sub
End Class
