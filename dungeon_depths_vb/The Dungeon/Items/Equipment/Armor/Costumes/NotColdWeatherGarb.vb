Public Class NotColdWeatherGarb
    Inherits Armor

    Public Const ITEM_NAME As String = "Not-So-Cold_Weather_Garb"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 425
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        rando_inv_allowed = False

        '|Stats|
        m_boost = 15
        d_boost = 5
        s_boost = 15
        count = 0
        value = 1699

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(116, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(516, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(517, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(518, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(519, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(520, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(521, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(522, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(109, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(502, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(503, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(504, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(505, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(506, True, True)

        '|Description|
        setDesc("This winter outfit seems to have been put together to more for form than function.  Its scarf pulses with some sort of magic force, but other than that it doesn't provide much in the way of protection- neither from attacks nor from the cold." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        p.learnSpell("Snowball")
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.forgetSpell("Snowball")
    End Sub
End Class
