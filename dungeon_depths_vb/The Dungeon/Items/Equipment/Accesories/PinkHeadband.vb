Public Class PinkHeadband
    Inherits Accessory

    Public Const ITEM_NAME As String = "Pink_Headband"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 356
        tier = Nothing

        '|Item Flags|
        usable = False
        under_m_hair = True
        rando_inv_allowed = False

        '|Stats|
        a_boost = 1
        count = 0
        value = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(49, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(25, False, True)

        '|Description|
        setDesc("A cute-looking pink headband." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
