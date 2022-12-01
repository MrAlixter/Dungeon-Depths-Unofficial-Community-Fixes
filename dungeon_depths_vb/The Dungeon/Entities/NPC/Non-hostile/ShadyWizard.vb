Public Class ShadyWizard
    Inherits ShopNPC

    Public Shared ReadOnly SECRET_INV_CLASSES() As String = {"Bimbo", "Magical Slut", "Maid", "Bunny Girl", "Bimbo++"}
    Public Shared ReadOnly NORMAL_INV() As String = {CurseBGone.ITEM_NAME, PApple.ITEM_NAME, HPStickOfGum.ITEM_NAME, MPStickOfGum.ITEM_NAME, CrystalBikini.ITEM_NAME, Cowbell.ITEM_NAME, ScaleTalisman.ITEM_NAME, MaidDuster.ITEM_NAME, ScepterOfAsh.ITEM_NAME, SWRestoration.ITEM_NAME, Lepanacea.ITEM_NAME, CynnTonic.ITEM_NAME}
    Public Shared ReadOnly SECRET_INV() As String = {HPStickOfGum.ITEM_NAME, MPStickOfGum.ITEM_NAME, CrystalBikini.ITEM_NAME, BrawlerCosplay.ITEM_NAME, BronzeBikini.ITEM_NAME, CowCosplay.ITEM_NAME, CultistCloak.ITEM_NAME, MaidLingerie.ITEM_NAME, BunnySuit.ITEM_NAME, ReverseBunnySuit.ITEM_NAME, SkimpyClothes.ITEM_NAME, SteelBikini.ITEM_NAME, WitchCosplay.ITEM_NAME, SportBra.ITEM_NAME}

    Private use_secret_inv As Boolean = SECRET_INV_CLASSES.Contains(Game.player1.className)

    Sub New()
        MyBase.New()

        '|ID Info|
        name = "Shady Wizard"
        sName = name
        npc_index = ShopNPCInd.shadywizard

        '|NPC Flags|
        pronoun = "he"
        p_pronoun = "his"
        r_pronoun = "him"
        isShop = True

        '|Inventory|
        setNormalInv()

        'Armors
        If DDDateTime.isSummer Then inv.setCount(LimeBikini.ITEM_NAME, 1)
        If DDDateTime.isHallow Then inv.setCount(FamCostume.ITEM_NAME, 1)

        '|Stats|
        health = (1.0)
        maxHealth = (9999)
        attack = (9)
        defense = (99)
        speed = (99)
        will = 999
        gold = 99999
        xp_value = (maxHealth + attack + defense + speed) / 4
        sMaxHealth = maxHealth
        sMaxMana = maxMana
        sAttack = attack
        sdefense = defense
        sWill = will
        sSpeed = speed

        '|Images|
        local_img = New Dictionary(Of ShopNPC.LocalImgInd, Image)()

        local_img.Add(LocalImgInd.normal, ShopNPC.gbl_img.atrs(0).getAt(6))
        local_img.Add(LocalImgInd.frog, ShopNPC.gbl_img.atrs(0).getAt(4))
        local_img.Add(LocalImgInd.bunny, ShopNPC.gbl_img.atrs(0).getAt(7))
        local_img.Add(LocalImgInd.princess, ShopNPC.gbl_img.atrs(0).getAt(8))
        local_img.Add(LocalImgInd.sheep, ShopNPC.gbl_img.atrs(0).getAt(5))
        local_img.Add(LocalImgInd.doll, ShopNPC.gbl_img.atrs(0).getAt(9))
        local_img.Add(LocalImgInd.arachne, ShopNPC.gbl_img.atrs(0).getAt(68))
        local_img.Add(LocalImgInd.catgirl, ShopNPC.gbl_img.atrs(0).getAt(90))
        local_img.Add(LocalImgInd.trilobite, ShopNPC.gbl_img.atrs(0).getAt(96))
        local_img.Add(LocalImgInd.beegirl, ShopNPC.gbl_img.atrs(0).getAt(148))
        local_img.Add(LocalImgInd.alt1, ShopNPC.gbl_img.atrs(0).getAt(10))
    End Sub

    '| - INVENTORY - |
    Private Sub setNormalInv()
        For Each itm In SECRET_INV
            inv.setCount(itm, 0)
        Next

        For Each itm In NORMAL_INV
            inv.setCount(itm, 1)
        Next
    End Sub
    Private Sub setSecretInv()
        For Each itm In NORMAL_INV
            inv.setCount(itm, 0)
        Next

        For Each itm In SECRET_INV
            inv.setCount(itm, 1)
        Next
    End Sub

    '| - EVENT HANDLERS - |
    Public Overrides Sub inventoryUpdate()
        use_secret_inv = SECRET_INV_CLASSES.Contains(Game.player1.className)

        If use_secret_inv Then
            setSecretInv()
        Else
            setNormalInv()
        End If

        If Game.mDun.numCurrFloor < 3 Then
            inv.setCount(ScaleBikini.ITEM_NAME, 1)
        Else
            inv.setCount(GoldAdornment.ITEM_NAME, 1)
        End If
    End Sub
    Public Overrides Sub toFemale(form As String)
        MyBase.toFemale(form)
        setName("Shady Witch")
    End Sub
    Public Overrides Sub toMale(form As String)
        MyBase.toMale(form)
        setName("Shady Wizard")
    End Sub

    '| - COMBAT - |
    Public Overrides Sub attackCMD(ByRef target As Entity)
        attackSpell(target, "Confuego", MyBase.getWIL)
    End Sub
    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.fromCombat()
        Dim out = "You collapse to the ground, the wizard's onslaught wearing down your last defenses.  Twirling " & p_pronoun & " staff, they fire off one final blast and as it hits you your lifeforce... surges?  Startled, you notice that your body is coursing with magical energy- far more than you were capable of mustering before." & DDUtils.RNRN &
                  "You spring back to your feet, resuming a fighting stance though your confusion over this turn of events has you puzzled enough to hold off on attacking." & DDUtils.RNRN &
                  """Give it a sec,"" " & pronoun & " states, ""Or don't.  I don't really care.""" & DDUtils.RNRN &
                  "You desperatly lunge at them, the flood of mana coursing through you still increasing and before you can take three steps your body shrinks with a sudden jolt, leaving you looking at a far larger world." & DDUtils.RNRN &
                  "The energy within you seems to have only been focused by your diminished stature.  Its electric flow overwhelms you, and you see small crystals of pure mana beginning to form on your arms.  You try to flee, but your now giant opponent simply places the crook of their staff around you.  Escape no longer an option, you can do nothing but cower as the crystals swiftly replace your flesh and bone.  Nothing more than a gem full of magical energy now, you can't even react as the wizard raises their staff to inspect you."
        Game.picPortrait.BackgroundImage = Portrait.ol_img_lib.getImg(8)
        TextEvent.push(out, AddressOf SWizDeath2)
    End Sub
    Sub SWizDeath2()
        Dim p = Game.player1

        Game.fromCombat()
        Dim out = """Wow, you're in there good,"" they remark.  ""Geez, looks like somehow you got embeded in the wood.  I'm not walking around with a loser like you in one of my products.  You didn't even make that good of a crystal!  If I want to sell this now, I'm going to need to make you more... eyecatching...""" & DDUtils.RNRN &
                  "He snaps " & p_pronoun & " fingers, and though you can not see it your body is instantly changed to that of an incredibly busty, nude young woman." & DDUtils.RNRN &
                  """Now that's a look that will draw in customers.  I might have to make more of these, assuming I can find a couple more shmucks like you!  I wonder what that food guy is up to...""" & DDUtils.RNRN &
                  "GAME OVER!"
        Game.picPortrait.BackgroundImage = Portrait.ol_img_lib.getImg(8)
        TextEvent.push(out, AddressOf p.die)
    End Sub

    '| - DIALOG - |
    Protected Overrides Function normalDialog(ByRef p As Player)
        If use_secret_inv Then
            Return "Hey sugar, looking good...  Heh, just for you, let's bust out the ol' special inventory, yeah?"
        ElseIf Game.player1.getIntHealth = 69 Then
            Return "Ehehe.  Your health...  Nice." & DDUtils.RNRN &
                   "Anyway, what are you buying?"
        Else
            Return "Heh...  What are you buying?"
        End If
    End Function
    Protected Overrides Function bunnyDialog(ByRef p As Player)
        If use_secret_inv Then
            Return "OMG, you gotta check out my special inventory!  You'd, like, totally look hot in one of these bikinis."
        Else
            Return "So, like, are these thingies real or fake?  Uh, like, my ears, I mean..."
        End If
    End Function
    Protected Overrides Function princessDialog(ByRef p As Player)
        If use_secret_inv Then
            Return "Hey, " & Game.player1.className & ", wanna buy a brassiere?"
        Else
            Return "Hey, " & Game.player1.className & ", how's it going?"
        End If
    End Function
    Protected Overrides Function sheepDialog(ByRef p As Player)
        Return "*bleets*"
    End Function
    Protected Overrides Function arachneDialog(ByRef p As Player)
        If Game.player1.formName.Equals("Arachne") And Game.player1.equippedArmor.getAntiSlutInd > 0 Then
            Return "Ooh, darling, are you the one who laid that snare?  Aren't you a cutie..."
        ElseIf Game.player1.formName.Equals("Arachne") And Game.player1.equippedArmor.getSlutVarInd > 0 Then
            Return "Ooh, darling, are you the one who laid that snare?  You know, I could spice your look up a bit..."
        ElseIf Game.player1.formName.Equals("Arachne") Then
            Return "Ooh, darling, are you the one who laid that snare?  Let me know if you'd like any tips on your bondage technique..."
        Else
            Return "Ooh, darling, you should really give the whole ""8-Legs"" thing a chance.  I have a more... potent... venom if you'd like..."
        End If
    End Function
    Protected Overrides Function catgirlDialog(ByRef p As Player)
        Return "Damn it, and I set aside the extra-skimpy bikini for this too..."
    End Function
    Protected Overrides Function beegirlDialog(ByRef p As Player)
        Return "Ehehehe... Bzz Bzz Bzz..."
    End Function

    Protected Overrides Function normalFightDialog(ByRef p As Player)
        Return "Alright, get ready to fight.  This ain't gonna go well for you."
    End Function
    Protected Overrides Function frogFightDialog(ByRef p As Player)
        Return "Ribbit..."
    End Function
    Protected Overrides Function bunnyFightDialog(ByRef p As Player)
        Return "Whaaaat!?!"
    End Function
    Protected Overrides Function princessFightDialog(ByRef p As Player)
        Return "Get ready, I was trained by the royal mage's guild and I certainly ain't gonna submit easily."
    End Function
    Protected Overrides Function arachneFightDialog(ByRef p As Player)
        Return "*tsk* *tsk* *tsk* Not too bright..."
    End Function
    Protected Overrides Function catgirlFightDialog(ByRef p As Player)
        Return normalFightDialog(p)
    End Function

    Protected Overrides Function normalSpellDialog(ByRef p As Player)
        Return "Ha!  That's just sloppy."
    End Function
    Protected Overrides Function bunnySpellDialog(ByRef p As Player)
        Return "That's neat!"
    End Function
    Protected Overrides Function princessSpellDialog(ByRef p As Player)
        Return "I've seen better spellwork, but that was a decent attempt."
    End Function
    Protected Overrides Function sheepSpellDialog(ByRef p As Player)
        Return "[angry bleets]!"
    End Function
    Protected Overrides Function arachneSpellDialog(ByRef p As Player)
        Return "Oooh, is that really your best?  Adorable..."
    End Function
    Protected Overrides Function catgirlSpellDialog(ByRef p As Player)
        Return normalSpellDialog(p)
    End Function

    Public Overrides Function postPurchaseDialog(ByRef p As Player) As Object
        Return "See ya around..."
    End Function

      '| - MISC - |
    Public Overrides Sub buildShopArea(ByRef floor As mFloor)
        MyBase.buildShopArea(floor)

        Dim mannequins = {New Point(pos.X - 1, pos.Y)}

        Dim barrels = {New Point(pos.X + 1, pos.Y)}

        For Each pt In mannequins
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "¥"
        Next

        For Each pt In barrels
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "¤"
        Next
    End Sub
End Class
