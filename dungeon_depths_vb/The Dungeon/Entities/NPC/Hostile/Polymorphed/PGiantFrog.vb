Public Class PGiantFrog
    Inherits PolymorphedNPC

    Public Sub New(ByRef e As NPC, ByRef p As Player, ByVal duration As Integer)
        MyBase.New(e, p, duration)
    End Sub

    Overrides Function getHPModifier() As Double
        Return 0.9
    End Function
    Overrides Function getATKModifier() As Double
        Return 0.2
    End Function
    Overrides Function getDEFModifier() As Double
        Return 0.4
    End Function
    Overrides Function getSPDModifier() As Double
        Return 0.7
    End Function
    Overrides Function getWILModifier() As Double
        Return 0.2
    End Function

    Public Overrides Function getFormName() As String
        Return "Giant Frog"
    End Function

    Public Overrides Sub newAttackCMD(ByRef target As Entity)
        If Int(Rnd() * 4) = 0 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " croaks, and leaps away from you.")
        Else
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " lashes out with " & p_pronoun & " tongue!")
            hit(calcDamage(getATK() + 15, target.getDEF), target)
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.npc_list.Clear()

        TextEvent.fpush("The frog lashes out with its tongue one final time, and pulls you into its mouth." & DDUtils.RNRN &
                        """Ribbit!""", AddressOf DeathEffects.hardDeath)
    End Sub
End Class
