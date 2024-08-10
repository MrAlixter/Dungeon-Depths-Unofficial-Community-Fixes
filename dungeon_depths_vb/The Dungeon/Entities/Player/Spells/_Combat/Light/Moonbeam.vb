Public Class Moonbeam
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Moonbeam")
        MyBase.settier(1)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim d6_1 = Int(Rnd() * 6)
        Dim d6_2 = Int(Rnd() * 6)
        Dim hdif = Math.Min(40 + d6_1 + d6_2, MyBase.getCaster.getMaxHealth - MyBase.getCaster.getIntHealth)
        MyBase.getCaster.health += (hdif / MyBase.getCaster.getMaxHealth)

        TextEvent.pushAndLog("You heal yourself for " & hdif & " health!")

        Dim dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, hdif)

        getCaster.hit(dmg, getTarget, "", "burn")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 offensive spell that restores health, and then deals medium magic that scales to the amount of health regained."
    End Function
End Class
