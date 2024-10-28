Public Class TwofoldSlash
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Twofold Slash")
        MyBase.setUOC(False)
        MyBase.setcost(24)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget
        'TextEvent.pushAndLog("Twofold Slash!")

        p.attackCMD(m)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Attacks twice.  The second attack is guranteed to hit last."
    End Function
End Class
