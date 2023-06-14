Public Class ASpellbook
    Inherits Spellbook

    Public Shadows Const ITEM_NAME As String = "Advanced_Spellbook"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 65
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 1500

        '|Description|
        setDesc("An ornate, gilded book that likely contains something outside of the standard magic curriculum.")
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
                Return 1
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Public Shared Shadows Function getSpells() As String()
        Return New ASpellbook().spells
    End Function
    Public Overrides Function spells() As String()
        Return {"Turn to Blade", "Turn to Cupcake", "Self Polymorph", "Magma Spear", "Petrify II", "Major Heal", "Uvona's Fugue", "Summon Apple"}
    End Function
    Public Overrides Function selfPolyForms() As String()
        Return {"Goddess"}
    End Function
    Public Overrides Function enemPolyForms() As String()
        Return {}
    End Function
End Class
