Public Class Petrify
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Petrify")
        MyBase.settier(2)
        MyBase.setcost(9)
    End Sub
    Public Overrides Sub effect()
        If getTarget.sName.Equals("Medusa") Or (getCaster.formName.Contains("Gorgon") And MyBase.getTarget.GetType().IsSubclassOf(GetType(Shopkeeper))) Then
            TextEvent.push("Your spell doesn't seem to have done anything...")
            Exit Sub
        End If

        TextEvent.pushAndLog(CStr("Your magic strikes " & target.getNameWithTitle() & " in the chest, turning " & MyBase.getTarget.r_pronoun & " to stone."))

        petrifyEffect(5, MyBase.getTarget)
    End Sub

    Public Shared Sub petrifyEffect(ByVal amt As Integer, ByRef target As NPC)
        If target.speed / amt > 0 Then
            TextEvent.pushAndLog(CStr(Math.Ceiling(target.speed / amt) & " more until they become a statue!"))
        End If

        If target.speed > 0 Then
            target.speed -= 5
        Else
            target.toStatue()
            TextEvent.pushLog("You see a statue here.")
        End If
    End Sub

    Public Overrides Function getcost() As Integer
        If Not getCaster() Is Nothing AndAlso getCaster.formName.Contains("Gorgon") Then Return 1 Else Return 9
    End Function

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 2 spell that slowly turns its target into little more than a stone statue with a low chance of missing altogether.  While this spell comes effortlessly to Gorgons it is also uneffective against them."
    End Function
End Class
