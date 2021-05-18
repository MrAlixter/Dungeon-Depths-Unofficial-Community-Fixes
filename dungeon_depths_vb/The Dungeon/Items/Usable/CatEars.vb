Public Class CatEars
    'CatEars is a useable item that gives the player cat ears
    Inherits Item
    Sub New()
        '|ID Info|
        setName("Cat_Ears")
        id = 15
        tier = Nothing

        '|Item Flags|
        usable = true

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
