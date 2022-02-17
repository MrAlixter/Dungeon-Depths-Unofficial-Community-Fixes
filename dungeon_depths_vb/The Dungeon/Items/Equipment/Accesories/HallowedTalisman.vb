Public Class HallowedTalisman
    Inherits Accessory

    Public Const ITEM_NAME As String = "Hallowed_Talisman"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 283
        tier = Nothing

        '|Item Flags|
        usable = False
        under_t_clothes = True

        '|Stats|
        m_boost = 10
        count = 0
        value = 125

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(23, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(23, True, True)

        '|Description|
        setDesc("A simple, beaded necklace that always boosts its wearer's spirit." & DDUtils.RNRN &
                 getStatInformation() & DDUtils.RNRN &
                 "Damage Deflection Effect")
    End Sub
End Class
