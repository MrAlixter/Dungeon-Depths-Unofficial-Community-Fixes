Public Class PPrincess
    Inherits PolymorphedNPC

    Public Sub New(ByRef e As NPC, ByRef p As Player, ByVal duration As Integer)
        MyBase.New(e, p, duration)
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"
    End Sub

    Overrides Function getHPModifier() As Double
        Return 0.5
    End Function
    Overrides Function getATKModifier() As Double
        Return 0.33
    End Function
    Overrides Function getDEFModifier() As Double
        Return 0.33
    End Function
    Overrides Function getSPDModifier() As Double
        Return 0.33
    End Function
    Overrides Function getWILModifier() As Double
        Return 1.0
    End Function

    Public Overrides Function getFormName() As String
        Return "Princess"
    End Function

    Public Overrides Sub newAttackCMD(ByRef target As Entity)
        If health < 0.5 Then
            If Int(Rnd() * 3) <> 0 Or originalShape.getMana > 5 Then
                Dim healvalue = Int(Rnd() * 4) + Int(Rnd() * 2) + 30
                If getIntHealth() + healvalue > getMaxHealth() Then healvalue = getMaxHealth() - getIntHealth()
                TextEvent.pushLog((getName() & " heals herself!  +" & healvalue & " health!"))
                TextEvent.pushCombat((getName() & " heals herself for " & healvalue & " health!"))
                takeDMG(-healvalue, Nothing)
            Else
                TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " tries to cast Heal, but it fails...")
            End If
        Else
            If Int(Rnd() * 2) = 0 Or originalShape.getMana > 5 Then
                attackSpell(target, "Field of Thorns", Math.Max(getWIL, 10))
            Else
                TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " tries to cast Field of Thorns, but it fails...")
            End If
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.npc_list.Clear()

        Dim polymorph_forms = {"sparkly ballgown", "motionless pumpkin", "pair of crystal high heels", "tube of scarlet lipstick", "soft fluffy pillow"}
        TextEvent.fpush("The princess collapses alongside you, as " & pronoun & " tries to catch " & p_pronoun & " breath." & DDUtils.RNRN &
                        """P-p-polymorph!"" " & pronoun & " suddenly calls out, pointing a finger at you and charging a spell." & DDUtils.RNRN &
                        "With a *poof*, you transform into a " & polymorph_forms(Int(Rnd() * polymorph_forms.Length)) & "; your story concluding with an embarrassing end.", AddressOf DeathEffects.hardDeath)
    End Sub
End Class
