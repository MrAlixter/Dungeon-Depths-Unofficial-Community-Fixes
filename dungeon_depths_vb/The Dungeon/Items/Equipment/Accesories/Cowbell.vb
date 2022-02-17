Public Class Cowbell
    Inherits Accessory

    Public Const ITEM_NAME As String = "Cowbell"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 70
        tier = 2

        '|Item Flags|
        usable = False

        '|Stats|
        h_boost = 20
        w_boost = -1
        count = 0
        value = 434

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(8, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(4, False, True)

        '|Description|
        setDesc("A large brass bell attached to a collar that rings steadily with its wearer's gait." & DDUtils.RNRN &
                getStatInformation())

    End Sub

    Overrides Sub onEquip(ByRef p As Player)
        p.health += 20 / p.getMaxHealth
        p.ongoingTFs.Add(New MinoFTF(9, 15, 2.0, True))
        If p.health > 1 Then p.health = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        If p.perks(perk.cowbell) > -1 Then p.perks(perk.cowbell) = -1
        If p.health > 1 Then p.health = 1
    End Sub
End Class
