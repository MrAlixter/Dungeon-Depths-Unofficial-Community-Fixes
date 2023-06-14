Public Class SteelArmor
    Inherits Armor

    Public Const ITEM_NAME As String = "Steel_Armor"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 5
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 7

        '|Stats|
        MyBase.d_boost = 12
        count = 0
        value = 564

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(6, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(104, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(13, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(15, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(34, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(104, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(104, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(104, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(105, True, True)

        '|Description|
        setDesc("A basic armor set forged from steel." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f1f2
                Return 3
            Case LootTable.bracket.f3f5
                Return 2
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function
End Class
