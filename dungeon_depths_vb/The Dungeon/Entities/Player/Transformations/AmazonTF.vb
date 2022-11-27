Public NotInheritable Class AmazonTF
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.amazon

    Sub New()
        MyBase.New(1, 0, 0, False)
        tf_name = tf_ind
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = tf_ind
        next_step = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub
    Public Sub step1()
        Dim p As Player = Game.player1

        If p.sex.Equals("Male") Then
            p.MtF()
            p.breastSize = 0
        End If

        p.changeForm("Amazon")
        p.changeClass("Warrior")

        If p.breastSize > 3 Then p.breastSize = 3

        Dim r1 = Int(Rnd() * Portrait.imgLib.atrs(pInd.rearhair).ndoF)
        Dim r2 = Int(Rnd() * Portrait.imgLib.atrs(pInd.fronthair).ndoF)

        p.prt.setIAInd(pInd.rearhair, r1, True, False)
        p.prt.setIAInd(pInd.midhair, r1, True, False)
        p.prt.setIAInd(pInd.fronthair, r2, True, False)

        'Amazon transformation
        p.changeHairColor(Color.FromArgb(255, 55, 30, 0))
        p.changeSkinColor(Color.FromArgb(255, 180, 138, 120))
        p.inv.add("Amazonian_Attire", 1)
        EquipmentDialogBackend.armorChange(p, "Amazonian_Attire")
        EquipmentDialogBackend.weaponChange(p, "Fists")

        p.perks(perk.amazon) = 1
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player1
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
