Public Class PierceAndPunish
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Pierce And Punish")
        MyBase.setUOC(False)
        MyBase.setcost(45)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        Dim m = MyBase.getTarget

        If Game.lblPHealtDiff.Tag < 0 Then
            TextEvent.fpushAndLog("Your foe put themselves in range by attacking!")

            For i = 1 To 3
                attackCMD(1.1, m)

                If MyBase.getTarget.isDead Then Exit For
            Next
        Else
            TextEvent.fpushAndLog("Your foe is slightly out of range...")
            attackCMD(0.8, m)
        End If

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
        Return "If the user has been hit earlier in the turn, deals three swift attacks that utilize the user's equipped weapon with 1.1x damage.  If the user has not been hit, attacks once with 0.8x damage."
    End Function
End Class
