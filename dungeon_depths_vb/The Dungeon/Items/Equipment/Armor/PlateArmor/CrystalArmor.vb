Public Class CrystalArmor
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Crystalline_Armor")
        id = 144
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True

        '|Stats|
        MyBase.d_boost = 20
        MyBase.m_boost = 15
        w_boost = 5
        count = 0
        value = 2777

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(53, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(207, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(208, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(209, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(210, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(37, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(38, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(119, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(120, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(121, True, True)

        '|Description|
        setDesc("A set of armor made up of a series of diamond-like plates enhanced by concentrated mana.  While normally these would be extremely brittle, the magical energy lends them a fair amount of durability, and lends their wearer some extra mana." & DDUtils.RNRN &
                       getSizeInformation() & vbCrLf & getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        p.mana += 15
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onEquip(p)
        If p.mana > 15 Then p.mana = Math.Max(0, p.mana - 15)
    End Sub
End Class
