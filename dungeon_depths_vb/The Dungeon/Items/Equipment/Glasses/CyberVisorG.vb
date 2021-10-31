Public Class CyberVisorG
    Inherits Glasses

    Sub New()
        '|ID Info|
        setName("Cyber_Visor_(G)")
        id = 318
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|    
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(8, True, True)

        '|Description|
        setDesc("A set of glasses made up of a single lime-green lens.  Their futuristic design is both lightweight and durable." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
