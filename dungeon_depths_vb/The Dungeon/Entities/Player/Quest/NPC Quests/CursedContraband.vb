Public Class CursedContraband
    Inherits Quest

    Sub New()
        MyBase.New("Cursed Contraband")

        quest_index = qInd.cContra

        objectives.Add(New CursedContrabandS1)
    End Sub

    Public Overrides Sub init()
        MyBase.init()
    End Sub

    Public Overrides Function canGet() As Boolean
        Return Not getActive() And Game.currFloor.floorNumber > 2 And Not getComplete()
    End Function
End Class

Friend Class CursedContrabandS1
    Inherits Objective

    Sub New()
        MyBase.New("Placeholder")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()

        Game.player1.gold += 1000
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & 1 & "/1]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return True
    End Function
End Class

