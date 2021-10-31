Public Class ThickRimmedSpecs
    Inherits Glasses

    Sub New()
        '|ID Info|
        setName("Thick_Rimmed_Specs")
        id = 311
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|    
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(4, False, False)

        '|Description|
        setDesc("A simple pair of glasses with a black frame" & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
