Public Class A6Battery
    Inherits Item

    Public Const ITEM_NAME As String = "AAAAAA_Battery"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 261
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 2

        '|Description|
        setDesc("A small, standardized battery cell roughly the length of a gold coin.  While on its own it is more or less useless, in the right futuristic technology this battery can accomplish nearly anything.")
    End Sub
End Class
