Public Class FaeQueen
    Inherits ShopNPC

    Public Const DIALOG_OPTION_1 = "Introduce yourself"
    Public Const DIALOG_OPTION_2 = "Introduce yourself by a fake name"
    Public Const DIALOG_OPTION_3 = """... Who are you?"""
    Public Const DIALOG_OPTION_4 = """I'm the one who's going to kill you."""

    Private Shared selected_tree = -1

    Private firstCombat = True
    Private deducedName As String = ""
    Private testedName As Boolean = False

    Sub New()
        MyBase.New()

        '|ID Info|
        name = "Fae Queen"
        sName = name
        npc_index = ShopNPCInd.faequeen

        '|NPC Flags|
        title = "the "
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"
        isShop = True

        '|Inventory|
        inv.setCount(FaeQueenAmulet.ITEM_NAME, 1)
        inv.setCount(FaeQueensCrown.ITEM_NAME, 1)
        inv.setCount(LingerieCatalog.ITEM_NAME, 1)
        inv.setCount(Tulip.ITEM_NAME, 13)

        '|Stats|
        maxHealth = 13000
        attack = 13
        defense = 13
        speed = 13000
        will = 13000
        gold = 7130

        xp_value = (maxHealth + attack + defense + speed) / 4
        sMaxHealth = maxHealth
        sMaxMana = maxMana
        sAttack = attack
        sdefense = defense
        sWill = will
        sSpeed = speed
        firstCTurn = False

        '|Images|
        local_img = New Dictionary(Of ShopNPC.LocalImgInd, Image)()

        local_img.Add(LocalImgInd.normal, ShopNPC.gbl_img.atrs(0).getAt(107))
        local_img.Add(LocalImgInd.frog, ShopNPC.gbl_img.atrs(0).getAt(4))
        local_img.Add(LocalImgInd.sheep, ShopNPC.gbl_img.atrs(0).getAt(5))
        local_img.Add(LocalImgInd.trilobite, ShopNPC.gbl_img.atrs(0).getAt(96))
        local_img.Add(LocalImgInd.beegirl, ShopNPC.gbl_img.atrs(0).getAt(148))
        local_img.Add(LocalImgInd.alt1, ShopNPC.gbl_img.atrs(0).getAt(108))
        local_img.Add(LocalImgInd.alt2, ShopNPC.gbl_img.atrs(0).getAt(109))
        local_img.Add(LocalImgInd.alt3, ShopNPC.gbl_img.atrs(0).getAt(110))
    End Sub

    Public Shared Sub spawn(ByRef floor As mFloor)
        Dim points As Point() = {New Point(4, 29), New Point(7, 29), New Point(8, 29), New Point(9, 29), New Point(10, 29),
                                 New Point(11, 29), New Point(12, 29), New Point(13, 29), New Point(14, 29), New Point(15, 29),
                                 New Point(4, 29), New Point(4, 28), New Point(4, 27), New Point(4, 30), New Point(4, 31),
                                 New Point(10, 29), New Point(10, 28), New Point(10, 27), New Point(10, 30), New Point(10, 31),
                                 New Point(5, 26), New Point(6, 26), New Point(7, 26), New Point(8, 26), New Point(9, 26),
                                 New Point(5, 32), New Point(6, 32), New Point(7, 32), New Point(8, 32), New Point(9, 32),
                                 New Point(5, 27), New Point(5, 31), New Point(9, 27), New Point(9, 31)}

        floor.addNPC(Game.fqueen, New Point(7, 29))

        For Each p In points
            floor.mBoard(p.Y, p.X).Tag = 2
        Next
    End Sub
    Public Shared Sub spawnStairs(ByRef floor As mFloor)
        Dim points As Point() = {New Point(46, 14), New Point(47, 14), New Point(48, 14),
                                 New Point(49, 14), New Point(50, 14), New Point(51, 14),
                                 New Point(52, 14), New Point(53, 14), New Point(54, 14),
                                 New Point(52, 13), New Point(53, 13), New Point(54, 13),
                                 New Point(52, 15), New Point(53, 15), New Point(54, 15)}

        For Each p In points
            floor.mBoard(p.Y, p.X).Tag = 2
        Next
    End Sub
    Public Shared Sub spawnFountain(ByRef floor As mFloor)
        Dim points As Point() = {New Point(24, 37), New Point(23, 38), New Point(24, 38), New Point(25, 38), New Point(24, 39)}

        For Each p In points
            floor.mBoard(p.Y, p.X).Text = "\"
        Next

        Game.player1.pos = New Point(24, 38)
    End Sub

    Public Overrides Function fleeFromAnimalTF() As Boolean
        Return False
    End Function
    Public Overrides Sub encounter()
        npc_index = 0
        Game.shop_npc_engaged = False
        Game.active_shop_npc = Nothing
        Game.btnEQP.Enabled = True
        Game.npc_list.Clear()
        Game.player1.canMoveFlag = True
        Game.btnTalk.Visible = False
        Game.btnNPCMG.Visible = False
        Game.cboxNPCMG.Visible = False
        Game.btnShop.Visible = False
        Game.btnFight.Visible = False
        Game.btnLeave.Visible = False

        Game.picBoard.Select()

        If Game.player1.perks(perk.faecurse) > -1 And Game.player1.perks(perk.f13fqueentalked) > 0 Then
            Objective.showNPC(local_img(LocalImgInd.normal), """You again, outstanding...  Must I do everything myself?""" & DDUtils.PAKTC, AddressOf toCombat)
        ElseIf Game.player1.perks(perk.faecurse) > -1 Then
            Objective.showNPC(local_img(LocalImgInd.normal), """Oh, hello...  Who do we have here?""" & DDUtils.PAKTC, AddressOf faeCursedInitialResponse)
        ElseIf Game.player1.perks(perk.f13fqueentalked) > 0 And Game.currFloor.mBoard(Game.currFloor.stairs.Y, Game.currFloor.stairs.X).Tag = 2 Then
            Objective.showNPC(local_img(LocalImgInd.normal), "Hello again...")
        Else
            Objective.showNPC(local_img(LocalImgInd.normal), """Well, well, well...  Who do we have here?""" & DDUtils.PAKTC, AddressOf selectInitialResponse)
        End If
    End Sub
    Public Overrides Sub despawn(reason As String)
        MyBase.despawn(reason)

        Game.currFloor.mBoard(29, 9).Tag = 2
    End Sub

    '| - QUESTIONS - |
    Private Sub selectInitialResponse()
        Dim d1 = New Tuple(Of String, Action)(FaeQueen.DIALOG_OPTION_1, AddressOf FaeQueen.dialogTree1)
        Dim d2 = New Tuple(Of String, Action)(FaeQueen.DIALOG_OPTION_2, AddressOf FaeQueen.dialogTree2)
        Dim d3 = New Tuple(Of String, Action)(FaeQueen.DIALOG_OPTION_3, AddressOf FaeQueen.dialogTree3)
        Dim d4 = New Tuple(Of String, Action)(FaeQueen.DIALOG_OPTION_4, AddressOf FaeQueen.dialogTree4)
        TextEvent.pushManySelect("Who does she have here?", d1, d2, d3, d4)

        Game.currFloor.mBoard(29, 9).Tag = 2
    End Sub
    Private Shared Sub giveRealName()
        TextEvent.pushYesNo("Give the Fae Queen your real name?", AddressOf dialogTree1alt, AddressOf canYouBeTrusted)
    End Sub
    Private Shared Sub canYouBeTrusted()
        TextEvent.pushYesNo("Can you be trusted?", AddressOf fakeNameCanBeTrusted, AddressOf fakeNameCannotBeTrusted)
    End Sub

    Private Sub faeCursedInitialResponse()
        Game.player1.perks(perk.f13fqueentalked) = 1
        TextEvent.push("You think about the question for a few seconds, before a presence overtakes you and you blurt out ""Death to the Fae Queen!""" & DDUtils.RNRN &
                       "A twinkling mist seeps out from your mouth as you launch into a barrage of insults, the Fae Queen simply standing by with one eyebrow raised.  Eventually, she cuts you off with a hand motion and you find yourself unable to speak." & DDUtils.RNRN &
                       """SILENCE!"" decrees the Fae Queen, ""I don't very much care for your prattle.  In fact...""", AddressOf faeCursedToCombat)
    End Sub

    '| - RESPONSES - |
    Public Overrides Function hitBySpell() As String
        Return """Well, well, well...  Who do we have here?"""
    End Function
    Public Overrides Function toFight() As String
        Return """Well, well, well...  Who do we have here?"""
    End Function
    Public Shared Sub dialogTree1()
        Dim p = Game.player1

        TextEvent.push("""Oh, is that so?  You know, '" & p.name & "', I think you'd make a wonderful faerie.  Much better to be one of my subjects than some lumbering " & p.formName & ", wouldn't you say?""" & DDUtils.RNRN &
                       "As she speaks, you notice that it seems like either everything else is moving upwards or that you're moving downwards.  Before you can even react, you've shruken to a fraction of your former height!" & DDUtils.RNRN &
                       "You flit up from the pile of now-too-big gear lying on the floor around you, and pout back at the royal figure that now looms menacingly over you..." & DDUtils.RNRN &
                       "You are a Faerie!", AddressOf fakeCurse1)

        EquipmentDialogBackend.equipArmor(p, "Naked", False)
        EquipmentDialogBackend.equipWeapon(p, "Fists", False)
        EquipmentDialogBackend.equipAcce(p, "Nothing", False)
        EquipmentDialogBackend.equipGlasses(p, "Nothing", False)

        p.ongoingTFs.add(New FaerieTF())
        p.update()

        selected_tree = 1
    End Sub
    Public Shared Sub dialogTree2()
        Dim p = Game.player1

        Dim fakename = If(p.name.Equals("Alex"), "Schmalex", "Alex")

        TextEvent.push("""Oh, is that so?  You know, '" & fakename & "', I think you'd make a wonderful faerie.  Much better to be one of my subjects than some lumbering " & p.formName & ", wouldn't you say?""" & DDUtils.RNRN &
                       "As she speaks, you notice that it seems like nothing out of the ordinary is happening.  The two of you stand silently for a moment before you cough awkwardly and the fae continues," & DDUtils.RNRN &
                       """A fake name, then?  Well, I suppose that is to be expected...""", AddressOf fakeName1)

        selected_tree = 2
    End Sub
    Public Shared Sub dialogTree3()
        TextEvent.push("The fae queen's smile falters." & DDUtils.RNRN &
                       """Who... am I?" & DDUtils.RNRN &
                       "What a rude response to my question, and not even close to an answer..." & DDUtils.RNRN &
                       "Who am I, " & Game.player1.formName & "?  Whose domain do you think your grubby little feet have been trodding all over?""" & DDUtils.RNRN &
                       "The air around you bristles with pale green sparks, and you ready your weapons for a fight.", AddressOf trueCurse)

        selected_tree = 3
    End Sub
    Public Shared Sub dialogTree4()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(107), """Oh, is that so?  Well then, by all means, let's see you try...""" & DDUtils.PAKTC, AddressOf toCombat)

        selected_tree = 4
        Game.player1.perks(perk.f13fqueentalked) = 4
    End Sub
    Public Shared Sub playerLeaves()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(108), """Are you ignoring me?  Hmm, how rude...""" & DDUtils.PAKTC)

        Game.player1.canMoveFlag = True

        Game.currFloor.mBoard(29, 9).Tag = 0
        Game.drawBoard()
    End Sub

    '| - STORY PROGRESSION - |
    Private Shared Sub fakeCurse1()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(107), "Ah, so that was your real name...  Well, I suppose I can't fault you for honesty." & DDUtils.RNRN &
                                                             "Your naiveity, on the other hand, may prove useful to me yet...", AddressOf fakeCurse2)
    End Sub
    Private Shared Sub fakeCurse2()
        Game.player1.revertToPState()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(108), "With a wave of her hand, and a plume of glittery dust, the fae returns you to your original form." & DDUtils.RNRN &
                                                             """It can be so hard to find someone- particularly an outsider- that I can trust.  But I know I can trust you, " & Game.player1.name & "." & DDUtils.RNRN &
                                                             "I have your name, after all, and names have such power, now don't they?""", AddressOf fakeCurse3)
    End Sub
    Private Shared Sub fakeCurse3()
        TextEvent.push("The Fae Queen hands you a gilded amulet with the image of a rose on it." & DDUtils.RNRN &
                       """See yourself out, and safe travels!""" & DDUtils.RNRN &
                       "+1 Fae Queen's Talisman")

        Game.player1.inv.add(FaeQueenAmulet.ITEM_NAME, 1)

        spawnStairs(Game.currFloor)

        Dim path = Game.currFloor.route(Game.fqueen.pos, Game.currFloor.stairs)

        For i = 0 To UBound(path) Step 4
            Game.currFloor.mBoard(path(i).Y, path(i).X).Tag = 2
            If Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "" Then Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "x"
        Next

        Game.player1.perks(perk.f13fqueentalked) = 1

        Game.drawBoard()
    End Sub

    Private Shared Sub fakeName1()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(108), "Still though, I cannot allow a lying outsider to run rampant through my realm." & DDUtils.RNRN &
                                                             "Choose your next words carefully, because if you aren't the trustworthy type..." & DDUtils.RNRN &
                                                             "Well, we can always change that, now can't we?", AddressOf giveRealName)
    End Sub
    Public Shared Sub dialogTree1alt()
        Dim p = Game.player1

        TextEvent.push("""Is that so?  You know, '" & p.name & "', I think you'd make a wonderful faerie.""" & DDUtils.RNRN &
                       "As she speaks, you notice that it seems like either everything else is moving upwards or that you're moving downwards.  Before you can even react, you've shruken to a fraction of your former height!" & DDUtils.RNRN &
                       "You flit up from the pile of now-too-big gear lying on the floor around you, and pout back at the royal figure that now looms menacingly over you..." & DDUtils.RNRN &
                       "You are a Faerie!", AddressOf fakeCurse1alt)

        EquipmentDialogBackend.equipArmor(p, "Naked", False)
        EquipmentDialogBackend.equipWeapon(p, "Fists", False)
        EquipmentDialogBackend.equipAcce(p, "Nothing", False)
        EquipmentDialogBackend.equipGlasses(p, "Nothing", False)

        p.ongoingTFs.add(New FaerieTF())
        p.update()
    End Sub
    Private Shared Sub fakeCurse1alt()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(107), "Ah, so that was your real name...  Well, I suppose I can't fault you for being cautious." & DDUtils.RNRN &
                                                             "Your shrewdness may actually prove useful to me yet...", AddressOf fakeCurse2)
    End Sub
    Private Shared Sub fakeNameCanBeTrusted()
        Dim fakename = If(Game.player1.name.Equals("Alex"), "Schmalex", "Alex")

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(109), """See, you say that, '" & fakename & "'...""" & DDUtils.RNRN &
                                                             "With the flick of a finger, she directs a ball of dark energy straight at you." & DDUtils.RNRN &
                                                             """...but we both know that it isn't true.  You've already lied to me once, now twice.  It will not happen again.""" & DDUtils.RNRN &
                                                             "Without time to dodge, all you can do is raise a makeshift arcane barrier that is quickly swallowed by the spell, along with your remaining MP." & DDUtils.RNRN &
                                                             "The Fae Queen's black magic engulfs you!", AddressOf fakeNameEnd)
        Game.player1.setMana(0)
        Game.player1.UIupdate()
    End Sub
    Private Shared Sub fakeNameCannotBeTrusted()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(107), "Fair enough.  You probably shouldn't trust me either." & DDUtils.RNRN &
                                                             "Now you've got me curious though, which means we get to do this the fun way...", AddressOf toCombat)
    End Sub
    Private Shared Sub fakeNameEnd()
        Dim p = Game.player1

        p.perks(perk.faequestatue) = 1

        EquipmentDialogBackend.equipArmor(p, "Naked", False)
        EquipmentDialogBackend.equipWeapon(p, "Fists", False)
        EquipmentDialogBackend.equipAcce(p, "Nothing", False)
        EquipmentDialogBackend.equipGlasses(p, "Nothing", False)

        p.changeForm("Faerie")

        p.prt.setIAInd(pInd.ears, 3, p.prt.iArrInd(pInd.ears).Item2, False)
        p.prt.setIAInd(pInd.wings, 10, True, False)
        If p.breastSize > 2 Then p.breastSize = 2
        If p.breastSize < 0 Then p.breastSize = 0
        If p.buttSize > 2 Then p.buttSize = 2
        If p.buttSize < 0 Then p.buttSize = 0
        p.petrify(Color.FromArgb(255, 195, 195, 195), 99999999)

        p.prt.setIAInd(pInd.hat, 23, True, True)
        p.prt.setIAInd(pInd.mouth, 33, True, True)
        p.drawPort()

        spawnFountain(Game.currFloor)
        Game.drawBoard()

        TextEvent.push("Weeks pass, and a familiar faerie comes across the Fae Queen's newest fountain...", AddressOf fakeNameEnd2)
    End Sub
    Private Shared Sub fakeNameEnd2()
        Game.player1.perks(perk.f13fqueentalked) = 2
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(57), """What the hell...""" & DDUtils.RNRN &
                                                            "GAME OVER!", AddressOf Game.player1.die)
    End Sub

    Private Shared Sub trueCurse()
        TextEvent.push("Bolts of verdant energy arc around you, coiling and crackling." & DDUtils.RNRN &
                       """Unbelievable.  If you intend to trapse about my woods, perhaps you should know your place...""" & DDUtils.RNRN &
                       "With a blinding flash, you find yourself back out in the mist.")

        Game.player1.addLust(16)
        FaerieTF.step1alt(Game.player1)
        Game.player1.pos = Game.currFloor.randPoint()
        Dim points As Point() = {New Point(4, 29), New Point(7, 29), New Point(8, 29), New Point(9, 29), New Point(10, 29),
                          New Point(11, 29), New Point(12, 29), New Point(13, 29), New Point(14, 29), New Point(15, 29),
                          New Point(4, 29), New Point(4, 28), New Point(4, 27), New Point(4, 30), New Point(4, 31),
                          New Point(10, 29), New Point(10, 28), New Point(10, 27), New Point(10, 30), New Point(10, 31),
                          New Point(5, 26), New Point(6, 26), New Point(7, 26), New Point(8, 26), New Point(9, 26),
                          New Point(5, 32), New Point(6, 32), New Point(7, 32), New Point(8, 32), New Point(9, 32),
                          New Point(5, 27), New Point(5, 31), New Point(9, 27), New Point(9, 31)}

        Game.fqueen.pos = New Point(-1, -1)

        For Each p In points
            Game.currFloor.mBoard(p.Y, p.X).Tag = 0
        Next

        Game.drawBoard()

        Game.player1.perks(perk.f13fqueentalked) = 3
    End Sub

    '| - COMBAT - |
    Public Overrides Function reactToSpell(spell As String) As Boolean
        If spell.Contains("Polymorph") Or spell.Contains("Turn to") Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " smiles as the spell washes over her, to no effect!")
            Return False
        End If

        Return True
    End Function
    Shared Sub toCombat()
        Dim m As FaeQueen = Game.fqueen
        Game.active_shop_npc = Game.fqueen
        Game.npc_list.Add(m)

        Game.queueSetup()
        Game.ShopNPCToCombat(m)

        Game.closeLblEvent()

        TextEvent.pushAndLog((DDUtils.capitalizeFirst(m.getNameWithTitle) & " awaits!"))

        If Game.player1.perks(perk.faecurse) > -1 And Not Game.cbrok.isDead Then
            TextEvent.push("You seem to be under some sort of fae curse...  Is this even a fight you can win?" & DDUtils.RNRN &
                           "It might be better to run away for now...")
            Game.cbrok.pos = New Point(4, 29)

            Game.player1.perks(perk.faecurse) += 1

            Game.drawBoard()
        End If
    End Sub
    Public Overrides Sub attackCMD(ByRef target As Entity)
        If firstCombat Then
            firstCombatTurn()
        ElseIf Not Game.player1.name.Equals(deducedName) And Game.lblEHealthChange.Tag < 10 Then
            trueNameClairvoyance()
        ElseIf Game.player1.name.Equals(deducedName) And Not testedName Then
            testName()
        ElseIf Game.player1.name.Equals(deducedName) And testedName Then
            trueNameSubmission()
        Else
            attackSpell(target, "Witch Orb", MyBase.getWIL)
            If Not target.getPlayer Is Nothing Then target.getPlayer.perks(perk.stunned) = 4
        End If
    End Sub
    Private Sub firstCombatTurn()
        Dim p As Player = Game.player1

        TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts Curse of Petals!")

        If Not p.equippedArmor.getAName.Equals("Naked") And Not p.equippedArmor.getAName.Contains("Steel") And Not p.equippedArmor.getAName.Contains("Iron") Then
            p.equippedArmor.add(-1)
            p.inv.add(PlantBikini.ITEM_NAME, 1)
            Equipment.equipArmor(p, PlantBikini.ITEM_NAME, False)
            TextEvent.push("Your armor shifts into a " & PlantBikini.ITEM_NAME & "!")
            p.drawPort()
        End If

        If Not p.equippedWeapon.getAName.Equals("Naked") And Not p.equippedWeapon.getAName.Contains("Steel") And Not p.equippedWeapon.getAName.Contains("Iron") Then
            p.equippedWeapon.add(-1)
            p.inv.add(Tulip.ITEM_NAME, 1)
            Equipment.equipWeapon(p, Tulip.ITEM_NAME, False)
            TextEvent.push("Your weapon shifts into a " & Tulip.ITEM_NAME & "!")
        End If

        firstCombat = False
    End Sub
    Private Sub testName()
        TextEvent.push("""Hmm, so your name is '" & Game.player1.name & "', correct?  What a clumsy little thing you are, " & Game.player1.name & "..."" says the Fae Queen.")
        TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle) & " tests the name she deduced...")

        Game.player1.nextCombatAction = AddressOf PerkEffects.mesStun

        testedName = True
    End Sub
    Private Sub trueNameClairvoyance()
        Dim p = Game.player1

        Dim deduction = p.name.Substring(deducedName.Length, Math.Min(2, p.name.Length - deducedName.Length))

        If p.perks(perk.vofmanynames) > 0 Then
            Dim falseDeduction = DDUtils.rndAlpha & DDUtils.rndAlpha

            While falseDeduction.Equals(deduction)
                falseDeduction = DDUtils.rndAlpha & DDUtils.rndAlpha
            End While

            TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " casts True-Name Clairvoyance!  " & DDUtils.capitalizeFirst(pronoun) & " learned that your name contains """ & falseDeduction & """" & DDUtils.RNRN &
                           """How curious, that doesn't seem quite right...""")
            TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts True-Name Clairvoyance!")

            p.perks(perk.vofmanynames) -= 1

            Exit Sub
        ElseIf p.perks(perk.vofmanynames) <> -1 Then
            p.perks(perk.vofmanynames) = -1
        End If

        TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " casts True-Name Clairvoyance!  " & DDUtils.capitalizeFirst(pronoun) & " learned that your name contains """ & deduction & """")
        TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts True-Name Clairvoyance!")

        deducedName += deduction
    End Sub
    Private Sub trueNameSubmission()
        Game.fromCombat()
        TextEvent.push("The Fae Queen smirks." & DDUtils.RNRN &
                       """" & Game.player1.name & ", kneel before me at once.  It's time for us to end this foolishness...""" & DDUtils.RNRN &
                       "Every fiber of your being tells you not to do so, but as your body moves on its own to lay down your weapon and drop to your knees it doesn't appear as though you have a choice." & DDUtils.RNRN &
                       "The Queen's expression darkens as you look up at her, and a soft glow eminates from her wings...", AddressOf pDeath)
    End Sub
    Private Sub pDeath()
        If selected_tree = 2 Then
            playerDeathAlt(Game.player1)
        Else
            playerDeath(Game.player1)
        End If
    End Sub
    Public Overrides Sub playerDeath(ByRef p As Player)
        MyBase.playerDeath(p)
        If Game.combat_engaged Then Game.fromCombat()

        Objective.showNPC(local_img(LocalImgInd.alt2), """Avert your gaze, you insect.  You aren't even worthy to lick my boots, let alone look me in the eyes." & DDUtils.RNRN &
                          "Mmm, 'insect' may even be too kind to describe someone like you...""" & DDUtils.RNRN &
                          "A contemplative look falls over the Queen's face, before shifting to a sinister grin." & DDUtils.RNRN &
                          """Take heart though, " & Game.player1.formName & ", for I have decided to grant you a form that isn't quite so repulsive.""", AddressOf leaveP1)

        If Game.shop_npc_engaged Then Game.hideNPCButtons()
    End Sub
    Public Sub playerDeathAlt(ByRef p As Player)
        MyBase.playerDeath(p)
        If Game.combat_engaged Then Game.fromCombat()

        Dim out = """A fittingly boring name, I suppose..."""

        If p.name.Length < 3 Then out = """Why is your name so short?"""
        If p.name.Length > 9 Then out = """Why is your name so long?"""
        If p.name.Equals("Fae Queen") Then out = """Are you mocking me?"""

        out += DDUtils.RNRN &
               "A contemplative look falls over the Queen's face, before shifting to a sinister grin." & DDUtils.RNRN &
               """Take heart though, " & Game.player1.name & ", for I have decided that you may serve some purpose yet."""

        Objective.showNPC(local_img(LocalImgInd.alt2), out, AddressOf leaveP1)

        If Game.shop_npc_engaged Then Game.hideNPCButtons()
    End Sub
    Private Sub leaveP1()
        Randomize(System.DateTime.Now.Millisecond)
        Select Case Int(Rnd() * 5)
            Case 0
                TextEvent.push("The Fae Queen's aura becomes overwhelming as a verdant glow engulfs your surroundings.  Thorny tendrils burst forth from your limbs, steadily ensnaring your body in their grasp." & DDUtils.RNRN &
                               "Your legs are pressed together, tighter, tighter, until the pressure releases suddenly and you take a moment to sigh with relief.  Glancing down, though, you find that your lower body has taken root and the dire state of your situation becomes clear." & DDUtils.RNRN &
                               "Leaves and petals sprout from your face as you begin to shrink, and without so much as a wimper you fade away into the fae's magic." & DDUtils.RNRN &
                               "The spell completes its work, and all that is left at the Queen's feet is an elegant " & Trim(Game.player1.getHairColor) & " rose.", AddressOf leaveP2)
                Game.player1.inv.item(FaeRose.ITEM_NAME).toSavedItem(Game.player1)
            Case 1
                TextEvent.push("The Fae Queen's aura becomes overwhelming as a verdant glow engulfs your surroundings.  You slump over, as the your strength is seemingly sapped by her spell." & DDUtils.RNRN &
                               "You try to prop yourself back up, but your arms quickly fall out from under you as they turn to a silky black fabric.  Glancing down, you find that the same is true of your legs, and the dire state of your situation becomes clear." & DDUtils.RNRN &
                               "The pattern of a bustier appears on your chest as it too becomes soft, silky cloth, and without so much as a wimper you fade away into the fae's magic." & DDUtils.RNRN &
                               "The spell completes its work, and all that is left at the Queen's feet is a skimpy set of lingerie.", AddressOf leaveP2)
                Game.player1.inv.item(FaeLingerie.ITEM_NAME).toSavedItem(Game.player1)
            Case 2
                TextEvent.push("The Fae Queen's aura becomes overwhelming as a verdant glow engulfs your surroundings.  You slump over, as the your strength is seemingly sapped by her spell." & DDUtils.RNRN &
                               "You try to prop yourself back up, but your arms quickly fall out from under you as they fade into nothingness.  Glancing down, you find that the same is true of your legs, and the dire state of your situation becomes clear." & DDUtils.RNRN &
                               "You can no longer sense anything around you, and without so much as a wimper you fade away into the fae's magic." & DDUtils.RNRN &
                               "The spell completes its work, and all that is left at the Queen's feet is a simple apple.", AddressOf leaveP2)
                Game.player1.inv.item(FaePApple.ITEM_NAME).toSavedItem(Game.player1)
            Case 3
                TextEvent.push("The Fae Queen's aura becomes overwhelming as a verdant glow engulfs your surroundings.  You slump over, as the your strength is seemingly sapped by her spell." & DDUtils.RNRN &
                               "You try to prop yourself back up, but your arms quickly fall out from under you as they fade into nothingness.  Glancing down, you find that the same is true of your legs, and the dire state of your situation becomes clear." & DDUtils.RNRN &
                               "You can no longer sense anything around you, and without so much as a wimper you fade away into the fae's magic." & DDUtils.RNRN &
                               "The spell completes its work, and all that is left at the Queen's feet is a shiny pair of earrings.", AddressOf leaveP2)
                Game.player1.inv.item(FaeForgedRing.ITEM_NAME).toSavedItem(Game.player1)
            Case Else
                TextEvent.push("The Fae Queen's aura becomes overwhelming as a verdant glow engulfs your surroundings.  You slump over, as the your strength is seemingly sapped by her spell." & DDUtils.RNRN &
                               "You try to prop yourself back up, but your arms quickly fall out from under you as they fade into nothingness.  Glancing down, you find that your legs are the only parts of you that aren't vanishing, and the dire state of your situation becomes clear." &
                               "The pattern of a ribbon appears on each of your thighs as they turn into smooth fabric, and without so much as a wimper you fade away into the fae's magic." & DDUtils.RNRN &
                               "The spell completes its work, and all that is left at the Queen's feet is a comfy pair of stockings.", AddressOf leaveP2)
                Game.player1.inv.item(FaeStockings.ITEM_NAME).toSavedItem(Game.player1)
        End Select
    End Sub
    Private Sub leaveP2()
        Objective.showNPC(local_img(LocalImgInd.normal), "There.  Much better...", AddressOf Game.player1.die)
    End Sub

    Private Sub faeCursedToCombat()
        If Game.player1.perks(perk.faehasname) < 0 Then
            Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(108), """I find your presence in my domain to be quite unpleasant...""" & DDUtils.PAKTC, AddressOf toCombat)
        Else
            Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(51), """Ah, by the way, your Majesty, their name is " & Game.player1.name & "."" a familiar faerie says, flitting in from the woods." & DDUtils.RNRN &
                                                                """Most apprecieated..."" smirks the Fae Queen, """ & Game.player1.name & ", I find your presence in my domain to be quite unpleasant...""" & DDUtils.PAKTC, AddressOf toCombat)

            deducedName = Game.player1.name
            testedName = True
        End If
    End Sub

    Public Overrides Sub die(ByRef cause As Entity)
        MyBase.die(cause)

        spawnStairs(Game.currFloor)

        Dim path = Game.currFloor.route(Game.fqueen.pos, Game.currFloor.stairs)

        For i = 0 To UBound(path) Step 4
            Game.currFloor.mBoard(path(i).Y, path(i).X).Tag = 2
            If Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "" Then Game.currFloor.mBoard(path(i).Y, path(i).X).Text = "x"
        Next

        Game.drawBoard()

        If debuffed Then inv.setCount(LingerieCatalog.ITEM_NAME, 0)

        Objective.showNPC(local_img(LocalImgInd.alt3), """G-GET OUT!  WHAT IS THIS CRAP!?  NO WAY I'D LOSE TO A " & Game.player1.formName & "!""" & DDUtils.RNRN &
                                    "The fae vanishes in a plume of mist, but now there's nothing to stop you from going through her stuff...", AddressOf pushChestContents)
    End Sub
    Private Sub pushChestContents()
        Dim c As String = "Chest Contents: " & vbCrLf

        For i = 0 To inv.upperBound
            Dim content As Item = inv.item(i)
            If content.only_drop_one And Game.player1.inv.getCountAt(i) > 0 Then inv.item(i).count = 0
            If inv.getCountAt(i) > 0 And Not i = 43 Then
                c += " " & vbCrLf & "+" & content.count & " " & Game.player1.inv.item(i).getName() & " "
            End If
        Next

        If inv.getCountAt(43) > 0 Then c += " " & vbCrLf & "+" & inv.getCountAt(43) & " " & Game.player1.inv.item(43).getName() & " "

        c += " " & DDUtils.PAKTC

        Game.lblEvent.Text = c
        If Settings.active(setting.textcolors) Then Game.lblEvent.ForeColor = Game.player1.textColor
        Game.lblEvent.BringToFront()
        Game.lblEvent.Location = New Point((250 * Game.Size.Width / 688) - (Game.lblEvent.Size.Width / 2), 65 * Game.Size.Width / 688)
        Game.lblEvent.Visible = True
    End Sub

    '| - MISC - |
    Public Overrides Sub buildShopArea(ByRef floor As mFloor)
    End Sub
End Class
