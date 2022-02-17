Public Class RubyCirclet
    Inherits Accessory

    Public Const ITEM_NAME As String = "Ruby_Circlet"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 68
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        m_boost = 2
        count = 0
        value = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(3, True, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(2, False, False)

        '|Description|
        setDesc("A ruby inset on a gold band, this circlet is commonly worn by mages." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
