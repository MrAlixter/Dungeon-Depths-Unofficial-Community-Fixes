Public Class PSlime
    Inherits PolymorphedNPC

    Public Sub New(ByRef e As NPC, ByRef p As Player, ByVal duration As Integer)
        MyBase.New(e, p, duration)
    End Sub

    Overrides Function getHPModifier() As Double
        Return 0.5
    End Function
    Overrides Function getATKModifier() As Double
        Return 1.2
    End Function
    Overrides Function getDEFModifier() As Double
        Return 2.5
    End Function
    Overrides Function getSPDModifier() As Double
        Return 0.9
    End Function
    Overrides Function getWILModifier() As Double
        Return 1.0
    End Function

    Public Overrides Function getFormName() As String
        Return "Slime"
    End Function

    Public Overrides Sub newAttackCMD(ByRef target As Entity)
        If Int(Rnd() * 16) = 0 Then
            TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " just sits there, bobbing up and down menacingly...")
            TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle) & " just sits there.")
        ElseIf health < 0.75 And Int(Rnd() * 2) = 0 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " uses Absorption!")

            Dim dmg = calcDamage(Me.getATK * 1.5, target.getDEF)
            hit(dmg, target)
            takeDMG(-dmg, Nothing)

            If health > 1.0 Then health = 1.0
        Else
            hit(calcDamage(getATK(), target.getDEF), target)
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        'Author Credit: Marionette
        Dim out As String = "As " & getNameWithTitle() & " closes in, you push yourself off the ground with a burst of adrenaline that overcomes your fatigue.  You sidestep as " & r_pronoun & " lunges, and you beat a hasty retreat." & DDUtils.RNRN &
                            "While your back is turned to it, however, " & getNameWithTitle() & " slings a ball of goo towards you; the impact of which causes you to stumble as it strikes your back." & DDUtils.RNRN &
                            "You can already feel it starting to writhe and squirm as it begins to move..."
        despawn("p-death")

        If p.perks(perk.slimetf) = -1 Then
            p.perks(perk.slimetf) = 1
        End If

        p.ongoingTFs.add(New SlimeETF(p.perks(perk.slimetf)))
        TextEvent.push(out, AddressOf p.update)
    End Sub
End Class
