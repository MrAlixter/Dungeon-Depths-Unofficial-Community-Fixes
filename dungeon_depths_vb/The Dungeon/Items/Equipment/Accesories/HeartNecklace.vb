Public Class HeartNecklace
    Inherits Accessory

    Public Const ITEM_NAME As String = "Heart_Necklace"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 66
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        count = 0
        value = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(1, True, False)

        '|Description|
        setDesc("A small pink heart on a silver chain." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
