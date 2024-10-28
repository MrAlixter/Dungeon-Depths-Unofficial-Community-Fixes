Public Class PHellhound
    Inherits PolymorphedNPC

    Public Sub New(ByRef e As NPC, ByRef p As Player, ByVal duration As Integer)
        MyBase.New(e, p, duration)
    End Sub

    Overrides Function getHPModifier() As Double
        Return 1.0
    End Function
    Overrides Function getATKModifier() As Double
        Return 1.2
    End Function
    Overrides Function getDEFModifier() As Double
        Return 0.5
    End Function
    Overrides Function getSPDModifier() As Double
        Return 1.0
    End Function
    Overrides Function getWILModifier() As Double
        Return 0.33
    End Function

    Public Overrides Function getFormName() As String
        Return "Hellhound"
    End Function

    Public Overrides Sub newAttackCMD(ByRef target As Entity)
        If Not target.getPlayer Is Nothing AndAlso (target.getPlayer.formName.Contains("Demon") Or target.getPlayer.formName.Contains("Succubus") Or target.getPlayer.formName.Contains("Oni")) Then
            despawn("friend")
        Else
            If Int(Rnd() * 3) = 0 Then
                TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " puffs out a fireball!")
                hit(getSpellDamage(target, getWIL() + 6), target)
            Else
                TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " snaps at you with burning fangs!")
                hit(calcDamage(getATK(), target.getDEF), target)
            End If
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.npc_list.Clear()

        TextEvent.fpush("The hellhound bursts into flame, engulfing the both of you into an inferno.", AddressOf DeathEffects.hardDeath)
    End Sub
End Class
