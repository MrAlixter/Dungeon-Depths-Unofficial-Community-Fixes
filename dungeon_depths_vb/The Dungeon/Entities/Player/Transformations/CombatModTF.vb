Public Class CombatModTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "CombatModTF"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "CombatModTF"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Sub step1()
        Dim p As Player = Game.player
        Dim out = ""

        'transformation
        If p.sex.Equals("Male") Then
            p.prt.setIAInd(4, 0, False, True)
            p.prt.setIAInd(6, 6, False, True)
            p.prt.setIAInd(9, 11, False, True)
        Else
            p.prt.setIAInd(4, 0, True, True)
            p.prt.setIAInd(6, 11, True, True)
            p.prt.setIAInd(9, 36, True, True)
        End If
       
        p.prt.setIAInd(12, 7, True, True)
        p.prt.setIAInd(8, 12, True, False)
        p.pForm = p.forms("Combat Unit")

        p.perks("slutcurse") = -1
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
