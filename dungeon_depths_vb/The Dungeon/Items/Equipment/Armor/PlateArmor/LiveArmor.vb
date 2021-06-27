Public Class LiveArmor
    Inherits Armor
    Sub New()
        '|ID Info|
        setName("Living_Armor")
        id = 55
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.cursed = True
        rando_inv_allowed = False
        MyBase.slut_var_ind = 56

        '|Stats|
        MyBase.d_boost = 6
        count = 0
        value = 350

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(15, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(15, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(81, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(83, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(85, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(87, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(54, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(244, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(244, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(245, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(246, True, True)

        '|Description|
        setDesc("A suit of living armor embued with a the soul of a mimic." & DDUtils.RNRN & _
                                   getSizeInformation() & vbcrlf & getStatInformation() &
                            "The mimic's movment continually raises lust" & vbCrLf & _
                            "May not be easy to remove")
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        If p.perks(perk.livearm) < 0 Then p.perks(perk.livearm) = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        If p.perks(perk.livearm) > -1 Then p.perks(perk.livearm) = -1
    End Sub
End Class
