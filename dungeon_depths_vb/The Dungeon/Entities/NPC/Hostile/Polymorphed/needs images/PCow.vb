Public Class PCow
    Inherits PolymorphedNPC

    Public Sub New(ByRef e As NPC, ByRef p As Player, ByVal duration As Integer)
        MyBase.New(e, p, duration)
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"
    End Sub

    Overrides Function getHPModifier() As Double
        Return 1.33
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
        Return 0.33
    End Function

    Public Overrides Function getFormName() As String
        Return "Cow"
    End Function

    Public Overrides Sub newAttackCMD(ByRef target As Entity)
        If Int(Rnd() * 4) = 0 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " tries to ram you... but they miss.")
        Else
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " rams you with a headbutt!")
            hit(calcDamage(getATK() + 5, target.getDEF), target)
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.npc_list.Clear()

        TextEvent.fpush("The cow falls over, crushing you beneath its hefty body." & DDUtils.RNRN &
                        """MOOOO!""", AddressOf DeathEffects.hardDeath)
    End Sub
End Class
