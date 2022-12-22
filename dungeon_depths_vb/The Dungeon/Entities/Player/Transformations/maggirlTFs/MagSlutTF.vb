Public Class MagSlutTF
    Inherits MagGirlTF

    Protected Shadows Const className As String = "Magical Slut"
    Private Const TF_IND As tfind = tfind.magslut

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tf_name = TF_IND
        MG_IND = mgind.magicalslut
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        MG_IND = mgind.magicalslut
        next_step = getNextStep(cs)
    End Sub

    Public Overrides Sub step1dialog(ByRef p As Player)
        Dim out = "You swing your wand in a wide arc over your head, and you are engulfed in a rain of hearts." & DDUtils.RNRN &
                  "The light around your body becomes blinding and your clothes disolve into the aether, as beams of rose-colored energy twirl around your shifting silhouette." & DDUtils.RNRN &
                  "With a final flash of brilliant white, the wand dims and "
        If p.isUnwilling() Then
            out += "you tug at your skimpy new outfit, scoffing as you find yourself unable to remove it.  You throw the wand across the dungeon, only for it to poof back into your hand seconds later." & DDUtils.RNRN &
                   "Grumbling to yourself, you stomp your feet before setting back out, tugging down on your new skirt in a failing attempt to preserve what's left of your dignity."
        Else
            out += "you giggle before striking a cutesy pose, making sure to press your big titties together." & DDUtils.RNRN &
                   "If you were paying better attention, you might have noticed the sinister crimson aura binding the wand to your perfectly manicured hand, but, like, hey, why would you want to get rid of your cute new wand?"
        End If

        TextEvent.fpush(out, AddressOf step2)
        TextEvent.pushLog("You activate your magical girl transformation!")
        p.TextColor = Game.lblEvent.ForeColor
    End Sub

    Overrides Sub tfBody(ByRef p As Player)
        p.breastSize = 3

        p.prt.haircolor = Color.FromArgb(255, 255, 250, 205)
        p.prt.setIAInd(pInd.rearhair, 10, True, True)
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 10, True, True)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.mouth, 21, True, True)
        p.prt.setIAInd(pInd.eyes, 39, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 30, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        If p.isUnwilling() Then p.pout()
    End Sub
    Overrides Sub tfClothes(ByRef p As Player)
        If p.inv.item(170).count < 1 Then p.inv.add(170, 1)

        p.prt.setIAInd(pInd.hairacc, 3, True, False)

        Equipment.accChange(p, "Nothing")
        EquipmentDialogBackend.armorChange(p, "Magical_Slut_Outfit")

        p.textColor = Color.HotPink
    End Sub

    Overrides Sub step2()
        Dim p As Player = Game.player1

        tfBody(p)

        setSpells(p)

        tfClothes(p)

        p.changeClass(className)

        Game.lblEvent.Text = ""
        Game.lblEvent.Visible = False
        p.canMoveFlag = True

        p.drawPort()

        stopTF()
    End Sub

    Public Overridable Sub fullTF(ByRef p As Player)
        tfClothes(p)
        tfBody(p)
    End Sub
End Class
