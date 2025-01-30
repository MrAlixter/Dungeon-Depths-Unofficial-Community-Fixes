Public Class turnToBlade
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Turn to Blade")
        settier(2)
        setcost(28)
    End Sub
    Public Overrides Sub effect()
        '| - TF Description - |
        If getCaster.getWIL < getTarget.getWIL And getCaster.passDieRoll(10, 1) Then
            TextEvent.pushCombat("Despite the difference in each of your resolves, Your spell hits " & getTarget.getNameWithTitle & ", turning " & getTarget.r_pronoun & " into a sword!")
            TextEvent.pushLog("Critical Hit!  Your spell hits " & getTarget.getNameWithTitle & ", turning " & getTarget.r_pronoun & " into a sword!")
        ElseIf getCaster.getWIL < getTarget.getWIL Then
            TextEvent.pushAndLog("You lack the WILL to transform your opponent!")
            Exit Sub
        Else
            TextEvent.pushAndLog("Your spell hits " & getTarget.getNameWithTitle & ", turning " & getTarget.r_pronoun & " into a sword!")
        End If

        '| - TF Effects - |
        getCaster.inv.setCount(SoulBlade.ITEM_NAME, 1)
        getTarget.inanimateTF(getCaster, SoulBlade.ITEM_NAME, False)
        getTarget.toBlade()

        '| - Cleanup - |
        getCaster().UIupdate()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 2 spell that transforms its target into a sword with a low chance of missing altogether.  If successful, this will end combat instantly."
    End Function
End Class
