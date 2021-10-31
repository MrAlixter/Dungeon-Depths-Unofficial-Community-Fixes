Public Class Eyepatch
    Inherits Glasses

    Sub New()
        '|ID Info|
        setName("Eyepatch")
        id = 314
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|    
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(7, False, False)

        '|Description|
        setDesc("A black piece of leather that covers up a single eye." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
