Public Class MajManaPotion
    Inherits Item

    Public Const ITEM_NAME As String = "Major_Mana_Potion"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 241
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 1233

        '|Description|
        setDesc("A better, rarer mana potion.")
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f1f2
                Return Nothing
            Case LootTable.bracket.f10f12
                Return 2
            Case LootTable.bracket.f13
                Return 2
            Case LootTable.bracket.f14fXX
                Return 2
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Overrides Sub use(ByRef p As Player)
        TextEvent.pushLog("You drink the " & getName())
        Dim phMana = p.mana

        Dim meffect As MajManaEffect = New MajManaEffect
        meffect.apply(p)

        TextEvent.push("You drink the " & getName() & ".  +" & (p.mana - phMana) & " mana!")
        count -= 1
    End Sub
End Class
