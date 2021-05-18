Public Class ExtraLife
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Extra_Life")
        id = 287
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.droppable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 1444

        '|Description|
        setDesc("A small token that always seems to take on the image of its holder." & DDUtils.RNRN &
                       "If you would die, a token is consumed and you... well... don't.")
    End Sub
End Class
