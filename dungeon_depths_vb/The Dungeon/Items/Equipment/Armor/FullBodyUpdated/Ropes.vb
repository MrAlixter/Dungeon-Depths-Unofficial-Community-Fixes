Public Class Ropes
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Ropes")
        id = 54
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.isCursed = True
        MyBase.bindsWearer = True
        hidesDick = False

        '|Stats|
        MyBase.aBoost = -5
        MyBase.dBoost = -5
        MyBase.sBoost = -5
        MyBase.count = 0
        MyBase.value = 100

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(13, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(63, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(72, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(73, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(74, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(75, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(76, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(19, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(44, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(45, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(46, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(48, True, True)

        '|Description|
        MyBase.setDesc("A tightened set of ropes that both reduces mobility and leaves one nearly naked." & DDUtils.RNRN & _
                              getSizeInformation() & vbCrLf & getStatInformation() & vbCrLf &
                             "May not be easy to remove")
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        p.reverseUSRoute()
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.bindsWearer = False
        p.reverseAllRoute()
        MyBase.bindsWearer = True
    End Sub
End Class
