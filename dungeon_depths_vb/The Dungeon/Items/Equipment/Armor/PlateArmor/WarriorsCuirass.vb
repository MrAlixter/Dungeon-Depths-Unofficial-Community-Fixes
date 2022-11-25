Public Class WarriorsCuirass
    Inherits Armor

    Public Const ITEM_NAME As String = "Warrior's_Cuirass"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 19
        tier = 3

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.slut_var_ind = 20

        '|Stats|
        MyBase.a_boost = 5
        MyBase.d_boost = 12
        count = 0
        value = 950

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(8, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(98, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(29, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(30, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(31, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(62, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(63, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(273, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(274, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(275, True, True)

        '|Description|
        setDesc("A protective garment made more for elite fighters rather than fashion-minded common folk." & DDUtils.RNRN &
                                getSizeInformation() & DDUtils.RNRN & getStatInformation())
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
End Class
