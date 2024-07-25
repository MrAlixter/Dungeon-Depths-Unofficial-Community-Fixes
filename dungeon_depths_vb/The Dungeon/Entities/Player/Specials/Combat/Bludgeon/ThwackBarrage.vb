Public Class ThwackBarrage
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Thwack Barrage")
        MyBase.setUOC(False)
        MyBase.setcost(6)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        For i = 1 To Int(Rnd() * 6) + If(p.equippedWeapon.GetType().IsSubclassOf(GetType(Bludgeon)), 2, 0)
            attackCMD(0.6, m)

            If i <> 1 Then p.stamina -= getCost()

            If m.isDead Or p.stamina < getCost() Then Exit For
        Next
    End Sub

    Protected Sub attackCMD(ByVal modifier As Double, ByRef target As Entity)
        Dim p = MyBase.getUser
        Randomize()

        If p.pClass.name.Equals("Barbarian") Then
            p.aBuff -= p.perks(perk.barbarian)
            p.perks(perk.barbarian) = 0
        End If

        Dim dmg As Integer = p.equippedWeapon.attack(p, target) * modifier

        If dmg = -1 Then
            p.miss(target)
        ElseIf dmg = -2 Then
            p.cHit(p.getATK, target)
        ElseIf dmg <> -3 Then
            p.hit(Math.Max(dmg, 1), target)
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Unleashes a flurry of 0-5 haphazard blows, with an addtional two hits if they are holding a bludgeon-class weapon."
    End Function
End Class
