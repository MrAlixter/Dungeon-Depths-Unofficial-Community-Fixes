Public Class BlackTShirt
    Inherits Armor

    Public Const ITEM_NAME As String = "T-Shirt"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 445
        tier = 3

        '|Item Flags|
        usable = False
        compress_breast = True
        rando_inv_allowed = False
        npc_drop_only = True
        slut_var_ind = 425

        '|Stats|
        a_boost = 4
        d_boost = 4
        s_boost = 4
        w_boost = 4
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(14, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(122, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(77, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(78, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(79, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(114, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(115, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(519, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(520, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(521, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(522, True, True)

        '|Description|
        setDesc("A black shirt that reads ""I fixed D_D forever and all I got was this stupid T-shirt"" in text that is the exact same color as the fabric." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
