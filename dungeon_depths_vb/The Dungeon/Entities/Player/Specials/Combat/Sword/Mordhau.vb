Public Class Mordhau
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Mordhau")
        MyBase.setUOC(False)
        MyBase.setcost(23)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        dmg += (p.getATK) + ((p.attack + p.aBuff) * p.pForm.a * p.pClass.a)
        dmg = Entity.calcDamage(dmg, m.defense * 0.2)

        specHit(getName, dmg, getUser, getTarget)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A heavy blow, delivered by a weapon held upside down.  Striking with the blunt end makes the attack better against enemies with high DEF, but also relies more on the users direct strength than on equipped weapons."
    End Function
End Class
