Public Class IHFu
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Ironhide Fury")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser

        p.perks(perk.ihfury) = 3
        Game.pushLstLog("Ironhide Fury!")
        Game.pushLblCombatEvent("Ironhide Fury!" & vbCrLf & "+50% ATK, +60% DEF for 3 turns.")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Boosts the user's ATK by 50% and DEF by 60% for 3 turns."
    End Function
End Class
