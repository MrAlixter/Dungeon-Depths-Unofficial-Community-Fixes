Public Enum mgind
    magicalgirl         '0
    redmagicalgirl      '1
    pinkmagicalgirl     '2
    greenmagicalgirl    '3
    darkmagicalgirl     '4
    promagicalgirl      '5
    proredmagicalgirl   '6
    magicalslut         '7
    magicalmimic        '8
End Enum

Public Class MagGirlTF
    Inherits Transformation

    Protected Const className As String = "Magical Girl"
    Private Const TF_IND As tfind = tfind.maggirl

    Protected MG_IND As mgind = mgind.magicalgirl

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tf_name = TF_IND
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Overridable Sub step1dialog(ByRef p As Player)
        Dim out = "You swing your wand in a wide arc over your head, and you are engulfed in a rain of stars." & DDUtils.RNRN &
                  "The light around your body becomes blinding and your clothes disolve into the aether, as beams of rainbow-colored energy twirl around your shifting silhouette." & DDUtils.RNRN &
                  "With a final flash of brilliant white, the wand dims and you strike a cutesy pose."

        TextEvent.push(out, AddressOf step2)
        TextEvent.pushLog("You activate your magical girl transformation!")
        p.textColor = Game.lblEvent.ForeColor
    End Sub
    Sub step1()
        Dim p As Player = Game.player1
        p.changeClass("Magical Girl​")

        If p.sex = "Male" Then
            p.MtF()
        End If

        step1dialog(p)

        p.specialRoute()
        p.magicRoute()
    End Sub

    Sub step1combat()
        step1()
        step2()
    End Sub

    Overridable Sub setSpells(ByRef p As Player)
        p.learnSpell("Heartblast Starcannon")
    End Sub
    Overridable Sub tfBody(ByRef p As Player)
        p.breastSize = 2

        p.prt.setIAInd(pInd.rearhair, 7, True, True)
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 7, True, True)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.mouth, 7, True, True)
        p.prt.setIAInd(pInd.eyes, 9, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 8, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)
    End Sub
    Overridable Sub tfClothes(ByRef p As Player)
        If p.inv.item(10).count < 1 Then p.inv.add(10, 1)

        p.prt.setIAInd(pInd.hairacc, 2, True, False)

        Equipment.accChange(p, "Nothing")
        EquipmentDialogBackend.armorChange(p, "Magical_Girl_Outfit")

        p.textColor = Color.CornflowerBlue
    End Sub
    Overridable Sub step2()
        Dim p As Player = Game.player1
        If p.formStates(stateInd.magGState).initFlag And (p.perks(perk.mgind) = MG_IND Or p.perks(perk.mgind) = -1) Then
            p.formStates(stateInd.magGState).load(p)
        Else
            tfBody(p)
            p.changeClass(className)

            p.perks(perk.mgind) = MG_IND
            p.formStates(stateInd.magGState).save(p)
            p.formStates(stateInd.magGState).initFlag = True
        End If

        setSpells(p)

        tfClothes(p)

        p.changeClass(className)

        Game.lblEvent.Text = ""
        Game.lblEvent.Visible = False
        p.canMoveFlag = True

        p.drawPort()

        stopTF()
    End Sub

    Shared Sub halfRevert(ByRef p As Player)
        p.changeClass("Mage")

        p.breastSize = 2

        p.prt.setIAInd(pInd.rearhair, 7, True, True)
        p.prt.setIAInd(pInd.ears, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 7, True, True)
        p.prt.setIAInd(pInd.fronthair, 7, True, True)
    End Sub
    Shared Sub chkForMagGirlRevert(ByRef p As Player)
        If Not p.className.Equals(className) Then Exit Sub
        pushLblEventWithoutLoss("Your form wavers, and while you can maintain it you are definitly tiring out.")
        MagGirlTF.halfRevert(p)
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player1
        If p.className.Equals("Magical Girl​") Then
            Return AddressOf step2
        ElseIf p.className.Equals(className) Then
            Return AddressOf stopTF
        ElseIf Game.combat_engaged Then
            Return AddressOf step1combat
        Else
            Return AddressOf step1
        End If
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = 0
    End Sub

    Public Shared Sub pushLblEventWithoutLoss(ByRef out As String)
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & DDUtils.RNRN & out
        TextEvent.push(out)
    End Sub
End Class
