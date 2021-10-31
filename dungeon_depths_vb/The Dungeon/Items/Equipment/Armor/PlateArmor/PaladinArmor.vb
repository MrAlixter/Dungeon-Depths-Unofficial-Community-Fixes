
Public Class PaladinArmor
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Paladin's_Armor")
        id = 301
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True

        '|Stats|
        m_boost = 10
        d_boost = 20
        w_boost = 10
        count = 0
        value = 1840

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(88, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(89, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(387, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(388, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(389, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(85, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(370, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(371, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(372, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(373, True, True)

        '|Description|
        setDesc("A thick set of plate armor that also bolsters its wearer's magical abilities." & DDUtils.RNRN &
                getSizeInformation() & vbCrLf &
                getStatInformation())
    End Sub
End Class
