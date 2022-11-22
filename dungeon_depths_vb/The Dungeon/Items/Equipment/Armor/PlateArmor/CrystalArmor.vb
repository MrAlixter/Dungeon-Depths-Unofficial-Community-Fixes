Public Class CrystalArmor
    Inherits Armor

    Public Const ITEM_NAME As String = "Crystalline_Armor"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 144
        tier = Nothing

        '|Item Flags|
        usable = False
        slut_var_ind = 357
        compress_breast = True

        '|Stats|
        d_boost = 20
        m_boost = 15
        w_boost = 5
        count = 0
        value = 2777

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(53, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(207, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(208, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(209, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(210, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(37, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(38, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(119, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(120, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(121, True, True)

        '|Description|
        setDesc("A set of armor made up of a series of diamond-like plates enhanced by concentrated mana.  While normally these would be extremely brittle, the magical energy lends them a fair amount of durability, and lends their wearer some extra mana." & DDUtils.RNRN &
                       getSizeInformation() & DDUtils.RNRN & getStatInformation())
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
