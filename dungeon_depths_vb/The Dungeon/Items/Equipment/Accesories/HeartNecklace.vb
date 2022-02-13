Public Class HeartNecklace
    Inherits Accessory
    'The heart necklace provides no bonuses
    Sub New()
        '|ID Info|
        setName("Heart_Necklace")
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
