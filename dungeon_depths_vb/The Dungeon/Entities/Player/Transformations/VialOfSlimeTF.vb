Public NotInheritable Class VialOfSlimeTF
    Inherits Transformation
    Sub New(Optional cs As Integer = 2)
        MyBase.New(1, 0, 0, False)
        tfName = "VialOfSlimeTF"
        currStep = cs
        nextStep = getNextStep(cs)
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "VialOfSlimeTF"
        nextStep = getNextStep(cs)
    End Sub

    Shared Sub step1()
        'In the future this will damage/destroy armor
        Dim p = Game.player
        p.inv.add("Dissolved_Clothes", 1)
        Equipment.clothesChange("Dissolved_Clothes")
        pushLblEventWithoutLoss("As you take stock of yourself, you notice that your clothing has been partially eaten away by a teal slime that you seem to sweating in small amounts.  This seems like something you are going to need to keep an eye on...")
        p.drawPort()
        If Game.player.perks("slimetf") > -1 Then Game.player.perks("slimetf") += 1
        If Game.player.perks("googirltf") > -1 Then Game.player.perks("googirltf") += 1
    End Sub

    Sub step2()
        Dim p As Player = Game.player

        p.prt.haircolor = Color.FromArgb(180, 5, 245, 198)
        p.drawPort()
        p.perks("vsslimehair") = 0
        'Author Credit: Marionette
        pushLblEventWithoutLoss("Opening the jar the goo slowly works its way out and onto your arm, the soft cool feeling of the Slime surprisingly refreshing as it slowly moves along. It reaches your shoulder and then pushes itself up into your hair, settling in as you reach your hand up to poke at it. It almost seems to nuzzle your finger as it slowly seeps throughout your hair, changing the color and consistency of it to that of goo!")

        If Game.player.perks("slimetf") > -1 Then Game.player.perks("slimetf") += 1
    End Sub
    Sub step3()
        Dim p As Player = Game.player
        p.prt.skincolor = Color.FromArgb(230, 0, 255, 255)
        p.pForm = p.forms("Half-Slime")
        'Author Credit: Marionette
        Dim out = "As soon as the lid of the jar comes off the goo jumps out.  "
        If p.breastSize < 1 Then
            out += "landing on your flat chest and splattering about; "
        ElseIf p.breastSize > 0 And p.breastSize < 4 Then
            out += "lands on your breasts, some of the goo seeping between your mammaries.  "
        Else
            out += "lands on your massive breast, your massive mammaries jiggling a little at the impact as a bit of the goo seeps in between the crevice of your tits.  "
        End If
        out += "Your skin tingles where the slime touches it and you can’t help but smile as the blob of goo nuzzles your chest. Slowly you watch as the goo starts to squirm and creep along your skin, the tingling sensation growing stronger as you see your skin start to change to the same consistency of the slime. By the time it's done your skin has changed color and become nearly translucent. You are now a half-slime!"
        pushLblEventWithoutLoss(out)
        p.drawPort()
        If Game.player.perks("slimetf") > -1 Then Game.player.perks("slimetf") += 1
    End Sub
    Sub step4()
        Dim p As Player = Game.player
        If p.equippedWeapon.getName.Equals("Magical_Girl_Wand") Or
            p.equippedWeapon.getName.Equals("Valkyrie_Sword") Then
            Equipment.weaponChange("Fists")
        End If

        p.health = 1

        p.prt.setIAInd(pInd.ears, 5, True, True)
        If p.sex.Equals("Male") Then
            p.prt.setIAInd(pInd.eyes, 5, False, True)
        Else
            p.prt.setIAInd(pInd.eyes, 11, True, True)
        End If
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        p.pForm = p.forms("Slime")
        Equipment.clothesChange("Naked")

        p.prt.skincolor = Color.FromArgb(200, p.prt.skincolor.R, p.prt.skincolor.G, p.prt.skincolor.B)

        pushLblEventWithoutLoss("Nearly as soon as you make contact with the slime, a reaction begins and you start to melt.  Suprisingly, this doesn't really hurt so much as just feel weird, and you figure that with how much of your body was gelatinous this must have been just enough to finish you off.  Now a puddle, you further reflect that regardless of how you started out, you probably are just a slime now.  Being a sentient ball of goo means you can easily reshape your body, right?  Focusing all your willpower, you pull your body into a rough aproximation of yourself.  You are now a slime! (You will restore to this form)")
        p.drawPort()

        If Game.player.perks("slimetf") > -1 Then Game.player.perks("slimetf") = -1

        p.setStartStates()
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub
    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player

        Select Case currStep
            Case 1
                Return AddressOf step1
            Case 2
                Return AddressOf step2
            Case 3
                Return AddressOf step3
            Case 4
                Return AddressOf step4
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
    Public Shared Sub pushLblEventWithoutLoss(ByRef out As String)
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & vbCrLf & vbCrLf & out
        Game.pushLblEvent(out)
    End Sub
    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub
End Class
