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
