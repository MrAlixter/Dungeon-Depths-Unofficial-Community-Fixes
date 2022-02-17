Public Class Blindfold
    Inherits Glasses

    Public Const ITEM_NAME As String = "Blindfold"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 161
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        m_boost = 2
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(10, True, True)

        '|Description|
        setDesc("A cloth band capable of blocking out one's vision completely." & DDUtils.RNRN &
                getStatInformation())
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        p.perks(perk.blind) = 1
        Game.drawBoard()
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.perks(perk.blind) = -1
        Game.drawBoard()
    End Sub
End Class
