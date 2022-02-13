Public Class AmaraphneVestment
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Vestment_of_Amaraphne")
        id = 324
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        droppable = False
        rando_inv_allowed = False
        anti_slut_var_ind = 325

        '|Stats|
        d_boost = 14
        m_boost = 20
        w_boost = 20
        count = 0
        value = 2014

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(49, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(171, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(172, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(173, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(174, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(89, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(397, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(398, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(399, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(400, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(401, True, True)

        '|Description|
        setDesc("A white and pink gown that shimmers with the tell-tale influence of the Goddess of Lust." & DDUtils.RNRN &
                getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
