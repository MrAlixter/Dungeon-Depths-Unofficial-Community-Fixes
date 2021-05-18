Public Class GelArmor
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Gelatinous_Shell")
        id = 137
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.droppable = False
        rando_inv_allowed = False

        '|Stats|
        h_boost = 20
        MyBase.d_boost = 15
        count = 0
        value = 0

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(52, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(199, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(200, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(201, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(202, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(203, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(204, True, True)
        MyBase.bsize6 = New Tuple(Of Integer, Boolean, Boolean)(205, True, True)
        MyBase.bsize7 = New Tuple(Of Integer, Boolean, Boolean)(206, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(36, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(113, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(114, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(115, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(116, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(117, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(118, True, True)

        '|Description|
        setDesc("An extra layer of a more durable goo for extra protection when donned by a slime.  Unfortunately, due to its weak consisancy slime's are the only ones that can don it." & vbCrLf & _
                              "Fits all sizes." & DDUtils.RNRN & getStatInformation())
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