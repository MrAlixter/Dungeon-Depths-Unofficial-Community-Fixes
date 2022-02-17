Public Class CircularGlasses
    Inherits Glasses

    Public Const ITEM_NAME As String = "Circular_Glasses"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 310
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|    
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(3, False, False)

        '|Description|
        setDesc("A pair of glasses with a thin, round frame." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
