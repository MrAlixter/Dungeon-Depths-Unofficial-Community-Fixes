Public Class Acorn
    Inherits Food

    Public Const ITEM_NAME As String = "Acorn"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 347
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 6
        setCalories(4)

        '|Description|
        setDesc("A simple, uncooked acorn.  You could probably eat it, but why would you want to?" & DDUtils.RNRN &
                "+4 Stamina")
    End Sub
End Class
