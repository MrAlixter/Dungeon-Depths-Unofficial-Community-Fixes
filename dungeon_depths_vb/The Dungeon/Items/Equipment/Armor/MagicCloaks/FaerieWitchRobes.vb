Public Class FaerieWitchRobes
    Inherits Armor

    Public Const ITEM_NAME As String = "Hyacinth's_Mantle"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 354
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        rando_inv_allowed = False
        hide_rearhair = True

        '|Stats|
        d_boost = 14
        m_boost = 20
        s_boost = 7
        count = 0
        value = 6614

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(462, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(463, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(464, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(465, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(445, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(446, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(447, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(448, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(449, True, True)

        hood = New Tuple(Of Integer, Boolean, Boolean)(24, True, True)
        cloak = New Tuple(Of Integer, Boolean, Boolean)(28, True, False)
        cloakneg1 = New Tuple(Of Integer, Boolean, Boolean)(28, True, False)
        cloak1 = New Tuple(Of Integer, Boolean, Boolean)(28, True, False)

        '|Description|
        setDesc("There once was a faerie named Hyacinth." & DDUtils.RNRN &
                "A renegade and prankster, her schemes got her into plenty of trouble with all sorts of folks.  Clever little Hyacinth was always able to get herself out of whatever mess she ended up in, and trick by trick she grew cleverer yet." & DDUtils.RNRN &
                """If I really tried..."" thought Hyacinth, with a grin, ""... I might even pull one over on the Fae Queen herself!""" & DDUtils.RNRN &
                "But clever little Hyacinth schemed long enough for her luck to run out." & DDUtils.RNRN &
                "As her essence wove into mint-colored fabric, she was equally giddy and horrified to have met someone so much more powerful than her monarch." & DDUtils.RNRN & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
