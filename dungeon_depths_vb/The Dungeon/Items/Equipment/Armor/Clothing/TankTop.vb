Public Class TankTop
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Tank_Top")
        id = 46
        tier = 2

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True

        '|Stats|
        MyBase.d_boost = 1
        MyBase.s_boost = 5
        count = 0
        value = 400

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(11, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(69, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(66, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(67, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(68, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(56, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(57, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(261, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(262, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(263, True, True)

        '|Description|
        setDesc("A grey tanktop made of a breathable fabric for the athletic." & DDUtils.RNRN &
                          getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
