Public Class Player
    'Player is the representation of a player controlled entity (the main player, any teammates)
    'METHODS AND VARIABLES RELATED TO LEVELING HAVE BEEN COMMENTED OUT.
    Implements Updatable

    'Player Instance variables
    Public name, sex, title, description As String
    'Public level, xp, nextLevelXp As Integer
    Public health, maxHealth, mana, maxMana, attack, defence, discipline, speed, evade, gold, lust As Integer
    Public hBuff As Integer = 0     'buffs that apply across forms (from charms, etc)
    Public mBuff As Integer = 0
    Public aBuff As Integer = 0
    Public dBuff As Integer = 0
    Public wBuff As Integer = 0
    Public sBuff As Integer = 0
    Public breastSize As Integer = -1
    Public hunger As Integer
    Public equippedWeapon As Weapon
    Public equippedArmor As Armor
    Public currTarget As Monster
    Public pos As Point
    Public canMoveFlag As Boolean = True
    Public perks As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)() 'perks also include triggers for events
    Public pImage As Image 'tile image of the player
    Public TextColor As Color
    Public isDead As Boolean = False
    'portrait variables
    Public sexBool As Boolean
    Public iArr As Image()
    Public iArrInd(16) As Tuple(Of Integer, Boolean)
    Public haircolor As Color = Color.FromArgb(255, 204, 203, 213)
    Public skincolor As Color = Color.FromArgb(255, 247, 219, 195)
    'inventory variables
    Public inventory As New ArrayList()
    Public inventorynames As New ArrayList()
    Dim armor() As Armor
    Dim weapons() As Weapon
    Public useable(), food(), potions(), misc() As Item
    Public invNeedsUDate As Boolean = False
    'player & form states
    Public currState, pState, sState As State
    Public succState As State = New State()
    Public slimState As State = New State()
    Public goddState As State = New State()
    Public dragState As State = New State()
    Public bimbState As State = New State()
    Public magGState As State = New State()
    Public maidState As State = New State()
    Public prinState As State = New State()

    Public solFlag = False
    Public wingInd = 0
    Public isAttacking = False

    'New takes no parameters and sets all of the inst. variables to temp variables.
    'Variables will be set at the start of a game
    Sub New()
        name = "TEMP_NAME"
        sex = "TEMP_SEX"
        title = "TEMP_TITLE"
        health = 100
        maxHealth = health
        attack = 10
        defence = 10
        discipline = 10
        speed = 10
        evade = 10
        gold = 200
        lust = 0
        'level = 1
        'xp = 0
        'nextLevelXp = 100
        mana = 0
        hunger = 0

        createInvPerks()
        inventory.Item(0).add(1)
        inventory.Item(2).add(1)
    End Sub
    'This New is used in the loading of a player from file
    Sub New(ByVal s As String)
        createInvPerks()
        Dim playArray() As String = s.Split("#")

        currState = New State(Me)
        sState = New State(Me)
        pState = New State(Me)
        succState = New State()
        slimState = New State()
        goddState = New State()
        dragState = New State()
        bimbState = New State()
        magGState = New State()
        maidState = New State()
        prinState = New State()

        currState.read(playArray(0))
        sState.read(playArray(1))
        pState.read(playArray(2))
        succState.read(playArray(3))
        slimState.read(playArray(4))
        goddState.read(playArray(5))
        dragState.read(playArray(6))
        bimbState.read(playArray(7))
        magGState.read(playArray(8))
        maidState.read(playArray(9))
        prinState.read(playArray(10))
        currState.load(Me)

        playArray = playArray(11).Split("*")
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

        Dim x As Integer = CInt(playArray(11)) - 1
        For i = 0 To x
            inventory.Item(i).add(playArray(12 + i))
        Next

        solFlag = True
        ReDim iArr(16)
        createP()

        'For i = 0 To UBound(Game.HPotionNames)
        '   inventory(25 + i).setName(Game.HPotionNames(i))
        '   inventorynames(25 + i) = Game.HPotionNames(i)
        'Next

        bsizeroute()
    End Sub

    'commands
    'movement commands
    Public Sub moveUp()
        If (pos.Y - 1) < 0 Or canMoveFlag = False Then Exit Sub
        If Game.mBoard(pos.Y - 1, pos.X).Tag = 0 Then Exit Sub
        pos.Y -= 1
    End Sub
    Public Sub moveDown()
        If (pos.Y + 1) > Game.mBoardHeight - 1 Or canMoveFlag = False Then Exit Sub
        If Game.mBoard(pos.Y + 1, pos.X).Tag = 0 Then Exit Sub
        pos.Y += 1
    End Sub
    Public Sub moveLeft()
        If (pos.X - 1) < 0 Or canMoveFlag = False Then Exit Sub
        If Game.mBoard(pos.Y, pos.X - 1).Tag = 0 Then Exit Sub
        pos.X -= 1
    End Sub
    Public Sub moveRight()
        If (pos.X + 1) > Game.mBoardWidth - 1 Or canMoveFlag = False Then Exit Sub
        If Game.mBoard(pos.Y, pos.X + 1).Tag = 0 Then Exit Sub
        pos.X += 1
    End Sub
    'combat commands
    Public Sub setTarg(ByVal m As Monster)
        currTarget = m
    End Sub
    Public Sub attackCMD(ByVal target As Monster)
        isAttacking = False
        Randomize()
        Dim dmg As Integer = equippedWeapon.attack(Me, target)
        If dmg = -1 Then
            Game.lstLog.Items.Add(CStr("You miss" & target.title & " " & target.getName() & "!"))
            Game.pushLblCombatEvent(CStr("You miss" & target.title & " " & target.getName() & "!"))
            Exit Sub
        ElseIf dmg = -2 Then
            dmg += (12 + (getAttack()) + (equippedWeapon.aBoost)) * 2
            Game.lstLog.Items.Add(CStr("You hit" & target.title & " " & target.getName() & " for " & dmg & " damage!" & ".  Critical hit!"))
            Game.pushLblCombatEvent("You hit" & target.title & " " & target.getName() & " for " & dmg & " damage!" & ".  Critical hit!")
            target.takeDMG(dmg)
            target.isStunned = True
            target.stunct = 0
            Exit Sub
        ElseIf dmg < 1 Then
            dmg = 1
        End If
        Game.lstLog.Items.Add(CStr("You hit" & target.title & " " & target.getName() & " for " & dmg & " damage!"))
        target.takeDMG(dmg)
        Game.pushLblCombatEvent(CStr("You hit" & target.title & " " & target.getName() & " for " & dmg & " damage!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Public Sub takeDMG(ByVal dmg As Integer)
        'If Form1.combatmode = False Then Exit Sub
        Dim actualDMG As Integer = dmg - ((getDefence() / 100) * dmg)
        If actualDMG < 1 Then actualDMG = 1
        health -= actualDMG
        Game.lblPHealtDiff.Tag -= actualDMG
        Game.lstLog.Items.Add(CStr("You got hit! -" & actualDMG & " health!"))
        Game.pushLblCombatEvent(CStr("You got hit! -" & actualDMG & " health!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub

    'genral functions
    'Die handles a player death
    Public Sub Die()
        If Game.pnlSaveLoad.Visible = True Then Exit Sub
        Try
            If currTarget.name.Equals("Shopkeeper") Then
                Dim n As NPC = Game.currNPC
                petrify(Color.Goldenrod)
                Dim out As String = "'You should have known better than to try and rob a shop keeper,' the shopkeep says," & vbCrLf &
                    " glaring down at you, '...and if its gold you're after, I guess I've got some good news for you.'" & vbCrLf &
                    "  With that, " & n.pronoun & " reaches into " & n.pPronoun & " bag and puts on a gaudy gauntlet " & vbCrLf &
                    "that begins glowing with a golden light. You lack the strength to fight back as " & n.pronoun & " places" & vbCrLf &
                    " his thumb on your forhead, and suddenly everything just seems so heavy. 'Noooo...' you moan, " & vbCrLf &
                    "as the area around where he touched turns to gold, and that gold turns your flesh and blood " & vbCrLf &
                    "around it to gold as well. In a matter of seconds, all that is left of " & Me.name & " the " & vbCrLf &
                    Me.title & " is a solid gold statue. The shopkeeper sighs, muttering to no one in particular, " & vbCrLf &
                    vbCrLf & vbCrLf & "'Now how am I going to get you back to the refinery?'"
                'Game.pushLblEvent(out)
                title = "Trophy"
                MsgBox(out)
            ElseIf currTarget.name.Equals("Mindless Bimbo") Then
                Game.player.perks("bimbotf") = 1
                Dim out As String = "Exausted, you slump to the floor.  Glancing up, the horny mess attacking you seem to have gotten a running start, throwing herself on top of you, and pulling you into a sloppy kiss.  As she clumsily fumbles around, trying to remove your clothes, you roll out from underneath her and beat a hasty retreat, the faint sweetness of bubblegum lingering in your mouth."
                currTarget.despawn("run")
                Game.pushLblEvent(out)
                health = 10
                Exit Sub
            ElseIf currTarget.name.Equals("Enslaved Thrall") Then
                Dim out As String = "Despite your fatigue, you are able to roll out of the way of the thrall's attempt to restrain you, and make a clumsy escape." & vbCrLf & " " & vbCrLf & "[Insert a TF here (eventually)]"
                currTarget.despawn("run")
                Game.pushLblEvent(out)
                health = 10
                Exit Sub
            ElseIf currTarget.name.Equals("Slime") Or currTarget.name.Equals("Goo Girl") Then
                Dim out As String = "As the " & currTarget.name & " closes in on you, you push yourself off the ground, sidestep it, and make a hasty retreat." & vbCrLf & " " & vbCrLf & "[Insert a TF here (eventually)]"
                currTarget.despawn("run")
                Game.pushLblEvent(out)
                health = 10
                Exit Sub
            ElseIf currTarget.name.Equals("Spider") Or currTarget.name.Equals("Arachne Huntress") Or currTarget.name.Equals("Enthralling Sorcerer") Or currTarget.name.Equals("Enthralling Sorceress") Then
                Dim out As String = "As the " & currTarget.name & " closes in on you, you push yourself off the ground, sidestep it, and make a hasty retreat." & vbCrLf & " " & vbCrLf & "[Insert a TF here (eventually)]"
                currTarget.despawn("run")
                Game.pushLblEvent(out)
                health = 10
                Exit Sub
            ElseIf currTarget.name.Equals("Mimic") Then
                currTarget.despawn("run")
                Dim out As String = "As you collapse, out of the corner of your eye you can see thick tendrils flowing out of the chest that could only be the body of the mimic.  Some of the tendrils wrap around your wrist and ankles, while others work their way up your thighs, aggressively groping your thighs."
                If equippedArmor.getName.Equals("Naked") Then
                    out += "  As you black out, you can feel the tendrils writhing around you crotch.  As the darkness takes you, so does the orgasmic bliss of the mimic's magic touch."
                    lust += 50
                    createP()
                    Game.pushLblEvent(out)
                    health = 10
                    Exit Sub
                End If
                out += "  As you black out, you can see the mimic working its way into your armor.  As the darkness takes you, so does the orgasmic bliss of the mimic's magic touch."
                Dim x As Integer = -1
                Dim n As String = equippedArmor.getName()
                For i = 0 To inventorynames.Count - 1
                    If inventorynames(i).Equals(n) Then
                        x = i
                        Exit For
                    End If
                Next
                If x <> -1 Then inventory(x).count -= 1
                equippedArmor = New LiveArmor
                inventory(55).add(1)
                perks(12) = True
                Equipment.portraitUDate()
                Game.pushLblEvent(out)
                health = 10
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("D_D Error 002: Unknown Cause of death")
        End Try
        isDead = True
        Dim r As Integer = CInt(Int(Rnd() * 2))
        If r = 0 Then
            If Not Game.currNPC Is Nothing AndAlso Game.currNPC.name.Equals("Shopkeeper") Then title = "Golem (Gold)"
            Dim writer As IO.StreamWriter
            writer = IO.File.CreateText("gho.sts")
            writer.WriteLine(Me.toGhost())
            writer.Flush()
            writer.Close()
        End If
        If MessageBox.Show("Game Over!  Reload the a save?", "Game Over . . .", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                Game.combatmode = False
                Game.solFlag = True
                Game.toSOL()
                Exit Sub
            Catch ex As Exception
                MsgBox("No save detected!")
            End Try
        End If
        Game.formReset()
    End Sub
    'setClass sets the player stats at the beginning of the game
    Public Sub setClass(ByVal s As String)
        equippedArmor = New NormalClothes
        equippedWeapon = New BareFists
        If s = "Warrior" Then
            health += 50
            maxHealth += 50
            attack += 10
            defence += 10
            inventory.Item(5).addOne()
            inventory.Item(6).addOne()
            equippedArmor = inventory.Item(5)
            equippedWeapon = inventory.Item(6)
        ElseIf s = "Mage" Then
            mana += 30
            maxMana += 15
            Game.cboxMG.Items.Add("Fireball")
            inventory.Item(2).add(3)
            inventory.Item(4).add(1)
            inventory.Item(21).add(1)
            equippedWeapon = inventory.Item(21)
        ElseIf s = "dev" Then
            health += 250
            maxHealth += 250
            mana += 999
            maxMana += 999
            For i = 0 To inventory.Count - 1
                inventory.Item(i).add(33)
            Next
        End If
        title = s
        Equipment.clothesChange(equippedArmor.getName)
        If equippedWeapon.GetType().IsSubclassOf(GetType(Staff)) Then
            mana += equippedWeapon.aBoost
            maxMana += equippedWeapon.aBoost
        End If
        If sex = "Female" Then sexBool = True
        If sex = "Male" Then sexBool = False
        pImage = Game.picPlayer.BackgroundImage
        TextColor = Color.White
        description = CStr(name & " is a " & sex & " " & title)

        currState = New State(Me)
        sState = New State(Me)
    End Sub
    'Public Sub levelUp()
    '    level += 1
    '    xp -= nextLevelXp
    '    nextLevelXp = nextLevelXp * 1.66
    '    Form1.lstLog.Items.Add("Level up!  " & name & " is now level " & level)
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
    'End Sub


    'the functions relating to the reversion to a state
    Public Sub revert()
        Dim tHth As Integer = health + hBuff
        Dim tMna As Integer = mana + mBuff
        Dim tHun As Integer = hunger
        Dim tGold As Integer = gold
        Dim tEweap As Weapon = equippedWeapon
        Dim tEarm As Armor = equippedArmor
        Dim hRatio As Double = health / getmaxHealth()
        If tEweap.getName = "Magic_Girl_Wand" Then tEweap = New BareFists()
        If tEarm.getName = "Magic_Girl_Outfit" Then tEarm = New Naked()

        sState.load(Me)

        health = getmaxHealth() * hRatio
        mana = tMna
        gold = tGold
        equippedArmor = tEarm
        equippedWeapon = tEweap
        perks("slutcurse") = -1
        currState.save(Me)
        pState.save(Me)



        If Game.cboxMG.Items.Contains("Heartblast Starcannon") Then
            Game.cboxMG.Items.Remove("Heartblast Starcannon")
            Game.lstLog.Items.Add("'Heartblast Starcannon' spell forgotten!")
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        End If

        If health > maxHealth + hBuff Then health = (maxHealth + hBuff) * hRatio
        If mana > maxMana + mBuff Then mana = maxMana + mBuff

        Game.pushLblEvent("With a poof of smoke, you return to your original self!")
        Game.pImage = pImage
        Game.lblEvent.ForeColor = TextColor
        Game.lblNameTitle.ForeColor = TextColor

        changeHairColor(haircolor)
        Equipment.portraitUDate()
        UIupdate()
    End Sub
    Public Sub revert2()
        Dim tHth As Integer = health + hBuff
        Dim tMna As Integer = mana + mBuff
        Dim tHun As Integer = hunger
        Dim tGold As Integer = gold
        Dim tEweap As Weapon = equippedWeapon
        Dim tEarm As Armor = equippedArmor
        Dim hRatio As Double = health / getmaxHealth()
        If tEweap.getName = "Magic_Girl_Wand" Then tEweap = New BareFists()
        If tEarm.getName = "Goddess_Gown" Or tEarm.getName = "Succubus_Garb" Then tEarm = New NormalClothes
        pState.load(Me)

        health = getmaxHealth() * hRatio
        mana = tMna
        gold = tGold
        If Not tEarm.getName.Equals("Magic_Girl_Outfit") Then equippedArmor = tEarm
        equippedWeapon = tEweap
        currState.save(Me)
        pState.save(Me)

        If Game.cboxMG.Items.Contains("Heartblast Starcannon") Then
            Game.cboxMG.Items.Remove("Heartblast Starcannon")
            Game.lstLog.Items.Add("'Heartblast Starcannon' spell forgotten!")
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        End If

        If health > maxHealth + hBuff Then health = (maxHealth + hBuff) * hRatio
        If mana > maxMana + mBuff Then mana = maxMana + mBuff
        Game.pushLblEvent("You return to your former form!")
        Game.pImage = pImage
        Game.lblEvent.ForeColor = TextColor
        Game.lblNameTitle.ForeColor = TextColor

        changeHairColor(haircolor)
        Equipment.portraitUDate()
        UIupdate()
    End Sub
    Public Sub genRandomPortrait(ByVal sb As Boolean)
        Randomize()

        haircolor = Color.FromArgb(255, Int(Rnd() * 125) + 100, Int(Rnd() * 125) + 100, Int(Rnd() * 125) + 100)
        Dim r1 As Integer = Int(Rnd() * 6)
        Select Case r1
            Case 0
                skincolor = (Color.AntiqueWhite)
            Case 1
                skincolor = (Color.FromArgb(255, 247, 219, 195))
            Case 2
                skincolor = (Color.FromArgb(255, 240, 184, 160))
            Case 3
                skincolor = (Color.FromArgb(255, 210, 161, 140))
            Case 4
                skincolor = (Color.FromArgb(255, 180, 138, 120))
            Case Else
                skincolor = (Color.FromArgb(255, 105, 80, 70))
        End Select

        Dim r As Integer = Int(Rnd() * 5)
        iArrInd(1) = New Tuple(Of Integer, Boolean)(r, True)
        iArrInd(2) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(4) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(5) = New Tuple(Of Integer, Boolean)(r, True)
        r = Int(Rnd() * 5)
        iArrInd(3) = New Tuple(Of Integer, Boolean)(r, True)
        r = Int(Rnd() * 4)
        iArrInd(6) = New Tuple(Of Integer, Boolean)(r, True)
        iArrInd(7) = New Tuple(Of Integer, Boolean)(0, True)
        r = Int(Rnd() * 3)
        If r = 1 Then r = 4
        iArrInd(8) = New Tuple(Of Integer, Boolean)(r, True)
        r = Int(Rnd() * 3)
        iArrInd(9) = New Tuple(Of Integer, Boolean)(r, True)
        iArrInd(10) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(11) = New Tuple(Of Integer, Boolean)(0, True)
        If Rnd() > 0.65 Then
            iArrInd(12) = New Tuple(Of Integer, Boolean)(4, True)
        End If
        iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(14) = New Tuple(Of Integer, Boolean)(0, True)
        r = Int(Rnd() * 4) + 1
        iArrInd(15) = New Tuple(Of Integer, Boolean)(r, True)
        iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)

        TextColor = Color.White
        If Game.floor < 6 Then pImage = Game.picPlayer.BackgroundImage Else pImage = Game.picPlayerf.BackgroundImage

        Equipment.portraitUDate()
    End Sub

    'updatable functions
    Sub update() Implements Updatable.update
        If Not (currTarget Is Nothing) And isAttacking Then attackCMD(currTarget)
        bsizeroute()
        If hunger >= 100 Then
            perks("hunger") = 0
        ElseIf hunger > 100 Then
            hunger = 100
        ElseIf Game.turn Mod 35 = 0 Then
            hunger += 1
        End If
        If inventory(8).count > 0 Then
            inventory(8).count = 0
            Game.pushLblEvent("The chicken suit phases out of reality")
        End If
    End Sub
    Sub createInvPerks()
        'create inventory
        inventory.Add(New Compass())    '0
        inventory.Add(New StickOfGum()) '1
        inventory.Add(New HealthPotion())   '2
        inventory.Add(New VialOfSlime())    '3
        inventory.Add(New Spellbook())  '4
        inventory.Add(New SteelArmor()) '5
        inventory.Add(New SteelSword()) '6
        inventory.Add(New SteelBikini())    '7
        inventory.Add(New ChickenSuit())    '8
        inventory.Add(New SoulBlade())  '9
        inventory.Add(New MagGirlOutfit())  '10
        inventory.Add(New MagGirlWand())    '11
        inventory.Add(New CatLingerie())    '12
        inventory.Add(New ManaPotion())    '13
        inventory.Add(New RestorationPotion())    '14
        inventory.Add(New CatEars())    '15
        inventory.Add(New BunnySuit())    '16
        inventory.Add(New SorcerersRobes())    '17
        inventory.Add(New WitchCosplay())    '18
        inventory.Add(New WarriorsCuirass())    '19
        inventory.Add(New BrawlerCosplay())    '20
        inventory.Add(New OakStaff())    '21
        inventory.Add(New WizardStaff())    '22
        inventory.Add(New BronzeXiphos())    '23
        inventory.Add(New TargaxSword())    '24

        inventory.Add(New BlondePotion())    '25
        inventory.Add(New RandomHairPotion())    '26
        inventory.Add(New RedHairPotion())    '27
        inventory.Add(New FemininePotion())    '28
        inventory.Add(New BEPotion())    '29

        inventory.Add(New ChickenLeg()) '30
        inventory.Add(New Apple()) '31
        inventory.Add(New PApple()) '32
        inventory.Add(New Herbs()) '33
        inventory.Add(New HeavyCream()) '34
        inventory.Add(New Cupcake()) '35
        inventory.Add(New Mirror()) '36
        inventory.Add(New Glowstick()) '37
        inventory.Add(New GoldArmor()) '38
        inventory.Add(New GoldAdornment()) '39
        inventory.Add(New GoldSword()) '40
        inventory.Add(New GoldenStaff()) '41
        inventory.Add(New MidasGuantlet()) '42
        inventory.Add(New Gold()) '43
        inventory.Add(New AngelFood()) '44
        inventory.Add(New MaidDuster()) '45
        inventory.Add(New TankTop()) '46
        inventory.Add(New SportBra()) '47
        inventory.Add(New HealthCharm()) '48
        inventory.Add(New ManaCharm()) '49
        inventory.Add(New AttackCharm()) '50
        inventory.Add(New DefenceCharm()) '51
        inventory.Add(New SpeedCharm()) '52
        inventory.Add(New Key()) '53
        inventory.Add(New Ropes()) '54
        inventory.Add(New LiveArmor()) '55
        inventory.Add(New LiveLingerie()) '56
        inventory.Add(New RigWrench()) '57
        inventory.Add(New FusionCrystal()) '58
        inventory.Add(New MasculinePotion()) '59
        inventory.Add(New BSPotion()) '60
        inventory.Add(New HyperHealPotion()) '61
        inventory.Add(New HyperManaPotion()) '62
        inventory.Add(New SpidersilkWhip()) '63

        For i = 0 To inventory.Count - 1
            If inventory(i).GetType().IsSubclassOf(GetType(MysteryPotion)) Then
                inventorynames.Insert(i, CType(inventory(i), MysteryPotion).getRealName())
            Else
                inventorynames.Insert(i, inventory(i).getName())
            End If
            'MsgBox(inventory(i).getName())
        Next
        armor = {New NormalClothes, New SkimpyClothes, New Naked, New PrincessGown,
                 New MaidOutfit, New GoddessGown, New SuccubusGarb,
                 inventory(5), inventory(7), inventory(8), inventory(10),
                 inventory(12), inventory(16), inventory(17), inventory(18),
                 inventory(19), inventory(20), inventory(38), inventory(39),
                 inventory(46), inventory(47), inventory(54), inventory(55),
                 inventory(56)}

        weapons = {New BareFists(),
                   inventory(6), inventory(9), inventory(11), inventory(21),
                   inventory(22), inventory(23), inventory(24), inventory(40),
                   inventory(41), inventory(42), inventory(45), inventory(63)}

        useable = {inventory(0), inventory(1), inventory(3), inventory(4),
                   inventory(15), inventory(36), inventory(37), inventory(45),
                   inventory(48), inventory(49), inventory(50), inventory(51),
                   inventory(52), inventory(57), inventory(58)}

        food = {inventory(30), inventory(31), inventory(32), inventory(33),
                inventory(34), inventory(35), inventory(44)}

        potions = {inventory(2), inventory(13), inventory(14), inventory(25),
                   inventory(26), inventory(27), inventory(28), inventory(29),
                   inventory(59), inventory(60), inventory(61), inventory(62)}

        misc = {inventory(43), inventory(53)}

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
    End Sub
    Sub perkUpdate()
        'hunger
        If perks("hunger") > -1 And Game.turn Mod 5 = 0 Then
            If hunger < 100 Then
                perks("hunger") = -1
            Else
                health -= 5
                Game.lstLog.Items.Add("Your stomach aches... -5 health!")
            End If
        End If
        'bimbo tf
        If perks("bimbotf") > -1 Then
            perks("chickentf") = -1
            If perks("polymorphed") > -1 Then perks("bimbotf") = -1
            If Not title.Equals("Bimbo") Then
                If perks("bimbotf") < 19 And perks("bimbotf") Mod 10 = 0 Then
                    haircolor = Game.cShift(haircolor, Polymorph.bimboyellow, 25)
                    createP()
                End If
                Select Case perks("bimbotf")
                    Case 0
                        If Not title.Equals("Magic Girl") And Not perks("polymorphed") > -1 Then
                            pState.save(Me)
                        ElseIf title.Equals("Magic Girl") Then
                            Polymorph.transform(Me, "bimbo", 2)
                        End If
                        lust += 10
                        'tfstage1
                        iArrInd(11) = New Tuple(Of Integer, Boolean)(0, sexBool)
                    Case 9
                        lust += 10
                        'tfStage2
                        If Not iArrInd(2).Item2 Or Not iArrInd(1).Item2 Or Not sexBool Or Not iArrInd(4).Item2 Then
                            MtF()
                        End If
                    Case 19
                        'tfStage3
                        Polymorph.transform(Me, "bimbo", 0)
                    Case 25
                        Polymorph.transform(Me, "bimbo", 1)
                        perks("bimbotf") -= 1
                End Select
                perks("bimbotf") += 1
                Dim outputln1 As String = "Chewing the gum causes a dizzy calm wash to over you."
                If perks("bimbotf") = 1 And Not title.Equals("Magic Girl") Then Game.pushLblEvent(outputln1)
            Else
                Dim outputln1 As String = "Chewing the gum make your head feel warm and fuzzy and stuff. You like, totally, love this gum!"
                Game.pushLblEvent(outputln1)
                Game.lblNameTitle.ForeColor = Color.HotPink
                perks("bimbotf") = -1
            End If
        End If
        'clothing curse
        If perks("slutcurse") > -1 Then
            Equipment.clothingCurse1()
        End If
        'removed chicken tf
        'If perks("chickentf") > -1 Then
        '    If perks("chickentf") < 0 Then
        '        perks("chickentf") = -1
        '    Else
        '        perks("chickentf") += 1
        '        If perks("chickentf") <= 1 Then
        '            Polymorph.transform(Me, "Chicken")
        '        ElseIf perks("chickentf") < 10 Then
        '        Else
        '            revert2()
        '            perks("chickentf") = -1
        '        End If
        '    End If
        'ElseIf perks("chickentf") > 0 Then
        '    perks("chickentf") += 1
        'End If
        'slime hair tf
        If perks("slimehair") > -1 Then
            If Not haircolor.A = 180 Then
                perks("slimehair") = -1
            Else
                If health < maxHealth + hBuff And Game.turn Mod 2 = 0 Then
                    health += 25
                    Game.lstLog.Items.Add("Your gel body heals some of the damage done to it. +5 health")
                    If health > getmaxHealth() Then health = getmaxHealth()
                End If
            End If
        End If
        'triggers timed polymorphs
        If perks("polymorphed") > -1 Then
            If perks("polymorphed") > 0 Then
                perks("polymorphed") -= 1
            Else
                perks("polymorphed") = -1
                revert2()
            End If
        End If
        'marissa's tf
        If perks("nekocurse") > -1 Then
            If currTarget Is Nothing Or currTarget.dead Then
                perks("nekocurse") = -1
            End If
            If Not perks("polymorphed") > -1 Then
                If perks("nekocurse") < (discipline * 1.2) Then
                    Select Case perks("nekocurse")
                        Case Int((discipline * 1.2) * 0.1)
                            Polymorph.transform(Me, "neko", 0)
                        Case Int((discipline * 1.2) * 0.3)
                            Polymorph.transform(Me, "neko", 1)
                        Case Int((discipline * 1.2) * 0.5)
                            If Not title.Equals("Magic Girl") Then
                                Polymorph.transform(Me, "neko", 2)
                            Else
                                haircolor = Color.FromArgb(255, 20, 20, 20)
                                Game.pushLblEvent("Your hair becomes a shiny black!")
                                lust += 5
                            End If
                        Case Int((discipline * 1.2) * 0.7)
                            Polymorph.transform(Me, "neko", 3)
                        Case Int((discipline * 1.2) * 0.9)
                            Polymorph.transform(Me, "neko", 4)
                        Case Int((discipline * 1.2) * 1.1)
                            If title.Equals("Magic Girl") Then
                                Polymorph.transform(Me, "neko", 6)
                            Else
                                Polymorph.transform(Me, "neko", 5)
                            End If
                            inventory.Item(12).addOne()
                            lust += 5
                            Equipment.clothesChange("Cat_Lingerie")
                        Case Int((discipline * 1.2))
                            Polymorph.transform(Me, "neko", 7)
                    End Select
                    perks("nekocurse") += 1
                Else
                    Polymorph.transform(Me, "neko", 7)
                End If
            End If
        End If
        'targax sword tf
        If perks("swordpossess") > -1 Then
            If name <> "Targax" Then
                If Not equippedWeapon.getName.Equals("Sword_of_the_Brutal") Then
                    perks("swordpossess") = -1
                End If
            Else
                perks("swordpossess") = -1
            End If
        End If
        'vial of slime hair bonus
        If perks("vsslimehair") > -1 Then
            If Not haircolor.A = 180 Then
                perks("vsslimehair") = -1
            Else
                If health < maxHealth + hBuff And Game.turn Mod 4 = 0 Then
                    Dim h As Integer = Int(Rnd() * 15) + 1
                    health += h
                    Game.lstLog.Items.Add("The gel portion of your body is able to heal some of your wounds! +" & h & " health")
                    If health > getmaxHealth() Then health = getmaxHealth()
                End If
            End If
        End If
        'berserker rage special
        If perks("brage") > -1 Then
            If perks("brage") > 0 Then
                aBuff = aBuff + (attack / 2)
                dBuff = dBuff - (defence / 3)
                perks("brage") -= 1
            Else
                aBuff = aBuff - attack * 1.5
                dBuff = dBuff + (defence) + 1
                perks("brage") = -1
                Game.lstLog.Items.Add("Berserker rage has worn off.")
                Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
            End If
        End If
        'massive mammaries special
        If perks("mmammaries") > -1 Then
            If perks("mmammaries") = 1 Then
                dBuff = dBuff + (defence * 0.8)
                perks("mmammaries") -= 1
            Else
                dBuff = dBuff - (defence * 0.8)
                perks("mmammaries") = -1
                Game.lstLog.Items.Add("Massive mammaries has worn off.")
                Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
            End If
        End If
        If perks("ihfury") > -1 Then
            If perks("ihfury") = 3 Then
                aBuff = aBuff + (attack * 0.5)
                dBuff = dBuff + (defence * 0.6)
                perks("ihfury") -= 1
            ElseIf perks("ihfury") > 0 Then
                perks("ihfury") -= 1
            Else
                aBuff = aBuff - (attack * 0.5)
                dBuff = dBuff - (defence * 0.6)
                perks("ihfury") = -1
                Game.lstLog.Items.Add("Ironhide Fury has worn off.")
                Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
            End If
        End If
        'living armor
        If perks("livearm") > -1 Then
            If equippedArmor.getName.Equals("Living_Armor") Then
                If Game.turn Mod 6 = 0 And lust < 100 Then
                    Dim l As Integer = Int(Rnd() * 15) + 10
                    lust += l
                    Game.lstLog.Items.Add("Your living armor raises your lust!")
                    createP()
                End If
            Else
                perks("livearm") = -1
            End If
        End If
        'living lingerie
        If perks("livelinge") > -1 Then
            If equippedArmor.getName.Equals("Living_Lingerie") Then
                If Game.turn Mod 4 = 0 And lust < 100 Then
                    Dim l As Integer = Int(Rnd() * 15) + 10
                    lust += l
                    Game.lstLog.Items.Add("Your living lingerie raises your lust!")
                    createP()
                End If
            Else
                perks("livelinge") = -1
            End If
        End If
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        description = CStr(name & " is a " & sex & " " & title)
    End Sub
    Sub UIupdate()
        perkUpdate()
        If health <= 0 Then
            Die()
            Exit Sub
        End If
        If inventory(8).count > 0 Then
            inventory(8).count = 0
            Game.pushLblEvent("The chicken suit phases out of reality")
        End If
        If Game.lblNameTitle.Text <> name & " the " & title Then Game.lblNameTitle.Text = name & " the " & title
        If Game.lblHealth.Text <> "Health = " & health & "/" & getmaxHealth() Then Game.lblHealth.Text = "Health = " & health & "/" & getmaxHealth()
        If Game.lblMana.Text <> "Mana = " & mana & "/" & getmaxMana() Then Game.lblMana.Text = "Mana = " & mana & "/" & getmaxMana()
        If Game.lblHunger.Text <> "Hunger = " & hunger & "/100" Then Game.lblHunger.Text = "Hunger = " & hunger & "/100"
        If Game.lblATK.Text <> "ATK = " & (getAttack()) + equippedWeapon.aBoost Then Game.lblATK.Text = "ATK = " & (getAttack()) + equippedWeapon.aBoost
        If Game.lblDEF.Text <> "DEF = " & getDefence() Then Game.lblDEF.Text = "DEF = " & getDefence()
        If Game.lblSKL.Text <> "WIL = " & getWillpower() Then Game.lblSKL.Text = "WIL = " & getWillpower()
        If Game.lblSPD.Text <> "SPD = " & getSpeed() Then Game.lblSPD.Text = "SPD = " & getSpeed()
        If Game.lblEVD.Text <> "EVD = " & evade Then Game.lblEVD.Text = "EVD = " & evade
        If Game.lblGold.Text <> "GOLD = " & gold And gold <= 999999 Then
            Game.lblGold.Text = "GOLD = " & gold
        ElseIf Game.lblGold.Text <> "GOLD = " & gold And Game.lblGold.Text <> "GOLD = 999999+" Then
            Game.lblGold.Text = "GOLD = 999999+"
        End If

        Dim numItems As Integer = Game.lstInventory.Items.Count
        Dim tArr(inventory.Count + 5) As String
        Dim ct As Integer = 0
        If Game.invFilters(0) Then
            tArr(ct) = "-USEABLES:"
            ct += 1
            For i = 0 To UBound(useable)
                If useable(i).getCount > 0 Then
                    tArr(ct) = " " & useable(i).getName() & " x" & useable(i).count
                    ct += 1
                End If
            Next
        End If
        If Game.invFilters(1) Then
            tArr(ct) = "-POTIONS:"
            ct += 1
            For i = 0 To UBound(potions)
                If potions(i).getCount > 0 Then
                    tArr(ct) = " " & potions(i).getName() & " x" & potions(i).count
                    ct += 1
                End If
            Next
        End If
        If Game.invFilters(2) Then
            tArr(ct) = "-FOOD:"
            ct += 1
            For i = 0 To UBound(food)
                If food(i).getCount > 0 Then
                    tArr(ct) = " " & food(i).getName() & " x" & food(i).count
                    ct += 1
                End If
            Next
        End If
        If Game.invFilters(3) Then
            tArr(ct) = "-ARMOR:"
            ct += 1
            For i = 0 To UBound(armor)
                If armor(i).getCount > 0 Then
                    tArr(ct) = " " & armor(i).getName() & " x" & armor(i).count
                    ct += 1
                End If
            Next
        End If
        If Game.invFilters(4) Then
            tArr(ct) = "-WEAPONS:"
            ct += 1
            For i = 0 To UBound(weapons)
                If weapons(i).getCount > 0 Then
                    tArr(ct) = " " & weapons(i).getName() & " x" & weapons(i).count
                    ct += 1
                End If
            Next
        End If
        If Game.invFilters(5) Then
            tArr(ct) = "-MISC:"
            ct += 1
            For i = 0 To UBound(misc)
                If misc(i).getCount > 0 Then
                    tArr(ct) = " " & misc(i).getName() & " x" & misc(i).count
                    ct += 1
                End If
            Next
        End If
        If ct <> numItems Or invNeedsUDate Then
            'MsgBox(ct & "," & numItems)
            Game.lstInventory.Items.Clear()
            For i = 0 To UBound(tArr)
                If Not tArr(i) Is Nothing Then Game.lstInventory.Items.Add(tArr(i))
            Next
        End If
        invNeedsUDate = False
        If Game.turn < 2 AndAlso Not CharacterGenerator.CreateBMP(iArr).Equals(Game.picPortrait.BackgroundImage) Then createP() 'Form3.portraitUDate()
    End Sub
    Public Sub createP()
        If Not Game.picPortrait.BackgroundImage Is Nothing Then Game.picPortrait.BackgroundImage.Dispose()
        For i = 0 To 16
            If iArrInd(i).Item2 Then
                iArr(i) = CharacterGenerator.fAttributes(i)(iArrInd(i).Item1)
            Else
                iArr(i) = CharacterGenerator.mAttributes(i)(iArrInd(i).Item1)
            End If
        Next
        changeHairColor(haircolor)
        changeSkinColor(skincolor)
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        If lust > 0 Then lustUpdate()
        If wingInd > 0 Then addWings(wingInd)
        currState.save(Me)
        Game.lblEvent.ForeColor = TextColor
        Game.lblNameTitle.ForeColor = TextColor
        If Not solFlag Then Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP(iArr)
    End Sub
    Public Sub MtF()
        If perks("polymorphed") > -1 Or title.Equals("Magic Girl") Then
            Game.lstLog.Items.Add("Your form prevents you from being altered.")
            Exit Sub
        End If
        If Not Game.isMark Then
            sexBool = True
            sex = "Female"
            breastSize = 1
            idRouteMF()
        Else
            sex = "Female"
            sexBool = True
            breastSize = 2
            iArrInd(1) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fRearHair2.Count - 1, True)
            iArrInd(2) = New Tuple(Of Integer, Boolean)(9, True)
            iArrInd(3) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fClothing.Count - 1, True)
            iArrInd(4) = New Tuple(Of Integer, Boolean)(0, True)
            iArrInd(5) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fRearHair1.Count - 1, True)
            iArrInd(6) = New Tuple(Of Integer, Boolean)(0, True)
            iArrInd(7) = New Tuple(Of Integer, Boolean)(0, True)
            iArrInd(8) = New Tuple(Of Integer, Boolean)(4, True)
            iArrInd(9) = New Tuple(Of Integer, Boolean)(2, True)
            iArrInd(10) = New Tuple(Of Integer, Boolean)(0, True)
            iArrInd(11) = New Tuple(Of Integer, Boolean)(0, True)
            iArrInd(12) = New Tuple(Of Integer, Boolean)(0, True)
            iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
            iArrInd(14) = New Tuple(Of Integer, Boolean)(0, True)
            iArrInd(15) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fFrontHair.Count - 1, True)
            iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)
        End If
        changeSkinColor(skincolor)
        If perks("swordpossess") > -1 Then perks("swordpossess") = 0
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Public Sub FtM()
        If perks("polymorphed") > -1 Or title.Equals("Magic Girl") Then
            Game.lstLog.Items.Add("Your form prevents you from being altered.")
            Exit Sub
        End If
        If Not Game.isMark Then
            sexBool = False
            sex = "Male"
            breastSize = -1
            perks(2) = False
            idRouteFM()
        End If
        If perks("swordpossess") > -1 Then perks("swordpossess") = 0
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Public Sub be()
        If perks("polymorphed") > -1 Or title.Equals("Magic Girl") Then
            Game.lstLog.Items.Add("Your form prevents you from being altered.")
            Exit Sub
        End If
        If breastSize = -1 Then breastSize = 0
        If breastSize >= 0 And breastSize < 6 Then
            breastSize += 1
            Select Case breastSize
                Case -1
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(0, False)
                Case 1
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(0, True)
                Case 2
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(1, True)
                Case 3
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(2, True)
                Case 4
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(3, True)
                Case 5
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(4, True)
            End Select
            Game.lstLog.Items.Add("+ 1 cup size!")
            If iArrInd(3).Item2 = False Then iArrInd(3) = New Tuple(Of Integer, Boolean)(iArrInd(3).Item1, True)
        End If
        bsizeroute()
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Friend Sub bs()
        If perks("polymorphed") > -1 Or title.Equals("Magic Girl") Then
            Game.lstLog.Items.Add("Your form prevents you from being altered.")
            Exit Sub
        End If
        'If breastSize = -1 Then breastSize = 0
        If breastSize > -1 And breastSize <= 6 Then
            breastSize -= 1
            If breastSize = 0 Then breastSize = -1
            Select Case breastSize
                Case -1
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(0, False)
                Case 1
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(0, True)
                Case 2
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(1, True)
                Case 3
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(2, True)
                Case 4
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(3, True)
                Case 5
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(4, True)
            End Select
            Game.lstLog.Items.Add("- 1 cup size!")
            If iArrInd(3).Item2 = False Then iArrInd(3) = New Tuple(Of Integer, Boolean)(iArrInd(3).Item1, True)
        End If
        bsizeroute()
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Sub bsizeroute()
        If (iArrInd(2).Item1 = 0 Or iArrInd(2).Item1 = 5) And iArrInd(2).Item2 And breastSize <> 1 Then
            breastSize = 1
        ElseIf iArrInd(2).Item1 = 1 Or iArrInd(2).Item1 = 6 And breastSize <> 2 Then
            breastSize = 2
        ElseIf (iArrInd(2).Item1 = 2 Or iArr(2).Equals(CharacterGenerator.fTFBody(10)) Or iArr(2).Equals(Game.picFMarkBody.BackgroundImage)) Or iArrInd(2).Item1 = 7 And breastSize <> 3 Then
            breastSize = 3
        ElseIf iArrInd(2).Item1 = 3 Or iArrInd(2).Item1 = 8 And breastSize <> 4 Then
            breastSize = 4
        ElseIf iArrInd(2).Item1 = 4 Or iArrInd(2).Item1 = 9 And breastSize <> 5 Then
            breastSize = 5
        ElseIf iArrInd(2).Item1 = 0 And Not iArrInd(2).Item2 And breastSize <> -1 Then
            breastSize = -1
        End If
        'createP()
    End Sub
    Sub idRouteMF()
        'rearHair2
        If Not iArrInd(1).Item2 Then
            Select Case iArrInd(1).Item1
                Case 5
                    iArrInd(1) = New Tuple(Of Integer, Boolean)(13, True)
            End Select
        End If
        'body
        If Not iArrInd(2).Item2 Then
            Select Case iArrInd(2).Item1
                Case 0
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(0, True)
            End Select
        End If
        'clothing
        Select Case iArrInd(3).Item1
            Case 5
                iArrInd(3) = New Tuple(Of Integer, Boolean)(47, True)
            Case Else
                If iArrInd(3).Item1 < 5 Then
                    iArrInd(3) = New Tuple(Of Integer, Boolean)(iArrInd(3).Item1, True)
                Else
                    Equipment.portraitUDate()
                End If
        End Select
        'face
        Select Case iArrInd(4).Item1
            Case Else
                iArrInd(4) = New Tuple(Of Integer, Boolean)(0, True)
        End Select
        'rearHair1
        If Not iArrInd(5).Item2 Then
            Select Case iArrInd(5).Item1
                Case 5
                    iArrInd(5) = New Tuple(Of Integer, Boolean)(15, True)
            End Select
        End If
        'nose
        Select Case iArrInd(7).Item1
            Case Else
                iArrInd(7) = New Tuple(Of Integer, Boolean)(0, True)
        End Select

        'ears
        Select Case iArrInd(6).Item1
            Case 5
                iArrInd(6) = New Tuple(Of Integer, Boolean)(5, True)
            Case Else
                iArrInd(6) = New Tuple(Of Integer, Boolean)(iArrInd(6).Item1, True)
        End Select
        'mouth
        Select Case iArrInd(8).Item1
            Case 5
                iArrInd(8) = New Tuple(Of Integer, Boolean)(10, True)
            Case Else
                iArrInd(8) = New Tuple(Of Integer, Boolean)(iArrInd(8).Item1, True)
        End Select
        'eyes
        Select Case iArrInd(9).Item1
            Case 7
                iArrInd(9) = New Tuple(Of Integer, Boolean)(14, True)
            Case 8
                iArrInd(9) = New Tuple(Of Integer, Boolean)(15, True)
            Case Else
                iArrInd(9) = New Tuple(Of Integer, Boolean)(iArrInd(9).Item1, True)
        End Select
        'eyebrows
        Select Case iArrInd(10).Item1
            Case Else
                iArrInd(9) = New Tuple(Of Integer, Boolean)(iArrInd(10).Item1, True)
        End Select
        'accesory
        Select Case iArrInd(14).Item1
            Case 1
                iArrInd(14) = New Tuple(Of Integer, Boolean)(2, True)
            Case 2
                iArrInd(14) = New Tuple(Of Integer, Boolean)(3, True)
        End Select
        'fronthair
        If Not iArrInd(15).Item2 Then
            Select Case iArrInd(15).Item1
                Case 6
                    iArrInd(15) = New Tuple(Of Integer, Boolean)(12, True)
            End Select
        End If
    End Sub
    Sub idRouteFM()
        'rearHair2
        Select Case iArrInd(1).Item1
            Case 13
                iArrInd(1) = New Tuple(Of Integer, Boolean)(5, False)
        End Select
        'body
        Select Case iArrInd(2).Item1
            Case Else
                iArrInd(2) = New Tuple(Of Integer, Boolean)(0, False)
        End Select
        'clothing
        Select Case iArrInd(3).Item1
            Case 47
                iArrInd(3) = New Tuple(Of Integer, Boolean)(5, False)
            Case Else
                If iArrInd(3).Item1 < 5 Then
                    iArrInd(3) = New Tuple(Of Integer, Boolean)(iArrInd(3).Item1, False)
                Else
                    Equipment.portraitUDate()
                End If
        End Select
        'face
        Select Case iArrInd(4).Item1
            Case Else
                iArrInd(4) = New Tuple(Of Integer, Boolean)(0, False)
        End Select
        'rearHair1
        Select Case iArrInd(5).Item1
            Case 15
                iArrInd(1) = New Tuple(Of Integer, Boolean)(5, False)
        End Select
        'nose
        Select Case iArrInd(7).Item1
            Case Else
                iArrInd(7) = New Tuple(Of Integer, Boolean)(0, True)
        End Select

        'ears
        Select Case iArrInd(6).Item1
            Case 5
                iArrInd(6) = New Tuple(Of Integer, Boolean)(5, False)
            Case Else
                iArrInd(6) = New Tuple(Of Integer, Boolean)(iArrInd(6).Item1, False)
        End Select
        'mouth
        Select Case iArrInd(8).Item1
            Case 10
                iArrInd(8) = New Tuple(Of Integer, Boolean)(5, False)
            Case Else
                If iArrInd(8).Item1 < 5 Then iArrInd(8) = New Tuple(Of Integer, Boolean)(iArrInd(8).Item1, False)
        End Select
        'eyes
        Select Case iArrInd(9).Item1
            Case 14
                iArrInd(9) = New Tuple(Of Integer, Boolean)(7, False)
            Case 15
                iArrInd(9) = New Tuple(Of Integer, Boolean)(8, False)
            Case Else
                If iArrInd(9).Item1 < 5 Then iArrInd(9) = New Tuple(Of Integer, Boolean)(iArrInd(9).Item1, False)
        End Select
        'eyebrows
        Select Case iArrInd(10).Item1
            Case Else
                iArrInd(9) = New Tuple(Of Integer, Boolean)(iArrInd(10).Item1, False)
        End Select
        'accesory
        Select Case iArrInd(14).Item1
            Case 2
                iArrInd(14) = New Tuple(Of Integer, Boolean)(1, False)
            Case 3
                iArrInd(14) = New Tuple(Of Integer, Boolean)(2, False)
        End Select
        'fronthair
        Select Case iArrInd(15).Item1
            Case 12
                iArrInd(15) = New Tuple(Of Integer, Boolean)(6, False)
        End Select
    End Sub
    Public Sub changeHairColor(ByVal c As Color)
        haircolor = c
        Dim t(16) As Image
        If iArrInd(1).Item2 Then
            If iArrInd(1).Item1 < 5 Then
                t(1) = CharacterGenerator.getImg("img/fRearHair2")(iArrInd(1).Item1)
            Else
                t(1) = CharacterGenerator.getImg("img/fTF/tfRearHair2")(iArrInd(1).Item1 - 5)
            End If
            If iArrInd(5).Item1 < 5 Then
                t(5) = CharacterGenerator.getImg("img/fRearHair1")(iArrInd(5).Item1)
            Else
                t(5) = CharacterGenerator.getImg("img/fTF/tfRearHair1")(iArrInd(5).Item1 - 5)
            End If
            If iArrInd(15).Item1 < 6 Then
                t(15) = CharacterGenerator.getImg("img/fFrontHair")(iArrInd(15).Item1)
            Else
                t(15) = CharacterGenerator.getImg("img/fTF/tfFrontHair")(iArrInd(15).Item1 - 6)
            End If
            CharacterGenerator.fFrontHair(0) = CharacterGenerator.picPort.Image
        Else
            If iArrInd(1).Item1 < 5 Then
                t(1) = CharacterGenerator.getImg("img/mRearHair2")(iArrInd(1).Item1)
            Else
                t(1) = CharacterGenerator.getImg("img/mTF/tfRearHair2")(iArrInd(1).Item1 - 5)
            End If
            If iArrInd(5).Item1 < 5 Then
                t(5) = CharacterGenerator.getImg("img/mRearHair1")(iArrInd(5).Item1)
            Else
                t(5) = CharacterGenerator.getImg("img/mTF/tfRearHair1")(iArrInd(5).Item1 - 5)
            End If
            If iArrInd(15).Item1 < 6 Then
                t(15) = CharacterGenerator.getImg("img/mFrontHair")(iArrInd(15).Item1)
            Else
                t(15) = CharacterGenerator.getImg("img/mTF/tfFrontHair")(iArrInd(15).Item1 - 6)
            End If
            CharacterGenerator.mFrontHair(0) = CharacterGenerator.picPort.Image
        End If
        If iArrInd(10).Item2 Then
            t(10) = CharacterGenerator.getImg("img/fEyebrows")(iArrInd(10).Item1)
        Else
            If iArrInd(10).Item1 < 3 Then t(10) = CharacterGenerator.getImg("img/mEyebrows")(iArrInd(10).Item1)
        End If
        If iArrInd(15).Item1 = 0 Then iArr(15) = CharacterGenerator.picPort.Image
        iArr(1) = CharacterGenerator.recolor(t(1), c)
        iArr(5) = CharacterGenerator.recolor(t(5), c)
        If Not iArr(15).Equals(CharacterGenerator.picPort.Image) Then iArr(15) = CharacterGenerator.recolor(t(15), c)
        If iArrInd(10).Item1 < 3 Then iArr(10) = CharacterGenerator.recolor(t(10), c)
        If Not solFlag Then Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP(iArr)
    End Sub

    Public Sub changeSkinColor(ByVal c As Color)
        skincolor = c
        Dim t(16) As Image
        If iArrInd(2).Item2 Then
            If iArrInd(2).Item1 = 0 Then
                t(2) = CharacterGenerator.getImg("img/fBody")(iArrInd(2).Item1)
                iArr(2) = CharacterGenerator.recolor2(t(2), c)
            Else
                Dim range As List(Of Image)
                Dim offset As Integer

                Dim fTFBody As List(Of Image) = CharacterGenerator.getImg("img/fTF/tfBody")
                offset = fTFBody.Count - 5
                range = fTFBody.GetRange(offset, 5)
                fTFBody = fTFBody.GetRange(0, offset)
                fTFBody.InsertRange(4, range)

                t(2) = fTFBody(iArrInd(2).Item1 - 1)
                iArr(2) = CharacterGenerator.recolor2(t(2), c)
            End If
        Else
            If iArrInd(2).Item1 = 0 Then
                t(2) = CharacterGenerator.getImg("img/mBody")(iArrInd(2).Item1)
                iArr(2) = CharacterGenerator.recolor2(t(2), c)
            Else
                t(2) = CharacterGenerator.getImg("img/mTF/tfBody")(iArrInd(2).Item1 - 1)
                iArr(2) = CharacterGenerator.recolor2(t(2), c)
            End If
        End If
        If iArrInd(4).Item2 Then
            t(4) = CharacterGenerator.getImg("img/fFace")(iArrInd(4).Item1)
            iArr(4) = CharacterGenerator.recolor2(t(4), c)
            If iArrInd(7).Item1 = 0 Then
                t(7) = CharacterGenerator.getImg("img/fNose")(iArrInd(7).Item1)
                iArr(7) = CharacterGenerator.recolor2(t(7), c)
            End If
            If iArrInd(6).Item1 = 0 Or iArrInd(6).Item1 = 3 Then
                t(6) = CharacterGenerator.getImg("img/fEars")(iArrInd(6).Item1)
                iArr(6) = CharacterGenerator.recolor2(t(6), c)
            ElseIf iArrInd(6).Item1 = 6 Then
                t(6) = CharacterGenerator.getImg("img/fTF/tfEars")(iArrInd(6).Item1 - 5)
                iArr(6) = CharacterGenerator.recolor2(t(6), c)
            End If
        Else
            t(4) = CharacterGenerator.getImg("img/mFace")(iArrInd(4).Item1)
            iArr(4) = CharacterGenerator.recolor2(t(4), c)
            If iArrInd(6).Item1 = 0 Or iArrInd(6).Item1 = 3 Then
                t(6) = CharacterGenerator.getImg("img/mEars")(iArrInd(6).Item1)
                iArr(6) = CharacterGenerator.recolor2(t(6), c)
            End If
            If iArrInd(7).Item1 = 0 Then
                t(7) = CharacterGenerator.getImg("img/mNose")(iArrInd(7).Item1)
                iArr(7) = CharacterGenerator.recolor2(t(7), c)
            End If
        End If
        If Not solFlag Then Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP(iArr)
    End Sub
    Public Sub lustUpdate()
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
        iArr(1) = CharacterGenerator.CreateBMP({CharacterGenerator.wings(i), iArr(1)})
    End Sub
    Public Sub petrify(ByVal c As Color)
        If title = "Succubus" Or title = "Slime" Or title = "Dragon" Or title = "Chicken" Then revert2()
        changeHairColor(c)
        If sexBool Then
            iArrInd(8) = New Tuple(Of Integer, Boolean)(10, True)
            iArrInd(9) = New Tuple(Of Integer, Boolean)(14, True)
        Else
            iArrInd(8) = New Tuple(Of Integer, Boolean)(5, False)
            iArrInd(9) = New Tuple(Of Integer, Boolean)(6, False)
        End If
        createP()
        changeSkinColor(c)
        iArr(8) = CharacterGenerator.recolor(iArr(8), c)
        iArr(9) = CharacterGenerator.recolor(iArr(9), c)

        canMoveFlag = False
        Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP(iArr)
    End Sub
    Public Sub toStatue(ByVal c As Color, ByVal r As String)
        petrify(c)
        If r.Equals("midas") Then
            Dim out As String = "As you reach out to touch your opponent, you clumsily swipe, missing them, and hit...yourself?  Already your legs are gold, and only have a moment to scream, your vocal cords quickly following suit. ''Well,'' you think, ''...at least I won't have to worry abou money anymore.'' " & vbCrLf & "And like that, the dungeon gains another decoration."
            Game.pushLblEvent(out)
            MsgBox(out)
            Die()
        End If
    End Sub

    'getter for buffable stats
    Function getmaxHealth()
        Return maxHealth + hBuff
    End Function
    Function getmaxMana()
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Then Return maxMana + mBuff
        Return maxMana + mBuff + equippedArmor.mBoost + equippedWeapon.mBoost
    End Function
    Function getAttack()
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Then Return attack + aBuff
        Return attack + aBuff + equippedArmor.aBoost
    End Function
    Function getDefence()
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Then Return defence + dBuff
        Return defence + dBuff + equippedArmor.dBoost
    End Function
    Function getSpeed()
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Then Return speed + sBuff
        Return speed + sBuff + equippedArmor.sBoost
    End Function
    Function getWillpower()
        Return discipline + wBuff
    End Function

    'getter for inventory sub catagories
    Function getArmors() As Tuple(Of String(), Armor())
        Dim s(UBound(armor)) As String
        For i = 0 To UBound(armor)
            s(i) = armor(i).getName
        Next
        Return New Tuple(Of String(), Armor())(s, armor)
    End Function
    Function getWeapons() As Tuple(Of String(), Weapon())
        Dim s(UBound(weapons)) As String
        For i = 0 To UBound(weapons)
            s(i) = weapons(i).getName
        Next
        Return New Tuple(Of String(), Weapon())(s, weapons)
    End Function

    'toString
    Public Overrides Function ToString() As String
        Dim output As String = ""

        currState.save(Me)
        output += currState.write()
        output += sState.write()
        output += pState.write()
        output += succState.write()
        output += slimState.write()
        output += goddState.write()
        output += dragState.write()
        output += bimbState.write()
        output += magGState.write()
        output += maidState.write()
        output += prinState.write()
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

        output += inventory.Count - 1 & "*"
        For i = 0 To inventory.Count - 1
            output += (inventory.Item(i).count & "*")
        Next
        Return output
    End Function
    Public Function toGhost() As String
        Dim output = CStr(name & " the " & title & "*" & health & "*" & maxHealth &
            "*" & getAttack() & "*" & getDefence() & "*" & getSpeed() & "*" & sexBool & "*" & haircolor.R & "*" & haircolor.G & "*" & haircolor.B & "*")
        For i = 0 To inventory.Count - 1
            output += (inventory.Item(i).count) & "*"
        Next
        For i = 0 To UBound(iArrInd)
            output += (iArrInd(i).Item1 & "%" & iArrInd(i).Item2 & "*")
        Next
        Return output
    End Function

    'description generation
    Function getHairColor() As String
        Dim c As Color
        Dim cArr As Color() = {Color.Aqua, Color.Aquamarine, Color.Azure, _
                               Color.Beige, Color.Black, Color.Blue, Color.BlueViolet, Color.Brown, _
                               Color.Chartreuse, Color.Chocolate, Color.Coral, Color.CornflowerBlue, Color.Crimson, Color.Cyan, _
                               Color.DarkBlue, Color.DarkCyan, Color.DarkGreen, Color.DarkMagenta, Color.DarkRed, Color.DarkSeaGreen, Color.DarkSlateBlue, Color.DarkTurquoise, Color.DarkViolet, _
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
            Dim ratio = isShadeOf(haircolor.R, haircolor.G, haircolor.B, cArr(i))
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
        Return out.ToLower
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
        out = "You are " & name & ", a " & sex & " " & title & vbCrLf & " " & vbCrLf

        'hair
        out += "You have " & getHairColor()
        If haircolor.A = 180 Then
            out += "gelatinous"
        End If
        If iArrInd(1).Item2 Then
            out += "hair, done in a feminine style." & vbCrLf & " " & vbCrLf
        Else
            out += "hair, done in a masculine style." & vbCrLf & " " & vbCrLf
        End If


        Return out
    End Function
End Class
