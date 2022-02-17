
Public Class PhotonArmor
    Inherits Armor

    Public Const ITEM_NAME As String = "Photon_Armor"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 104
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        rando_inv_allowed = False
        MyBase.slut_var_ind = 105

        '|Stats|
        MyBase.m_boost = 12
        MyBase.d_boost = 10
        count = 0
        value = 4331

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(42, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(71, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(145, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(146, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(65, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(66, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(295, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(296, True, True)

        '|Description|
        setDesc("This armor consists of lightweight though fragile black plates of an advanced plastic, alongside a powerful shield generator that harnesses its users mana to withstand impacts." & DDUtils.RNRN &
                       "Hardlight Effect" & DDUtils.RNRN &
                        getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        p.perks(perk.hardlight) = 1
    End Sub
End Class
