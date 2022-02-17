Public NotInheritable Class ArchDemonessTF
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.archdemoness

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

    Sub step1()
        Dim p As Player = Game.player1

        If p.sex = "Male" Then
            p.MtF()
        End If

        p.changeForm("Archdemoness")

        p.breastSize = 2
        p.buttSize = 3

        p.changeHairColor(Color.FromArgb(255, 40, 101, 255))
        p.changeSkinColor(Color.FromArgb(255, 183, 211, 251))

        p.prt.setIAInd(pInd.rearhair, 12, True, True)
        p.prt.setIAInd(pInd.face, 3, True, False)
        p.prt.setIAInd(pInd.midhair, 35, True, True)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.mouth, 11, True, True)
        p.prt.setIAInd(pInd.eyes, 51, True, True)
        p.prt.setIAInd(pInd.eyebrows, 5, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 17, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)
        p.prt.setIAInd(pInd.wings, 7, True, False)
        p.prt.setIAInd(pInd.horns, 4, True, False)

        If p.inv.getCountAt("Succubus_Armor") < 1 Then p.inv.add("Succubus_Armor", 1)

        EquipmentDialogBackend.armorChange(p, "Succubus_Armor")

        p.learnSpecial("Helix Slash")

        p.canMoveFlag = True
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player1
        If p.className.Equals("Valkyrie") Then
            Return AddressOf stopTF
        Else
            Return AddressOf step1
        End If
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = 0
    End Sub
End Class
