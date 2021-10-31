Public Class Dodge
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Dodge")
        MyBase.setUOC(False)
        MyBase.setcost(10)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser

        p.perks(perk.dodge) = 1
        TextEvent.pushLog("DODGE!")
        TextEvent.pushCombat("Dodge!" & vbCrLf & "Guaranteed to avoid the next attack!")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Swiftly avoids the next oncoming attack."
    End Function
End Class
