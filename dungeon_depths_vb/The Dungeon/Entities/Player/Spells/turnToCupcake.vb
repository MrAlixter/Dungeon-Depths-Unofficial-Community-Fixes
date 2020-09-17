Public Class turnToCupcake
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Turn to Cupcake")
        MyBase.settier(5)
        MyBase.setcost(17)
    End Sub
    Public Overrides Sub effect()
        MyBase.getCaster.inv.add(35, 1)
        MyBase.getCaster.inv.invNeedsUDate = True
        MyBase.getCaster.UIupdate()
        MyBase.getTarget.despawn("cupcake")
        Game.pushLstLog(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.rPronoun & " into a cupcake!"))
        Game.pushLblCombatEvent(CStr("Your spell hits the " & MyBase.getTarget.name & ", turning " & MyBase.getTarget.rPronoun & " into a cupcake!"))
    End Sub

    Public Overrides Sub backfire()
        Polymorph.transform(MyBase.getCaster, "Cake")

        MyBase.getCaster.perks(perk.polymorphed) = 1
        Game.pushLstLog(CStr("You turn yourself into a cake-girl!"))
        Game.pushLblCombatEvent(CStr("You turn yourself into a cake-girl!"))

    End Sub
End Class
