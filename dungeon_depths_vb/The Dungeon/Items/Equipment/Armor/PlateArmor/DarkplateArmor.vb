Public Class DarkplateArmor
    Inherits Armor

    Public Const ITEM_NAME As String = "Darkplate_Armor"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 429
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False
        compress_breast = True
        slut_var_ind = 413

        '|Stats|
        d_boost = 22
        s_boost = 10
        count = 0
        value = 3080

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(117, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(118, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(523, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(524, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(110, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(111, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(507, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(508, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(509, True, True)

        '|Description|
        setDesc("A surprisingly lightweight set of plate armor that allows one to move freely without sacrificing defense." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
