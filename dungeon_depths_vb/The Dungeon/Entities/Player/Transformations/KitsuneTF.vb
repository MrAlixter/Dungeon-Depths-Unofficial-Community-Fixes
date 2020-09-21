Public NotInheritable Class KitsuneTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "KitsuneTF"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "KitsuneTF"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Sub step1()
        fulltf()
    End Sub

    Public Sub fulltf()
        Dim p As Player = Game.player1

        If Not p.prt.sexBool Then p.MtF()

        p.breastSize = 4
        p.buttSize = 2
        p.reverseAllRoute()

        'kitsune transformation
        p.changeHairColor(Color.FromArgb(255, 234, 189, 134))
        p.prt.setIAInd(pInd.tail, 1, True, False)
        p.prt.setIAInd(pInd.rearhair, 8, True, True)
        p.prt.setIAInd(pInd.eyebrows, 5, True, False)
        p.prt.setIAInd(pInd.eyes, 43, True, True)
        p.prt.setIAInd(pInd.ears, 13, True, True)
        p.prt.setIAInd(pInd.mouth, 11, True, True)
        p.prt.setIAInd(pInd.midhair, 36, True, True)
        p.prt.setIAInd(pInd.fronthair, 35, True, True)

        If p.inv.getCountAt("Kitsune's_Robes") < 1 Then p.inv.add("Kitsune's_Robes", 1)
        Equipment.clothesChange("Kitsune's_Robes")

        p.changeForm("Kitsune")
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
