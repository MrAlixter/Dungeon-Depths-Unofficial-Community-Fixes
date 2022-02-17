Public Class AmaraphneRaiment
    Inherits Armor

    Public Const ITEM_NAME As String = "Raiment_of_Amaraphne"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 325
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        droppable = False
        rando_inv_allowed = False
        slut_var_ind = 324

        '|Stats|
        d_boost = 24
        m_boost = 30
        w_boost = 30
        count = 0
        value = 2014

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(418, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(419, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(420, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(421, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(408, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(409, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(410, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(411, True, True)

        '|Description|
        setDesc("A white and crimson gown that shimmers with the tell-tale influence of the Goddess of Love." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
