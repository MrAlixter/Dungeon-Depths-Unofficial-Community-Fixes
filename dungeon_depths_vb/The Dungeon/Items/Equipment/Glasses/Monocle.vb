Public Class Monocle
    Inherits Glasses

    Public Const ITEM_NAME As String = "Monocle"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 313
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|    
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(6, False, False)

        '|Description|
        setDesc("A classy glass eyepiece with only a single lens." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
