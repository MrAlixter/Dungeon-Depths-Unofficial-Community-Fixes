Public NotInheritable Class MaidTF
    Inherits OneStepTF

    Private Const TF_IND As tfind = tfind.maid

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

        'equip clothes
        If p.inv.getCountAt(MaidOutfit.ITEM_NAME) < 1 Then p.inv.add(MaidOutfit.ITEM_NAME, 1)
        EquipmentDialogBackend.equipArmor(p, "Maid_Outfit")

        'maid transformation
        p.prt.haircolor = Color.FromArgb(255, 115, 72, 65)
        p.prt.setIAInd(pInd.rearhair, 8, True, True)
        p.prt.setIAInd(pInd.midhair, 8, True, True)
        p.prt.setIAInd(pInd.fronthair, 3, True, True)
        p.prt.setIAInd(pInd.hat, 2, True, False)

        'transformation description push
        out += "You shake the duster, sending a shimmering cloud of dust over your surroundings.  As you take a step back, coughing, a gust frenzied of wind whips around and shrouds you in a radiant veil." & DDUtils.RNRN &
               "You cover your face and eyes until the glowing storm settles down, "
        If p.isUnwilling And p.dickSize > -1 And p.breastSize < 1 Then
            'Credit for this passage goes to Big Iron Red
            out += "and it seems to have left you feeling... lighter?" & DDUtils.RNRN & "Looking down, you see a flat chest, covered by a skimpy maids uniform!  You panic and throw your hands down to lower your dangerously short skirt, unaware of the choker and headband placed on you, as well as the addition of a long, auburn curtain of curls down your back." & DDUtils.RNRN &
                   "Thankfully, while you are still male, as an inspection under your skirt reveals (along a pair of white panties with a telltale bulge), you have lost a great deal of muscle definition and height.  You feel as weak and tiny as a... well, a young girl.  Cheeks burning red, you daintily mince deeper into the dungeon on your new stiletto heels, being careful not to let anyone see the surprise under your skirt."
        Else
            out += "and when you peek back out, you are wearing the frock and apron of a maid!" & DDUtils.RNRN &
                   "Your hair falls in auburn ringlets down your back, and as you brush a few wayward strands aside, your hand runs past a frilly headband." & DDUtils.RNRN &
                   "Black fishnet stockings rise up to your thighs from a pair of matching stiletto heels, and you are pleasantly suprised to find that you can still move freely in them." & DDUtils.RNRN &
                   "With a little sneeze, you continue on your journey to... clean this entire dungeon?" & DDUtils.RNRN &
                   "No, that doesn't seem quite right..."
        End If

        TextEvent.push(out.TrimStart(vbCrLf))

        p.UIupdate()
    End Sub
End Class
