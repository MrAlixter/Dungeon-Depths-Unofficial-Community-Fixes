Public Class turnToPanties
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Turn to Panties")
        MyBase.settier(2)
        MyBase.setcost(32)
    End Sub
    Public Overrides Sub effect()
        If MyBase.getCaster.getWIL < MyBase.getTarget.getWIL And Int(Rnd() * 10) = 1 Then
            TextEvent.pushCombat(CStr("Despite the difference in each of your resolves, Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.r_pronoun & " into a pair of panties!"))
            TextEvent.pushLog(CStr("Critical Hit!  Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.r_pronoun & " into a pair of panties!"))
        ElseIf MyBase.getCaster.getWIL < MyBase.getTarget.getWIL Then
            TextEvent.pushAndLog(CStr("You lack the WILL to transform your opponent!"))
            Exit Sub
        Else
            TextEvent.pushAndLog(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.r_pronoun & " into a pair of panties!"))
        End If

        MyBase.getCaster.inv.setCount(PPanties.ITEM_NAME, 1)

        MyBase.getCaster.UIupdate()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 2 spell that transforms its target into a pair of panties with a low chance of missing altogether.  If successful, this will end combat instantly."
    End Function
End Class
