Public Class ImmitationCowbell
    Inherits Accessory

    Public Const ITEM_NAME As String = "Imitation_Cowbell"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 292
        tier = Nothing

        '|Item Flags|
        usable = False
        under_chin = True
        rando_inv_allowed = False
        cursed = True

        '|Stats|
        h_boost = 10
        m_boost = 10
        s_boost = -10
        count = 0
        value = 1434

        '|Image Index|
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(24, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(17, False, True)

        '|Description|
        setDesc("A large metallic bell attached to a collar that rings steadily with its wearer's gait.  Occasionally a small tendril flicks out from the bell..." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Overrides Sub onEquip(ByRef p As Player)
        p.health += 10 / p.getMaxHealth
        p.ongoingTFs.add(New MimicMinoTF(9, 15, 2.0, True))
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        If p.perks(perk.cowbell) > -1 Then p.perks(perk.cowbell) = -1
    End Sub
End Class
