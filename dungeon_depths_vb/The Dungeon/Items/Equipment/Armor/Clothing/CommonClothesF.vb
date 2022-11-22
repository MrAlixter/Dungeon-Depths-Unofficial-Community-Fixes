Public Class CommonClothesF
    Inherits Armor

    Public Const ITEM_NAME As String = "Fae_Researcher_Outfit"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 332
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        show_underboob = False
        slut_var_ind = 331

        '|Stats|
        d_boost = 15
        w_boost = 10
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(94, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(428, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(429, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(430, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(431, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(91, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(417, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(418, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(419, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(420, True, True)

        '|Description|
        setDesc("A practical set of clothing commonly worn by those who would like to see more of the faefolk." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
