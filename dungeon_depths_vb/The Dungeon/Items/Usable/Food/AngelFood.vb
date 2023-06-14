Public Class AngelFood
    Inherits Food

    Public Const ITEM_NAME As String = "Angel_Food_Cake"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 44
        tier = 3

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 622
        setCalories(20)

        '|Description|
        setDesc("An divine sugary confection." & DDUtils.RNRN &
                "+20 Stamina")
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f3f5
                Return 2
            Case LootTable.bracket.f6f9
                Return 2
            Case LootTable.bracket.f10f12
                Return 2
            Case LootTable.bracket.f13
                Return Nothing
            Case LootTable.bracket.f14fXX
                Return 1
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Public Overrides Sub effect(ByRef p As Player)
        p.ongoingTFs.add(New AngelTF())
        p.update()
    End Sub
End Class
