Public NotInheritable Class ValkyrieTF2
    Inherits Transformation
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "Valkyrie"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "Valkyrie"
        nextStep = getNextStep(cs)
    End Sub

    Sub step1()
        Dim p As Player = Game.player1

        If p.sex = "Male" Then
            p.MtF()
        End If

        p.pClass = p.classes("Valkyrie")

        p.breastSize = 2
        p.prt.setIAInd(pInd.rearhair, 0, True, False)
        p.prt.setIAInd(pInd.body, 6, True, True)
        p.prt.setIAInd(pInd.face, 3, True, False)
        p.prt.setIAInd(pInd.midhair, 3, True, False)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.mouth, 4, True, False)
        p.prt.setIAInd(pInd.eyes, 23, True, True)
        p.prt.setIAInd(pInd.eyebrows, 2, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 11, True, True)
        p.prt.setIAInd(pInd.hat, 7, True, False)
        p.prt.setIAInd(pInd.wings, 1, True, False)

        p.inv.add(95, 1)

        Equipment.clothesChange("Valkyrie_Armor")

        If Not p.knownSpecials.Contains("Blazing Angel Strike") Then p.knownSpecials.Add("Blazing Angel Strike")
        Game.pushLstLog("""Blazing Angel Strike"" special learned!")
        p.canMoveFlag = True
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = game.player1
        If p.pClass.name.Equals("Valkyrie") Then
            Return AddressOf stopTF
        Else
            Return AddressOf step1
        End If
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = 0
    End Sub
End Class
