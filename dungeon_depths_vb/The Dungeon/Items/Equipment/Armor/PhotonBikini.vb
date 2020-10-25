
Public Class PhotonBikini
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Photon_Bikini")
        id = 105
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.isRandoTFAcceptable = False
        MyBase.antiSlutVarInd = 105

        '|Stats|
        MyBase.mBoost = 7
        MyBase.dBoost = 2
        MyBase.count = 0
        MyBase.value = 3331

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(46, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(155, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(156, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(157, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(158, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(70, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(305, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(306, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(307, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(308, True, True)

        '|Description|
        MyBase.setDesc("Though at a glance it may seem unlikely, this swimsuit houses a powerful shield generator that harnesses its users mana to withstand impacts." & DDUtils.RNRN & _
                        "Hardlight Effect" & DDUtils.RNRN &
                        getSizeInformation() & vbCrLf & getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        p.perks(perk.hardlight) = 1
    End Sub
End Class
