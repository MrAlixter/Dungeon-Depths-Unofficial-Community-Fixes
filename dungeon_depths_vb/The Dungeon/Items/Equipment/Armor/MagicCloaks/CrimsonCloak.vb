Public Class CrimsonCloak
    Inherits Armor

    Dim cloakneg1 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Dim cloak1 As Tuple(Of Integer, Boolean, Boolean) = Nothing

    Sub New()
        '|ID Info|
        setName("Crimson_Cloak")
        id = 289
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 288

        '|Stats|
        w_boost = 45
        count = 0
        value = 5200

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(84, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(85, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(369, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(370, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(371, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(372, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(82, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(83, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(354, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(355, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(356, True, True)

        MyBase.hood = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)
        MyBase.cloak = New Tuple(Of Integer, Boolean, Boolean)(11, True, False)
        cloakneg1 = New Tuple(Of Integer, Boolean, Boolean)(12, True, False)
        cloak1 = New Tuple(Of Integer, Boolean, Boolean)(13, True, False)

        '|Description|
        setDesc("A blood-red hooded cloak that crackles with arcane energy when touched." & DDUtils.RNRN &
                        getSizeInformation() & vbcrlf & getStatInformation())
    End Sub

    Public Overrides Function getCloak(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
        Select Case p.buttSize
            Case -2, -1
                Return cloakneg1
            Case 1, 2
                Return cloak
            Case 0, 3
                Return cloak1
        End Select

        Return cloak
    End Function

End Class
