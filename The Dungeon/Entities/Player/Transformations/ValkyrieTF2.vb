Public Class ValkyrieTF2
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
        Dim p As Player = Game.player

        If p.sex = "Male" Then
            p.MtF()
        End If

        p.pClass = p.classes("Valkyrie")

        p.breastSize = 2
        p.prt.setIAInd(1, 0, True, False)
        p.prt.setIAInd(2, 6, True, True)
        p.prt.setIAInd(4, 3, True, False)
        p.prt.setIAInd(5, 3, True, False)
        p.prt.setIAInd(7, 0, True, False)
        p.prt.setIAInd(8, 4, True, False)
        p.prt.setIAInd(9, 23, True, True)
        p.prt.setIAInd(10, 2, True, False)
        p.prt.setIAInd(13, 0, True, False)
        p.prt.setIAInd(15, 11, True, True)
        p.prt.setIAInd(16, 7, True, False)
        p.prt.wingInd = 1

        p.inv.add(95, 1)

        Equipment.clothesChange("Valkyrie_Armor")

        p.knownSpells.Add("Blazing Angel Strike")
        Game.pushLstLog("""Blazing Angel Strike"" special learned!")
        p.canMoveFlag = True
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = game.player
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
