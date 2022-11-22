Public Class MarissasNotes
    Inherits Spellbook

    Public Shadows Const ITEM_NAME As String = "Marissa's_Notes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 278
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 800

        '|Description|
        setDesc("A small, black book with the golden silloette of a cat on the cover.  According to the title page, the author is ""Marissa, Master Nekomancer""")
    End Sub

    Public Overrides Function spells() As String()
        Return {"Polymorph Enemy"}
    End Function
    Public Overrides Function selfPolyForms() As String()
        Return {}
    End Function
    Public Overrides Function enemPolyForms() As String()
        Return {"Cat-Girl"}
    End Function
End Class
