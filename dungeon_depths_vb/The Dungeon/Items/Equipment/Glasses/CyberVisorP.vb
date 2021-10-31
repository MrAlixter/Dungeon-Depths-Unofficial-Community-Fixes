Public Class CyberVisorP
    Inherits Glasses

    Sub New()
        '|ID Info|
        setName("Cyber_Visor_(P)")
        id = 316
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|    
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(6, True, True)

        '|Description|
        setDesc("A set of glasses made up of a single pink lens.  Their futuristic design is both lightweight and durable." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
