Public Class RedHeadband
    Inherits Accessory

    Sub New()
        '|ID Info|
        setName("Red_Headband")
        id = 67
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        a_boost = 1
        count = 0
        value = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(2, True, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(1, False, False)

        '|Description|
        setDesc("An aggressive looking red headband." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
