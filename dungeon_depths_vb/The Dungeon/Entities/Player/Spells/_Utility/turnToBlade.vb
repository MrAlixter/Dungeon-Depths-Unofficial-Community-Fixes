Public Class turnToBlade
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Turn to Blade")
        MyBase.settier(2)
        MyBase.setcost(28)
    End Sub
    Public Overrides Sub effect()
        If MyBase.getCaster.getWIL < MyBase.getTarget.getWIL And Int(Rnd() * 10) = 1 Then
            TextEvent.pushCombat(CStr("Despite the difference in each of your resolves, Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.r_pronoun & " into a sword!"))
            TextEvent.pushLog(CStr("Critical Hit!  Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.r_pronoun & " into a sword!"))
        ElseIf MyBase.getCaster.getWIL < MyBase.getTarget.getWIL Then
            TextEvent.pushAndLog(CStr("You lack the WILL to transform your opponent!"))
            Exit Sub
        Else
            TextEvent.pushAndLog(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.r_pronoun & " into a sword!"))
        End If

        MyBase.getCaster.inv.setCount(SoulBlade.ITEM_NAME, 1)

        MyBase.getCaster.UIupdate()

        CType(MyBase.getCaster.inv.item(9), SoulBlade).Absorb(MyBase.getTarget)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 2 spell that transforms its target into a sword with a low chance of missing altogether.  If successful, this will end combat instantly."
    End Function
End Class
