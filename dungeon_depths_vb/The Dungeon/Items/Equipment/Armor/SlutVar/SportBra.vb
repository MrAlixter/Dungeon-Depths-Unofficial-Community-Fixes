Public Class SportBra
    Inherits Armor

    Public Const ITEM_NAME As String = "Sports_Bra"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 47
        tier = 3

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True
        anti_slut_ind = 46

        '|Stats|
        d_boost = 1
        s_boost = 5
        count = 0
        value = 644

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(110, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(111, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(62, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(63, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(64, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(65, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(103, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(104, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(129, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(130, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(131, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(132, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(133, True, True)

        '|Description|
        setDesc("A sports bra made of a strechy matierial that allows it to fit many different bust sizes." & DDUtils.RNRN &
                "Slightly increases the rate that XP is gained." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f3f5
                Return 2
            Case LootTable.bracket.misc
                Return MyBase.getTier(floor_num)
            Case Else
                Return Nothing
        End Select
    End Function
End Class
