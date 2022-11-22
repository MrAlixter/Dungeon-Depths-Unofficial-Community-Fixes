Public Class LingerieCatalog
    Inherits Spellbook

    Public Shadows Const ITEM_NAME As String = "Lingerie_Catalog"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 350
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False
        npc_drop_only = True

        '|Stats|
        count = 0
        value = 200

        '|Description|
        setDesc("A small paper pamphlet containing pictures of models in skimpy underwear.  On its back, a simple incantation is scrawled in golden ink.")
    End Sub

    Public Overrides Function spells() As String()
        Return {"Turn to Panties"}
    End Function
    Public Overrides Function selfPolyForms() As String()
        Return {}
    End Function
    Public Overrides Function enemPolyForms() As String()
        Return {}
    End Function
End Class
