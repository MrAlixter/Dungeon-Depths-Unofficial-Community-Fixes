Public Class turnToBlade
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As Monster)
        MyBase.New(c, t)
        MyBase.setName("Turn to Blade")
        MyBase.settier(2)
        MyBase.setcost(9)
    End Sub
    Public Overrides Sub effect()
        MyBase.getCaster.p_inventory.add(9, 1)
        If MyBase.getCaster.p_inventory.item(9).count < 1 Then MyBase.getCaster.p_inventory.item(9).remove()
        MyBase.getCaster.UIupdate()
        CType(MyBase.getCaster.p_inventory.item(9), SoulBlade).Absorb(MyBase.getTarget)
        Game.lstLog.Items.Add(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.rPronoun & " into a sword!"))
        Game.pushLblCombatEvent(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.rPronoun & " into a sword!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
End Class
