Public NotInheritable Class BUDollTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.blowupdoll

    Sub New()
        MyBase.New()
        tf_name = TF_IND
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        next_step = getNextStep(cs)
        tf_name = TF_IND
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = Int(Rnd() * 25) + 5
    End Sub

    Public Overrides Sub step1()
        Dim p As player = Game.player1
        Dim out = ""

        'equip clothes
        EquipmentDialogBackend.armorChange(p, "Naked")
        p.changeForm("Blowup Doll")

        'bu doll transformation

        p.breastSize = 4

        p.prt.setIAInd(pInd.rearhair, 39, True, True)
        p.prt.setIAInd(pInd.face, 1, True, True)
        p.prt.setIAInd(pInd.midhair, 13, True, True)
        p.prt.setIAInd(pInd.nose, 1, True, True)
        p.prt.setIAInd(pInd.mouth, 12, True, True)
        p.prt.setIAInd(pInd.eyes, 17, True, True)
        p.prt.setIAInd(pInd.eyebrows, 2, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        p.reverseBSroute()
        p.prt.setIAInd(pInd.shoulders, 9, True, False)
        p.prt.setIAInd(pInd.genitalia, 5, True, False)
    End Sub

    Public Shared Sub faeriePrincessTF()
        Dim p As Player = Game.player1

        'equip clothes
        If p.inv.getCountAt(RegalGownF.ITEM_NAME) < 1 Then p.inv.add(RegalGownF.ITEM_NAME, 1)
        EquipmentDialogBackend.armorChange(p, RegalGownF.ITEM_NAME)
        p.changeForm("Blowup Doll")

        'bu doll transformation

        p.breastSize = 3
        p.buttSize = 2
        p.dickSize = -1
        p.reverseAllRoute()

        p.prt.setIAInd(pInd.face, 1, True, True)
        p.prt.setIAInd(pInd.nose, 1, True, True)
        p.prt.setIAInd(pInd.mouth, 12, True, True)
        p.prt.setIAInd(pInd.eyes, 17, True, True)
        p.prt.setIAInd(pInd.eyebrows, 2, True, False)

        p.prt.setIAInd(pInd.cloak, 0, True, True)
        p.prt.setIAInd(pInd.hat, 22, True, True)

        p.prt.setIAInd(pInd.shoulders, 9, True, False)
        p.prt.setIAInd(pInd.genitalia, 5, True, False)

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
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
