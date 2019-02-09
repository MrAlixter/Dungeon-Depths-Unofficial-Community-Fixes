Public Class Petrify2
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As Monster)
        MyBase.New(c, t)
        MyBase.setName("Petrify II")
        MyBase.settier(4)
        MyBase.setcost(14)
    End Sub
    Public Overrides Sub effect()
        If MyBase.getTarget.GetType() Is GetType(Monster) Then
            Game.pushLstLog(CStr("Your magic strikes the " & MyBase.getTarget.name & " in the chest, turning it briefly to stone!"))
            Game.pushLblCombatEvent(CStr("Your magic strikes the " & MyBase.getTarget.name & " in the chest, turning it briefly to stone!"))
        Else
            Game.pushLstLog(CStr("Your magic strikes " & MyBase.getTarget.name & " in the chest, turning " & MyBase.getTarget.rPronoun & " to stone"))
            Game.pushLblCombatEvent(CStr("Your magic strikes " & MyBase.getTarget.name & " in the chest, turning " & MyBase.getTarget.rPronoun & " to stone"))
        End If
        If MyBase.getTarget.speed / 10 > 0 Then
            Game.pushLstLog(CStr(Math.Ceiling(MyBase.getTarget.speed / 10) & " more until they become a statue!"))
            Game.pushLblCombatEvent(CStr(Math.Ceiling(MyBase.getTarget.speed / 10) & " more until they become a statue!"))
        End If

        If MyBase.getTarget.speed > 0 Then
            MyBase.getTarget.speed -= 10
        Else
            MyBase.getTarget.toStatue()
            Game.pushLstLog(CStr("You see a statue here."))
        End If
    End Sub
    Public Overrides Sub backfire()
        Dim p = Game.player
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
        p.defence = 40

        Dim pturns = Int(Rnd() * 5) + 3
        p.petrify(Color.LightGray, pturns)
        Game.pushLstLog(CStr("You petrify yourself for " & pturns - 1 & " turns!"))
        Game.pushLblCombatEvent(CStr("You petrify yourself for " & pturns - 1 & " turns!"))
    End Sub
End Class
