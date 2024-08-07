Public Class PSheep
    Inherits PolymorphedNPC

    Public Sub New(ByRef e As NPC, ByRef p As Player, ByVal duration As Integer)
        MyBase.New(e, p, duration)
    End Sub

    Overrides Function getHPModifier() As Double
        Return 0.5
    End Function
    Overrides Function getATKModifier() As Double
        Return 0.5
    End Function
    Overrides Function getDEFModifier() As Double
        Return 0.5
    End Function
    Overrides Function getSPDModifier() As Double
        Return 0.5
    End Function
    Overrides Function getWILModifier() As Double
        Return 0.5
    End Function

    Public Overrides Function getFormName() As String
        Return "Sheep"
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

        TextEvent.fpush("The sheep falls over, crushing you beneath its wooly body." & DDUtils.RNRN &
                        """BAAAAAH!""", AddressOf DeathEffects.hardDeath)
    End Sub
End Class
