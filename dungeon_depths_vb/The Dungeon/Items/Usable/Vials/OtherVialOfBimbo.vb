Public Class OtherVialOfBimbo
    Inherits Item

    Public Const ITEM_NAME As String = "Another_Bimbo_TF_Item"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 449
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 1230

        '|Description|
        setDesc("A glittery, glowing pink potion contained in a clear glass vial.  The contents are sure to turn you into a blond ditz, probably... for sure.")
    End Sub

    Public Overrides Sub use(ByRef p As Player)
        TextEvent.pushLog("Drinking the pink contents of the vial causes a dizzy calm wash to over you...")

        MASBimboTF.step1Alt(p)
        p.drawPort()

        count -= 1
    End Sub
End Class
