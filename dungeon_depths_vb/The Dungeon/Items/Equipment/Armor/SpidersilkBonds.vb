Public Class SpidersilkBonds
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Spidersilk_Bonds")
        id = 239
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.isCursed = True
        MyBase.bindsWearer = True
        MyBase.isRandoTFAcceptable = False
        hidesDick = False

        '|Stats|
        MyBase.aBoost = -13
        MyBase.sBoost = -13
        MyBase.count = 0
        MyBase.value = 25

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(73, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(74, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(335, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(336, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(337, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(338, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(339, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(72, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(318, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(319, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(320, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(321, True, True)

        '|Description|
        MyBase.setDesc("A tight, binding web of spidersilk." & DDUtils.RNRN & _
                       getSizeInformation() & vbCrLf & vbCrLf &
                       "-13 ATK" & vbCrLf &
                       "-13 SPD" & vbCrLf &
                       "May not be easy to remove")
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.pForm.canBeBound Then
            Equipment.equipArmor(p, "Naked")
            Game.pushLblEvent("You effortlessly break your bonds.")
            Game.pushLstLog("You effortlessly break your bonds.")
        End If
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.bindsWearer = False
        MyBase.bindsWearer = True
    End Sub
End Class
