Public Class SmallGlasses
    Inherits Glasses

    Sub New()
        '|ID Info|
        setName("Small_Glasses")
        id = 309
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|    
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(2, False, False)

        '|Description|
        setDesc("A small pair of glasses with a simple black frame." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
