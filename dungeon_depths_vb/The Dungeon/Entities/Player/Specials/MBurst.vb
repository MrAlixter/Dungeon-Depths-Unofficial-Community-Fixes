Public Class MBurst
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Mana Burst")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        MyBase.getUser.perks(perk.mburst) = 14
        Game.pushLstLog("MANA BURST!")
        Game.pushLblCombatEvent("MANA BURST!" & vbCrLf & "Regen Health and Mana at the cost of hunger for 60 turns.")
    End Sub
End Class
