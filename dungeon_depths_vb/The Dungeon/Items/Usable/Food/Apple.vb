Public Class Apple
    Inherits Food

    Public Const ITEM_NAME As String = "Apple"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 32
        tier = 1

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 150
        setCalories(15)

        '|Description|
        setDesc("An normal red apple." & DDUtils.RNRN &
                "+15 Stamina")
    End Sub
End Class
