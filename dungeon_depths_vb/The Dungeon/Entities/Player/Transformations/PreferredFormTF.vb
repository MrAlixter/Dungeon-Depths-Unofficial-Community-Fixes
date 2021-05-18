Public Class PreferredFormTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "PrefFormTF"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "PrefFormTF"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = 5
    End Sub

    Public Sub step1()
        Dim p As Player = Game.player1

        p.prefForm.shiftTowards(p)
        p.perks(perk.thrall) = 1
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player1

        If p.prefForm.playerMeetsForm(p) Then
            Return AddressOf stopTF
        End If

        Return AddressOf step1
    End Function
End Class
