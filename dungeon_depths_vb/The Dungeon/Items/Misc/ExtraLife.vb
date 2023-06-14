Public Class ExtraLife
    Inherits Item

    Public Const ITEM_NAME As String = "Extra_Life"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 287
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 1444

        '|Description|
        setDesc("A small token that always seems to take on the image of its holder." & DDUtils.RNRN &
                "If you would die, a token is consumed and you... well... don't.")
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f6f9
                Return 4
            Case LootTable.bracket.f10f12
                Return 4
            Case LootTable.bracket.f14fXX
                Return 4
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function
End Class
