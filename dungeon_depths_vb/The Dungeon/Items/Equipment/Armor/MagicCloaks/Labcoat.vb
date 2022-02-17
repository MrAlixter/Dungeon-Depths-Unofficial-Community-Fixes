
Public Class Labcoat
    Inherits Armor

    Public Const ITEM_NAME As String = "Labcoat"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 106
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        rando_inv_allowed = False
        slut_var_ind = 107

        '|Stats|
        d_boost = 3
        w_boost = 30
        count = 0
        value = 600

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(39, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(65, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(143, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(144, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(41, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(42, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(139, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(140, True, True)

        '|Description|
        setDesc("A white labcoat that gives its wearer an air of scientific authority." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
