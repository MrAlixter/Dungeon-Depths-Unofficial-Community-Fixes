Public Class CyberVisorO
    Inherits Glasses

    Public Const ITEM_NAME As String = "Cyber_Visor_(O)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 317
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats| 
        m_boost = 5
        w_boost = 5
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(7, True, True)

        '|Description|
        setDesc("A set of glasses made up of a single orange lens.  Their futuristic design is both lightweight and durable." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
