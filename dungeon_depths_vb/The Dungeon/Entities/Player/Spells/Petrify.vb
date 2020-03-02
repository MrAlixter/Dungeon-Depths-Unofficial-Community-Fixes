Public Class Petrify
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Petrify")
        MyBase.settier(2)
        If Not c Is Nothing AndAlso c.pForm.name.Contains("Gorgon") Then MyBase.setcost(1) Else MyBase.setcost(9)
    End Sub
    Public Overrides Sub effect()
        If getTarget.sName.Equals("Medusa") Or (getCaster.pForm.name.Contains("Gorgon") And MyBase.getTarget.GetType().IsSubclassOf(GetType(Shopkeeper))) Then
            Game.pushLblEvent("Your spell doesn't seem to have done anything...")
            Exit Sub
        End If

        If MyBase.getTarget.GetType() Is GetType(Monster) Then
            Game.pushLstLog(CStr("Your magic strikes the " & MyBase.getTarget.name & " in the chest, turning it briefly to stone!"))
            Game.pushLblCombatEvent(CStr("Your magic strikes the " & MyBase.getTarget.name & " in the chest, turning it briefly to stone!"))
        Else
            Game.pushLstLog(CStr("Your magic strikes " & MyBase.getTarget.name & " in the chest, turning " & MyBase.getTarget.rPronoun & " to stone"))
            Game.pushLblCombatEvent(CStr("Your magic strikes " & MyBase.getTarget.name & " in the chest, turning " & MyBase.getTarget.rPronoun & " to stone"))
        End If
        If MyBase.getTarget.speed / 5 > 0 Then
            Game.pushLstLog(CStr(Math.Ceiling(MyBase.getTarget.speed / 5) & " more until they become a statue!"))
            Game.pushLblCombatEvent(CStr(Math.Ceiling(MyBase.getTarget.speed / 5) & " more until they become a statue!"))
        End If

        If MyBase.getTarget.speed > 0 Then
            MyBase.getTarget.speed -= 5
        Else
            MyBase.getTarget.toStatue()
            Game.pushLstLog(CStr("You see a statue here."))
        End If

    End Sub
End Class
