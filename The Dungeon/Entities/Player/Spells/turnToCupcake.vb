Public Class turnToCupcake
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As Monster)
        MyBase.New(c, t)
        MyBase.setName("Turn to Cupcake")
        MyBase.settier(2)
        MyBase.setcost(9)
    End Sub
    Public Overrides Sub effect()
        MyBase.getCaster.inv.add(35, 1)
        MyBase.getCaster.inv.invNeedsUDate = True
        MyBase.getCaster.UIupdate()
        MyBase.getTarget.despawn("cupcake")
        Game.pushLstLog(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.rPronoun & " into a sword!"))
        Game.pushLblCombatEvent(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.rPronoun & " into a sword!"))
        
    End Sub
End Class
