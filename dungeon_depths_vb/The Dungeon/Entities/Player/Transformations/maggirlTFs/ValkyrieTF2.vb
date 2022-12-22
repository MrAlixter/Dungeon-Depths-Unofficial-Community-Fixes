Public Class ValkyrieTF2
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.valkyrie

    Protected Const className As String = "Valkyrie"

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
        Dim out = "You swing your blade in a wide arc over your head, and you are engulfed in a ball of fire." & DDUtils.RNRN &
                  "The inferno becomes blinding and your clothes burn away into the aether, as beams of red-hot energy twirl around your shifting silhouette." & DDUtils.RNRN &
                  "With a final explosion of brilliant light, the sword dims and you flare your glorious wings."

        TextEvent.fpush(out, AddressOf step2)
        TextEvent.pushLog("You activate your valkyrie transformation!")
        p.textColor = Game.lblEvent.ForeColor
    End Sub

    Overridable Sub setAbilities(ByRef p As Player)
        p.learnSpecial("Helix Slash")
    End Sub

    Sub step1()
        Dim p As Player = Game.player1

        HumanTF.change(p)

        If p.sex = "Male" Then
            p.MtF()
        End If

        p.changeClass("Valkyrie​")

        step1dialog(p)

        p.specialRoute()
        p.magicRoute()
    End Sub

    Sub step1combat()
        step1()
        step2()
    End Sub

    Sub step2()
        Dim p As Player = Game.player1

        If p.sex = "Male" Then
            p.MtF()
        End If

        p.changeClass("Valkyrie")

        p.breastSize = 2

        p.prt.setIAInd(pInd.rearhair, 0, True, False)
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

        setAbilities(p)

        If p.inv.getCountAt(95) < 1 Then p.inv.add(95, 1)
        EquipmentDialogBackend.armorChange(p, "Valkyrie_Armor")

        Game.lblEvent.Text = ""
        Game.lblEvent.Visible = False
        p.canMoveFlag = True

        p.drawPort()

        stopTF()
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player1
        If p.className.Equals("Valkyrie​") Then
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
End Class
