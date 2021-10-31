Public Class RedRimmedSpecs
    Inherits Glasses

    Sub New()
        '|ID Info|
        setName("Red_Framed_Spectacles")
        id = 308
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|    
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(1, False, False)

        '|Description|
        setDesc("A simple pair of glasses with a red frame" & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
