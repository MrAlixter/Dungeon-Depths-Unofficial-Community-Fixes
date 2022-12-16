Public Class NecromancerRobe
    Inherits Armor

    Public Const ITEM_NAME As String = "Necromancer's_Robes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 300
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        hide_rearhair = True
        slut_var_ind = 394

        '|Stats|
        h_boost = 10
        d_boost = 10
        w_boost = 20
        count = 0
        value = 1840

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(86, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(87, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(383, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(384, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(385, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(386, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(84, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(366, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(367, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(368, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(369, True, True)

        hood = New Tuple(Of Integer, Boolean, Boolean)(20, True, True)
        cloak = New Tuple(Of Integer, Boolean, Boolean)(14, True, False)
        cloakneg1 = New Tuple(Of Integer, Boolean, Boolean)(14, True, False)
        cloak1 = New Tuple(Of Integer, Boolean, Boolean)(14, True, False)

        '|Description|
        setDesc("A pitch black robe that identifies its wearer as a mage that specializes in equally dark magic." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
