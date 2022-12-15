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

        '| - Body TF - |
        p.breastSize = 2
        p.buttSize = 1

        '| - Face TF - |
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.eyes, 24, True, True)

        '| - Hair TF - |
        p.prt.setIAInd(pInd.rearhair, 18, True, True)
        p.prt.setIAInd(pInd.midhair, 18, True, True)
        p.prt.setIAInd(pInd.fronthair, 18, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)

        p.prt.setIAInd(pInd.cloak, 0, True, False)

        p.changeHairColor(BimboTF.bimboyellow1)

        If p.equippedArmor.d_boost > 15 Then
            If p.inv.getCountAt(BunnySuitA.ITEM_NAME) < 1 Then p.inv.add(BunnySuitA.ITEM_NAME, 1)
            EquipmentDialogBackend.equipArmor(p, BunnySuitA.ITEM_NAME, True)
        Else
            If p.inv.getCountAt(BunnySuit.ITEM_NAME) < 1 Then p.inv.add(BunnySuit.ITEM_NAME, 1)
            EquipmentDialogBackend.equipArmor(p, BunnySuit.ITEM_NAME, True)
        End If

        TextEvent.push("Your bowtie glows, and everything slows down." & DDUtils.RNRN &
                       "Still, even with this tremendous advantage you aren't fast enough.  Desperately, you focus everything you have into the bowtie and its aura crackles with blinding crimson light; before it erupts with a flare of mana." & DDUtils.RNRN &
                       "In that instant, you find yourself able to easily duck under the attack." & DDUtils.RNRN &
                       "Time resumes at its normal pace, and you are shocked to discover that you've been turned into a bunny-themed hostess!  Your speed is higher, though you doubt you can take as hard of a hit...")
        p.canMoveFlag = True
    End Sub

    Public Shared Sub step1RND(Optional ByVal suit As String = BunnySuit.ITEM_NAME)
        Dim p As Player = Game.player1

        If p.sex = "Male" Then
            p.MtF()
        End If

        p.changeClass("Bunny Girl")

        p.breastSize = 2
        p.buttSize = 1
        p.prt.setIAInd(pInd.rearhair, 6, True, True)
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 18, True, True)
        p.prt.setIAInd(pInd.nose, 0, True, False)

        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 18, True, True)

        If p.inv.getCountAt(suit) < 1 Then p.inv.add(suit, 1)
        EquipmentDialogBackend.equipArmor(p, suit)

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
