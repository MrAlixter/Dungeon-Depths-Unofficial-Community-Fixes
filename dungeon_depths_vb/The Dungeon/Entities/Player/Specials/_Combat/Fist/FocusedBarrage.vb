Public Class FocusedBarrage
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Focused Barrage")
        MyBase.setUOC(False)
        MyBase.setcost(6)
    End Sub
    Public Overrides Sub effect()

        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget
        TextEvent.pushLog("Focused Barrage!")
        TextEvent.pushCombat("Focused Barrage!")

        For i = 0 To Int(Rnd() * 4) + 4
            Dim dmg As Integer = p.getATKWithoutWeapon * 0.65
            dmg += Int(Rnd() * 2 * (p.getATKWithoutWeapon * 0.65 * 0.05)) - (p.getATKWithoutWeapon * 0.65 * 0.05)

            dmg = Entity.calcDamage(dmg, m.defense)

            getUser.hit(dmg, getTarget)

            If i <> 0 Then p.stamina -= 4

            If MyBase.getTarget.isDead Then Exit For
        Next

    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A flurry of 4-7 quick strikes that deal physical damage and don't factor in the user's weapon."
    End Function
End Class
