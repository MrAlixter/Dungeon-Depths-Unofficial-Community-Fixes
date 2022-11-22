Public Class RosePetalSpellbook
    Inherits Spellbook

    Public Shadows Const ITEM_NAME As String = "Rosepetal_Spellbook"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 379
        tier = 3

        '|Item Flags|
        usable = True
        npc_drop_only = True

        '|Stats|
        count = 0
        value = 700

        '|Description|
        setDesc("A small, pale-green book with a pink rose sigil on the cover.  Its pages glitter with pixie dust...")
    End Sub

    Public Shared Shadows Function getSpells() As String()
        Return New RosePetalSpellbook().spells
    End Function

    Public Overrides Function spells() As String()
        Return {"Slitherslice", "Polymorph Enemy", "Turn to Frog"}
    End Function
    Public Overrides Function selfPolyForms() As String()
        Return {}
    End Function
    Public Overrides Function enemPolyForms() As String()
        Return {"Bee-Girl"}
    End Function
End Class
