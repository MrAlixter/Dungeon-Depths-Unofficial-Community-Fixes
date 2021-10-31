Public NotInheritable Class BunnyBimboTF
    Inherits BimboTF

    Private Const TF_IND As tfind = tfind.bunnybimbo

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        MyBase.update_during_combat = False
        tf_name = TF_IND
        next_step = AddressOf hairColorShift
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.update_during_combat = False
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    'Step 1
    Public Overrides Sub step1()
        Dim p As Player = Game.player1

        If p.sex = "Male" Then
            p.MtF()
        End If

        p.changeClass("Bunny Girl")

        p.breastSize = 2

        'hair
        p.prt.setIAInd(pInd.rearhair, 11, True, False)
        p.prt.setIAInd(pInd.midhair, 11, True, False)
        p.prt.setIAInd(pInd.fronthair, 4, True, False)
        'face
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.eyes, 25, True, True)
        p.prt.setIAInd(pInd.mouth, 25, True, True)

        'other
        p.prt.setIAInd(pInd.cloak, 0, True, False)

        p.changeHairColor(DDUtils.cShift(p.prt.haircolor, BimboTF.bimboyellow2, 50))

        If p.inv.getCountAt(222) < 1 Then p.inv.add(222, 1)
        EquipmentDialogBackend.armorChange(p, "Bunny_Suit_(Classic)")

        TextEvent.push("As you begin to feel the familiar heat of arousal, your face flushes as your clothes vanish in a *poof* of smoke.  Your nude body is engulfed in a glow from your bunny ears, and with a flash of light you turn into a rabbit themed hostess!")
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Select Case stage
            Case 1
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function

    Shared Sub tfPlayer(ByVal stepNum As Integer, ByRef p As Player)
        Dim bTF As BunnyBimboTF = New BunnyBimboTF(1, 0, 0, False)
        bTF.next_step = bTF.getNextStep(stepNum)

        bTF.next_step()
        p.UIupdate()
    End Sub
End Class