Public Class Spellcyclopedia
    Inherits Item

    Public Const ITEM_NAME As String = "Spellcyclopedia"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 242
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 0

        '|Description|
        setDesc("A large book that explains how to make the best use of certain skills, as long as you know the basics.")
    End Sub
    Overrides Sub use(ByRef p As Player)
        SpellSpecDescBackend.toPNLSpellSpecDesc(Nothing, Nothing, p, SpellOrSpec.SPELL)
    End Sub
End Class
