Public Class SorcerersRobes
    Inherits Armor

    Public Const ITEM_NAME As String = "Sorcerer's_Robes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 17
        tier = 3

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 18

        '|Stats|
        MyBase.d_boost = 7
        MyBase.m_boost = 10
        count = 0
        value = 950

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(7, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(7, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(21, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(22, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(23, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(24, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(60, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(95, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(267, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(268, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(269, True, True)

        '|Description|
        setDesc("A protective garment made more for pratical funtion than for fashion. " & DDUtils.RNRN &
                                          getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub

    Public Overrides Function getTier() As Integer
        If Game.currFloor Is Nothing Then Return 3
        Select Case Game.currFloor.floorNumber
            Case 1, 2
                Return 3
            Case Else
                Return 2
        End Select

    End Function
End Class
