Public Class Polymorph
    Public Shared porm As Boolean = True
    Public target As Monster
    Public tfForm As Boolean = False
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'scale to the screen size
        Dim startingWidth = Me.Width
        Dim startingHeight = Me.Height
        If Game.screenSize = "Small" Then
            Size = New Size(Size.Width * 0.8, Size.Height * 0.8)
        ElseIf Game.screenSize = "Medium" Then
            Size = New Size(Size.Width * 0.9, Size.Height * 0.9)
        ElseIf Game.screenSize = "XLarge" Then
            Size = New Size(Size.Width * 1.3, Size.Height * 1.3)
        End If
        Dim RW As Double = (Me.Width - startingWidth) / startingWidth ' Ratio change of width
        Dim RH As Double = (Me.Height - startingHeight) / startingHeight ' Ratio change of height
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * Me.Size.Width / 210))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Font = newFont
            Me.Controls(i).Width += CDbl(Me.Controls(i).Width * RW)
            Me.Controls(i).Height += CDbl(Me.Controls(i).Height * RH)
            Me.Controls(i).Left += CDbl(Me.Controls(i).Left * RW)
            Me.Controls(i).Top += CDbl(Me.Controls(i).Top * RH)
        Next
        Select Case porm
            Case True
                For i = 0 To Game.formList.Count - 1
                    cboxPMorph.Items.Add(Game.formList.Item(i))
                Next
                If cboxPMorph.Items.Contains(Game.player.pClass.name) Then cboxPMorph.Items.Remove(Game.player.pClass.name)
                If cboxPMorph.Items.Contains(Game.player.pForm.name) Then cboxPMorph.Items.Remove(Game.player.pForm.name)
            Case False
                For i = 0 To Game.tFormList.Count - 1
                    cboxPMorph.Items.Add(Game.tFormList.Item(i))
                Next
        End Select
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cboxPMorph.Text = "-- Select --" Or Not tfForm Then
            Me.Close()
            Game.player.mana += 5
            Exit Sub
        End If
        Select Case porm
            Case True
                transform(Game.player, cboxPMorph.Text)
            Case False
                If target.GetType() Is GetType(NPC) Then transformN(target) Else transform(target)
        End Select
        Me.Close()
    End Sub

    'player transform methods
    Sub transform(ByRef p As Player, ByVal form As String)
        If form.Equals(p.pClass.name) Or form.Equals(p.pForm.name) Or Not p.polymorphs.Keys.Contains(form) Then
            Exit Sub
        End If

        'gets the revert text for whatever is being changed
        Dim revertText = ""
        If Not form.Equals(p.pClass.name) Then
            p.pClass.revert()
            revertText = p.pClass.revertPassage & vbCrLf & vbCrLf
        ElseIf Not form.Equals(p.pForm.name) Then
            p.pForm.revert()
            revertText = p.pForm.revertPassage & vbCrLf & vbCrLf
        Else
            MsgBox(form.Equals(p.pClass.name) & " | " & form.Equals(p.pForm.name))
        End If

        'performs the neccisary polymorph
        Dim removeind = New List(Of Integer)
        For i = 0 To p.ongoingTFs.Count - 1
            If p.ongoingTFs(i).GetType().IsSubclassOf(GetType(PolymorphTF)) Then removeind.Add(i)
        Next
        For i = 0 To removeind.Count - 1
            p.ongoingTFs.RemoveAt(removeind(i))
        Next

        p.polymorphs(form) = PolymorphTF.newPoly(form)

        p.ongoingTFs.Add(p.polymorphs(form))
        If p.forms.Keys.Contains(form) Then
            p.pForm = p.forms(form)
        Else
            p.pClass = p.classes(form)
        End If

        'cleanup
        p.perks("polymorphed") = 1

        Game.lblEvent.Text = revertText & Game.lblEvent.Text
        Game.cmboxSpec.Items.Clear()
        Game.specialRoute()
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Public Sub transform(ByRef p As Player, ByVal form As String, ByVal ind As Integer)
        If p.perks("polymorphed") > -1 Then
            Game.lstLog.Items.Add("Your form prevents you from being polymorphed.")
            Exit Sub
        End If
        If form = "slime" Then
            slimeTF(p, ind)
        ElseIf form = "angel" Then
            p.pForm = p.forms("Angel")
            Game.pushLblEvent("As you bite into the cake, you are lost in its sweet flavor.  So lost, in fact, that you miss the large white wings growing on you back.  You are now an angel!")
            p.changeHairColor(Color.FromArgb(255, 245, 231, 184))
            p.iArrInd(1) = New Tuple(Of Integer, Boolean)(5, True)
            p.iArrInd(5) = New Tuple(Of Integer, Boolean)(14, True)
            p.iArrInd(15) = New Tuple(Of Integer, Boolean)(11, True)
            p.wingInd = 1
        ElseIf form = "maid" Then
            Game.pushLblEvent("As you shake the duster, the dust coming off of it seems to glow.  As you take a step back, it whips into a frenzy shrouding you in a radiant cloud.  As the glow dies down, your clothes seem to have become skimpy maid's attire to match the duster, and your hair seems to have become auburn.  Sneezing, you continue on your journey to clean this entire dungeon.")
            Equipment.clothesChange("Maid_Outfit")
            p.pClass = p.classes("Maid")
            p.haircolor = Color.FromArgb(255, 115, 72, 65)
            p.iArrInd(1) = New Tuple(Of Integer, Boolean)(8, True)
            p.iArrInd(5) = New Tuple(Of Integer, Boolean)(8, True)
            p.iArrInd(15) = New Tuple(Of Integer, Boolean)(3, True)
            p.iArrInd(16) = New Tuple(Of Integer, Boolean)(2, True)
        ElseIf form = "princess" Then
            Select Case ind
                Case 0
                    p.pClass = New Unconcious()
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
                    p.pClass = p.classes("Princess")
                    p.changeHairColor(Color.FromArgb(255, 181, 148, 98))
                    p.iArrInd(1) = New Tuple(Of Integer, Boolean)(1, True)
                    p.iArrInd(5) = New Tuple(Of Integer, Boolean)(13, True)
                    p.iArrInd(8) = New Tuple(Of Integer, Boolean)(0, True)
                    p.iArrInd(9) = New Tuple(Of Integer, Boolean)(p.pState.iArrInd(9).Item1, True)
                    p.iArrInd(15) = New Tuple(Of Integer, Boolean)(10, True)
                    p.iArrInd(16) = New Tuple(Of Integer, Boolean)(6, True)

                Case 2
                    Game.pushLblEvent("As you bite into the apple, your mind starts to get foggy.  You yawn, " &
                                                   "and lay down on the floor.  As you nod off, you realize that that apple" &
                                                    " probably was probably either enchanted or poisoned, and as you black out" &
                                                   " your last thought is that this seems like something out of an old fairy " &
                                                   "tail. " & vbCrLf & " " & vbCrLf _
                        & "As you come to, several hours later, you groan and rub your forhead, only to knock a golden crown off of your head. This jolts you up, and you examine yourself further.  Long hair, poofy ballgown, gloves that go up past your elbows?!  Well, it seems like your 'fairy-tail' hunch wasn't too far off after all.  Dusting youself off, you get ready to embark back on your journey to return to your kingdom.  Wait...that isn't why you came here..." & vbCrLf & "Or was it?")
                    Equipment.clothesChange("Regal_Gown")
                    If Not p.sexBool Then
                        p.MtF()
                    End If
                    p.pClass = p.classes("Princess")
                    p.changeHairColor(Color.FromArgb(255, 181, 148, 98))
                    p.iArrInd(1) = New Tuple(Of Integer, Boolean)(1, True)
                    p.iArrInd(5) = New Tuple(Of Integer, Boolean)(13, True)
                    p.iArrInd(8) = New Tuple(Of Integer, Boolean)(0, True)
                    p.iArrInd(9) = New Tuple(Of Integer, Boolean)(p.pState.iArrInd(9).Item1, True)
                    p.iArrInd(15) = New Tuple(Of Integer, Boolean)(10, True)
                    p.iArrInd(16) = New Tuple(Of Integer, Boolean)(6, True)
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
            p.pForm = p.forms("Blowup Doll")
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
        ElseIf form = "Minotaur_F" Then
            minoFTF(p, ind)
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
    Sub transform(ByRef t As Monster, ByVal s As String)
        Dim title As String = s
        If title = "Slime​" Then
            t.health = 150
            t.maxHealth = 150
            t.attack = 10
            t.defence = 15
            t.tfCt = 1
            t.tfEnd = 2
            t.form = "Slime"
        ElseIf title = "Succubus​" Then
            t.health = 125
            t.maxHealth = 125
            t.attack = 20
            t.defence = 5
            t.tfCt = 1
            t.tfEnd = 2
            t.form = "Succubus"
        ElseIf title = "Dragon​" Then
            t.health = 200
            t.maxHealth = 200
            t.attack = 15
            t.defence = 30
            t.tfCt = 1
            t.tfEnd = 2
            t.form = "Dragon"
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
        End Select
    End Sub
    Sub minoFTF(ByRef p As Player, ByVal ind As Integer)
        Select Case ind
            Case 0
                Dim black = Color.FromArgb(255, 50, 50, 50)
                Dim brown = Color.FromArgb(255, 131, 81, 54)
                Dim blonde = Color.FromArgb(255, 248, 189, 90)
                Dim white = Color.FromArgb(255, 249, 249, 249)
                Dim hcs = {black, brown, blonde, white}
                Dim hcn = {"Black", "Brown", "Blonde", "White"}
                Dim i = Int(Rnd() * hcs.Length)
                p.haircolor = hcs(i)
                Game.pushLblEvent("Your foot falls on an uneven patch of dungeon and you breifly lose your footing. As you lurch forward, catching your balance, your cowbell gives out a loud ring.  Looking franctically around, you are relived to see that nothing seems to have been attracted by the noise.  As you brush your shaken up hair back into place, you notice that at some point your hair color had changed to a shade of " & hcn(i) & ".  𝘔𝘢𝘺𝘣𝘦 𝘐 𝘴𝘵𝘦𝘱𝘱𝘦𝘥 𝘰𝘯 𝘢 𝘤𝘶𝘳𝘴𝘦𝘥 𝘣𝘳𝘪𝘤𝘬 𝘰𝘳 𝘴𝘰𝘮𝘦𝘵𝘩𝘪𝘯𝘨, you muse as you continue on." & vbCrLf & vbCrLf & "You now have " & hcn(i) & " hair!")
            Case 1
                p.hornInd = 1
                Game.pushLblEvent("Out of nowhere, you feel the tile beneath you depress slightly.  You instinctively roll left just in time for a projectile to fly through the air where you just to the left.  Breathing a sigh of relief, you take a couple of steps back only to step on another pressure plate.  Another dart fires straight for your neck and without any time to dodge it strikes you right ... in your cowbell.  The ding it lets out is louder than last time, but not by much.  After a nervous scan of your surroundings, you go to readjust your hair again only to find a small pair of horns.  As you size them up, you realize that they give you a slightly bovine appearance.")
            Case 2
                Dim out = "Through the sway of your motion your cowbell rings out quietly, but repeatedly.  After a while of this, you take a rest and check yourself for any changes that may have taken place."
                If p.iArrInd(1).Item2 Then
                    out += "  Looking at your reflection in the nearby pool of water, you see that you now have bovine ears!  Between these and the horns, you're pretty sure you're slowly turning into some sort of cow."
                    p.iArrInd(6) = New Tuple(Of Integer, Boolean)(8, True)
                    p.wBuff -= 1
                Else
                    out += "  You can feel the tickle of hair much further down on your back than you are used to, and a quick glance in a nearby puddle confirms that your hair has lengthened considerably."
                    p.iArrInd(1) = New Tuple(Of Integer, Boolean)(1, True)
                    p.iArrInd(5) = New Tuple(Of Integer, Boolean)(0, True)
                    If Not Int(Rnd() * 3) = 0 Then
                        out += "  Looking at your reflection in the nearby pool of water, you see that you now have bovine ears!  Between these and the horns, you're pretty sure you're slowly turning into some sort of cow."
                        p.iArrInd(6) = New Tuple(Of Integer, Boolean)(8, True)
                        p.equippedAcce.wBoost -= 1
                    End If
                End If
                p.hBuff += 5
                p.health += 5 / p.getmaxHealth
                Game.pushLblEvent(out)
            Case 3
                Dim out = "As you bend down to pick up a dropped item, your cowbell jangles as you stand back up.  Already used to this, you give yourself a quick once over.  You don't see that much different, though your hair seems to have styled itself since you last checked up on it."
                p.iArrInd(1) = New Tuple(Of Integer, Boolean)(16, True)
                p.iArrInd(5) = New Tuple(Of Integer, Boolean)(20, True)
                p.iArrInd(15) = New Tuple(Of Integer, Boolean)(16, True)
                Game.pushLblEvent(out)
            Case 4
                p.hornInd = 2
                Game.pushLblEvent("As you trudge through a particularly dusty patch of dungeon, you feel a powerful sneeze coming on.  As the sneeze rocks your body, the cowbell on your neck rattles noisily, the loudest it has rung yet, and you need to take a few minutes to get your bearings back.  Your head feels slightly heavier, and as you feel around you can tell that your horns have gotten longer, and seem to have a more extreme curl.  Sweet!")
            Case 5 Or 6 Or 7
                Dim out = "Despite being out of the cloud of dust, another small sneeze rattles your bell slightly."
                If Game.player.breastSize = 7 Then
                    out += "  Nothing seems to have happened, and you go on your way."
                ElseIf Game.player.breastSize = -1 Then
                    out += "  Your breasts jiggle a little, and ..." & vbCrLf & vbCrLf & "Wait, BREASTS?!" & vbCrLf & vbCrLf & "You strip off your top and examine your chest and sure enough, you have two small breasts now."
                    Game.player.be()
                Else
                    out += "  Your breasts jiggle a little, and it seems that you've gone up a cup size."
                    Game.player.be()
                End If
                If Not Game.player.sexBool Then
                    If Int(Rnd() * 2) = 0 Then
                        out += "  You also notice that you feel a little ... breathier ... between your legs and a quick pat down confirms that you are now female.  Seems like this bell is turning you into a proper cow after all..."
                        Game.player.MtF()
                    End If
                End If
                Game.pushLblEvent(out)
            Case 8
                Game.pushLblEvent("You take another look at your cowbell.  Every time its rung thus far, you've progressed a little more into some form of bovine-human hybrid.  𝘔𝘪𝘯𝘰𝘵𝘢𝘶𝘳, you correct your self.  It's been turning you into a minotaur, and a female one at that.  Your transformation seems pretty far along, and you'd wager you're only one more chime away from completing the change.  With that in mind, you give the bell a hard shake, and the sound from its ring echos throughout the dungeon." & vbCrLf & vbCrLf & "You are now a female minotaur!")
                Game.player.pForm = p.forms("Minotaur Cow")
                p.inventory(71).add(1)
                Equipment.clothesChange("Cow_Print_Bra")
        End Select
    End Sub

    Shared Sub giveRNDFFName(ByRef p As Player)
        If Game.floor < 5 Then Randomize(Game.floorLayouts(Game.floor).GetHashCode) Else Randomize()
        Dim fFNames() As String = {"Abigail", "Abby", "Anna", "Ann", "Ana", "Alexis", _
                               "Becky", _
                               "Christine", "Casandra", "Catherine", "Cassie", "Carol", "Caroline", "Cara", _
                               "Danica", _
                               "Ellen", "Erika", "Erica", _
                               "Heather", _
                               "Iliona", _
                               "Janice", "Johanna", "Jenna", "Judy", "Jennifer", "Jo-Jo", _
                               "Kerry", "Katherine", "Katja", _
                               "Lana", _
                               "Monica", "Mary", _
                               "Nancy", "Nicole", "Nadja", _
                               "Racheal", _
                               "Samantha", "Sarah", "Sally", _
                               "Tanja", "Trisha", _
                               "Vanessa"}
        p.name = fFNames(Int(Rnd() * fFNames.Length))
    End Sub

    Private Sub cboxPMorph_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboxPMorph.SelectedValueChanged
        tfForm = True
    End Sub
End Class