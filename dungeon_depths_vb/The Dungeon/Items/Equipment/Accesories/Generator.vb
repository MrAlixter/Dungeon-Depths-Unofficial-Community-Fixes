Public Class Generator
    Inherits Accessory

    Sub New()
        '|ID Info|
        setName("Mobile_Powerbank")
        id = 110
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False

        '|Stats|
        MyBase.m_boost = 5
        count = 0
        value = 5000

        '|Image Index|
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(10, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(10, True, True)

        '|Description|
        setDesc("A small yet effective generator that, in addition to condensing mana for later use, powers a communication device.  Too bad there's no signal..." & DDUtils.RNRN &
                       "Mana regeneration effect" & vbCrLf &
                       getStatInformation())
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        p.perks(perk.minmanregen) = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        p.perks(perk.minmanregen) = -1
    End Sub
End Class
