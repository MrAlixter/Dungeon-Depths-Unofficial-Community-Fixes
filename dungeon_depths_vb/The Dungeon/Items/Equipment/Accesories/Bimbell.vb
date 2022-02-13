Public Class Bimbell
    Inherits Accessory

    Sub New()
        '|ID Info|
        setName("Bimbell")
        id = 197
        tier = 3

        '|Item Flags|
        usable = False

        '|Stats|
        h_boost = 20
        w_boost = -1
        count = 0
        value = 434

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(17, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(16, False, True)

        '|Description|
        setDesc("A large metal bell attached to a pink collar that rings hypnotically with its wearer's gait." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Overrides Sub onEquip(ByRef p As Player)
        p.health += 40 / p.getMaxHealth
        p.ongoingTFs.Add(New BimBellTF(9, 15, 2.0, True))
        If p.health > 1 Then p.health = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        If p.perks(perk.cowbell) > -1 Then p.perks(perk.cowbell) = -1
        If p.health > 1 Then p.health = 1
    End Sub
End Class
