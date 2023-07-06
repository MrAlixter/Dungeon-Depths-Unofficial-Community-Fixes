Public NotInheritable Class SpaceBunTF
    Inherits OneStepTF

    Private Const TF_IND As tfind = tfind.spacebun

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Public Overrides Sub step1()
        Dim willChangeBody As Boolean = Game.player1.breastSize <> 2 Or Game.player1.buttSize <> 3
        tf(Game.player1)

        TextEvent.fpush("As you bite into the pastry, something feels... different." & DDUtils.RNRN &
                        "A slight tingling sensation alerts you to the tiny black strands of silk that have begun wrapping themselves around your fingertips, and a jolt down your spine freezes your body in place." & DDUtils.RNRN &
                        "You hair begins to twirl upwards, as though caught in a phantom breeze.  Each strand shifts to a soft, rosy pink, and they twist around and around; winding into massive buns." & DDUtils.RNRN &
                        "Your " & If(Game.player1.equippedArmor.getAName.Contains("Armor"), "armor", "clothes") & " begins breaking down into strands itself, reweaving into a tight pink dress.  " & If(willChangeBody, "You swoon as your body morphs to fit it,", "You swoon as it sinches up along your back,") & "  gasping as more of the black strands coil their way up your thighs." & DDUtils.RNRN &
                        "With a tickling pulse, the silken threads around your limbs pull taut, forming sheer black stockings and gloves!  Your footwear reshapes with a *pop*, becoming a sexy pair of stiletto pumps." & DDUtils.RNRN &
                        "Finally, another jolt rolls through your body and you can move again.  The science- or magic, whichever- within the pastry seems to have finished its work, leaving behind the sweet taste of sugar.")
    End Sub

    Public Shared Sub tf(ByRef p As Player)
        'transformation
        p.MtF()

        '| -- Body TF -- |
        p.breastSize = 2
        p.buttSize = 3

        '| -- Hair TF -- |
        p.prt.haircolor = Color.HotPink
        p.prt.setIAInd(pInd.midhair, 49, True, True)
        p.prt.setIAInd(pInd.rearhair, 41, True, True)

        '| -- Face TF -- |
        p.prt.setIAInd(pInd.eyes, 64, True, True)

        '| -- Clothing TF -- |
        If p.inv.getCountAt(NanosilkQipaoP.ITEM_NAME) < 1 Then p.inv.add(NanosilkQipaoP.ITEM_NAME, 1)
        EquipmentDialogBackend.equipArmor(p, NanosilkQipaoP.ITEM_NAME)
    End Sub
End Class
