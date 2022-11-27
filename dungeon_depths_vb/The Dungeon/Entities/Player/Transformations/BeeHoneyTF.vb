Public NotInheritable Class BeeHoneyTF
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.beehoney

    Sub New(Optional cs As Integer = 2)
        MyBase.New(1, 0, 0, False)
        tf_name = TF_IND
        curr_step = cs
        next_step = getNextStep(cs)
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Shared Sub step1()
        Dim p = Game.player1

        p.drawPort()
    End Sub
    Sub step2()
        Dim p As Player = Game.player1

        p.drawPort()
    End Sub
    Sub step3()
        Dim p As Player = Game.player1
       
        p.drawPort()
    End Sub
    Sub step4()
        Dim p As Player = Game.player1

        p.setStartStates()
    End Sub

    Shared Sub fullTF(Optional ByRef p As Player = Nothing)
        If p Is Nothing Then p = Game.player1

        If p.sex.Equals("Male") Then
            p.MtF()
        End If

        p.changeForm("Bee Girl")

        '| -- Face TF -- |
        p.prt.setIAInd(pInd.horns, 14, False, False)
        p.prt.setIAInd(pInd.eyes, 62, True, True)

        '| -- Body TF -- |
        p.prt.setIAInd(pInd.wings, 8, False, False)
        p.prt.setIAInd(pInd.tail, 5, False, False)

        p.drawPort()
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub
    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player1

        Select Case curr_step
            Case 1
                Return AddressOf step1
            Case 2
                Return AddressOf step2
            Case 3
                Return AddressOf step3
            Case 4
                Return AddressOf step4
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
   
    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub
End Class
