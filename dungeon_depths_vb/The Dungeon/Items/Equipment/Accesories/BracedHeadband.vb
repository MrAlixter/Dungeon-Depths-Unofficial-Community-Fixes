Public Class BracedHeadband
    Inherits Accessory

    Sub New()
        '|ID Info|
        setName("Braced_Headband")
        id = 139
        tier = 2

        '|Item Flags|
        usable = False

        '|Stats|
        a_boost = 5
        d_boost = 5
        w_boost = 5
        count = 0
        value = 1100

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(9, False, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(9, False, True)

        '|Description|
        setDesc("An aggressive looking red headband that looks like it can take a hit thanks to a steel plate." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
