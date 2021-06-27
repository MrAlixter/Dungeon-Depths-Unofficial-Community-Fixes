Public Class CultistCloak
    Inherits Armor

    Dim cloakneg1 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Dim cloak1 As Tuple(Of Integer, Boolean, Boolean) = Nothing

    Sub New()
        '|ID Info|
        setName("Cultist's_Cloak")
        id = 288
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.anti_slut_ind = 265

        '|Stats|
        w_boost = 25
        count = 0
        value = 6400

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(364, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(365, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(366, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(367, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(368, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(349, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(350, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(351, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(352, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(353, True, True)

        MyBase.hood = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)
        MyBase.cloak = New Tuple(Of Integer, Boolean, Boolean)(11, True, False)
        cloakneg1 = New Tuple(Of Integer, Boolean, Boolean)(12, True, False)
        cloak1 = New Tuple(Of Integer, Boolean, Boolean)(13, True, False)

        '|Description|
        setDesc("A blood-red hooded cloak that tingles with arcane energy when touched." & DDUtils.RNRN & _
                        getSizeInformation() & vbcrlf & getStatInformation())
    End Sub

    Public Overrides Function getCloak(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
        Select Case p.buttSize
            Case -2, -1
                Return cloakneg1
            Case 0, 1, 2, 3
                Return cloak
        End Select

        Return cloak
    End Function
End Class
