Public Class DissolvedClothes
    Inherits Armor

    Public Const ITEM_NAME As String = "Dissolved_Clothes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 80
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True
        rando_inv_allowed = False

        '|Stats|
        MyBase.d_boost = 1
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(32, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(99, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(131, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(132, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(64, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(287, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(288, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(288, True, True)

        '|Description|
        setDesc("While at some point this set of apperal may have provided some defense, a generous dousing of slime has left it completely ruined." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
