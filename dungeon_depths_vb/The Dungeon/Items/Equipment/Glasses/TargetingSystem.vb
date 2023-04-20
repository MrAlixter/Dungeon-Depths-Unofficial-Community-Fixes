Public Class TargetingSystem
    Inherits Glasses

    Public Const ITEM_NAME As String = "Targeting_System"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 317
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False
        over_acce = True

        '|Stats| 
        w_boost = 15
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)

        '|Description|
        setDesc("An angular black visor, dotted with a network of lasers and sensors." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
