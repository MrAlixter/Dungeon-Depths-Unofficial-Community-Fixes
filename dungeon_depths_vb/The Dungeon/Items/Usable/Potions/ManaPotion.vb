Public Class ManaPotion
    Inherits Item

    Public Const ITEM_NAME As String = "Mana_Potion"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 13
        tier = 2

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 633

        '|Description|
        setDesc("A normal, everyday mana potion.")

    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f10f12
                Return 1
            Case LootTable.bracket.f13
                Return Nothing
            Case LootTable.bracket.f14fXX
                Return 1
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Overrides Sub use(ByRef p As Player)
        TextEvent.pushLog("You drink the " & getName())
        Dim phMana = p.mana

        Dim meffect As ManaEffect = New ManaEffect
        meffect.apply(p)

        TextEvent.push("You drink the " & getName() & ".  +" & (p.mana - phMana) & " mana!")
        count -= 1
    End Sub
End Class
