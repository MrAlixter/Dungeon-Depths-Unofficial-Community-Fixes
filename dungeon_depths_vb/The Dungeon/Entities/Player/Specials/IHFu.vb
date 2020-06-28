Public Class IHFu
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Ironhide Fury")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser

        p.perks(perk.ihfury) = 3
        Game.pushLstLog("Ironhide Fury!")
        Game.pushLblCombatEvent("Ironhide Fury!" & vbCrLf & "+50% ATK, +60% DEF for 3 turn.")
    End Sub
End Class
