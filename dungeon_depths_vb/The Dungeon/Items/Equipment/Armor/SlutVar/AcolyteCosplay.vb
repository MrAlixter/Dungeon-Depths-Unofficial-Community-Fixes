Public Class AcolyteCosplay
    Inherits Armor

    Public Const ITEM_NAME As String = "Acolyte_Cosplay"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 394
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        hide_rearhair = True
        anti_slut_ind = 300
        is_sexy = True

        '|Stats|
        h_boost = 10
        d_boost = 10
        w_boost = 10
        count = 0
        value = 920

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(106, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(486, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(487, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(488, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(489, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(100, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(470, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(471, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(472, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(473, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(474, True, True)

        hood = New Tuple(Of Integer, Boolean, Boolean)(20, True, True)
        cloak = New Tuple(Of Integer, Boolean, Boolean)(14, True, False)
        cloakneg1 = New Tuple(Of Integer, Boolean, Boolean)(14, True, False)
        cloak1 = New Tuple(Of Integer, Boolean, Boolean)(14, True, False)

        '|Description|
        setDesc("A pitch black outfit that identifies its wearer as a user of dark magic who appreciates both the sexy and the spooky." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
