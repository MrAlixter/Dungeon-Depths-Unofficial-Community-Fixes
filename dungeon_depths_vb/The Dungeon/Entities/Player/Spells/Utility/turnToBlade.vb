Public Class turnToBlade
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Turn to Blade")
        MyBase.settier(2)
        MyBase.setcost(28)
    End Sub
    Public Overrides Sub effect()
        If MyBase.getCaster.getWIL < MyBase.getTarget.getWIL And Int(Rnd() * 10) = 1 Then
            Game.pushLblCombatEvent(CStr("Despite the difference in each of your resolves, Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.rPronoun & " into a sword!"))
            Game.pushLstLog(CStr("Critical Hit!  Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.rPronoun & " into a sword!"))
        ElseIf MyBase.getCaster.getWIL < MyBase.getTarget.getWIL Then
            Game.pushLogAndEvent(CStr("You lack the WILL to transform your opponent!"))
            Exit Sub
        Else
            Game.pushLogAndEvent(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.rPronoun & " into a sword!"))
        End If

        MyBase.getCaster.inv.add(9, 1)
        If MyBase.getCaster.inv.item(9).count < 1 Then MyBase.getCaster.inv.item(9).remove()
        MyBase.getCaster.UIupdate()
        CType(MyBase.getCaster.inv.item(9), SoulBlade).Absorb(MyBase.getTarget)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 5 spell that transforms its target into a sword with a medium chance of backfiring or missing altogether.  If successful, this will end combat instantly."
    End Function
End Class
