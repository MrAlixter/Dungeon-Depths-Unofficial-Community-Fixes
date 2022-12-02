Public NotInheritable Class BimboMaidTF
    Inherits OneStepTF

    Private Const TF_IND As tfind = tfind.bimbomaid

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1

        Dim out = If(p.pClass.revertPassage.Length = 0, p.pClass.revertPassage & DDUtils.RNRN, "")
        p.changeClass("Maid")

        If p.sex.Equals("Male") Then
            p.MtF()
        End If

        'equip clothes
        If p.inv.getCountAt(MaidOutfit.ITEM_NAME) < 1 Then p.inv.add(MaidOutfit.ITEM_NAME, 1)
        EquipmentDialogBackend.equipArmor(p, "Maid_Outfit")

        'maid transformation
        p.changeHairColor(DDUtils.cShift(p.prt.haircolor, Color.White, 30))
        p.prt.setIAInd(pInd.rearhair, 37, True, True)
        p.prt.setIAInd(pInd.midhair, 21, True, True)
        p.prt.setIAInd(pInd.fronthair, 29, True, True)

        p.prt.setIAInd(pInd.eyes, 63, True, True)
        p.prt.setIAInd(pInd.mouth, 22, True, True)

        p.prt.setIAInd(pInd.hat, 2, True, False)

        'transformation description push
        out += "You shake the duster, sending a shimmering cloud of dust over your surroundings.  As you take a step back, coughing, a gust frenzied of wind whips around and shrouds you in a radiant veil." & DDUtils.RNRN &
               "You cover your face and eyes until the glowing storm settles down, and when you peek back out, you are wearing the frock and apron of a maid!" & DDUtils.RNRN &
               "Your hair falls in " & p.getHairColor & " ringlets down your back, and as you brush a few wayward strands aside, your hand runs past a frilly headband." & DDUtils.RNRN &
               "Black fishnet stockings rise up to your thighs from a pair of matching stiletto heels, and you are pleasantly suprised to find that you can still move freely in them." & DDUtils.RNRN &
               "With a little sneeze, you continue on your journey to... prepare the Fae Queen's evening tea?" & DDUtils.RNRN &
               "No, that doesn't seem quite right..."

        TextEvent.push(out.TrimStart(vbCrLf))

        p.UIupdate()
    End Sub
End Class
