Public NotInheritable Class PrincessTF
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.princess

    Sub New()
        MyBase.New(1, 0, 0, False)
        tf_name = TF_IND
        next_step = AddressOf step1
    End Sub
    Sub New(tfStepFlag As Boolean)
        MyBase.New(1, 0, 0, False)
        tf_name = TF_IND
        next_step = AddressOf step3
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = 0
    End Sub

    Public Shared Sub step1()
        Dim p As Player = Game.player1

        Dim out = ""

        'equip clothes
        p.pClass = New Unconcious()

        'princess transformation
        p.prt.setIAInd(pInd.mouth, 5, True, True)

        If p.prt.sexBool Then
            p.prt.setIAInd(pInd.eyes, 5, True, False)
        Else
            p.prt.setIAInd(pInd.eyes, 4, False, False)
        End If

        'transformation description push
        out += "As you bite into the apple, your mind starts to get foggy.  You yawn, and lay down on the floor.  Nodding off, you realize that that apple probably was probably either enchanted or poisoned." & DDUtils.RNRN &
               "Your last thought as you black out is that this seems like something out of an old fairy-tale..."

        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & DDUtils.RNRN & out

        TextEvent.push(out, AddressOf step2)

        p.drawPort()
    End Sub
    Public Shared Sub step2()
        Dim p As Player = Game.player1
        Dim out = ""

        'equip clothes
        If p.inv.getCountAt("Regal_Gown") < 1 Then p.inv.add("Regal_Gown", 1)
        EquipmentDialogBackend.armorChange(p, "Regal_Gown")
        p.changeClass("Princess")

        'maid transformation
        If Not p.prt.sexBool Then
            p.MtF()
        End If

        p.changeHairColor(Color.FromArgb(255, 181, 148, 98))
        p.prt.setIAInd(pInd.rearhair, 39, True, True)
        p.prt.setIAInd(pInd.midhair, 21, True, True)
        p.prt.setIAInd(pInd.mouth, 0, True, False)
        p.prt.setIAInd(pInd.eyes, p.pState.iArrInd(pInd.eyes).Item1, p.pState.iArrInd(pInd.eyes).Item2, p.pState.iArrInd(pInd.eyes).Item3)
        p.prt.setIAInd(pInd.fronthair, 10, True, True)
        p.prt.setIAInd(pInd.hat, 6, True, False)

        'transformation description push
        out += "As you come to several hours later, you groan and rub your forhead, only to knock a golden crown off of your head. This jolts you up, and you examine yourself further." & DDUtils.RNRN &
               "Long hair, poofy ballgown, gloves that go up past your elbows?!  Well, it seems like your ""fairy-tale"" hunch wasn't too far off after all.  Dusting youself off, you get ready to embark back on your journey to return to your kingdom." & DDUtils.RNRN &
               "Wait... that isn't why you came here..." & DDUtils.RNRN &
               "Or was it?"

        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & DDUtils.RNRN & out

        TextEvent.push(out)

        p.drawPort()
    End Sub
    Public Shared Sub step3()
        Dim p As Player = Game.player1
        Dim out = ""

        'equip clothes
        If p.inv.getCountAt("Regal_Gown") < 1 Then p.inv.add("Regal_Gown", 1)
        EquipmentDialogBackend.armorChange(p, "Regal_Gown")
        p.changeClass("Princess")

        'maid transformation
        If Not p.prt.sexBool Then
            p.MtF()
        End If
        p.changeHairColor(Color.FromArgb(255, 181, 148, 98))
        p.prt.setIAInd(pInd.rearhair, 39, True, True)
        p.prt.setIAInd(pInd.midhair, 21, True, True)
        p.prt.setIAInd(pInd.mouth, 0, True, False)
        p.prt.setIAInd(pInd.eyes, p.pState.iArrInd(pInd.eyes).Item1, p.pState.iArrInd(pInd.eyes).Item2, p.pState.iArrInd(pInd.eyes).Item3)
        p.prt.setIAInd(pInd.fronthair, 10, True, True)
        p.prt.setIAInd(pInd.hat, 6, True, False)

        'transformation description push
        out += "As you bite into the apple, your mind starts to get foggy.  You yawn, and lay down on the floor.  Nodding off, you realize that that apple probably was probably either enchanted or poisoned." & DDUtils.RNRN &
               "Your last thought as you black out is that this seems like something out of an old fairy-tale..." & DDUtils.RNRN

        out += "As you come to several hours later, you groan and rub your forhead, only to knock a golden crown off of your head. This jolts you up, and you examine yourself further." & DDUtils.RNRN &
               "Long hair, poofy ballgown, gloves that go up past your elbows?!  Well, it seems like your ""fairy-tale"" hunch wasn't too far off after all.  Dusting youself off, you get ready to embark back on your journey to return to your kingdom." & DDUtils.RNRN &
               "Wait... that isn't why you came here..." & DDUtils.RNRN &
               "Or was it?"

        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & DDUtils.RNRN & out

        TextEvent.push(out)

        p.drawPort()
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = Game.player1
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
