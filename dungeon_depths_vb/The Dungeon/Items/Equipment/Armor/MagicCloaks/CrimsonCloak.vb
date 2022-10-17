Public Class CrimsonCloak
    Inherits Armor

    Public Const ITEM_NAME As String = "Crimson_Cloak"

    Dim cloakneg1 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Dim cloak1 As Tuple(Of Integer, Boolean, Boolean) = Nothing

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 289
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        hide_rearhair = True
        slut_var_ind = 288

        '|Stats|
        w_boost = 45
        count = 0
        value = 5200

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(84, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(85, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(369, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(370, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(371, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(372, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(82, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(83, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(354, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(355, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(356, True, True)

        hood = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)
        cloak = New Tuple(Of Integer, Boolean, Boolean)(11, True, False)
        cloakneg1 = New Tuple(Of Integer, Boolean, Boolean)(12, True, False)
        cloak1 = New Tuple(Of Integer, Boolean, Boolean)(13, True, False)

        '|Description|
        setDesc("A blood-red hooded cloak that crackles with arcane energy when touched." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
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
