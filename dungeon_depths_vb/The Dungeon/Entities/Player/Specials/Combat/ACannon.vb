Public Class ACannon
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Aura Cannon")
        MyBase.setUOC(False)
        MyBase.setcost(0)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = p.mana * ((p.attack + p.aBuff) * p.pClass.a * p.pForm.a) / 10
        p.mana = 0

        dmg = p.getSpellDamage(m, dmg)

        Dim t_took_dmg = m.takeDMG(dmg, p)

        If t_took_dmg And Not m.isDead Then
            TextEvent.pushLog("Aura Cannon!  You fire a beam that hits " & getTarget.getNameWithTitle & " for " & dmg & " damage!")
            TextEvent.pushCombat("Aura Cannon!" & DDUtils.RNRN & "You focus all of your internal energy into your hands, and fire a beam at your opponent.  The blast hits " & m.pronoun & " for " & dmg & " damage!")
        ElseIf t_took_dmg Then
            TextEvent.push3rdLastLog(CStr("Aura Cannon!  You fire a beam that hits " & getTarget.getNameWithTitle & " for " & dmg & " damage!"))
        End If
    End Sub

    Public Overrides Function getCost() As Integer
        Return Math.Min(100, (getUser.mana * ((getUser.attack + getUser.aBuff) * getUser.pClass.a * getUser.pForm.a) / 10))
    End Function

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Burns through all of its user's MP to deal massive magic damage."
    End Function
End Class
