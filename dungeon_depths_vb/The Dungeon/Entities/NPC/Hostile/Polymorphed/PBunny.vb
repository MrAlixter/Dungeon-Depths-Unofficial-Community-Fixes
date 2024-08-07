Public Class PBunny
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
        Return 1.0
    End Function
    Overrides Function getWILModifier() As Double
        Return 0.5
    End Function

    Public Overrides Function getFormName() As String
        Return "Bunny"
    End Function

    Public Overrides Sub newAttackCMD(ByRef target As Entity)
        If Int(Rnd() * 2) = 0 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " leaps to one side, gaining some distance from you.")
        Else
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " chomps onto your leg!")
            hit(calcDamage(getATK(), target.getDEF), target)
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        TextEvent.fpush("The bunny scampers away, clearly not keen to continue fighting..." & DDUtils.PAKTC)
    End Sub
End Class
