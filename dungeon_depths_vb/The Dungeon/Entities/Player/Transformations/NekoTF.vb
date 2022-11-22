Public NotInheritable Class NekoTF
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.neko

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tf_name = TF_IND
        Game.player1.perks(perk.nekocurse) = 0
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Sub step1()
        Dim p As player = Game.player1
        p.prt.setIAInd(pInd.ears, 1, p.prt.sexBool, False)
        TextEvent.pushCombat("Your ears twitch, while Marissa gives you a smug grin." & DDUtils.RNRN &
                                """I'm sure you tell where this is going."" she giggles, gesturing up at your now feline facial features." & DDUtils.RNRN &
                                "You now have cat ears!")
        p.lust += 5
        p.will -= 1
    End Sub
    Sub step2()
        Dim p As player = Game.player1
        p.prt.setIAInd(pInd.face, 0, True, False)
        TextEvent.pushCombat("Your facial structure softens, and now you have a feminine face!")
        p.lust += 5
    End Sub
    Sub step3()
        Dim p As player = Game.player1
        p.prt.setIAInd(pInd.rearhair, 12, True, True)
        p.prt.setIAInd(pInd.midhair, 17, True, True)
        p.prt.setIAInd(pInd.fronthair, 1, True, False)
        p.will -= 1
        TextEvent.pushCombat("Your hair grows down to your ass, straightening out as it lengthens.  You now have long, straight hair!")
    End Sub
    Sub step4()
        Dim p As player = Game.player1
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.eyes, 13, True, True)
        TextEvent.pushCombat("You wince and close your eye as a burning sensation flows through them. You now have kitten eyes!")
        p.lust += 5
    End Sub
    Sub step5()
        Dim p As player = Game.player1
        If Not p.prt.sexBool Then
            p.MtF()
            p.prt.setIAInd(pInd.eyes, 13, True, True)
            TextEvent.pushCombat("Your body slims down, and your chest inlates, giving you average sized breasts.  Soon after, your cock and balls shift into a vagina. You are now female!")
        Else
            be()
            curr_step += 1
        End If
        p.lust += 5
    End Sub
    Sub step6()
        Dim p As player = Game.player1

        If p.className.Equals("Magical Girl") Or p.className.Equals("Valkyrie") Then
            step6alt()
            Exit Sub
        End If

        be()
        p.prt.setIAInd(pInd.mouth, 9, True, True)
        p.will -= 2

        If p.inv.getCountAt("Cat_Lingerie") < 1 Then p.inv.add("Cat_Lingerie", 1)
        EquipmentDialogBackend.armorChange(p, "Cat_Lingerie")

        TextEvent.pushCombat("Your tits expand, your clothes shift, and you feel your will grow weaker. You are now a cat girl!" & DDUtils.RNRN &
                                "Soon you will be Marissa's pet! ")
    End Sub

    Sub step6alt()
        Dim p As player = Game.player1
        EquipmentDialogBackend.weaponChange(p, "Fists")
        EquipmentDialogBackend.armorChange(p, "Cat_Lingerie")
        be()
        p.prt.setIAInd(pInd.rearhair, 12, True, True)
        p.prt.setIAInd(pInd.midhair, 17, True, True)
        p.prt.setIAInd(pInd.fronthair, 1, True, False)
        p.prt.setIAInd(pInd.clothes, 40, True, True)
        p.prt.setIAInd(pInd.mouth, 9, True, True)
        TextEvent.pushCombat("Your hair grows down to your ass, straightening out as it lengthens.  You now have long, straight hair!  Your tits expand, your clothes shift, and you feel your will grow weaker. You are now a cat girl!" & DDUtils.RNRN &
                                "Soon you will be Marissa's pet! ")
    End Sub
    Sub step7()
        Dim p As player = Game.player1
        If p.will < 5 Then
            If p.sex = "Male" Then
                p.MtF()
                be()
            End If
            p.prt.setIAInd(pInd.rearhair, 12, True, True)
            p.prt.setIAInd(pInd.midhair, 17, True, True)
            p.prt.setIAInd(pInd.fronthair, 1, True, False)
            p.prt.setIAInd(pInd.mouth, 9, True, True)
        End If
        p.changeClass("Kitty")
        be()

        If p.inv.getCountAt(CatLingerie.ITEM_NAME) < 1 Then p.inv.add(CatLingerie.ITEM_NAME, 1)
        EquipmentDialogBackend.armorChange(p, "Cat_Lingerie")

        Game.fromCombat()
        If p.isUnwilling And p.sex.Equals("Male") Then
            'Author Credit: Big Iron Red
            TextEvent.push("As Marissa's curse starts to fade, a collar and leash manifests on your neck, with a tag that says " & p.getName & ". The collar glows gently, and you feel any strength left leaving you." & DDUtils.RNRN &
                              "Marissa tugs the leash, ""Come, kitty!""" & DDUtils.RNRN &
                              "You don't see any other option, so you follow her sheepishly on all fours, cheeks flush with embarrassment. ""Am I really just a pet from nyow on?"" you think, envisioning your future stuck with Marissa as this soft, feminine creature. It has to end eventually, right?" & DDUtils.RNRN &
                              """Don't worry, kitty! My magic will keep you young forever! You get to be cute forever and ever! You won't be an ugly boy ever again!"" Marissa chimes in, seemingly reading your mind." & DDUtils.RNRN &
                              "GAME OVER!", AddressOf p.die)
        Else
            TextEvent.push("Once the last of your resistance drains away, all you can find yourself doing is focusing on your new mistress's voice as she orders you down onto all fours." & DDUtils.RNRN &
                              "You happily oblige, purring softly, and she giggles." & DDUtils.RNRN &
                              """Come on kitty, lets go!"" she orders, and the two of you journey into the darkness." & DDUtils.RNRN &
                              "GAME OVER!", AddressOf p.die)
        End If

        p.perks(perk.nekocurse) = -1
    End Sub

    Sub resist()
        TextEvent.pushCombat("You are able to resist the curse, but you can feel your resolve wavering...")
        Game.player1.will -= 1
    End Sub
    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player1.perks(perk.nekocurse) = -1
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        If Game.player1.perks(perk.nekocurse) = -1 Then
            Return AddressOf stopTF
        ElseIf (Game.player1.className.Equals("Magical Girl") Or Game.player1.className.Equals("Valkyrie")) And stage < 6 Then
            Return AddressOf resist
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
                Return AddressOf step5
            Case 5
                Return AddressOf step6
            Case 6
                Return AddressOf step7
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = 1
        turns_until_next_step += generatWILResistance()
    End Sub

    Sub be()
        Dim p = Game.player1
        If p.breastSize < 7 Then
            p.breastSize += 1
        End If
    End Sub
End Class
