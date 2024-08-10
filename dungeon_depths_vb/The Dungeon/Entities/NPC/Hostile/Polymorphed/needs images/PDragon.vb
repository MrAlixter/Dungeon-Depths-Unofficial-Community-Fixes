Public Class PDragon
    Inherits PolymorphedNPC

    Public Sub New(ByRef e As NPC, ByRef p As Player, ByVal duration As Integer)
        MyBase.New(e, p, duration)
    End Sub

    Overrides Function getHPModifier() As Double
        Return 2.0
    End Function
    Overrides Function getATKModifier() As Double
        Return 1.5
    End Function
    Overrides Function getDEFModifier() As Double
        Return 2.0
    End Function
    Overrides Function getSPDModifier() As Double
        Return 0.33
    End Function
    Overrides Function getWILModifier() As Double
        Return 1.5
    End Function

    Public Overrides Function getFormName() As String
        Return "Dragon"
    End Function

    Public Overrides Sub newAttackCMD(ByRef target As Entity)
        If Int(Rnd() * 2) = 0 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " slashes with sharp claws!")
            hit(calcDamage(getATK(), target.getDEF * 0.8), target)
        Else
            attackSpell(target, "Dragon's Breath", Math.Max(getWIL, 45))
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.npc_list.Clear()

        TextEvent.fpush("The dragon chomps down, swallowing you whole.", AddressOf DeathEffects.hardDeath)
    End Sub
End Class
