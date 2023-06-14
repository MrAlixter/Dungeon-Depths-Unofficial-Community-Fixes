Public Class RingOfUvona
    Inherits Accessory

    Public Const ITEM_NAME As String = "Ring_of_Uvona"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 123
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        m_boost = 7
        w_boost = 13
        count = 0
        value = 813

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
        'MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(11, True, True)
        'MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(9, False, True)

        '|Description|
        setDesc("While on the surface, this seems to be but an ornate ring crafted from extremely precious materials, closer inspection reveals that the inside of its band is inscribed with a blessing of the Uvona, Goddess of Fugue." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f10f12
                Return 3
            Case LootTable.bracket.f13
                Return 3
            Case LootTable.bracket.f14fXX
                Return 3
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function
End Class
