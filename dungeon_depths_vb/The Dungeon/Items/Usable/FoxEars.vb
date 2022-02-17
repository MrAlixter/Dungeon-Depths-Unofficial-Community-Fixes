Public Class FoxEars
    Inherits Item

    Public Const ITEM_NAME As String = "Fox_Ears"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 219
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 777

        '|Description|
        setDesc("An enchanted pair of vulpine ears." & DDUtils.RNRN &
                "Using this item will give its user fox ears!")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        p.prt.setIAInd(pInd.ears, 13, True, True)
        p.drawPort()
        count -= 1
    End Sub
End Class
