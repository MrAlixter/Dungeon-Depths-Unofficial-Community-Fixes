Public Class HallowedTalisman
    Inherits Accessory

    Sub New()
        '|ID Info|
        setName("Hallowed_Talisman")
        id = 283
        tier = Nothing

        '|Item Flags|
        usable = False
        under_clothes = True

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
