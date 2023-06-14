
Public Class BarbArmor
    Inherits Armor

    Public Const ITEM_NAME As String = "Barbarian_Armor"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 101
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True

        '|Stats|
        a_boost = 20
        d_boost = 10
        s_boost = 5
        count = 0
        value = 1840

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(37, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(38, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(139, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(140, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(141, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(142, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(22, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(23, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(64, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(65, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(66, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(67, True, True)

        MyBase.bsizeneg2 = New Tuple(Of Integer, Boolean, Boolean)(67, False, True)
        MyBase.usizeneg2 = New Tuple(Of Integer, Boolean, Boolean)(49, False, True)

        '|Description|
        setDesc("While this ""armor"" may not provide the same defense as other sets, it greatly improves offensive options." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f13
                Return 3
            Case LootTable.bracket.f14fXX
                Return 3
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function
End Class
