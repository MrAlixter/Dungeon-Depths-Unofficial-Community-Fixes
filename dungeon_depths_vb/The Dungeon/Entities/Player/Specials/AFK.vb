Public Class AFK
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Nothing")
        MyBase.setUOC(True)
        MyBase.setcost(0)
    End Sub
    Public Overrides Sub effect()
        TextEvent.pushLog("Whatever you tried to do failed unspectacularly.")
        TextEvent.push("Something isn't right, and whatever you tried to do failed unspectacularly.")
    End Sub
End Class
