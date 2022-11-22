Public Class ExtraLife
    Inherits Item

    Public Const ITEM_NAME As String = "Extra_Life"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 287
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 1444

        '|Description|
        setDesc("A small token that always seems to take on the image of its holder." & DDUtils.RNRN &
                "If you would die, a token is consumed and you... well... don't.")
    End Sub
End Class
