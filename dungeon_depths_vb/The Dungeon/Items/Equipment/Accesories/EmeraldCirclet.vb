Public Class EmeraldCirclet
    Inherits Accessory

    Sub New()
        '|ID Info|
        setName("Emerald_Circlet")
        id = 140
        tier = 2

        '|Item Flags|
        usable = False

        '|Stats|
        m_boost = 10
        s_boost = 10
        count = 0
        value = 1100

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(10, False, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(10, False, True)

        '|Description|
        setDesc("A large emerald inset on a gold-alloy band, this circlet is commonly worn by archmages." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
