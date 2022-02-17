Public Class turnToCupcake
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Turn to Cupcake")
        MyBase.settier(5)
        MyBase.setcost(17)
    End Sub
    Public Overrides Sub effect()
        If MyBase.getCaster.getWIL < MyBase.getTarget.getWIL And Int(Rnd() * 10) = 1 Then
            TextEvent.pushCombat(CStr("Despite the difference in each of your resolves, Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.r_pronoun & " into a cupcake!"))
            TextEvent.pushLog(CStr("Critical Hit!  Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.r_pronoun & " into a cupcake!"))
        ElseIf MyBase.getCaster.getWIL < MyBase.getTarget.getWIL Then
            TextEvent.pushAndLog(CStr("You lack the WILL to transform your opponent!"))
            Exit Sub
        Else
            TextEvent.pushAndLog(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.r_pronoun & " into a cupcake!"))
        End If

        MyBase.getCaster.inv.add(35, 1)
        MyBase.getCaster.inv.invNeedsUDate = True
        MyBase.getCaster.UIupdate()
        MyBase.getTarget.despawn("cupcake")
    End Sub

    Public Overrides Sub backfire()
        Polymorph.transform(MyBase.getCaster, "Cake")

        MyBase.getCaster.perks(perk.polymorphed) = 1
        TextEvent.pushAndLog(CStr("You turn yourself into a cake-girl!"))
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 5 spell that transforms its target into a cupcake with a medium chance of backfiring or missing altogether.  If successful, this will end combat instantly."
    End Function
End Class
