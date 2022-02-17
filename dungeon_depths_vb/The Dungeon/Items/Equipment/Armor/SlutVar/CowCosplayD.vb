Public Class CowCosplayD
    Inherits Armor

    Public Const ITEM_NAME As String = "Cow_Cosplay_(Demonic)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 221
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = False
        show_underboob = True
        hide_dick = True
        anti_slut_ind = 71

        '|Stats|
        d_boost = 1
        count = 0
        value = 50

        '|Image Index|
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(315, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(316, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(317, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(318, True, True)
        bsize7 = New Tuple(Of Integer, Boolean, Boolean)(319, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(239, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(240, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(241, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(242, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(243, True, True)

        '|Description|
        setDesc("An unholy outfit for busty bovine demons.  While it grants its wearer an undenyable charm, it does make it harder for other succubi to take them seriously as anything other than a pet." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
