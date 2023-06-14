Public Class TankTop
    Inherits Armor

    Public Const ITEM_NAME As String = "Tank_Top"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 46
        tier = 2

        '|Item Flags|
        usable = false
        compress_breast = True
        slut_var_ind = 47

        '|Stats|
        d_boost = 1
        s_boost = 5
        count = 0
        value = 400

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(11, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(69, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(66, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(67, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(68, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(56, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(57, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(261, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(262, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(263, True, True)

        '|Description|
        setDesc("A grey tanktop made of a breathable fabric for the athletic." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f1f2
                Return MyBase.getTier(floor_num)
            Case LootTable.bracket.misc
                Return MyBase.getTier(floor_num)
            Case Else
                Return Nothing
        End Select
    End Function
End Class
