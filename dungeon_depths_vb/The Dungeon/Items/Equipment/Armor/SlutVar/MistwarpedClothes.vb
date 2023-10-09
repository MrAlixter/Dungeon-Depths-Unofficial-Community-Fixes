Public Class MistwarpedClothes
    Inherits Armor

    Public Const ITEM_NAME As String = "Mistwarped_Clothes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 423
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        show_underboob = True
        anti_slut_ind = 418

        '|Stats|
        s_boost = 10
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(115, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(511, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(512, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(513, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(514, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(515, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(108, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(497, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(498, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(499, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(500, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(501, True, True)

        '|Description|
        setDesc("A pastel pink outfit that seems to boost its wearer's health the less they think.  Each piece of clothing is dotted with slight imperfections, as though they had been woven by an external force..." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getDescription() As Object
        Return "A pastel pink outfit that seems to boost its wearer's health the less they think.  Each piece of clothing is dotted with slight imperfections, as though they had been woven by an external force..." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation()
    End Function

    Public Overrides Function getHBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 27
        Return 7 + Math.Min(30, Math.Max(3, 30 - (2 * (p.will + p.wBuff))))
    End Function
End Class
