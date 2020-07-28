Public NotInheritable Class HGorgonTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "HGorgonTF"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "HGorgonTF"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Sub step1()
        Dim p As Player = Game.player1

        'transformation
        If p.sex.Equals("Male") Then p.MtF()
        p.changeHairColor(Color.FromArgb(255, 92, 154, 1))
        p.prt.setIAInd(pInd.rearhair, 20, True, True)
        p.prt.setIAInd(pInd.midhair, 22, True, True)
        p.prt.setIAInd(pInd.fronthair, 21, True, True)
        p.prt.setIAInd(pInd.eyes, 30, True, True)
        p.prt.setIAInd(pInd.eyebrows, 5, True, False)

        p.pForm = p.forms("Half-Gorgon")

        If Not p.knownSpells.Contains("Petrify II") Then p.knownSpells.Add("Petrify II")
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player1
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
