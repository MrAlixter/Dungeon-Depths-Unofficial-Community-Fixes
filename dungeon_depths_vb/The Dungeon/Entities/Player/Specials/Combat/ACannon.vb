Public Class ACannon
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Aura Cannon")
        MyBase.setUOC(False)
        MyBase.setcost(0)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = p.mana * ((p.attack + p.aBuff) * p.pClass.a * p.pForm.a) / 10
        p.mana = 0

        dmg = p.getSpellDamage(m, dmg)
        Game.pushLstLog("Aura Cannon!")
        Game.pushLblCombatEvent("Aura Cannon!" & vbCrLf & "You focus all of your internal energy into your hands, using it to fire a beam at your opponent.  The blast hits them for " & dmg & " damage!")

        MyBase.getTarget.takeDMG(dmg, MyBase.getUser)
    End Sub

    Public Overrides Function getCost() As Integer
        Return Math.Min(100, (getUser.mana * ((getUser.attack + getUser.aBuff) * getUser.pClass.a * getUser.pForm.a) / 10))
    End Function

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Burns through all of its user's MP to deal massive magic damage."
    End Function
End Class
