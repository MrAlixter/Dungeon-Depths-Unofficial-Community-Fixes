Public Class PTrilobite
    Inherits PolymorphedNPC

    Public Sub New(ByRef e As NPC, ByRef p As Player, ByVal duration As Integer)
        MyBase.New(e, p, duration)
    End Sub

    Overrides Function getHPModifier() As Double
        Return 0.66
    End Function
    Overrides Function getATKModifier() As Double
        Return 0.01
    End Function
    Overrides Function getDEFModifier() As Double
        Return 3.0
    End Function
    Overrides Function getSPDModifier() As Double
        Return 0.01
    End Function
    Overrides Function getWILModifier() As Double
        Return 3.0
    End Function

    Public Overrides Function getFormName() As String
        Return "Trilobite"
    End Function

    Public Overrides Sub newAttackCMD(ByRef target As Entity)
        TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " sits there, motionless...")
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.npc_list.Clear()
        DeathEffects.hardDeath()
    End Sub
End Class
