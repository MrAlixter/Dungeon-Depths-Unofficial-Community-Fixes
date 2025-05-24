Public Class StellarWitch
    Inherits ShopNPC

    Public Shared ReadOnly SECRET_INV_CLASSES() As String = {"Bimbo", "Magical Slut", "Maid", "Bunny Girl", "Bimbo++"}
    Public Shared ReadOnly NORMAL_INV() As String = {CurseBGone.ITEM_NAME, HPStickOfGum.ITEM_NAME, MPStickOfGum.ITEM_NAME, CrystalBikini.ITEM_NAME, ScepterOfAsh.ITEM_NAME, AshStiletto.ITEM_NAME, SWRestoration.ITEM_NAME, Lepanacea.ITEM_NAME, CynnTonic.ITEM_NAME}
    Public Shared ReadOnly SECRET_INV() As String = {HPStickOfGum.ITEM_NAME, MPStickOfGum.ITEM_NAME, CrystalBikini.ITEM_NAME, BrawlerCosplay.ITEM_NAME, BronzeBikini.ITEM_NAME, CowCosplay.ITEM_NAME, CultistCloak.ITEM_NAME, MaidLingerie.ITEM_NAME, BunnySuit.ITEM_NAME, ReverseBunnySuit.ITEM_NAME, SkimpyClothes.ITEM_NAME, SteelBikini.ITEM_NAME, WitchCosplay.ITEM_NAME, SportBra.ITEM_NAME, ChainBikini.ITEM_NAME, DarkplateBikini.ITEM_NAME}
    Public Shared ReadOnly RANDOMIZED_INV() As String = {PApple.ITEM_NAME, Bowtie.ITEM_NAME, Cowbell.ITEM_NAME, ScaleTalisman.ITEM_NAME, MaidDuster.ITEM_NAME, CAttackCharm.ITEM_NAME, CDefenseCharm.ITEM_NAME, MagSlutWand.ITEM_NAME}

    Private use_secret_inv As Boolean = SECRET_INV_CLASSES.Contains(Game.player1.className)

    Sub New()
        MyBase.New()

        init()
    End Sub

    Sub init()
        '|ID Info|
        name = "Stellar Witch"
        sName = name
        npc_index = ShopNPCInd.shadywizard

        '|NPC Flags|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"
        isShop = True
        hasMetPlayer = Game.swiz.hasMetPlayer

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
        sDefense = defense
        sWill = will
        sSpeed = speed

        '|Images|
        local_img = New Dictionary(Of ShopNPC.LocalImgInd, Image)()

        local_img.Add(LocalImgInd.normal, ShopNPC.gbl_img.atrs(0).getAt(171))
        local_img.Add(LocalImgInd.frog, ShopNPC.gbl_img.atrs(0).getAt(4))
        local_img.Add(LocalImgInd.bunny, ShopNPC.gbl_img.atrs(0).getAt(173))
        local_img.Add(LocalImgInd.princess, ShopNPC.gbl_img.atrs(0).getAt(174))
        local_img.Add(LocalImgInd.sheep, ShopNPC.gbl_img.atrs(0).getAt(5))
        local_img.Add(LocalImgInd.doll, ShopNPC.gbl_img.atrs(0).getAt(178))
        local_img.Add(LocalImgInd.arachne, ShopNPC.gbl_img.atrs(0).getAt(175))
        local_img.Add(LocalImgInd.catgirl, ShopNPC.gbl_img.atrs(0).getAt(176))
        local_img.Add(LocalImgInd.trilobite, ShopNPC.gbl_img.atrs(0).getAt(96))
        local_img.Add(LocalImgInd.beegirl, ShopNPC.gbl_img.atrs(0).getAt(148))
        local_img.Add(LocalImgInd.bimbo, ShopNPC.gbl_img.atrs(0).getAt(177))
        local_img.Add(LocalImgInd.alt1, ShopNPC.gbl_img.atrs(0).getAt(172))
        local_img.Add(LocalImgInd.alt2, ShopNPC.gbl_img.atrs(0).getAt(179))
    End Sub

    Public Overrides Sub encounter()
        If Game.mDun.getWorldFlag(wFlag.stellarwitchswapped) < 0 Then
            Game.active_shop_npc = Game.swiz
            Game.swiz.encounter()
            Exit Sub
        End If

        MyBase.encounter()
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
    Private Sub setRandomInv()
        For Each itm In RANDOMIZED_INV
            inv.setCount(itm, 0)
        Next

        inv.setCount(RANDOMIZED_INV(Int(Rnd() * RANDOMIZED_INV.Length)), 1)
    End Sub

    '| - EVENT HANDLERS - |
    Public Overrides Sub inventoryUpdate()
        use_secret_inv = SECRET_INV_CLASSES.Contains(Game.player1.className) And hasMetPlayer

        If use_secret_inv Then
            setSecretInv()
        Else
            setNormalInv()
        End If

        setRandomInv()

        If Game.mDun.numCurrFloor < 3 Then
            inv.setCount(ScaleBikini.ITEM_NAME, 1)
        Else
            inv.setCount(GoldAdornment.ITEM_NAME, 1)
        End If
    End Sub
    Public Overrides Sub toFemale(form As String)
        MyBase.toFemale(form)
        setName("Stellar Witch")
    End Sub
    Public Overrides Sub toMale(form As String)
        MyBase.toMale(form)
        setName("Stellar Wizard")
    End Sub

    '| - COMBAT - |
    Public Overrides Sub attackCMD(ByRef target As Entity)
        attackSpell(target, "「✧ 𝐂𝐨𝐧𝐟𝐮𝐞𝐠𝐨 ✧」", MyBase.getWIL)
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
        If Not hasMetPlayer Then
            Game.swiz.hasMetPlayer = True
            Return ".°˖✧˚₊‧ HEYO! ‧₊˚✧˖°." & DDUtils.RNRN &
                   "Before you stands 「STAR」, stellar witch of the cosmos!  Purveyor of magic junk and style from beyond the spheres!" & DDUtils.RNRN &
                   "So look around!  I know I've got something with your name on it." & DDUtils.RNRN &
                   "⁺˚⋆｡°✩ ( ◜⁠‿⁠◝⁠ ) ✩°｡⋆˚⁺"
        ElseIf use_secret_inv Then
            Return "Heyo again!  I've got my special stock ready for " & If(p.sex.Equals("Female"), "a gal", "someone") & " like you, lemme know if anything catches your eye, ok?  (˶ > ⩊ < ˵)"
        Else
            Return "Heyo again!  Check the stock, and lemme know if anything catches your eye, ok?  (˶ ˆ ᗜ ˆ ˵)"
        End If
    End Function
    Protected Overrides Function bunnyDialog(ByRef p As Player)
        If use_secret_inv Then
            Return "Heyo again!  I've got my special stock ready for " & If(p.sex.Equals("Female"), "a gal", "someone") & " like you, lemme know if anything catches your eye, ok?  𓈒₍ ᐢ..ᐢ₎"
        Else
            Return "Heyo again!  Check the stock, and lemme know if anything catches your eye, ok?  𓈒₍ ᐢ..ᐢ₎"
        End If
    End Function
    Protected Overrides Function princessDialog(ByRef p As Player)
        If use_secret_inv Then
            Return "Hello again!  I've got my special stock ready for " & If(p.sex.Equals("Female"), "a gal", "someone") & " like you, please let me know if anything catches your eye, ok?"
        Else
            Return "Hello again!  Check the stock, and please let me know if anything catches your eye, ok?"
        End If
    End Function
    Protected Overrides Function sheepDialog(ByRef p As Player)
        Return "「 baaaaa 」"
    End Function
    Protected Overrides Function dollDialog(ByRef p As Player)
        Return "... (╥﹏╥)"
    End Function
    Protected Overrides Function arachneDialog(ByRef p As Player)
        Return "Why'd ya turn me into a bug?  That's kinda rude... ᄽ(☉_☉)ᄿ"
    End Function
    Protected Overrides Function catgirlDialog(ByRef p As Player)
        If use_secret_inv Then
            Return "Heyo again!  I've got my special stock ready for " & If(p.sex.Equals("Female"), "a gal", "someone") & " like you, lemme know if anything catches your eye, ok?  ᓚ( ^..^)"
        Else
            Return "Heyo again!  Check the stock, and lemme know if anything catches your eye, ok?  ᓚ( ^..^)"
        End If
    End Function
    Protected Overrides Function beegirlDialog(ByRef p As Player)
        Return "「 bzzzzzz 」"
    End Function
    Protected Overrides Function bimboDialog(ByRef p As Player)
        Return normalDialog(p)
    End Function

    Protected Overrides Function normalFightDialog(ByRef p As Player)
        Return "˗ˏˋ ᶠᶸᶜᵏᵧₒᵤ! ˎˊ˗"
    End Function
    Protected Overrides Function frogFightDialog(ByRef p As Player)
        Return "「 crrrrrroak 」!"
    End Function
    Protected Overrides Function bunnyFightDialog(ByRef p As Player)
        Return "ˋ-𓈒♥❀ 𝑑𝑖𝑒 ❀♥𓈒-ˊ"
    End Function
    Protected Overrides Function princessFightDialog(ByRef p As Player)
        Return "˗ˏˋ ᶜᵘʳˢᵉᵧₒᵤ! ˎˊ˗"
    End Function
    Protected Overrides Function arachneFightDialog(ByRef p As Player)
        Return "˚°｡° ᶠᶸᶜᵏᵧₒᵤ! °｡°˚"
    End Function
    Protected Overrides Function catgirlFightDialog(ByRef p As Player)
        Return "ฅ >ᶠᶸᶜᵏᵧₒᵤ! ฅ"
    End Function
    Protected Overrides Function bimboFightDialog(ByRef p As Player)
        Return bunnyFightDialog(p)
    End Function

    Protected Overrides Function normalSpellDialog(ByRef p As Player)
        Return "˗ˏˋ ( ╹ -╹)? ˎˊ˗"
    End Function
    Protected Overrides Function bunnySpellDialog(ByRef p As Player)
        Return normalSpellDialog(p)
    End Function
    Protected Overrides Function princessSpellDialog(ByRef p As Player)
        Return normalSpellDialog(p)
    End Function
    Protected Overrides Function sheepSpellDialog(ByRef p As Player)
        Return "「 angry bleets 」!"
    End Function
    Protected Overrides Function arachneSpellDialog(ByRef p As Player)
        Return "˗ˏˋ ( ˚°｡° - °｡°˚)? ˎˊ˗"
    End Function
    Protected Overrides Function catgirlSpellDialog(ByRef p As Player)
        Return "˗ˏˋ >^•⩊•^<? ˎˊ˗"
    End Function

    Protected Overrides Function normalPostPurchaseDialog(ByRef p As Player) As String
        Return "Thanks, see ya soon!  ദ്ദി─(• ᴗ -) ࿔*✧"
    End Function
    Protected Overrides Function dollPostPurchaseDialog(ByRef p As Player) As String
        Return "... (╥﹏╥)"
    End Function
    Protected Overrides Function bimboPostPurchaseDialog(ByRef p As Player) As String
        Return "Thanks, see ya soon!  ദ്ദി─(• ᴗ -) ࿔*🎔"
    End Function

    '| - MISC - |
    Public Overrides Sub buildShopArea(ByRef floor As mFloor)
        MyBase.buildShopArea(floor)

        Dim mannequins = {New Point(pos.X - 1, pos.Y)}
        If floor.ptInBounds(mannequins(0)) AndAlso floor.mBoard(mannequins(0).Y, mannequins(0).X).Tag = 0 Then mannequins(0) = New Point(pos.X, pos.Y - 1)

        Dim barrels = {New Point(pos.X + 1, pos.Y)}
        If floor.ptInBounds(barrels(0)) AndAlso floor.mBoard(barrels(0).Y, barrels(0).X).Tag = 0 Then barrels(0) = New Point(pos.X, pos.Y + 1)

        For Each pt In mannequins
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "¥"
        Next

        For Each pt In barrels
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Text = "¤"
        Next
    End Sub
End Class
