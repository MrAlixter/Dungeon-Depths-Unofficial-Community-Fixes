Public Class LingerieCatalog
    Inherits Item

    Public Const ITEM_NAME As String = "Lingerie_Catalog"

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

    Overrides Sub use(ByRef p As Player)
        p.learnSpell("Turn to Panties")

        count -= 1
    End Sub
End Class
