Public Class Player
    'Player is the representation of a player controlled entity (the main player, any teammates)
    'METHODS AND VARIABLES RELATED TO LEVELING HAVE BEEN COMMENTED OUT.
    Inherits Entity

    'Player Instance variables
    Public sex, description As String
    Public pClass As pClass = New Classless()
    Public pForm As pForm = New Human()
    Dim turnCt As Integer = 0
    'Public level, xp, nextLevelXp As Integer
  
    Public breastSize As Integer = -1
    Public hunger As Integer
    Public equippedWeapon As Weapon
    Public equippedArmor As Armor
    Public equippedAcce As Accessory = New noAcce

    Public Shadows currTarget As NPC = Nothing

    Public perks As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)() 'perks also include triggers for events
    Public classes As Dictionary(Of String, pClass) = New Dictionary(Of String, pClass)()
    Public forms As Dictionary(Of String, pForm) = New Dictionary(Of String, pForm)()
    Public polymorphs As Dictionary(Of String, Transformation) = New Dictionary(Of String, Transformation)()
    Public pImage As Image 'tile image of the player
    Public TextColor As Color
    Public isPetrified = False
    'portrait variables
    Public sexBool As Boolean
    Public iArr As Image()
    Public iArrInd(16) As Tuple(Of Integer, Boolean, Boolean)
    Public haircolor As Color = Color.FromArgb(255, 204, 203, 213)
    Public skincolor As Color = Color.FromArgb(255, 247, 219, 195)

    'player & form states
    Public currState, pState, sState As State
    Public bimbState As State = New State()
    Public magGState As State = New State()
    Public goddState As State = New State()
    Public maidState As State = New State()
    Public prinState As State = New State()

    Dim formStates = {goddState, bimbState, magGState, maidState, prinState}

    Public solFlag = False
    Public wingInd = 0
    Public hornInd = 0
    Public prefForm As preferedForm

    Public ongoingTFs As List(Of Transformation) = New List(Of Transformation)

    '|CONSTRUCTORS|:
    Public Sub New()
        name = "TEMP_NAME"
        sex = "TEMP_SEX"
        health = 1.0
        maxHealth = 100
        attack = 10
        defence = 10
        will = 10
        speed = 10
        gold = 200
        lust = 0
        'level = 1
        'xp = 0
        'nextLevelXp = 100
        mana = 3
        maxMana = mana
        hunger = 0

        createInvPerks()
        inv.add(0, 1)
        inv.add(2, 1)
    End Sub
    'load from save constructors
    Public Sub New(ByVal s As String, ByVal v As Double)
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
        hunger = playArray(4)
        hBuff = playArray(5)
        mBuff = playArray(6)
        aBuff = playArray(7)
        dBuff = playArray(8)
        wBuff = playArray(9)
        sBuff = playArray(10)


        inv.load(playArray(11))
        Dim x As Integer = -2

        If Not playArray(14 + x).Equals("N/a") Then
            Dim crystal As Point = New Point(CInt(playArray(14 + x)), playArray(15 + x))
            forcedPath = {crystal}
            nextCombatAction = AddressOf ThrallTF.postLoadCrystalSpawn
        Else
            forcedPath = Nothing
        End If

        Dim currentIndex = 15 + x
        If Not playArray(14 + x).Equals("N/a") Then currentIndex += 1

        Dim stuff() As String = playArray(currentIndex).Split("$")
        If Not stuff(0).Equals("N/a") Then
            prefForm = New preferedForm(Color.FromArgb(CInt(stuff(0)), CInt(stuff(1)), CInt(stuff(2)), CInt(stuff(3))), _
                                        Color.FromArgb(CInt(stuff(4)), CInt(stuff(5)), CInt(stuff(6)), CInt(stuff(7))), _
                                        CBool(stuff(8)), CBool(stuff(9)), CInt(stuff(10)), CBool(stuff(11)), CInt(stuff(12)))
            CType(inv.item(69), ThrallCollar).setFormerLife(stuff(13), New Tuple(Of Integer, Boolean, Boolean)(CInt(stuff(14)), stuff(15), stuff(16)))
        Else
            CType(inv.item(69), ThrallCollar).setFormerLife(stuff(1), New Tuple(Of Integer, Boolean, Boolean)(CInt(stuff(2)), stuff(3), stuff(4)))
            ''If Not stuff(0).Equals("N/a") Then
            ''    prefForm = New preferedForm(Color.FromArgb(CInt(stuff(0)), CInt(stuff(1)), CInt(stuff(2)), CInt(stuff(3))),
            ''                                Color.FromArgb(CInt(stuff(5)), CInt(stuff(6)), CInt(stuff(7)), CInt(stuff(8))),
            ''                                CBool(stuff(9)), CBool(stuff(10)), CInt(stuff(11)), CBool(stuff(12)), CInt(stuff(13)))
            ''    CType(inv.item(69), ThrallCollar).setFormerLife(stuff(13), New Tuple(Of Integer, Boolean, Boolean)(CInt(stuff(14)), stuff(15), stuff(16)))
            ''Else
            ''    CType(inv.item(69), ThrallCollar).setFormerLife(stuff(1), New Tuple(Of Integer, Boolean, Boolean)(CInt(stuff(2)), stuff(3), stuff(4)))
            ''End If
        End If

        currentIndex += 1
        'MsgBox(UBound(playArray) & "/" & currentIndex)
        For i = 0 To CInt(playArray(currentIndex))
            Dim tf As Transformation = Transformation.newTF(playArray(currentIndex + 1 + i).Split("$"))
            ongoingTFs.Add(tf)
        Next

        currState.load(Me)
        ReDim iArr(16)

        turnCt = Game.turn

        createP()

        bsizeroute()
    End Sub

    '|CHARACTER CREATION/INITIALIZATION|
    Private Sub setStartingAccessory()
        'assigns an accessory based on the created player portrait
        If iArrInd(14).Item2 Then
            Select Case iArrInd(14).Item1
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
            Select Case iArrInd(14).Item1
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
    Public Sub setClassLoadout(ByVal s As String)
        'sets default weapon/armor/accessory
        equippedArmor = New CommonClothes
        equippedWeapon = New BareFists
        setStartingAccessory()
        'sets loadout based on selected class
        If s = "Warrior" Then
            inv.add(83, 1)
            inv.add(84, 1)
            equippedArmor = inv.item(83)
            equippedWeapon = inv.item(84)
        ElseIf s = "Mage" Then
            Game.cboxMG.Items.Add("Fireball")
            inv.add(2, 3)
            inv.add(4, 1)
            inv.add(21, 1)
            equippedWeapon = inv.item(21)
        End If
        'set class
        pClass = classes(s)
        'equip armor, boost mana if a staff is equipped
        Equipment.clothesChange(equippedArmor.getName)
        If equippedWeapon.GetType().IsSubclassOf(GetType(Staff)) Then mana += equippedWeapon.mBoost
        'set sexBool
        If sex = "Female" Then sexBool = True
        If sex = "Male" Then sexBool = False
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
        inv = New Inventory
        initPerks()
        initClasses()
        initForms()
        initPolymorphs()
    End Sub
    Private Sub initPerks()
        perks.Clear()
        'Creates the dictionary of perks
        perks.Add("hunger", -1) '0
        perks.Add("bimbotf", -1) '1
        perks.Add("slutcurse", -1) '2
        perks.Add("chickentf", -1) '3
        perks.Add("slimehair", -1) '4
        perks.Add("polymorphed", -1) '5
        perks.Add("nekocurse", -1) '6
        perks.Add("swordpossess", -1) '7
        perks.Add("vsslimehair", -1) '8
        perks.Add("brage", -1) '9
        perks.Add("mmammaries", -1) '10
        perks.Add("ihfury", -1) '11
        perks.Add("livearm", -1) '12
        perks.Add("livelinge", -1) '13
        perks.Add("thrall", -1) '14
        perks.Add("cowbell", -1) '15
        perks.Add("minRegen", -1) '16
        perks.Add("rotlg", -1) '17
        perks.Add("astatue", -1) '18
    End Sub
    Private Sub initClasses()
        'creates the class dictionary
        classes.Clear()
        classes.Add("Classless", New Classless())
        classes.Add("Warrior", New Warrior())
        classes.Add("Mage", New Mage())
        classes.Add("Magic Girl", New MagicGirl())
        classes.Add("Magic Girl​", New MagicGirlTransform())
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
    End Sub

    '|MOVEMENT COMMANDS|
    Public Overrides Sub reachedFPathDest()
        If Game.floor = 4 And Game.preBSBody Is Nothing And Not Game.preBSStartState Is Nothing And Game.floorboss(4) = "Ooze Empress" Then
            RandoTF.floor4FirstBossEncounter()
            Exit Sub
        End If
        If pClass.name.Equals("Thrall") Then
            If Int(Rnd() * 2) = 1 Then
                Dim out = "You've found one of the crystals your controller is seeking!  As you circle it, you feel a familiar presence enter your mind.  " & _
                    """Yes!  You've found it!"" your overseer states exitedly, ""I'll be over shortly, don't go anywhere and don't touch that crystal.""" & vbCrLf & _
                    "Obeying, you take a seat and wait for a few minutes before a violet portal opens up near the crystal and your master steps out."
                If will > 7 Then
                    out += "  In their attention to the crystal, they don't seem to notice you at all giving you a few minutes to yourself." & vbCrLf & vbCrLf & "Wait... if they aren't paying attention to you..." & vbCrLf & vbCrLf & "You fiddle around with your collar, and they still don't seem to notice your actions, so you leverage your thumb in the collars joint."
                    Game.pushLblEvent(out, AddressOf ThrallTF.betraySorc, AddressOf ThrallTF.waitSorc, "Break off your collar?")
                Else
                    out += "  Despite your excitement, they don't seem to notice you, instead focusing all their attention on the crystalline array.  As they fiddle with it, you notice a slight purple aura beginning to form around them and wait, are those horns sprouting out of their hair that seems to catch a non-existant wind?  With a flourish, they complete ... something ... and a blinding flash engulfs them.  Where once stood your human controller now stands a half-demon who only now seems to have taken notice of you." & _
                        """Well... It looks like you succeeded.  For that, I will give you an ultimatium.  Join me as my general, or die in these dungeons as my slave."
                    Game.pushLblEvent(out, AddressOf ThrallTF.acceptSorc, AddressOf ThrallTF.fightSorc, "Accept their offer?")
                End If

            Else
                Game.pushLblEvent("You've found one of the crystals your controller is seeking!  As you circle it, you feel a familiar presence enter your mind.  " & _
                    """No, that isn't it."" your overseer states disappointedly, ""Well, I guess you can go back to your buisness now.""")
                ongoingTFs.Add(New ThrallTF())
            End If
        End If
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
        Dim dmg As Integer = equippedWeapon.attack(Me, target)
        If dmg = -1 Then
            miss(target)
        ElseIf dmg = -2 Then
            cHit(Me.getATK, target)
        Else
            hit(dmg, target)
        End If

    End Sub
    'attacking a npc
    Private Sub miss(target As NPC)
        Game.pushLstLog(CStr("You miss" & target.title & " " & target.getName() & "!"))
        Game.pushLblCombatEvent(CStr("You miss" & target.title & " " & target.getName() & "!"))
    End Sub
    Private Sub hit(dmg As Integer, target As NPC)
        target.takeDMG(dmg, Me)
        Game.pushLstLog(CStr("You hit" & target.title & " " & target.getName() & " for " & dmg & " damage!"))
        Game.pushLblCombatEvent(CStr("You hit" & target.title & " " & target.getName() & " for " & dmg & " damage!"))
    End Sub
    Public Sub setTarget(ByRef t As NPC)
        currTarget = t
        MyBase.currTarget = t
    End Sub
    Private Sub cHit(dmg As Integer, target As NPC)
        target.takeDMG(dmg * 3, Me)
        Game.pushLstLog(CStr("You hit" & target.title & " " & target.getName() & " for " & dmg * 3 & " damage!  Critical hit!"))
        Game.pushLblCombatEvent(CStr("You hit" & target.title & " " & target.getName() & " for " & dmg * 3 & " damage!  Critical hit!"))
        target.isStunned = True
        target.stunct = 0
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

        target.takeDMG(dmg, Me)
        Game.pushLstLog(CStr("You hit " & target.getName() & " for " & dmg & " damage!"))
        Game.pushLblCombatEvent(CStr("You hit " & target.getName() & " for " & dmg & " damage!"))
    End Sub
    Private Sub cHit(dmg As Integer, target As Entity)
        If target.GetType() Is GetType(NPC) Or target.GetType.IsSubclassOf(GetType(NPC)) Then
            cHit(dmg, CType(target, NPC))
            Exit Sub
        End If

        target.takeDMG(dmg * 3, Me)
        Game.pushLstLog(CStr("You hit " & target.getName() & " for " & dmg * 3 & " damage!  Critical hit!"))
        Game.pushLblCombatEvent("You hit " & target.getName() & " for " & dmg * 3 & " damage!  Critical hit!")
    End Sub
    'taking damage
    Public Overrides Sub takeDMG(ByVal dmg As Integer, ByRef source As Entity)
        MyBase.takeDMG(dmg, source)
        Game.lblPHealtDiff.Tag -= dmg
    End Sub

    '|TRANSFORMATION METHODS|
    Public Sub revertToSState()
        Dim tHth As Integer = health + hBuff
        Dim tMna As Integer = mana + mBuff
        Dim tHun As Integer = hunger
        Dim tGold As Integer = gold
        Dim tEweap As Weapon = equippedWeapon
        Dim tEarm As Armor = equippedArmor
        If tEweap.getName = "Magic_Girl_Wand" Then tEweap = New BareFists()
        If tEarm.getName = "Magic_Girl_Outfit" Then tEarm = New Naked()

        sState.load(Me)

        mana = tMna
        gold = tGold
        equippedArmor = tEarm
        equippedWeapon = tEweap
        perks("slutcurse") = -1
        currState.save(Me)
        If Transformation.canBeTFed(Me) Then
            pState.save(Me)
        End If

        For i = 0 To ongoingTFs.Count - 1
            ongoingTFs.RemoveAt(i)
        Next

        If Game.cboxMG.SelectedItem = "Heartblast Starcannon" Then
            Game.cboxMG.Items.Insert(0, "-- Select --")
            Game.cboxMG.SelectedIndex = 0
        End If
        Do While Game.cboxMG.Items.Contains("Heartblast Starcannon")
            Game.cboxMG.Items.Remove("Heartblast Starcannon")
        Loop

        If health > 1 Then health = 1
        If mana > maxMana + mBuff Then mana = maxMana + mBuff

        Game.pushLblEvent("With a poof of smoke, you return to your original self!")
        Game.pImage = pImage
        Game.lblEvent.ForeColor = TextColor
        Game.lblNameTitle.ForeColor = TextColor

        changeHairColor(haircolor)
        createP()
        setPImage()
        UIupdate()
    End Sub
    Public Function revertToSState(ByVal numtorevert As Integer) As String
        Randomize()
        Dim loopct = 0
        Dim attributes As String() = {"Rear Hair", "Body", "Clothing", "Face", "Rear Hair", "Ears",
                                      "Nose", "Mouth", "Eyes", "Eyebrows", "Facial Mark", "Glasses",
                                      "Cloak", "Accessories", "Front Hair", "Hat", "Hair Color", "Skin Color"}
        Dim revertedAttributes As List(Of String) = New List(Of String)


        While numtorevert > 0
            If loopct > 100 Then
                revertToSState()
                Return ""
                Exit While
            End If

            Dim layer = Int(Rnd() * 18) + 1

            If (layer <= 16 AndAlso (iArrInd(layer).Item1 <> sState.iArrInd(layer).Item1 And
                               iArrInd(layer).Item2 <> sState.iArrInd(layer).Item2 And
                               iArrInd(layer).Item2 <> sState.iArrInd(layer).Item3)) Or
                           (layer = 17 And haircolor <> sState.getHairColor) Or
                            (layer = 18 And skincolor <> sState.getSkinColor) Then

                If layer = 18 Then
                    skincolor = sState.getSkinColor
                ElseIf layer = 17 Then
                    haircolor = sState.getHairColor
                ElseIf layer = 1 Or layer = 5 Then
                    iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(sState.iArrInd(1).Item1, sState.iArrInd(1).Item2, sState.iArrInd(1).Item3)
                    iArrInd(5) = New Tuple(Of Integer, Boolean, Boolean)(sState.iArrInd(5).Item1, sState.iArrInd(5).Item2, sState.iArrInd(5).Item3)
                ElseIf layer = 3 Then
                    Dim tEarm As Armor = sState.equippedArmor
                    iArrInd(layer) = New Tuple(Of Integer, Boolean, Boolean)(sState.iArrInd(layer).Item1, sState.iArrInd(layer).Item2, sState.iArrInd(layer).Item3)
                    If tEarm.getName = "Goddess_Gown" Or tEarm.getName = "Succubus_Garb" Then tEarm = New CommonClothes
                    If Not tEarm.getName.Equals("Magic_Girl_Outfit") Then equippedArmor = tEarm
                    Equipment.portraitUDate()
                Else
                    iArrInd(layer) = New Tuple(Of Integer, Boolean, Boolean)(sState.iArrInd(layer).Item1, sState.iArrInd(layer).Item2, sState.iArrInd(layer).Item3)
                End If
                numtorevert -= 1
                If Not revertedAttributes.Contains(attributes(layer)) Then revertedAttributes.Add(attributes(layer))
            End If
            loopct += 1
        End While
        createP()

        Dim out = revertedAttributes.Count & " changes were reverted." & vbCrLf & "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
        For Each atr In revertedAttributes
            out += vbCrLf & atr & " reverted."
        Next
        If revertedAttributes.Count > 0 Then out += vbCrLf & "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
        Return out
    End Function
    Public Sub revertToPState()
        Dim tHth As Integer = health + hBuff
        Dim tMna As Integer = mana + mBuff
        Dim tHun As Integer = hunger
        Dim tGold As Integer = gold
        Dim tEweap As Weapon = equippedWeapon
        Dim tEarm As Armor = equippedArmor

        Dim tpClassName As String = pClass.name
        Dim tpFormName As String = pForm.name
        Dim tpClassRP As String = pClass.revertPassage
        Dim tpFormRP As String = pClass.revertPassage

        If tEweap.getName = "Magic_Girl_Wand" Then tEweap = New BareFists()
        If tEarm.getName = "Goddess_Gown" Or tEarm.getName = "Succubus_Garb" Then tEarm = New CommonClothes
        pState.load(Me)

        mana = tMna
        gold = tGold
        If Not tEarm.getName.Equals("Magic_Girl_Outfit") Then equippedArmor = tEarm
        equippedWeapon = tEweap
        currState.save(Me)
        If Transformation.canBeTFed(Me) Then
            pState.save(Me)
        End If

        If Game.cboxMG.SelectedItem = "Heartblast Starcannon" Then
            Game.cboxMG.Items.Insert(0, "-- Select --")
            Game.cboxMG.SelectedIndex = 0
        End If
        Do While Game.cboxMG.Items.Contains("Heartblast Starcannon")
            Game.cboxMG.Items.Remove("Heartblast Starcannon")
            Game.pushLstLog("'Heartblast Starcannon' spell forgotten!")
        Loop

        If health > 1 Then health = 1
        If mana > maxMana + mBuff Then mana = maxMana + mBuff

        Dim out = ""
        If Not tpClassName.Equals(pClass.name) Then
            pClass.revert()
            If pClass.revertPassage <> "" Then out += pClass.revertPassage & vbCrLf & vbCrLf
        End If
        If Not tpFormName.Equals(pForm.name) Then
            pForm.revert()
            If pForm.revertPassage <> "" Then out += pForm.revertPassage & vbCrLf & vbCrLf
        End If

        Dim removeind = New List(Of Integer)
        For i = 0 To Game.player.ongoingTFs.Count - 1
            If Game.player.ongoingTFs(i).GetType().IsSubclassOf(GetType(PolymorphTF)) Then removeind.Add(i)
        Next
        For i = 0 To removeind.Count - 1
            ongoingTFs.RemoveAt(removeind(i))
        Next

        If Game.lblEvent.Visible = False Then Game.pushLblEvent(out & "You return to your former form!")
        Game.pImage = pImage
        Game.lblEvent.ForeColor = TextColor
        Game.lblNameTitle.ForeColor = TextColor

        changeHairColor(haircolor)

        createP()
        setPImage()
        UIupdate()
    End Sub
    Public Function revertToPState(ByVal numtorevert As Integer) As String
        Randomize()
        Dim loopct = 0
        Dim attributes As String() = {"Rear Hair", "Body", "Clothing", "Face", "Rear Hair", "Ears",
                                      "Nose", "Mouth", "Eyes", "Eyebrows", "Facial Mark", "Glasses",
                                      "Cloak", "Accessories", "Front Hair", "Hat", "Hair Color", "Skin Color"}
        Dim revertedAttributes As List(Of String) = New List(Of String)


        While numtorevert > 0
            If loopct > 100 Then
                revertToPState()
                Return ""
                Exit While
            End If

            Dim layer = Int(Rnd() * 18) + 1
            If (layer <= 16 AndAlso (iArrInd(layer).Item1 <> pState.iArrInd(layer).Item1 And
                               iArrInd(layer).Item2 <> pState.iArrInd(layer).Item2 And
                               iArrInd(layer).Item2 <> pState.iArrInd(layer).Item3)) Or
                           (layer = 17 And haircolor <> pState.getHairColor) Or
                            (layer = 18 And skincolor <> pState.getSkinColor) Then

                If layer = 18 Then
                    skincolor = pState.getSkinColor
                ElseIf layer = 17 Then
                    haircolor = pState.getHairColor
                ElseIf layer = 1 Or layer = 5 Then
                    iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(pState.iArrInd(1).Item1, pState.iArrInd(1).Item2, pState.iArrInd(1).Item3)
                    iArrInd(5) = New Tuple(Of Integer, Boolean, Boolean)(pState.iArrInd(5).Item1, pState.iArrInd(5).Item2, pState.iArrInd(5).Item3)
                ElseIf layer = 3 Then
                    Dim tEarm As Armor = pState.equippedArmor
                    iArrInd(layer) = New Tuple(Of Integer, Boolean, Boolean)(pState.iArrInd(layer).Item1, pState.iArrInd(layer).Item2, pState.iArrInd(layer).Item3)
                    If tEarm.getName = "Goddess_Gown" Or tEarm.getName = "Succubus_Garb" Then tEarm = New CommonClothes
                    If Not tEarm.getName.Equals("Magic_Girl_Outfit") Then equippedArmor = tEarm
                    Equipment.portraitUDate()
                Else
                    iArrInd(layer) = New Tuple(Of Integer, Boolean, Boolean)(pState.iArrInd(layer).Item1, pState.iArrInd(layer).Item2, pState.iArrInd(layer).Item3)
                End If
                numtorevert -= 1
                If Not revertedAttributes.Contains(attributes(layer)) Then revertedAttributes.Add(attributes(layer))
            End If
            loopct += 1
        End While
        createP()

        Dim out = revertedAttributes.Count & " changes were reverted." & vbCrLf & "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
        For Each atr In revertedAttributes
            out += vbCrLf & atr & " reverted."
        Next
        If revertedAttributes.Count > 0 Then out += vbCrLf & "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
        Return out
    End Function
    Public Sub petrify(ByVal c As Color, ByVal dur As Integer)
        If pForm.name.Equals("Dragon") Then revertToPState()
        perks("astatue") = dur
        changeHairColor(c)
        If sexBool Then
            iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(10, True, True)
            iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        Else
            iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(5, False, True)
            iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(6, False, True)
        End If
        changeSkinColor(c)

        iArr(8) = CharacterGenerator.recolor(iArr(8), c)
        iArr(9) = CharacterGenerator.recolor(iArr(9), c)
        isPetrified = True
        createP()

        canMoveFlag = False
        Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP(iArr)
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
    Public Overrides Sub die(ByRef source As Entity)
        initPerks()
        If Game.pnlSaveLoad.Visible = True Then Exit Sub
        If source Is Nothing Then
            DeathEffects.hardDeath()
            Game.npcList.Clear()
            Exit Sub
        End If

        source.currTarget = Nothing
        source.nextCombatAction = Nothing

        setHealth(0.1)

        If source.getName.Equals("Shopkeeper") Then
            DeathEffects.ShopkeeperDeath()
            Exit Sub
        ElseIf source.getName.Equals("Mindless Bimbo") Then
            DeathEffects.MBimboDeath()
            Exit Sub
        ElseIf source.getName.Equals("Mesmerized Thrall") Or source.getName.Equals("Mesmerized Thrall​") Then
            DeathEffects.thrallDeath()
            Exit Sub
        ElseIf source.getName.Equals("Enthralling Sorcerer") Or source.getName.Equals("Enthralling Sorceress") Then
            DeathEffects.sorcererDeath()
            Exit Sub
        ElseIf source.getName.Equals("Slime") Or source.getName.Equals("Goo Girl") Then
            DeathEffects.slimeDeath()
            Exit Sub
        ElseIf source.getName.Equals("Spider") Or source.getName.Equals("Arachne Huntress") Then
            DeathEffects.spiderDeath()
            Exit Sub
        ElseIf source.getName.Equals("Mimic") Then
            DeathEffects.mimicDeath()
            Exit Sub
        ElseIf source.getName.Equals("Ooze Empress") Then
            DeathEffects.oozeEmpDeath()
            Exit Sub
        ElseIf source.getName.Equals("Hunger") Then
            Game.pushLblEvent("You starve to death!")
        End If

        DeathEffects.hardDeath()
        Game.npcList.Clear()
    End Sub
    Public Sub setPImage()
        'sets the player call
        If pClass.name.Equals("Bimbo") Then
            If Game.floor > 5 Then
                pImage = Game.picBimbof.BackgroundImage
            Else
                pImage = Game.picPlayerB.BackgroundImage
            End If
        Else
            If Game.floor > 5 Then
                pImage = Game.picPlayerf.BackgroundImage
            Else
                pImage = Game.picPlayer.BackgroundImage
            End If
        End If
    End Sub

    '|UPDATE METHODS|
    Public Overrides Sub update()
        '|COMBAT|
        If perks("astatue") > -1 Then nextCombatAction = AddressOf PerkEffects.statueMove
        MyBase.update()

        '|PLAYER STAT UPKEEP|
        If hunger >= 100 Then
            perks("hunger") = 0
        ElseIf hunger > 100 Then
            hunger = 100
        ElseIf Game.turn Mod 25 = 0 Then
            hunger += 1
        End If

        If health > 1 Then health = 1
        If will < 0 Then will = 0
        If mana > getMaxMana() And Not Game.combatmode And Not solFlag Then mana = getMaxMana()

        '|PERK AND TRANSFORMATION UPDATES|
        Dim pUpdateFlag As Boolean = False
        'perks
        If Game.turn <> turnCt Then
            turnCt = Game.turn
            pUpdateFlag = perkUpdate()
        End If
        UIupdate()
        'transformations
        Dim removeind = New List(Of Integer)
        For i = 0 To ongoingTFs.Count - 1
            If Not ongoingTFs(i) Is Nothing Then
                If ongoingTFs(i).getTFDone Then
                    removeind.Add(i)
                Else
                    Dim c = ongoingTFs(i).getturnsTilNextStep
                    If c = 0 Then pUpdateFlag = True
                    ongoingTFs(i).update()
                End If
            Else
                ongoingTFs.RemoveAt(i)
            End If
        Next
        For i = 0 To removeind.Count - 1
            ongoingTFs.RemoveAt(removeind(i))
        Next
        If pUpdateFlag Then createP()


    End Sub
    Function perkUpdate() As Boolean
        Dim needsToUpdatePortrait = False
        '|GENERAL EFFECTS|
        'hunger
        If perks("hunger") > -1 And Game.turn Mod 5 = 0 Then
            PerkEffects.hungerEffect()
        End If
        'clothing curse
        If perks("slutcurse") > -1 Then
            needsToUpdatePortrait = Equipment.clothingCurse1()
        End If
            'slime hair health regen
            If perks("slimehair") > -1 Then
                PerkEffects.slimeHairRegen()
            End If
            'vial of slime hair regen
            If perks("vsslimehair") > -1 Then
                PerkEffects.vslimeHairRegen()
            End If

            'ring of min. regen
            If perks("minRegen") > -1 Then
                PerkEffects.minorRegen()
            End If

            'living armor
            If perks("livearm") > -1 Then
                needsToUpdatePortrait = PerkEffects.livingArmor()
            End If
            'living lingerie
            If perks("livelinge") > -1 Then
                needsToUpdatePortrait = PerkEffects.livingLingerie()
            End If

            'rotlg
            If perks("rotlg") > -1 Then
                PerkEffects.ROTLGRoute()
            End If

            '|TRANSFORMATION TRIGGERS|
            'targax sword tf
            If perks("swordpossess") > -1 Then
                PerkEffects.targaxSwordTF()
            End If
            'shift toward prefered form
            If Not prefForm Is Nothing AndAlso (pClass.name = "Thrall" Xor equippedAcce.getName.Equals("Slave_Collar")) AndAlso Not prefForm.playerMeetsForm(Game.player) And Not pForm.name.Equals("Half-Succubus") And Not perks("thrall") = 1 And Not perks("nekocurse") > -1 And Not perks("polymorphed") > -1 And Not perks("bimbotf") > -1 Then
                PerkEffects.thrallRestore()
            End If
            If perks("astatue") > -1 Then
                PerkEffects.aStatue()
            End If

            '|SPECIAL MOVE HANDLERS|
            'berserker rage special
            If perks("brage") > -1 Then
                PerkEffects.berserkerRage()
            End If
            'massive mammaries special
            If perks("mmammaries") > -1 Then
                PerkEffects.massiveMammaries()
            End If
            'ironhide fury
            If perks("ihfury") > -1 Then
                PerkEffects.ironhideFury()
            End If


            description = CStr(name & " is a " & sex & " " & pForm.name & " " & pClass.name)
            Return needsToUpdatePortrait
    End Function
    Sub UIupdate()
        If Game.lblNameTitle.Text <> name & " the " & pClass.name Then Game.lblNameTitle.Text = name & " the " & pClass.name
        If Game.lblHealth.Text <> "Health = " & CInt(health * getMaxHealth()) & "/" & getMaxHealth() Then Game.lblHealth.Text = "Health = " & CInt(health * getMaxHealth()) & "/" & getMaxHealth()
        If Game.lblMana.Text <> "Mana = " & mana & "/" & getMaxMana() Then Game.lblMana.Text = "Mana = " & mana & "/" & getMaxMana()
        If Game.lblHunger.Text <> "Hunger = " & hunger & "/100" Then Game.lblHunger.Text = "Hunger = " & hunger & "/100"
        If Game.lblATK.Text <> "ATK = " & (getATK()) + equippedWeapon.aBoost Then Game.lblATK.Text = "ATK = " & (getATK()) + equippedWeapon.aBoost
        If Game.lblDEF.Text <> "DEF = " & getDEF() Then Game.lblDEF.Text = "DEF = " & getDEF()
        If Game.lblSKL.Text <> "WIL = " & getWIL() Then Game.lblSKL.Text = "WIL = " & getWIL()
        If Game.lblSPD.Text <> "SPD = " & getSPD() Then Game.lblSPD.Text = "SPD = " & getSPD()
        If Game.lblGold.Text <> "GOLD = " & gold And gold <= 999999 Then
            Game.lblGold.Text = "GOLD = " & gold
        ElseIf Game.lblGold.Text <> "GOLD = " & gold And Game.lblGold.Text <> "GOLD = 999999+" Then
            Game.lblGold.Text = "GOLD = 999999+"
        End If

        Dim numItems As Integer = Game.lstInventory.Items.Count
        Dim tArr(inv.count + 5) As String
        Dim ct As Integer = 0
        If Game.invFilters(0) Then
            tArr(ct) = "-USEABLES:"
            ct += 1
            Dim u_list = inv.getUseable
            Array.Sort(u_list)
            For i = 0 To UBound(u_list)
                If u_list(i).getCount > 0 Then
                    tArr(ct) = " " & u_list(i).getName() & " x" & u_list(i).count
                    ct += 1
                End If
            Next
        End If
        If Game.invFilters(1) Then
            tArr(ct) = "-POTIONS:"
            ct += 1
            Dim p_list = inv.getPotions
            Array.Sort(p_list)
            For i = 0 To UBound(p_list)
                If p_list(i).getCount > 0 Then
                    tArr(ct) = " " & p_list(i).getName() & " x" & p_list(i).count
                    ct += 1
                End If
            Next
        End If
        If Game.invFilters(2) Then
            tArr(ct) = "-FOOD:"
            ct += 1
            Dim f_list = inv.getFood
            Array.Sort(f_list)
            For i = 0 To UBound(f_list)
                If f_list(i).getCount > 0 Then
                    tArr(ct) = " " & f_list(i).getName() & " x" & f_list(i).count
                    ct += 1
                End If
            Next
        End If
        If Game.invFilters(3) Then
            tArr(ct) = "-ARMOR:"
            ct += 1
            Dim a_list = inv.getArmors.Item2
            Array.Sort(a_list)
            For i = 0 To UBound(a_list)
                If a_list(i).getCount > 0 Then
                    tArr(ct) = " " & a_list(i).getName() & " x" & a_list(i).count
                    ct += 1
                End If
            Next
        End If
        If Game.invFilters(4) Then
            tArr(ct) = "-WEAPONS:"
            ct += 1
            Dim w_list = inv.getWeapons.Item2
            Array.Sort(w_list)
            For i = 0 To UBound(w_list)
                If w_list(i).getCount > 0 Then
                    tArr(ct) = " " & w_list(i).getName() & " x" & w_list(i).count
                    ct += 1
                End If
            Next
        End If
        If Game.invFilters(6) Then
            tArr(ct) = "-ACCESSORIES:"
            ct += 1
            Dim ac_list = inv.getAccesories.Item2
            Array.Sort(ac_list)
            For i = 0 To UBound(ac_list)
                If ac_list(i).getCount > 0 Then
                    tArr(ct) = " " & ac_list(i).getName() & " x" & ac_list(i).count
                    ct += 1
                End If
            Next
        End If
        If Game.invFilters(5) Then
            tArr(ct) = "-MISC:"
            ct += 1
            Dim m_list = inv.getMisc
            Array.Sort(m_list)
            For i = 0 To UBound(m_list)
                If m_list(i).getCount > 0 Then
                    tArr(ct) = " " & m_list(i).getName() & " x" & m_list(i).count
                    ct += 1
                End If
            Next
        End If
        If ct <> numItems Or inv.invNeedsUDate Then
            Game.lstInventory.Items.Clear()
            For i = 0 To UBound(tArr)
                If Not tArr(i) Is Nothing Then Game.lstInventory.Items.Add(tArr(i))
            Next
        End If
        inv.invNeedsUDate = False
        'Dim t As Boolean = CharacterGenerator.CreateBMP(iArr).Equals(Game.picPortrait.BackgroundImage)
        'Dim t As Boolean = picsAreSame(CharacterGenerator.CreateBMP(iArr), New Bitmap(Game.picPortrait.BackgroundImage))
        ''If Game.turn < 2 AndAlso Not CharacterGenerator.CreateBMP(iArr).Equals(Game.picPortrait.BackgroundImage) Then createP() 'Form3.portraitUDate()
        'If Game.turn < 2 AndAlso Not t Then createP() 'Form3.portraitUDate()
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
        If pForm.name.Equals("Dragon") Then
            Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP({Game.picDragon.BackgroundImage})
            b = True
        ElseIf pClass.name.Equals("Magic Girl​") Then
            Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP({Game.picmgp1.BackgroundImage})
            b = True
        ElseIf pForm.name.Equals("Sheep") Then
            Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP({Game.picSheep.BackgroundImage})
            b = True
        ElseIf pForm.name.Equals("Cake") Then
            Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP({Game.picCake.BackgroundImage})
            b = True
        ElseIf pForm.name.Equals("Frog") Then
            Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP({Game.picFrog.BackgroundImage})
            b = True
        ElseIf pClass.name.Equals("Princess​") Then
            Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP({Game.picPrin.BackgroundImage})
            b = True
        ElseIf pClass.name.Equals("Bunny Girl​") Then
            Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP({Game.picBun.BackgroundImage})
            b = True
        End If
    End Sub
    Public Sub createP()
        'If Game.noImg Then Exit Sub

        If solFlag Then Exit Sub

        If Not Game.picPortrait.BackgroundImage Is Nothing Then Game.picPortrait.BackgroundImage.Dispose()

        Dim chk = False

        If Not solFlag Then Equipment.portraitUDate()
        For i = 0 To 16
            Try
                    iArr(i) = Game.imgLib.atrs(Game.imgLib.atrs.Keys(i)).getAt(iArrInd(i))
            Catch ex As Exception
                MsgBox("Error!  Exception thrown in portrait creation (specifically in the " & Game.imgLib.atrs.Keys(i) & " layer).  The player character will now revert to default.")
                revertToSState()
            End Try
        Next

        changeHairColor(haircolor)
        changeSkinColor(skincolor)

        If isPetrified Then
            iArr(8) = CharacterGenerator.recolor(iArr(8), skincolor)
            iArr(9) = CharacterGenerator.recolor(iArr(9), skincolor)
        End If

        hideEars()
        If lust > 0 Then lustBlushUpdate()
        If wingInd > 0 Then addWings(wingInd)
        If hornInd > 0 Then addHorns(hornInd)

        If Not solFlag And Not chk Then Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP(iArr)
        oneLayerImgCheck(chk)
        Game.picPortrait.Update()

        currState.save(Me)

        Game.lblEvent.ForeColor = TextColor
        Game.lblNameTitle.ForeColor = TextColor
    End Sub
    Public Sub changeHairColor(ByVal c As Color)
        haircolor = c

        iArr(1) = CharacterGenerator.recolor(Game.imgLib.atrs("RearHair2").getAt(iArrInd(1)), c)
        iArr(5) = CharacterGenerator.recolor(Game.imgLib.atrs("RearHair1").getAt(iArrInd(5)), c)
        iArr(10) = CharacterGenerator.recolor(Game.imgLib.atrs("Eyebrows").getAt(iArrInd(10)), c)
        iArr(15) = CharacterGenerator.recolor(Game.imgLib.atrs("FrontHair").getAt(iArrInd(15)), c)

        If Not solFlag Then Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP(iArr)
    End Sub
    Public Sub changeSkinColor(ByVal c As Color)
        skincolor = c

        iArr(2) = CharacterGenerator.recolor2(Game.imgLib.atrs("Body").getAt(iArrInd(2)), c)
        iArr(4) = CharacterGenerator.recolor2(Game.imgLib.atrs("Face").getAt(iArrInd(4)), c)
        iArr(6) = CharacterGenerator.recolor2(Game.imgLib.atrs("Ears").getAt(iArrInd(6)), c)
        iArr(7) = CharacterGenerator.recolor2(Game.imgLib.atrs("Nose").getAt(iArrInd(7)), c)

        If Not solFlag Then Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP(iArr)
    End Sub
    Public Sub lustBlushUpdate()
        Select Case Int(lust / 20)
            Case 0
            Case 1
                iArr(4) = CharacterGenerator.CreateBMP({iArr(4), Game.picLust1.BackgroundImage})
            Case 2
                iArr(4) = CharacterGenerator.CreateBMP({iArr(4), Game.picLust2.BackgroundImage})
            Case 3
                iArr(4) = CharacterGenerator.CreateBMP({iArr(4), Game.picLust3.BackgroundImage})
            Case Else
                iArr(4) = CharacterGenerator.CreateBMP({iArr(4), Game.picLust4.BackgroundImage})
        End Select
    End Sub
    Sub addWings(ByVal i As Integer)
        iArr(1) = CharacterGenerator.CreateBMP({Game.imgLib.atrs("Wings").getM(i), iArr(1)})
    End Sub
    Sub addHorns(ByVal i As Integer)
        iArr(6) = CharacterGenerator.CreateBMP({Game.imgLib.atrs("Horns").getM(i), iArr(6)})
    End Sub
    Sub hideEars()
        If iArrInd(6).Item1 = 1 Or iArrInd(6).Item1 = 2 Or (Not iArrInd(5).Item2 And iArrInd(5).Item1 <> 2) Then Exit Sub

        Dim t = iArr(5).Clone
        iArr(5) = iArr(6).Clone
        iArr(6) = t
    End Sub
    Sub setIAInd(ByVal attrInd As Integer, ByVal i As Integer, ByVal b As Boolean, ByVal nonDefFlag As Boolean)
        iArrInd(attrInd) = New Tuple(Of Integer, Boolean, Boolean)(i, b, nonDefFlag)
    End Sub
    Sub setIAInd(ByVal attrInd As Integer, ByVal iaInd As Tuple(Of Integer, Boolean, Boolean))
        iArrInd(attrInd) = iaInd
    End Sub
    Function checkNDefFemInd(ByVal attrInd As Integer, ByVal i As Integer) As Boolean
        Dim ind = iArrInd(attrInd)
        If Not ind.Item2 Or Not ind.Item3 Then Return False
        If Game.imgLib.atrs(Game.imgLib.atrs.Keys(attrInd)).rosf(ind.Item1) = i Then Return True Else Return False
    End Function
    Function checkNDefMalInd(ByVal attrInd As Integer, ByVal i As Integer) As Boolean
        Dim ind = iArrInd(attrInd)
        If ind.Item2 Or ind.Item3 Then Return False
        If Game.imgLib.atrs(Game.imgLib.atrs.Keys(attrInd)).rosm(ind.Item1) = i Then Return True Else Return False
    End Function
    Function checkFemInd(ByVal attrInd As Integer, ByVal i As Integer) As Boolean
        Dim ind = iArrInd(attrInd)
        If Not ind.Item2 Or Not ind.Item3 Then Return False
        If ind.Item1 = i Then Return True Else Return False
    End Function
    Function checkMalInd(ByVal attrInd As Integer, ByVal i As Integer) As Boolean
        Dim ind = iArrInd(attrInd)
        If ind.Item2 Or ind.Item3 Then Return False
        If ind.Item1 = i Then Return True Else Return False
    End Function
    'sex change methods
    Public Sub MtF()
        If perks("polymorphed") > -1 Or pClass.name.Equals("Magic Girl") Then
            Game.pushLstLog("Your form prevents you from being altered.")
            Exit Sub
        End If
        sexBool = True
        sex = "Female"
        breastSize = 1
        idRouteMF()
        changeSkinColor(skincolor)
        If perks("swordpossess") > -1 Then perks("swordpossess") = 0
    End Sub
    Public Sub FtM()
        If perks("polymorphed") > -1 Or pClass.name.Equals("Magic Girl") Then
            Game.pushLstLog("Your form prevents you from being altered.")
            Exit Sub
        End If
        sexBool = False
        sex = "Male"
        breastSize = -1
        perks(2) = False
        idRouteFM()
        If perks("swordpossess") > -1 Then perks("swordpossess") = 0

    End Sub
    Sub idRouteMF()
        'rearHair2
        If Not iArrInd(1).Item2 Then
            Select Case iArrInd(1).Item1
                Case 5
                    iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(13, True, True)
            End Select
        End If
        'body
        If Not iArrInd(2).Item2 Then
            Select Case iArrInd(2).Item1
                Case 0
                    iArrInd(2) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
            End Select
        End If
        'clothing
        Select Case iArrInd(3).Item1
            Case 5
                iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
            Case Else
                If iArrInd(3).Item1 < 5 Then
                    iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(3).Item1, True, False)
                Else
                    Equipment.portraitUDate()
                End If
        End Select
        'face
        Select Case iArrInd(4).Item1
            Case Else
                iArrInd(4) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        End Select
        'rearHair1
        If Not iArrInd(5).Item2 Then
            Select Case iArrInd(5).Item1
                Case 5
                    iArrInd(5) = New Tuple(Of Integer, Boolean, Boolean)(15, True, True)
            End Select
        End If
        'nose
        Select Case iArrInd(7).Item1
            Case Else
                iArrInd(7) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        End Select

        'ears
        Select Case iArrInd(6).Item1
            Case 5
                iArrInd(6) = New Tuple(Of Integer, Boolean, Boolean)(5, True, True)
            Case Else
                iArrInd(6) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(6).Item1, True, False)
        End Select
        'mouth
        Select Case iArrInd(8).Item1
            Case 5
                iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(10, True, True)
            Case Else
                iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(8).Item1, True, False)
        End Select
        'eyes
        Select Case iArrInd(9).Item1
            Case 5
                iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(11, True, True)
            Case 6
                iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
            Case 7
                iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(15, True, True)
            Case 8
                iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)
            Case Else
                iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(9).Item1, True, False)
        End Select
        'eyebrows
        Select Case iArrInd(10).Item1
            Case Else
                iArrInd(10) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(10).Item1, True, False)
        End Select
        'accesory
        Select Case iArrInd(14).Item1
            Case 1
                iArrInd(14) = New Tuple(Of Integer, Boolean, Boolean)(2, True, False)
            Case 2
                iArrInd(14) = New Tuple(Of Integer, Boolean, Boolean)(3, True, False)
        End Select
        'fronthair
        If Not iArrInd(15).Item2 Then
            Select Case iArrInd(15).Item1
                Case 6
                    iArrInd(15) = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)
            End Select
        End If
    End Sub
    Sub idRouteFM()
        'rearHair2
        Select Case iArrInd(1).Item1
            Case 13
                iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(5, False, True)
        End Select
        'body
        Select Case iArrInd(2).Item1
            Case Else
                iArrInd(2) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
        End Select
        'clothing
        Select Case iArrInd(3).Item1
            Case 47
                iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(5, False, True)
            Case Else
                If iArrInd(3).Item1 < 5 Then
                    iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(3).Item1, False, False)
                Else
                    Equipment.portraitUDate()
                End If
        End Select
        'face
        Select Case iArrInd(4).Item1
            Case Else
                iArrInd(4) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
        End Select
        'rearHair1
        Select Case iArrInd(5).Item1
            Case 15
                iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(5, False, True)
        End Select
        'nose
        Select Case iArrInd(7).Item1
            Case Else
                iArrInd(7) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        End Select

        'ears
        Select Case iArrInd(6).Item1
            Case 5
                iArrInd(6) = New Tuple(Of Integer, Boolean, Boolean)(5, False, True)
            Case Is < 5
                iArrInd(6) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(6).Item1, False, False)
        End Select
        'mouth
        Select Case iArrInd(8).Item1
            Case 10
                iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(5, False, True)
            Case Else
                If iArrInd(8).Item1 < 5 Then iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(8).Item1, False, False)
        End Select
        'eyes
        Select Case iArrInd(9).Item1
            Case 11
                iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(5, False, True)
            Case 14
                iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(6, False, True)
            Case 15
                iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(7, False, True)
            Case 19
                iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(8, False, True)
            Case Else
                If iArrInd(9).Item1 < 5 Then iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(9).Item1, False, False)
        End Select
        'eyebrows
        Select Case iArrInd(10).Item1
            Case Else
                iArrInd(10) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(10).Item1, False, False)
        End Select
        'accesory
        Select Case iArrInd(14).Item1
            Case 2
                iArrInd(14) = New Tuple(Of Integer, Boolean, Boolean)(1, False, False)
            Case 3
                iArrInd(14) = New Tuple(Of Integer, Boolean, Boolean)(2, False, False)
        End Select
        'fronthair
        Select Case iArrInd(15).Item1
            Case 12
                iArrInd(15) = New Tuple(Of Integer, Boolean, Boolean)(6, False, True)
        End Select
    End Sub
    Sub idRouteMFHalf()
        'rearHair2
        If Not iArrInd(1).Item2 And Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(1).Item1
                Case 5
                    iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(13, True, True)
            End Select
        End If
        'body
        If Int(Rnd() * 2) = 0 Then
            If Not iArrInd(2).Item2 And Int(Rnd() * 2) = 0 Then
                Select Case iArrInd(2).Item1
                    Case 0
                        iArrInd(2) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
                End Select
            End If
        End If
        'clothing
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(3).Item1
                Case 5
                    iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
                Case Else
                    If iArrInd(3).Item1 < 5 Then
                        iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(3).Item1, True, False)
                    Else
                        Equipment.portraitUDate()
                    End If
            End Select
        End If
        'face
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(4).Item1
                Case Else
                    iArrInd(4) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
            End Select
        End If
        'rearHair1
        If Int(Rnd() * 2) = 0 Then
            If Not iArrInd(5).Item2 And Int(Rnd() * 2) = 0 Then
                Select Case iArrInd(5).Item1
                    Case 5
                        iArrInd(5) = New Tuple(Of Integer, Boolean, Boolean)(15, True, True)
                End Select
            End If
        End If
        'nose
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(7).Item1
                Case Else
                    iArrInd(7) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
            End Select
        End If
        'ears
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(6).Item1
                Case 5
                    iArrInd(6) = New Tuple(Of Integer, Boolean, Boolean)(5, True, True)
                Case Else
                    iArrInd(6) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(6).Item1, True, False)
            End Select
        End If
        'mouth
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(8).Item1
                Case 5
                    iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(10, True, True)
                Case Else
                    iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(8).Item1, True, False)
            End Select
        End If
        'eyes
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(9).Item1
                Case 5
                    iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(11, True, True)
                Case 6
                    iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
                Case 7
                    iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(15, True, True)
                Case 8
                    iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)
                Case Else
                    iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(9).Item1, True, False)
            End Select
        End If
        'eyebrows
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(10).Item1
                Case Else
                    iArrInd(10) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(10).Item1, True, False)
            End Select
        End If
        'accesory
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(14).Item1
                Case 1
                    iArrInd(14) = New Tuple(Of Integer, Boolean, Boolean)(2, True, False)
                Case 2
                    iArrInd(14) = New Tuple(Of Integer, Boolean, Boolean)(3, True, False)
            End Select
        End If
        'fronthair
        If Not iArrInd(15).Item2 And Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(15).Item1
                Case 6
                    iArrInd(15) = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)
            End Select
        End If
    End Sub
    Sub idRouteFMHalf()
        'rearHair2
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(1).Item1
                Case 13
                    iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(5, False, True)
            End Select
        End If
        'body
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(2).Item1
                Case Else
                    iArrInd(2) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
            End Select
        End If
        'clothing
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(3).Item1
                Case 47
                    iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(5, False, True)
                Case Else
                    If iArrInd(3).Item1 < 5 Then
                        iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(3).Item1, False, False)
                    Else
                        Equipment.portraitUDate()
                    End If
            End Select
        End If
        'face
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(4).Item1
                Case Else
                    iArrInd(4) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
            End Select
        End If
        'rearHair1
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(5).Item1
                Case 15
                    iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(5, False, True)
            End Select
        End If
        'nose
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(7).Item1
                Case Else
                    iArrInd(7) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
            End Select
        End If
        'ears
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(6).Item1
                Case 5
                    iArrInd(6) = New Tuple(Of Integer, Boolean, Boolean)(5, False, True)
                Case Is < 5
                    iArrInd(6) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(6).Item1, False, False)
            End Select
        End If
        'mouth
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(8).Item1
                Case 10
                    iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(5, False, True)
                Case Else
                    If iArrInd(8).Item1 < 5 Then iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(8).Item1, False, False)
            End Select
        End If
        'eyes
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(9).Item1
                Case 11
                    iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(5, False, True)
                Case 14
                    iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(6, False, True)
                Case 15
                    iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(7, False, True)
                Case 19
                    iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(8, False, True)
                Case Else
                    If iArrInd(9).Item1 < 5 Then iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(9).Item1, False, False)
            End Select
        End If
        'eyebrows
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(10).Item1
                Case Else
                    iArrInd(10) = New Tuple(Of Integer, Boolean, Boolean)(iArrInd(10).Item1, False, False)
            End Select
        End If
        'accesory
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(14).Item1
                Case 2
                    iArrInd(14) = New Tuple(Of Integer, Boolean, Boolean)(1, False, False)
                Case 3
                    iArrInd(14) = New Tuple(Of Integer, Boolean, Boolean)(2, False, False)
            End Select
        End If
        'fronthair
        If Int(Rnd() * 2) = 0 Then
            Select Case iArrInd(15).Item1
                Case 12
                    iArrInd(15) = New Tuple(Of Integer, Boolean, Boolean)(6, False, True)
            End Select
        End If
    End Sub
    Public Sub lustUpdate()
        Select Case Int(lust / 20)
            Case 0
            Case 1
                iArr(4) = CharacterGenerator.CreateBMP({iArr(4), Game.picLust1.BackgroundImage})
            Case 2
                iArrInd(14) = New Tuple(Of Integer, Boolean, Boolean)(1, False, False)
            Case 3
                iArrInd(14) = New Tuple(Of Integer, Boolean, Boolean)(2, False, False)
        End Select
        'fronthair
        Select Case iArrInd(15).Item1
            Case 12
                iArrInd(15) = New Tuple(Of Integer, Boolean, Boolean)(6, False, True)
        End Select
    End Sub
    'breast enlargement/reduction methods
    Public Sub be()
        If Not Transformation.canBeTFed(Me) And Not pClass.name.Equals("Thrall") Then
            Game.pushLstLog("Your form prevents you from being altered.")
            Exit Sub
        End If

        If breastSize >= -1 And breastSize < 7 Then
            breastSize += 1
            reverseBSRoute()
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
            reverseBSRoute()
            Game.pushLstLog("- 1 cup size!")
        Else
            Game.pushLstLog("Your breasts can get no smaller!")
        End If
    End Sub
    Sub bsizeroute()
        If Game.imgLib Is Nothing Or iArr Is Nothing Or
            iArrInd Is Nothing Or solFlag Then Exit Sub
        If (checkFemInd(2, 0) Or checkNDefFemInd(2, 5)) And breastSize <> 1 Then
            breastSize = 1
        ElseIf (checkNDefFemInd(2, 1) Or checkNDefFemInd(2, 6) Or checkNDefFemInd(2, 21)) And breastSize <> 2 Then
            breastSize = 2
        ElseIf (checkNDefFemInd(2, 2) Or checkNDefFemInd(2, 7) Or checkNDefFemInd(2, 10) Or checkNDefFemInd(2, 16)) And breastSize <> 3 Then
            breastSize = 3
        ElseIf (checkNDefFemInd(2, 3) Or checkNDefFemInd(2, 8)) And breastSize <> 4 Then
            breastSize = 4
        ElseIf (checkNDefFemInd(2, 4) Or checkNDefFemInd(2, 9)) And breastSize <> 5 Then
            breastSize = 5
        ElseIf (checkNDefFemInd(2, 17) Or checkNDefFemInd(2, 18)) And breastSize <> 6 Then
            breastSize = 6
        ElseIf (checkNDefFemInd(2, 19) Or checkNDefFemInd(2, 20)) And breastSize <> 7 Then
            breastSize = 7
        ElseIf (checkNDefMalInd(2, 2)) And breastSize <> 0 Then
            breastSize = 0
        ElseIf (checkMalInd(2, 0)) And breastSize <> -1 Then
            breastSize = -1
        End If
    End Sub
    Public Sub reverseBSRoute()
        Select Case breastSize
            Case -1
                iArrInd(2) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
            Case 0
                iArrInd(2) = New Tuple(Of Integer, Boolean, Boolean)(2, False, True)
            Case 1
                iArrInd(2) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
            Case 2
                iArrInd(2) = New Tuple(Of Integer, Boolean, Boolean)(1, True, True)
            Case 3
                iArrInd(2) = New Tuple(Of Integer, Boolean, Boolean)(2, True, True)
            Case 4
                iArrInd(2) = New Tuple(Of Integer, Boolean, Boolean)(3, True, True)
            Case 5
                iArrInd(2) = New Tuple(Of Integer, Boolean, Boolean)(4, True, True)
            Case 6
                iArrInd(2) = New Tuple(Of Integer, Boolean, Boolean)(17, True, True)
            Case 7
                iArrInd(2) = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)
        End Select
        Equipment.portraitUDate()
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
        output += hunger & "*"
        output += hBuff & "*"
        output += mBuff & "*"
        output += aBuff & "*"
        output += dBuff & "*"
        output += wBuff & "*"
        output += sBuff & "*"

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

        output += "*" & ongoingTFs.Count - 1 & "*"
        For i = 0 To ongoingTFs.Count - 1
            output += ongoingTFs(i).ToString
        Next
        Return output
    End Function
    Public Function toGhost() As String
        Dim output = CStr(name & " the " & pForm.name & " " & pClass.name & "*" & health & "*" & maxHealth &
            "*" & getATK() & "*" & getDEF() & "*" & getSPD() & "*" & sexBool & "*" & haircolor.R & "*" & haircolor.G & "*" & haircolor.B & "*")
        output += inv.save
        For i = 0 To UBound(iArrInd)
            output += (iArrInd(i).Item1 & "%" & iArrInd(i).Item2 & "*")
        Next
        Return output
    End Function

    '|GETTER/SETTER METHODS|
    Overrides Function getMaxHealth() As Integer
        Return CInt((maxHealth + hBuff + equippedArmor.hBoost + equippedAcce.hBoost) * pClass.h * pForm.h)
    End Function
    Overrides Function getMaxMana() As Integer
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Then Return CInt(maxMana * pForm.m * pForm.m) + mBuff
        Return CInt((maxMana + mBuff + equippedArmor.mBoost + equippedWeapon.mBoost + equippedAcce.mBoost) * pForm.m * pForm.m)
    End Function
    Overrides Function getATK() As Integer
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Then Return CInt(attack * pForm.a * pClass.a) + aBuff
        Return CInt((attack + aBuff + equippedArmor.aBoost + equippedAcce.aBoost) * pForm.a * pClass.a)
    End Function
    Overrides Function getDEF() As Integer
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Then Return CInt(defence * pClass.d * pForm.d) + dBuff
        Return CInt((defence + dBuff + equippedArmor.dBoost + equippedAcce.dBoost) * pClass.d * pForm.d)
    End Function
    Overrides Function getSPD() As Integer
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Then Return CInt(speed * pClass.s * pForm.s) + sBuff
        Return CInt((speed + sBuff + equippedArmor.sBoost + equippedAcce.sBoost) * pClass.s * pForm.s)
    End Function
    Overrides Function getWIL() As Integer
        Return CInt(will * pClass.w * pForm.w) + wBuff
    End Function

    '|DESCRIPTION GENERATION METHODS|
    Function getColor(ByVal color As Color)
        Dim c As Color


        Dim cArr As Color() = {color.Aqua, color.Aquamarine, color.Azure, _
                               color.Beige, color.Black, color.Blue, color.BlueViolet, color.Brown, _
                               color.Chartreuse, color.Coral, color.CornflowerBlue, color.Crimson, color.Cyan, _
                               color.DarkBlue, color.DarkCyan, color.DarkGreen, color.DarkMagenta, color.DarkRed, color.DarkSeaGreen, color.DarkSlateBlue, color.DarkTurquoise, color.DarkViolet, _
                               color.Fuchsia, _
                               color.Gold, color.Gray, color.Green, color.GreenYellow, _
                               color.Honeydew, color.HotPink, _
                               color.Indigo, _
                               color.Lavender, color.LawnGreen, color.LightBlue, color.LightGray, color.LightGreen, color.LightPink, color.LightSeaGreen, color.LightSkyBlue, color.LightSteelBlue, color.LightYellow, color.Lime, _
                               color.Magenta, color.Maroon, color.MidnightBlue, color.MintCream, color.MediumPurple, color.MediumOrchid, _
                               color.Navy, _
                               color.Orange, color.OrangeRed, color.Orchid, _
                               color.Pink, color.Purple, color.PowderBlue, color.Plum, color.PaleVioletRed, _
                               color.Red, color.RosyBrown, _
                               color.SeaGreen, color.Silver, color.Sienna, color.SteelBlue, _
                               color.Tan, color.Teal, color.Turquoise, _
                               color.Wheat, color.White, _
                               color.Yellow}
        Dim closest As Double = 99999999999999
        For i = 0 To UBound(cArr)
            Dim ratio = isShadeOf(color.R, color.G, color.B, cArr(i))
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
        If out.Equals("Beige ") Or out.Equals("Wheat ") Then out = "Platinum Blonde "
        Return out.ToLower
    End Function
    Function getHairColor() As String
        Return getColor(haircolor)
    End Function
    Function getSkinColor() As String
        Select Case skincolor.GetHashCode
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
                Return getColor(skincolor)
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
    Function genDescription()
        Dim out As String = ""
        'general statement
        out = "You are " & name & ", a " & sex & " " & pForm.name & " " & pClass.name & vbCrLf & " " & vbCrLf

        'check for single image forms
        Select Case pForm.name
            Case "Dragon"
                out += "You are a large, green dragon.  Yay for you." & vbCrLf & vbCrLf
                Return out + outPutPerkText()
            Case "Blob"
            Case "Chicken"
            Case "Frog"
                out += "You are a lime green tiny frog.  Ribbit, ribbit." & vbCrLf & vbCrLf
                Return out + outPutPerkText()
            Case "Sheep"
                out += "You are a fluffy, white sheep.  Bahh." & vbCrLf & vbCrLf
                Return out + outPutPerkText()
            Case "Cake"
                out += "Your body is made of a rich, pink cake.  Despite this, be it through magic or sheer force of will, " &
                    "you can keep yourself together enough to move and even fight.  That said, your form isn't exactly durable " &
                    "and while you may be able to take a few hits, anything else might just end up leaving you splattered on the floor " &
                    "of the dungeon." & vbCrLf & vbCrLf &
                    "You look female, with massive breasts topped with dollops of whipped cream topping them.  Your ""hair"" is also made " &
                    "of a similar frosting, done in a feminine style." & vbCrLf & vbCrLf
                Return out + outPutPerkText()
        End Select
        Select Case pClass.name
            Case "Magic Girl​"
                out += "You are currently in the middle of a magical girl transformation!" & vbCrLf & vbCrLf
                Return out + outPutPerkText()
            Case "Princess​"
                out += "Whatever you were before, you are now a princess in a yellow ballgown." & vbCrLf & vbCrLf
                Return out + outPutPerkText()
            Case "Bunny Girl​"
                out += "Whatever you were before, you are now a small, blonde adult woman in a red bunny suit.  The suit, clinging to your suple body includes not just a crimzon leotard, but also a pair of fishnet stockings that highlight your toned legs, and end in a pair of platform heels.  Topping off your ensamble is a black headband with two bunny ears." & vbCrLf & vbCrLf
                Return out + outPutPerkText()
        End Select

        'hair
        out += "You have " & getHairColor()
        If haircolor.A = 180 Then
            out += "gelatinous "
        End If
        If pForm.name.Equals("Blowup Doll") Then
            out += "rubber "
        End If
        If iArrInd(1).Item2 Then
            out += "hair, done in a feminine style." & vbCrLf & " " & vbCrLf
        Else
            out += "hair, done in a masculine style." & vbCrLf & " " & vbCrLf
        End If

        'body
        Select Case pForm.name
            Case "Blowup Doll"
                out += "You are a inflatable sex doll with " & getSkinColor() & "rubber skin.  "
                If sexBool Then
                    out += "You have a feminine body, with huge breasts and the matching female genetalia." & vbCrLf & " " & vbCrLf
                Else
                    out += "You have a feminine body, with huge breasts, though you have male genetalia." & vbCrLf & " " & vbCrLf
                End If
            Case Else
                'skincolor
                If haircolor.A = 200 Then
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
                If sexBool Then
                    If iArrInd(2).Item2 Then
                        out += "You have a feminine body, with " & bAdj & " breasts and the matching female genetalia." & vbCrLf & " " & vbCrLf
                    Else
                        out += "You have a a masculine body, with " & bAdj & " breasts, though you have female genetalia." & vbCrLf & " " & vbCrLf
                    End If
                    out += "Your hips have womanly curves without being overly wide.  Overall, you have typical legs and feet for a humanoid woman." & vbCrLf & " " & vbCrLf
                Else
                    If iArrInd(2).Item2 Then
                        out += "You have a feminine body, with " & bAdj & " breasts, though you have male genetalia." & vbCrLf & " " & vbCrLf
                    Else
                        out += "You have a masculine body, with a toned chest and the matching male genetalia." & vbCrLf & " " & vbCrLf
                    End If
                End If
        End Select

        out += outPutPerkText()

        Return out
    End Function
    Function outPutPerkText() As String
        Dim out = ""
        If perks("hunger") > -1 Then out += "You haven't eaten anything in a while and are starving." & vbCrLf & " " & vbCrLf
        If perks("slutcurse") > -1 Then out += "You choose to dress very provocatively, showing as much skin as possible due to a curse."
        If perks("polymorphed") > -1 Then out += "You are under the effects of a temporary polymorph, and will be for " & perks("polymorphed") & " more turns." & vbCrLf & " " & vbCrLf
        If perks("thrall") > -1 Then out += "You are under the thrall of a sorcerer/ess, and may not have full control over your body or mind." & vbCrLf & " " & vbCrLf
        If perks("astatue") > -1 Then out += "You are currently a statue, and won't be able to do much for " & perks("astatue") & " turns." & vbCrLf & " " & vbCrLf
        Return out
    End Function
    '|UNIMPLEMENTED|
    Public Sub levelUp()
        '    level += 1
        '    xp -= nextLevelXp
        '    nextLevelXp = nextLevelXp * 1.66
        '    Form1.pushLstLog("Level up!  " & name & " is now level " & level)
        '    If xp > nextLevelXp Then levelUp()
        '    health += 3
        '    maxHealth += 3
        '    attack += 1
        '    defence += 1
        '    If level Mod 2 = 0 Then
        '        mana += 5
        '        maxMana += 5
        '    End If
        '    Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        '    description = CStr(name & " is a " & sex & ", level " & level & " " & title)
    End Sub
End Class
