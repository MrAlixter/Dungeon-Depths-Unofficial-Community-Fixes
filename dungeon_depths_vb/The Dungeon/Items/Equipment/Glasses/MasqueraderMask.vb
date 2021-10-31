Public Class MasqueraderMask
    Inherits Glasses

    Sub New()
        '|ID Info|
        setName("Masquerader's_Mask")
        id = 315
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|    
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(8, False, False)

        '|Description|
        setDesc("A red feathery mask resembling those worn at extravagant balls." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
