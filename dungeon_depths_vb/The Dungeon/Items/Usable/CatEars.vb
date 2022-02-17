Public Class CatEars
    Inherits Item

    Public Const ITEM_NAME As String = "Cat_Ears"

    'CatEars is a useable item that gives the player cat ears
    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 15
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 250

        '|Description|
        setDesc("An enchanted pair of feline ears." & DDUtils.RNRN &
                       "Using this item will give its user cat ears!")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        p.prt.setIAInd(pInd.ears, 1, p.prt.sexBool, False)
        p.drawPort()
        count -= 1
    End Sub
End Class
