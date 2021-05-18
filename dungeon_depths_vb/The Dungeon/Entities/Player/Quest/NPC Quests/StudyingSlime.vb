Public Class StudyingSlime
    Inherits Quest

    Sub New()
        MyBase.New("Studying Slime")

        qInd = qInds.sSlime

        objectives.Add(New StudyingSlimeS1)
    End Sub

    Public Overrides Sub init()
        MyBase.init()
    End Sub

    Public Overrides Function canGet() As Boolean
        Return Not getActive() And Game.currFloor.floorNumber > 2 And Not getComplete()
    End Function
End Class

Public Class StudyingSlimeS1
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

