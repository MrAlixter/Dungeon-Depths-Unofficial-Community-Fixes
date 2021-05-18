Public Class A6Battery
    Inherits Item

    Sub New()
        '|ID Info|
        setName("AAAAAA_Battery")
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
