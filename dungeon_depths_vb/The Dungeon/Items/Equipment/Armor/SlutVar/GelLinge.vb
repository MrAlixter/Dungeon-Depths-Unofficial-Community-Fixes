Public Class GelLinge
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Gelatinous_Negligee")
        id = 138
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.droppable = False
        rando_inv_allowed = False

        '|Stats|
        h_boost = 30
        count = 0
        value = 0

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(51, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(191, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(192, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(193, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(194, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(195, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(196, True, True)
        MyBase.bsize6 = New Tuple(Of Integer, Boolean, Boolean)(197, True, True)
        MyBase.bsize7 = New Tuple(Of Integer, Boolean, Boolean)(198, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(58, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(281, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(282, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(283, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(284, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(285, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(286, True, True)

        '|Description|
        setDesc("Negligee might even be too much to describe this skimpy outfit formed from the a pink goo that unfortunately only slimes can wear." & DDUtils.RNRN &
                        getSizeInformation() & vbCrLf & getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        If p.inv.getCountAt(getName) > 1 Then p.inv.add(getName, 1)
        'If Not p.formName.Contains("Slime") And Not p.formName.Contains("Goo") Then
        '    Equipment.clothesChange(p, "Naked")
        '    Game.pushLblEvent("Your clothes melt off!")
        '    p.drawPort()
        'End If
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.inv.add(getName, -1)
    End Sub
End Class