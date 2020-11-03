Public Class MirageDance
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Mirage Dance")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser

        p.perks(perk.dodge) = 3
        Game.pushLstLog("Mirage Dance!")
        Game.pushLblCombatEvent("Mirage Dance!" & vbCrLf & "Guaranteed to avoid the next 3 attacks!")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A sultry dance that avoids the next 3 oncoming attacks."
    End Function
End Class
