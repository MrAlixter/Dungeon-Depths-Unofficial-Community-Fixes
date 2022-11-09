Public Class FaerieBlossom
    Inherits Accessory

    Public Const ITEM_NAME As String = "Faerie_Blossom"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 374
        tier = Nothing

        '|Item Flags|
        usable = False
        cursed = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 260

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(51, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(51, True, True)

        '|Description|
        setDesc("A small white flower, jinxed by a tricksy faerie." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
