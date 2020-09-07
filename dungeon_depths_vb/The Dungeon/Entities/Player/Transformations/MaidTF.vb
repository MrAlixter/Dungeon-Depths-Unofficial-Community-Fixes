Public NotInheritable Class MaidTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "MaidTF"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "MaidTF"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Sub step1()

        Dim p As Player = Game.player1

        Dim out = ""

        p.pClass.revert()
        out = p.pClass.revertPassage & DDUtils.RNRN
        p.pClass = p.classes("Maid")

        'equip clothes
        Equipment.clothesChange("Maid_Outfit")
        'maid transformation
        p.prt.haircolor = Color.FromArgb(255, 115, 72, 65)
        p.prt.setIAInd(pInd.rearhair, 8, True, True)
        p.prt.setIAInd(pInd.midhair, 8, True, True)
        p.prt.setIAInd(pInd.fronthair, 3, True, True)
        p.prt.setIAInd(pInd.hat, 2, True, False)

        'transformation description push
        If p.isUnwilling And p.prt.sexBool = False Then
            'Credit for this passage goes to Big Iron Red
            out += "As you shake the duster, the dust coming off of it seems to glow. As you take a step back, it whips into a frenzy, shrouding you in a radiant cloud. As the glow dies down, you feel...lighter? You look down, and see a flat chest, covered by a skimpy maids uniform! You panic and throw your hands down to lower your dangerously short skirt, unaware of the choker and headband placed on you, as well as the addition of a long, auburn curtain of curls down your back. Thankfully, while you are still male, as an inspection under your skirt reveals (along a pair of white panties with a telltale bulge), you have lost a great deal of muscle definition and height. You feel as weak and tiny as a... well, a young girl. Cheeks burning red, you daintily mince deeper into the dungeon on your new stiletto heels, being careful not to let anyone see the surprise under your skirt."
        Else
            out += "As you shake the duster, the dust coming off of it seems to glow.  As you take a step back, it whips into a frenzy shrouding you in a radiant cloud.  As the glow dies down, your clothes seem to have become skimpy maid's attire to match the duster, and your hair seems to have become auburn.  Sneezing, you continue on your journey to clean this entire dungeon."
        End If
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & DDUtils.RNRN & out
        Game.pushLblEvent(out)
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = game.player1
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
