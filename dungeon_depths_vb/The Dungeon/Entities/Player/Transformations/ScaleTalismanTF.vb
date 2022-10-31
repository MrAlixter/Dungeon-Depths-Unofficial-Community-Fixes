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

    '| -- Step 1 -- |
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

    '| -- Step 2 -- |
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
                out += "Your hair shifts in color, becoming brighter!" & DDUtils.RNRN
            Case Mode.heal
                out += "You feel fresher, as though you've been suddenly healed!" & DDUtils.RNRN
            Case Mode.mana
                out += "Your mana flows with a renewed vigor!" & DDUtils.RNRN
            Case Else
                out += "...but nothing happens!" & DDUtils.RNRN
        End Select

        If p.breastSize < 0 Then
            p.breastSize = 0
            If p.perks(perk.dragonboobs) < 0 Then p.perks(perk.dragonboobs) = 1
            out += "Your chest tingles, and your mana reserves seem to have increased slightly." & DDUtils.RNRN
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

    '| -- Step 3 -- |
    Overridable Sub step3Effect(ByRef p As Player, ByVal m As Integer)
        If Not p.knownSpells.Contains("Fotia's Piercing Gaze") Then p.learnSpell("Fotia's Piercing Gaze")

        Select Case m
            Case Mode.tf
                p.prt.setIAInd(pInd.eyes, 43, True, True)
           Case Mode.heal
                p.health += 0.25
            Case Mode.mana
                p.mana += 0.25 * p.getMaxMana
        End Select
    End Sub
    Overridable Sub tfDialogStep3(ByRef p As Player, ByVal m As Integer)
        Dim out = "The red scale dangling around your neck surges with a burst of fiery energy..." & DDUtils.RNRN

        Select Case m
            Case Mode.tf
                out += "Your eyes burn, shifting along with the rest of the transformation..." & DDUtils.RNRN
            Case Mode.heal
                out += "You feel fresher, as though you've been suddenly healed!" & DDUtils.RNRN
            Case Mode.mana
                out += "Your mana flows with a renewed vigor!" & DDUtils.RNRN
            Case Else
                out += "...but nothing happens!" & DDUtils.RNRN
        End Select

        If p.breastSize < 1 Then
            p.breastSize = 1
            If p.perks(perk.dragonboobs) < 0 Then p.perks(perk.dragonboobs) = 1
            out += "Your chest tingles, and your mana reserves seem to have increased slightly." & DDUtils.RNRN
        End If

    
        out += "Another murmur, slightly more understandable this time, emits from the scale." & DDUtils.RNRN &
               """...good- pierce through... shadows of unseen..."""
          
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

    '| -- Step 4 -- |
    Overridable Sub step4Effect(ByRef p As Player, ByVal m As Integer)
        Select Case m
            Case Mode.tf
                p.prt.setIAInd(pInd.rearhair, 39, True, True)
                p.prt.setIAInd(pInd.midhair, 17, True, True)
                p.prt.setIAInd(pInd.fronthair, 31, True, True)
            Case Mode.heal
                p.health += 0.25
            Case Mode.mana
                p.mana += 0.25 * p.getMaxMana
        End Select
    End Sub
    Overridable Sub tfDialogStep4(ByRef p As Player, ByVal m As Integer)
        Dim out = "The red scale dangling around your neck surges with a burst of fiery energy..." & DDUtils.RNRN

        Select Case m
            Case Mode.tf
                out += "Your hair morphs into a new style!" & DDUtils.RNRN
            Case Mode.heal
                out += "You feel fresher, as though you've been suddenly healed!" & DDUtils.RNRN
            Case Mode.mana
                out += "Your mana flows with a renewed vigor!" & DDUtils.RNRN
            Case Else
                out += "...but nothing happens!" & DDUtils.RNRN
        End Select

        If p.breastSize < 3 Then
            p.breastSize += 1
            If p.perks(perk.dragonboobs) < 0 Then p.perks(perk.dragonboobs) = 1
            out += "Your chest tingles, and your mana reserves seem to have increased slightly." & DDUtils.RNRN
        End If

        out += "Another murmur, slightly louder, emits from the scale." & DDUtils.RNRN &
               """...I am... Fotia... YOU... student of... FIRE ---"""

        TextEvent.push(out)

        TextEvent.pushLog("Your " & ScaleTalisman.ITEM_NAME.Replace("_", " ") & " surges with fiery energy!")
    End Sub
    Sub step4()
        Dim p As Player = Game.player1
        Dim m = Mode.none

        If p.health < 0.65 Then
            m = Mode.heal
        ElseIf p.getMana / p.getMaxMana < 0.65 Then
            m = Mode.mana
        Else
            m = Mode.tf
        End If

        step4Effect(p, m)
        tfDialogStep4(p, m)
    End Sub

    '| -- Step 5 -- |
    Overridable Sub step5Effect(ByRef p As Player, ByVal m As Integer)
        Select Case m
            Case Mode.tf
                p.prt.setIAInd(pInd.mouth, 26, True, True)
            Case Mode.heal
                p.health += 0.25
            Case Mode.mana
                p.mana += 0.25 * p.getMaxMana
        End Select
    End Sub
    Overridable Sub tfDialogStep5(ByRef p As Player, ByVal m As Integer)
        Dim out = "The red scale dangling around your neck surges with a burst of fiery energy..." & DDUtils.RNRN

        Select Case m
            Case Mode.tf
                out += "Your teeth sharpen into fangs!" & DDUtils.RNRN
            Case Mode.heal
                out += "You feel fresher, as though you've been suddenly healed!" & DDUtils.RNRN
            Case Mode.mana
                out += "Your mana flows with a renewed vigor!" & DDUtils.RNRN
            Case Else
                out += "...but nothing happens!" & DDUtils.RNRN
        End Select

        If p.breastSize < 1 Then
            p.breastSize = 1
            If p.perks(perk.dragonboobs) < 0 Then p.perks(perk.dragonboobs) = 1
            out += "Your chest tingles, and your mana reserves seem to have increased slightly." & DDUtils.RNRN
        End If


        out += "Another murmur emits from the scale, almost thundering through your mind..." & DDUtils.RNRN &
               """...did- IS FOTIA SLAIN?  DO I SLUMBER ETERNAL?  who- DOEST THOU WALK MY PATH? ---"""

        TextEvent.push(out)

        TextEvent.pushLog("Your " & ScaleTalisman.ITEM_NAME.Replace("_", " ") & " surges with fiery energy!")
    End Sub
    Sub step5()
        Dim p As Player = Game.player1
        Dim m = Mode.none

        If p.health < 0.65 Then
            m = Mode.heal
        ElseIf p.getMana / p.getMaxMana < 0.65 Then
            m = Mode.mana
        Else
            m = Mode.tf
        End If

        step5Effect(p, m)
        tfDialogStep5(p, m)
    End Sub

    '| -- Step 6 -- |
    Overridable Sub step6Effect(ByRef p As Player, ByVal m As Integer)
        Select Case m
            Case Mode.tf
                p.prt.setIAInd(pInd.horns, 4, True, False)
            Case Mode.heal
                p.health += 0.25
            Case Mode.mana
                p.mana += 0.25 * p.getMaxMana
        End Select
    End Sub
    Overridable Sub tfDialogStep6(ByRef p As Player, ByVal m As Integer)
        Dim out = "The red scale dangling around your neck surges with a burst of fiery energy..." & DDUtils.RNRN

        If p.breastSize < 3 Then
            p.breastSize += 1
            If p.perks(perk.dragonboobs) < 0 Then p.perks(perk.dragonboobs) = 1
            out += "Your chest tingles, and your mana reserves seem to have increased slightly." & DDUtils.RNRN
        End If


        out += "Fotia, the dragon spirit contained in the scale talisman, murmurs yet again." & DDUtils.RNRN &
               """--- YESSSS... ALMOST... COMPLETE ---"""

        TextEvent.push(out)

        TextEvent.pushLog("Your " & ScaleTalisman.ITEM_NAME.Replace("_", " ") & " surges with fiery energy!")
    End Sub
    Sub step6()
        Dim p As Player = Game.player1
        Dim m = Mode.none

        If p.health < 0.65 Then
            m = Mode.heal
        ElseIf p.getMana / p.getMaxMana < 0.65 Then
            m = Mode.mana
        Else
            m = Mode.tf
        End If

        step6Effect(p, m)
        tfDialogStep6(p, m)
    End Sub

    '| -- Step 7 -- |
    Overridable Sub tfDialogStep7()
        TextEvent.push(If(Game.player1.inv.getCountAt(Mirror.ITEM_NAME) > 0, "You check your reflection in the mirror you've been carrying around.", "You check your reflection in a nearby pool of water.") & DDUtils.RNRN &
                       "Crimson scales have come to cover much of your body, and a pair of leathery wings adorn your back.  Despite similarities in your body's silhouette, your form has more in common with that of a dragon than that of a human." & DDUtils.RNRN &
                       """--- GO FOURTH, YOUNG ONE.  BURN THIS WORLD TO CINDERS ---"" Fotia chimes from within the charm around your neck, as it flares with another burst of energy." & DDUtils.RNRN &
                       "You are now a Half Dragon!")

        TextEvent.pushLog("You are now a Half Dragon!")
    End Sub
    Overridable Sub step7()
        Dim p As Player = Game.player1

        tfDialogStep7()

        If Not p.knownSpells.Contains("Dragon's Breath") Then p.learnSpell("Dragon's Breath")
        p.prt.setIAInd(pInd.wings, 5, True, False)
        p.changeForm("Half-Dragon (R)")
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        If Not Game.player1.equippedAcce.getAName.Equals(ScaleTalisman.ITEM_NAME) Then Return AddressOf stopTF
        If stage > 6 And Not Game.player1.formName.Equals("Half-Dragon (R)") Then stage = 6

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
                Return AddressOf step1
        End Select
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = 20
        turns_until_next_step += generatWILResistance()
    End Sub
End Class
