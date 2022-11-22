
Public Class PhotonBikini
    Inherits Armor

    Public Const ITEM_NAME As String = "Photon_Bikini"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 105
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True
        rando_inv_allowed = False
        anti_slut_ind = 104

        '|Stats|
        m_boost = 7
        d_boost = 2
        count = 0
        value = 3331

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(46, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(155, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(156, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(157, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(158, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(70, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(305, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(306, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(307, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(308, True, True)

        '|Description|
        setDesc("Though at a glance it may seem unlikely, this swimsuit houses a powerful shield generator that harnesses its users mana to withstand impacts." & DDUtils.RNRN &
                "Hardlight Effect" & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        p.perks(perk.hardlight) = 1
    End Sub
End Class
