Public Class Venombarb
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Venombarb")
        MyBase.settier(2)
        MyBase.setcost(8)

        can_be_reacted_to = False
    End Sub
    Public Overrides Sub effect()
        Dim dmg As Integer = 2

        getTarget.perks(npc_perk.poison) = 7
        dmg = MyBase.getCaster.getSpellDamage(MyBase.getTarget, dmg)
        getCaster.hit(dmg, getTarget, "", "prick")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 2 utility spell that poisons the opponent for 7 turns, with a low chance of missing altogether."
    End Function
End Class
