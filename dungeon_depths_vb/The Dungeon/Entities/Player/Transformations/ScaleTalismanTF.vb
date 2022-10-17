Public Class ScaleTalismanTF
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.scaletalisman

    Protected Friend Enum Mode
        tf
        heal
        mana
        none
    End Enum

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tf_name = TF_IND
        MyBase.update_during_combat = False
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.update_during_combat = False
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Overridable Sub step1Effect(ByRef p As Player, ByVal m As Integer)
        Select Case m
            Case MODE.tf
                p.prt.changeHairColor(DDUtils.cShift(p.prt.haircolor, Color.White, 40))
            Case MODE.heal
                p.health += 0.25
            Case MODE.mana
                p.mana += 0.25 * p.getMaxMana
        End Select
    End Sub
    Overridable Sub tfDialogStep1(ByRef p As Player, ByVal m As Integer)
        Dim out = "The red scale dangling around your neck surges with a burst of fiery energy..." & DDUtils.RNRN

        Select Case m
            Case MODE.tf
                out += "Your hair shifts in color, becoming brighter!"
            Case MODE.heal
                out += "You feel fresher, as though you've been suddenly healed!"
            Case MODE.mana
                out += "Your mana flows with a renewed vigor!"
            Case Else
                out += "...but nothing happens!"
        End Select

        TextEvent.push(out)
        TextEvent.pushLog("Your " & ScaleTalisman.ITEM_NAME.Replace("_", " ") & " surges with fiery energy!")
    End Sub
    Sub step1()
        Dim p As Player = Game.player1
        Dim m = Mode.none

        If p.health < 0.65 Then
            m = Mode.heal
        ElseIf p.getMana / p.getMaxMana < 0.65 Then
            m = Mode.mana
        Else
            m = Mode.tf
        End If

        step1Effect(p, m)
        tfDialogStep1(p, m)
    End Sub

    Overridable Sub step2Effect(ByRef p As Player, ByVal m As Integer)
        Select Case m
            Case Mode.tf
                p.prt.changeHairColor(DDUtils.cShift(p.prt.haircolor, Color.White, 100))
            Case Mode.heal
                p.health += 0.25
            Case Mode.mana
                p.mana += 0.25 * p.getMaxMana
        End Select
    End Sub
    Overridable Sub tfDialogStep2(ByRef p As Player, ByVal m As Integer)
        Dim out = "The red scale dangling around your neck surges with a burst of fiery energy..." & DDUtils.RNRN

        Select Case m
            Case Mode.tf
                out += "Your hair shifts in color, becoming brighter!"
            Case Mode.heal
                out += "You feel fresher, as though you've been suddenly healed!"
            Case Mode.mana
                out += "Your mana flows with a renewed vigor!"
            Case Else
                out += "...but nothing happens!"
        End Select

        If p.breastSize < 0 Then
            p.breastSize = 0
            If p.perks(perk.dragonboobs) < 0 Then p.perks(perk.dragonboobs) = 1
            out += DDUtils.RNRN & "Your chest tingles, and your mana reserves seem to have increased slightly."
        End If

        TextEvent.push(out & DDUtils.RNRN &
                       "Patches of tiny crimson scales dot your forearms, and an almost unintelligible murmur seeps from the talisman." & DDUtils.RNRN &
                       """...magnificent- beginning...""")
        TextEvent.pushLog("Your " & ScaleTalisman.ITEM_NAME.Replace("_", " ") & " surges with fiery energy!")
    End Sub
    Sub step2()
        Dim p As Player = Game.player1
        Dim m = Mode.none

        If p.health < 0.65 Then
            m = Mode.heal
        ElseIf p.getMana / p.getMaxMana < 0.65 Then
            m = Mode.mana
        Else
            m = Mode.tf
        End If

        step2Effect(p, m)
        tfDialogStep2(p, m)
    End Sub

    Overridable Sub step3Effect(ByRef p As Player, ByVal m As Integer)
        Select Case m
            Case Mode.tf
                If Not p.knownSpells.Contains("Fotia's Piercing Gaze") Then p.knownSpells.Add("Fotia's Piercing Gaze") : TextEvent.pushLog("""Fotia's Piercing Gaze"" spell learned!")
                p.prt.setIAInd(pInd.eyes, 43, True, True)
            Case Mode.heal
                If Not p.knownSpecials.Contains("Inferno Aura") Then p.knownSpecials.Add("Inferno Aura") : TextEvent.pushLog("""Inferno Aura"" special learned!")
            Case Mode.mana
                If Not p.knownSpells.Contains("Fotia's Piercing Gaze") Then p.knownSpells.Add("Fotia's Piercing Gaze") : TextEvent.pushLog("""Fotia's Piercing Gaze"" spell learned!")
        End Select
    End Sub
    Overridable Sub tfDialogStep3(ByRef p As Player, ByVal m As Integer)
        Dim out = "The red scale dangling around your neck surges with a burst of fiery energy..." & DDUtils.RNRN

        If p.breastSize < 1 Then
            p.breastSize = 1
            If p.perks(perk.dragonboobs) < 0 Then p.perks(perk.dragonboobs) = 1
            out += "Your chest tingles, and your mana reserves seem to have increased slightly." & DDUtils.RNRN
        End If

        Select Case m
            Case Mode.tf
                out += "Another murmur, slightly more understandable this time, emits from the scale." & DDUtils.RNRN &
                     """...good- pierce through... shadows of unseen..."""
            Case Mode.heal
                out += "Another murmur, slightly more understandable this time, emits from the scale." & DDUtils.RNRN &
                       """...need to stay- keep... survive..."""
            Case Mode.mana
                out += "Another murmur, slightly more understandable this time, emits from the scale." & DDUtils.RNRN &
                    """...need to gain- steal... mana..."""
            Case Else
                out += "...but nothing happens!"
        End Select

        TextEvent.push(out)

        TextEvent.pushLog("Your " & ScaleTalisman.ITEM_NAME.Replace("_", " ") & " surges with fiery energy!")
    End Sub
    Sub step3()
        Dim p As Player = Game.player1
        Dim m = Mode.none

        If p.health < 0.65 Then
            m = Mode.heal
        ElseIf p.getMana / p.getMaxMana < 0.65 Then
            m = Mode.mana
        Else
            m = Mode.tf
        End If

        step3Effect(p, m)
        tfDialogStep3(p, m)
    End Sub

    Overridable Function dropEWeapon(ByRef p As Player) As Boolean
        If p.className.Equals("Magical Girl") Or p.className.Equals("Valkyrie") Then
            EquipmentDialogBackend.weaponChange(p, "Fists")
            Return True
        End If
        Return False
    End Function
    Overridable Sub hairTF2(ByRef p As Player)
        p.prt.setIAInd(pInd.rearhair, 12, True, True)
        p.prt.setIAInd(pInd.midhair, 21, True, True)
    End Sub
    Overridable Sub tfDialogStep4(ByVal dropItem As Boolean)
        Dim out = "As you bend down to pick up a dropped item, your cowbell jangles as you stand back up." & DDUtils.RNRN &
                  "Already used to this, you give yourself a quick once over.  You don't see that much different, though your hair seems to have styled itself since you last checked up on it."

        If dropItem Then
            out += DDUtils.RNRN & "You lose hold of your weapon, dropping it and reverting your transformation."
        End If

        TextEvent.push(out)
    End Sub
    Overridable Sub step4()
        Dim p As Player = Game.player1

        Dim dropItem = dropEWeapon(p)

        hairTF2(p)

        tfDialogStep4(dropItem)
    End Sub

    Overridable Sub growHorns(ByRef p As Player)
        p.prt.setIAInd(pInd.horns, 4, True, False)
    End Sub
    Overridable Sub tfDialogStep5()
        TextEvent.push("As you trudge through a particularly dusty patch of dungeon, you feel a powerful sneeze coming on." & DDUtils.RNRN &
                          """Achoo!"" the sneeze rocks your body, causing the cowbell on your neck to rattle noisily.  That had to be the loudest it has rung yet, and you need to take a few minutes to get your bearings back." & DDUtils.RNRN &
                          "Your head feels slightly heavier, and as you feel around your head you can tell that your horns have both gotten longer and developed a more extreme curl." & DDUtils.RNRN &
                          "Sweet!")
    End Sub
    Sub step5()
        Dim p As Player = Game.player1
        growHorns(p)
        tfDialogStep5()
    End Sub

    Overridable Sub boobTF(ByRef p As Player)
        p.breastSize += 1
        p.maxMana += 5
    End Sub
    Overridable Sub tfDialogStep678(ByVal bsize3 As Boolean, ByVal bsizeneg1 As Boolean, ByVal be As Boolean, ByVal mtf As Boolean)
        Dim out = "Despite being out of the cloud of dust, another small sneeze rattles your bell slightly."

        If bsize3 Then
            out += "  Nothing seems to have happened, and you go on your way."
        End If

        If bsizeneg1 Then
            out += "  Your breasts jiggle a little, and ..." & DDUtils.RNRN & "Wait, BREASTS?!" & DDUtils.RNRN & "You strip off your top and examine your chest and sure enough, you have two small breasts now."
        End If

        If be Then
            out += "  Your breasts jiggle a little, and it seems that you've gone up a cup size."
        End If

        If mtf Then
            out += "  You also notice that you feel a little... breathier... between your legs and a quick pat down confirms that you are now female..."
        End If

        TextEvent.push(out)
    End Sub
    Overridable Sub step678()
        Dim p As Player = Game.player1
        Dim bsize3 As Boolean = False
        Dim bsizeneg1 As Boolean = False
        Dim be As Boolean = False
        Dim mtf As Boolean = False

        If p.breastSize = 3 Then
            bsize3 = True
        ElseIf p.breastSize = -1 Then
            boobTF(p)
            bsizeneg1 = True
        Else
            If p.breastSize < 3 Then
                boobTF(p)
            End If
            be = True
        End If
        If Not p.prt.sexBool Then
            If Int(Rnd() * 2) = 0 Then
                Game.player1.MtF()
                mtf = True
            End If
        End If

        tfDialogStep678(bsize3, bsizeneg1, be, mtf)
    End Sub

    Overridable Sub tfClothes(ByRef p As Player)
        EquipmentDialogBackend.armorChange(p, "Naked")
    End Sub
    Overridable Sub tfDialogStep9()
        TextEvent.push(If(Game.player1.inv.getCountAt(Mirror.ITEM_NAME) > 0, "You check your reflection in the mirror you've been carrying around.", "You check your reflection in a nearby pool of water.") & DDUtils.RNRN &
                       "" & DDUtils.RNRN &
                       """--- GO FOURTH, YOUNG ONE.  YOU " & DDUtils.RNRN &
                       "You are now a Half Dragon!")
    End Sub
    Overridable Sub step9()
        Dim p As Player = Game.player1

        tfDialogStep9()

        p.changeForm("Half-Dragon (R)")

        tfClothes(p)
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        If Not Game.player1.equippedAcce.getAName.Equals(ScaleTalisman.ITEM_NAME) Then Return AddressOf stopTF

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
            Case 5, 6, 7
                Return AddressOf step678
            Case 8
                Return AddressOf step9
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = 10
        turns_until_next_step += generatWILResistance()
    End Sub
End Class
