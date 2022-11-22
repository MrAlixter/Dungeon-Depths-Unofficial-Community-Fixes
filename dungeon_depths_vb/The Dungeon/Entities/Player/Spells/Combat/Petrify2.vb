Public Class Petrify2
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Petrify II")
        MyBase.settier(4)
        MyBase.setcost(14)
    End Sub
    Public Overrides Sub effect()
        If getTarget.sName.Equals("Medusa") Or (getCaster.formName.Contains("Gorgon") And MyBase.getTarget.GetType().IsSubclassOf(GetType(Shopkeeper))) Then
            TextEvent.push("Your spell doesn't seem to have done anything...")
            Exit Sub
        End If

        TextEvent.pushAndLog(CStr("Your magic strikes " & target.getNameWithTitle() & " in the chest, turning " & MyBase.getTarget.r_pronoun & " to stone."))

        Petrify.petrifyEffect(10, MyBase.getTarget)
    End Sub
    Public Overrides Sub backfire()
        Dim p = Game.player1

        p.savePState()

        p.defense = 40

        Dim pturns = Int(Rnd() * 5) + 3
        p.petrify(Color.LightGray, pturns)
        TextEvent.pushLog(CStr("You petrify yourself for " & pturns - 1 & " turns!"))
        TextEvent.pushCombat(CStr("You petrify yourself for " & pturns - 1 & " turns!"))
    End Sub

    Public Overrides Function getcost() As Integer
        If Not getCaster() Is Nothing AndAlso getCaster.formName.Contains("Gorgon") Then Return 2 Else Return 14
    End Function

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 4 spell that turns its target into little more than a stone statue with a medium chance of backfiring and a low chance of missing altogether.  This spell is twice as effective as the standard Petrify, and while it comes effortlessly to Gorgons it is also uneffective against them."
    End Function
End Class
