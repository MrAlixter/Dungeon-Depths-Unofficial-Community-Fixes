Public Class MasqueraderMask
    Inherits Glasses

    Public Const ITEM_NAME As String = "Masquerader's_Mask"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 315
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
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(8, False, False)

        '|Description|
        setDesc("A red feathery mask resembling those worn at extravagant balls." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
