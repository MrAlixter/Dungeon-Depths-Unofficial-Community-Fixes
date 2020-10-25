Public Class Snowball
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Snowball")
        MyBase.settier(1)
        MyBase.setcost(0)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 10
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 3)

        If MyBase.getTarget.isStunned = True Then
            '"critical" hit
            dmg *= MyBase.getTarget.stunct + 2
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d31 + d32)
            Game.pushLstLog(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!  Oof, what a throw!"))
            Game.pushLblCombatEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!  Oof, what a throw!"))
            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
        Else
            'non critical hit
            dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d31 + d32)
            'should target be stunned?
            If Int(Rnd() * 2) = 0 Then
                MyBase.getTarget.isStunned = True
                MyBase.getTarget.stunct = 3
                Game.pushLstLog(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!  They are stunned by the spell!"))
                Game.pushLblCombatEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!  They are stunned by the spell!"))
            Else
                Game.pushLstLog(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
                Game.pushLblCombatEvent(CStr("You hit the " & MyBase.getTarget.name & " for " & dmg & " damage!"))
            End If

            MyBase.getTarget.takeDMG(dmg, MyBase.getCaster)
        End If
    End Sub
End Class
