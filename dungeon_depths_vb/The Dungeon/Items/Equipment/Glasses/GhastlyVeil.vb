Public Class GhastlyVeil
    Inherits Glasses

    Public Const ITEM_NAME As String = "Ghastly_Veil"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 460
        tier = Nothing

        '|Item Flags|
        usable = False
        over_acce = True
        cursed = True

        '|Stats|
        m_boost = 2
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(15, True, True)

        '|Description|
        setDesc("A cloth band capable of blocking out one's vision completely." & DDUtils.RNRN &
                "While it also bestows its user with spectral sight, it will be difficuly to remove from its wearer's face." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        p.perks(perk.blind) = 2
        p.perks(perk.esper) = 2
        Game.drawBoard()
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        If p.perks(perk.esper) = 2 Then p.perks(perk.blind) = -1
        If p.perks(perk.esper) = 2 Then p.perks(perk.esper) = -1
        Game.drawBoard()
    End Sub
End Class
