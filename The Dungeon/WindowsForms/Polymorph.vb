Public Class Polymorph
    Public Shared porm As Boolean = True
    Public target As Monster
    Shared fList() As String = {"Succubus", "Slime", "Goddess"}
    Public bimboyellow As Color = Color.FromArgb(255, 255, 230, 160)
    Public tfForm As Boolean = False
    Dim hRatio As Double = 1
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * Me.Size.Width / 210))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Font = newFont
        Next
        Select Case porm
            Case True
                cboxPMorph.Items.Add("Warrior")
                cboxPMorph.Items.Add("Mage")
                For i = 0 To Game.formList.Count - 1
                    cboxPMorph.Items.Add(Game.formList.Item(i))
                Next
                If cboxPMorph.Items.Contains(Game.player.title) Then cboxPMorph.Items.Remove(Game.player.title)
            Case False
                For i = 0 To Game.tFormList.Count - 1
                    cboxPMorph.Items.Add(Game.tFormList.Item(i))
                Next
        End Select
        hRatio = Game.player.health / Game.player.getmaxHealth
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cboxPMorph.Text = "-- Select --" Or Not tfForm Then
            Me.Close()
            Game.player.mana += 5
            Exit Sub
        End If
        Select Case porm
            Case True
                transform(Game.player)
                Game.player.health *= hRatio
            Case False
                If target.GetType() Is GetType(NPC) Then transformN(target) Else transform(target)
        End Select

        Me.Close()
    End Sub

    Sub hpreset(ByVal h As Integer)
        'Dim p As Player = Game.player
        'If p.health - h <= 0 And p.health > p.maxHealth Then
        '    p.health = p.maxHealth
        'ElseIf p.health - h <= 0 Then

        'Else
        '    p.health -= h
        'End If

    End Sub

    'player transform methods
    Sub transform(ByRef p As Player)
        If Not p.perks("polymorphed") Or Not p.title.Equals("Magic Girl") Then
            p.pState.save(p)
        End If
        If cboxPMorph.Text.Equals(p.title) Then
            Exit Sub
        End If
        Dim color1 As Color = Color.White
        Dim out As String = ""
        If p.title = "Warrior" Then
            p.maxHealth -= 50
            hpreset(50)
            p.attack -= 10
            p.defence -= 10
            out = out & "You feel your muscle mass decrease slightly, and your physical strength becomes far more average."
        ElseIf p.title = "Mage" Then
            p.mana -= 15
            p.maxMana -= 15
            out = out & "Your mind feels slightly weaker, and your magical aptitude becomes far more average."
        ElseIf p.title = "Bimbo" Then
            out = out & "Your mind feels slightly more useful, and you pout sligthly as your tits and ass decrease in size.  While you are sad to see them go, you have become smart enough to realize that it is probably for the best."
        ElseIf p.title = "Chicken" Then
            Game.player.inventory(8).add(-1)
            out = out & " With a poof of smoke, you turn back into your normal, human, self. You sigh a big sigh of relief. "
        ElseIf p.title = "Dragon" Then
            out = out & "Your scales slowly disappear into your skin as you slowly turn back into a biped. On the bright side, you are pretty sure you could still breath fire if you really wanted to."
        ElseIf p.title = "Slime" Then
            p.perks("slimehair") = False
            out = out & "Your body is feeling much more solid than before. You get the feeling healing won't be as easy as it was when you were semi-liquid."
        ElseIf p.title = "Succubus" Then
            out = out & "You roll your eyes as the purple tint leaves your skin, and your demonic features slowly shrink into nothingness."
        ElseIf p.title = "Goddess" Then
            out = out & "The golden aura leaves your body, and you once again join the world of the mortals."
        ElseIf p.title = "Magic Girl" Then
            Game.cboxMG.Items.Remove("Heartblast Starcannon")
            Game.lstLog.Items.Add("'Heartblast Starcannon' spell forgotten!")
            out = out & "As you stow your wand, the glow engulfing it fades and you return to your original form. Well, until you should be called on again, at least."
        End If

        p.title = cboxPMorph.Text
        If p.title = "Dragon" Then
            If Not p.dragState.initFlag Then
                p.health = 500
                p.maxHealth = 500
                p.attack = 100
                p.defence = 100
                Equipment.clothesChange("Naked")
                p.equippedWeapon = New BareFists()
                p.iArrInd(16) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fHat.Count - 2, True)
                p.TextColor = Color.Green
                p.dragState.save(p)
            Else
                p.dragState.load(p)
            End If
            If Not Game.cboxMG.Items.Contains("Dragon's Breath") Then Game.cboxMG.Items.Add("Dragon's Breath")
            out = out & " You can feel green scales begin to cover most of your body, as another wave of mana washes over you.  As your new scales begin to thicken, you are forced down onto all fours, and a quick glance back confirms that you now have grown considerably, as well as now have a thick reptilian tail, an a proper set of dragon wings, colored the same color green as the rest of your body. After your face finishes extending into a snout, and you feel the last of the changes stop, it finally hits you. You are now a dragon."
            color1 = Color.Green
        ElseIf p.title = "Slime" Then
            If Not p.slimState.initFlag Then
                p.health = 120
                p.maxHealth = 120
                p.TextColor = Color.FromArgb(255, 2, 249, 200)
                p.perks("slimehair") = True
                Equipment.clothesChange("Naked")
                p.equippedWeapon = New BareFists()
                p.haircolor = Color.FromArgb(180, 5, 245, 198)
                p.skincolor = Color.FromArgb(200, 0, 255, 255)
                p.iArrInd(6) = New Tuple(Of Integer, Boolean)(5, True)
                p.iArrInd(9) = New Tuple(Of Integer, Boolean)(5, True)
                p.iArrInd(10) = New Tuple(Of Integer, Boolean)(0, True)
                p.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
                p.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)
                If Not p.sexBool Then
                    p.idRouteFM()
                End If
                p.slimState.save(p)
            Else
                p.slimState.load(p)
            End If
            out += " Your skin feels wetter than it did a minute ago.  As you look down, you see that your body is slowly disolving into a aquamarine fluid! You melt down into a puddle, and find that while it is challenging, you can somewhat manipulate your body.  After some experimentation, you find yourself in a rough aproximation of your original form."
            color1 = Color.FromArgb(2, 249, 200)
        ElseIf p.title = "Succubus" Then
            If Not p.succState.initFlag Then
                p.attack = 25
                p.defence = 25
                p.speed = 50
                p.mana = 75
                p.maxMana = 75
                p.TextColor = Color.FromArgb(231, 126, 245)
                If p.sex = "Male" Then
                    p.sexBool = True
                    p.MtF()
                    out += " Your body becomes daintier, and you are soon fully female."
                End If
                Equipment.clothesChange("Succubus_Garb")
                p.equippedWeapon = New BareFists()
                p.haircolor = Color.FromArgb(255, 155, 0, 0)
                p.skincolor = Color.FromArgb(255, 255, 105, 180)
                p.iArrInd(1) = New Tuple(Of Integer, Boolean)(9, True)
                p.iArrInd(4) = New Tuple(Of Integer, Boolean)(0, True)
                p.iArrInd(5) = New Tuple(Of Integer, Boolean)(9, True)
                p.iArrInd(7) = New Tuple(Of Integer, Boolean)(0, True)
                p.iArrInd(9) = New Tuple(Of Integer, Boolean)(12, True)
                p.iArrInd(10) = New Tuple(Of Integer, Boolean)(0, True)
                p.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
                p.iArrInd(15) = New Tuple(Of Integer, Boolean)(13, True)
                p.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)
                p.wingInd = 2
                p.succState.save(p)
            Else
                p.succState.load(p)
            End If
            color1 = Color.FromArgb(231, 126, 245)
            out += " As hellfire engulfs you, you ponder over what you should do to your opponent.  Maybe flay them, mabye just go for a quick clean decapitation, or maybe tie them up and use them as a fucktoy until you get bored?  'Well,' you tell them with a sinister grin, '... whatever I decide on ...' you do a pirouette, showing off your new body in all its glory '... will certainly be more fun for me ...' you lock eyes with your prey and bare your fangs in a vicious sneer '... than for you.'"
        ElseIf p.title = "Goddess" Then
            If Not p.goddState.initFlag Then
                p.health = 9999
                p.maxHealth = 9999
                p.attack = 9999
                p.defence = 9999
                p.speed = 9999
                p.mana = 9999
                p.maxMana = 9999
                p.TextColor = Color.Goldenrod
                If p.sex = "Male" Then
                    p.MtF()
                    out += " Your body becomes daintier, and you are soon fully female."
                End If
                Equipment.clothesChange("Goddess_Gown")
                p.equippedWeapon = New BareFists()
                p.haircolor = Color.FromArgb(255, 210, 180, 140)
                If p.skincolor = Color.FromArgb(255, 255, 105, 180) Then p.haircolor = Color.FromArgb(255, 155, 0, 0)
                If p.skincolor = Color.FromArgb(200, 0, 255, 255) Then p.haircolor = Color.FromArgb(180, 5, 245, 198)
                p.iArrInd(1) = New Tuple(Of Integer, Boolean)(8, True)
                p.iArrInd(2) = New Tuple(Of Integer, Boolean)(1, True)
                p.iArrInd(4) = New Tuple(Of Integer, Boolean)(0, True)
                p.iArrInd(5) = New Tuple(Of Integer, Boolean)(8, True)
                p.iArrInd(6) = New Tuple(Of Integer, Boolean)(0, True)
                p.iArrInd(7) = New Tuple(Of Integer, Boolean)(0, True)
                p.iArrInd(8) = New Tuple(Of Integer, Boolean)(8, True)
                p.iArrInd(9) = New Tuple(Of Integer, Boolean)(10, True)
                p.iArrInd(10) = New Tuple(Of Integer, Boolean)(0, True)
                p.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
                p.iArrInd(15) = New Tuple(Of Integer, Boolean)(9, True)
                p.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)
                p.goddState.save(p)
            Else
                p.goddState.load(p)
            End If
            out += " Your eyes burn with an awesome fury as golden flames engulf you.  Your opponent squints and covers their eyes, blinded by your new found vibrance.  Dialing back your personal light show, you give them a cocky grin.  They may not know it, but this battle is already over."
            color1 = Color.Goldenrod
        End If
        p.perks("polymorphed") += (Int(Rnd() * 15) * 1.5) + 2
        Equipment.portraitUDate()
        p.createP()
        Game.lblEvent.ForeColor = color1
        Game.lblNameTitle.ForeColor = color1
        Game.pushLblEvent(out)
        p.perks("polymorphed") -= 1
        p.TextColor = Game.lblEvent.ForeColor
        p.pImage = Game.pImage
        p.health += p.hBuff
        Game.cmboxSpec.Items.Clear()
        Game.specialRoute()
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Public Sub transform(ByRef p As Player, ByVal form As String)
        If p.perks("polymorphed") Then
            Game.lstLog.Items.Add("Your form prevents you from being polymorphed.")
            Exit Sub
        End If
        If Not p.perks("polymorphed") > -1 And Not p.title.Equals("Magic Girl") Then
            p.pState.save(p)
        End If
        Dim color1 As Color = Color.White
        Dim out As String = ""
        If p.title = "Warrior" Then
            p.maxHealth -= 50
            hpreset(50)
            p.attack -= 10
            p.defence -= 10
            out = out & "You feel your muscle mass decrease slightly, and your physical strength becomes far more average."
        ElseIf p.title = "Mage" Then
            p.mana -= 15
            p.maxMana -= 15
            out = out & "Your mind feels slightly weaker, and your magical aptitude becomes far more average."
        ElseIf p.title = "Bimbo" Then
            out = out & "Your mind feels slightly more useful, and you pout sligthly as your tits and ass decrease in size.  While you are sad to see them go, you have become smart enough to realize that it is probably for the best."
        ElseIf p.title = "Chicken" Then
            Game.player.inventory(8).add(-1)
            out = out & " With a poof of smoke, you turn back into your normal, human, self. You sigh a big sigh of relief. "
        ElseIf p.title = "Dragon" Then
            out = out & "Your scales slowly disappear into your skin as you slowly turn back into a biped. On the bright side, you are pretty sure you could still breath fire if you really wanted to."
        ElseIf p.title = "Slime" Then
            p.perks("slimehair") = False
            out = out & "Your body is feeling much more solid than before. You get the feeling healing won't be as easy as it was when you were semi-liquid."
        ElseIf p.title = "Succubus" Then
            out = out & "You roll your eyes as the purple tint leaves your skin, and your demonic features slowly shrink into nothingness."
        ElseIf p.title = "Goddess" Then
            out = out & "The golden aura leaves your body, and you once again join the world of the mortals."
        ElseIf p.title = "Magic Girl" Then
            Game.cboxMG.Items.Remove("Heartblast Starcannon")
            Game.lstLog.Items.Add("'Heartblast Starcannon' spell forgotten!")
            out = out & "As you stow your wand, the glow engulfing it fades and you return to your original form. Well, until you should be called on again, at least."
        End If

        If form = "Warrior" Then
            p.health += 2
            p.maxHealth += 2
            p.attack += 2
            p.defence += 1
        ElseIf form = "Mage" Then
            p.mana += 15
            p.maxMana += 15
        ElseIf form = "Chicken" Then
            p.equippedArmor.add(-1)
            p.inventory.Item(8).addOne()
            p.equippedArmor = p.inventory.Item(8)
            p.defence += p.equippedArmor.aBoost
            Game.pImage = Game.picChicken.BackgroundImage
            If p.sexBool Then
                p.iArrInd(16) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fHat.Count - 2, True)
            Else
                p.iArrInd(16) = New Tuple(Of Integer, Boolean)(CharacterGenerator.mHat.Count - 2, False)
            End If
            out = out & " You cluck nervously as you recall your recent encounter. Wait . . . cluck?!?  You start to notice that everything in the room is looking much bigger.  You flail your wings as panic sets in, while your nose and mouth shift into a beak.  As your white puffy featers come in, you can't help but think back to when the kids in your hometown used to call you ''chicken''. Looks like they were right."
            color1 = Color.LightGoldenrodYellow
        ElseIf form = "Chicken2" Then
            form = "Chicken"
            p.defence += p.equippedArmor.aBoost
            Game.pImage = Game.picChicken.BackgroundImage
            'Form1.pIndex = 2
            out = out & " Putting on the chicken suit, you notice that once again everything in the room is looking much bigger.  You examine your wings closer, observing the changes as they happen.  As your nose and mouth shift into a beak, you feel the last of your white puffy featers come in. A chicken once again, you can't help but wonder if you actually might deserve to stay this way for your cowardice."
            If p.sexBool Then
                p.iArrInd(16) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fHat.Count - 2, True)
            Else
                p.iArrInd(16) = New Tuple(Of Integer, Boolean)(CharacterGenerator.mHat.Count - 2, False)
            End If
            color1 = Color.LightGoldenrodYellow
        ElseIf form = "Magic Girl" Then
            p.health = 199
            p.maxHealth = 199
            p.attack = 25
            p.speed = 60
            p.mana = 99
            p.maxMana = 99
            out = out & "Swinging your wand, you are engulfed in a rain of stars. As the light around your body grows blinding and your clothes disolve into the aether, you become a buxom young woman wearing a skimpy uniform!"
            If p.sex = "Male" Then
                p.sex = "Female"
                p.sexBool = True
            End If
            p.iArrInd(16) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fHat.Count - 3, True)
        End If
        p.title = form
        Game.lblEvent.ForeColor = color1
        Game.lblNameTitle.ForeColor = color1
        If form.Equals("Magic Girl") Then Game.pushLblEvent(out, AddressOf Polymorph.magicGSub2) Else Game.pushLblEvent(out)
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        p.TextColor = Game.lblEvent.ForeColor
        p.pImage = Game.pImage
        p.health += p.hBuff
        Game.cmboxSpec.Items.Clear()
        Game.specialRoute()
        p.createP()
    End Sub
    Public Sub transform(ByRef p As Player, ByVal form As String, ByVal ind As Integer)
        If p.perks("polymorphed") > -1 Then
            Game.lstLog.Items.Add("Your form prevents you from being polymorphed.")
            Exit Sub
        End If
        If Not p.perks("polymorphed") > -1 And Not p.title.Equals("Magic Girl") Then
            p.pState.save(p)
        End If
        If form = "bimbo" Then
            bimboTF(p, ind)
        ElseIf form = "neko" Then
            nekoTF(p, ind)
        ElseIf form = "targax" Then
            targaxTF(p, ind)
        ElseIf form = "slime" Then
            slimeTF(p, ind)
        ElseIf form = "angel" Then
            Game.pushLblEvent("As you bite into the cake, you are lost in its sweet flavor.  So lost, in fact, that you miss the large white wings growing on you back.  You are now an angel!")
            p.changeHairColor(Color.FromArgb(255, 245, 231, 184))
            p.iArrInd(1) = New Tuple(Of Integer, Boolean)(5, True)
            p.iArrInd(5) = New Tuple(Of Integer, Boolean)(14, True)
            p.iArrInd(15) = New Tuple(Of Integer, Boolean)(11, True)
            p.wingInd = 1
        ElseIf form = "maid" Then
            Game.pushLblEvent("As you shake the duster, the dust coming off of it seems to glow.  As you take a step back, it whips into a frenzy shrouding you in a radiant cloud.  As the glow dies down, your clothes seem to have become skimpy maid's attire to match the duster, and your hair seems to have become auburn.  Sneezing, you continue on your journey to clean this entire dungeon.")
            Equipment.clothesChange("Maid_Outfit")
            p.title = "Maid"
            p.haircolor = Color.FromArgb(255, 115, 72, 65)
            p.iArrInd(1) = New Tuple(Of Integer, Boolean)(8, True)
            p.iArrInd(5) = New Tuple(Of Integer, Boolean)(8, True)
            p.iArrInd(15) = New Tuple(Of Integer, Boolean)(3, True)
            p.iArrInd(16) = New Tuple(Of Integer, Boolean)(2, True)
            If Not Game.player.perks("polymorphed") > -1 And Not Game.player.title.Equals("Magic Girl") Then
                Game.player.pState.save(Game.player)
            End If
        ElseIf form = "princess" Then
            Select Case ind
                Case 0
                    Game.pushLblEvent("As you bite into the apple, your mind starts to get foggy.  You yawn, " &
                                                   "and lay down on the floor.  As you nod off, you realize that that apple" &
                                                   " probably was probably either enchanted or poisoned, and as you black out" &
                                                   " your last thought is that this seems like something out of an old fairy " &
                                                   "tail.", AddressOf PApple.princessTF)
                    p.iArrInd(8) = New Tuple(Of Integer, Boolean)(3, p.sexBool)
                    If p.sexBool Then
                        p.iArrInd(9) = New Tuple(Of Integer, Boolean)(5, True)
                    Else
                        p.iArrInd(9) = New Tuple(Of Integer, Boolean)(4, False)
                    End If
                Case 1
                    Game.pushLblEvent("As you come to several hours later, you groan and rub your forhead, only to knock a golden crown off of your head. This jolts you up, and you examine yourself further.  Long hair, poofy ballgown, gloves that go up past your elbows?!  Well, it seems like your 'fairy-tail' hunch wasn't too far off after all.  Dusting youself off, you get ready to embark back on your journey to return to your kingdom.  Wait...that isn't why you came here..." & vbCrLf & "Or was it?")
                    Equipment.clothesChange("Regal_Gown")
                    If Not p.sexBool Then
                        p.MtF()
                    End If
                    p.title = "Princess"
                    p.changeHairColor(Color.FromArgb(255, 181, 148, 98))
                    p.iArrInd(1) = New Tuple(Of Integer, Boolean)(1, True)
                    p.iArrInd(5) = New Tuple(Of Integer, Boolean)(13, True)
                    p.iArrInd(8) = New Tuple(Of Integer, Boolean)(0, True)
                    p.iArrInd(9) = New Tuple(Of Integer, Boolean)(p.pState.iArrInd(9).Item1, True)
                    p.iArrInd(15) = New Tuple(Of Integer, Boolean)(10, True)
                    p.iArrInd(16) = New Tuple(Of Integer, Boolean)(6, True)
                    If Not Game.player.perks("polymorphed") > -1 And Not Game.player.title.Equals("Magic Girl") Then
                        Game.player.pState.save(Game.player)
                    End If
            End Select
        ElseIf form = "doll" Then
            Game.pushLblEvent("Looking down, you see some sort of coupon laying on the ground.  Picking it up, you read " & vbCrLf &
                               "𝘕𝘦𝘦𝘥 𝘱𝘰𝘵𝘦𝘯𝘵 𝘮𝘢𝘨𝘪𝘤 𝘪𝘵𝘦𝘮𝘴 𝘸𝘪𝘵𝘩 𝘯𝘰 𝘲𝘶𝘦𝘴𝘵𝘪𝘰𝘯𝘴 𝘢𝘴𝘬𝘦𝘥?  𝘏𝘪𝘵 𝘶𝘱 𝘵𝘩𝘦 𝘉𝘳𝘰𝘸𝘯 𝘏𝘢𝘵, 𝘤𝘰𝘮𝘪𝘯𝘨 𝘵𝘰 𝘢 𝘥𝘶𝘯𝘨𝘦𝘰𝘯 𝘯𝘦𝘢𝘳 " &
                               "𝘺𝘰𝘶 𝘴𝘰𝘰𝘯!  𝘚𝘦𝘦 𝘵𝘩𝘦 𝘣𝘢𝘤𝘬 𝘧𝘰𝘳 𝘢 𝘧𝘳𝘦𝘦 𝘴𝘢𝘮𝘱𝘭𝘦." & vbCrLf &
                               "Flipping the scrap over, your fingers brush against a rune, activating it with the slightest touch." &
                               "  You suddenly find yourself feeling immobile, yet strangely light as your body collapses in on itself, leaving you an immobile sheet of vinyl." &
                               "  A rush of air from the rune returns you to an exagerated female form, though apart from having changed with the rest of your " &
                               "genitalia seems largly unchanged.  Propping yourself up, you try to re-equip your gear only to find that you can barely hold a weapon, let alone wear armor. This 'free sample' seems to have turned you into a sentient sex doll.  𝘉𝘳𝘰𝘸𝘯 𝘏𝘢𝘵, 𝘩𝘶𝘩...")
            Equipment.clothesChange("Naked")
            p.title = "Blow-Up Doll"
            p.perks("polymorphed") = -1
            p.perks("polymorphed") = Int(Rnd() * 50)
            p.defence = 1

            p.iArrInd(1) = New Tuple(Of Integer, Boolean)(14, True)
            p.iArrInd(2) = New Tuple(Of Integer, Boolean)(16, True)
            p.iArrInd(4) = New Tuple(Of Integer, Boolean)(1, True)
            p.iArrInd(5) = New Tuple(Of Integer, Boolean)(18, True)
            p.iArrInd(7) = New Tuple(Of Integer, Boolean)(1, True)
            p.iArrInd(8) = New Tuple(Of Integer, Boolean)(12, True)
            p.iArrInd(9) = New Tuple(Of Integer, Boolean)(17, True)
            p.iArrInd(10) = New Tuple(Of Integer, Boolean)(2, False)
            p.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
            p.iArrInd(15) = New Tuple(Of Integer, Boolean)(14, True)
            p.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)
        End If
        Equipment.portraitUDate()
    End Sub
    'monster transform method
    Sub transform(ByRef t As Monster)
        Dim title As String = cboxPMorph.Text
        If title = "Sheep" Then
            t.health = 50
            t.maxHealth = 50
            t.attack = 1
            t.defence = 1
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Sheep"
        ElseIf title = "Princess" Then
            t.health = 60
            t.maxHealth = 60
            t.attack = 5
            t.defence = 1
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Princess"
        ElseIf title = "Bunny" Then
            t.health = 25
            t.maxHealth = 25
            t.attack = 1
            t.defence = 1
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Bunny"
        ElseIf title = "Chicken" Then
            t.health = 45
            t.maxHealth = 45
            t.attack = 5
            t.defence = 5
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Chicken"
        ElseIf title = "Cow" Then
            t.health = 75
            t.maxHealth = 75
            t.attack = 0
            t.defence = 0
            t.tfCt = 1
            t.tfEnd = 6
            t.form = "Cow"
        End If
    End Sub
    'npc transform method
    Sub transformN(ByRef t As NPC)
        Dim title As String = cboxPMorph.Text
        If title = "Sheep" Then
            t.health = 50
            t.maxHealth = 50
            t.attack = 1
            t.defence = 1
            t.tfCt = 1
            t.tfEnd = 6
            t.npcIndex = 2
            t.form = "Sheep"
        ElseIf title = "Princess" Then
            t.health = 999
            t.maxHealth = 999
            t.attack = 50
            t.defence = 1
            t.tfCt = 1
            t.tfEnd = 15
            t.npcIndex = 3
            t.toFemale("prin")
            t.form = "Princess"
        ElseIf title = "Bunny" Then
            t.health = 500
            t.maxHealth = 500
            t.attack = 1
            t.defence = 1
            t.tfCt = 1
            t.tfEnd = 15
            t.npcIndex = 4
            t.toFemale("bunny")
            t.form = "Bunny Girl"
            Game.NPCfromCombat(t)
        ElseIf title = "Chicken" Then
            t.health = 45
            t.maxHealth = 45
            t.attack = 5
            t.defence = 5
            t.tfCt = 1
            t.tfEnd = 6
            t.npcIndex = 6
            t.form = "Chicken"
        ElseIf title = "Cow" Then
            t.health = 75
            t.maxHealth = 75
            t.attack = 0
            t.defence = 0
            t.tfCt = 1
            t.tfEnd = 6
            t.npcIndex = 7
            t.form = "Cow"
        End If
        Game.npcIndex = t.npcIndex
    End Sub

    'auxilary methods for multiple step tfs
    Shared Sub magicGSub2()
        Dim p As Player = Game.player
        If p.magGState.initFlag Then
            p.magGState.load(p)
        Else
            p.breastSize = 1
            p.iArrInd(1) = New Tuple(Of Integer, Boolean)(7, True)
            p.iArrInd(2) = New Tuple(Of Integer, Boolean)(10, True)
            p.iArrInd(3) = New Tuple(Of Integer, Boolean)(12, True)
            p.iArrInd(4) = New Tuple(Of Integer, Boolean)(0, True)
            p.iArrInd(5) = New Tuple(Of Integer, Boolean)(7, True)
            p.iArrInd(6) = New Tuple(Of Integer, Boolean)(6, True)
            p.iArrInd(7) = New Tuple(Of Integer, Boolean)(0, True)
            p.iArrInd(8) = New Tuple(Of Integer, Boolean)(7, True)
            p.iArrInd(9) = New Tuple(Of Integer, Boolean)(9, True)
            p.iArrInd(10) = New Tuple(Of Integer, Boolean)(0, True)
            p.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
            p.iArrInd(15) = New Tuple(Of Integer, Boolean)(8, True)
            p.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)
            p.magGState.save(p)
            p.magGState.initFlag = True
        End If
        Game.cboxMG.Items.Add("Heartblast Starcannon")
        p.inventory.Item(10).addOne()
        Equipment.clothesChange("Magic_Girl_Outfit")
        p.equippedArmor = New MagGirlOutfit
        Game.lstLog.Items.Add("'Heartblast Starcannon' spell learned!")
        p.createP()
    End Sub
    Sub bimboTF(ByRef p As Player, ByVal ind As Integer)
        Select Case ind
            Case 0
                'If p.title = "Chicken" Then
                '    p.haircolor = Color.FromArgb(255, 230, 0, 0)
                '    p.iArrInd(1) = New Tuple(Of Integer, Boolean)(12, True)
                '    p.iArrInd(5) = New Tuple(Of Integer, Boolean)(12, True)
                '    p.iArrInd(15) = New Tuple(Of Integer, Boolean)(13, True)
                '    Form1.pushLblEvent("With a poof of smoke, you are no longer a chicken! Something seems off though . . . ")
                If Name = "Targax" Then
                    p.haircolor = Color.FromArgb(255, 255, 0, 147)
                    p.iArrInd(1) = New Tuple(Of Integer, Boolean)(9, True)
                    p.iArrInd(5) = New Tuple(Of Integer, Boolean)(9, True)
                    p.iArrInd(15) = New Tuple(Of Integer, Boolean)(13, True)
                Else
                    p.haircolor = bimboyellow
                    p.iArrInd(1) = New Tuple(Of Integer, Boolean)(1, True)
                    p.iArrInd(5) = New Tuple(Of Integer, Boolean)(5, True)
                    p.iArrInd(15) = New Tuple(Of Integer, Boolean)(6, True)
                End If

                If p.breastSize = 1 Then
                    p.iArrInd(2) = New Tuple(Of Integer, Boolean)(6, True)
                    If p.equippedArmor.getName.ToString() = "Common_Clothes" Then
                        p.iArrInd(3) = New Tuple(Of Integer, Boolean)(5, True)
                    End If
                Else
                    p.be()
                End If
                If p.title.Equals("Magic Girl") Then
                    p.iArrInd(16) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fHat.Count - 3, True)
                    p.perks("bimbotf") = 24
                End If
                If p.iArrInd(6).Item1 = 8 And p.iArrInd(6).Item2 Then p.iArrInd(6) = New Tuple(Of Integer, Boolean)(0, True)
                p.iArrInd(8) = New Tuple(Of Integer, Boolean)(5, True)
                p.iArrInd(9) = New Tuple(Of Integer, Boolean)(7, True)
                p.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
                If Not p.title.Equals("Magic Girl") Then p.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)
                p.lust += 10
            Case 1
                Dim out As String = ""
                If Not p.sexBool Then
                    out += "In your haze, you look down to see breasts blossoming from your chest. You giggle, all traces of intelect vanishing as your body becomes more curvy and feminine. As your dainty hands move down your body, you discover that you no longer have a cock and balls, and insted have a tight moist cunt.  Your hair lengthens, becoming a platinum blonde, and your clothes change to match your new figure."
                    p.sex = "Female"
                    p.sexBool = True
                ElseIf p.sexBool And p.breastSize < 3 Then
                    out += "In your haze, you look down at your tits. You, like, never noticed how round and big they had got. You giggle, all traces of intelect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a platinum blonde, and your clothes change to match your new figure."
                ElseIf p.sexBool And p.breastSize >= 3 Then
                    out += "In your haze, you look down to see your clothes have become tight and pink. You giggle, all traces of intelect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a platinum blonde, and your clothes finish changing to match your new figure."
                End If
                If p.perks("bimbotf") = 25 Then Game.pushLblEvent(out)
                p.title = "Bimbo"
                p.lust += 10
                p.attack -= 10
                p.defence -= 10
                'final tf Stage
                If Name.Equals("Targax") Then p.haircolor = Color.FromArgb(255, 20, 20, 20) Else p.haircolor = Color.FromArgb(255, 245, 231, 184)
                If Game.isMark Then
                    p.iArrInd(1) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fRearHair2.Count - 2, True)
                    p.iArrInd(2) = New Tuple(Of Integer, Boolean)(6, True)
                    p.iArrInd(8) = New Tuple(Of Integer, Boolean)(6, True)
                    p.iArrInd(9) = New Tuple(Of Integer, Boolean)(8, True)
                    p.iArrInd(3) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fClothing.Count - 2, True)
                    p.iArrInd(5) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fRearHair1.Count - 2, True)
                    p.iArrInd(15) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fFrontHair.Count - 2, True)
                End If

                If p.breastSize < 3 And Not p.title.Equals("Magic Girl") And Game.isMark = False Then
                    p.iArrInd(2) = New Tuple(Of Integer, Boolean)(7, True)
                Else
                    p.be()
                End If

                If Not p.equippedArmor.getName.Equals("Naked") And Not p.title.Equals("Magic Girl") And Game.isMark = False Then
                    Dim eAName As String = p.equippedArmor.getName.ToString
                    Equipment.clothingCurse1()
                    If eAName = p.equippedArmor.getName Then
                        Equipment.clothesChange("Skimpy_Clothes")
                    End If
                End If

                If Game.isMark = False Then
                    If Name <> "Targax" Then
                        p.haircolor = Color.FromArgb(255, 250, 250, 205)
                        p.iArrInd(1) = New Tuple(Of Integer, Boolean)(6, True)
                        p.iArrInd(5) = New Tuple(Of Integer, Boolean)(6, True)
                        p.iArrInd(9) = New Tuple(Of Integer, Boolean)(8, True)
                        p.iArrInd(15) = New Tuple(Of Integer, Boolean)(7, True)
                    Else
                        p.iArrInd(9) = New Tuple(Of Integer, Boolean)(16, True)
                    End If
                    p.iArrInd(8) = New Tuple(Of Integer, Boolean)(6, True)
                End If
                If Game.floor < 6 Then p.pImage = Game.picPlayerB.BackgroundImage Else p.pImage = Game.picBimbof.BackgroundImage
                p.TextColor = Color.HotPink
                p.perks("bimbotf") = -1
            Case 2
                p.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)
                p.iArrInd(2) = New Tuple(Of Integer, Boolean)(7, True)
                Equipment.clothesChange("Magic_Girl_Outfit")
                p.breastSize = 3
                Equipment.portraitUDate()
                p.haircolor = Color.FromArgb(255, 255, 250, 205)
                p.iArrInd(1) = New Tuple(Of Integer, Boolean)(10, True)
                p.iArrInd(5) = New Tuple(Of Integer, Boolean)(10, True)
                p.iArrInd(15) = New Tuple(Of Integer, Boolean)(7, True)
                p.iArrInd(6) = New Tuple(Of Integer, Boolean)(0, True)
                p.iArrInd(8) = New Tuple(Of Integer, Boolean)(6, True)
                p.iArrInd(9) = New Tuple(Of Integer, Boolean)(8, True)
                p.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)

                Game.pushLblEvent("You immediatly feel funny, the increased magic in your system reacting swiftly with the gum.  In your haze, you look down to see your clothes have become tight and pink. You giggle, all traces of intelect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a platinum blonde, and your clothes finish changing to match your new figure.")
                p.title = "Bimbo"
                p.lust += 10
                p.attack -= 10
                p.defence -= 10
                If Game.floor < 6 Then p.pImage = Game.picPlayerB.BackgroundImage Else p.pImage = Game.picBimbof.BackgroundImage
                p.TextColor = Color.HotPink
                p.perks("bimbotf") = -1
        End Select
    End Sub
    Sub nekoTF(ByRef p As Player, ByVal ind As Integer)
        Select Case ind
            Case 0
                p.iArrInd(6) = New Tuple(Of Integer, Boolean)(1, p.sexBool)
                Game.pushLblCombatEvent("Your ears twitch, becoming feline while Marissa gives you a malicious grin.  'I'm sure you tell where this is going,' she giggles.  You now have cat ears!")
                p.lust += 5
            Case 1
                p.iArrInd(4) = New Tuple(Of Integer, Boolean)(0, True)
                Game.pushLblCombatEvent("Your facial structure softens, and now you have a feminine face!")
                p.lust += 5
            Case 2
                p.iArrInd(1) = New Tuple(Of Integer, Boolean)(12, True)
                p.iArrInd(5) = New Tuple(Of Integer, Boolean)(17, True)
                p.iArrInd(15) = New Tuple(Of Integer, Boolean)(1, True)
                p.haircolor = Color.FromArgb(255, 20, 20, 20)
                Game.pushLblCombatEvent("Your hair grows down to your ass, and darkens to a shade of shiny black.  You now have long black hair!")
            Case 3
                p.iArrInd(7) = New Tuple(Of Integer, Boolean)(0, True)
                p.iArrInd(9) = New Tuple(Of Integer, Boolean)(13, True)
                Game.pushLblCombatEvent("You wince and close your eye as a burning sensation flows through them. You now have kitten eyes!")
                p.lust += 5
            Case 4
                If Not p.sexBool Then
                    p.MtF()
                    p.be()
                    p.iArrInd(9) = New Tuple(Of Integer, Boolean)(13, True)
                    Game.pushLblCombatEvent("Your body slims down, and your chest inlates, giving you average sized breasts.  Soon after, your cock and balls shift into a vagina. You are now female!")
                Else
                    p.be()
                    p.perks("nekocurse") += 1
                End If
                p.lust += 5
            Case 5
                p.iArrInd(2) = New Tuple(Of Integer, Boolean)(6, True)
                p.iArrInd(3) = New Tuple(Of Integer, Boolean)(40, True)
                p.iArrInd(8) = New Tuple(Of Integer, Boolean)(9, True)
                Game.pushLblCombatEvent("Your tits expand, your clothes shift, and you feel your will grow weaker. You are now permenantly a cat girl!  Soon you will be Marissa's pet! ")
            Case 6
                p.iArrInd(1) = New Tuple(Of Integer, Boolean)(12, True)
                p.iArrInd(5) = New Tuple(Of Integer, Boolean)(17, True)
                p.iArrInd(15) = New Tuple(Of Integer, Boolean)(1, True)
                p.iArrInd(2) = New Tuple(Of Integer, Boolean)(6, True)
                p.iArrInd(3) = New Tuple(Of Integer, Boolean)(40, True)
                p.iArrInd(8) = New Tuple(Of Integer, Boolean)(9, True)
                p.haircolor = Color.FromArgb(255, 20, 20, 20)
                Game.pushLblCombatEvent("Your hair grows down to your ass, and darkens to a shade of shiny black.  You now have long black hair!  Your tits expand, your clothes shift, and you feel your will grow weaker. You are now a cat girl!  Soon you will be Marissa's pet! ")
            Case 7
                If p.discipline < 5 Then
                    If p.sex = "Male" Then
                        p.MtF()
                        p.be()
                        p.iArrInd(1) = New Tuple(Of Integer, Boolean)(12, True)
                        p.iArrInd(5) = New Tuple(Of Integer, Boolean)(17, True)
                        p.iArrInd(15) = New Tuple(Of Integer, Boolean)(1, True)
                        p.haircolor = Color.FromArgb(255, 20, 20, 20)
                    End If
                    p.iArrInd(1) = New Tuple(Of Integer, Boolean)(12, True)
                    p.iArrInd(5) = New Tuple(Of Integer, Boolean)(17, True)
                    p.iArrInd(15) = New Tuple(Of Integer, Boolean)(1, True)
                    p.iArrInd(2) = New Tuple(Of Integer, Boolean)(6, True)
                    p.iArrInd(3) = New Tuple(Of Integer, Boolean)(40, True)
                    p.iArrInd(8) = New Tuple(Of Integer, Boolean)(9, True)
                    p.haircolor = Color.FromArgb(255, 20, 20, 20)
                End If
                p.title = "Kitty"
                p.be()
                Game.pushLblCombatEvent("As the last of your resistance drains away, all you can find yourself doing is focusing on your new mistress's voice as she orders you down onto all fours.  You happily oblige, purring softly, and she giggles.  ''Come on kitty, lets go!'' she orders and the two of you, with her leading, wander off into the darkness.  GAME OVER!")
                MsgBox(Game.lblCombatEvents.Text)
                p.Die()
                p.perks("nekocurse") = -1
        End Select
    End Sub
    Sub targaxTF(ByRef p As Player, ByVal ind As Integer)
        Select Case ind
            Case 0
                If (p.iArrInd(9).Item2 And p.iArrInd(9).Item1 <> 15) Or (Not p.iArrInd(9).Item2 And p.iArrInd(9).Item1 <> 7) Then
                    If p.iArrInd(9).Item2 Then
                        p.iArrInd(9) = New Tuple(Of Integer, Boolean)(15, True)
                    Else
                        p.iArrInd(9) = New Tuple(Of Integer, Boolean)(7, False)
                    End If
                    Game.pushLblEvent("As you cut down your most recent foe, you take a second to examine the sword you pulled off of Targax.  No doubt, this is one of the most powerful weapons you have seen let alone handled, and as it glints crimson you grin at the potential power you could seize with it.")
                End If
            Case 1
                If (p.iArrInd(15).Item2 And p.iArrInd(15).Item1 <> 18) Or (Not p.iArrInd(15).Item2 And p.iArrInd(15).Item1 <> 7) Then
                    If p.iArrInd(9).Item2 Then
                        p.iArrInd(1) = New Tuple(Of Integer, Boolean)(13, True)
                        p.iArrInd(5) = New Tuple(Of Integer, Boolean)(15, True)
                        p.iArrInd(15) = New Tuple(Of Integer, Boolean)(12, True)
                    Else
                        p.iArrInd(1) = New Tuple(Of Integer, Boolean)(5, False)
                        p.iArrInd(5) = New Tuple(Of Integer, Boolean)(5, False)
                        p.iArrInd(15) = New Tuple(Of Integer, Boolean)(6, False)
                    End If
                    p.haircolor = Color.FromArgb(255, 128, 0, 0)
                    p.title = "Targaxian"
                    Game.pushLblEvent("As another foe meets its demise at your, no, Targax's blade, you have a brief sense of regret that you defeated him.  Who knows what you could have gained from an alliance with him. ''Oh well, back to the slaughter.''")
                End If
            Case 2
                p.name = "Targax"
                p.title = "Soul-Lord"
                Game.pushLblEvent("You jolt out of the trance you've been in for a unknown period of time, and stare in awe at the ornate glyphs that you have apperantly carved in the ground.  ''What the hell did I ...'' when the voice in your head returns, asking ''Do you accept?''.  ''Do I accept what?'' you demand, to which the voice in your head simply repeats the question.  About to firmly decline whatever nonsense your mental passenger is getting at, you are cut short by a thundering ''DO YOU ACCEPT''.  Your eyes space out and you answer your master the only way you can." & vbCrLf & vbCrLf & "''Yes Master.''")
                p.maxHealth = 300
                p.attack = 75
                p.iArrInd(8) = New Tuple(Of Integer, Boolean)(13, True)
                p.sState.save(p)
                p.pState.save(p)
        End Select
    End Sub
    Sub slimeTF(ByRef p As Player, ByVal ind As Integer)
        Select Case ind
            Case 0
                If Game.player.iArrInd(5).Item1 = 7 And Game.player.iArrInd(5).Item2 Then
                    Game.lstLog.Items.Add("Your hair resists being altered!")
                Else
                    Game.player.haircolor = Color.FromArgb(180, 5, 245, 198)
                    Game.player.createP()
                    Game.player.perks("vsslimehair") = 0
                End If
                If Not Game.player.perks("polymorphed") > -1 And Not Game.player.title.Equals("Magic Girl") Then
                    Game.player.pState.save(Game.player)
                End If
        End Select
    End Sub

    Private Sub cboxPMorph_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboxPMorph.SelectedValueChanged
        tfForm = True
    End Sub
End Class