Public NotInheritable Class DancerTF
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.dancer

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

    Public Shared Sub step1()
        Dim p As Player = Game.player1

        If p.sex = "Male" Then
            p.MtF()
        End If

        p.changeClass("Bunny Girl")

        p.breastSize = 2
        p.prt.setIAInd(pInd.rearhair, 6, True, True)
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 18, True, True)
        p.prt.setIAInd(pInd.nose, 0, True, False)

        p.prt.setIAInd(pInd.eyes, 24, True, True)

        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 18, True, True)

        p.changeHairColor(BimboTF.bimboyellow1)

        If p.equippedArmor.d_boost > 15 Then
            p.inv.add(94, 1)
            EquipmentDialogBackend.armorChange(p, "Armored_Bunny_Suit")
        Else
            p.inv.add(16, 1)
            EquipmentDialogBackend.armorChange(p, "Bunny_Suit")
        End If

        TextEvent.push("Your bowtie glows, and everything slows down.  You attempt to deftly dodge the oncoming blow, but you aren't nimble enough.  Desperately, you focus on getting as much power to the bowtie as possible, and the aura around it shifts to a blinding crimson.  As the glow fades, you find yourself able to easily duck under the attack with a nimbleness you weren't aware you had before.  As time resumes its normal pace, you are shocked to discover that your body has become that of a rabbit themed hostess!  Fortunately you seem to have higher agilty now, though you doubt you can take as hard of a hit.")
        p.canMoveFlag = True
    End Sub

    Public Shared Sub step1RND()
        Dim p As Player = Game.player1

        If p.sex = "Male" Then
            p.MtF()
        End If

        p.changeClass("Bunny Girl")

        p.breastSize = 2
        p.prt.setIAInd(pInd.rearhair, 6, True, True)
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 18, True, True)
        p.prt.setIAInd(pInd.nose, 0, True, False)

        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 18, True, True)

        p.changeHairColor(BimboTF.bimboyellow1)

        If p.inv.getCountAt(BunnySuit.ITEM_NAME) < 1 Then p.inv.add(BunnySuit.ITEM_NAME, 1)
        EquipmentDialogBackend.equipArmor(p, BunnySuit.ITEM_NAME)

        p.canMoveFlag = True
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player1
        If p.className.Equals("Bunny Girl") Then
            Return AddressOf stopTF
        Else
            Return AddressOf step1
        End If
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = 0
    End Sub
End Class
