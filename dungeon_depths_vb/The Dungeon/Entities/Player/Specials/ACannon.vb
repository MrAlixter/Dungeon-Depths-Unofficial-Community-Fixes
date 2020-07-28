Public Class ACannon
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Aura Cannon")
        MyBase.setUOC(False)
        MyBase.setcost(u.mana * ((u.attack + u.aBuff) * u.pClass.a * u.pForm.a) / 10)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = p.mana * ((p.attack + p.aBuff) * p.pClass.a * p.pForm.a) / 10
        p.mana = 0
        m.takeDMG(dmg, p)

        Game.pushLstLog("Aura Cannon!")
        Game.pushLblCombatEvent("Aura Cannon!" & vbCrLf & "You focus all of your internal energy into your hands, using it to fire a beam at your opponent.  The blast hits them for " & dmg & " damage!")
    End Sub
End Class
