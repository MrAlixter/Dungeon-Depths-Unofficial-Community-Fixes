Public Class CrackedPinkOrb
    Inherits Item

    Public Const ITEM_NAME As String = "Cracked_Pink_Orb"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 417
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 0

        '|Description|
        setDesc("A medium-sized pink orb that has large crack running along its surface.  A strange mist seeps fourth from it, so you've wrapped it in some of your clothing for safekeeping.")
    End Sub
End Class
