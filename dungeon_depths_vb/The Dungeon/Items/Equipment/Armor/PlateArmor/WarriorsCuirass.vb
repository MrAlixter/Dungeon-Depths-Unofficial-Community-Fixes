Public Class WarriorsCuirass
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Warrior's_Cuirass")
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
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(8, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(8, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(29, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(30, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(31, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(62, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(63, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(273, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(274, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(275, True, True)

        '|Description|
        setDesc("A protective garment made more for elite fighters rather than fashion-minded common folk." & DDUtils.RNRN &
                                getSizeInformation() & vbCrLf & getStatInformation())
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
