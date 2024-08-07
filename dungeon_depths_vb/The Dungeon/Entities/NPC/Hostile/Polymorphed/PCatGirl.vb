Public Class PCatGirl
    Inherits PolymorphedNPC

    Public Sub New(ByRef e As NPC, ByRef p As Player, ByVal duration As Integer)
        MyBase.New(e, p, duration)
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"
    End Sub

    Overrides Function getHPModifier() As Double
        Return 0.33
    End Function
    Overrides Function getATKModifier() As Double
        Return 0.5
    End Function
    Overrides Function getDEFModifier() As Double
        Return 0.33
    End Function
    Overrides Function getSPDModifier() As Double
        Return 1.0
    End Function
    Overrides Function getWILModifier() As Double
        Return 0.33
    End Function

    Public Overrides Function getFormName() As String
        Return "Cat-Girl"
    End Function

    Public Overrides Sub newAttackCMD(ByRef target As Entity)
        If Int(Rnd() * 4) = 0 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " leaps backwards, gaining some distance from you.")
        Else
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " slashes with " & p_pronoun & " claws!")
            hit(calcDamage(getATK() + 5, target.getDEF), target)
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        TextEvent.fpush("The cat-girl giggles, pushing you over with the tip of " & p_pronoun & " claw.  She turns away with a bored sigh, before leaving you to whatever fate befalls you." & DDUtils.RNRN &
                        """Nya~~...""" & DDUtils.PAKTC)
    End Sub
End Class
