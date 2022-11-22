Public Class RegalGownF
    Inherits Armor

    Public Const ITEM_NAME As String = "Regal_Gown_(Fae)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 335
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False
        compress_breast = True
        show_underboob = False
        slut_var_ind = 333

        '|Stats|
        m_boost = 15
        s_boost = -7
        w_boost = 17
        count = 0
        value = 0

        '|Image Index|
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(437, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(438, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(439, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(426, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(427, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(428, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(429, True, True)

        '|Description|
        setDesc("The frilly ballgown of a bonafide princess.  Well, either that, or someone who a fairy thought could use a little more elegance in their life..." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
