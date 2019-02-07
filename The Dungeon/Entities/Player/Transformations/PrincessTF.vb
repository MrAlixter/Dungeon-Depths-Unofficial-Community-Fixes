Public Class PrincessTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "PrincessTF"
        nextStep = AddressOf step1
    End Sub
    Sub New(tfStepFlag As Boolean)
        MyBase.New(1, 0, 0, False)
        tfName = "PrincessTF"
        nextStep = AddressOf step3
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "PrincessTF"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = 0
    End Sub

    Public Sub step1()
        Dim p As Player = Game.player

        If p.pClass.name = "Magic Girl" Then
            Game.pushLblEvent("Your form prevents you from being altered!")
            Exit Sub
        End If

        Dim out = ""

        'equip clothes
        p.pClass = New Unconcious()

        'maid transformation
        p.iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(3, p.sexBool, False)
        If p.sexBool Then
            p.iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(5, True, False)
        Else
            p.iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(4, False, False)
        End If

        'transformation description push
        out += "As you bite into the apple, your mind starts to get foggy.  You yawn, " &
               "and lay down on the floor.  As you nod off, you realize that that apple" &
               " probably was probably either enchanted or poisoned, and as you black out" &
               " your last thought is that this seems like something out of an old fairy " &
               "tale."
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & vbCrLf & vbCrLf & out
        Game.pushLblEvent(out, AddressOf step2)
    End Sub
    Public Sub step2()
        Dim p As player = game.player
        Dim out = ""

        'equip clothes
        Equipment.clothesChange("Regal_Gown")
        p.pClass = p.classes("Princess")

        'maid transformation
        If Not p.sexBool Then
            p.MtF()
        End If
        p.changeHairColor(Color.FromArgb(255, 181, 148, 98))
        p.iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(1, True, False)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean, Boolean)(13, True, True)
        p.iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        p.iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(p.pState.iArrInd(9).Item1, p.pState.iArrInd(9).Item2, p.pState.iArrInd(9).Item3)
        p.iArrInd(15) = New Tuple(Of Integer, Boolean, Boolean)(10, True, True)
        p.iArrInd(16) = New Tuple(Of Integer, Boolean, Boolean)(6, True, False)

        'transformation description push
        out += "As you come to several hours later, you groan and rub your forhead, only to knock a golden crown off of your head. This jolts you up, and you examine yourself further.  Long hair, poofy ballgown, gloves that go up past your elbows?!  Well, it seems like your ""fairy-tale"" hunch wasn't too far off after all.  Dusting youself off, you get ready to embark back on your journey to return to your kingdom.  Wait...that isn't why you came here..." & vbCrLf & "Or was it?"
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & vbCrLf & vbCrLf & out
        Game.pushLblEvent(out)
        p.createP()
        stopTF()
    End Sub
    Public Sub step3()
        Dim p As player = game.player
        Dim out = ""

        'equip clothes
        Equipment.clothesChange("Regal_Gown")
        p.pClass = p.classes("Princess")

        'maid transformation
        If Not p.sexBool Then
            p.MtF()
        End If
        p.changeHairColor(Color.FromArgb(255, 181, 148, 98))
        p.iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(1, True, False)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean, Boolean)(13, True, True)
        p.iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        p.iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(p.pState.iArrInd(9).Item1, p.pState.iArrInd(9).Item2, p.pState.iArrInd(9).Item3)
        p.iArrInd(15) = New Tuple(Of Integer, Boolean, Boolean)(10, True, True)
        p.iArrInd(16) = New Tuple(Of Integer, Boolean, Boolean)(6, True, True)

        'transformation description push
        out += "As you bite into the apple, your mind starts to get foggy.  You yawn, " &
                                                   "and lay down on the floor.  As you nod off, you realize that that apple" &
                                                    " probably was probably either enchanted or poisoned, and as you black out" &
                                                   " your last thought is that this seems like something out of an old fairy " &
                                                   "tale. " & vbCrLf & " " & vbCrLf _
                        & "As you come to, several hours later, you groan and rub your forhead, only to knock a golden crown off of your head. This jolts you up, and you examine yourself further.  Long hair, poofy ballgown, gloves that go up past your elbows?!  Well, it seems like your ""fairy-tale"" hunch wasn't too far off after all.  Dusting youself off, you get ready to embark back on your journey to return to your kingdom.  Wait...that isn't why you came here..." & vbCrLf & "Or was it?"
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & vbCrLf & vbCrLf & out
        Game.pushLblEvent(out)
        stopTF()
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = game.player
        Select Case stage
            Case 0
                Return AddressOf step1
            Case 1
                Return AddressOf step2
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
