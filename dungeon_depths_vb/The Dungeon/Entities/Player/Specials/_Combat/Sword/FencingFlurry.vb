Public Class FencingFlurry
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Fencing Flurry")
        MyBase.setUOC(False)
        MyBase.setcost(16)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        For i = 1 To 1 + Int(Rnd() * 2) + If(p.equippedWeapon.GetType().IsSubclassOf(GetType(Sword)), 1, 0)
            Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
            dmg += (p.getATK) + (p.equippedWeapon.getABoost(p))
            dmg = Entity.calcDamage(dmg, m.defense * 0.75)

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
        Return "Unleashes a flurry of 1-2 piercing blows, with an addtional hit if they are holding a sword-class weapon."
    End Function
End Class
