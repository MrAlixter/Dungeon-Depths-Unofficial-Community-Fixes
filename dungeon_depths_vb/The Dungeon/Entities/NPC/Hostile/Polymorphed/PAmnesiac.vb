Public Class PAmnesiac
    Inherits PolymorphedNPC

    Public Sub New(ByRef e As NPC, ByRef p As Player, ByVal duration As Integer)
        MyBase.New(e, p, duration)
    End Sub

    Overrides Function getHPModifier() As Double
        Return 0.33
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
        Return "Amnesiac"
    End Function

    Public Overrides Sub newAttackCMD(ByRef target As Entity)
        If Game.player1.passDieRoll(3, 2) Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " stares blankly ahead...")
        Else
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " throws a wild punch!")
            hit(calcDamage(getWIL() + 2, target.getDEF), target)
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.npc_list.Clear()
        DeathEffects.hardDeath()
    End Sub
End Class
