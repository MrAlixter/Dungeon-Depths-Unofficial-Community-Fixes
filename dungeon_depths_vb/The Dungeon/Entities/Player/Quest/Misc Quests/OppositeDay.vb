Public Class OppositeDay
    Inherits Quest

    Sub New()
        MyBase.New("Opposite Day")

        qInd = qInds.oppositeDay

        objectives.Add(New OppositeDayS1)
    End Sub

    Public Overrides Sub init()
        MyBase.init()

        Game.player1.perks(perk.odxpgained) = 0
    End Sub

    Public Overrides Function canGet() As Boolean
        Return Not getActive() And Not getComplete() And (Not Game.currFloor Is Nothing AndAlso Game.currFloor.floorNumber < 7)
    End Function
End Class

Public Class OppositeDayS1
    Inherits Objective

    Sub New()
        MyBase.New("Gain 600 xp.")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()

        Game.player1.revertToSState()
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & Game.player1.perks(perk.odxpgained) & "/600]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return Game.player1.perks(perk.odxpgained) >= 600
    End Function
End Class

