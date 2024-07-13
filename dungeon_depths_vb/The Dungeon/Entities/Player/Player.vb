Public Enum perk
    hunger          '0
    bimbotf         '1
    slutcurse       '2
    chickentf       '3
    slimehair       '4
    polymorphed     '5
    nekocurse       '6
    swordpossess    '7
    vsslimehair     '8
    brage           '9
    mmammaries      '10
    ihfury          '11
    livearm         '12
    livelinge       '13
    thrall          '14
    cowbell         '15
    minRegen        '16
    rotlg           '17
    astatue         '18
    svenom          '19
    avenom          '20
    blind           '21
    bowtie          '22
    hardlight       '23
    minmanregen     '24
    amazon          '25
    barbarian       '26
    slimetf         '27
    googirltf       '28
    bimbododge      '29
    lightsource     '30
    cupcake         '31
    stealth         '32
    copoly          '33
    cogreed         '34
    corust          '35
    comilk          '36
    coblind         '37
    coscale         '38
    pprot           '39
    masochist       '40
    burn            '41
    mburst          '42
    infernoa        '43
    faehasname      '44
    faecurse        '45
    isfae           '46
    meetfae1        '47
    succubuscurse   '48
    succubuscow     '49
    lucky7          '50
    dodge           '51
    seventailsstage '52
    bunnyears       '53
    hcharmsused     '54
    mcharmsused     '55
    acharmsused     '56
    dcharmsused     '57
    scharmsused     '58
    wcharmsused     '59
    guardup         '60
    willup          '61
    atkup           '62
    lurk            '63
    tfcausingwand   '64
    tfcausingsword  '65
    snarednpc       '66
    cmark           '67
    isspotfused     '68
    collarssnipped  '69
    canmeetcyn      '70
    cynnsq1ct1      '71
    cynnsq1ct2      '72
    fvHasSword      '73
    coftheox        '74
    pickaxe         '75
    pdrill          '76
    pdeflector      '77
    enemyoftime     '78
    owetimebalance  '79
    odxpgained      '80
    mrevived        '81
    tfedbyweapon    '82
    rubytrapstage   '83
    mesmerized      '84
    gagged          '85
    moamarphne      '86
    faestaysafe     '87
    stunned         '88
    mgind           '89
    faepassangers   '90
    zipped          '91
    faequestatue    '92
    irondagger      '93
    f13fqueentalked '94
    f13p2startturn  '95
    dragonboobs     '96
    metfantoma      '97
    vofmanynames    '98
    yellowonefavor  '99
    cynnstonic      '100
    metcynthia      '101
    faewishesmade   '102
    slimeregenplus  '103
    esper           '104
    spacebun        '105
    pinkmist        '106
    dubrations      '107
    hidehat         '108
End Enum
Public Enum stateInd
    goddState
    bimbState
    magGState
    maidState
    prinState
    dembimState1
    dembimState2
    succDisgState
    preBSBody
    preBSStartState
End Enum
Public Class Player
    'Player is the representation of a player controlled entity (the main player, any teammates)
    Inherits Entity

    'Player Instance variables
    Public sex, description As String
    Public pClass As pClass = New Classless()
    Public pForm As pForm = New Human()
    Public turnCt As Integer = 0
    Public xp, nextLevelXp As Integer

    Public breastSize As Integer = -1
    Public dickSize As Integer = -1
    Public buttSize As Integer = -1

    Public stamina As Integer
    Public equippedWeapon As Weapon = New BareFists
    Public equippedArmor As Armor = New CommonClothes0
    Public equippedAcce As Accessory = New noAcce
    Public equippedGlasses As Glasses = New noGlasses

    Public selectedSpell As String = Nothing
    Public selectedSpecial As String = Nothing

    Public Shadows currTarget As NPC = Nothing

    Public perks As Dictionary(Of perk, Integer) = New Dictionary(Of perk, Integer)() 'perks also include triggers for events
    Public Shared classes As Dictionary(Of String, pClass) = New Dictionary(Of String, pClass)()
    Public Shared forms As Dictionary(Of String, pForm) = New Dictionary(Of String, pForm)()
    Public polymorphs As Dictionary(Of String, Transformation) = New Dictionary(Of String, Transformation)()
    Public player_image As Image 'tile image of the player
    Public textColor As Color
    Public isPetrified = False

    'portrait variable
    Public prt As Portrait = New Portrait(True, Me)

    'player & form states
    Public currState, pState, sState As State
    Public formStates(9)

    Public solFlag = False
    Public prefForm As PreferredForm

    'assorted lists
    Public ongoingTFs As TFList = New TFList
    Public ongoingQuests As QuestList = New QuestList
    Public knownSpells As List(Of String) = New List(Of String)
    Public knownSpecials As List(Of String) = New List(Of String)
    Public selfPolyForms As List(Of String) = New List(Of String)
    Public enemPolyForms As List(Of String) = New List(Of String)
    Public skillsUsedThisCombat As List(Of String) = New List(Of String)
    Public quests As List(Of Quest) = New List(Of Quest)

    '|CONSTRUCTORS|:
    Shared Sub New()
        initClasses()
        initForms()
    End Sub
    Public Sub New()
        name = "TEMP_NAME"
        sex = "TEMP_SEX"
        health = 1.0
        maxHealth = 100
        attack = 10
        defense = 10
        will = 10
        speed = 10
        gold = 200
        lust = 0
        level = 1
        xp = 0
        nextLevelXp = DDConst.NEXT_LEVEL_FLOOR
        mana = 3
        maxMana = mana
        stamina = 100

        For i = 0 To UBound(formStates)
            formStates(i) = New State()
        Next

        selectedSpell = ""
        selectedSpecial = ""

        createInvPerks()
        inv.add(0, 1)
        inv.add(2, 1)
    End Sub
    'load from save constructors
    Public Sub New(ByVal s As String, ByVal v As Double)
        '|- Setup -|
        solFlag = True
        createInvPerks()

        Dim playArray() As String = s.Split("#")

        currState = New State(Me)
        sState = New State(Me)
        pState = New State(Me)
        For i = 0 To UBound(formStates)
            formStates(i) = New State()
        Next

        '|- Main Save States -|
        currState.read(playArray(0), v)
        sState.read(playArray(1), v)
        pState.read(playArray(2), v)

        pClass = classes(currState.pClass.name)
        pForm = forms(currState.pForm.name)

        '|- Tertiary Save States (For TFs/etc) -|
        Dim ind As Integer
        If v > 0.4 Then
            ind = CInt(playArray(3)) - 1
            For i = 0 To ind
                formStates(i).read(playArray(4 + i), v)
                If i = UBound(formStates) Then Exit For
            Next

            playArray = playArray(5 + ind).Split("*")
        Else
            ind = 7
            For i = 0 To 9
                formStates(i).read(playArray(3 + i), v)
            Next

            playArray = playArray(4 + ind).Split("*")
        End If

        '|- Player Stats -|
        pos.X = playArray(0)
        pos.Y = playArray(1)
        health = playArray(2)
        mana = playArray(3)
        stamina = playArray(4)
        hBuff = playArray(5)
        mBuff = playArray(6)
        aBuff = playArray(7)
        dBuff = playArray(8)
        wBuff = playArray(9)
        sBuff = playArray(10)
        level = playArray(11)
        xp = playArray(12)
        nextLevelXp = playArray(13)

        currState.load(Me)

        '|- Inventory -|
        inv.load(playArray(14))

        '|- Forced Path -|
        Dim x As Integer = -2
        If Not playArray(17 + x).Equals("N/a") Then
            'If the player is under the effect of the thrall collar, load their saved path.
            Dim crystal As Point = New Point(CInt(playArray(17 + x)), playArray(18 + x))
            forcedPath = {crystal}
            nextCombatAction = AddressOf ThrallTF.postLoadCrystalSpawn
        Else
            'Otherwise, there will be a placeholder "N/a" in place of the forced path that can be ignored.
            forcedPath = Nothing
        End If

        'Since the index is a bit messy at this point, currentIndex is created to clean it up
        Dim currentIndex = 18 + x
        If Not playArray(17 + x).Equals("N/a") Then currentIndex += 1

        '|- Current "Preferred Form" transformation/"Slave Collar" Saved Values -|
        Dim stuff() As String = playArray(currentIndex).Split("$")
        If Not stuff(0).Equals("N/a") Then
            prefForm = New PreferredForm(Color.FromArgb(CInt(stuff(0)), CInt(stuff(1)), CInt(stuff(2)), CInt(stuff(3))), _
                                        Color.FromArgb(CInt(stuff(4)), CInt(stuff(5)), CInt(stuff(6)), CInt(stuff(7))), _
                                        CBool(stuff(8)), CBool(stuff(9)), CInt(stuff(10)), CBool(stuff(11)), CInt(stuff(12)))
            CType(inv.item(69), ThrallCollar).setFormerLife(stuff(13), New Tuple(Of Integer, Boolean, Boolean)(CInt(stuff(14)), stuff(15), stuff(16)))
        Else
            CType(inv.item(69), ThrallCollar).setFormerLife(stuff(1), New Tuple(Of Integer, Boolean, Boolean)(CInt(stuff(2)), stuff(3), stuff(4)))
        End If

        '|- List Loading Setup -|
        'The next set of loaded values are all lists, saved as a list of lists delimitted by †
        Dim knowlegebase = playArray(currentIndex + 1).Split("†")
        currentIndex = 1

        '|- Ongoing Transformations -|
        Dim subKB = knowlegebase(currentIndex).Split("Ͱ")
        For i = 1 To CInt(subKB(0) + 1)
            Dim tf As Transformation = Transformation.newTF(subKB(i).Split("$"))
            ongoingTFs.add(tf)
        Next
        currentIndex += 1

        '|- Known "Self Polymorphs" Forms -|
        subKB = knowlegebase(currentIndex).Split("Ͱ")
        For i = 1 To CInt(subKB(0) + 1)
            selfPolyForms.Add(subKB(i))

        Next
        currentIndex += 1

        '|- Known "Polymorph Enemy" Forms -|
        subKB = knowlegebase(currentIndex).Split("Ͱ")
        For i = 1 To CInt(subKB(0) + 1)
            enemPolyForms.Add(subKB(i))

        Next
        currentIndex += 1

        '|- Known Spells -|
        subKB = knowlegebase(currentIndex).Split("Ͱ")
        For i = 1 To CInt(subKB(0) + 1)
            knownSpells.Add(subKB(i))
        Next
        currentIndex += 1

        '|- Known Specials -|
        subKB = knowlegebase(currentIndex).Split("Ͱ")
        For i = 1 To CInt(subKB(0) + 1)
            knownSpecials.Add(subKB(i))

        Next
        currentIndex += 1

        '|- Quest Records -|
        'Quests were added in version 10.2, and would not be present in older saves
        If v >= 10.2 Then
            subKB = knowlegebase(currentIndex).Split("Ͱ")
            For i = 1 To CInt(subKB(0) + 1)
                quests(i - 1).load(subKB(i))
            Next
            currentIndex += 1
        End If

        '|- Ongoing Quests -|
        'Quests were added in version 10.2, and would not be present in older saves
        If v >= 10.2 Then
            subKB = knowlegebase(currentIndex).Split("Ͱ")
            For i = 1 To CInt(subKB(0) + 1)
                ongoingQuests.add(quests(CInt(subKB(i))))
            Next
            currentIndex += 1
        End If

        '|- Cleanup -|
        currState.load(Me)
        If perks(perk.tfedbyweapon) > 0 Then equippedWeapon = currState.equippedWeapon

        turnCt = Game.getTurn

        allRoute()
        drawPort()

        magicRoute()
        specialRoute()

        solFlag = False
    End Sub
    Public Sub setStatsToBeginning()
        maxHealth = 100
        attack = 10
        defense = 10
        will = 10
        speed = 10
        mana = 3
        maxMana = mana
    End Sub

    '|CHARACTER CREATION/INITIALIZATION|
    Private Sub setStartingAccessory()
        'assigns an accessory based on the created player portrait
        If prt.iArrInd(pInd.accessory).Item2 Then
            Select Case prt.iArrInd(pInd.accessory).Item1
                Case 1
                    equippedAcce = inv.item(66)
                Case 2
                    equippedAcce = inv.item(67)
                Case 3
                    equippedAcce = inv.item(68)
                Case Else
                    equippedAcce = New noAcce
                    equippedAcce.count -= 1
            End Select
        Else
            Select Case prt.iArrInd(pInd.accessory).Item1
                Case 1
                    equippedAcce = inv.item(67)
                Case 2
                    equippedAcce = inv.item(68)
                Case Else
                    equippedAcce = New noAcce
                    equippedAcce.add(-1)
            End Select
        End If
        equippedAcce.add(1)
    End Sub
    Private Sub setStartingGlasses()
        'assigns glasses based on the created player portrait
        Select Case prt.iArrInd(pInd.glasses).Item1
            Case 1
                equippedGlasses = inv.item("Red_Framed_Spectacles")
            Case 2
                equippedGlasses = inv.item("Small_Glasses")
            Case 3
                equippedGlasses = inv.item("Circular_Glasses")
            Case 4
                equippedGlasses = inv.item("Thick_Rimmed_Specs")
            Case 5
                equippedGlasses = inv.item("Cool_Shades")
            Case 6
                equippedGlasses = inv.item("Monocle")
            Case 7
                equippedGlasses = inv.item("Eyepatch")
            Case 8
                equippedGlasses = inv.item("Masquerader's_Mask")
            Case Else
                equippedGlasses = New noGlasses
                equippedGlasses.count -= 1
        End Select

        equippedGlasses.add(1)
    End Sub
    Private Sub setCommonClothes()
        'assigns an accessory based on the created player portrait
        Select Case prt.iArrInd(pInd.clothes).Item1
            Case 0
                equippedArmor = inv.item("Common_Clothes")
            Case 1
                equippedArmor = inv.item("Common_Armor")
            Case 2
                equippedArmor = inv.item("Common_Garb")
            Case 3
                equippedArmor = inv.item("Fancy_Clothes")
            Case 4
                equippedArmor = inv.item("Ordinary_Clothes")
            Case 5
                equippedArmor = inv.item("Common_Kimono")
            Case 6
                equippedArmor = inv.item("Sneaky_Clothes")
            Case 7
                equippedArmor = inv.item("Adventurer's_Clothes")
            Case 8
                equippedArmor = inv.item("Regular_Clothes")
            Case 9
                equippedArmor = inv.item(CommonClothes9.ITEM_NAME)
            Case Else
                equippedArmor = New Naked
                equippedArmor.count -= 1
        End Select
        equippedArmor.add(1)
    End Sub
    Public Sub setClassLoadout(ByVal s As String)
        'set the player's form baced on their ears
        If prt.iArrInd(pInd.ears).Item1 = 3 Then
            pForm = forms("Elf")
        ElseIf prt.iArrInd(pInd.ears).Item1 = 4 Then
            pForm = forms("Android")
        End If

        'sets default weapon/armor/accessory
        equippedWeapon = New BareFists
        setStartingAccessory()
        setStartingGlasses()
        setCommonClothes()
        'set class
        pClass = classes(s)
        'sets loadout based on selected class
        If s = "Warrior" Then
            inv.add(83, 1)
            inv.add(84, 1)
            equippedArmor = inv.item(83)
            equippedWeapon = inv.item(84)

        ElseIf s = "Rogue" Then
            inv.add(164, 1)
            inv.add(165, 1)
            equippedAcce = inv.item(164)
            equippedWeapon = inv.item(165)

        ElseIf s = "Mage" Then
            knownSpells.Add("Fireball")
            inv.add(2, 3)
            inv.add(4, 1)
            inv.add(21, 1)
            equippedWeapon = inv.item(21)

        ElseIf s = "Cleric" Then
            knownSpells.Add("Heal")
            inv.add(2, 1)
            inv.add(13, 1)
            inv.add(283, 1)
            inv.add(284, 1)
            equippedAcce = inv.item(283)
            equippedWeapon = inv.item(284)

        ElseIf s = "Witch" Then
            knownSpells.Add("Turn to Frog")
            If breastSize = -1 Then breastSize = 0
            inv.add(4, 1)
            inv.add(117, 3)
            inv.add(166, 1)
            inv.add(167, 1)
            prt.skincolor = DDUtils.cShift(prt.skincolor, Color.ForestGreen, 15)
            equippedArmor = inv.item(166)
            equippedArmor.onEquip(Me)
            equippedWeapon = inv.item(167)

        ElseIf s = "Magical Girl" Then
            pClass = classes("Classless")
            maxHealth = 80
            attack = 7
            defense = 7
            speed = 7
            inv.add(2, 3)
            inv.add(4, 1)
            inv.add(11, 1)
            TextEvent.pushLog("You find a wand lodged in the entrance...  Maybe you should equip it?")

        ElseIf s = "Valkyrie" Then
            pClass = classes("Classless")
            maxHealth = 80
            attack = 7
            defense = 7
            speed = 7
            inv.add(2, 3)
            inv.add(88, 1)
            inv.add("Valkyrie_Sword", 1)
            TextEvent.pushLog("You find a sword piercing the floor...  Maybe you should equip it?")

        ElseIf s = "Time Cop" Then
            pClass = classes("Time Cop")
            inv.add("Phase_Pistol", 1)
            inv.add("Phase_Deflector", 1)
            inv.add("AAAAAA_Battery", 45)
            inv.add("Time_Cop_Clothes", 1)

            equippedWeapon = inv.item("Phase_Pistol")
            equippedArmor = inv.item(282)
            pState = New State(Me)
            Equipment.accChange(Me, "Phase_Deflector")
            Game.lblEvent.Visible = False
            Game.compOOT = True
            gold = 0

        ElseIf s = "Cynn's Ally" Then
            pClass = classes("Rogue")

            DarkPactTF.step1ally(Me)
            quests(qInd.darkPact).completeEntireQuest()
            Game.compDP = True

            inv.add(BronzeSpear.ITEM_NAME, 1)
            inv.add(CynnsMark.ITEM_NAME, 1)

            equippedAcce = inv.item(CynnsMark.ITEM_NAME)
            equippedAcce.onEquip(Me)
            equippedWeapon = inv.item(BronzeSpear.ITEM_NAME)

        ElseIf s = "Mecha-Warrior" Then
            pClass = classes("Warrior")
            pForm = forms("Combat Unit")

            prt.setIAInd(pInd.wings, 11, True, False)

            inv.add(StickOfGum.ITEM_NAME, 25)
            inv.add(DFStickOfGum.ITEM_NAME, 5)
            inv.add(TargetingSystem.ITEM_NAME, 1)
            inv.add(GumGun20mm.ITEM_NAME, 1)
            inv.add(GumGrenade.ITEM_NAME, 5)

            equippedWeapon = inv.item(GumGun20mm.ITEM_NAME)
            equippedGlasses = inv.item(TargetingSystem.ITEM_NAME)

        ElseIf s = "Evil Mage" Then
            pClass = classes("Mage")

            knownSpells.Add("Self Polymorph")
            knownSpells.Add("Fireball")
            selfPolyForms.Add("Succubus")

            maxMana = 999

            inv.add(2, 3)
            inv.add(4, 1)
            inv.add(21, 1)

            equippedWeapon = inv.item(21)
        End If

        If Settings.active(setting.startwithbooks) Then
            inv.add(242, 1)
            inv.add(243, 1)
        End If

        'equip armor, boost mana if a staff is equipped
        EquipmentDialogBackend.armorChange(Me, equippedArmor.getName)
        mana = getMaxMana()
        'set the known specials/spells
        specialRoute()
        magicRoute()
        'set player_image and TextColor
        player_image = mTile.imgLib.getImg(tSet.dungeon, tile.player)
        textColor = Color.White
        'sets the player description
        description = CStr(name & " is a " & sex & " " & pForm.name & " " & pClass.name)
        'saves the player's state
        currState = New State(Me)
        sState = New State(Me)
    End Sub
    Public Sub createInvPerks()
        inv = New Inventory(True)
        If System.IO.File.Exists("items\" & Game.sessionID & "_9.itm") Then inv.item(SoulBlade.ITEM_NAME).loadSavedItem(Game.sessionID, 9)

        initPerks()
        initPolymorphs()
        initQuests()
    End Sub
    Private Sub initPerks()
        perks.Clear()
        'Creates the dictionary of perks
        For Each p In System.Enum.GetValues(GetType(perk))
            perks.Add(p, -1)
        Next
    End Sub
    Private Shared Sub initClasses()
        'creates the class dictionary
        classes.Clear()
        classes.Add("Classless", New Classless())
        classes.Add("Warrior", New Warrior())
        classes.Add("Mage", New Mage())
        classes.Add("Evil Mage", New Mage())
        classes.Add("Magical Girl", New MagicGirl())
        classes.Add("Magical Girl​", New MagicGirlTransform())
        classes.Add("Valkyrie​", New ValkyrieTransform())
        classes.Add("Magical Slut", New MagicSlut())
        classes.Add("Bimbo", New Bimbo())
        classes.Add("Princess", New Princess())
        classes.Add("Maid", New Maid())
        classes.Add("Goddess", New Goddess())
        classes.Add("Paladin", New Paladin())
        classes.Add("Thrall", New Thrall())
        classes.Add("Trophy", New Trophy())
        classes.Add("Princess​", New PrincessBackfire())
        classes.Add("Bunny Girl​", New BunnyGirl())
        classes.Add("Kitty", New Kitty())
        classes.Add("Soul-Lord", New SoulLord())
        classes.Add("Targaxian", New Targaxian())
        classes.Add("Unconscious", New Unconcious())
        classes.Add("Valkyrie", New Valkyrie())
        classes.Add("Mecha Valkyrie", New CyberValkyrie())
        classes.Add("Bunny Girl", New Dancer())
        classes.Add("Barbarian", New Barbarian())
        classes.Add("Warlock", New Warlock())
        classes.Add("Mindless", New Mindless())
        classes.Add("Bimbo++", New BimboPlusPlus())
        classes.Add("Shrunken", New Shrunken())
        classes.Add("Maiden", New Maiden())
        classes.Add("Rogue", New Rogue())
        classes.Add("Cynn's Ally", New Rogue())
        classes.Add("Witch", New Witch())
        classes.Add("Time Cop", New TimeCop())
        classes.Add("Cleric", New Cleric())
        classes.Add("Necromancer", New Necromancer())
        classes.Add("Thong", New WSmithThong1())
        classes.Add("Thong​", New WSmithThong2())
        classes.Add("Fae Bee", New FvendFaeBee())
        classes.Add("Fae Bee​", New FVendFaeBee2())
        classes.Add("Battlemaiden", New Battlemaiden())
        classes.Add("Pirate", New Pirate())
        classes.Add("Cynn Onahole", New CynnOnahole())
        classes.Add("Onahole", New CynnOnahole2())
        classes.Add("Mecha-Warrior", New Warrior())
        classes.Add("Mindless Bimbo", New MindlessBimbo())
    End Sub
    Private Shared Sub initForms()
        'Creates the form dictionary
        forms.Clear()
        forms.Add("Human", New Human())
        forms.Add("Elf", New Elf())
        forms.Add("Android", New Android())
        forms.Add("Succubus", New Succubus())
        forms.Add("Half-Succubus", New HalfSuccubus())
        forms.Add("Angel", New Angel())
        forms.Add("Slime", New Slime())
        forms.Add("Half-Slime", New HalfSlime())
        forms.Add("Tigress", New Tigress())
        forms.Add("Dragon", New Dragon())
        forms.Add("Half-Dragon (R)", New HalfDragonR())
        forms.Add("Harpy", New Harpy())
        forms.Add("Djinn", New Djinn())
        forms.Add("Kitsune", New Kitsune())
        forms.Add("Minotaur Cow", New MinotaurCow())
        forms.Add("Minotaur Bull", New MinotaurBull())
        forms.Add("Golem", New Golem())
        forms.Add("Elder-God", New ElderGod())
        forms.Add("Gynoid", New Gynoid())
        forms.Add("Cyborg", New Cyborg())
        forms.Add("Blowup Doll", New BlowUpDoll())
        forms.Add("Cake", New Cake())
        forms.Add("Sheep", New Sheep())
        forms.Add("Frog", New Frog())
        forms.Add("Arachne", New Arachne())
        forms.Add("Amazon", New Amazon())
        forms.Add("Amazon​", New AmazonWeak())
        forms.Add("Plantfolk", New Plantfolk())
        forms.Add("Goo Girl", New GooGirl())
        forms.Add("Combat Unit", New CombatUnit())
        forms.Add("Half-Gorgon", New HGorgon())
        forms.Add("Half-Dragoness", New HDragoness())
        forms.Add("Half-Broodmother", New HBroodmother())
        forms.Add("Broodmother", New Broodmother())
        forms.Add("Blob", New Blob())
        forms.Add("Horse", New Horse())
        forms.Add("Unicorn", New Unicorn())
        forms.Add("Oni", New Oni())
        forms.Add("Alraune", New AlrauneF())
        forms.Add("Goth", New Goth())
        forms.Add("Plush", New Plush())
        forms.Add("Faerie", New FaeForm())
        forms.Add("Archdemoness", New ArchDemoness())
        forms.Add("Minotaur Cow (B)", New MinotaurCowB())
        forms.Add("Minotaur Bull (B)", New MinotaurBullB())
        forms.Add("Cow", New Cow())
        forms.Add("Orc", New Orc())
        forms.Add("Bee Girl", New BeeGirl())
        forms.Add("Blow-Up Cynn", New BlowUpCynn())
        forms.Add("Faerie (B)", New FaeBimbo())
        forms.Add("Demon", New Demon())
        forms.Add("Daemon", New Daemon())
    End Sub
    Private Sub initPolymorphs()
        'compile list of polymorphs
        polymorphs.Clear()
        polymorphs.Add("Dragon", Nothing)
        polymorphs.Add("Goddess", Nothing)
        polymorphs.Add("Slime", Nothing)
        polymorphs.Add("Succubus", Nothing)
        polymorphs.Add("Tigress", Nothing)
        polymorphs.Add("Princess​", Nothing)
        polymorphs.Add("Bunny Girl​", Nothing)
        polymorphs.Add("Sheep", Nothing)
        polymorphs.Add("Cake", Nothing)
        polymorphs.Add("Fusion", Nothing)
        polymorphs.Add("Mindless", Nothing)
        polymorphs.Add("MASBimbo", Nothing)
        polymorphs.Add("Plush", Nothing)
        polymorphs.Add("Fae", Nothing)
        polymorphs.Add("Horse", Nothing)
        polymorphs.Add("Unicorn", Nothing)
        polymorphs.Add("Cow", Nothing)
        polymorphs.Add("Human", Nothing)
    End Sub
    Private Sub initQuests()
        quests.Clear()
        quests.Add(New HelpWanted)
        quests.Add(New DarkPact)
        quests.Add(New DueForAnUpgrade)
        quests.Add(New BreakingAnEgg)
        quests.Add(New OutOfTime)
        quests.Add(New CursedContraband)
        quests.Add(New StudyingSlime)
        quests.Add(New Floor4Encounter)
        quests.Add(New OppositeDay)
        quests.Add(New NineLives)
        quests.Add(New ThrallLoss)
        quests.Add(New FaeWoodsQ1A)
        quests.Add(New FaeWoodsQ1B)
        quests.Add(New FaeWoodsQ2A)
        quests.Add(New FantasticPhantom)
    End Sub
    Sub setStartStates()
        If Settings.active(setting.enemiesoverwritess) Then
            sState.save(Me)
        End If

        savePState()
        If perks(perk.polymorphed) > -1 Then perks(perk.polymorphed) = -1
    End Sub
    Public Sub savePState()
        saveXState(pState)
    End Sub
    Public Sub saveXState(ByRef x_state As State)
        If Not x_state Is Nothing AndAlso Transformation.canBeTFed(Me) And Not perks(perk.succubuscurse) > 0 Then
            x_state.save(Me)
        End If
    End Sub

    '|MOVEMENT COMMANDS|
    Public Overrides Sub move(ByVal newX, ByVal newY)
        Game.progressTurn()

        '|-Forced Path-|
        If Not forcedPath Is Nothing Then
            followPath()
            Exit Sub
        End If

        '|-NPC Encounter Movement Freeze-|
        If Game.shop_npc_engaged Then Exit Sub

        '|-Other Movement Freezes-|
        If canMoveFlag = False Then Exit Sub

        '|-Edge of the Map-|
        If mFloor.loopVerticalFloors.Contains(Game.currFloor.floorNumber) AndAlso newY < 0 Then newY = Game.currFloor.mBoardHeight - 1
        If mFloor.loopVerticalFloors.Contains(Game.currFloor.floorNumber) AndAlso newY > Game.currFloor.mBoardHeight - 1 Then newY = 0
        If newY < 0 Or newY > Game.currFloor.mBoardHeight - 1 Or newX < 0 Or newX > Game.currFloor.mBoardWidth - 1 Then Exit Sub

        Dim board = Game.currFloor.mBoard

        '|-Pickaxe Effect-|
        If board(newY, newX).Tag = DDConst.TILE_WALL And perks(perk.pickaxe) > 0 And Game.mDun.numCurrFloor <> 13 Then board(newY, newX).Tag = DDConst.TILE_SEEN

        '|-Phase Drill Effect-|
        If board(newY, newX).Tag = DDConst.TILE_WALL And perks(perk.pdrill) > 0 And inv.getCountAt("AAAAAA_Battery") > 0 And Game.mDun.numCurrFloor <> 13 Then
            board(newY, newX).Tag = DDConst.TILE_SEEN
            getPlayer.inv.add("AAAAAA_Battery", -1)
        ElseIf board(newY, newX).Tag = DDConst.TILE_WALL And perks(perk.pdrill) > 0 And inv.getCountAt("AAAAAA_Battery") < 1 And Game.mDun.numCurrFloor <> 13 Then
            TextEvent.push("The drill spins weakly...")
        End If

        '|-Other Wall-|
        If board(newY, newX).Tag = 0 Then Exit Sub

        '|-Mindless-|
        If (className.Equals("Mindless") Or className.Equals("Mindless Bimbo")) And passDieRoll(5, 3) Then wander(board) : Exit Sub

        '|-Move-|
        board(pos.Y, pos.X).Text = ""
        pos = New Point(newX, newY)
    End Sub
    Public Overrides Sub reachedFPathDest()
        'Thrall Crystal discovery
        If pClass.name.Equals("Thrall") Then

            'Dark Pact questline
            If quests(qInd.darkPact).getCurrStep = 1 Then
                quests(qInd.darkPact).completeCurrOjb()
                Exit Sub
            End If

            'Standard encounter
            Dim out = "You've arrived at the crystal!" & DDUtils.RNRN &
                      "A familiar presence begins to flow into your mind, before a SNAP echos through your psyche.  You stand at attention, mindlessly staring at the glyphs inscribed on the gemstone's surface." & DDUtils.RNRN

            If passDieRoll(2, 1) Or Settings.active(setting.norng) Then
                out += """YES, AT LAST!"" your master states exitedly, and a roiling ball of violet magic appears besides you.  Once it grows large enough, they step out and immediately place a hand firmly on their prize." & DDUtils.RNRN

                If will > 10 Then
                    out += "Focusing completely on the network of symbols scrawled across the gem's surface, your master ignores your presence entirely." & DDUtils.RNRN &
                           "Wait... if they aren't monitoring you..." & DDUtils.RNRN &
                           "You grasp your collar with both hands, and they still don't seem to be paying you any attention, so you leverage your thumbs in the collar's joint."
                    TextEvent.push(out, AddressOf ThrallTF.betraySorc, AddressOf ThrallTF.waitSorc, "Break off your collar?")
                Else
                    out += "As your master fiddles with the gem, you notice a slight purple aura beginning to form around them and... wait, are those horns sprouting out from under their hair?" & DDUtils.RNRN &
                           "With a flourish, they complete their ritual, and with a deafening hum you are both engulfed by a blinding light that flashes out from the crystal!" & DDUtils.RNRN &
                           "As the dungeon fades back in, you glance around nervously.  Where once stood a mere human now stands a much-taller demon, clad in the tatters of their former clothes.  They cackle maniacally as a realization washes over you..." & DDUtils.RNRN &
                           "The collar around your neck has been reduced to ash!"

                    Equipment.equipAcce(Me, "Nothing", False)
                    If inv.getCountAt(ThrallCollar.ITEM_NAME) > 0 Then inv.add(ThrallCollar.ITEM_NAME, -1)

                    UIupdate()
                    drawPort()

                    TextEvent.push(out, AddressOf ThrallTF.waitSorc2)
                End If

            Else
                TextEvent.push(out & """NO, THIS ISN'T IT..."" your master states, leaving you in a disappointed huff.")
                ongoingTFs.add(New ThrallTF())
            End If
        ElseIf prt.checkFemInd(pInd.horns, 12) Then
            'For Each chest In Game.currFloor.chestList
            '    If DDUtils.withinOnePlusMinus(pos, chest.pos) Then
            '        chest.open()
            '        Game.currFloor.chestList.Remove(chest)
            '        Exit For
            '    End If
            'Next
        End If
    End Sub
    Public Sub wander(ByRef board(,) As mTile)
        Dim points As List(Of Point) = New List(Of Point)({New Point(pos.X, pos.Y - 1), New Point(pos.X, pos.Y + 1), New Point(pos.X - 1, pos.Y), New Point(pos.X + 1, pos.Y)})

        While points.Count > 0
            Dim i As Integer = Int(Rnd() * points.Count)

            If Game.currFloor.ptInBounds(points(i)) And board(points(i).Y, points(i).X).Tag > 0 Then
                board(pos.Y, pos.X).Text = ""
                pos = New Point(points(i).X, points(i).Y)
                Exit Sub
            End If

            points.Remove(points(i))
        End While
    End Sub

    '|COMBAT COMMANDS|
    Public Sub clearTarget()
        currTarget = Nothing
        MyBase.currTarget = Nothing
        nextCombatAction = Nothing
        MyBase.nextCombatAction = Nothing
    End Sub
    Public Overrides Sub attackCMD(ByRef target As Entity)
        Randomize()

        If pClass.name.Equals("Barbarian") Then
            aBuff -= perks(perk.barbarian)
            perks(perk.barbarian) = 0
        End If

        Dim dmg As Integer = equippedWeapon.attack(Me, target)

        If dmg = -1 Then
            miss(target)
        ElseIf dmg = -2 Then
            cHit(Me.getATK, target)
        ElseIf dmg <> -3 Then
            hit(Math.Max(dmg, 1), target)
        End If
    End Sub
    'attacking a npc
    Public Sub miss(target As NPC)
        TextEvent.pushAndLog(CStr("You miss " & target.getNameWithTitle() & "!"))
    End Sub
    Public Sub hit(dmg As Integer, target As NPC, Optional postfix As String = "", Optional verb As String = "hit")
        Dim t_took_dmg = target.takeDMG(dmg, Me)

        If t_took_dmg And Not target.isDead Then
            TextEvent.pushAndLog(CStr("You " & verb & " " & target.getNameWithTitle() & " for " & DDUtils.formatBigNumber(dmg) & " damage!" & postfix))
        ElseIf t_took_dmg Then
            TextEvent.push3rdLastLog(CStr("You " & verb & " " & target.getNameWithTitle() & " for " & DDUtils.formatBigNumber(dmg) & " damage!" & postfix))
        End If
    End Sub
    Public Sub cHit(dmg As Integer, target As NPC)
        Dim t_took_dmg = target.takeDMG(dmg * 2, Me)

        If t_took_dmg And Not target.isDead Then
            target.perks(npc_perk.stun) = 0
            TextEvent.pushAndLog(CStr("You hit " & target.getNameWithTitle() & " for " & DDUtils.formatBigNumber(dmg * 2) & " damage!  Critical hit!"))
        ElseIf t_took_dmg Then
            TextEvent.push3rdLastLog(CStr("You hit " & target.getNameWithTitle() & " for " & DDUtils.formatBigNumber(dmg * 2) & " damage!  Critical hit!"))
        End If
    End Sub
    Public Sub setTarget(ByRef t As NPC)
        currTarget = t
        MyBase.currTarget = t
    End Sub

    'attacking a non npc
    Private Sub miss(target As Entity)
        If target.GetType() Is GetType(NPC) Or target.GetType.IsSubclassOf(GetType(NPC)) Then
            miss(CType(target, NPC))
            Exit Sub
        End If

        TextEvent.pushAndLog(CStr("You miss " & Trim(target.getName()) & "!"))
    End Sub
    Private Sub hit(dmg As Integer, target As Entity)
        If target.GetType() Is GetType(NPC) Or target.GetType.IsSubclassOf(GetType(NPC)) Then
            hit(dmg, CType(target, NPC))
            Exit Sub
        End If

        TextEvent.pushAndLog(CStr("You hit " & Trim(target.getName()) & " for " & DDUtils.formatBigNumber(dmg) & " damage!"))
        target.takeDMG(dmg, Me)
    End Sub
    Private Sub cHit(dmg As Integer, target As Entity)
        If target.GetType() Is GetType(NPC) Or target.GetType.IsSubclassOf(GetType(NPC)) Then
            cHit(dmg, CType(target, NPC))
            Exit Sub
        End If

        TextEvent.pushAndLog(CStr("You hit " & Trim(target.getName()) & " for " & DDUtils.formatBigNumber(dmg * 2) & " damage!  Critical hit!"))
        target.takeDMG(dmg * 2, Me)
    End Sub
    'taking damage
    Public Overrides Function takeDMG(ByRef dmg As Integer, ByRef source As Entity) As Boolean
        If PerkEffects.onDamage(Me, dmg) Then Return False

        Game.lblPHealtDiff.Tag -= dmg

        TextEvent.pushAndLog(CStr("You got hit! -" & DDUtils.formatBigNumber(dmg) & " health!"))

        Return MyBase.takeDMG(dmg, source)
    End Function
    Public Sub takeUnconditionalDMG(ByVal dmg As Integer, ByRef source As Entity)
        Game.lblPHealtDiff.Tag -= dmg

        TextEvent.pushAndLog(CStr("You got hit! -" & DDUtils.formatBigNumber(dmg) & " health!"))

        MyBase.takeDMG(dmg, source)
    End Sub
    Public Overrides Function takeCritDMG(ByRef dmg As Integer, ByRef source As Entity) As Boolean
        If PerkEffects.onDamage(Me, dmg, True) Then Return False
        If dmg > getIntHealth() And dmg > 0.05 * getMaxHealth() Then dmg = getIntHealth() - 1

        Game.lblPHealtDiff.Tag -= dmg

        TextEvent.pushAndLog(CStr("You got hit!  Critical hit!  -" & DDUtils.formatBigNumber(dmg) & " health!"))

        Return MyBase.takeDMG(dmg, source)
    End Function
    Public Sub takeUnconditionalCritDMG(ByVal dmg As Integer, ByRef source As Entity)
        If dmg > getIntHealth() And dmg > 0.05 * getMaxHealth() Then dmg = getIntHealth() - 1

        Game.lblPHealtDiff.Tag -= dmg

        TextEvent.pushAndLog(CStr("You got hit!  Critical hit!  -" & DDUtils.formatBigNumber(dmg) & " health!"))

        MyBase.takeDMG(dmg, source)
    End Sub
    'specials
    Public Sub specialRoute()
        Game.cboxSpec.Items.Clear()

        For Each s In knownSpecials
            Game.cboxSpec.Items.Add(s)
        Next

        If (pClass.name = "Warrior" Or pClass.name = "Barbarian") And Not knownSpecials.Contains("Berserker Rage") Then Game.cboxSpec.Items.Add("Berserker Rage")
        If (pClass.name = "Mage" Or pClass.name = "Warlock") And Not knownSpecials.Contains("Risky Decision") Then Game.cboxSpec.Items.Add("Risky Decision")
        If (pClass.name = "Rogue" Or pClass.name = "Necromancer") And Not knownSpecials.Contains("Pluck") Then Game.cboxSpec.Items.Add("Pluck")
        If (pClass.name = "Cleric" Or pClass.name = "Paladin") And Not knownSpecials.Contains("Cleansing Light") Then Game.cboxSpec.Items.Add("Cleansing Light")
        If breastSize > 3 And Not knownSpecials.Contains("Massive Mammaries") Then Game.cboxSpec.Items.Add("Massive Mammaries")
        If breastSize > 5 And Not knownSpecials.Contains("Pillowy Protect") Then Game.cboxSpec.Items.Add("Pillowy Protect")
        If pForm.name = "Succubus" And Not knownSpecials.Contains("Charm") Then Game.cboxSpec.Items.Add("Charm")
        If pForm.name = "Succubus" And Not knownSpecials.Contains("Drain Soul") Then Game.cboxSpec.Items.Add("Drain Soul")
        If pForm.name = "Slime" And Not knownSpecials.Contains("Absorbtion") Then Game.cboxSpec.Items.Add("Absorbtion")
        If pForm.name = "Dragon" And Not knownSpecials.Contains("Ironhide Fury") Then Game.cboxSpec.Items.Add("Ironhide Fury")
        If inv.item("Shrink_Ray").count > 0 And Not knownSpecials.Contains("Shrink_Ray Shot") Then Game.cboxSpec.Items.Add("Shrink_Ray Shot")
    End Sub
    Public Sub magicRoute()
        Game.cboxNPCMG.Items.Clear()
        If pForm.name = "Alraune" And Not knownSpells.Contains("Mesmeric Bloom") Then knownSpells.Add("Mesmeric Bloom")
    End Sub
    'wait
    Public Sub wait()
        If pClass.name.Equals("Barbarian") Then
            aBuff += 5
            perks(perk.barbarian) += 5
        End If
    End Sub

    '|TRANSFORMATION METHODS|
    Public Sub revertToState(ByRef s As State)
        Dim tMna As Integer = mana + mBuff
        Dim tHun As Integer = stamina
        Dim tGold As Integer = gold

        Dim t_equip_armor As String = equippedArmor.getAName()
        Dim t_equip_weapon As String = equippedWeapon.getAName()
        Dim t_equip_acc As String = equippedAcce.getAName()
        Dim t_equip_glasses As String = equippedGlasses.getAName()

        Dim tpClass As pClass = pClass
        Dim tpForm As pForm = pForm

        s.load(Me, False)

        mana = tMna
        gold = tGold

        If inv.getCountAt(t_equip_armor) > 0 Then EquipmentDialogBackend.armorChange(Me, t_equip_armor, False)
        If inv.getCountAt(t_equip_weapon) > 0 Then EquipmentDialogBackend.weaponChange(Me, t_equip_weapon, False)
        If inv.getCountAt(t_equip_acc) > 0 Then EquipmentDialogBackend.accessoryChange(Me, t_equip_acc, False)
        If inv.getCountAt(t_equip_glasses) > 0 Then EquipmentDialogBackend.equipGlasses(Me, t_equip_glasses, False)

        currState.save(Me)
        savePState()

        If mana > maxMana + mBuff Then mana = maxMana + mBuff

        Dim out = ""

        If Not tpForm.name.Equals(pForm.name) Then
            tpForm.revert()
            If tpForm.revertPassage <> "" Then out += tpForm.revertPassage & DDUtils.RNRN
            If pForm.transformPassage <> "" Then out += pForm.transformPassage & DDUtils.RNRN
        End If

        If Not tpClass.name.Equals(pClass.name) And perks(perk.tfedbyweapon) < 0 Then
            tpClass.revert()
            If tpClass.revertPassage <> "" Then out += tpClass.revertPassage & DDUtils.RNRN
            If pClass.transformPassage <> "" Then out += pClass.transformPassage & DDUtils.RNRN
        End If

        ongoingTFs.resetPolymorphs()

        If Game.lblEvent.Visible = False Then TextEvent.push(out & "You return to your former form!")
        Game.player_image = player_image
        If Settings.active(setting.textcolors) Then Game.lblEvent.ForeColor = textColor
        Game.lblNameTitle.ForeColor = textColor

        reverseAllRoute()
        drawPort()
        UIupdate()
    End Sub
    Public Function revertToState(ByVal numtorevert As Integer, ByRef s As State) As String
        Randomize()

        Dim loopct = 0

        Dim unordered_attributes As String() = {"Tail", "Wings", "Rear Hair", "Face", "Horns", "Ears", "Nose", "Mouth", "Eyes", "Eyebrows", "Facemark", "Front Hair", "Hat", "Hair Color", "Skin Color", "Breast Size", "Dick Size", "Butt Size", "Text Color"}
        DDUtils.shuffle(unordered_attributes)
        Dim repeatable_attributes As String() = {"Breast Size", "Dick Size", "Butt Size"}

        Dim attributes As List(Of String) = unordered_attributes.ToList
        Dim reverted_attributes As List(Of String) = New List(Of String)

        While numtorevert > 0

            If loopct > 100 Then
                'if 100 attributes have been tried and there are still some left to revert, give up
                revertToState(s)
                Return ""
                Exit While
            End If

            Dim attribute As String = attributes(Int(Rnd() * attributes.Count))
            Dim layer = -1
            Dim reverted_attribute As Boolean = False

            Select Case attribute
                Case "Tail"
                    layer = pInd.tail
                Case "Wings"
                    layer = pInd.wings
                Case "Rear Hair"
                    If Not (prt.iArrInd(pInd.rearhair).Item1 = s.iArrInd(pInd.rearhair).Item1 And prt.iArrInd(pInd.rearhair).Item2 = s.iArrInd(pInd.rearhair).Item2 And prt.iArrInd(pInd.rearhair).Item3 = s.iArrInd(pInd.rearhair).Item3) Then reverted_attribute = True
                    prt.setIAInd(pInd.rearhair, s.iArrInd(pInd.rearhair).Item1, s.iArrInd(pInd.rearhair).Item2, s.iArrInd(pInd.rearhair).Item3)
                    prt.setIAInd(pInd.midhair, s.iArrInd(pInd.midhair).Item1, s.iArrInd(pInd.midhair).Item2, s.iArrInd(pInd.midhair).Item3)
                Case "Face"
                    layer = pInd.face
                Case "Horns"
                    layer = pInd.horns
                Case "Ears"
                    layer = pInd.ears
                Case "Nose"
                    layer = pInd.nose
                Case "Mouth"
                    layer = pInd.mouth
                Case "Eyes"
                    layer = pInd.eyes
                Case "Eyebrows"
                    layer = pInd.eyebrows
                Case "Facemark"
                    layer = pInd.facemark
                Case "Front Hair"
                    layer = pInd.fronthair
                Case "Hat"
                    layer = pInd.hat
                Case "Hair Color"
                    If Not DDUtils.cEquals(prt.haircolor, s.getHairColor) Then reverted_attribute = True
                    prt.haircolor = DDUtils.cShift(prt.haircolor, s.getHairColor, 125)
                Case "Skin Color"
                    If Not prt.skincolor = s.getSkinColor Then reverted_attribute = True
                    prt.skincolor = DDUtils.cShift(prt.skincolor, s.getSkinColor, 125)
                Case "Breast Size"
                    If breastSize > s.breastSize Then
                        breastSize -= 1
                        reverted_attribute = True
                    ElseIf breastSize < s.breastSize Then
                        breastSize += 1
                        reverted_attribute = True
                    End If
                Case "Dick Size"
                    If dickSize > s.dickSize Then
                        dickSize -= 1
                        reverted_attribute = True
                    ElseIf dickSize < s.dickSize Then
                        dickSize += 1
                        reverted_attribute = True
                    End If
                Case "Butt Size"
                    If buttSize > s.buttSize Then
                        buttSize -= 1
                        reverted_attribute = True
                    ElseIf buttSize < s.buttSize Then
                        buttSize += 1
                        reverted_attribute = True
                    End If
                Case "Text Color"
                    If Not DDUtils.cEquals(textColor, s.textColor) Then reverted_attribute = True
                    textColor = DDUtils.cShift(textColor, s.textColor, 255)
            End Select

            If (layer <> -1 AndAlso (prt.iArrInd(layer).Item1 <> sState.iArrInd(layer).Item1 And prt.iArrInd(layer).Item2 <> sState.iArrInd(layer).Item2 And prt.iArrInd(layer).Item2 <> sState.iArrInd(layer).Item3)) Then
                prt.setIAInd(layer, s.iArrInd(layer).Item1, s.iArrInd(layer).Item2, s.iArrInd(layer).Item3)
                reverted_attribute = True
            End If

            If reverted_attribute Then
                numtorevert -= 1
                reverted_attributes.Add(attribute)
                If Not repeatable_attributes.Contains(attribute) Then attributes.Remove(attribute)
            End If

            loopct += 1
        End While

        reverseAllRoute()
        drawPort()

        Dim out = reverted_attributes.Count & " changes were reverted." & vbCrLf & "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
        For Each atr In reverted_attributes
            out += vbCrLf & atr & " reverted."
        Next
        If reverted_attributes.Count > 0 Then out += vbCrLf & "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
        Return out
    End Function
    Public Sub revertToSState()
        perks(perk.slutcurse) = -1

        revertToState(sState)

        TextEvent.push("With a poof of smoke, you return to your original self!")
    End Sub
    Public Function revertToSState(ByVal numtorevert As Integer) As String
        Return revertToState(numtorevert, sState)
    End Function
    Public Sub revertToPState()
        revertToState(pState)
    End Sub
    Public Function revertToPState(ByVal numtorevert As Integer) As String
        Return revertToState(numtorevert, pState)
    End Function
    Public Sub changeClass(ByVal newClass As String)
        If Not classes.ContainsKey(newClass) Then DDError.playerClassChangeError(newClass) : Exit Sub
        If pClass.name.Equals(newClass) Then Exit Sub

        Dim nextlevelPercentage As Double = xp / nextLevelXp
        xp = 0

        For i = level To 1 Step -1
            pClass.deLVL(i, Me)
        Next

        pClass.revert()

        pClass = classes(newClass)

        For i = 1 To level
            pClass.onLVLUp(i, Me, False)
        Next

        xp = CInt(nextlevelPercentage * nextLevelXp)
    End Sub
    Public Sub changeForm(ByVal newForm As String)
        If Not forms.ContainsKey(newForm) Then DDError.playerFormChangeError(newForm) : Exit Sub
        If pForm.name.Equals(newForm) Then Exit Sub

        Dim nextlevelPercentage As Double = xp / nextLevelXp
        xp = 0

        For i = level To 1 Step -1
            pForm.deLVL(i, Me)
        Next

        pForm.revert()

        pForm = forms(newForm)

        For i = 1 To level
            pForm.onLVLUp(i, Me, False)
        Next

        xp = CInt(nextlevelPercentage * nextLevelXp)
    End Sub
    Public Sub petrify(ByVal c As Color, ByVal dur As Integer)
        savePState()

        perks(perk.astatue) = dur
        changeHairColor(c, True)

        If prt.sexBool Then
            prt.setIAInd(pInd.mouth, 10, True, True)
            prt.setIAInd(pInd.eyes, 14, True, True)
        Else
            prt.setIAInd(pInd.mouth, 5, False, True)
            prt.setIAInd(pInd.eyes, 6, False, True)
        End If

        If Not isUnwilling() Then
            prt.setIAInd(pInd.mouth, 29, True, True)
        End If

        changeSkinColor(c)

        isPetrified = True
        drawPort()
        canMoveFlag = False
    End Sub
    Public Sub toStatue(ByVal c As Color, ByVal r As String)
        Game.fromCombat()

        petrify(c, 9999)
        If r.Equals("midas") Then
            Dim out As String = "As you reach out to touch your opponent, you clumsily swipe, missing them, and hit...yourself?  Already your legs are gold, and only have a moment to scream, your vocal cords quickly following suit. ""Well,"" you think, ""...at least I won't have to worry abou money anymore."" " & vbCrLf & "And like that, the dungeon gains another decoration."
            TextEvent.push(out, AddressOf die)
        End If
    End Sub

    '|GENERAL METHODS|
    Sub resetPerks()
        perks(perk.bimbotf) = -1
        perks(perk.chickentf) = -1
        perks(perk.polymorphed) = -1
        perks(perk.nekocurse) = -1
        perks(perk.brage) = -1
        perks(perk.mmammaries) = -1
        perks(perk.ihfury) = -1
        perks(perk.astatue) = -1
        perks(perk.bimbododge) = -1
        perks(perk.pprot) = -1
        perks(perk.burn) = -1
        perks(perk.mburst) = -1
        perks(perk.infernoa) = -1
        perks(perk.dodge) = -1
        perks(perk.guardup) = -1
        perks(perk.willup) = -1
        perks(perk.atkup) = -1
        perks(perk.lurk) = -1
        perks(perk.isspotfused) = -1
        perks(perk.owetimebalance) = -1
    End Sub
    Public Overrides Sub die(ByRef source As Entity)
        If Game.pnlSaveLoad.Visible = True Then Exit Sub

        If inv.getCountAt("Extra_Life") > 0 Then
            inv.item("Extra_Life").add(-1)
            health = Math.Min(0.125 * inv.getCountAt("Extra_Life"), 1.0)
            health = Math.Max(health, 0.1)
            TextEvent.pushAndLog("Extra_Life consumed!")

            Exit Sub
        End If

        Game.fromCombat()
        Game.pnlCombat.Visible = False
        canMoveFlag = False

        resetPerks()

        If source Is Nothing Then
            DeathEffects.hardDeath()
            Exit Sub
        End If

        source.currTarget = Nothing
        source.nextCombatAction = Nothing

        If Not source Is Nothing AndAlso Not source.getSName Is Nothing Then
            TextEvent.pushLog("You are defeated!")

            If source.getName.Equals("stamina") Then
                TextEvent.push("You starve to death!")
            ElseIf source.getName.Equals("Fire") Then
                TextEvent.push("You burn to death!")
            ElseIf source.getName.Equals(BewitchedRations.ITEM_NAME) Then
                DeathEffects.bewitchedRation(Me)
                setHealth(0.25)
                Exit Sub
            ElseIf source.GetType.IsSubclassOf(GetType(ShopNPC)) Then
                CType(source, ShopNPC).playerDeath(Me)
                setHealth(0.25)
                Exit Sub
            ElseIf source.GetType.IsSubclassOf(GetType(NPC)) Or source.GetType.IsSubclassOf(GetType(Monster)) Then
                CType(source, NPC).playerDeath(Me)
                setHealth(0.25)
                Exit Sub
            End If
        End If

        DeathEffects.hardDeath()
        Game.npc_list.Clear()
    End Sub

    '|UPDATE METHODS|
    Public Overrides Sub update()
        '|COMBAT|
        If perks(perk.astatue) > -1 Then nextCombatAction = AddressOf PerkEffects.statueMove
        If (perks(perk.mesmerized) > -1 Or className.Equals("Mindless")) AndAlso Int(Rnd() * 2) = 0 Then nextCombatAction = AddressOf PerkEffects.mesStun
        If perks(perk.stunned) = 1 Then nextCombatAction = AddressOf PerkEffects.stun
        If Game.currFloor.floorNumber = 13 And perks(perk.faepassangers) = 1 Or perks(perk.faepassangers) = 2 Or perks(perk.faepassangers) = 3 Then nextCombatAction = AddressOf FaeWoodsQ2A.faeAttack

        MyBase.update()

        '|STAMINA|
        If Game.getTurn <> turnCt And Game.getTurn Mod 25 = 0 Then stamina -= 1

        '|MANA REGEN|
        Dim m = Math.Max(CInt(7.8152 * Math.Exp(-0.011 * getWIL())), 1)
        If Game.getTurn <> turnCt And mana < getMaxMana() And Game.getTurn Mod m = 0 And Not perks(perk.cmark) > -1 Then
            Dim mregen = Math.Max(Int(getMaxMana() / 15), 1)
            If equippedAcce.getAName.Equals(TidemageTattoo.ITEM_NAME) AndAlso equippedArmor.getAName.Contains("Bikini") Then mregen *= 1.4
            mana += mregen
        End If

        '|PERK AND TRANSFORMATION UPDATES|
        Dim pUpdateFlag As Boolean = False
        'perks
        If Game.getTurn <> turnCt Then
            pUpdateFlag = perkUpdate()
        End If
        'transformations
        tfUpdate(pUpdateFlag)

        '|QUEST UPDATES|
        ongoingQuests.ping()

        '|PLAYER STAT UPKEEP|
        UIupdate()

        If pUpdateFlag Then drawPort()

        turnCt = Game.getTurn
    End Sub
    Protected Sub tfUpdate(Optional ByRef pUpdateFlag = False)
        'transformations
        ongoingTFs.ping(pUpdateFlag)
    End Sub
    Protected Function perkUpdate() As Boolean
        Dim needsToUpdatePortrait = False

        If quests(qInd.fanPhan).canGet Then
            quests(qInd.fanPhan).init()
            Return needsToUpdatePortrait
        End If

        '|GENERAL EFFECTS|
        applyMiscPerkEffects(needsToUpdatePortrait)
        applyClassPerkEffects(needsToUpdatePortrait)
        applyFormPerkEffects(needsToUpdatePortrait)

        '|TRANSFORMATION TRIGGERS|
        applyTFTriggerPerkEffects(needsToUpdatePortrait)
        applyTFEffectPerkEffects(needsToUpdatePortrait)

        '|ABILITY (SPELL/SPECIAL) HANDLERS|
        applyAbilityPerkEffects(needsToUpdatePortrait)

        '|CURSES|
        applyCursePerkEffects(needsToUpdatePortrait)

        description = CStr(name & " is a " & sex & " " & pForm.name & " " & pClass.name)
        Return needsToUpdatePortrait
    End Function
    Protected Sub applyMiscPerkEffects(ByRef needsToUpdatePortrait As Boolean)
        '| - Stamina (Hunger) Depletion - |
        If perks(perk.hunger) > -1 And Game.getTurn Mod 5 = 0 Then
            PerkEffects.staminaEffect(Me)
        End If
        '| - Burn Lingering Damage - |
        If perks(perk.burn) > -1 And Game.getTurn Mod 4 = 0 Then
            PerkEffects.burnEffect(Me)
        End If
        '| - Illuminate Linger - |
        If perks(perk.lightsource) > -1 Then
            perks(perk.lightsource) -= 1
        End If

        '| - Polymorph Effects - |
        If perks(perk.polymorphed) > -1 And Not ongoingTFs.containsPolymorph() Then
            If perks(perk.polymorphed) = 0 Then revertToPState()
            perks(perk.polymorphed) -= 1
        End If

        '| - Ring of Minor Regen - |
        If perks(perk.minRegen) > -1 Then
            PerkEffects.minorRegen(Me)
        End If
        '| - Ring of Minor Mana Regen - |
        If perks(perk.minmanregen) > -1 Then
            PerkEffects.minorManaRegen(Me)
        End If

        '| - Phase Deflector - |
        If perks(perk.pdeflector) > -1 Then
            PerkEffects.phaseDeflector(Me)
        End If

        '| - Living Armor/Lingerie - |
        If perks(perk.livearm) > -1 Then
            needsToUpdatePortrait = PerkEffects.livingArmor(Me)
        End If
        If perks(perk.livelinge) > -1 Then
            needsToUpdatePortrait = PerkEffects.livingLingerie(Me)
        End If

        '| - Imitation Cowbell Dowse - |
        If Not pClass.name.Equals("Thrall") And forcedPath Is Nothing And prt.checkFemInd(pInd.horns, 12) AndAlso Int(Rnd() * 100) = 0 AndAlso Not Game.combat_engaged AndAlso Not Game.shop_npc_engaged Then
            PerkEffects.imitationCowbell(Me)
        End If

        '| - Cowbell Cleanup - |
        If perks(perk.cowbell) > -1 And Not (equippedAcce.getAName.Equals(Cowbell.ITEM_NAME) Or equippedAcce.getAName.Equals(Bimbell.ITEM_NAME) Or equippedAcce.getAName.Equals(ImmitationCowbell.ITEM_NAME)) Then
            perks(perk.cowbell) = -1
        End If

        '| - Fae Stockings Cleanup - |
        If equippedAcce.getAName.Equals(FaeStockings.ITEM_NAME) And equippedArmor.bind_wearer Then
            Equipment.equipAcce(Me, "Nothing", False)
            TextEvent.pushAndLog("Your accessory vanishes...")
            drawPort()
        End If

        '| - Cynn's Tonic Cleanup - |
        If perks(perk.cynnstonic) > -1 Then
            If Game.turn Mod 5 = 0 Then perks(perk.cynnstonic) -= 1
        End If
        '| - Dark Pact P1 Cleanup - |
        If perks(perk.canmeetcyn) > 0 And Not (formName.Equals("Succubus") Or formName.Equals("Demon") Or formName.Equals("Daemon")) Then
            perks(perk.canmeetcyn) = -1
        End If
    End Sub
    Protected Sub applyClassPerkEffects(ByRef needsToUpdatePortrait As Boolean)
        '| - Amazon - |
        If perks(perk.amazon) > -1 Then
            PerkEffects.amazon(Me)
        End If
        '| - Barbarian - |
        If perks(perk.barbarian) > -1 Then
            PerkEffects.barbarian(Me)
        End If
    End Sub
    Protected Sub applyFormPerkEffects(ByRef needsToUpdatePortrait As Boolean)
        '| - Slime Regen - |
        If perks(perk.slimehair) > -1 Or perks(perk.slimeregenplus) > -1 Then
            PerkEffects.slimeHairRegen(Me)
        End If
        If perks(perk.vsslimehair) > -1 Then
            PerkEffects.vslimeHairRegen(Me)
        End If
        '| - Plantfolk Regen - |
        If pForm.name.Equals("Plantfolk") Then
            PerkEffects.plantRegen(Me)
        End If
    End Sub
    Protected Sub applyTFTriggerPerkEffects(ByRef needsToUpdatePortrait As Boolean)
        '| - Targax Sword TF - |
        If perks(perk.swordpossess) > -1 Then
            PerkEffects.targaxSwordTF(Me)
        End If

        '| - Shift Toward Preferred Form - |
        If Not prefForm Is Nothing AndAlso Transformation.canBeTFed(Me) And (pClass.name = "Thrall" Xor equippedAcce.getName.Equals("Slave_Collar")) AndAlso Not prefForm.playerMeetsForm(Game.player1) And Not pForm.name.Equals("Half-Succubus") And Not perks(perk.thrall) = 1 Then
            PerkEffects.thrallRestore(Me)
        End If

        '| - Petrification - |
        If perks(perk.astatue) > -1 Then
            PerkEffects.aStatue(Me)
        End If

        '| - Magical Girl/Valkyrie Status Checks - |
        If pClass.name.Equals("Magical Girl") And perks(perk.tfedbyweapon) > 0 Then
            PerkEffects.magicGirlStatusCheck(Me)
        End If
        If pClass.name.Contains("Valkyrie") And perks(perk.tfedbyweapon) > 0 Then
            PerkEffects.valkyrieStatusCheck(Me)
        End If
        If perks(perk.tfedbyweapon) < 0 And (perks(perk.tfcausingwand) > -1 Or perks(perk.tfcausingsword) > -1) Then
            perks(perk.tfcausingwand) = -1
            perks(perk.tfcausingsword) = -1
        End If

        '| - Bimbo Mist TF - |
        If (perks(perk.bimbotf) < 0 And Game.currFloor.mBoard(pos.Y, pos.X).Tag > DDConst.PINK_MIST_OFFSET) Or ongoingTFs.contains(tfind.mistbimbo) Then
            PerkEffects.pinkMistTF(Me, Game.currFloor.mBoard(pos.Y, pos.X).Tag)
        End If
    End Sub
    Protected Sub applyTFEffectPerkEffects(ByRef needsToUpdatePortrait As Boolean)
        '| - Cupcake TF - |
        If perks(perk.cupcake) > -1 Then
            If Game.getTurn Mod 20 = 0 Then perks(perk.cupcake) -= 1
        End If
        '| - Space Bun TF - |
        If perks(perk.spacebun) > -1 Then
            If Game.getTurn Mod 20 = 0 Then perks(perk.spacebun) -= 1
        End If
        '| - Bunny Ear TF - |
        If perks(perk.bunnyears) > -1 And equippedAcce.getAName.Equals(BunnyEars.ITEM_NAME) Then
            PerkEffects.bunnyEarsEff(Me)
        End If
        '| - Golden Gum TF - |
        If inv.getCountAt("Golden_Gum") > 0 And Not ongoingTFs.contains(tfind.goldbimbo) And Not className.Equals("Bimbo") Then
            TextEvent.push("A dizzy calm washes over you...")
            ongoingTFs.add(New GBimboTF(2, 20, 0.25, True))
        End If
        '| - Fae Blossom - |
        If equippedAcce.getAName.Equals(FaerieBlossom.ITEM_NAME) And Int(Rnd() * 200) = 0 Then
            PerkEffects.faeleafBloom(Me)
        End If
    End Sub
    Protected Sub applyAbilityPerkEffects(ByRef needsToUpdatePortrait As Boolean)
        '| - Attack Up - |
        If perks(perk.atkup) > -1 Then
            PerkEffects.attackUp(Me)
        End If
        '| - Guard Up - |
        If perks(perk.guardup) > -1 Then
            PerkEffects.guardUp(Me)
        End If
        '| - Will Up - |
        If perks(perk.willup) > -1 Then
            PerkEffects.willUp(Me)
        End If

        '| - Berserker Rage - |
        If perks(perk.brage) > -1 Then
            PerkEffects.berserkerRage(Me)
        End If
        '| - Lurk - |
        If perks(perk.lurk) > -1 Then
            PerkEffects.lurk(Me)
        End If

        '| - Massive Mammaries - |
        If perks(perk.mmammaries) > -1 Then
            PerkEffects.massiveMammaries(Me)
        End If
        '| - Pillowy Protect - |
        If perks(perk.pprot) > -1 Then
            PerkEffects.pProt(Me)
        End If

        '| - Ironhide Fury - |
        If perks(perk.ihfury) > -1 Then
            PerkEffects.ironhideFury(Me)
        End If
        '| - Inferno Aura - |
        If perks(perk.infernoa) > -1 Then
            PerkEffects.infernoAura(Me)
        End If
        '| - Mana Burst - |
        If perks(perk.mburst) > -1 And Game.getTurn Mod 4 = 0 Then
            PerkEffects.mBurst(Me)
        End If

        '| - Spot Fusion Cooldown - |
        If perks(perk.isspotfused) > -1 Then
            perks(perk.isspotfused) -= 1
            If perks(perk.isspotfused) < 1 Then perks(perk.isspotfused) = -1
        End If

        '| - Eye of Medusa - |
        If Game.combat_engaged And equippedAcce.getAName.Equals(MedusaEye.ITEM_NAME) And Not currTarget Is Nothing Then
            Dim s = New MedusaEyePassive(Me, currTarget)
            s.cast()
        End If
    End Sub
    Protected Sub applyCursePerkEffects(ByRef needsToUpdatePortrait As Boolean)
        '| - Clothing Curse - |
        If perks(perk.slutcurse) > -1 AndAlso equippedArmor.getAntiSlutInd = -1 Then
            needsToUpdatePortrait = Equipment.clothingCurse1(Me)
        End If
        '| - Curse of Rust - |
        If perks(perk.corust) > -1 Then
            needsToUpdatePortrait = PerkEffects.curseOfRust(Me)
        End If
        '| - Curse of Milk - |
        If perks(perk.comilk) > -1 Then
            needsToUpdatePortrait = PerkEffects.curseOfMilk(Me)
        End If
        '| - Curse of Random Polymorph - |
        If perks(perk.copoly) > -1 Then
            needsToUpdatePortrait = PerkEffects.curseOfPolymorph(Me)
        End If
        '| - Curse of Blindness - |
        If perks(perk.coblind) > -1 And Not perks(perk.blind) > -1 Then
            perks(perk.blind) = 1
        End If
        '| - Succubus Curse - |
        If perks(perk.succubuscurse) > -1 Then
            PerkEffects.curseOfBimbo(Me)
        End If
        '| - Cryptic Cursemark - |
        If Not equippedAcce Is Nothing AndAlso equippedAcce.getAName.Equals(SPCursemark.ITEM_NAME) Then
            PerkEffects.crypticCursemark(Me)
        End If
    End Sub

    '|UI METHODS|
    Sub keepStatsInBounds()
        '|HEALTH|
        If Not Game.combat_engaged And Not solFlag Then health = Math.Min(1, health)

        '|MANA|
        If Not Game.combat_engaged And Not solFlag Then mana = Math.Min(mana, getMaxMana)
        mana = Math.Max(0, mana)

        '|STAMINA|
        stamina = Math.Max(0, stamina)
        stamina = Math.Min(100, stamina)
        If stamina < 1 Then perks(perk.hunger) = 1 Else perks(perk.hunger) = -1

        '|STATS|
        attack = Math.Max(1, attack)

        defense = Math.Max(1, defense)

        speed = Math.Max(1, speed)

        will = Math.Max(0, will)

        lust = Math.Min(100, lust)
        lust = Math.Max(0, lust)
        If perks(perk.cmark) > -1 Then lust = Math.Max((mana / getMaxMana()) * 100, lust)
    End Sub
    Sub UIupdate(Optional do_inv As Boolean = True)
        'Dim startTime As Double = DDDateTime.getTimeNow()
        keepStatsInBounds()

        If Game.lblNameTitle.Text <> name & " the " & pClass.name Then Game.lblNameTitle.Text = name & " the " & pClass.name

        Game.lblHealth.Text = DDUtils.statBar(getIntHealth, getMaxHealth, Game.lblHealth)
        Game.lblHealth.ForeColor = Game.getHPColor(getHealth)

        Game.lblMana.Text = DDUtils.statBar(getMana, getMaxMana, Game.lblMana)

        Game.lblstamina.Text = DDUtils.statBar(stamina, 100, Game.lblstamina)

        Game.lblXP.Text = DDUtils.statBar(xp, nextLevelXp, Game.lblXP)

        Dim formatted_lvl_text = DDConst.STATNAME_LEVEL & " = " & DDUtils.formatBigNumber(level)
        Dim formatted_atk_text = DDConst.STATNAME_ATK & " = " & DDUtils.formatBigNumber(getATK())
        Dim formatted_def_text = DDConst.STATNAME_DEF & " = " & DDUtils.formatBigNumber(getDEF())
        Dim formatted_spd_text = DDConst.STATNAME_SPD & " = " & DDUtils.formatBigNumber(getSPD())
        Dim formatted_wil_text = DDConst.STATNAME_WILL & " = " & DDUtils.formatBigNumber(getWIL())
        Dim formatted_lus_text = DDConst.STATNAME_LUST & " = " & DDUtils.formatBigNumber(getLust())
        Dim formatted_gld_text = DDConst.STATNAME_GOLD & " = " & DDUtils.formatBigNumber(gold)


        If Not Game.lblLevel.Text.Equals(formatted_lvl_text) Then Game.lblLevel.Text = formatted_lvl_text
        If Not Game.lblATK.Text.Equals(formatted_atk_text) Then Game.lblATK.Text = formatted_atk_text
        If Not Game.lblDEF.Text.Equals(formatted_def_text) Then Game.lblDEF.Text = formatted_def_text
        If Not Game.lblSPD.Text.Equals(formatted_spd_text) Then Game.lblSPD.Text = formatted_spd_text
        If Not Game.lblWIL.Text.Equals(formatted_wil_text) Then Game.lblWIL.Text = formatted_wil_text
        If Not Game.lblLust.Text.Equals(formatted_lus_text) Then Game.lblLust.Text = formatted_lus_text
        If Not Game.lblGold.Text.Equals(formatted_gld_text) Then Game.lblGold.Text = formatted_gld_text

        If do_inv Then
            inv.invIDorder.Clear()
            Dim numItems As Integer = Game.lstInventory.Items.Count
            Dim tArr(inv.count + 16) As String
            Dim ct As Integer = 0
            If InventoryFilterBackend.invFilters(0) Then
                drawInv("-USEABLES:", inv.getUseable, tArr, ct)
            End If
            If InventoryFilterBackend.invFilters(1) Then
                drawInv("-POTIONS:", inv.getPotions, tArr, ct)
            End If
            If InventoryFilterBackend.invFilters(2) Then
                drawInv("-FOOD:", inv.getFood, tArr, ct)
            End If
            If InventoryFilterBackend.invFilters(3) Then
                drawInv("-ARMOR:", inv.getArmors.Item2, tArr, ct)
            End If
            If InventoryFilterBackend.invFilters(4) Then
                drawInv("-WEAPONS:", inv.getWeapons.Item2, tArr, ct)
            End If
            If InventoryFilterBackend.invFilters(6) Then
                drawInv("-ACCESSORIES:", inv.getAccesories.Item2, tArr, ct)
            End If
            If InventoryFilterBackend.invFilters(7) Then
                drawInv("-GLASSES:", inv.getGlasses.Item2, tArr, ct)
            End If
            If InventoryFilterBackend.invFilters(5) Then
                drawInv("-MISC:", inv.getMisc, tArr, ct)
            End If
            If ct <> numItems Or inv.invNeedsUDate Then
                Game.lstInventory.Items.Clear()
                For Each invItem In tArr
                    If Not invItem Is Nothing Then
                        Game.lstInventory.Items.Add(invItem)
                    End If
                Next
            End If
            inv.invNeedsUDate = False
        End If

        'Dim endTime = DDDateTime.getTimeNow()
        'Console.WriteLine(" - UI UPDATE TIME: " + (endTime - startTime).ToString())
    End Sub
    Sub drawInv(ByVal heading As String, ByRef list() As Item, ByRef tArr() As String, ByRef ct As Integer)
        'Keep track of the starting count for later use in checking what has been added
        Dim starting_ct As Integer = ct

        'Add the category heading
        tArr(ct) = heading
        inv.invIDorder.Add(-1)
        ct += 1

        'Add all items for the given category that the player has at least one copy of
        Array.Sort(list)
        For i = 0 To UBound(list)
            If list(i).getCount > 0 And Not (heading = "-USEABLES:" And Not list(i).getUsable) Then
                tArr(ct) = " " & list(i).getName().Replace("_", " ") & " x" & list(i).count
                inv.invIDorder.Add(list(i).getId)
                ct += 1
            End If
        Next

        'If we're still at the starting count, the inventory heading is empty and we should ignore it
        If ct = starting_ct + 1 Then
            tArr(ct) = ""

            If ct = 2 Then
                inv.invIDorder.RemoveAt(inv.invIDorder.Count() - 1)
                inv.invIDorder.RemoveAt(inv.invIDorder.Count() - 1)
                ct -= 2
            ElseIf ct = 1 Then
                inv.invIDorder.RemoveAt(inv.invIDorder.Count() - 1)
                ct -= 1
            End If

        End If

        'Add a new line space to the inventory
        tArr(ct) = ""
        inv.invIDorder.Add(-1)
        ct += 1
    End Sub

    '|TILE IMAGE RENDEDRING|
    Public Sub setPlayerImage()
        'Dim startTime As Double = DDDateTime.getTimeNow()
        Select Case True
            Case isPetrified
                player_image = getStatueTileImage()
            Case formName.Equals("Archdemoness"), formName.Equals("Demon"), formName.Equals("Daemon")
                player_image = getDemonTileImage()
            Case formName.Equals("Succubus")
                player_image = getSuccubusTileImage()
            Case formName.Equals("Dragon")
                player_image = getDragonTileImage()
            Case formName.Equals("Broodmother")
                player_image = getBroodmotherTileImage()
            Case formName.Equals("Horse")
                player_image = getHorseTileImage()
            Case formName.Equals("Unicorn")
                player_image = getUnicornTileImage()
            Case formName.Equals("Cow")
                player_image = getCowTileImage()
            Case formName.Equals("Sheep")
                player_image = getSheepTileImage()
            Case formName.Equals("Frog")
                player_image = getFrogTileImage()
            Case formName.Equals("Blob")
                player_image = getBlobTileImage()
            Case className.Contains("Bimbo")
                player_image = getBimboTileImage()
            Case className.Equals("Thong​")
                player_image = getItemTileImage()
            Case Else
                player_image = getPlayerTileImage()
        End Select
        Dim endTime = DDDateTime.getTimeNow()
        'Console.WriteLine(" - SET PLAYER_IMAGE TIME: " + (endTime - startTime).ToString())
    End Sub
    Private Function getPlayerTileImage() As Image
        Select Case Game.mDun.numCurrFloor
            Case 6, 7, 8, 9, 10, 11, 12
                Return mTile.imgLib.getImg(tSet.forest, tile.player)
            Case 13
                Return mTile.imgLib.getImg(tSet.fogforest, tile.player)
            Case 14
                Return mTile.imgLib.getImg(tSet.hub, tile.player)
                'Case 15
                '    Return mTile.imgLib.getImg(tSet.desert, tile.player)
            Case 9999, 10000
                Return mTile.imgLib.getImg(tSet.space, tile.player)
            Case 91017
                Return mTile.imgLib.getImg(tSet.legacy, tile.player)
            Case 91018
                Return mTile.imgLib.getImg(tSet.caveh, tile.player)
            Case Is > 14
                Return mTile.imgLib.getImg(tSet.hub, tile.player)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.player)
        End Select
    End Function
    Private Function getBimboTileImage() As Image
        Select Case Game.mDun.numCurrFloor
            Case 6, 7, 8, 9, 10, 11, 12
                Return mTile.imgLib.getImg(tSet.forest, tile.bimbo)
            Case 13
                Return mTile.imgLib.getImg(tSet.fogforest, tile.bimbo)
            Case 14
                Return mTile.imgLib.getImg(tSet.hub, tile.bimbo)
                'Case 15
                '    Return mTile.imgLib.getImg(tSet.desert, tile.bimbo)
            Case 9999, 10000
                Return mTile.imgLib.getImg(tSet.space, tile.bimbo)
            Case 91017
                Return mTile.imgLib.getImg(tSet.legacy, tile.bimbo)
            Case 91018
                Return mTile.imgLib.getImg(tSet.caveh, tile.bimbo)
            Case Is > 14
                Return mTile.imgLib.getImg(tSet.hub, tile.bimbo)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.bimbo)
        End Select
    End Function
    Private Function getStatueTileImage() As Image
        Select Case Game.mDun.numCurrFloor
            Case 6, 7, 8, 9, 10, 11, 12
                Return mTile.imgLib.getImg(tSet.forest, tile.statue)
            Case 13
                If perks(perk.faequestatue) > 0 Then Return mTile.imgLib.getImg(tSet.fogforest, tile.extra3) Else Return mTile.imgLib.getImg(tSet.fogforest, tile.statue)
            Case 14
                Return mTile.imgLib.getImg(tSet.hub, tile.statue)
                'Case 15
                '    Return mTile.imgLib.getImg(tSet.desert, tile.statue)
            Case 9999, 10000
                Return mTile.imgLib.getImg(tSet.space, tile.statue)
            Case 91017
                Return mTile.imgLib.getImg(tSet.legacy, tile.statue)
            Case 91018
                Return mTile.imgLib.getImg(tSet.caveh, tile.statue)
            Case Is > 14
                Return mTile.imgLib.getImg(tSet.hub, tile.statue)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.statue)
        End Select
    End Function
    Private Function getDemonTileImage() As Image
        Select Case Game.mDun.numCurrFloor
            Case 6, 7, 8, 9, 10, 11, 12
                Return mTile.imgLib.getImg(tSet.forest, tile.demon)
            Case 13
                Return mTile.imgLib.getImg(tSet.fogforest, tile.demon)
            Case 14
                Return mTile.imgLib.getImg(tSet.hub, tile.demon)
                'Case 15
                '    Return mTile.imgLib.getImg(tSet.desert, tile.demon)
            Case 9999, 10000
                Return mTile.imgLib.getImg(tSet.space, tile.demon)
            Case 91017
                Return mTile.imgLib.getImg(tSet.legacy, tile.demon)
            Case 91018
                Return mTile.imgLib.getImg(tSet.caveh, tile.demon)
            Case Is > 14
                Return mTile.imgLib.getImg(tSet.hub, tile.demon)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.demon)
        End Select
    End Function
    Private Function getSuccubusTileImage() As Image
        Select Case Game.mDun.numCurrFloor
            Case 6, 7, 8, 9, 10, 11, 12
                Return mTile.imgLib.getImg(tSet.forest, tile.succubus)
            Case 13
                Return mTile.imgLib.getImg(tSet.fogforest, tile.succubus)
            Case 14
                Return mTile.imgLib.getImg(tSet.hub, tile.succubus)
                'Case 15
                '    Return mTile.imgLib.getImg(tSet.desert, tile.succubus)
            Case 9999, 10000
                Return mTile.imgLib.getImg(tSet.space, tile.succubus)
            Case 91017
                Return mTile.imgLib.getImg(tSet.legacy, tile.succubus)
            Case 91018
                Return mTile.imgLib.getImg(tSet.caveh, tile.succubus)
            Case Is > 14
                Return mTile.imgLib.getImg(tSet.hub, tile.succubus)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.succubus)
        End Select
    End Function
    Private Function getDragonTileImage() As Image
        Select Case Game.mDun.numCurrFloor
            Case 6, 7, 8, 9, 10, 11, 12
                Return mTile.imgLib.getImg(tSet.forest, tile.dragon)
            Case 13
                Return mTile.imgLib.getImg(tSet.fogforest, tile.dragon)
            Case 14
                Return mTile.imgLib.getImg(tSet.hub, tile.dragon)
                'Case 15
                '    Return mTile.imgLib.getImg(tSet.desert, tile.dragon)
            Case 9999, 10000
                Return mTile.imgLib.getImg(tSet.space, tile.dragon)
            Case 91017
                Return mTile.imgLib.getImg(tSet.legacy, tile.dragon)
            Case 91018
                Return mTile.imgLib.getImg(tSet.caveh, tile.dragon)
            Case Is > 14
                Return mTile.imgLib.getImg(tSet.hub, tile.dragon)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.dragon)
        End Select
    End Function
    Private Function getBroodmotherTileImage() As Image
        Select Case Game.mDun.numCurrFloor
            Case 6, 7, 8, 9, 10, 11, 12
                Return mTile.imgLib.getImg(tSet.forest, tile.broodmother)
            Case 13
                Return mTile.imgLib.getImg(tSet.fogforest, tile.broodmother)
            Case 14
                Return mTile.imgLib.getImg(tSet.hub, tile.broodmother)
                'Case 15
                '    Return mTile.imgLib.getImg(tSet.desert, tile.broodmother)
            Case 9999, 10000
                Return mTile.imgLib.getImg(tSet.space, tile.broodmother)
            Case 91017
                Return mTile.imgLib.getImg(tSet.legacy, tile.broodmother)
            Case 91018
                Return mTile.imgLib.getImg(tSet.caveh, tile.broodmother)
            Case Is > 14
                Return mTile.imgLib.getImg(tSet.hub, tile.broodmother)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.broodmother)
        End Select
    End Function
    Private Function getHorseTileImage() As Image
        Select Case Game.mDun.numCurrFloor
            Case 6, 7, 8, 9, 10, 11, 12
                Return mTile.imgLib.getImg(tSet.forest, tile.horse)
            Case 13
                Return mTile.imgLib.getImg(tSet.fogforest, tile.horse)
            Case 14
                Return mTile.imgLib.getImg(tSet.hub, tile.horse)
                'Case 15
                '    Return mTile.imgLib.getImg(tSet.desert, tile.horse)
            Case 9999, 10000
                Return mTile.imgLib.getImg(tSet.space, tile.horse)
            Case 91017
                Return mTile.imgLib.getImg(tSet.legacy, tile.horse)
            Case 91018
                Return mTile.imgLib.getImg(tSet.caveh, tile.horse)
            Case Is > 14
                Return mTile.imgLib.getImg(tSet.hub, tile.horse)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.horse)
        End Select
    End Function
    Private Function getUnicornTileImage() As Image
        Select Case Game.mDun.numCurrFloor
            Case 6, 7, 8, 9, 10, 11, 12
                Return mTile.imgLib.getImg(tSet.forest, tile.unicorn)
            Case 13
                Return mTile.imgLib.getImg(tSet.fogforest, tile.unicorn)
            Case 14
                Return mTile.imgLib.getImg(tSet.hub, tile.unicorn)
                'Case 15
                '    Return mTile.imgLib.getImg(tSet.desert, tile.unicorn)
            Case 9999, 10000
                Return mTile.imgLib.getImg(tSet.space, tile.unicorn)
            Case 91017
                Return mTile.imgLib.getImg(tSet.legacy, tile.unicorn)
            Case 91018
                Return mTile.imgLib.getImg(tSet.caveh, tile.unicorn)
            Case Is > 14
                Return mTile.imgLib.getImg(tSet.hub, tile.unicorn)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.unicorn)
        End Select
    End Function
    Private Function getCowTileImage() As Image
        Select Case Game.mDun.numCurrFloor
            Case 6, 7, 8, 9, 10, 11, 12
                Return mTile.imgLib.getImg(tSet.forest, tile.cow)
            Case 13
                Return mTile.imgLib.getImg(tSet.fogforest, tile.cow)
            Case 14
                Return mTile.imgLib.getImg(tSet.hub, tile.cow)
                'Case 15
                '    Return mTile.imgLib.getImg(tSet.desert, tile.cow)
            Case 9999, 10000
                Return mTile.imgLib.getImg(tSet.space, tile.cow)
            Case 91017
                Return mTile.imgLib.getImg(tSet.legacy, tile.cow)
            Case 91018
                Return mTile.imgLib.getImg(tSet.caveh, tile.cow)
            Case Is > 14
                Return mTile.imgLib.getImg(tSet.hub, tile.cow)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.cow)
        End Select
    End Function
    Private Function getSheepTileImage() As Image
        Select Case Game.mDun.numCurrFloor
            Case 6, 7, 8, 9, 10, 11, 12
                Return mTile.imgLib.getImg(tSet.forest, tile.sheep)
            Case 13
                Return mTile.imgLib.getImg(tSet.fogforest, tile.sheep)
            Case 14
                Return mTile.imgLib.getImg(tSet.hub, tile.sheep)
                'Case 15
                '    Return mTile.imgLib.getImg(tSet.desert, tile.sheep)
            Case 9999, 10000
                Return mTile.imgLib.getImg(tSet.space, tile.sheep)
            Case 91017
                Return mTile.imgLib.getImg(tSet.legacy, tile.sheep)
            Case 91018
                Return mTile.imgLib.getImg(tSet.caveh, tile.sheep)
            Case Is > 14
                Return mTile.imgLib.getImg(tSet.hub, tile.sheep)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.sheep)
        End Select
    End Function
    Private Function getFrogTileImage() As Image
        Select Case Game.mDun.numCurrFloor
            Case 6, 7, 8, 9, 10, 11, 12
                Return mTile.imgLib.getImg(tSet.forest, tile.frog)
            Case 13
                Return mTile.imgLib.getImg(tSet.fogforest, tile.frog)
            Case 14
                Return mTile.imgLib.getImg(tSet.hub, tile.frog)
                'Case 15
                '    Return mTile.imgLib.getImg(tSet.desert, tile.frog)
            Case 9999, 10000
                Return mTile.imgLib.getImg(tSet.space, tile.frog)
            Case 91017
                Return mTile.imgLib.getImg(tSet.legacy, tile.frog)
            Case 91018
                Return mTile.imgLib.getImg(tSet.caveh, tile.frog)
            Case Is > 14
                Return mTile.imgLib.getImg(tSet.hub, tile.frog)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.frog)
        End Select
    End Function
    Private Function getBlobTileImage() As Image
        Select Case Game.mDun.numCurrFloor
            Case 6, 7, 8, 9, 10, 11, 12
                Return mTile.imgLib.getImg(tSet.forest, tile.blob)
            Case 13
                Return mTile.imgLib.getImg(tSet.fogforest, tile.blob)
            Case 14
                Return mTile.imgLib.getImg(tSet.hub, tile.blob)
                'Case 15
                '    Return mTile.imgLib.getImg(tSet.desert, tile.blob)
            Case 9999, 10000
                Return mTile.imgLib.getImg(tSet.space, tile.blob)
            Case 91017
                Return mTile.imgLib.getImg(tSet.legacy, tile.blob)
            Case 91018
                Return mTile.imgLib.getImg(tSet.caveh, tile.blob)
            Case Is > 14
                Return mTile.imgLib.getImg(tSet.hub, tile.blob)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.blob)
        End Select
    End Function
    Private Function getItemTileImage() As Image
        Select Case Game.mDun.numCurrFloor
            Case 6, 7, 8, 9, 10, 11, 12
                Return mTile.imgLib.getImg(tSet.forest, tile.item)
            Case 13
                Return mTile.imgLib.getImg(tSet.fogforest, tile.item)
            Case 14
                Return mTile.imgLib.getImg(tSet.hub, tile.item)
                'Case 15
                '    Return mTile.imgLib.getImg(tSet.desert, tile.item)
            Case 9999, 10000
                Return mTile.imgLib.getImg(tSet.space, tile.item)
            Case 91017
                Return mTile.imgLib.getImg(tSet.legacy, tile.item)
            Case 91018
                Return mTile.imgLib.getImg(tSet.caveh, tile.item)
            Case Is > 14
                Return mTile.imgLib.getImg(tSet.hub, tile.item)
            Case Else
                Return mTile.imgLib.getImg(tSet.dungeon, tile.item)
        End Select
    End Function

    '|PORTRAIT IMAGE RENDERING METHODS|
    Function picsAreSame(a As Bitmap, b As Bitmap)
        If a Is Nothing Or b Is Nothing Then Return False
        If Not a.Size.Equals(b.Size) Then Return False

        Dim BM1 As Bitmap = a
        Dim BM2 As Bitmap = b
        For x = 0 To BM1.Width - 1
            For y = 0 To BM2.Height - 1
                If BM1.GetPixel(x, y) <> BM2.GetPixel(x, y) Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function
    Sub oneLayerImgCheck(ByRef b As Boolean)
        If prt.oneLayerImgCheck(pForm.name, pClass.name) Is Nothing Then b = False Else b = True
    End Sub
    Public Sub drawPort()
        reverseAllRoute()
        If Not solFlag Then Game.picPortrait.BackgroundImage = prt.draw(solFlag, isPetrified, AddressOf revertToSState, pForm.name, pClass.name)

        Game.picPortrait.Update()

        If Not currState Is Nothing Then currState.save(Me)

        If Settings.active(setting.textcolors) Then Game.lblEvent.ForeColor = textColor
        Game.lblNameTitle.ForeColor = textColor
        If Not solFlag Then setPlayerImage()
    End Sub
    Public Sub changeHairColor(ByVal c As Color, Optional forceOpacity As Boolean = False)
        If forceOpacity Then
            prt.haircolor = c
        Else
            prt.haircolor = Color.FromArgb(prt.haircolor.A, c.R, c.G, c.B)
        End If

        drawPort()
    End Sub
    Public Sub changeSkinColor(ByVal c As Color)
        prt.skincolor = c
        drawPort()
    End Sub
    Public Sub pout()
        prt.setIAInd(pInd.eyes, 37, True, True)
        prt.setIAInd(pInd.mouth, 20, True, True)
        drawPort()
    End Sub

    'sex change methods
    Public Sub MtF()
        If perks(perk.polymorphed) > -1 Or pClass.name.Equals("Magical Girl") Or className.Contains("Valkyrie") Then
            TextEvent.pushLog("Your form prevents you from being altered.")
            Exit Sub
        End If
        If sex = "Male" Then sex = "Female"
        breastSize = Math.Max(1, breastSize)
        buttSize = Math.Max(1, buttSize)
        dickSize = -1
        idRouteMF()
        If perks(perk.swordpossess) > -1 Then perks(perk.swordpossess) = 0
    End Sub
    Public Sub FtM()
        If perks(perk.polymorphed) > -1 Or pClass.name.Equals("Magical Girl") Or className.Contains("Valkyrie") Then
            TextEvent.pushLog("Your form prevents you from being altered.")
            Exit Sub
        End If
        If sex = "Female" Then sex = "Male"
        breastSize = -1
        buttSize = -1
        dickSize = Math.Max(1, dickSize)
        perks(perk.slutcurse) = -1
        idRouteFM()
        If perks(perk.swordpossess) > -1 Then perks(perk.swordpossess) = 0
    End Sub
    Sub idRouteMF(Optional halfRevertFlag As Boolean = False)
        Dim mfr = Portrait.imgLib.mfEquivalentIndexes
        For Each key In mfr.Keys
            'checks for half reversion
            If Int(Rnd() * 2) = 0 Or Not halfRevertFlag Then
                prt.iArrInd(key) = mfr(key).getFfromM(prt.iArrInd(key))
            End If
        Next

        reverseAllRoute()

        'update the players clothing
        prt.portraitUDate()
    End Sub
    Sub idRouteFM(Optional halfRevertFlag As Boolean = False)
        Dim fmr = Portrait.imgLib.mfEquivalentIndexes
        For Each key In fmr.Keys
            'checks for half reversion
            If Int(Rnd() * 2) = 0 Or Not halfRevertFlag Then
                prt.iArrInd(key) = fmr(key).getMfromF(prt.iArrInd(key))
            End If
        Next

        reverseAllRoute()

        'update the players clothing
        prt.portraitUDate()
    End Sub
    'breast enlargement/reduction methods
    Public Sub be()
        If breastSize >= -2 And breastSize < 7 Then
            breastSize += 1
            reverseBSroute()
            reverseUSRoute()
            TextEvent.pushLog("+ 1 cup size!")
        Else
            TextEvent.pushLog("Your breasts can get no larger!")
        End If
    End Sub
    Public Sub bs()
        If breastSize > -1 And breastSize <= 7 Then
            breastSize -= 1
            reverseBSroute()
            reverseUSRoute()
            TextEvent.pushLog("- 1 cup size!")
        Else
            TextEvent.pushLog("Your breasts can get no smaller!")
        End If
    End Sub
    Sub bsizeroute()
        If Portrait.imgLib Is Nothing Or prt.iArr Is Nothing Or
            prt.iArrInd Is Nothing Or solFlag Then Exit Sub
        If (prt.checkFemInd(pInd.chest, pForm.bsize1.Item1) Or prt.checkFemInd(pInd.chest, 9)) And breastSize <> 1 Then
            breastSize = 1
        ElseIf (prt.checkFemInd(pInd.chest, pForm.bsize2.Item1) Or prt.checkFemInd(pInd.chest, 10)) And breastSize <> 2 Then
            breastSize = 2
        ElseIf (prt.checkFemInd(pInd.chest, pForm.bsize3.Item1) Or prt.checkFemInd(pInd.chest, 11)) And breastSize <> 3 Then
            breastSize = 3
        ElseIf (prt.checkFemInd(pInd.chest, pForm.bsize4.Item1) Or prt.checkFemInd(pInd.chest, 12)) And breastSize <> 4 Then
            breastSize = 4
        ElseIf (prt.checkFemInd(pInd.chest, pForm.bsize5.Item1) Or prt.checkFemInd(pInd.chest, 13)) And breastSize <> 5 Then
            breastSize = 5
        ElseIf (prt.checkFemInd(pInd.chest, pForm.bsize6.Item1) Or prt.checkFemInd(pInd.chest, 14)) And breastSize <> 6 Then
            breastSize = 6
        ElseIf (prt.checkFemInd(pInd.chest, pForm.bsize7.Item1) Or prt.checkFemInd(pInd.chest, 15)) And breastSize <> 7 Then
            breastSize = 7
        ElseIf (prt.checkMalInd(pInd.chest, pForm.bsize0.Item1)) And breastSize <> 0 Then
            breastSize = 0
        ElseIf (prt.checkMalInd(pInd.chest, pForm.bsizeneg2.Item1)) And (prt.checkMalInd(pInd.shoulders, 7)) And breastSize <> -2 Then
            breastSize = -2
        ElseIf (prt.checkMalInd(pInd.chest, pForm.bsizeneg1.Item1)) And breastSize <> -1 Then
            breastSize = -1
        End If
    End Sub
    Public Sub reverseBSroute(Optional ByVal shoulderFlag = True)
        Select Case breastSize
            Case -2
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 7, False, False)
                prt.setIAInd(pInd.chest, pForm.bsizeneg2)
                buttSize = -2
            Case -1
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 0, False, False)
                prt.setIAInd(pInd.chest, pForm.bsizeneg1)
                buttSize = -1
            Case 0
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 1, False, False)
                prt.setIAInd(pInd.chest, pForm.bsize0)
                buttSize = 0
            Case 1
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 2, True, False)
                prt.setIAInd(pInd.chest, pForm.bsize1)
                If buttSize < 1 Then buttSize = 1
            Case 2
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 2, True, False)
                prt.setIAInd(pInd.chest, pForm.bsize2)
                If buttSize < 1 Then buttSize = 1
            Case 3
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 2, True, False)
                prt.setIAInd(pInd.chest, pForm.bsize3)
                If buttSize < 1 Then buttSize = 1
            Case 4
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 2, True, False)
                prt.setIAInd(pInd.chest, pForm.bsize4)
                If buttSize < 1 Then buttSize = 1
            Case 5
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 2, True, False)
                prt.setIAInd(pInd.chest, pForm.bsize5)
                If buttSize < 1 Then buttSize = 1
            Case 6
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 2, True, False)
                prt.setIAInd(pInd.chest, pForm.bsize6)
                If buttSize < 1 Then buttSize = 1
            Case 7
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 2, True, False)
                prt.setIAInd(pInd.chest, pForm.bsize7)
                If buttSize < 1 Then buttSize = 1
        End Select
        prt.portraitUDate()
    End Sub
    'dick enlargement/reduction methods
    Public Sub de()
        If dickSize >= -1 And dickSize < 3 Then
            dickSize += 1
            reverseAllRoute()
            TextEvent.pushLog("+ dick size!")
        Else
            TextEvent.pushLog("Your dick can get no larger!")
        End If
    End Sub
    Public Sub ds()
        If dickSize > -1 And dickSize <= 3 Then
            dickSize -= 1
            reverseDSRoute()
            TextEvent.pushLog("- dick size!")
        Else
            TextEvent.pushLog("You no longer have a dick!")
        End If
    End Sub
    Sub dsizeroute()
        If Portrait.imgLib Is Nothing Or prt.iArr Is Nothing Or
            prt.iArrInd Is Nothing Or solFlag Then Exit Sub
        If prt.checkFemInd(pInd.genitalia, 4) And dickSize <> -1 Then
            dickSize = -1
        ElseIf prt.checkMalInd(pInd.genitalia, 0) And dickSize <> 0 Then
            dickSize = 0
        ElseIf prt.checkMalInd(pInd.genitalia, 1) And dickSize <> 1 Then
            dickSize = 1
        ElseIf prt.checkMalInd(pInd.genitalia, 2) And dickSize <> 2 Then
            dickSize = 2
        ElseIf prt.checkMalInd(pInd.genitalia, 3) And dickSize <> 3 Then
            dickSize = 3
        End If
    End Sub
    Public Sub reverseDSRoute()
        Select Case dickSize
            Case -1
                prt.setIAInd(pInd.genitalia, 4, True, False)
            Case 0
                prt.setIAInd(pInd.genitalia, 0, True, False)
            Case 1
                prt.setIAInd(pInd.genitalia, 1, True, False)
            Case 2
                prt.setIAInd(pInd.genitalia, 2, True, False)
            Case 3
                prt.setIAInd(pInd.genitalia, 3, True, False)
        End Select
        prt.portraitUDate()
    End Sub
    'butt enlargement/reduction methods
    Public Sub ue()
        If buttSize >= -2 And buttSize < 5 Then
            buttSize += 1
            reverseUSRoute()
            If equippedArmor.bind_wearer Then reverseBSroute(False) Else reverseBSroute()
            TextEvent.pushLog("+ 1 butt size!")
        Else
            TextEvent.pushLog("Your ass can get no larger!")
        End If
    End Sub
    Public Sub us()
        If buttSize > -1 And buttSize <= 5 Then
            buttSize -= 1
            reverseUSRoute()
            If equippedArmor.bind_wearer Then reverseBSroute(False) Else reverseBSroute()
            TextEvent.pushLog("- 1 butt size!")
        Else
            TextEvent.pushLog("Your butt can get no smaller!")
        End If
    End Sub
    Sub usizeroute()
        If equippedArmor.bind_wearer Then uBsizeroute() : Exit Sub
        If Portrait.imgLib Is Nothing Or prt.iArr Is Nothing Or
            prt.iArrInd Is Nothing Or solFlag Then Exit Sub
        If prt.checkNDefMalInd(pInd.body, 5) And buttSize <> -2 Then
            buttSize = -2
        ElseIf prt.checkMalInd(pInd.body, 0) And buttSize <> -1 Then
            buttSize = -1
        ElseIf prt.checkNDefMalInd(pInd.body, 1) And buttSize <> 0 Then
            buttSize = 0
        ElseIf prt.checkFemInd(pInd.body, 0) And buttSize <> 1 Then
            buttSize = 1
        ElseIf prt.checkNDefFemInd(pInd.body, 1) And buttSize <> 2 Then
            buttSize = 2
        ElseIf prt.checkNDefFemInd(pInd.body, 2) And buttSize <> 3 Then
            buttSize = 3
        ElseIf prt.checkNDefFemInd(pInd.body, 3) And buttSize <> 4 Then
            buttSize = 4
        ElseIf prt.checkNDefFemInd(pInd.body, 4) And buttSize <> 5 Then
            buttSize = 5
        End If
    End Sub
    Public Sub reverseUSRoute()
        If equippedArmor.bind_wearer Then reverseUBSRoute() : Exit Sub
        'If formName.Equals("Blowup Doll") Then prt.setIAInd(pInd.body, 9, True, True) : Exit Sub

        Select Case buttSize
            Case -2
                prt.setIAInd(pInd.body, 5, False, False)
                breastSize = -2
            Case -1
                prt.setIAInd(pInd.body, 0, False, False)
                breastSize = -1
            Case 0
                prt.setIAInd(pInd.body, 2, False, True)
                breastSize = 0
            Case 1
                prt.setIAInd(pInd.body, 0, True, False)
                If breastSize < 1 Then breastSize = 1
            Case 2
                prt.setIAInd(pInd.body, 1, True, True)
                If breastSize < 1 Then breastSize = 1
            Case 3
                prt.setIAInd(pInd.body, 2, True, True)
                If breastSize < 1 Then breastSize = 1
            Case 4
                prt.setIAInd(pInd.body, 3, True, True)
                If breastSize < 1 Then breastSize = 1
            Case 5
                prt.setIAInd(pInd.body, 4, True, True)
                If breastSize < 1 Then breastSize = 1
        End Select
        prt.portraitUDate()
    End Sub
    'bondage butt enlargement/reduction methods
    Sub uBsizeroute()
        If Portrait.imgLib Is Nothing Or prt.iArr Is Nothing Or
            prt.iArrInd Is Nothing Or solFlag Then Exit Sub
        If prt.checkNDefMalInd(pInd.body, 4) And buttSize <> -1 Then
            buttSize = -1
        ElseIf prt.checkNDefFemInd(pInd.body, 5) And buttSize <> 0 Then
            buttSize = 0
        ElseIf prt.checkNDefFemInd(pInd.body, 6) And buttSize <> 1 Then
            buttSize = 1
        ElseIf prt.checkNDefFemInd(pInd.body, 7) And buttSize <> 2 Then
            buttSize = 2
        ElseIf prt.checkNDefFemInd(pInd.body, 8) And buttSize <> 3 Then
            buttSize = 3
        ElseIf prt.checkNDefFemInd(pInd.body, 9) And buttSize <> 4 Then
            buttSize = 4
        End If
    End Sub
    Public Sub reverseUBSRoute()
        Select Case buttSize
            Case -1
                prt.setIAInd(pInd.body, 4, False, True)
                prt.setIAInd(pInd.shoulders, 3, False, False)
                breastSize = -1
            Case 0
                prt.setIAInd(pInd.body, 5, True, True)
                prt.setIAInd(pInd.shoulders, 4, False, False)
                breastSize = 0
            Case 1
                prt.setIAInd(pInd.body, 6, True, False)
                prt.setIAInd(pInd.shoulders, 5, False, False)
                If breastSize < 1 Then breastSize = 1
            Case 2
                prt.setIAInd(pInd.body, 7, True, True)
                prt.setIAInd(pInd.shoulders, 5, False, False)
                If breastSize < 1 Then breastSize = 1
            Case 3
                prt.setIAInd(pInd.body, 8, True, True)
                prt.setIAInd(pInd.shoulders, 5, False, False)
                If breastSize < 1 Then breastSize = 1
            Case 4
                prt.setIAInd(pInd.body, 9, True, True)
                prt.setIAInd(pInd.shoulders, 5, False, False)
                If breastSize < 1 Then breastSize = 1
            Case 5
                prt.setIAInd(pInd.body, 9, True, True)
                prt.setIAInd(pInd.shoulders, 5, False, False)
                If breastSize < 1 Then breastSize = 1
        End Select
    End Sub

    Public Overrides Sub addLust(ByVal i As Integer)
        lust += i
        lust = Math.Max(lust, 0)
        lust = Math.Min(lust, 100)
        drawPort()
    End Sub

    Public Sub allRoute()
        bsizeroute()
        dsizeroute()
        usizeroute()
    End Sub
    Public Sub reverseAllRoute()
        reverseBSroute()
        reverseDSRoute()
        reverseUSRoute()
    End Sub

    '|SAVE METHODS|
    Public Function toGhost() As String
        Dim output = CStr(
            name & " the " & pClass.name & "*" &
            Game.currFloor.floorCode & "*" &
            pClass.name & "*" &
            health & "*" &
            getMaxHealth() & "*" &
            getATK() & "*" &
            getMaxMana() & "*" &
            getDEF() & "*" &
            getSPD() & "*" &
            getWIL() & "*" &
            prt.sexBool & "*" &
            prt.iArrInd(pInd.eyes).Item1 & "*" &
            prt.iArrInd(pInd.eyes).Item2 & "*" &
            prt.iArrInd(pInd.eyes).Item3 & "*" &
            prt.haircolor.R & "*" &
            prt.haircolor.G & "*" &
            prt.haircolor.B & "*")
        output += inv.save
        Return output
    End Function

    '|GETTER/SETTER METHODS|
    Public Function getGreatestStatname() As String
        Dim modded_maxhealth As Integer = maxHealth / 10
        Dim modded_maxmana = maxMana / 5

        If modded_maxhealth > modded_maxmana And modded_maxhealth > attack And modded_maxhealth > defense And modded_maxhealth > speed And modded_maxhealth > will Then
            Return DDConst.STATNAME_HP
        ElseIf modded_maxmana > modded_maxhealth And modded_maxmana > attack And modded_maxmana > defense And modded_maxmana > speed And modded_maxmana > will Then
            Return DDConst.STATNAME_MP
        ElseIf attack > modded_maxhealth And attack > modded_maxmana And attack > defense And attack > speed And attack > will Then
            Return DDConst.STATNAME_ATK
        ElseIf defense > modded_maxhealth And defense > modded_maxmana And defense > attack And defense > speed And defense > will Then
            Return DDConst.STATNAME_DEF
        ElseIf speed > modded_maxhealth And speed > modded_maxmana And speed > attack And speed > defense And speed > will Then
            Return DDConst.STATNAME_SPD
        ElseIf will > modded_maxhealth And will > modded_maxmana And will > attack And will > defense And will > speed Then
            Return DDConst.STATNAME_WILL
        End If

        If (attack + speed) > (defense + modded_maxhealth) And (attack + speed) > (will + modded_maxmana) Then
            Return DDConst.STATNAME_ATK
        ElseIf (defense + modded_maxhealth) > (attack + speed) And (defense + modded_maxhealth) > (will + modded_maxmana) Then
            Return DDConst.STATNAME_DEF
        ElseIf (will + modded_maxmana) > (attack + speed) And (will + modded_maxmana) > (defense + modded_maxhealth) Then
            Return DDConst.STATNAME_WILL
        End If

        Return DDConst.STATNAME_HP
    End Function
    Overrides Function getMaxHealth() As Integer
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Or equippedAcce Is Nothing Then Return CInt(maxHealth * pForm.h * pForm.h) + hBuff
        Return CInt((maxHealth + hBuff) * pClass.h * pForm.h) + equippedArmor.getHBoost(Me) + equippedWeapon.getHBoost(Me) + equippedAcce.getHBoost(Me) + equippedGlasses.getHBoost(Me)
    End Function
    Overrides Function getMaxMana() As Integer
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Or equippedAcce Is Nothing Then Return CInt(maxMana * pForm.m * pForm.m) + mBuff + PerkEffects.dragonBoobsMana(Me)
        Return Math.Max(0, CInt((maxMana + mBuff) * pForm.m * pForm.m) + equippedArmor.getMBoost(Me) + equippedWeapon.getMBoost(Me) + equippedAcce.getMBoost(Me) + equippedGlasses.getMBoost(Me) + PerkEffects.dragonBoobsMana(Me))
    End Function
    Overrides Function getATK() As Integer
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Or equippedAcce Is Nothing Then Return CInt(attack * pForm.a * pClass.a) + aBuff
        Return CInt((attack + aBuff) * pForm.a * pClass.a) + equippedArmor.getABoost(Me) + equippedWeapon.getABoost(Me) + equippedAcce.getABoost(Me) + equippedGlasses.getABoost(Me)
    End Function
    Overrides Function getDEF() As Integer
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Or equippedAcce Is Nothing Then Return CInt(defense * pClass.d * pForm.d) + dBuff
        Return CInt((defense + dBuff) * pClass.d * pForm.d) + equippedArmor.getDBoost(Me) + equippedWeapon.getDBoost(Me) + equippedAcce.getDBoost(Me) + equippedGlasses.getDBoost(Me)
    End Function
    Overrides Function getSPD() As Integer
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Or equippedAcce Is Nothing Then Return CInt(speed * pClass.s * pForm.s) + sBuff
        Return CInt((speed + sBuff) * pClass.s * pForm.s) + equippedArmor.getSBoost(Me) + equippedWeapon.getSBoost(Me) + equippedAcce.getSBoost(Me) + equippedGlasses.getSBoost(Me)
    End Function
    Overrides Function getWIL() As Integer
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Or equippedAcce Is Nothing Then Return CInt(will * pClass.w * pForm.w) + wBuff
        Return CInt((will + wBuff) * pClass.w * pForm.w) + equippedArmor.getWBoost(Me) + equippedWeapon.getWBoost(Me) + equippedAcce.getWBoost(Me) + equippedGlasses.getWBoost(Me)
    End Function
    Public Function passDieRoll(ByVal d As Integer, Optional ByVal lessthanPass As Integer = 1, Optional ByVal savingThrow As Boolean = False) As Boolean
        Dim rollPassed As Boolean = (Int(Rnd() * d) + 1) <= lessthanPass

        If Not rollPassed AndAlso (perks(perk.lucky7) > -1 Or savingThrow) Then Return (passDieRoll(d, lessthanPass, False))

        Return rollPassed
    End Function
    Public Function className() As String
        Return pClass.name
    End Function
    Public Function formName() As String
        Return pForm.name
    End Function

    '|DESCRIPTION GENERATION METHODS|
    Shared Function getColor(ByVal clr As Color) As String
        Dim c As Color

        Dim DirtyBlonde = Color.FromArgb(255, 186, 163, 0)

        Dim cArr As Color() = {Color.Aqua, Color.Aquamarine, Color.Azure, _
                               Color.Beige, Color.Black, Color.Blue, Color.BlueViolet, Color.Brown, _
                               Color.Chartreuse, Color.Coral, Color.CornflowerBlue, Color.Crimson, Color.Cyan, _
                               Color.DarkBlue, Color.DarkCyan, Color.DarkGreen, Color.DarkMagenta, Color.DarkRed, Color.DarkSeaGreen, Color.DarkSlateBlue, Color.DarkTurquoise, Color.DarkViolet,
                               DirtyBlonde, _
                               Color.Fuchsia, _
                               Color.Gold, Color.Gray, Color.Green, Color.GreenYellow, _
                               Color.Honeydew, Color.HotPink, _
                               Color.Indigo, _
                               Color.Lavender, Color.LawnGreen, Color.LightBlue, Color.LightGray, Color.LightGreen, Color.LightPink, Color.LightSeaGreen, Color.LightSkyBlue, Color.LightSteelBlue, Color.LightYellow, Color.Lime, _
                               Color.Magenta, Color.Maroon, Color.MidnightBlue, Color.MintCream, Color.MediumPurple, Color.MediumOrchid, _
                               Color.Navy, _
                               Color.Orange, Color.OrangeRed, Color.Orchid, _
                               Color.Pink, Color.Purple, Color.PowderBlue, Color.Plum, Color.PaleVioletRed, _
                               Color.Red, Color.RosyBrown, _
                               Color.SeaGreen, Color.Silver, Color.Sienna, Color.SteelBlue, _
                               Color.Tan, Color.Teal, Color.Turquoise, _
                               Color.Wheat, Color.White, _
                               Color.Yellow}
        Dim closest As Double = 99999999999999
        For i = 0 To UBound(cArr)
            Dim ratio = isShadeOf(clr.R, clr.G, clr.B, cArr(i))
            If ratio < closest Then
                closest = ratio
                c = cArr(i)
            End If
        Next

        Dim mc As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(c.Name, "[A-Z][a-z]*")
        Dim out = ""
        For Each m As System.Text.RegularExpressions.Match In mc
            out += m.ToString
            out += " "
        Next
        If out.Equals("Beige ") Or out.Equals("Wheat ") Then out = "Light Blonde "
        If c.Equals(DirtyBlonde) Then out = "Dirty Blonde "

        Return out.ToLower
    End Function
    Shared Function isShadeOf(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer, ByVal c As Color) As Double
        Dim ratio1, ratio2, ratio3
        Dim totalDelta = 0
        ratio1 = (Math.Abs(r - c.R) ^ 3) * 5
        ratio2 = (Math.Abs(g - c.G) ^ 3) * 5
        ratio3 = (Math.Abs(b - c.B) ^ 3) * 5
        totalDelta += ratio1 + ratio2 + ratio3

        Return totalDelta
    End Function
    Function getHairColor() As String
        Return getColor(prt.haircolor)
    End Function
    Function getSkinColor() As String
        Select Case prt.skincolor.GetHashCode
            Case Color.AntiqueWhite.GetHashCode
                Return "porcelain "
            Case Color.FromArgb(255, 247, 219, 195).GetHashCode
                Return "fair "
            Case Color.FromArgb(255, 240, 184, 160).GetHashCode
                Return "tan "
            Case Color.FromArgb(255, 210, 161, 140).GetHashCode
                Return "tan "
            Case Color.FromArgb(255, 180, 138, 120).GetHashCode
                Return "dark "
            Case Color.FromArgb(255, 105, 80, 70).GetHashCode
                Return "ebony "
            Case Else
                Return getColor(prt.skincolor)
        End Select
    End Function
    Function plusMinus(ByVal x, ByVal y, ByVal tol)
        If x > y + tol Or x < y - tol Then Return False Else Return True
    End Function
    Function isUnwilling() As Boolean
        If will > 15 Then Return True
        Return Settings.active(setting.alwaysunwilling)
    End Function
    Function cursed() As Boolean
        If perks(perk.slutcurse) > -1 Then Return True
        If perks(perk.copoly) > -1 Then Return True
        If perks(perk.cogreed) > -1 Then Return True
        If perks(perk.corust) > -1 Then Return True
        If perks(perk.comilk) > -1 Then Return True
        If perks(perk.coblind) > -1 Then Return True
        If perks(perk.coscale) > -1 Then Return True
        If perks(perk.succubuscurse) > -1 Then Return True
        If perks(perk.faecurse) > -1 Then Return True
        If perks(perk.coftheox) > -1 Then Return True
        If ongoingTFs.contains(tfind.malmino) Then Return True
        If equippedArmor.getCursed(Me) Or equippedWeapon.getCursed(Me) Or equippedAcce.getCursed(Me) Or equippedGlasses.getCursed(Me) Then Return True
        Return False
    End Function
    Function genDescription()
        allRoute()

        Dim out As String = ""
        'general statement
        If pClass.name.Equals("Classless") Then
            out = "You are " & name & ", a " & sex & " " & pClass.name & " " & pForm.name & DDUtils.RNRN
        Else
            out = "You are " & name & ", a " & sex & " " & pForm.name & " " & pClass.name & DDUtils.RNRN
        End If
        description = Replace(out, vbCrLf, "")

        out += nextLevelXp - xp & " XP to next LVL" & DDUtils.RNRN
        'check for single image forms
        Select Case pForm.name
            Case "Dragon"
                out += "You are a large, green dragon." & DDUtils.RNRN
                Return out + outPutPerkText()
            Case "Broodmother"
                out += "You are a large, red dragon." & DDUtils.RNRN
                Return out + outPutPerkText()
            Case "Oni"
                out += "You are a massive red woman with small horns betraying a demonic origin." & DDUtils.RNRN
                Return out + outPutPerkText()
            Case "Horse"
                out += "You are a dark brown draft horse, bred for pulling heavy loads." & DDUtils.RNRN
                Return out + outPutPerkText()
            Case "Unicord"
                out += "You are snowy white horse with a medium-sized magical horn on your forehead." & DDUtils.RNRN
                Return out + outPutPerkText()
            Case "Blob"
                out += "You are a small cyan blob of slime, too pliable to maintain a constant form.  While the gelatinous goo that makes up your body gives you a certain durability, one solid strike may leave you in pieces." & DDUtils.RNRN
                Return out + outPutPerkText()
            Case "Chicken"
            Case "Fae"
                out += "You are a small farie.  While you can fly using the delicate wings attached to your back, your size makes it difficult to wear or use any form of equipment designed for bigger folk." & DDUtils.RNRN
            Case "Frog"
                out += "You are a lime green tiny frog.  Ribbit, ribbit." & DDUtils.RNRN
                Return out + outPutPerkText()
            Case "Sheep"
                out += "You are a fluffy, white sheep.  Bahh." & DDUtils.RNRN
                Return out + outPutPerkText()
            Case "Cake"
                out += "Your body is made of a rich, pink cake.  Despite this, be it through magic or sheer force of will, " &
                    "you can keep yourself together enough to move and even fight.  That said, your form isn't exactly durable " &
                    "and while you may be able to take a few hits, anything else might just end up leaving you splattered on the floor " &
                    "of the dungeon." & DDUtils.RNRN &
                    "You look female, with massive breasts topped with dollops of whipped cream topping them.  Your ""hair"" is also made " &
                    "of a similar frosting, done in a feminine style." & DDUtils.RNRN
                Return out + outPutPerkText()
        End Select

        Select Case pClass.name
            Case "Magical Girl​"
                out += "You are currently in the middle of a magical girl transformation!" & DDUtils.RNRN
                Return out + outPutPerkText()
            Case "Princess​"
                out += "Whatever you were before, you are now a princess in a golden ballgown." & DDUtils.RNRN
                Return out + outPutPerkText()
            Case "Bunny Girl​"
                out += "Whatever you were before, you are now a small, blonde adult woman in a azure bunny suit.  The suit, clinging to your suple body includes not just a blue leotard, but also a pair of nylon stockings that highlight your toned legs, and end in a pair of platform heels.  Topping off your ensamble is a white headband with two bunny ears." & DDUtils.RNRN
                Return out + outPutPerkText()
        End Select

        'hair
        out += "You have " & getHairColor()
        If prt.haircolor.A = 180 Then
            out += "gelatinous "
        End If
        If pForm.name.Equals("Blowup Doll") Then
            out += "rubber "
        End If
        If prt.iArrInd(pInd.rearhair).Item2 Then
            out += "hair, done in a feminine style." & DDUtils.RNRN
        Else
            out += "hair, done in a masculine style." & DDUtils.RNRN
        End If

        'body
        Select Case pForm.name
            Case "Blowup Doll"
                out += "You are a inflatable sex doll with " & getSkinColor() & "rubber skin.  "
                If prt.sexBool Then
                    out += "You have a feminine body, with huge breasts and a matching ""pussy""." & DDUtils.RNRN
                Else
                    out += "You have a feminine body, with huge breasts, though you do have a dildo-like cock." & DDUtils.RNRN
                End If
            Case Else
                'skincolor
                If prt.haircolor.A = 200 Then
                    out += "Your body is made up of a " & getSkinColor() & "slime, and while you are technically formless, you still have enough control over the slime to form a bipedal, humanoid form.  "
                Else
                    out += "You have a (relatively) normal human body with " & getSkinColor() & "skin.  "
                End If
                'breasts
                Dim bAdj = ""
                Select Case breastSize
                    Case -1
                        bAdj = "non-existant"
                    Case 0
                        bAdj = "small"
                    Case 1
                        bAdj = "medium"
                    Case 2
                        bAdj = "large"
                    Case 3
                        bAdj = "huge"
                    Case 4
                        bAdj = "massive"
                    Case 5
                        bAdj = "ridiculous"
                    Case 6
                        bAdj = "vast"
                    Case 7
                        bAdj = "immense"
                End Select
                'dick
                Dim dAdj = ""
                Select Case dickSize
                    Case -1
                        dAdj = "non-existant"
                    Case 0
                        dAdj = "small"
                    Case 1
                        dAdj = "medium-sized"
                    Case 2
                        dAdj = "large"
                    Case 3
                        dAdj = "huge"
                    Case 4
                        dAdj = "massive"
                End Select
                'body
                Dim uAdj = ""
                Select Case buttSize
                    Case -2, -1
                        uAdj = "masculine"
                    Case 1, 2, 3, 4, 5
                        uAdj = "feminine"
                    Case Else
                        uAdj = "androgynous"
                End Select

                If prt.sexBool Or dickSize = -1 Then
                    out += "Your body has a generally " & uAdj & " appearance, with " & bAdj & " breasts and a pussy between your legs." & DDUtils.RNRN
                Else
                    If breastSize = -1 Then
                        out += "Your body has a generally " & uAdj & " appearance, with a toned chest and a " & dAdj & " cock between your legs." & DDUtils.RNRN
                    Else
                        out += "Your body has a generally " & uAdj & " appearance, with " & bAdj & " breasts and a " & dAdj & " cock between your legs." & DDUtils.RNRN
                    End If
                End If
        End Select

        out += outPutPerkText()

        out += listQuests()
        Return out
    End Function
    Function outPutPerkText() As String
        Dim out = ""

        '| -- Status Indicators -- |
        If Not DDUtils.isEmpty(selectedSpell) Then out += "You have selected " & selectedSpell & " as your primary spell." & DDUtils.RNRN
        If Not DDUtils.isEmpty(selectedSpecial) Then out += "You have selected " & selectedSpecial & " as your primary special." & DDUtils.RNRN
        If Not Transformation.canBeTFed(Me) Then out += "Your form is unstable..." & DDUtils.RNRN
        If perks(perk.hunger) > -1 Then out += "You haven't eaten anything in a while and are starving." & DDUtils.RNRN
        If perks(perk.thrall) > -1 Then out += "You are under the thrall of a sorcerer/ess, and may not have full control over your body or mind." & DDUtils.RNRN
        If perks(perk.polymorphed) > -1 Then out += "You are under the effects of a temporary polymorph, and will be for " & perks(perk.polymorphed) & " more turns." & DDUtils.RNRN
        If perks(perk.astatue) > -1 And className.Equals("Cynn Onahole") Then
            out += "You are currently inanimate, and won't be able to do much for " & perks(perk.astatue) & " turns." & DDUtils.RNRN
        ElseIf perks(perk.astatue) > -1 Then
            out += "You are currently a statue, and won't be able to do much for " & perks(perk.astatue) & " turns." & DDUtils.RNRN
        End If
        If perks(perk.lurk) > -1 Then out += "You are currently in a shrub." & DDUtils.RNRN
        If perks(perk.blind) > -1 Then out += "You are blind." & DDUtils.RNRN
        If perks(perk.lightsource) > -1 Then out += "Your entire body is glowing, and will continue to do so for " & perks(perk.lightsource) & " turns." & DDUtils.RNRN
        'If perks(perk.masochist) > -1 Then out += "Damage you take will raise your lust." & DDUtils.RNRN
        If perks(perk.burn) > -1 Then out += "You are on fire, and will continue to do so for " & perks(perk.burn) & " turns." & DDUtils.RNRN
        If perks(perk.mesmerized) > -1 Then out += "You are mesmerized, and will continue to be so for " & perks(perk.mesmerized) & " turns." & DDUtils.RNRN
        If perks(perk.dodge) > -1 Then out += "You will dodge the next attack that comes your way." & DDUtils.RNRN
        If perks(perk.isspotfused) > -1 Then out += "You can not fuse again for " & perks(perk.isspotfused) & " turns." & DDUtils.RNRN
        If perks(perk.vofmanynames) > -1 Then out += "Your true name is hidden!  " & perks(perk.vofmanynames) & " charges remain." & DDUtils.RNRN
        If perks(perk.cynnstonic) > -1 Then out += "You are under the " & CynnTonic.getEffectTier(Me) & " influence of Cynn's Tonic!  " & perks(perk.cynnstonic) & " charges remain." & DDUtils.RNRN
        If ongoingTFs.contains(tfind.arachne) Then out += "You are under the influence of Arachne venom." & DDUtils.RNRN

        '| -- Curse Indicators -- |
        If perks(perk.slutcurse) > -1 Then out += "Due to a curse, any clothes or armor you wear will become skimpy and revealing." & DDUtils.RNRN
        If perks(perk.copoly) > -1 Then out += "Due to a curse, you will occasionally change forms uncontrollably." & DDUtils.RNRN
        If perks(perk.cogreed) > -1 Then out += "Due to a curse, all chests that you open will turn into mimics." & DDUtils.RNRN
        If perks(perk.corust) > -1 Then out += "Due to a curse, your worn equipment will take damage occasionally." & DDUtils.RNRN
        If perks(perk.comilk) > -1 Then out += "Due to a curse, your tits will rapidly grow larger over time." & DDUtils.RNRN
        If perks(perk.coblind) > -1 Then out += "Due to a curse, you can no longer see." & DDUtils.RNRN
        If perks(perk.succubuscurse) > -1 Then out += "Due to a curse, you will progressively turn into a bimbo as your lust increases." & DDUtils.RNRN
        If perks(perk.faecurse) > -1 Then out += "Due to a curse, you are marked as an enemy of the fae." & DDUtils.RNRN

        Return out
    End Function
    Function listQuests() As String
        Dim originalOut = "|----- QUESTS -----|" & DDUtils.RNRN
        Dim out = originalOut

        For Each qu In quests
            If qu.getActive And Not qu.getComplete And Not qu.isHidden Then
                out += """" & qu.getName & """ (" & qu.getProgress & ")" & vbCrLf & "- " & qu.getCurrObj.getDesc & DDUtils.RNRN
            End If
        Next

        Return If(out.Equals(originalOut), "", out)
    End Function

    '|LEVELING| 
    Public Sub addXP(ByVal i As Integer)
        If className.Contains("Bimbo") Then i *= 2
        If equippedArmor.getAName.Equals(SportBra.ITEM_NAME) Then i *= 1.2

        xp += i

        If perks(perk.odxpgained) > -1 Then perks(perk.odxpgained) += i

        If xp >= nextLevelXp Then levelUp()
    End Sub
    Public Sub levelUp()
        If equippedAcce.getAName.Equals(CynnsBimboMark.ITEM_NAME) Then
            TextEvent.pushAndLog("Your tattoo glows, and you can feel your experience being siphoned away...")
            xp = 0
            Exit Sub
        End If


        level += 1

        xp -= nextLevelXp
        nextLevelXp = nextLevelXp * level

        health = 1
        maxHealth += 20

        pClass.onLVLUp(level, Me)
        pForm.onLVLUp(level, Me)

        TextEvent.pushLog("Level up!  " & name & " is now level " & level)

        If xp > nextLevelXp Then levelUp()

        If equippedWeapon.getAName.Equals(LanceOfSFury.ITEM_NAME) AndAlso TextEvent.lblEventOnClose Is Nothing Then TextEvent.lblEventOnClose = AddressOf LanceOfSFury.levelUp
    End Sub
    Public Function deLevel(ByVal lostLevels As Integer) As Integer
        If lostLevels < 1 Or level = 1 Then Return 0

        pClass.deLVL(level, Me)
        pForm.deLVL(level, Me)

        Dim xpR As Double = xp / nextLevelXp

        nextLevelXp = Math.Max(CInt(nextLevelXp / level), DDConst.NEXT_LEVEL_FLOOR)

        maxHealth -= 20
        level -= 1

        Dim lostXP As Integer = nextLevelXp
        lostXP += xp - (xpR * nextLevelXp)

        xp = xpR * nextLevelXp

        If lostLevels > 1 Then
            Return lostXP + deLevel(lostLevels - 1)
        End If

        Return lostXP
    End Function
    Public Sub learnSpell(ByVal spell As String)
        If knownSpells.Contains(spell) Then Exit Sub
        knownSpells.Add(spell)
        TextEvent.pushLog(spell & " spell learned!")
    End Sub
    Public Sub forgetSpell(ByVal spell As String)
        If Not knownSpells.Contains(spell) Then Exit Sub

        While knownSpells.Contains(spell)
            knownSpells.Remove(spell)
        End While
        TextEvent.pushLog(spell & " spell forgotten!")
    End Sub
    Public Sub learnSpecial(ByVal spec As String)
        If knownSpecials.Contains(spec) Then Exit Sub
        knownSpecials.Add(spec)
        TextEvent.pushLog(spec & " special learned!")
    End Sub
End Class
