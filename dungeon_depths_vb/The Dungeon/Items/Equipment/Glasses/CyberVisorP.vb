Public Class CyberVisorP
    Inherits Glasses

    Public Const ITEM_NAME As String = "Cyber_Visor_(P)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 316
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False
        over_acce = True

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
