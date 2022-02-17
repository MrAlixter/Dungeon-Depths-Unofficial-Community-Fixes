Public Class BookOSpecials
    Inherits Item

    Public Const ITEM_NAME As String = "Big_Book_O'_Specials"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 243
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 0

        '|Description|
        setDesc("A large manual that explains how to make the best use of certain skills, as long as you know the basics.")
    End Sub
    Overrides Sub use(ByRef p As Player)
        SpellSpecDescBackend.toPNLSpellSpecDesc(Nothing, Nothing, p, SpellOrSpec.SPECIAL)
    End Sub
End Class
