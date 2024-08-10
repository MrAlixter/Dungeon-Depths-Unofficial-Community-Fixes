Public Class PSuccubus
    Inherits PolymorphedNPC

    Protected levelDrainThres, lustRaiseThres As Integer
    Protected levelsToDrain, lustToIncrease As Integer

    Public Sub New(ByRef e As NPC, ByRef p As Player, ByVal duration As Integer)
        MyBase.New(e, p, duration)

        levelDrainThres = 3
        lustRaiseThres = 33
        levelsToDrain = 1
        lustToIncrease = Int(Rnd() * 6) + 6

        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"
    End Sub

    Overrides Function getHPModifier() As Double
        Return 0.8
    End Function
    Overrides Function getATKModifier() As Double
        Return 1.25
    End Function
    Overrides Function getDEFModifier() As Double
        Return 0.5
    End Function
    Overrides Function getSPDModifier() As Double
        Return 1.66
    End Function
    Overrides Function getWILModifier() As Double
        Return 1.66
    End Function

    Public Overrides Function getFormName() As String
        Return "Succubus​"
    End Function

    Public Overrides Sub newAttackCMD(ByRef target As Entity)
        If target.lust < lustRaiseThres And Int(Rnd() * 3) = 0 Then
            If Int(Rnd() * target.will) < 15 Then
                target.addLust(lustRaiseThres)
                TextEvent.fpushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " used Charm!")
            Else
                TextEvent.fpushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " used Charm... but it fails...")
            End If
        Else
            If levelDrainThres > 0 And levelsToDrain > 0 And target.level > 2 And target.level - levelDrainThres >= 1 And Int(Rnd() * 4) = 0 Then
                TextEvent.fpushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " tries to use Drain Soul, but they are unable to do so successfully...")
            Else
                attackSpell(target, "Fire of Amaraphne", Math.Max(getWIL() * (If(target.getPlayer Is Nothing, 0, target.getPlayer.getLust) / 33), 40))
            End If
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        TextEvent.fpush("The succubus kicks your defeated body aside, before flying away with a smug giggle." & DDUtils.PAKTC)
    End Sub
End Class
