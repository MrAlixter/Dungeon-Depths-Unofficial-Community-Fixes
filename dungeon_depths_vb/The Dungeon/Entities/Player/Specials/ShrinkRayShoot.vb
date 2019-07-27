Public Class ShrinkRayShoot
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Shrink_Ray Shot")
        MyBase.setUOC(False)
        MyBase.setcost(0)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim t = MyBase.getTarget
        Game.pushLstLog("Shrink_Ray Shot!")

        CType(p.inv.item("Shrink_Ray"), ShrinkRay).attack(p, t)
    End Sub
End Class
