Public Class Sunburst
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Sunburst")
        MyBase.settier(1)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 40
        Dim d6_1 = Int(Rnd() * 6)
        Dim d6_2 = Int(Rnd() * 6)

        dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg + d6_1 + d6_2)
        getCaster.hit(dmg, getTarget, "", "burn")

        Dim hdif = Math.Min(dmg, MyBase.getCaster.getMaxHealth - MyBase.getCaster.getIntHealth)

        MyBase.getCaster.health += (hdif / MyBase.getCaster.getMaxHealth)

        If Not getTarget.isDead Then TextEvent.pushAndLog("You heal yourself for " & hdif & " health!") Else TextEvent.pushLog("You heal yourself for " & hdif & " health!")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 offensive spell that deals a medium amount of magic damage, and restores health equal to the damage dealt."
    End Function
End Class
