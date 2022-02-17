Public Class Shades
    Inherits Glasses

    Public Const ITEM_NAME As String = "Cool_Shades"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 312
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|    
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(5, False, False)

        '|Description|
        setDesc("A simple pair of black glasses that conceal one's eyes." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
