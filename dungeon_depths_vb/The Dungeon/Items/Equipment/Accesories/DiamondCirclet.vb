Public Class DiamondCirclet
    Inherits Accessory

    Public Const ITEM_NAME As String = "Diamond_Circlet"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 355
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        m_boost = 2
        count = 0
        value = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(48, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(24, False, True)

        '|Description|
        setDesc("A set of small diamonds inset on a rose-gold band, this circlet is commonly worn by mages." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
