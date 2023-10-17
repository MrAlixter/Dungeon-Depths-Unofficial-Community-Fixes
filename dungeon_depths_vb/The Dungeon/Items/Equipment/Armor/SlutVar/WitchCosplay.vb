Public Class WitchCosplay
    Inherits Armor

    Public Const ITEM_NAME As String = "Witch_Cosplay"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 18
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        anti_slut_ind = 17
        is_sexy = True

        '|Stats|
        m_boost = 10
        d_boost = 3
        count = 0
        value = 1250

        '|Image Index|
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(25, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(26, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(27, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(28, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(39, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(40, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(41, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(42, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(43, True, True)

        '|Description|
        setDesc("A glamourous garment made more to show off one's body than to show off any magical ability." & vbCrLf & _
                             getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
