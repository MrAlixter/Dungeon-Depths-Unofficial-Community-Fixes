Public Class FocusedRoundhouse
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Focused Roundhouse")
        MyBase.setUOC(False)
        MyBase.setcost(16)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        Dim dmg As Integer = p.getATKWithoutWeapon * 1.95
        dmg = Entity.calcDamage(dmg, getTarget.defense)

        getUser.hit(dmg, getTarget, "", "kick")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Deals heavy damage that does not factor in the weapon of its user."
    End Function
End Class
