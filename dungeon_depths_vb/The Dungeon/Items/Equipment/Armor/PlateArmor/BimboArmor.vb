Public Class BimboArmor
    Inherits Armor

    Public Const ITEM_NAME As String = "Mistwarped_Armor"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 418
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        d_boost = 27
        s_boost = 10
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(114, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(506, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(507, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(508, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(509, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(510, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(107, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(492, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(493, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(494, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(495, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(496, True, True)

        '|Description|
        setDesc("A pastel pink set of armor that seems to provide more defense the less its wearer thinks.  Each plate is dotted with slight imperfections, as though it has been stretched into place by an external force..." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getDescription() As Object
        Return "A pastel pink set of armor that seems to provide more defense the less its wearer thinks.  Each plate is dotted with slight imperfections, as though it has been stretched into place by an external force..." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation()
    End Function

    Public Overrides Function getDBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 27
        Return 7 + Math.Min(30, Math.Max(3, 30 - (2 * (p.will + p.wBuff))))
    End Function
End Class
