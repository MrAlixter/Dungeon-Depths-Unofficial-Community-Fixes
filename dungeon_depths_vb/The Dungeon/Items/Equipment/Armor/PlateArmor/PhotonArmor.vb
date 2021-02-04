
Public Class PhotonArmor
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Photon_Armor")
        id = 104
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.isRandoTFAcceptable = False
        MyBase.slutVarInd = 105

        '|Stats|
        MyBase.mBoost = 12
        MyBase.dBoost = 10
        MyBase.count = 0
        MyBase.value = 4331

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(42, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(71, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(145, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(146, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(65, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(66, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(295, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(296, True, True)

        '|Description|
        MyBase.setDesc("This armor consists of lightweight though fragile black plates of an advanced plastic, alongside a powerful shield generator that harnesses its users mana to withstand impacts." & DDUtils.RNRN &
                       "Hardlight Effect" & DDUtils.RNRN &
                        getSizeInformation() & vbCrLf & getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        p.perks(perk.hardlight) = 1
    End Sub
End Class
