Public Class Swashbuckle
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Swashbuckle")
        MyBase.setUOC(False)
        MyBase.setcost(14)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser

        Dim dmg As Integer = p.equippedWeapon.attack(p, MyBase.getTarget)

        If dmg = -1 Then
            p.miss(MyBase.getTarget)
        ElseIf dmg = -2 Then
            p.cHit(Math.Max(dmg, 1), MyBase.getTarget)
        ElseIf dmg <> -3 Then
            p.hit(Math.Max(dmg, 1), MyBase.getTarget)
        End If

        If p.perks(perk.atkup) = -1 Then
            p.perks(perk.atkup) = 1
        Else
            p.perks(perk.atkup) += 1
        End If

        p.aBuff = p.aBuff + ((p.getATK - p.aBuff) * 0.3)

        TextEvent.pushCombat("Swashbuckle!" & vbCrLf & "+30% ATK for 1 turn.")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A physical attack that boosts its user's attack by 30% on the next turn."
    End Function
End Class
