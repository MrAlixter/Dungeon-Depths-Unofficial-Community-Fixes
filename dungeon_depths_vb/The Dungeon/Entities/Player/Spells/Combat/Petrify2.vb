Public Class Petrify2
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Petrify II")
        MyBase.settier(4)
        If Not c Is Nothing AndAlso c.formName.Contains("Gorgon") Then MyBase.setcost(2) Else MyBase.setcost(14)
    End Sub
    Public Overrides Sub effect()
        If getTarget.sName.Equals("Medusa") Or (getCaster.formName.Contains("Gorgon") And MyBase.getTarget.GetType().IsSubclassOf(GetType(Shopkeeper))) Then
            Game.pushLblEvent("Your spell doesn't seem to have done anything...")
            Exit Sub
        End If

        If MyBase.getTarget.GetType() Is GetType(Monster) Then
            Game.pushLogAndEvent(CStr("Your magic strikes the " & MyBase.getTarget.name & " in the chest, turning it briefly to stone!"))
        Else
            Game.pushLogAndEvent(CStr("Your magic strikes " & MyBase.getTarget.name & " in the chest, turning " & MyBase.getTarget.rPronoun & " to stone"))
        End If
        If MyBase.getTarget.speed / 10 > 0 Then
            Game.pushLogAndEvent(CStr(Math.Ceiling(MyBase.getTarget.speed / 10) & " more until they become a statue!"))
        End If

        If MyBase.getTarget.speed > 0 Then
            MyBase.getTarget.speed -= 10
        Else
            MyBase.getTarget.toStatue()
            Game.pushLstLog(CStr("You see a statue here."))
        End If
    End Sub
    Public Overrides Sub backfire()
        Dim p = Game.player1

        p.savePState()

        p.defense = 40

        Dim pturns = Int(Rnd() * 5) + 3
        p.petrify(Color.LightGray, pturns)
        Game.pushLstLog(CStr("You petrify yourself for " & pturns - 1 & " turns!"))
        Game.pushLblCombatEvent(CStr("You petrify yourself for " & pturns - 1 & " turns!"))
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 4 spell that turns its target into little more than a stone statue with a medium chance of backfiring and a low chance of missing altogether.  This spell is twice as effective as the standard Petrify, and while it comes effortlessly to Gorgons it is also uneffective against them."
    End Function
End Class
