Public Class Dodge
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Dodge")
        MyBase.setUOC(False)
        MyBase.setcost(10)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser

        p.perks(perk.dodge) = 1
        Game.pushLstLog("DODGE!")
        Game.pushLblCombatEvent("Dodge!" & vbCrLf & "Guaranteed to avoid the next attack!")
    End Sub
End Class
