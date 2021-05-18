Public Class Floor4Encounter
    Inherits Quest

    Sub New()
        MyBase.New("Floor 4 Ooze Chest")

        qInd = qInds.floor4encounter

        objectives.Add(New Floor4Init)
    End Sub

    Public Overrides Sub init()
        MyBase.init()
    End Sub

    Public Overrides Function isHidden() As Object
        Return True
    End Function
End Class

Public Class Floor4Init
    Inherits Objective

    Sub New()
        MyBase.New("Walk away...")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()
        'If Not Game.player1.preBSBody.initFlag Or Not Game.player1.preBSStartState.initFlag Then Exit Sub
        RandoTF.floor4FirstBossEncounter()
    End Sub

    Public Overrides Function getDesc() As String
        Return description & "  [" & 1 & "/1]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return Not Game.lblEvent.Visible = True
    End Function
End Class

