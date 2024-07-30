Public Class RedHeadband
    Inherits Accessory

    Public Const ITEM_NAME As String = "Red_Headband"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 67
        tier = Nothing

        '|Item Flags|
        usable = False
        under_m_hair = True

        '|Stats|
        a_boost = 1
        count = 0
        value = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(2, True, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(1, False, False)

        '|Description|
        setDesc("A crimson length of cloth to be wrapped around the forehead of a fighter." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
