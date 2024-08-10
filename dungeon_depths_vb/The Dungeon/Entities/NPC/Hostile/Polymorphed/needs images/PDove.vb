Public Class PDove
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
        Return 0.56
    End Function
    Overrides Function getWILModifier() As Double
        Return 0.33
    End Function

    Public Overrides Function getFormName() As String
        Return "Dove"
    End Function

    Public Overrides Sub newAttackCMD(ByRef target As Entity)
        despawn("flee")
        TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " flies away...")
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        TextEvent.fpush("How did this happen?  The dove is programmed to only fly away, and it somehow killed you?" & DDUtils.RNRN &
                        "It doesn't even have any attacks, what the hell." & DDUtils.PAKTC)
    End Sub
End Class
