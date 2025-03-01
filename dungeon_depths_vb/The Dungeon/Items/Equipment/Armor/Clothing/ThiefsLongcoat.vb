Public Class TheifsLongcoat
    Inherits Armor

    Public Const ITEM_NAME As String = "Theif's_Longcoat"

    Dim cloakneg1 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Dim cloak1 As Tuple(Of Integer, Boolean, Boolean) = Nothing

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 443
        tier = 3

        '|Item Flags|
        usable = False
        compress_breast = True
        hide_rearhair = True
        slut_var_ind = 457

        '|Stats|
        a_boost = 5
        d_boost = 7
        s_boost = 6
        count = 0
        value = 950

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(120, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(121, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(530, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(531, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(532, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(533, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(112, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(113, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(516, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(517, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(518, True, True)

        hood = New Tuple(Of Integer, Boolean, Boolean)(30, True, True)
        cloak = New Tuple(Of Integer, Boolean, Boolean)(35, True, False)
        cloakneg1 = New Tuple(Of Integer, Boolean, Boolean)(36, True, False)
        cloak1 = New Tuple(Of Integer, Boolean, Boolean)(37, True, False)

        '|Description|
        setDesc("A sneaky cloak for a sneaky bloke." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier(ByVal floor_num As Integer) As Integer
        If Game.currFloor Is Nothing Then Return 3
        Select Case Game.currFloor.floorNumber
            Case 1, 2
                Return 3
            Case Else
                Return 2
        End Select

    End Function

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
