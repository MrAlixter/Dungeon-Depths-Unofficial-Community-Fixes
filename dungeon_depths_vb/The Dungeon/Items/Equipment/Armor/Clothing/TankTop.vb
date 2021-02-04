Public Class TankTop
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Tank_Top")
        id = 46
        tier = 2

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True

        '|Stats|
        MyBase.dBoost = 1
        MyBase.sBoost = 5
        MyBase.count = 0
        MyBase.value = 400

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
        MyBase.setDesc("A grey tanktop made of a breathable fabric for the athletic." & DDUtils.RNRN &
                          getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
