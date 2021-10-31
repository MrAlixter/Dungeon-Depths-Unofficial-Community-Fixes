Public Class STBodysuit
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Skin_Tight_Bodysuit")
        id = 103
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        rando_inv_allowed = False
        MyBase.anti_slut_ind = 102

        '|Stats|
        MyBase.m_boost = 23
        count = 0
        value = 1375

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(44, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(45, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(159, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(160, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(161, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(162, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(52, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(53, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(230, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(231, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(232, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(233, True, True)

        '|Description|
        setDesc("This sleek bodysuit leaves very little to the imagination, despite covering most of one's body.  Its thin, but flexible material trades any possible defense to maximize energy production." & DDUtils.RNRN & _
                                      getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
