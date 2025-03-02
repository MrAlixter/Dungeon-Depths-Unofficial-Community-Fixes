Public Class Aliza
    Inherits MiniBoss

    Public Shadows Const BASE_NAME As String = "Aliza, the Dressmaker"

    Protected Shared savedPlayerState As State = Nothing
    Dim turnCounter As Integer = 0
    Dim failedToHypno As Boolean = False

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 666
        attack = 66
        defense = 66
        speed = 666
        will = 666

        '|Inventory|
        inv.setCount(LingerieCatalog.ITEM_NAME, 1)
        inv.setCount(AlizaComb.ITEM_NAME, 1)

        '|Misc|
        setupMonsterOnSpawn()
        maxHealth = 666

        '|Dialog Variables|
        intro_taunt = """Oh, darling... we could do so much with the fabric of your being..."""
        title = " "
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"
    End Sub

    Public Shared Function shouldSpawnAliza(ByRef p As Player) As Boolean
        If p.getWIL < 5 Or p.className.Contains("Bimbo") Then
            Select Case Settings.getSpawnRate(mInd.aliza)
                Case 3
                    Return Not p.passDieRoll(4)
                Case 2
                    Return Not p.passDieRoll(3)
                Case 1
                    Return Not p.passDieRoll(2)
            End Select
        End If

        Return False
    End Function
    Public Shared Sub intro1()
        Game.fromCombat()

        TextEvent.fpush("With a sudden crackle of magic, your foe twists into a slutty pair of panties and falls motionless to the dungeon floor!" & DDUtils.RNRN &
                        "The flap of wings alerts you that another succubus seems to have joined the fray; a powerful spellcaster, going off of how easily she handled the princess.  You leap back to gain some distance, but she seems more interested in her handywork than you at the moment." & DDUtils.RNRN &
                        "As she claims her prize, you find yourself struck by the beauty of this infernal woman.  Her hair falls in perfect, violet ringlets; cascading across her gorgeous face.  Her delicate fingers trail their way up her toned legs as she slides the panties into place, and for a split second you find yourself envious of the princess's fate." & DDUtils.RNRN &
                        "Finally, she turns to you with piercing blue eyes and a malevolent giggle...", AddressOf intro2)
    End Sub
    Public Shared Sub intro2()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(169), """Ooooh... Aren't you a pretty little thing...""" & DDUtils.RNRN &
                                                              "The demoness licks her lips, as she pores over your body with her gaze." & DDUtils.RNRN &
                                                              """I believe you'd do quite nicely to complete my outfit; quite nicely indeed...""" & DDUtils.PAKTC, AddressOf toCombat)
    End Sub
    Public Shared Sub toCombat()
        Dim p As Player = Game.player1
        Dim m As Monster = New Aliza()
        If Not Game.npc_list.Contains(m) Then Game.npc_list.Add(m)

        Game.queueSetup()
        Game.toCombat(m)
        m.currTarget = p
        Game.closeLblEvent()

        If Transformation.canBeTFed(p) AndAlso (savedPlayerState Is Nothing AndAlso p.className.Contains("Bimbo") Or p.breastSize > 1) Then
            p.saveXState(p.currState)
            savedPlayerState = p.currState.clone(p)
        End If

        TextEvent.push("""Oh, darling... we could do so much with the fabric of your being...""")
        TextEvent.pushLog(DDUtils.capitalizeFirst(m.getNameWithTitle) & " approaches!")
    End Sub

    '| - COMBAT - |
    Public Overrides Sub attackCMD(ByRef target As Entity)
        turnCounter += 1

        If Not target.getPlayer Is Nothing Then
            Dim p As Player = target.getPlayer()

            If Transformation.canBeTFed(p) AndAlso ((savedPlayerState Is Nothing AndAlso p.className.Contains("Bimbo") Or p.breastSize > 1) OrElse (Not savedPlayerState Is Nothing AndAlso savedPlayerState.breastSize < p.breastSize)) Then
                p.saveXState(p.currState)
                savedPlayerState = p.currState.clone(p)
            ElseIf Not savedPlayerState Is Nothing AndAlso (savedPlayerState.breastSize > p.breastSize Or (savedPlayerState.pClass.name.Contains("Bimbo") And Not p.className.Contains("Bimbo"))) Then
                System.Threading.Thread.Sleep(100)
                p.revertToState(savedPlayerState)
                TextEvent.fpushAndLog("""No, darling, that's no good...""  Aliza waves her hand, sending you back into a ditzy form.")
                Exit Sub
            End If

            If turnCounter = 1 AndAlso Not p.equippedArmor.getAName().Equals("Naked") AndAlso Not p.equippedArmor.is_sexy AndAlso HypnosisEffect.hypnotize(p, getWIL, h_ind.strip) Then
                TextEvent.fpush("""Now- remove those rags, if you'd be so kind...""")
                TextEvent.pushLog("Aliza hypnotizes you to strip!")

                HypnosisEffect.trigger(p, h_ind.strip)
                p.UIupdate()
                p.drawPort()
                Exit Sub
            End If

            Dim d10 As Integer = Int(Rnd() * 10) + 1

            If (d10 = 5 Or turnCounter = 1) AndAlso HypnosisEffect.hypnotize(p, getWIL, h_ind.wait) Then
                p.nextCombatAction = Sub() HypnosisEffect.trigger(p, h_ind.wait)

                TextEvent.pushAndLog("""Freeze."" Aliza commands, snapping her fingers.")
                Exit Sub
            ElseIf (d10 = 5 Or turnCounter = 1) Then
                TextEvent.pushAndLog("""Freeze."" Aliza commands, snapping her fingers to no effect.")
                failedToHypno = True
                Exit Sub
            End If

            If (d10 < 3 Or failedToHypno) AndAlso Game.mDun.numCurrFloor < 13 Then
                Game.fromCombat()

                Game.quickChangeFloor(13)

                Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(169), "Aliza snaps her fingers, and you find yourself falling through the floor." & DDUtils.RNRN &
                                                                      """Darling, don't worry... you won't be joining my wardrobe today... though I can't promise that you won't be joining someone else's...""" & DDUtils.RNRN &
                                                                      "With a flap of her wings, she vanishes as suddenly as she appeared; leaving you in a strange new place." & DDUtils.PAKTC)

                Exit Sub
            End If

            If d10 > 8 AndAlso p.will > 20 AndAlso Not p.equippedAcce.getAName().Equals(AlizasMark.ITEM_NAME) Then
                If p.inv.getCountAt(AlizasMark.ITEM_NAME) < 1 Then p.inv.add(AlizasMark.ITEM_NAME, 1)
                EquipmentDialogBackend.equipAcce(p, AlizasMark.ITEM_NAME, False)
                p.UIupdate()

                TextEvent.fpush("Aliza snaps her fingers, and you find yourself lightheaded." & DDUtils.RNRN &
                                """You seem smarter than your appearance might suggest... Here, let's rectify that...""")
                Exit Sub
            ElseIf d10 > 8 AndAlso p.will > 20 Then
                TextEvent.fpush("Aliza snaps her fingers, to no effect." & DDUtils.RNRN &
                               """You seem smarter than your appearance might suggest... Here, let's rectify that...""")
                failedToHypno = True
                Exit Sub
            End If

            If d10 = 6 AndAlso HypnosisEffect.hypnotize(p, getWIL, h_ind.bimbokiss) Then
                Game.fromCombat()

                Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(169), "Aliza snaps her fingers, and you find yourself spiraling away into a mindless trance." & DDUtils.RNRN &
                                                                      "*SNAP*" & DDUtils.RNRN &
                                                                      """Darling, don't worry... you won't be joining my wardrobe today.  To show that there's no hard feelings, why don't you go buy yourself something nice?""" & DDUtils.RNRN &
                                                                      "+150 Gold" & DDUtils.PAKTC)
                p.gold += 150
                p.UIupdate()
                Exit Sub
            ElseIf d10 = 6 Then
                Game.fromCombat()

                TextEvent.fpush("Aliza snaps her fingers, to no effect." & DDUtils.RNRN &
                                """Darling, don't worry... you won't be joining my wardrobe today.  To show that... there's... wait... why didn't that work?""" & DDUtils.RNRN &
                                "You shrug, before raising your fist to menace your opponent.  Despite " & p_pronoun & " grumbling, you snatch everything of value on the demoness's person." & DDUtils.RNRN &
                                "+1666 Gold" & vbCrLf & "+1 " & GlitteryDress.ITEM_NAME & vbCrLf & "+1 " & ScarletComb.ITEM_NAME & vbCrLf & "+1 " & KestrelKnife.ITEM_NAME & DDUtils.PAKTC)
                p.gold += 1666
                p.inv.add(GlitteryDress.ITEM_NAME, 1)
                p.inv.add(AlizaComb.ITEM_NAME, 1)
                p.inv.add(KestrelKnife.ITEM_NAME, 1)

                p.UIupdate()
                Exit Sub
            End If
        End If

        attackSpell(target, "a crackling surge of black lightning", getATK)
    End Sub
    Public Overrides Function reactToSpell(spell As String) As Boolean
        If spell.Contains("Polymorph") Or spell.Contains("Turn to") Or spell.Contains("Petrify") Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " waves her hand " & r_pronoun & ", dispelling your spell!")
            Return False
        End If

        Return True
    End Function

    '| - DEATH - |
    Public Overrides Sub die(ByRef cause As Entity)
        If cause.GetType() Is GetType(Player) Then
            Dim p = CType(cause, Player)

            If p.perks(perk.cynnsq1ct1) > -1 Then p.perks(perk.cynnsq1ct1) += 1

            If p.perks(perk.succubuscurse) > -1 Then

                Dim isPTFed = p.perks(perk.succubuscurse) > 0

                p.perks(perk.succubuscurse) = -1

                TextEvent.pushLog("The succubus's curse is lifted!")
                TextEvent.push(If(isPTFed, "The succubus's curse is lifted!  However, this does not revert your transformation...", "The succubus's curse is lifted!"))
            End If
        End If

        MyBase.die(cause)
    End Sub
    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        p.changeClass("Bustier")
        p.UIupdate()
        p.drawPort()

        TextEvent.fpush("With a final crackle of power, you fall under Aliza's spell." & DDUtils.RNRN &
                        "Your shape is woven anew in an instant; and you collapse into a pile of soft fabric and slender lace." & DDUtils.RNRN &
                        "The demoness picks up your silken form delicately, and slides you across her chest.  You feel her tits squeeze against your new form, as everything else begins to fade away.", AddressOf playerDeath2)
    End Sub
    Public Shared Sub playerDeath2()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(170), """How very supportive...""" & DDUtils.RNRN &
                                                              "GAME OVER!", AddressOf DeathEffects.hardDeath)
    End Sub
End Class
