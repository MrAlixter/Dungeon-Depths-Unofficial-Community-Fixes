Public Class FaeQueensCrown
    Inherits Accessory

    Public Const ITEM_NAME As String = "Fae_Queen's_Crown"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 376
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        m_boost = 50
        w_boost = 25
        count = 0
        value = 9999

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(52, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(52, True, True)

        '|Description|
        setDesc("An ornate piece of regal headwear, seemingly made from a jet-black metal of some kind.  It has a subtle minty glow to it, belying the immense magical power that dwells within." & DDUtils.RNRN &
                 getStatInformation() & DDUtils.RNRN &
                 "Prevents spells from backfiring or missing.")
    End Sub
End Class
