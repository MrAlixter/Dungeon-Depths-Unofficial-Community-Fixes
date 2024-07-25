Public Class StabBarrage
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Stab Barrage")
        MyBase.setUOC(False)
        MyBase.setcost(7)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        For i = 1 To 3 + Int(Rnd() * 3)
            Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
            dmg += (p.getATK)
            dmg = Entity.calcDamage(dmg, m.defense) * If(p.equippedWeapon.GetType().IsSubclassOf(GetType(Dagger)), 1.0, 0.5)

            altSpecHit(getName, dmg, getUser, getTarget)

            If i <> 1 Then p.stamina -= getCost()

            If m.isDead Or p.stamina < getCost() Then Exit For
        Next
    End Sub

    Public Shared Sub altSpecHit(spec As String, dmg As Integer, user As Player, target As NPC, Optional postfix As String = "")
        Dim t_took_dmg = target.takeDMG(dmg, user)

        If t_took_dmg And Not target.isDead Then
            TextEvent.push(CStr("You hit " & target.getNameWithTitle() & " for " & DDUtils.formatBigNumber(dmg) & " damage!" & postfix))
            TextEvent.pushLog(CStr("You hit " & target.getNameWithTitle() & " for " & DDUtils.formatBigNumber(dmg) & " damage!" & postfix))
        ElseIf t_took_dmg Then
            TextEvent.push3rdLastLog(CStr("You hit " & target.getNameWithTitle() & " for " & DDUtils.formatBigNumber(dmg) & " damage!" & postfix))
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Unleashes a flurry of 3-6 quick stabs that do not activate on-attack triggers.  If not used with a dagger, the damage of each hit is halved."
    End Function
End Class
