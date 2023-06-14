Public Class WarlockRobe
    Inherits Armor

    Public Const ITEM_NAME As String = "Warlock's_Robes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 115
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True

        '|Stats|
        h_boost = 5
        d_boost = 20
        m_boost = 15
        count = 0
        value = 1840

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(48, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(70, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(167, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(168, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(169, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(170, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(61, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(270, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(270, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(271, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(272, True, True)

        '|Description|
        setDesc("A snazzy robe that identifies its wearer as a high ranking follower of Uvona, Goddess of Fugue.  The goddess's power is woven into its very fabric, amplifying its wearer's own magic ability." & DDUtils.RNRN &
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
