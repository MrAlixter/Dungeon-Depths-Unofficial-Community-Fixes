Public Class Player
    'Player is the representation of a player controlled entity (the main player, any teammates)
    'METHODS AND VARIABLES RELATED TO LEVELING HAVE BEEN COMMENTED OUT.
    Implements Updatable

    'Player Instance variables
    Public name, sex, description As String
    Public pClass As pClass = New pClass(1, 1, 1, 1, 1, 1, "Classless")
    Public pForm As pForm = New pForm(1, 1, 1, 1, 1, 1, "Human", True)
    'Public level, xp, nextLevelXp As Integer
    Public health As Double
    Public maxHealth, mana, maxMana, attack, defence, will, speed, evade, gold, lust As Integer
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
    Public equippedAcce As Accessory = New noAcce
    Public currTarget As Monster
    Public pos As Point
    Public canMoveFlag As Boolean = True
    Public perks As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)() 'perks also include triggers for events
    Public classes As Dictionary(Of String, pClass) = New Dictionary(Of String, pClass)()
    Public forms As Dictionary(Of String, pForm) = New Dictionary(Of String, pForm)()
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
    Public mysteryPotionDisplayOrder As New List(Of String)
    Dim armor() As Armor
    Dim weapons() As Weapon
    Dim acce() As Accessory
    Public useable(), food(), potions(), misc() As Item
    Public invNeedsUDate As Boolean = False
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
    Public isAttacking = False

    Public forcedPath() As Point = Nothing

    Public prefForm As preferedForm

    'New takes no parameters and sets all of the inst. variables to temp variables.
    'Variables will be set at the start of a game
    Sub New()
        name = "TEMP_NAME"
        sex = "TEMP_SEX"
        health = 1.0
        maxHealth = 100
        attack = 10
        defence = 10
        will = 10
        speed = 10
        evade = 10
        gold = 200
        lust = 0
        'level = 1
        'xp = 0
        'nextLevelXp = 100
        mana = 3
        maxMana = mana
        hunger = 0

        createInvPerks()
        inventory.Item(0).add(1)
        inventory.Item(2).add(1)
    End Sub
    'This New is used in the loading of a player from file
    Sub New(ByVal s As String, ByVal v As Double)
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

        Dim x As Integer = CInt(playArray(11)) - 1
        For i = 0 To x
            inventory.Item(i).add(playArray(12 + i))
        Next

        If Game.version >= 0.6 Then
            Dim y = 0
            Dim tfp As List(Of Point) = New List(Of Point)
            If Not playArray(14 + x).Equals("N/a") Then
                y = CInt(playArray(13 + x)) * 2
                For i = 0 To y Step 2
                    tfp.Add(New Point(CInt(playArray(14 + x + i)), playArray(15 + x + i)))
                Next
                forcedPath = tfp.ToArray
            Else
                tfp = Nothing
            End If

            Dim currentIndex = 15 + x + y
            If Not playArray(14 + x).Equals("N/a") Then currentIndex += 1

            Dim stuff() As String = playArray(currentIndex).Split("$")

            If Not stuff(0).Equals("N/a") Then
                prefForm = New preferedForm(Color.FromArgb(CInt(stuff(0)), CInt(stuff(1)), CInt(stuff(2)), CInt(stuff(3))), _
                                            Color.FromArgb(CInt(stuff(4)), CInt(stuff(5)), CInt(stuff(6)), CInt(stuff(7))), _
                                            CBool(stuff(8)), CBool(stuff(9)), CInt(stuff(10)), CBool(stuff(11)), CInt(stuff(12)))
                inventory(69).setFormerLife(stuff(13), New Tuple(Of Integer, Boolean)(CInt(stuff(14)), stuff(15)))
            Else
                inventory(69).setFormerLife(stuff(1), New Tuple(Of Integer, Boolean)(CInt(stuff(2)), stuff(3)))
            End If
        End If

        currState.load(Me)
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
    Sub reachedFPathDest()
        If pClass.name.Equals("Thrall") Then
            If 1 = 1 Then 'Int(Rnd() * 2) = 1 Then
                Dim out = "You've found one of the crystals your controller is seeking!  As you circle it, you feel a familiar presence enter your mind.  " & _
                    """Yes!  You've found it!"" your overseer states exitedly, ""I'll be over shortly, don't go anywhere and don't touch that crystal.""" & vbCrLf & _
                    "Obeying, you take a seat and wait for a few minutes before a violet portal opens up near the crystal and your master steps out."
                If will > 7 Then

                Else
                    out += "Despite your excitement, they don't seem to notice you, instead focusing all their attention on the crystalline array.  As they fiddle with it, you notice a slight purple aura beginning to form around them and wait, are those horns sprouting out of their hair that seems to catch a non-existant wind?  With a flourish, they complete ... something ... and a blinding flash engulfs them.  Where once stood your human controller now stands a half-demon who only now seems to have taken notice of you." & _
                        """Well... It looks like you succeeded.  For that, I will give you an ultimatium.  Join me as my general, or die in these dungeons as my slave."
                    Game.pushLblEvent(out, AddressOf acceptSorc, AddressOf fightSorc)
                End If

            Else
                Game.pushLblEvent("You've found one of the crystals your controller is seeking!  As you circle it, you feel a familiar presence enter your mind.  " & _
                    """No, that isn't it."" your overseer states disappointedly, ""Well, I guess you can go back to your buisness now.""")
            End If
            'toDo:  roll a d2 
            '       if 1, then the player has the option to break free of the collar and fight a "Demonic Sorcerer/Sorceress"
            '       otherwise, they check in with their controller who informs them that they haven't found the right array.
        End If
    End Sub
    Sub fightSorc()
        Dim m As Monster
        m = New Monster(9)
        Game.npcList.Add(m)
        currTarget = m
        Game.toCombat()
        Game.lstLog.Items.Add((m.getName() & " attacks!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Sub fightSorc2()
        Dim m As Monster
        m = New Monster(8)
        Equipment.accChange("Nothing")
        Game.npcList.Add(m)
        currTarget = m
        Game.toCombat()
        Game.lstLog.Items.Add((m.getName() & " attacks!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Sub acceptSorc()
        perks("thrall") = -1
        Polymorph.transform(Me, "Half-Succubus")
        Game.pushLblEvent("""Then I deem your task concluded as a success.  Go now, and take care not to fall under the spell of any others,"" your controller states.")
    End Sub
    Sub betraySorc()
        Game.pushLblEvent("Brushing past you, your ""boss"" heads straight for the array.  As they begin fiddling with it, you take notice of their distraction and begin creeping into a position behind them.  As they chant over the array, you prepare to make your move.  " & _
                          "As their raving reaches its zenith and the runes enscribed on the crystal begin to glow you strike out, disrupting their ritual.  ""YOU!  DO YOU HAVE ANY IDEA ..."" screams the mage, and while they shout you realize you couldn't care less about them.  " & _
                          "Looking down, you see that your collar has gone dark and dangles open from your neck.  Grinning, your prepare to fight for your life.", AddressOf fightSorc2)
        equippedAcce.onUnequip()
        equippedAcce = New noAcce
        inventory(69).count -= 1

        Equipment.portraitUDate()
    End Sub
    Sub waitSorc()
        Dim out = "You decide against making a move now, instead waiting to see what happens next.  Your controller doesn't seem to notice you, instead focusing all their attention on the crystalline array.  As they fiddle with it, you notice a slight purple aura beginning to form around them and wait, are those horns sprouting out of their hair that seems to catch a non-existant wind?  With a flourish, they complete ... something ... and a blinding flash engulfs them.  Where once stood your human controller now stands a half-demon who only now seems to have taken notice of you." & _
                        """Well... It looks like you succeeded.  For that, I will give you an ultimatium.  Join me as my general, or die in these dungeons as my slave."
        Game.pushLblEvent(out, AddressOf acceptSorc, AddressOf fightSorc)
    End Sub

    Sub followPath()
        If forcedPath(0).X = 0 And forcedPath(0).Y = 0 Then
            reachedFPathDest()
            forcedPath = Nothing
        Else
            Dim t(UBound(forcedPath)) As Point
            pos = forcedPath(0)
            For i = 1 To UBound(forcedPath)
                t(i - 1) = forcedPath(i)
            Next
            forcedPath = t
        End If
    End Sub
    Function resistPath()
        Return (Int(Rnd() * 3) = 0) And getWillpower() > 7
    End Function

    Public Sub moveUp()
        If Not forcedPath Is Nothing Then
            followPath()
            Exit Sub
        End If
        If (pos.Y - 1) < 0 Or canMoveFlag = False Then Exit Sub
        If Game.mBoard(pos.Y - 1, pos.X).Tag = 0 Then Exit Sub
        pos.Y -= 1
    End Sub
    Public Sub moveDown()
        If Not forcedPath Is Nothing Then
            followPath()
            Exit Sub
        End If
        If (pos.Y + 1) > Game.mBoardHeight - 1 Or canMoveFlag = False Then Exit Sub
        If Game.mBoard(pos.Y + 1, pos.X).Tag = 0 Then Exit Sub
        pos.Y += 1
    End Sub
    Public Sub moveLeft()
        If Not forcedPath Is Nothing Then
            followPath()
            Exit Sub
        End If
        If (pos.X - 1) < 0 Or canMoveFlag = False Then Exit Sub
        If Game.mBoard(pos.Y, pos.X - 1).Tag = 0 Then Exit Sub
        pos.X -= 1
    End Sub
    Public Sub moveRight()
        If Not forcedPath Is Nothing Then
            followPath()
            Exit Sub
        End If
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
    Public Sub takeDMG(ByVal dmg As Integer, ByRef source As Updatable)
        currTarget = source
        If dmg > 0 Then dmg += Int(Rnd() * 3) + -1
        If dmg = -2 Then
            dmg = currTarget.attack * 2
            'Dim actualDMG As Integer = dmg - ((getDefence() / 100) * dmg)
            Dim actualDMG As Integer = dmg * Math.Min(getDefence() / 100, 0.5)
            health -= actualDMG / getmaxHealth()
            Game.lblPHealtDiff.Tag -= actualDMG
            Game.lstLog.Items.Add(CStr("You got hit! Critical hit! -" & actualDMG & " health!"))
            Game.pushLblCombatEvent(CStr("You got hit! Critical hit! -" & actualDMG & " health!"))
        ElseIf dmg = -1 Then
            Game.lblPHealtDiff.Tag -= 0
            Game.lstLog.Items.Add(CStr("You are able to evade your opponent!"))
            Game.pushLblCombatEvent(CStr("You are able to evade your opponent!"))
        Else
            Dim actualDMG As Integer = dmg - ((getDefence() / 100) * dmg)
            If actualDMG < 1 Then actualDMG = 1
            health -= actualDMG / getmaxHealth()
            Game.lblPHealtDiff.Tag -= actualDMG
            Game.lstLog.Items.Add(CStr("You got hit! -" & actualDMG & " health!"))
            Game.pushLblCombatEvent(CStr("You got hit! -" & actualDMG & " health!"))
        End If
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub

    'genral functions
    'Die handles a player death
    Public Sub Die()
        initPerks()
        If Game.pnlSaveLoad.Visible = True Then Exit Sub
        Try
            If currTarget.name.Equals("Shopkeeper") Then
                Dim n As NPC = Game.currNPC
                petrify(Color.Goldenrod)
                Dim out As String = """You should have known better than to try and rob a shop keeper,"" the shopkeep says," & vbCrLf &
                    " glaring down at you, ""...and if its gold you're after, I guess I've got some good news for you.""" & vbCrLf &
                    "  With that, " & n.pronoun & " reaches into " & n.pPronoun & " bag and puts on a gaudy gauntlet " & vbCrLf &
                    "that begins glowing with a golden light. You lack the strength to fight back as " & n.pronoun & " places" & vbCrLf &
                    " his thumb on your forhead, and suddenly everything just seems so heavy. ""Noooo..."" you moan, " & vbCrLf &
                    "as the area around where he touched turns to gold, and that gold turns your flesh and blood " & vbCrLf &
                    "around it to gold as well. In a matter of seconds, all that is left of " & Me.name & " the " & vbCrLf &
                    Me.pClass.name & " is a solid gold statue. The shopkeeper sighs, muttering to no one in particular, " & vbCrLf &
                    vbCrLf & vbCrLf & """Now how am I going to get you back to the refinery?"""
                'Game.pushLblEvent(out)
                pClass = classes("Trophy")
                MsgBox(out)
            ElseIf currTarget.name.Equals("Mindless Bimbo") Then
                Game.player.perks("bimbotf") = 1
                Dim out As String = "Exausted, you slump to the floor.  Glancing up, the horny mess attacking you seem to have gotten a running start, throwing herself on top of you, and pulling you into a sloppy kiss.  As she clumsily fumbles around, trying to remove your clothes, you roll out from underneath her and beat a hasty retreat, the faint sweetness of bubblegum lingering in your mouth."
                currTarget.despawn("run")
                Game.pushLblEvent(out)
                health = 0.1
                Exit Sub
            ElseIf currTarget.name.Equals("Mesmerized Thrall") Then
                Dim out As String = ""
                Dim ln1 As String = Nothing
                If pClass.name.Equals("Thrall") Then
                    out = "Despite your fatigue, you are able to roll out of the way of the thrall's attempt to restrain you, and make a clumsy escape."
                    health = 0.1
                Else
                    ln1 = "As you collapse, you see the thrall pull a small metal collar out of their bag.  Lacking the strength to resist, you are powerless as they secure it firmly around your neck, all the while murmuring whispers of the joys of submission into your ear.  Once they have the collar fitted properly, they place a small glowing gem into a slot on the collar, igniting a small array of runes.  Your mind goes blank in an instant, and while at first an ammnesia-fueled panic sets in it is quickly replaced by a booming disembodied voice."
                    inventory(69).addone()
                    If Not equippedAcce.getName.Equals("Nothing") Then equippedAcce.onUnequip()
                    Equipment.accChange("Slave_Collar")
                    health = 1
                    mana = getmaxMana()
                    Game.player.will -= 3
                    If Game.player.will < 1 Then Game.player.will = 0
                End If
                currTarget.despawn("run")
                If Not ln1 Is Nothing Then
                    Game.pushLblEvent(ln1, AddressOf thrallLN2)
                Else
                    Game.pushLblEvent(out)
                End If
                Exit Sub
            ElseIf currTarget.name.Equals("Enthralling Sorcerer") Or currTarget.name.Equals("Enthralling Sorceress") Then
                Dim out As String = ""
                If pClass.name.Equals("Thrall") Then
                    out = "Despite your fatigue, you are able to roll out of the way of the mage's attempt to restrain you, and make a clumsy escape."
                    health = 0.1
                Else
                    out = """Wonderful!"", your opponent exclaims as you collapse, ""You'll make a perfect thrall!""" & vbCrLf & _
                          "𝘛𝘩𝘳𝘢𝘭𝘭!? you think moments before a small metal collar finds its way around your neck and a network of runes inscribed on it begin glowing with your new master's magic.  𝘞𝘢𝘪𝘵 ... 𝘕𝘦𝘸 𝘔𝘈𝘚𝘛𝘌𝘙?!  You don't have a momment to rest before your mind is filled with a booming voice." & vbCrLf & _
                          """LISTEN UP, NEW SLAVE!  I have need of your services."" your new master begins, ""In this dungeon, there are several high-power mana arrays.  Only one of them, however, is capable of bestowing the power of a demon lord onto a mortal such as I.  Your task is to find and inspect these arrays, and report back to me with your findings.""  They snicker,  ""I'm sure you won't let me down, but I'm going to need to make a few changes to make you more ... uniform ... with the rest of your collegues.""" & vbCrLf & vbCrLf & "...       " & vbCrLf & vbCrLf & "With a final warning not to fail them, the foreign presence leaves your mind and you are once again alone with your thoughts and your task."
                    inventory(69).addone()
                    If Not equippedAcce.getName.Equals("Nothing") Then equippedAcce.onUnequip()
                    equippedAcce = inventory(69)
                    equippedAcce.onEquip()
                    health = 1
                    mana = getmaxMana()
                    prefForm.snapShift(Me)
                    Game.player.will -= 3
                    If Game.player.will < 1 Then Game.player.will = 0
                End If
                currTarget.despawn("run")
                Game.pushLblEvent(out)
                Exit Sub
            ElseIf currTarget.name.Equals("Slime") Or currTarget.name.Equals("Goo Girl") Then
                Dim out As String = "As the " & currTarget.name & " closes in on you, you push yourself off the ground, sidestep it, and make a hasty retreat." & vbCrLf & " " & vbCrLf & "[Insert a TF here (eventually)]"
                currTarget.despawn("run")
                Game.pushLblEvent(out)
                health = 0.1
                Exit Sub
            ElseIf currTarget.name.Equals("Spider") Or currTarget.name.Equals("Arachne Huntress") Then
                Dim out As String = "As the " & currTarget.name & " closes in on you, you push yourself off the ground, sidestep it, and make a hasty retreat." & vbCrLf & " " & vbCrLf & "[Insert a TF here (eventually)]"
                currTarget.despawn("run")
                Game.pushLblEvent(out)
                health = 0.1
                Exit Sub
            ElseIf currTarget.name.Equals("Mimic") Then
                currTarget.despawn("run")
                Dim out As String = "As you collapse, out of the corner of your eye you can see thick tendrils flowing out of the chest that could only be the body of the mimic.  Some of the tendrils wrap around your wrist and ankles, while others work their way up your thighs, aggressively groping your thighs."
                If equippedArmor.getName.Equals("Naked") Then
                    out += "  As you black out, you can feel the tendrils writhing around you crotch.  As the darkness takes you, so does the orgasmic bliss of the mimic's magic touch."
                    lust += 50
                    createP()
                    Game.pushLblEvent(out)
                    health = 0.1
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
                health = 0.1
                Exit Sub
            ElseIf currTarget.name.Equals("Hunger") Then
                Game.pushLblEvent("You starve to death!")
            End If
        Catch ex As Exception
            MsgBox("D_D Error 002: Unknown Cause of death")
        End Try
        isDead = True
        Dim r As Integer = CInt(Int(Rnd() * 2))
        If r = 0 Then
            If Not Game.currNPC Is Nothing AndAlso Game.currNPC.name.Equals("Shopkeeper") Then pClass = classes("Trophy")
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
    Sub thrallLN2()
        Dim ptype = "sister"
        If Int(Rnd() * 2) = 0 Then
            ptype = "brother"
        End If
        Game.pushLblEvent("""LISTEN UP, NEW SLAVE!  I have need of your services."" your new master begins, ""In this dungeon, there are several high-power mana arrays.  Only one of them, however, is capable of bestowing the power of a demon lord onto a mortal such as I.  Your task is to find and inspect these arrays, and report back to me with your findings.""  They snicker,  ""I'm sure you won't let me down, but I'm going to need to make a few changes to make you more ... uniform ... with the rest of your collegues.""" & vbCrLf & vbCrLf & "        .....       " & vbCrLf & vbCrLf & "With a final warning not to fail them, the foreign presence leaves your mind and you are once again alone with your thoughts, your new " & ptype & ", and your task.")
    End Sub
    'setClass sets the player stats at the beginning of the game
    Sub setACCA()
        If iArrInd(14).Item2 Then
            Select Case iArrInd(14).Item1
                Case 1
                    equippedAcce = inventory(66)
                Case 2
                    equippedAcce = inventory(67)
                Case 3
                    equippedAcce = inventory(68)
                Case Else
                    equippedAcce = New noAcce
                    equippedAcce.count -= 1
            End Select
        Else
            Select Case iArrInd(14).Item1
                Case 1
                    equippedAcce = inventory(67)
                Case 2
                    equippedAcce = inventory(68)
                Case Else
                    equippedAcce = New noAcce
                    equippedAcce.add(-1)
            End Select
        End If
        equippedAcce.add(1)
    End Sub
    Public Sub setClass(ByVal s As String)
        equippedArmor = New NormalClothes
        equippedWeapon = New BareFists
        setACCA()

        If s = "Warrior" Then
            inventory.Item(5).addOne()
            inventory.Item(6).addOne()
            equippedArmor = inventory.Item(5)
            equippedWeapon = inventory.Item(6)
        ElseIf s = "Mage" Then
            Game.cboxMG.Items.Add("Fireball")
            inventory.Item(2).add(3)
            inventory.Item(4).add(1)
            inventory.Item(21).add(1)
            equippedWeapon = inventory.Item(21)
        End If
        pClass = classes(s)
        Equipment.clothesChange(equippedArmor.getName)
        If equippedWeapon.GetType().IsSubclassOf(GetType(Staff)) Then
            mana += equippedWeapon.mBoost
        End If
        If sex = "Female" Then sexBool = True
        If sex = "Male" Then sexBool = False
        pImage = Game.picPlayer.BackgroundImage
        TextColor = Color.White
        description = CStr(name & " is a " & sex & " " & pForm.name & " " & pClass.name)

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
        If tEweap.getName = "Magic_Girl_Wand" Then tEweap = New BareFists()
        If tEarm.getName = "Magic_Girl_Outfit" Then tEarm = New Naked()

        sState.load(Me)

        mana = tMna
        gold = tGold
        equippedArmor = tEarm
        equippedWeapon = tEweap
        perks("slutcurse") = -1
        currState.save(Me)
        pState.save(Me)

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
        Equipment.portraitUDate()
        setPImage()
        UIupdate()
    End Sub
    Public Sub revert2()
        Dim tHth As Integer = health + hBuff
        Dim tMna As Integer = mana + mBuff
        Dim tHun As Integer = hunger
        Dim tGold As Integer = gold
        Dim tEweap As Weapon = equippedWeapon
        Dim tEarm As Armor = equippedArmor
        If tEweap.getName = "Magic_Girl_Wand" Then tEweap = New BareFists()
        If tEarm.getName = "Goddess_Gown" Or tEarm.getName = "Succubus_Garb" Then tEarm = New NormalClothes
        pState.load(Me)

        mana = tMna
        gold = tGold
        If Not tEarm.getName.Equals("Magic_Girl_Outfit") Then equippedArmor = tEarm
        equippedWeapon = tEweap
        currState.save(Me)
        pState.save(Me)

        If Game.cboxMG.SelectedItem = "Heartblast Starcannon" Then
            Game.cboxMG.Items.Insert(0, "-- Select --")
            Game.cboxMG.SelectedIndex = 0
        End If
        Do While Game.cboxMG.Items.Contains("Heartblast Starcannon")
            Game.cboxMG.Items.Remove("Heartblast Starcannon")
            Game.lstLog.Items.Add("'Heartblast Starcannon' spell forgotten!")
        Loop

        If health > 1 Then health = 1
        If mana > maxMana + mBuff Then mana = maxMana + mBuff
        Game.pushLblEvent("You return to your former form!")
        Game.pImage = pImage
        Game.lblEvent.ForeColor = TextColor
        Game.lblNameTitle.ForeColor = TextColor

        changeHairColor(haircolor)
        Equipment.portraitUDate()
        setPImage()
        UIupdate()
    End Sub
    Public Sub setPImage()
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
        ElseIf Game.turn Mod 25 = 0 Then
            hunger += 1
        End If
        If health > 1 Then health = 1
        If mana > getmaxMana() Then mana = getmaxMana()
        'If inventory(8).count > 0 Then
        '    inventory(8).count = 0
        '    Game.pushLblEvent("The chicken suit phases out of reality")
        'End If
    End Sub
    Sub createInvPerks()
        'create inventory
        '0.1 - 0.4
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
        inventory.Add(New ChitArmor()) '64
        '0.5
        inventory.Add(New ASpellbook()) '65
        '0.6
        inventory.Add(New HeartNecklace()) '66
        inventory.Add(New RedHeadband()) '67
        inventory.Add(New RubyCirclet()) '68
        inventory.Add(New ThrallCollar()) '69
        inventory.Add(New Cowbell()) '70
        inventory.Add(New CowBra()) '71

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
                 inventory(56), inventory(64), inventory(71)}

        weapons = {New BareFists(),
                   inventory(6), inventory(9), inventory(11), inventory(21),
                   inventory(22), inventory(23), inventory(24), inventory(40),
                   inventory(41), inventory(42), inventory(45), inventory(63)}

        useable = {inventory(0), inventory(1), inventory(3), inventory(4),
                   inventory(65), inventory(15), inventory(36), inventory(37),
                   inventory(45), inventory(48), inventory(49), inventory(50),
                   inventory(51), inventory(52), inventory(57), inventory(58)}

        food = {inventory(30), inventory(31), inventory(32), inventory(33),
                inventory(34), inventory(35), inventory(44)}

        acce = {New noAcce(), inventory(66), inventory(67), inventory(68),
                inventory(69), inventory(70)}

        potions = {inventory(2), inventory(13), inventory(14), inventory(25),
                   inventory(26), inventory(27), inventory(28), inventory(29),
                   inventory(59), inventory(60), inventory(61), inventory(62)}
        Array.Sort(potions)

        misc = {inventory(43), inventory(53)}

        initPerks()

        'Creates the class dictionary
        classes.Clear()
        classes.Add("Classless", New pClass(1, 1, 1, 1, 1, 1, "Classless"))
        classes.Add("Warrior", New pClass(1, 1.5, 0.75, 1.5, 0.75, 1, "Warrior"))
        classes.Add("Mage", New pClass(1, 0.75, 1.5, 0.75, 1, 1.5, "Mage"))
        classes.Add("Magic Girl", New pClass(1, 0.5, 1.5, 0.75, 1.5, 1.5, "Magic Girl"))
        classes.Add("Magic Girl​", New pClass(1, 0.5, 1.5, 0.75, 1.5, 1.5, "Magic Girl​"))
        classes.Add("Bimbo", New pClass(0.75, 0.5, 0.5, 0.75, 1, 0.5, "Bimbo"))
        classes.Add("Princess", New pClass(0.75, 1, 1, 0.75, 0.75, 1.5, "Princess"))
        classes.Add("Maid", New pClass(0.75, 0.5, 0.75, 0.75, 1.5, 0.5, "Maid"))
        classes.Add("Goddess", New pClass(2, 2, 2, 2, 2, 2, "Goddess"))
        classes.Add("Paladin", New pClass(1, 1.5, 1.5, 1.5, 0.75, 1.5, "Paladin"))
        classes.Add("Thrall", New pClass(1, 1, 1, 1, 1, 0.5, "Thrall"))
        classes.Add("Trophy", New pClass(0.1, 0.1, 0.1, 4, 0.1, 0.1, "Trophy"))
        classes.Add("Princess​", New pClass(0.75, 1, 1, 0.75, 0.75, 1.5, "Princess​"))
        classes.Add("Bunny Girl​", New pClass(0.75, 0.5, 0.5, 0.75, 1, 0.5, "Bunny Girl​"))
        classes.Add("Kitty", New pClass(0.75, 0.5, 0.5, 0.75, 1, 0.5, "Kitty"))
        classes.Add("Soul-Lord", New pClass(1.75, 1.75, 1.75, 1.75, 1.75, 1.75, "Soul-Lord"))
        classes.Add("Targaxian", New pClass(1, 1, 1, 1, 1, 0.5, "Targaxian"))
        classes.Add("Unconscious", New pClass(pClass.h, pClass.a, pClass.m, pClass.d, pClass.s, pClass.w, "Unconscious"))

        'Creates the form dictionary
        forms.Clear()
        forms.Add("Human", New pForm(1, 1, 1, 1, 1, 1, "Human", True))
        forms.Add("Elf", New pForm(0.75, 1, 1.5, 1, 1, 1, "Elf", True))
        forms.Add("Android", New pForm(1, 1, 1, 1.5, 1, 0.75, "Android", True))
        forms.Add("Succubus", New pForm(1.5, 1.5, 1.5, 0.75, 1.5, 1, "Succubus", True))
        forms.Add("Half-Succubus", New pForm(1.1, 1.5, 1.1, 1.1, 1.5, 1, "Half-Succubus", True))
        forms.Add("Angel", New pForm(2, 1.1, 0.9, 1.1, 1.5, 1.5, "Angel", True))
        forms.Add("Slime", New pForm(0.4, 1, 1, 2.5, 0.75, 0.75, "Slime", True))
        forms.Add("Half-Slime", New pForm(0.75, 1, 1, 1.7, 1, 1, "Half-Slime", True))
        forms.Add("Tigress", New pForm(1, 1.5, 1, 0.75, 1.5, 1, "Tigress", False))
        forms.Add("Dragon", New pForm(1, 1.5, 1.5, 2, 0.5, 1, "Dragon", False))
        forms.Add("Half-Dragon", New pForm(1, 1.5, 1, 1.5, 0.75, 1, "Half-Dragon", False))
        forms.Add("Harpy", New pForm(1, 1.5, 1, 0.5, 2, 1, "Harpy", False))
        forms.Add("Djinn", New pForm(0.75, 0.75, 3, 0.5, 0.75, 0.5, "Djinn", True))
        forms.Add("Minotaur Cow", New pForm(2, 1, 0.75, 1.5, 0.75, 0.5, "Minotaur Cow", True))
        forms.Add("Minotaur Bull", New pForm(1.5, 1.5, 0.75, 1.5, 0.75, 0.5, "Minotaur Bull", True))
        forms.Add("Golem", New pForm(0.75, 1, 0.5, 2, 0.5, 0.5, "Golem", True))
        forms.Add("Elder-God", New pForm(3, 3, 3, 3, 3, 3, "Elder-God", False))
        forms.Add("Gynoid", New pForm(0.75, 0.75, 0.75, 1.5, 1.5, 0.5, "Gynoid", True))
        forms.Add("Cyborg", New pForm(1, 1.5, 1.5, 1.5, 1.5, 1, "Cyborg", True))
        forms.Add("Blowup Doll", New pForm(0.7, 0.7, 0.7, 0.5, 0.5, 0.75, "Blowup Doll", False))
        forms.Add("Cake", New pForm(1.5, 0.75, 1, 0.5, 0.5, 1, "Cake", False))
        forms.Add("Sheep", New pForm(1.5, 0.5, 0.5, 1.5, 0.5, 0.75, "Sheep", False))
        forms.Add("Frog", New pForm(0.75, 0.5, 0.5, 0.5, 2, 1, "Frog", False))
    End Sub
    Sub initPerks()
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
    End Sub
    Sub perkUpdate()
        'hunger
        If perks("hunger") > -1 And Game.turn Mod 5 = 0 Then
            If hunger < 100 Then
                perks("hunger") = -1
            Else
                health -= 5 / getmaxHealth()
                Game.lstLog.Items.Add("Your stomach aches... -5 health!")
                If health <= 0 Then setTarg(New Monster(10))
            End If
        End If
        'bimbo tf
        If perks("bimbotf") > -1 Then
            perks("chickentf") = -1
            If perks("polymorphed") > -1 Then perks("bimbotf") = -1
            If Not pClass.name.Equals("Bimbo") Then
                If perks("bimbotf") < 19 And perks("bimbotf") Mod 10 = 0 Then
                    haircolor = Game.cShift(haircolor, Polymorph.bimboyellow, 25)
                    createP()
                End If
                Select Case perks("bimbotf")
                    Case 0
                        If Not pClass.name.Equals("Magic Girl") And Not perks("polymorphed") > -1 Then
                            pState.save(Me)
                        ElseIf pClass.name.Equals("Magic Girl") Then
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
                If perks("bimbotf") = 1 And Not pClass.name.Equals("Magic Girl") Then Game.pushLblEvent(outputln1)
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
                If health < 1 And Game.turn Mod 4 = 0 Then
                    health += 25 / getmaxHealth()
                    Game.lstLog.Items.Add("Your gel body heals some of the damage done to it. +5 health")
                    If health > 1 Then health = 1
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
            If currTarget Is Nothing Then
                perks("nekocurse") = -1
            ElseIf currTarget.dead Then
                perks("nekocurse") = -1
            End If
            If Not perks("polymorphed") > -1 Then
                If perks("nekocurse") < Int((will * 1.2) * 1.3) Then
                    Select Case perks("nekocurse")
                        Case Int((will * 1.2) * 0.1)
                            Polymorph.transform(Me, "neko", 0)
                        Case Int((will * 1.2) * 0.3)
                            Polymorph.transform(Me, "neko", 1)
                        Case Int((will * 1.2) * 0.5)
                            If Not pClass.name.Equals("Magic Girl") Then
                                Polymorph.transform(Me, "neko", 2)
                            Else
                                haircolor = Color.FromArgb(255, 20, 20, 20)
                                Game.pushLblEvent("Your hair becomes a shiny black!")
                                lust += 5
                            End If
                        Case Int((will * 1.2) * 0.7)
                            Polymorph.transform(Me, "neko", 3)
                        Case Int((will * 1.2) * 0.9)
                            Polymorph.transform(Me, "neko", 4)
                        Case Int((will * 1.2) * 1.1)
                            If pClass.name.Equals("Magic Girl") Then
                                Polymorph.transform(Me, "neko", 6)
                            Else
                                Polymorph.transform(Me, "neko", 5)
                            End If
                            inventory.Item(12).addOne()
                            lust += 5
                            will -= 2
                            Equipment.clothesChange("Cat_Lingerie")
                            Equipment.portraitUDate()
                        Case Int((will * 1.2) * 1.3)
                            will = 0
                            Polymorph.transform(Me, "neko", 7)
                    End Select
                    perks("nekocurse") += 1
                Else
                    will = 0
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
                If health < 1 And Game.turn Mod 7 = 0 Then
                    Dim h As Integer = Int(Rnd() * 15) + 1
                    health += h / getmaxHealth()
                    Game.lstLog.Items.Add("The gel portion of your body is able to heal some of your wounds! +" & h & " health")
                    If health > 1 Then health = 1
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
        'thrall tf
        If perks("thrall") > -1 And Not pForm.name.Equals("Half-Succubus") And forcedPath Is Nothing And Not Game.lblEvent.Visible Then
            If Game.turn Mod 10 = 0 And Not prefForm.playerMeetsForm(Game.player) And perks("thrall") < 21 Then
                prefForm.shiftTowards(Game.player)
                perks("thrall") += 1
                If perks("thrall") > 20 Then
                    prefForm.snapShift(Game.player)
                End If
            End If

            If prefForm.playerMeetsForm(Game.player) Then
                If forcedPath Is Nothing And Not Game.combatmode And Not Game.npcmode Then
                    Dim crystalX As Integer
                    Dim crystalY As Integer
                    Do While (Game.mBoard(crystalY, crystalX).Tag <> 1 Or Game.mBoard(crystalY, crystalX).Text <> "")
                        crystalX = CInt(Int(Rnd() * Game.mBoardWidth))
                        crystalY = CInt(Int(Rnd() * Game.mBoardHeight))
                    Loop
                    Dim crystal = New Point(crystalX, crystalY)

                    Game.mBoard(crystalY, crystalX).Tag = 2
                    Game.mBoard(crystalY, crystalX).Text = "c"

                    forcedPath = Game.route(Game.player.pos, crystal, New Point(0, 0))


                    Dim s As String = ""
                    If getWillpower() > 10 Then
                        s = "you mock your instructions under your breath, before stiffly moving towards the crystal." + vbCrLf + "𝘐𝘧 𝘰𝘯𝘭𝘺 𝘐 𝘤𝘰𝘶𝘭𝘥 𝘨𝘦𝘵 𝘵𝘩𝘪𝘴 𝘥𝘢𝘮𝘯 𝘤𝘰𝘭𝘭𝘢𝘳 𝘰𝘧𝘧..."
                    ElseIf getWillpower() > 7 Then
                        s = "you reluctantly start off towards the crystal." + vbCrLf + "𝘖𝘩 𝘸𝘦𝘭𝘭, 𝘣𝘦𝘵𝘵𝘦𝘳 𝘮𝘦 𝘵𝘩𝘢𝘯 𝘰𝘯𝘦 𝘰𝘧 𝘵𝘩𝘦𝘪𝘳 𝘰𝘵𝘩𝘦𝘳 𝘪𝘥𝘪𝘰𝘵𝘴."
                    ElseIf getWillpower() > 4 Then
                        s = "you jump immediatly into action, happy to help the voice in your head with whatever it may need." + vbCrLf + "𝘐'𝘮 𝘨𝘰𝘪𝘯𝘨 𝘵𝘰 𝘮𝘢𝘬𝘦 𝘲𝘶𝘪𝘤𝘬 𝘸𝘰𝘳𝘬 𝘰𝘧 𝘵𝘩𝘪𝘴 𝘵𝘢𝘴𝘬!"
                    Else
                        s = "you mindlessly obey, moving towards the crystal with a vacant grin."
                    End If
                    Game.pushLblEvent("As your collar flares to life, you grimace as the location of a large mana crystal becomes clear in your mind." & _
                                      "'SERVANT!', your controller's voice booms in your head, 'This is another of the crystals!  Recover it immediately!'" & vbCrLf & _
                                      "As their voice leaves your head, " & s)
                End If
            End If
        End If
        'shift toward prefered form
        If Not prefForm Is Nothing AndAlso (pClass.name = "Thrall" Xor equippedAcce.getName.Equals("Slave_Collar")) AndAlso Not prefForm.playerMeetsForm(Game.player) And Not pForm.name.Equals("Half-Succubus") And Not perks("thrall") = 1 And Not perks("nekocurse") > -1 And Not perks("polymorphed") > -1 And Not perks("bimbotf") > -1 Then
            prefForm.shiftTowards(Game.player)
            perks("thrall") = 1
        End If

        'cowbell tf
        If perks("cowbell") > -1 Then
            If Polymorph.canBeTFed(Me) Then
                Select Case perks("cowbell")
                    Case 0
                        If Game.turn Mod 20 = 5 Then
                            If Int(Rnd() * 3) = 0 Then
                                Polymorph.transform(Me, "Minotaur_F", 0)
                                perks("cowbell") += 1
                            End If
                        End If
                        Exit Select
                    Case 1
                        If Game.turn Mod 20 = 1 Then
                            If Int(Rnd() * 4) = 0 Then
                                Polymorph.transform(Me, "Minotaur_F", 1)
                                perks("cowbell") += 1
                            End If
                        End If
                        Exit Select
                    Case 2
                        If Game.turn Mod 20 = 1 Then
                            If Int(Rnd() * 4) = 0 Then
                                Polymorph.transform(Me, "Minotaur_F", 2)
                                perks("cowbell") += 1
                            End If
                        End If
                        Exit Select
                    Case 3
                        If Game.turn Mod 20 = 1 Then
                            If Int(Rnd() * 4) = 0 Then
                                Polymorph.transform(Me, "Minotaur_F", 3)
                                perks("cowbell") += 1
                            End If
                        End If
                        Exit Select
                    Case 4
                        If Game.turn Mod 20 = 1 Then
                            If Int(Rnd() * 4) = 0 Then
                                Polymorph.transform(Me, "Minotaur_F", 4)
                                perks("cowbell") += 1
                            End If
                        End If
                        Exit Select
                    Case 5
                        If Game.turn Mod 20 = 1 Then
                            If Int(Rnd() * 3) = 0 Then
                                Polymorph.transform(Me, "Minotaur_F", 5)
                                perks("cowbell") += 1
                            End If
                        End If
                        Exit Select
                    Case 6
                        If Game.turn Mod 20 = 1 Then
                            If Int(Rnd() * 3) = 0 Then
                                Polymorph.transform(Me, "Minotaur_F", 6)
                                perks("cowbell") += 1
                            End If
                        End If
                        Exit Select
                    Case 7
                        If Game.turn Mod 20 = 1 Then
                            If Int(Rnd() * 2) = 0 Then
                                Polymorph.transform(Me, "Minotaur_F", 7)
                                perks("cowbell") += 1
                            End If
                        End If
                        Exit Select
                    Case 8
                        If Game.turn Mod 20 = 1 Then
                            If Int(Rnd() * 2) = 0 Then
                                Polymorph.transform(Me, "Minotaur_F", 8)
                                perks("cowbell") += 1
                            End If
                        End If
                        Exit Select
                    Case Else
                        perks("cowbell") = -1
                End Select
            End If
        End If
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        description = CStr(name & " is a " & sex & " " & pForm.name & " " & pClass.name)
    End Sub
    Sub UIupdate()
        perkUpdate()
        If health <= 0 Then
            Die()
            Exit Sub
        End If
        'If inventory(8).count > 0 Then
        '    inventory(8).count = 0
        '    Game.pushLblEvent("The chicken suit phases out of reality")
        'End If
        If Game.lblNameTitle.Text <> name & " the " & pClass.name Then Game.lblNameTitle.Text = name & " the " & pClass.name
        If Game.lblHealth.Text <> "Health = " & CInt(health * getmaxHealth()) & "/" & getmaxHealth() Then Game.lblHealth.Text = "Health = " & CInt(health * getmaxHealth()) & "/" & getmaxHealth()
        If Game.lblMana.Text <> "Mana = " & mana & "/" & getmaxMana() Then Game.lblMana.Text = "Mana = " & mana & "/" & getmaxMana()
        If Game.lblHunger.Text <> "Hunger = " & hunger & "/100" Then Game.lblHunger.Text = "Hunger = " & hunger & "/100"
        If Game.lblATK.Text <> "ATK = " & (getAttack()) + equippedWeapon.aBoost Then Game.lblATK.Text = "ATK = " & (getAttack()) + equippedWeapon.aBoost
        If Game.lblDEF.Text <> "DEF = " & getDefence() Then Game.lblDEF.Text = "DEF = " & getDefence()
        If Game.lblSKL.Text <> "WIL = " & getWillpower() Then Game.lblSKL.Text = "WIL = " & getWillpower()
        If Game.lblSPD.Text <> "SPD = " & getSpeed() Then Game.lblSPD.Text = "SPD = " & getSpeed()
        'If Game.lblEVD.Text <> "EVD = " & evade Then Game.lblEVD.Text = "EVD = " & evade
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
            Array.Sort(potions)
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
        If Game.invFilters(6) Then
            tArr(ct) = "-ACCESSORIES:"
            ct += 1
            For i = 0 To UBound(acce)
                If acce(i).getCount > 0 Then
                    tArr(ct) = " " & acce(i).getName() & " x" & acce(i).count
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
        If Not Game.picPortrait.BackgroundImage Is Nothing Then Game.picPortrait.BackgroundImage.Dispose()

        Dim chk = False

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
        If hornInd > 0 Then addHorns(hornInd)

        If Not solFlag And Not chk Then Game.picPortrait.BackgroundImage = CharacterGenerator.CreateBMP(iArr)
        oneLayerImgCheck(chk)
        Game.picPortrait.Update()

        currState.save(Me)
        Game.lblEvent.ForeColor = TextColor
        Game.lblNameTitle.ForeColor = TextColor
    End Sub
    Public Sub MtF()
        If perks("polymorphed") > -1 Or pClass.name.Equals("Magic Girl") Then
            Game.lstLog.Items.Add("Your form prevents you from being altered.")
            Exit Sub
        End If
        sexBool = True
        sex = "Female"
        breastSize = 1
        idRouteMF()
        changeSkinColor(skincolor)
        If perks("swordpossess") > -1 Then perks("swordpossess") = 0
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Public Sub FtM()
        If perks("polymorphed") > -1 Or pClass.name.Equals("Magic Girl") Then
            Game.lstLog.Items.Add("Your form prevents you from being altered.")
            Exit Sub
        End If
        sexBool = False
        sex = "Male"
        breastSize = -1
        perks(2) = False
        idRouteFM()
        If perks("swordpossess") > -1 Then perks("swordpossess") = 0
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Public Sub be()
        If Not Polymorph.canBeTFed(Me) Then
            Game.lstLog.Items.Add("Your form prevents you from being altered.")
            Exit Sub
        End If
        If breastSize >= -1 And breastSize < 8 Then
            breastSize += 1
            Select Case breastSize
                Case -1
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(0, False)
                Case 0
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(2, False)
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
                Case 6
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(17, True)
                Case 7
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(19, True)
            End Select
            Game.lstLog.Items.Add("+ 1 cup size!")
            If iArrInd(3).Item2 = False Then iArrInd(3) = New Tuple(Of Integer, Boolean)(iArrInd(3).Item1, True)
        End If
        bsizeroute()
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Friend Sub bs()
        If Not Polymorph.canBeTFed(Me) Then
            Game.lstLog.Items.Add("Your form prevents you from being altered.")
            Exit Sub
        End If
        If breastSize > -1 And breastSize <= 6 Then
            breastSize -= 1
            Select Case breastSize
                Case -1
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(0, False)
                Case 0
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(2, False)
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
                Case 6
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(17, True)
                Case 7
                    iArrInd(2) = New Tuple(Of Integer, Boolean)(19, True)
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
        ElseIf ((iArrInd(2).Item1 = 2 And iArrInd(2).Item2) Or iArr(2).Equals(CharacterGenerator.fTFBody(10))) Or iArrInd(2).Item1 = 7 And breastSize <> 3 Then
            breastSize = 3
        ElseIf iArrInd(2).Item1 = 3 Or iArrInd(2).Item1 = 8 And breastSize <> 4 Then
            breastSize = 4
        ElseIf iArrInd(2).Item1 = 4 Or iArrInd(2).Item1 = 9 And breastSize <> 5 Then
            breastSize = 5
        ElseIf iArrInd(2).Item1 = 17 Or iArrInd(2).Item1 = 18 And breastSize <> 6 Then
            breastSize = 6
        ElseIf iArrInd(2).Item1 = 19 Or iArrInd(2).Item1 = 20 And breastSize <> 7 Then
            breastSize = 7
        ElseIf iArrInd(2).Item1 = 2 And Not iArrInd(2).Item2 And breastSize <> 0 Then
            breastSize = 0
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
            Case 5
                iArrInd(9) = New Tuple(Of Integer, Boolean)(11, True)
            Case 6
                iArrInd(9) = New Tuple(Of Integer, Boolean)(14, True)
            Case 7
                iArrInd(9) = New Tuple(Of Integer, Boolean)(15, True)
            Case 8
                iArrInd(9) = New Tuple(Of Integer, Boolean)(19, True)
            Case Else
                iArrInd(9) = New Tuple(Of Integer, Boolean)(iArrInd(9).Item1, True)
        End Select
        'eyebrows
        Select Case iArrInd(10).Item1
            Case Else
                iArrInd(10) = New Tuple(Of Integer, Boolean)(iArrInd(10).Item1, True)
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
            Case 11
                iArrInd(9) = New Tuple(Of Integer, Boolean)(5, False)
            Case 14
                iArrInd(9) = New Tuple(Of Integer, Boolean)(6, False)
            Case 15
                iArrInd(9) = New Tuple(Of Integer, Boolean)(7, False)
            Case 19
                iArrInd(9) = New Tuple(Of Integer, Boolean)(8, False)
            Case Else
                If iArrInd(9).Item1 < 5 Then iArrInd(9) = New Tuple(Of Integer, Boolean)(iArrInd(9).Item1, False)
        End Select
        'eyebrows
        Select Case iArrInd(10).Item1
            Case Else
                iArrInd(10) = New Tuple(Of Integer, Boolean)(iArrInd(10).Item1, False)
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
                Dim temp As Integer = iArrInd(1).Item1 - 5
                If temp >= CharacterGenerator.getImg("img/fTF/tfRearHair2").Count Then temp = CharacterGenerator.getImg("img/fTF/tfRearHair2").Count - 1
                t(1) = CharacterGenerator.getImg("img/fTF/tfRearHair2")(temp)
            End If
            If iArrInd(5).Item1 < 5 Then
                t(5) = CharacterGenerator.getImg("img/fRearHair1")(iArrInd(5).Item1)
            Else
                Dim temp As Integer = iArrInd(5).Item1 - 5
                If temp >= CharacterGenerator.getImg("img/fTF/tfRearHair1").Count Then temp = CharacterGenerator.getImg("img/fTF/tfRearHair1").Count - 1
                t(5) = CharacterGenerator.getImg("img/fTF/tfRearHair1")(temp)
            End If
            If iArrInd(15).Item1 < 6 Then
                t(15) = CharacterGenerator.getImg("img/fFrontHair")(iArrInd(15).Item1)
            Else
                Dim temp As Integer = iArrInd(15).Item1 - 6
                If temp >= CharacterGenerator.getImg("img/fTF/tfFrontHair").Count Then temp = CharacterGenerator.getImg("img/fTF/tfFrontHair").Count - 1
                t(15) = CharacterGenerator.getImg("img/fTF/tfFrontHair")(temp)
            End If
            CharacterGenerator.fFrontHair(0) = CharacterGenerator.picPort.Image
        Else
            If iArrInd(1).Item1 < 5 Then
                t(1) = CharacterGenerator.getImg("img/mRearHair2")(iArrInd(1).Item1)
            Else
                Dim temp As Integer = iArrInd(1).Item1 - 5
                If temp >= CharacterGenerator.getImg("img/mTF/tfRearHair2").Count Then temp = CharacterGenerator.getImg("img/mTF/tfRearHair2").Count - 1
                t(1) = CharacterGenerator.getImg("img/mTF/tfRearHair2")(temp)
            End If
            If iArrInd(5).Item1 < 5 Then
                t(5) = CharacterGenerator.getImg("img/mRearHair1")(iArrInd(5).Item1)
            Else
                Dim temp As Integer = iArrInd(5).Item1 - 5
                If temp >= CharacterGenerator.getImg("img/mTF/tfRearHair1").Count Then temp = CharacterGenerator.getImg("img/mTF/tfRearHair1").Count - 1
                t(5) = CharacterGenerator.getImg("img/mTF/tfRearHair1")(temp)
            End If
            If iArrInd(15).Item1 < 6 Then
                t(15) = CharacterGenerator.getImg("img/mFrontHair")(iArrInd(15).Item1)
            Else
                Dim temp As Integer = iArrInd(15).Item1 - 6
                If temp >= CharacterGenerator.getImg("img/mTF/tfFrontHair").Count Then temp = CharacterGenerator.getImg("img/mTF/tfFrontHair").Count - 1
                t(15) = CharacterGenerator.getImg("img/mTF/tfFrontHair")(temp)
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
            ElseIf iArrInd(6).Item1 = 6 Or iArrInd(6).Item1 = 7 Then
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
    Sub addHorns(ByVal i As Integer)
        iArr(6) = CharacterGenerator.CreateBMP({CharacterGenerator.horns(i), iArr(6)})
    End Sub
    Public Sub petrify(ByVal c As Color)
        If pForm.name.Equals("Dragon") Then revert2()
        changeHairColor(c)
        If sexBool Then
            iArrInd(8) = New Tuple(Of Integer, Boolean)(10, True)
            iArrInd(9) = New Tuple(Of Integer, Boolean)(14, True)
        Else
            iArrInd(8) = New Tuple(Of Integer, Boolean)(5, False)
            iArrInd(9) = New Tuple(Of Integer, Boolean)(7, False)
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
            Dim out As String = "As you reach out to touch your opponent, you clumsily swipe, missing them, and hit...yourself?  Already your legs are gold, and only have a moment to scream, your vocal cords quickly following suit. ""Well,"" you think, ""...at least I won't have to worry abou money anymore."" " & vbCrLf & "And like that, the dungeon gains another decoration."
            Game.pushLblEvent(out)
            MsgBox(out)
            Die()
        End If
    End Sub

    'getter for buffable stats
    Function getmaxHealth()
        Return CInt((maxHealth + hBuff + equippedArmor.hBoost + equippedAcce.hBoost) * pClass.h * pForm.h)
    End Function
    Function getmaxMana()
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Then Return CInt(maxMana * pForm.m * pForm.m) + mBuff
        Return CInt((maxMana + mBuff + equippedArmor.mBoost + equippedWeapon.mBoost + equippedAcce.mBoost) * pForm.m * pForm.m)
    End Function
    Function getAttack()
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Then Return CInt(attack * pForm.a * pClass.a) + aBuff
        Return CInt((attack + aBuff + equippedArmor.aBoost + equippedAcce.aBoost) * pForm.a * pClass.a)
    End Function
    Function getDefence()
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Then Return CInt(defence * pClass.d * pForm.d) + dBuff
        Return CInt((defence + dBuff + equippedArmor.dBoost + equippedAcce.dBoost) * pClass.d * pForm.d)
    End Function
    Function getSpeed()
        If equippedArmor Is Nothing Or equippedWeapon Is Nothing Then Return CInt(speed * pClass.s * pForm.s) + sBuff
        Return CInt((speed + sBuff + equippedArmor.sBoost + equippedAcce.sBoost) * pClass.s * pForm.s)
    End Function
    Function getWillpower()
        Return CInt(will * pClass.w * pForm.w) + wBuff
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
    Function getAccesories() As Tuple(Of String(), Accessory())
        Dim s(UBound(acce)) As String
        For i = 0 To UBound(acce)
            s(i) = acce(i).getName
        Next
        Return New Tuple(Of String(), Accessory())(s, acce)
    End Function

    'toString
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

        output += inventory.Count - 1 & "*"
        For i = 0 To inventory.Count - 1
            output += (inventory.Item(i).count & "*")
        Next

        If forcedPath Is Nothing Then
            output += "N/a*"
        Else
            output += UBound(forcedPath) & "*"
            For i = 0 To UBound(forcedPath)
                output += (forcedPath(i).X & "*")
                output += (forcedPath(i).Y & "*")
            Next
        End If

        If Not prefForm Is Nothing Then
            output += prefForm.ToString & "$"
        Else
            output += "N/a$"
        End If
        output += inventory(69).ToString

        Return output
    End Function
    Public Function toGhost() As String
        Dim output = CStr(name & " the " & pForm.name & " " & pClass.name & "*" & health & "*" & maxHealth &
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
            Case "Blob"
            Case "Chicken"
            Case "Frog"
            Case "Sheep"
            Case "Bunny"
        End Select
        Select Case pClass.name
            Case "Magic Girl​"
                out += "You are currently in the middle of a magical girl transformation!"
                Return out
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

                    out += "Your hips have womanly curves without being overly wide.  Overall, you have typical legs and feet for a humanoid woman."
                Else
                    If iArrInd(2).Item2 Then
                        out += "You have a feminine body, with " & bAdj & " breasts, though you have male genetalia." & vbCrLf & " " & vbCrLf
                    Else
                        out += "You have a masculine body, with a toned chest and the matching male genetalia." & vbCrLf & " " & vbCrLf
                    End If
                End If
        End Select

        'perks
        If perks("hunger") > -1 Then out += "You haven't eaten anything in a while and are starving." & vbCrLf & " " & vbCrLf
        If perks("slutcurse") > -1 Then out += "You choose to dress very provocatively, showing as much skin as possible due to a curse."
        If perks("polymorphed") > -1 Then out += "You are under the effects of a temporary polymorph, and will be for " & perks("polymorphed") & " more turns." & vbCrLf & " " & vbCrLf
        Return out
    End Function
End Class
