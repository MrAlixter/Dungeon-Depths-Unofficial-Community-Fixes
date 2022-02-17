Public Class CommonClothes7
    Inherits Armor

    Public Const ITEM_NAME As String = "Adventurer's_Clothes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 254
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        slut_var_ind = 191

        '|Stats|
        w_boost = 1
        a_boost = 1
        count = 0
        value = 0

        '|Image Index|
        bsizeneg2 = New Tuple(Of Integer, Boolean, Boolean)(75, False, True)
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(7, False, False)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(76, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(7, True, False)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(346, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(14, False, False)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(15, False, False)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(14, True, False)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(15, True, False)

        '|Description|
        setDesc("Lightweight clothes for a determined adventurer." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
