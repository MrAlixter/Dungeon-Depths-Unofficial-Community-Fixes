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
End Enum

Public Class Player
    'Player is the representation of a player controlled entity (the main player, any teammates)
    'METHODS AND VARIABLES RELATED TO LEVELING HAVE BEEN COMMENTED OUT.
    Inherits Entity

    'Player Instance variables
    Public sex, description As String
    Public pClass As pClass = New Classless()
    Public pForm As pForm = New Human()
    Dim turnCt As Integer = 0
    Public xp, nextLevelXp As Integer

    Public breastSize As Integer = -1
    Public dickSize As Integer = -1
    Public buttSize As Integer = -1

    Public stamina As Integer
    Public equippedWeapon As Weapon = New BareFists
    Public equippedArmor As Armor = New CommonClothes0
    Public equippedAcce As Accessory = New noAcce

    Public Shadows currTarget As NPC = Nothing

    Public perks As Dictionary(Of perk, Integer) = New Dictionary(Of perk, Integer)() 'perks also include triggers for events
    Public classes As Dictionary(Of String, pClass) = New Dictionary(Of String, pClass)()
    Public forms As Dictionary(Of String, pForm) = New Dictionary(Of String, pForm)()
    Public polymorphs As Dictionary(Of String, Transformation) = New Dictionary(Of String, Transformation)()
    Public pImage As Image 'tile image of the player
    Public TextColor As Color
    Public isPetrified = False

    'portrait variable
    Public prt As Portrait = New Portrait(True, Me)

    'player & form states
    Public currState, pState, sState As State
    Public bimbState As State = New State()
    Public magGState As State = New State()
    Public goddState As State = New State()
    Public maidState As State = New State()
    Public prinState As State = New State()
    Public dembimState1 As State = New State()
    Public dembimState2 As State = New State()
    Dim formStates = {goddState, bimbState, magGState, maidState, prinState, dembimState1, dembimState2}

    Public solFlag = False
    Public prefForm As preferedForm

    'assorted lists
    Public ongoingTFs As TFList = New TFList
    Public knownSpells As List(Of String) = New List(Of String)
    Public knownSpecials As List(Of String) = New List(Of String)
    Public selfPolyForms As List(Of String) = New List(Of String)
    Public enemPolyForms As List(Of String) = New List(Of String)

    '|CONSTRUCTORS|:
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
        nextLevelXp = 125
        mana = 3
        maxMana = mana
        stamina = 100

        createInvPerks()
        inv.add(0, 1)
        inv.add(2, 1)
    End Sub
    'load from save constructors
    Public Sub New(ByVal s As String, ByVal v As Double)
        solFlag = True
        createInvPerks()
        Dim playArray() As String = s.Split("#")

        currState = New State(Me)
        sState = New State(Me)
        pState = New State(Me)
        For i = 0 To UBound(formStates)
            formStates(i) = New State()
        Next


        currState.read(playArray(0))
        sState.read(playArray(1))
        pState.read(playArray(2))
        pClass = classes(currState.pClass.name)
        pForm = forms(currState.pForm.name)
        Dim ind As Integer
        If v > 0.4 Then
            ind = CInt(playArray(3)) - 1
            For i = 0 To ind
                formStates(i).read(playArray(4 + i))
                If i = UBound(formStates) Then Exit For
            Next
            playArray = playArray(5 + ind).Split("*")
        Else
            ind = 7
            For i = 0 To 7
                formStates(i).read(playArray(3 + i))
            Next
            playArray = playArray(4 + ind).Split("*")
        End If

        currState.load(Me)


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


        inv.load(playArray(14))
        Dim x As Integer = -2

        If Not playArray(17 + x).Equals("N/a") Then
            Dim crystal As Point = New Point(CInt(playArray(17 + x)), playArray(18 + x))
            forcedPath = {crystal}
            nextCombatAction = AddressOf ThrallTF.postLoadCrystalSpawn
        Else
            forcedPath = Nothing
        End If

        Dim currentIndex = 18 + x
        If Not playArray(17 + x).Equals("N/a") Then currentIndex += 1

        Dim stuff() As String = playArray(currentIndex).Split("$")
        If Not stuff(0).Equals("N/a") Then
            prefForm = New preferedForm(Color.FromArgb(CInt(stuff(0)), CInt(stuff(1)), CInt(stuff(2)), CInt(stuff(3))), _
                                        Color.FromArgb(CInt(stuff(4)), CInt(stuff(5)), CInt(stuff(6)), CInt(stuff(7))), _
                                        CBool(stuff(8)), CBool(stuff(9)), CInt(stuff(10)), CBool(stuff(11)), CInt(stuff(12)))
            CType(inv.item(69), ThrallCollar).setFormerLife(stuff(13), New Tuple(Of Integer, Boolean, Boolean)(CInt(stuff(14)), stuff(15), stuff(16)))
        Else
            CType(inv.item(69), ThrallCollar).setFormerLife(stuff(1), New Tuple(Of Integer, Boolean, Boolean)(CInt(stuff(2)), stuff(3), stuff(4)))
        End If

        Dim knowlegebase = playArray(currentIndex + 1).Split("†")
        currentIndex = 1
        Dim subKB = knowlegebase(currentIndex).Split("Ͱ")

        For i = 1 To CInt(subKB(0) + 1)
            Dim tf As Transformation = Transformation.newTF(subKB(i).Split("$"))
            ongoingTFs.add(tf)
        Next
        currentIndex += 1

        'load the known self poly forms
        subKB = knowlegebase(currentIndex).Split("Ͱ")
        For i = 1 To CInt(subKB(0) + 1)
            selfPolyForms.Add(subKB(i))

        Next
        currentIndex += 1

        'load the known self enemy forms
        subKB = knowlegebase(currentIndex).Split("Ͱ")
        For i = 1 To CInt(subKB(0) + 1)
            enemPolyForms.Add(subKB(i))

        Next
        currentIndex += 1

        'load the known spells
        subKB = knowlegebase(currentIndex).Split("Ͱ")
        For i = 1 To CInt(subKB(0) + 1)
            knownSpells.Add(subKB(i))

        Next
        currentIndex += 1
        'load the known specials
        subKB = knowlegebase(currentIndex).Split("Ͱ")
        For i = 1 To CInt(subKB(0) + 1)
            knownSpecials.Add(subKB(i))

        Next
        currentIndex += 1

        currState.load(Me)

        turnCt = Game.turn

        drawPort()
        magicRoute()
        specialRoute()
        allRoute()

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
            Game.pushLstLog("You find a wand lodged in the entrance...Maybe you should equip it?")
        ElseIf s = "Valkyrie" Then
            pClass = classes("Classless")
            maxHealth = 80
            attack = 7
            defense = 7
            speed = 7
            inv.add(2, 3)
            inv.add(4, 1)
            inv.add("Valkyrie_Sword", 1)
            Game.pushLstLog("You find a sword piercing the floor...Maybe you should equip it?")
        End If
        'equip armor, boost mana if a staff is equipped
        Equipment.clothesChange(equippedArmor.getName)
        If equippedWeapon.GetType().IsSubclassOf(GetType(Staff)) Then mana += equippedWeapon.mBoost
        'set the known specials/spells
        specialRoute()
        magicRoute()
        'set pImage and TextColor
        pImage = Game.picPlayer.BackgroundImage
        TextColor = Color.White
        'sets the player description
        description = CStr(name & " is a " & sex & " " & pForm.name & " " & pClass.name)
        'saves the player's state
        currState = New State(Me)
        sState = New State(Me)
    End Sub
    Public Sub createInvPerks()
        inv = New Inventory(True)
        initPerks()
        initClasses()
        initForms()
        initPolymorphs()
    End Sub
    Private Sub initPerks()
        perks.Clear()
        'Creates the dictionary of perks
        For Each p In System.Enum.GetValues(GetType(perk))
            perks.Add(p, -1)
        Next
    End Sub
    Private Sub initClasses()
        'creates the class dictionary
        classes.Clear()
        classes.Add("Classless", New Classless())
        classes.Add("Warrior", New Warrior())
        classes.Add("Mage", New Mage())
        classes.Add("Magical Girl", New MagicGirl())
        classes.Add("Magical Girl​", New MagicGirlTransform())
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
        classes.Add("Bunny Girl", New Dancer())
        classes.Add("Barbarian", New Barbarian())
        classes.Add("Warlock", New Warlock())
        classes.Add("Mindless", New Mindless())
        classes.Add("Bimbo++", New BimboPlusPlus())
        classes.Add("Shrunken", New Shrunken())
        classes.Add("Maiden", New Maiden())
        classes.Add("Rogue", New Rogue())
        classes.Add("Witch", New witch())
    End Sub
    Private Sub initForms()
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
        forms.Add("Half-Dragon", New HalfDragon())
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
        forms.Add("Oni", New Oni())
        forms.Add("Alraune", New AlrauneF())
        forms.Add("Goth", New Goth())
        forms.Add("Plush", New Plush())
        forms.Add("Fae", New FaeForm())
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
    End Sub
    Sub setStartStates()
        sState.save(Me)
        savePState()
        If perks(perk.polymorphed) > -1 Then perks(perk.polymorphed) = -1
    End Sub
    Public Sub savePState()
        If Transformation.canBeTFed(Me) And Not perks(perk.succubuscurse) > 0 Then
            pState.save(Me)
        End If
    End Sub

    '|MOVEMENT COMMANDS|
    Public Overrides Sub reachedFPathDest()
        If Game.mDun.numCurrFloor = 4 And Not Game.preBSBody Is Nothing And Game.preBSStartState Is Nothing And Game.mDun.floorboss(4) = "Ooze Empress" Then
            RandoTF.floor4FirstBossEncounter()
            Exit Sub
        End If
        If pClass.name.Equals("Thrall") Then
            If Int(Rnd() * 2) = 1 Then
                Dim out = "You've found one of the crystals your controller is seeking!  As you circle it, you feel a familiar presence enter your mind.  " & _
                    """Yes!  You've found it!"" your overseer states exitedly, ""I'll be over shortly, don't go anywhere and don't touch that crystal.""" & vbCrLf & _
                    "Obeying, you take a seat and wait for a few minutes before a violet portal opens up near the crystal and your master steps out."
                If will > 7 Then
                    out += "  In their attention to the crystal, they don't seem to notice you at all giving you a few minutes to yourself." & DDUtils.RNRN & "Wait... if they aren't paying attention to you..." & DDUtils.RNRN & "You fiddle around with your collar, and they still don't seem to notice your actions, so you leverage your thumb in the collars joint."
                    Game.pushLblEvent(out, AddressOf ThrallTF.betraySorc, AddressOf ThrallTF.waitSorc, "Break off your collar?")
                Else
                    out += "  Despite your excitement, they don't seem to notice you, instead focusing all their attention on the crystalline array.  As they fiddle with it, you notice a slight purple aura beginning to form around them and wait, are those horns sprouting out of their hair that seems to catch a non-existant wind?  With a flourish, they complete ... something ... and a blinding flash engulfs them.  Where once stood your human controller now stands a half-demon who only now seems to have taken notice of you." & _
                        """Well... It looks like you succeeded.  For that, I will give you an ultimatium.  Join me as my general, or die in these dungeons as my slave."
                    Game.pushLblEvent(out, AddressOf ThrallTF.acceptSorc, AddressOf ThrallTF.fightSorc, "Accept their offer?")
                End If

            Else
                Game.pushLblEvent("You've found one of the crystals your controller is seeking!  As you circle it, you feel a familiar presence enter your mind.  " & _
                    """No, that isn't it."" your overseer states disappointedly, ""Well, I guess you can go back to your buisness now.""")
                ongoingTFs.add(New ThrallTF())
            End If
        End If
    End Sub
    Public Sub wander()
        Select Case Int(Rnd() * 4) + 1
            Case 1
                moveUp()
            Case 2
                moveDown()
            Case 3
                moveLeft()
            Case 4
                moveRight()
        End Select
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

        Dim dmg As Integer = Math.Max(equippedWeapon.attack(Me, target), 1)

        If dmg = -1 Then
            miss(target)
        ElseIf dmg = -2 Then
            cHit(Me.getATK, target)
        ElseIf dmg <> -3 Then
            hit(dmg, target)
        End If

    End Sub
    'attacking a npc
    Public Sub miss(target As NPC)
        Game.pushLstLog(CStr("You miss" & target.title & " " & target.getName() & "!"))
        Game.pushLblCombatEvent(CStr("You miss" & target.title & " " & target.getName() & "!"))
    End Sub
    Public Sub hit(dmg As Integer, target As NPC)
        Game.pushLstLog(CStr("You hit" & target.title.ToLower & target.getName() & " for " & dmg & " damage!"))
        Game.pushLblCombatEvent(CStr("You hit" & target.title.ToLower & target.getName() & " for " & dmg & " damage!"))
        target.takeDMG(dmg, Me)
    End Sub
    Public Sub setTarget(ByRef t As NPC)
        currTarget = t
        MyBase.currTarget = t
    End Sub
    Public Sub cHit(dmg As Integer, target As NPC)
        Game.pushLstLog(CStr("You hit" & target.title.ToLower & target.getName() & " for " & dmg * 3 & " damage!  Critical hit!"))
        Game.pushLblCombatEvent(CStr("You hit" & target.title.ToLower & target.getName() & " for " & dmg * 3 & " damage!  Critical hit!"))
        target.isStunned = True
        target.stunct = 0
        target.takeDMG(dmg * 3, Me)
    End Sub
    'attacking a non npc
    Private Sub miss(target As Entity)
        If target.GetType() Is GetType(NPC) Or target.GetType.IsSubclassOf(GetType(NPC)) Then
            miss(CType(target, NPC))
            Exit Sub
        End If

        Game.pushLstLog(CStr("You miss " & target.getName() & "!"))
        Game.pushLblCombatEvent(CStr("You miss " & target.getName() & "!"))
    End Sub
    Private Sub hit(dmg As Integer, target As Entity)
        If target.GetType() Is GetType(NPC) Or target.GetType.IsSubclassOf(GetType(NPC)) Then
            hit(dmg, CType(target, NPC))
            Exit Sub
        End If

        Game.pushLstLog(CStr("You hit " & target.getName() & " for " & dmg & " damage!"))
        Game.pushLblCombatEvent(CStr("You hit " & target.getName() & " for " & dmg & " damage!"))
        target.takeDMG(dmg, Me)
    End Sub
    Private Sub cHit(dmg As Integer, target As Entity)
        If target.GetType() Is GetType(NPC) Or target.GetType.IsSubclassOf(GetType(NPC)) Then
            cHit(dmg, CType(target, NPC))
            Exit Sub
        End If

        Game.pushLstLog(CStr("You hit " & target.getName() & " for " & dmg * 3 & " damage!  Critical hit!"))
        Game.pushLblCombatEvent("You hit " & target.getName() & " for " & dmg * 3 & " damage!  Critical hit!")
        target.takeDMG(dmg * 3, Me)
    End Sub
    'taking damage
    Public Overrides Sub takeDMG(ByVal dmg As Integer, ByRef source As Entity)
        If PerkEffects.onDamage(dmg) Then Exit Sub
        MyBase.takeDMG(dmg, source)
        Game.lblPHealtDiff.Tag -= dmg
        Game.pushLstLog(CStr("You got hit! -" & dmg & " health!"))
        Game.pushLblCombatEvent(CStr("You got hit! -" & dmg & " health!"))
    End Sub
    Public Overrides Sub takeCritDMG(ByVal dmg As Integer, ByRef source As Entity)
        If PerkEffects.onDamage(dmg) Then Exit Sub
        If dmg > getIntHealth() And dmg > 0.05 * getMaxHealth() Then dmg = getIntHealth() - 1
        MyBase.takeDMG(dmg, source)
        Game.lblPHealtDiff.Tag -= dmg
        Game.pushLstLog(CStr("You got hit!  Critical hit!  -" & dmg & " health!"))
        Game.pushLblCombatEvent(CStr("You got hit!  Critical hit! -" & dmg & " health!"))
    End Sub
    'specials
    Public Sub specialRoute()
        Game.cboxSpec.Items.Clear()
        For Each s In knownSpecials
            Game.cboxSpec.Items.Add(s)
        Next

        If pClass.name = "Warrior" Or pClass.name = "Paladin" Then Game.cboxSpec.Items.Add("Berserker Rage")
        If pClass.name = "Mage" Or pClass.name = "Paladin" Then Game.cboxSpec.Items.Add("Risky Decision")
        If pClass.name = "Rogue" Then Game.cboxSpec.Items.Add("Bounty's Collection")
        If breastSize > 3 Then Game.cboxSpec.Items.Add("Massive Mammaries")
        If breastSize > 5 Then Game.cboxSpec.Items.Add("Pillowy Protect")
        If pForm.name = "Succubus" Then Game.cboxSpec.Items.Add("Charm") : Game.cboxSpec.Items.Add("Drain Soul")
        If pForm.name = "Slime" Then Game.cboxSpec.Items.Add("Absorbtion")
        If pForm.name = "Dragon" Then Game.cboxSpec.Items.Add("Ironhide Fury")
        If inv.item("Shrink_Ray").count > 0 Then Game.cboxSpec.Items.Add("Shrink_Ray Shot")
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
        Dim tHth As Integer = health + hBuff
        Dim tMna As Integer = mana + mBuff
        Dim tHun As Integer = stamina
        Dim tGold As Integer = gold
        Dim tEweap As Weapon = equippedWeapon
        Dim tEarm As Armor = equippedArmor
        Dim tAcc As Accessory = equippedAcce

        Dim tpClassName As String = pClass.name
        Dim tpFormName As String = pForm.name
        Dim tpClassRP As String = pClass.revertPassage
        Dim tpFormRP As String = pClass.revertPassage

        s.load(Me, False)

        mana = tMna
        gold = tGold
        equippedArmor = tEarm
        If inv.getCountAt(tEarm.getAName) < 1 Then equippedArmor = New Naked
        equippedWeapon = tEweap
        If inv.getCountAt(tEweap.getAName) < 1 Then equippedWeapon = New BareFists
        equippedAcce = tAcc
        If inv.getCountAt(tAcc.getAName) < 1 Then equippedAcce = New noAcce

        currState.save(Me)
        savePState()

        Do While knownSpells.Contains("Heartblast Starcannon")
            knownSpells.Remove("Heartblast Starcannon")
            Game.pushLstLog("'Heartblast Starcannon' spell forgotten!")
        Loop

        If health > 1 Then health = 1
        If mana > maxMana + mBuff Then mana = maxMana + mBuff

        Dim out = ""
        If Not tpClassName.Equals(pClass.name) Then
            pClass.revert()
            If pClass.revertPassage <> "" Then out += pClass.revertPassage & DDUtils.RNRN
        End If
        If Not tpFormName.Equals(pForm.name) Then
            pForm.revert()
            If pForm.revertPassage <> "" Then out += pForm.revertPassage & DDUtils.RNRN
        End If

        ongoingTFs.resetPolymorphs()

        If Game.lblEvent.Visible = False Then Game.pushLblEvent(out & "You return to your former form!")
        Game.pImage = pImage
        Game.lblEvent.ForeColor = TextColor
        Game.lblNameTitle.ForeColor = TextColor

        drawPort()
        setPImage()
        UIupdate()
    End Sub
    Public Function revertToState(ByVal numtorevert As Integer, ByRef s As State) As String
        Randomize()
        Dim loopct = 0
        Dim attributes As String() = {"Tail", "Wings", "Rear Hair", "Hair Accessory", "Clothes",
                                      "Face", "Mid. Hair", "Horns", "Ears", "Nose", "Mouth", "Eyes",
                                      "Eyebrows", "Facemark", "Glasses", "Cloak", "Front Hair", "Hat",
                                      "Hair Color", "Skin Color"}
        DDUtils.shuffle(attributes)

        Dim revertedAttributes As List(Of String) = New List(Of String)


        While numtorevert > 0
            If loopct > 100 Then
                revertToState(s)
                Return ""
                Exit While
            End If

            Dim attribute As String = attributes(Int(Rnd() * attributes.Length))
            Dim layer = -1

            Select Case attribute
                Case "Tail"
                    layer = pInd.tail
                Case "Wings"
                    layer = pInd.wings
                Case "Rear Hair", "Mid. Hair"
                    prt.setIAInd(pInd.rearhair, s.iArrInd(pInd.rearhair).Item1, s.iArrInd(pInd.rearhair).Item2, s.iArrInd(pInd.rearhair).Item3)
                    prt.setIAInd(pInd.midhair, s.iArrInd(pInd.midhair).Item1, s.iArrInd(pInd.midhair).Item2, s.iArrInd(pInd.midhair).Item3)
                Case "Hair Accessory"
                    layer = pInd.hairacc
                Case "Clothes"
                    Dim tEarm As Armor = s.equippedArmor
                    equippedArmor = tEarm
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
                Case "Glasses"
                    layer = pInd.glasses
                Case "Cloak"
                    layer = pInd.cloak
                Case "Front Hair"
                    layer = pInd.fronthair
                Case "Hat"
                    layer = pInd.hat
                Case "Hair Color"
                    prt.haircolor = sState.getHairColor
                Case "Skin Color"
                    prt.skincolor = sState.getSkinColor
            End Select

            If (layer <> -1 AndAlso (prt.iArrInd(layer).Item1 <> sState.iArrInd(layer).Item1 And
                                     prt.iArrInd(layer).Item2 <> sState.iArrInd(layer).Item2 And
                                     prt.iArrInd(layer).Item2 <> sState.iArrInd(layer).Item3)) Then

                prt.setIAInd(layer, s.iArrInd(layer).Item1, s.iArrInd(layer).Item2, s.iArrInd(layer).Item3)

                numtorevert -= 1
                layer -= 1
                If Not revertedAttributes.Contains(attribute) Then revertedAttributes.Add(attribute)
            End If
            loopct += 1
        End While
        drawPort()

        Dim out = revertedAttributes.Count & " changes were reverted." & vbCrLf & "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
        For Each atr In revertedAttributes
            out += vbCrLf & atr & " reverted."
        Next
        If revertedAttributes.Count > 0 Then out += vbCrLf & "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
        Return out
    End Function
    Public Sub revertToSState()
        perks(perk.slutcurse) = -1

        revertToState(sState)

        Game.pushLblEvent("With a poof of smoke, you return to your original self!")
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
        If Not classes.ContainsKey(newClass) Then MsgBox("Error 09: " & newClass & " is not a recognized player class!") : Exit Sub

        Dim nextlevelPercentage As Double = xp / nextLevelXp
        xp = 0

        For i = level To 1 Step -1
            pClass.deLVL(i, Me)
        Next

        pClass = classes(newClass)

        For i = 1 To level
            pClass.onLVLUp(i, Me)
        Next

        xp = CInt(nextlevelPercentage * nextLevelXp)
    End Sub
    Public Sub changeForm(ByVal newForm As String)
        If Not forms.ContainsKey(newForm) Then MsgBox("Error 10: " & newForm & " is not a recognized player form!") : Exit Sub

        Dim nextlevelPercentage As Double = xp / nextLevelXp
        xp = 0

        For i = level To 1 Step -1
            pForm.deLVL(i, Me)
        Next

        pForm = forms(newForm)

        For i = 1 To level
            pForm.onLVLUp(i, Me)
        Next

        xp = CInt(nextlevelPercentage * nextLevelXp)
    End Sub
    Public Sub petrify(ByVal c As Color, ByVal dur As Integer)
        If pForm.name.Equals("Dragon") Then revertToPState()
        perks(perk.astatue) = dur
        changeHairColor(c, True)
        If prt.sexBool Then
            prt.setIAInd(pInd.mouth, 10, True, True)
            prt.setIAInd(pInd.eyes, 14, True, True)
        Else
            prt.setIAInd(pInd.mouth, 5, False, True)
            prt.setIAInd(pInd.eyes, 6, False, True)
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
            Game.pushLblEvent(out, AddressOf die)
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
    End Sub
    Public Overrides Sub die(ByRef source As Entity)
        If Game.pnlSaveLoad.Visible = True Then Exit Sub

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

        setHealth(0.1)
        If Not source Is Nothing AndAlso Not source.getSName Is Nothing Then
            If source.getName.Equals("stamina") Then
                Game.pushLblEvent("You starve to death!")
            ElseIf source.getName.Equals("Fire") Then
                Game.pushLblEvent("You burn to death!")
            ElseIf source.GetType.IsSubclassOf(GetType(NPC)) Or source.GetType.IsSubclassOf(GetType(Monster)) Then
                CType(source, NPC).playerDeath(Me)
                Exit Sub
            End If
        End If

        DeathEffects.hardDeath()
        Game.npcList.Clear()
    End Sub
    Public Sub setPImage()
        'sets the player tile image
        If pClass.name.Equals("Bimbo") Then
            If Game.mDun.numCurrFloor = 13 Then
                pImage = Game.picPlayerBFog.BackgroundImage
            ElseIf Game.mDun.numCurrFloor = 9999 Then
                pImage = Game.picBimboSpace.BackgroundImage
            ElseIf Game.mDun.numCurrFloor = 91017 Then
                pImage = Game.picLegaBimbo.BackgroundImage
            ElseIf Game.mDun.numCurrFloor > 5 Then
                pImage = Game.picBimbof.BackgroundImage
            Else
                pImage = Game.picPlayerB.BackgroundImage
            End If
        Else
            If Game.mDun.numCurrFloor = 13 Then
                pImage = Game.picPlayerFog.BackgroundImage
            ElseIf Game.mDun.numCurrFloor = 9999 Then
                pImage = Game.picPlayerSpace.BackgroundImage
            ElseIf Game.mDun.numCurrFloor = 91017 Then
                pImage = Game.picLegaPlayer.BackgroundImage
            ElseIf Game.mDun.numCurrFloor > 5 Then
                pImage = Game.picPlayerf.BackgroundImage
            Else
                pImage = Game.picPlayer.BackgroundImage
            End If
        End If
    End Sub

    '|UPDATE METHODS|
    Public Overrides Sub update()
        '|COMBAT|
        If perks(perk.astatue) > -1 Then nextCombatAction = AddressOf PerkEffects.statueMove
        MyBase.update()

        '|PERK AND TRANSFORMATION UPDATES|
        Dim pUpdateFlag As Boolean = False
        'perks
        If Game.turn <> turnCt Then
            turnCt = Game.turn
            pUpdateFlag = perkUpdate()
        End If
        'transformations
        tfUpdate(pUpdateFlag)

        '|PLAYER STAT UPKEEP|
        If xp >= nextLevelXp Then levelUp()
        UIupdate()

        If pUpdateFlag Then drawPort()
    End Sub
    Sub tfUpdate(Optional ByRef pUpdateFlag = False)
        'transformations
        ongoingTFs.ping(pUpdateFlag)
    End Sub
    Sub keepStatsInBounds()
        '|HEALTH|
        If Not Game.combatmode And Not solFlag Then health = Math.Min(1, health)

        '|MANA|
        If Not Game.combatmode And Not solFlag Then mana = Math.Min(mana, getMaxMana)
        mana = Math.Max(0, mana)

        '|STAMINA|
        stamina = Math.Max(0, stamina)
        stamina = Math.Min(100, stamina)
        If stamina <= 0 Then perks(perk.hunger) = 1
        If Game.turn Mod 25 = 10 And Int(Rnd() * 2) = 0 Then stamina -= 1

        '|STATS|
        attack = Math.Max(1, attack)

        defense = Math.Max(1, defense)

        speed = Math.Max(1, speed)

        will = Math.Max(0, will)

        lust = Math.Min(100, lust)
        lust = Math.Max(0, lust)
    End Sub
    Function perkUpdate() As Boolean
        Dim needsToUpdatePortrait = False
        '|GENERAL EFFECTS|
        'stamina
        If perks(perk.hunger) > -1 And Game.turn Mod 5 = 0 Then
            PerkEffects.staminaEffect()
        End If
        If perks(perk.burn) > -1 And Game.turn Mod 4 = 0 Then
            PerkEffects.burnEffect()
        End If
        If perks(perk.mburst) > -1 And Game.turn Mod 4 = 0 Then
            PerkEffects.mBurst()
        End If
        'slime hair health regen
        If perks(perk.slimehair) > -1 Then
            PerkEffects.slimeHairRegen()
        End If
        'vial of slime hair regen
        If perks(perk.vsslimehair) > -1 Then
            PerkEffects.vslimeHairRegen()
        End If
        'plant regen
        If pForm.name.Equals("Plantfolk") Then
            PerkEffects.plantRegen()
        End If
        'ring of min. regen
        If perks(perk.minRegen) > -1 Then
            PerkEffects.minorRegen()
        End If
        'mana generator
        If perks(perk.minmanregen) > -1 Then
            PerkEffects.minorManaRegen()
        End If
        'light source effect
        If perks(perk.minmanregen) > -1 Then
            PerkEffects.lightSource()
        End If
        'amazon effect
        If perks(perk.amazon) > -1 Then
            PerkEffects.amazon()
        End If
        'barbarian effect
        If perks(perk.barbarian) > -1 Then
            PerkEffects.barbarian()
        End If
        If perks(perk.cupcake) > -1 Then
            If Game.turn Mod 20 = 0 Then perks(perk.cupcake) -= 1
        End If

        'living armor
        If perks(perk.livearm) > -1 Then
            needsToUpdatePortrait = PerkEffects.livingArmor()
        End If
        'living lingerie
        If perks(perk.livelinge) > -1 Then
            needsToUpdatePortrait = PerkEffects.livingLingerie()
        End If

        '|TRANSFORMATION TRIGGERS|
        'targax sword tf
        If perks(perk.swordpossess) > -1 Then
            PerkEffects.targaxSwordTF()
        End If
        'shift toward prefered form
        If Not prefForm Is Nothing AndAlso (pClass.name = "Thrall" Xor equippedAcce.getName.Equals("Slave_Collar")) AndAlso Not prefForm.playerMeetsForm(Game.player1) And Not pForm.name.Equals("Half-Succubus") And Not perks(perk.thrall) = 1 And Not perks(perk.nekocurse) > -1 And Not perks(perk.polymorphed) > -1 And Not perks(perk.bimbotf) > -1 Then
            PerkEffects.thrallRestore()
        End If
        If perks(perk.astatue) > -1 Then
            PerkEffects.aStatue()
        End If
        If pClass.name.Equals("Magical Girl") Then
            PerkEffects.magicGirlStatusCheck(Me)
        End If
        If pClass.name.Equals("Valkyrie") Then
            PerkEffects.valkyrieStatusCheck(Me)
        End If

        '|SPECIAL MOVE HANDLERS|
        'berserker rage special
        If perks(perk.brage) > -1 Then
            PerkEffects.berserkerRage()
        End If
        'massive mammaries special
        If perks(perk.mmammaries) > -1 Then
            PerkEffects.massiveMammaries()
        End If
        'pillowy protect special
        If perks(perk.pprot) > -1 Then
            PerkEffects.pProt()
        End If
        'ironhide fury
        If perks(perk.ihfury) > -1 Then
            PerkEffects.ironhideFury()
        End If
        'inferno aura
        If perks(perk.infernoa) > -1 Then
            PerkEffects.infernoAura()
        End If

        '|CURSES|
        'clothing curse
        If perks(perk.slutcurse) > -1 Then
            needsToUpdatePortrait = Equipment.clothingCurse1(Me)
        End If
        'curse of rust
        If perks(perk.corust) > -1 Then
            needsToUpdatePortrait = PerkEffects.curseOfRust(Me)
        End If
        'curse of milk
        If perks(perk.comilk) > -1 Then
            needsToUpdatePortrait = PerkEffects.curseOfMilk(Me)
        End If
        'curse of milk
        If perks(perk.copoly) > -1 Then
            needsToUpdatePortrait = PerkEffects.curseOfPolymorph(Me)
        End If
        'curse of blindness
        If perks(perk.coblind) > -1 And Not perks(perk.blind) > -1 Then
            perks(perk.blind) = 1
        End If
        'succubus curse
        If perks(perk.succubuscurse) > -1 Then
            PerkEffects.curseOfBimbo(Me)
        End If


        description = CStr(name & " is a " & sex & " " & pForm.name & " " & pClass.name)
        Return needsToUpdatePortrait
    End Function
    Sub UIupdate()
        keepStatsInBounds()

        If Game.lblNameTitle.Text <> name & " the " & pClass.name Then Game.lblNameTitle.Text = name & " the " & pClass.name

        Game.lblHealth.Text = statBar(getIntHealth, getMaxHealth, Game.lblHealth)
        Game.lblHealth.ForeColor = Game.getHPColor(getHealth)

        Game.lblMana.Text = statBar(getMana, getMaxMana, Game.lblMana)

        Game.lblstamina.Text = statBar(stamina, 100, Game.lblstamina)

        Game.lblXP.Text = statBar(xp, nextLevelXp, Game.lblXP)

        If Game.lblLevel.Text <> "Level = " & level Then Game.lblLevel.Text = "Level = " & level
        If Game.lblATK.Text <> "ATK = " & getATK() Then Game.lblATK.Text = "ATK = " & getATK()
        If Game.lblDEF.Text <> "DEF = " & getDEF() Then Game.lblDEF.Text = "DEF = " & getDEF()
        If Game.lblSPD.Text <> "SPD = " & getSPD() Then Game.lblSPD.Text = "SPD = " & getSPD()
        If Game.lblWIL.Text <> "WILL = " & getWIL() Then Game.lblWIL.Text = "WILL = " & getWIL()
        If Game.lblLust.Text <> "LUST = " & getLust() Then Game.lblLust.Text = "LUST = " & getLust()
        If Game.lblGold.Text <> "GOLD = " & gold And gold <= 999999 Then
            Game.lblGold.Text = "GOLD = " & gold
        ElseIf Game.lblGold.Text <> "GOLD = " & gold And Game.lblGold.Text <> "GOLD = 999999+" Then
            Game.lblGold.Text = "GOLD = 999999+"
        End If

        inv.invIDorder.Clear()
        Dim numItems As Integer = Game.lstInventory.Items.Count
        Dim tArr(inv.count + 5) As String
        Dim ct As Integer = 0
        If Game.invFilters(0) Then
            drawInv("-USEABLES:", inv.getUseable, tArr, ct)
        End If
        If Game.invFilters(1) Then
            drawInv("-POTIONS:", inv.getPotions, tArr, ct)
        End If
        If Game.invFilters(2) Then
            drawInv("-FOOD:", inv.getFood, tArr, ct)
        End If
        If Game.invFilters(3) Then
            drawInv("-ARMOR:", inv.getArmors.Item2, tArr, ct)
        End If
        If Game.invFilters(4) Then
            drawInv("-WEAPONS:", inv.getWeapons.Item2, tArr, ct)
        End If
        If Game.invFilters(6) Then
            drawInv("-ACCESSORIES:", inv.getAccesories.Item2, tArr, ct)
        End If
        If Game.invFilters(5) Then
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
    End Sub
    Function statBar(ByVal cval As Double, ByVal mval As Double, ByVal ctrl As Control, Optional ByVal delim As Char = "ᚋ")
        Dim out As String = " " & cval & "/" & mval & " "

        ctrl.Font = Game.lblHealthbarFont.Font

        While ctrl.Width * (cval / mval) > TextRenderer.MeasureText(out, ctrl.Font).Width
            out = delim & out & delim
        End While

        While ctrl.Width < TextRenderer.MeasureText(out, ctrl.Font).Width
            out = out.Substring(0, out.Length - 1)
        End While

        If Not out.Contains(delim) Then out.Replace(" ", "")

        Return out
    End Function
    Sub drawInv(ByVal heading As String, ByRef list() As Item, ByRef tArr() As String, ByRef ct As Integer)
        tArr(ct) = heading
        inv.invIDorder.Add(-1)
        ct += 1

        Array.Sort(list)
        For i = 0 To UBound(list)
            If list(i).getCount > 0 Then
                tArr(ct) = " " & list(i).getName().Replace("_", " ") & " x" & list(i).count
                inv.invIDorder.Add(list(i).getId)
                ct += 1
            End If
        Next

        tArr(ct) = ""
        inv.invIDorder.Add(-1)
        ct += 1
    End Sub

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
        If Not solFlag Then Game.picPortrait.BackgroundImage = prt.draw(solFlag, isPetrified, AddressOf revertToSState, pForm.name, pClass.name)
        Game.picPortrait.Update()

        currState.save(Me)

        Game.lblEvent.ForeColor = TextColor
        Game.lblNameTitle.ForeColor = TextColor
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
        If perks(perk.polymorphed) > -1 Or pClass.name.Equals("Magical Girl") Or pClass.name.Equals("Valkyrie") Then
            Game.pushLstLog("Your form prevents you from being altered.")
            Exit Sub
        End If
        sex = "Female"
        breastSize = Math.Max(1, breastSize)
        buttSize = Math.Max(1, buttSize)
        dickSize = -1
        idRouteMF()
        If perks(perk.swordpossess) > -1 Then perks(perk.swordpossess) = 0
    End Sub
    Public Sub FtM()
        If perks(perk.polymorphed) > -1 Or pClass.name.Equals("Magical Girl") Or pClass.name.Equals("Valkyrie") Then
            Game.pushLstLog("Your form prevents you from being altered.")
            Exit Sub
        End If
        sex = "Male"
        breastSize = -1
        buttSize = -1
        dickSize = Math.Max(1, dickSize)
        perks(2) = False
        idRouteFM()
        If perks(perk.swordpossess) > -1 Then perks(perk.swordpossess) = 0
    End Sub
    Sub idRouteMF(Optional halfRevertFlag As Boolean = False)
        Dim mfr = Portrait.imgLib.mfEquivalentIndexes
        For i = 0 To mfr.Count - 1
            'checks for half reversion
            If Int(Rnd() * 2) = 0 Or halfRevertFlag = False Then
                'handles routing for default options
                If (i = pInd.eyebrows Or i = pInd.eyes) And prt.iArrInd(i).Item1 < 5 Then
                    prt.setIAInd(i, prt.iArrInd(i).Item1, True, False)
                ElseIf i <> pInd.blush Then
                    'handles routing for non-default options
                    Dim f = mfr(i).getFfromM(prt.iArrInd(i).Item1)
                    If (i = pInd.face Or i = pInd.facemark) And f = -1 Then f = 0
                    If f <> -1 Then prt.setIAInd(i, f, True, True)
                End If
            End If
        Next

        reverseAllRoute()

        'update the players clothing
        prt.portraitUDate()
    End Sub
    Sub idRouteFM(Optional halfRevertFlag As Boolean = False)
        Dim fmr = Portrait.imgLib.mfEquivalentIndexes
        For i = 0 To fmr.Count - 1
            'checks for half reversion
            If Int(Rnd() * 2) = 0 Or halfRevertFlag = False Then
                'handles routing for default options
                If (i = pInd.eyebrows Or i = pInd.eyes) And prt.iArrInd(i).Item1 < 5 Then
                    prt.setIAInd(i, prt.iArrInd(i).Item1, True, False)
                ElseIf i <> pInd.blush Then
                    'handles routing for non-default options
                    Dim m = fmr(i).getMfromF(prt.iArrInd(i).Item1)
                    If (i = pInd.face Or i = pInd.facemark) And m = -1 Then m = 0
                    If m <> -1 Then prt.setIAInd(i, m, True, True)
                End If
            End If
        Next

        allRoute()

        'update the players clothing
        prt.portraitUDate()
    End Sub
    'breast enlargement/reduction methods
    Public Sub be()
        If Not Transformation.canBeTFed(Me) And Not pClass.name.Equals("Thrall") Then
            Game.pushLstLog("Your form prevents you from being altered.")
            Exit Sub
        End If

        If breastSize >= -2 And breastSize < 7 Then
            breastSize += 1
            reverseBSroute()
            reverseUSRoute()
            Game.pushLstLog("+ 1 cup size!")
        Else
            Game.pushLstLog("Your breasts can get no larger!")
        End If
    End Sub
    Friend Sub bs()
        If Not Transformation.canBeTFed(Me) And Not pClass.name.Equals("Thrall") Then
            Game.pushLstLog("Your form prevents you from being altered.")
            Exit Sub
        End If
        If breastSize > -1 And breastSize <= 7 Then
            breastSize -= 1
            reverseBSroute()
            reverseUSRoute()
            Game.pushLstLog("- 1 cup size!")
        Else
            Game.pushLstLog("Your breasts can get no smaller!")
        End If
    End Sub
    Sub bsizeroute()
        If Portrait.imgLib Is Nothing Or prt.iArr Is Nothing Or
            prt.iArrInd Is Nothing Or solFlag Then Exit Sub
        If (prt.checkFemInd(pInd.chest, 2) Or prt.checkFemInd(pInd.chest, 9)) And breastSize <> 1 Then
            breastSize = 1
        ElseIf (prt.checkFemInd(pInd.chest, 3) Or prt.checkFemInd(pInd.chest, 10)) And breastSize <> 2 Then
            breastSize = 2
        ElseIf (prt.checkFemInd(pInd.chest, 4) Or prt.checkFemInd(pInd.chest, 11)) And breastSize <> 3 Then
            breastSize = 3
        ElseIf (prt.checkFemInd(pInd.chest, 5) Or prt.checkFemInd(pInd.chest, 12)) And breastSize <> 4 Then
            breastSize = 4
        ElseIf (prt.checkFemInd(pInd.chest, 6) Or prt.checkFemInd(pInd.chest, 13)) And breastSize <> 5 Then
            breastSize = 5
        ElseIf (prt.checkFemInd(pInd.chest, 7) Or prt.checkFemInd(pInd.chest, 14)) And breastSize <> 6 Then
            breastSize = 6
        ElseIf (prt.checkFemInd(pInd.chest, 8) Or prt.checkFemInd(pInd.chest, 15)) And breastSize <> 7 Then
            breastSize = 7
        ElseIf (prt.checkMalInd(pInd.chest, 1)) And breastSize <> 0 Then
            breastSize = 0
        ElseIf (prt.checkMalInd(pInd.chest, 0)) And (prt.checkMalInd(pInd.shoulders, 7)) And breastSize <> -2 Then
            breastSize = -2
        ElseIf (prt.checkMalInd(pInd.chest, 0)) And breastSize <> -1 Then
            breastSize = -1
        End If
    End Sub
    Public Sub reverseBSroute(Optional ByVal shoulderFlag = True)
        Select Case breastSize
            Case -2
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 7, False, False)
                prt.setIAInd(pInd.chest, 0, True, False)
                buttSize = -2
            Case -1
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 0, False, False)
                prt.setIAInd(pInd.chest, 0, True, False)
                buttSize = -1
            Case 0
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 1, False, False)
                prt.setIAInd(pInd.chest, 1, True, False)
                buttSize = 0
            Case 1
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 2, True, False)
                prt.setIAInd(pInd.chest, 9, True, False)
                If buttSize < 1 Then buttSize = 1
            Case 2
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 2, True, False)
                prt.setIAInd(pInd.chest, 10, True, False)
                If buttSize < 1 Then buttSize = 1
            Case 3
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 2, True, False)
                prt.setIAInd(pInd.chest, 11, True, False)
                If buttSize < 1 Then buttSize = 1
            Case 4
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 2, True, False)
                prt.setIAInd(pInd.chest, 12, True, False)
                If buttSize < 1 Then buttSize = 1
            Case 5
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 2, True, False)
                prt.setIAInd(pInd.chest, 13, True, False)
                If buttSize < 1 Then buttSize = 1
            Case 6
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 2, True, False)
                prt.setIAInd(pInd.chest, 14, True, False)
                If buttSize < 1 Then buttSize = 1
            Case 7
                If shoulderFlag Then prt.setIAInd(pInd.shoulders, 2, True, False)
                prt.setIAInd(pInd.chest, 15, True, False)
                If buttSize < 1 Then buttSize = 1
        End Select
        prt.portraitUDate()
    End Sub
    'dick enlargement/reduction methods
    Public Sub de()
        If Not Transformation.canBeTFed(Me) And Not pClass.name.Equals("Thrall") Then
            Game.pushLstLog("Your form prevents you from being altered.")
            Exit Sub
        End If

        If dickSize >= -1 And dickSize < 3 Then
            dickSize += 1
            reverseAllRoute()
            Game.pushLstLog("+ dick size!")
        Else
            Game.pushLstLog("Your dick can get no larger!")
        End If
    End Sub
    Friend Sub ds()
        If Not Transformation.canBeTFed(Me) And Not pClass.name.Equals("Thrall") Then
            Game.pushLstLog("Your form prevents you from being altered.")
            Exit Sub
        End If
        If dickSize > -1 And dickSize <= 3 Then
            dickSize -= 1
            reverseDSRoute()
            Game.pushLstLog("- dick size!")
        Else
            Game.pushLstLog("You no longer have a dick!")
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
        If Not Transformation.canBeTFed(Me) And Not pClass.name.Equals("Thrall") Then
            Game.pushLstLog("Your form prevents you from being altered.")
            Exit Sub
        End If

        If buttSize >= -2 And buttSize < 5 Then
            buttSize += 1
            reverseUSRoute()
            If equippedArmor.bindsWearer Then reverseBSroute(False) Else reverseBSroute()
            Game.pushLstLog("+ 1 butt size!")
        Else
            Game.pushLstLog("Your ass can get no larger!")
        End If
    End Sub
    Friend Sub us()
        If Not Transformation.canBeTFed(Me) And Not pClass.name.Equals("Thrall") Then
            Game.pushLstLog("Your form prevents you from being altered.")
            Exit Sub
        End If
        If buttSize > -1 And buttSize <= 5 Then
            buttSize -= 1
            reverseUSRoute()
            If equippedArmor.bindsWearer Then reverseBSroute(False) Else reverseBSroute()
            Game.pushLstLog("- 1 butt size!")
        Else
            Game.pushLstLog("Your butt can get no smaller!")
        End If
    End Sub
    Sub usizeroute()
        If equippedArmor.bindsWearer Then uBsizeroute() : Exit Sub
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
        ElseIf prt.checkNDefFemInd(pInd.body, 11) And buttSize <> 5 Then
            buttSize = 5
        End If
    End Sub
    Public Sub reverseUSRoute()
        If equippedArmor.bindsWearer Then reverseUBSRoute() : Exit Sub
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
                prt.setIAInd(pInd.body, 11, True, True)
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
        ElseIf prt.checkNDefFemInd(pInd.body, 12) And buttSize <> 0 Then
            buttSize = 0
        ElseIf prt.checkNDefFemInd(pInd.body, 13) And buttSize <> 1 Then
            buttSize = 1
        ElseIf prt.checkNDefFemInd(pInd.body, 14) And buttSize <> 2 Then
            buttSize = 2
        ElseIf prt.checkNDefFemInd(pInd.body, 15) And buttSize <> 3 Then
            buttSize = 3
        ElseIf prt.checkNDefFemInd(pInd.body, 16) And buttSize <> 4 Then
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
                prt.setIAInd(pInd.body, 12, True, True)
                prt.setIAInd(pInd.shoulders, 4, False, False)
                breastSize = 0
            Case 1
                prt.setIAInd(pInd.body, 13, True, False)
                prt.setIAInd(pInd.shoulders, 5, False, False)
                If breastSize < 1 Then breastSize = 1
            Case 2
                prt.setIAInd(pInd.body, 14, True, True)
                prt.setIAInd(pInd.shoulders, 5, False, False)
                If breastSize < 1 Then breastSize = 1
            Case 3
                prt.setIAInd(pInd.body, 15, True, True)
                prt.setIAInd(pInd.shoulders, 5, False, False)
                If breastSize < 1 Then breastSize = 1
            Case 4
                prt.setIAInd(pInd.body, 16, True, True)
                prt.setIAInd(pInd.shoulders, 5, False, False)
                If breastSize < 1 Then breastSize = 1
            Case 5
                prt.setIAInd(pInd.body, 16, True, True)
                prt.setIAInd(pInd.shoulders, 5, False, False)
                If breastSize < 1 Then breastSize = 1
        End Select
        prt.portraitUDate()
    End Sub

    Public Overrides Sub addLust(ByVal i As Integer)
        lust += i

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
    Public Overrides Function ToString() As String
        Dim output As String = ""

        currState.save(Me)

        output += currState.write()
        output += sState.write()
        output += pState.write()

        output += formStates.length & "#"
        For i = 0 To UBound(formStates)
            output += formStates(i).write()
        Next
        output += pos.X & "*"
        output += pos.Y & "*"
        output += health & "*"
        output += mana & "*"
        output += stamina & "*"
        output += hBuff & "*"
        output += mBuff & "*"
        output += aBuff & "*"
        output += dBuff & "*"
        output += wBuff & "*"
        output += sBuff & "*"
        output += level & "*"
        output += xp & "*"
        output += nextLevelXp & "*"

        output += inv.save()

        If forcedPath Is Nothing Then
            output += "N/a*"
        Else
            output += (forcedPath(UBound(forcedPath)).X & "*")
            output += (forcedPath(UBound(forcedPath)).Y & "*")
        End If

        If Not prefForm Is Nothing Then
            output += prefForm.ToString & "$"
        Else
            output += "N/a$"
        End If
        output += inv.item(69).ToString

        output += "*†"
        output += ongoingTFs.save()

        output += "†"
        output += selfPolyForms.Count - 1 & "Ͱ"
        For i = 0 To selfPolyForms.Count - 1
            output += selfPolyForms(i).ToString & "Ͱ"
        Next
        output += "†"
        output += enemPolyForms.Count - 1 & "Ͱ"
        For i = 0 To enemPolyForms.Count - 1
            output += enemPolyForms(i).ToString & "Ͱ"
        Next
        output += "†"
        output += knownSpells.Count - 1 & "Ͱ"
        For i = 0 To knownSpells.Count - 1
            output += knownSpells(i).ToString & "Ͱ"
        Next
        output += "†"
        output += knownSpecials.Count - 1 & "Ͱ"
        For i = 0 To knownSpecials.Count - 1
            output += knownSpecials(i).ToString & "Ͱ"
        Next
        output += "†"
        Return output
    End Function
    Public Function toGhost() As String
        Dim output = CStr(
            name & " the " & pForm.name & " " & pClass.name & "*" &
            Game.currFloor.floorCode & "*" &
            pClass.name & "*" &
            health & "*" &
            getMaxHealth() & "*" &
            getATK() & "*" &
            getMaxMana() & "*" &
            getDEF() & "*" &
            getSPD() & "*" &
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
    Overrides Function getMaxHealth() As Integer
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Or equippedAcce Is Nothing Then Return CInt(maxHealth * pForm.h * pForm.h) + hBuff
        Return CInt((maxHealth + hBuff) * pClass.h * pForm.h) + equippedArmor.getHBoost(Me) + equippedWeapon.getHBoost(Me) + equippedAcce.getHBoost(Me)
    End Function
    Overrides Function getMaxMana() As Integer
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Or equippedAcce Is Nothing Then Return CInt(maxMana * pForm.m * pForm.m) + mBuff
        Return CInt((maxMana + mBuff) * pForm.m * pForm.m) + equippedArmor.getMBoost(Me) + equippedWeapon.getMBoost(Me) + equippedAcce.getMBoost(Me)
    End Function
    Overrides Function getATK() As Integer
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Or equippedAcce Is Nothing Then Return CInt(attack * pForm.a * pClass.a) + aBuff
        Return CInt((attack + aBuff) * pForm.a * pClass.a) + equippedArmor.getABoost(Me) + equippedWeapon.getABoost(Me) + equippedAcce.getABoost(Me)
    End Function
    Overrides Function getDEF() As Integer
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Or equippedAcce Is Nothing Then Return CInt(defense * pClass.d * pForm.d) + dBuff
        Return CInt((defense + dBuff) * pClass.d * pForm.d) + equippedArmor.getDBoost(Me) + equippedWeapon.getDBoost(Me) + equippedAcce.getDBoost(Me)
    End Function
    Overrides Function getSPD() As Integer
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Or equippedAcce Is Nothing Then Return CInt(speed * pClass.s * pForm.s) + sBuff
        Return CInt((speed + sBuff) * pClass.s * pForm.s) + equippedArmor.getSBoost(Me) + equippedWeapon.getSBoost(Me) + equippedAcce.getSBoost(Me)
    End Function
    Overrides Function getWIL() As Integer
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Or equippedAcce Is Nothing Then Return CInt(will * pClass.w * pForm.w) + wBuff
        Return CInt((will + wBuff) * pClass.w * pForm.w) + equippedArmor.getWBoost(Me) + equippedWeapon.getWBoost(Me) + equippedAcce.getWBoost(Me)
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
    Function getColor(ByVal clr As Color) As String
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
    Function isShadeOf(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer, ByVal c As Color) As Double
        Dim ratio1, ratio2, ratio3
        Dim totalDelta = 0
        ratio1 = (Math.Abs(r - c.R) ^ 3) * 5
        ratio2 = (Math.Abs(g - c.G) ^ 3) * 5
        ratio3 = (Math.Abs(b - c.B) ^ 3) * 5
        totalDelta += ratio1 + ratio2 + ratio3

        Return totalDelta
    End Function
    Function isUnwilling() As Boolean
        If will > 15 Then Return True
        Return Game.pcUnwilling
    End Function
    Function isCursed() As Boolean
        If perks(perk.slutcurse) > -1 Then Return True
        If perks(perk.copoly) > -1 Then Return True
        If perks(perk.cogreed) > -1 Then Return True
        If perks(perk.corust) > -1 Then Return True
        If perks(perk.comilk) > -1 Then Return True
        If perks(perk.coblind) > -1 Then Return True
        If perks(perk.coscale) > -1 Then Return True
        If perks(perk.succubuscurse) > -1 Then Return True
        If equippedArmor.isCursed Or equippedWeapon.isCursed Or equippedAcce.isCursed Then Return True
        Return False
    End Function
    Function genDescription()
        allRoute()

        Dim out As String = ""
        'general statement
        out = "You are " & name & ", a " & sex & " " & pForm.name & " " & pClass.name & vbCrLf & " " & vbCrLf
        out += nextLevelXp - xp & " XP to next LVL" & vbCrLf & " " & vbCrLf
        'check for single image forms
        Select Case pForm.name
            Case "Dragon"
                out += "You are a large, green dragon." & DDUtils.RNRN
                Return out + outPutPerkText()
            Case "Broodmother"
                out += "You are a large, red dragon." & DDUtils.RNRN
                Return out + outPutPerkText()
            Case "Oni"
                out += "You are a massive red woman with small horns betraying a demonic origin."
                Return out + outPutPerkText()
            Case "Horse"
                out += "You are dark brown draft horse, bred for pulling heavy loads."
                Return out + outPutPerkText()
            Case "Blob"
                out += "You are a small cyan blob of slime, too pliable to maintain a constant form.  While the gelatinous goo that makes up your body gives you a certain durability, one solid strike may leave you in pieces."
                Return out + outPutPerkText()
            Case "Chicken"
            Case "Fae"
                out += "You are a small, naked farie with long blond hair and a feminine body.  While you can fly using the delicate pink wings attached to your back, your size makes it difficult to wear or use any form of equipment designed for bigger folk." & DDUtils.RNRN
                Return out + outPutPerkText()
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
            out += "hair, done in a feminine style." & vbCrLf & " " & vbCrLf
        Else
            out += "hair, done in a masculine style." & vbCrLf & " " & vbCrLf
        End If

        'body
        Select Case pForm.name
            Case "Blowup Doll"
                out += "You are a inflatable sex doll with " & getSkinColor() & "rubber skin.  "
                If prt.sexBool Then
                    out += "You have a feminine body, with huge breasts and a matching ""pussy""." & vbCrLf & " " & vbCrLf
                Else
                    out += "You have a feminine body, with huge breasts, though you do have a dildo-like cock." & vbCrLf & " " & vbCrLf
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
                    out += "Your body has a generally " & uAdj & " appearance, with " & bAdj & " breasts and a pussy between your legs." & vbCrLf & " " & vbCrLf
                Else
                    If breastSize = -1 Then
                        out += "Your body has a generally " & uAdj & " appearance, with a toned chest and a " & dAdj & " cock between your legs." & vbCrLf & " " & vbCrLf
                    Else
                        out += "Your body has a generally " & uAdj & " appearance, with " & bAdj & " breasts and a " & dAdj & " cock between your legs." & vbCrLf & " " & vbCrLf
                    End If
                End If
        End Select

        out += outPutPerkText()

        Return out
    End Function
    Function outPutPerkText() As String
        Dim out = ""
        If perks(perk.hunger) > -1 Then out += "You haven't eaten anything in a while and are starving." & vbCrLf & " " & vbCrLf
        If perks(perk.slutcurse) > -1 Then out += "You choose to dress very provocatively, showing as much skin as possible due to a curse."
        If perks(perk.polymorphed) > -1 Then out += "You are under the effects of a temporary polymorph, and will be for " & perks(perk.polymorphed) & " more turns." & vbCrLf & " " & vbCrLf
        If perks(perk.thrall) > -1 Then out += "You are under the thrall of a sorcerer/ess, and may not have full control over your body or mind." & vbCrLf & " " & vbCrLf
        If perks(perk.astatue) > -1 Then out += "You are currently a statue, and won't be able to do much for " & perks(perk.astatue) & " turns." & vbCrLf & " " & vbCrLf
        Return out
    End Function

    '|LEVELING|
    Public Sub levelUp()
        level += 1
        xp -= nextLevelXp
        nextLevelXp = nextLevelXp * level
        Game.pushLstLog("Level up!  " & name & " is now level " & level)
        If xp > nextLevelXp Then levelUp()
        health = 1
        maxHealth += 20

        pClass.onLVLUp(level, Me)
        pForm.onLVLUp(level, Me)
    End Sub
    Public Sub deLevel(ByVal lostLevels As Integer)
        If lostLevels < 1 Or level = 1 Then Exit Sub

        nextLevelXp = Math.Max(CInt(nextLevelXp / level), 125)
        maxHealth -= 20
        level -= 1

        If xp > nextLevelXp / 2 Then xp = nextLevelXp / 2

        pClass.deLVL(level, Me)
        pForm.deLVL(level, Me)

        If lostLevels > 1 Then
            deLevel(lostLevels - 1)
        End If
    End Sub
End Class
