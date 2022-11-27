Public NotInheritable Class GooGirlTF
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.googirl

    Sub New(Optional cs As Integer = 2)
        MyBase.New(1, 0, 0, False)
        tf_name = TF_IND
        curr_step = cs
        next_step = getNextStep(cs)
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Private Sub step1()
        Dim p As Player = Game.player1
        Dim out As String = "Pink slime coats your " & If(p.equippedArmor.getAName.Contains("Armor"), "armor", "clothing") & "." & DDUtils.RNRN

        Dim curse_success = EquipmentDialogBackend.clothingCurse(p, False)
        If curse_success Then
            TextEvent.push(out & "It crackles with blinding light, twisting your gear into a warped perversion of itself!  The goo evaporates with a caustic hiss.")
        ElseIf Not p.equippedArmor.getAName = "Naked" Then
            TextEvent.push(out & "With a caustic hiss it evaporates, eating into your gear signifigantly." & DDUtils.RNRN &
                           Math.Max(p.equippedArmor.durability - 50, 0) & " durability remains on your " & p.equippedArmor.getAName.Replace("_", " ") & "...")
            p.equippedArmor.damage(50)
        End If

        If p.equippedArmor.getAName = "Naked" Or curse_success Then
            If Game.player1.perks(perk.googirltf) > -1 Then Game.player1.perks(perk.googirltf) += 1
        Else
            curr_step -= 1
        End If

        Application.DoEvents()
    End Sub

    Private Sub step2()
        Dim p As Player = Game.player1

        TextEvent.push("Pink slime coats your hair." & DDUtils.RNRN &
                       "It drips down in a gooey clump, much longer (and pinker) than it was before." & DDUtils.RNRN &
                       "You now have slime hair!")

        p.prt.setIAInd(pInd.rearhair, 12, True, True)
        p.prt.setIAInd(pInd.midhair, 21, True, True)
        p.prt.setIAInd(pInd.fronthair, 3, True, False)
        p.prt.haircolor = Color.FromArgb(180, 255, 120, 255)

        p.perks(perk.vsslimehair) = 0
        If p.perks(perk.googirltf) > -1 Then p.perks(perk.googirltf) += 1
    End Sub

    Private Sub step3()
        Dim p As Player = Game.player1

        p.changeForm("Half-Slime")

        p.prt.skincolor = Color.FromArgb(230, 255, 102, 179)

        TextEvent.push("Pink slime coats your entire body." & DDUtils.RNRN &
                       "While at first it seems that soaking in this much of the slime has dyed your skin, a closer inspection reveals that you can almost see through your limbs.  A little more of this goo, and you might end up completely translucent." & DDUtils.RNRN &
                       "You are now a Half-Slime!")

        If Game.player1.perks(perk.googirltf) > -1 Then Game.player1.perks(perk.googirltf) += 1
    End Sub

    Private Sub step4()
        Dim p As Player = Game.player1

        If p.sex.Equals("Male") Then
            p.MtF()
        End If

        p.changeForm("Goo Girl")

        EquipmentDialogBackend.armorChange(p, "Naked")

        p.breastSize = 4
        p.buttSize = 3

        p.prt.setIAInd(pInd.ears, 5, True, True)
        p.prt.setIAInd(pInd.mouth, 18, True, True)
        p.prt.setIAInd(pInd.eyes, 35, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        p.prt.setIAInd(pInd.rearhair, 27, True, True)
        p.prt.setIAInd(pInd.midhair, 30, True, True)
        p.prt.setIAInd(pInd.fronthair, 28, True, True)

        p.prt.skincolor = Color.FromArgb(200, p.prt.skincolor.R, p.prt.skincolor.G, p.prt.skincolor.B)

        Dim athe = "a"
        If p.health <= 0 Then athe = "the"

        TextEvent.push("Pink slime coats your entire body." & DDUtils.RNRN &
                       "Nearly as soon as you make contact, a reaction begins and you start to melt.  Suprisingly, this doesn't really hurt so much as it just feels weird, and you figure that with how much of your body was gelatinous this must have been just enough to finish you off." & DDUtils.RNRN &
                       "While you are reflecting on your current state, " & athe & " Goo Girl glides toward you and giggles..." & DDUtils.RNRN &
                       """Here, let me help you out!  Reforming can be kinda hard, so I'll just hop in and do it for you.""" & DDUtils.RNRN &
                       "Before you can protest, she dives into your body and the two of you merge into a single blob.  You are powerless to do anything but watch as she raises the both of you back up, sculpting a feminine body from your combined mass.", AddressOf step4p2)



        p.sState.save(p)
        p.savePState()

        p.health = 1
        If Game.player1.perks(perk.googirltf) > -1 Then Game.player1.perks(perk.googirltf) = -1
    End Sub

    Private Sub step4p2()
        TextEvent.push("Once upright, you are able exert a little more control; though not enough to stop her from swelling your breasts into massive udders.  The goo girl notices your efforts, and she smushes the nucleus that contains your mind into her own." & DDUtils.RNRN &
                       "Suddenly, you can, like, totally control your hot body again!  Wait... were you the " & Game.player1.className & ", or the Goo Girl?  Like, do you even care?  You giggle, before picking up your scattered belongings." & DDUtils.RNRN &
                       "Your base form is now that of a Goo Girl!  Should you revert to your start state, this is what you will become.")
    End Sub


    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player1

        Select Case curr_step
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

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub
End Class
