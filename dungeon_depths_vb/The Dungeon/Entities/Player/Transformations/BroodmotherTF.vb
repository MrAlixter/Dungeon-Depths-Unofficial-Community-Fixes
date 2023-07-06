Public NotInheritable Class BroodmotherTF
    Inherits Transformation
    Public Shared hc As Color = Color.FromArgb(255, 236, 196, 87)
    Public Shared sc As Color = Color.FromArgb(255, 213, 145, 113)

    Private Const TF_IND As tfind = tfind.broodmother

    Sub New()
        MyBase.New(5, 15, 2.0, True)
        tf_name = TF_IND
    End Sub
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tf_name = TF_IND
        MyBase.update_during_combat = False
        Game.player1.perks(perk.coscale) = 0
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.update_during_combat = False
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Sub step1()
        Dim p As Player = Game.player1
        p.changeHairColor(DDUtils.cShift(p.prt.haircolor, hc, 40))
        p.changeSkinColor(DDUtils.cShift(p.prt.skincolor, sc, 40))

        If p.breastSize = -1 Then p.breastSize = 0
        If p.breastSize > 3 Then p.bs()
        If Not p.prt.haircolor.Equals(hc) Or Not p.prt.skincolor.Equals(sc) Then curr_step -= 1
    End Sub
    Sub step2()
        Dim p As Player = Game.player1

        If Not p.prt.haircolor.Equals(hc) Or Not p.prt.skincolor.Equals(sc) Then
            curr_step = 0
            Exit Sub
        End If

        Dim out = "As you pass by the smooth surface of a nearby puddle, you nearly double take at your reflection.  "
        If p.sState.getSkinColor.R > sc.R Then
            out += "Your hairstyle seems to have completely changed, and you seem to have developed a bit of a tan!"
        ElseIf p.sState.getSkinColor.R < sc.R Then
            out += "Your hairstyle seems to have completely changed, and your skin seems have become a little bit lighter!"
        Else
            out += "Your hairstyle seems to have completely changed, becoming messier than before!"
        End If

        p.prt.setIAInd(pInd.rearhair, 11, True, True)
        p.prt.setIAInd(pInd.midhair, 32, True, True)
        p.prt.setIAInd(pInd.fronthair, 31, True, True)

        If p.sex.Equals("Male") Then
            p.MtF()
            out += DDUtils.RNRN & "It also seems that you've missed more of a transformation than you thought, and your frame has become noticeably more feminine..."
        End If

        out += DDUtils.RNRN & "Slightly concerned, you set back out while musing on these changes; hoping that they don't go any further..."

        If p.breastSize <> 2 Then p.breastSize = 2

        TextEvent.push(out)
    End Sub
    Sub step3()
        Dim p As Player = Game.player1
        p.prt.setIAInd(pInd.mouth, 7, True, True)
        p.prt.setIAInd(pInd.eyes, 40, True, True)

        TextEvent.push("While the change has been gradual, you can tell that your vision is getting sharper.  As you watch an ant across the dungeon crawl up the wall, you grin to yourself..." & DDUtils.RNRN &
                       "Soon, there won't be anything that can escape your gaze.")
    End Sub
    Sub step4()
        Dim p As Player = Game.player1
        p.prt.setIAInd(pInd.wings, 5, True, False)
        p.prt.setIAInd(pInd.horns, 4, True, False)
        p.changeHairColor(hc)
        p.changeSkinColor(sc)
        TextEvent.push("A sudden shift in your center of balance knocks you over, and you prop yourself back up with the assistance of a new pair of leathery black wings." & DDUtils.RNRN &
                       "Further, a new set of wicked looking black horns poke out from your blonde hair!")
    End Sub
    Sub step5p1()
        Dim p As Player = Game.player1
        p.changeForm("Half-Dragoness")
        p.drawPort()

        TextEvent.push("While your senses have been gradually becoming more precise, you can't help but feel that you're getting less done." & DDUtils.RNRN &
                       "It's almost as though some distraction is clouding your judgment, and as you catch the echo of a dragon's wingbeat from far off in the distance you wonder if maybe you should track it down for a good fucking to clear your head..." & DDUtils.RNRN &
                       "You are now a half-broodmother!", AddressOf step5p2)
    End Sub
    Sub step5p2()
        Dim p As Player = Game.player1
        p.changeForm("Half-Broodmother")
        TextEvent.push("*A day passes...*" & DDUtils.RNRN &
                       "You may have set off to find the dragon on somewhat of a whim, but the mere thought of being pinned down and bred by it has fanned a burning desire within you.  Blushing under your scales, you stagger forward, knees weak with anticipation." & DDUtils.RNRN &
                       "While a small part of your psyche is screaming that you need to focus up, you practically tear off your clothes to get at your sex.  You collapse to the ground, panting as you desperately finger your pussy.  As you edge closer and closer to climaxing, you let out a gutteral roar, thrusting your wings out and spitting out a jet of red-hot flame." & DDUtils.RNRN &
                       "As you sprawl out, scales covering every inch of your once fleshy hide, you giggle with an almost schoolgirl-like excitement.  That dragon may have gotten away this time, but next time you'll get him for sure!" & DDUtils.RNRN &
                       "You are now a broodmother!", AddressOf step5p3)
        p.drawPort()
    End Sub
    Sub step5p3()
        Dim p As Player = Game.player1
        'unequips
        EquipmentDialogBackend.armorChange(p, "Naked")
        EquipmentDialogBackend.weaponChange(p, "Fists")

        'dragon transformation
        p.learnSpell("Dragon's Breath")
        p.changeForm("Broodmother")
        p.drawPort()
    End Sub

    Shared Sub halfDragonTF(ByRef p As Player)
        p.changeForm("Half-Dragon (R)")

        p.prt.setIAInd(pInd.mouth, 7, True, True)
        p.prt.setIAInd(pInd.eyes, 40, True, True)
        p.prt.setIAInd(pInd.wings, 5, True, False)
        p.prt.setIAInd(pInd.horns, 4, True, False)
        p.prt.setIAInd(pInd.rearhair, 38, True, True)
        p.prt.setIAInd(pInd.midhair, 44, True, True)
        p.prt.setIAInd(pInd.fronthair, 42, True, True)

        p.changeHairColor(hc)
        p.changeSkinColor(sc)

        p.breastSize = 2
        p.buttSize = 1
        p.dickSize = -1

        p.drawPort()
    End Sub

    Sub resist()
        TextEvent.pushCombat("You are able to resist the curse, but you can feel your resolve wavering...")
        Game.player1.will -= 1
    End Sub
    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player1.perks(perk.coscale) = -1
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        If Game.player1.perks(perk.coscale) = -1 Then
            Return AddressOf stopTF
        End If
        Select Case stage
            Case 0
                Return AddressOf step1
            Case 1
                Return AddressOf step2
            Case 2
                Return AddressOf step3
            Case 3
                Return AddressOf step4
            Case 4
                Return AddressOf step5p1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = 10
        turns_until_next_step += generatWILResistance()
    End Sub
End Class
