Public Class OutOfTime
    Inherits Quest

    Public playerHasContraband As Boolean = False

    Sub New()
        MyBase.New("Out of Time")

        quest_index = qInd.outOfTime

        objectives.Add(New OutOfTimeS1)
        objectives.Add(New OutOfTimeS2)
        objectives.Add(New OutOfTimeS3)
    End Sub

    Public Overrides Sub init()
        MyBase.init()

        TextEvent.push("As you walk along, a familiar glowing portal twists into being before you." & DDUtils.RNRN &
                       "This time, though, the portal doesn't pull you in.  Instead, a woman wearing goggles steps out of it and glances around until she locks eyes with you.", AddressOf initStep2)
    End Sub
    Private Sub initStep2()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(39), """HELLO, DENIZEN OF THE PAST!"" she says, striking a dramatic pose." & DDUtils.RNRN &
                                                             """You haven't exactly been keeping to your timeline, huh?""", AddressOf initStep3)
    End Sub
    Private Sub initStep3()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(43), """Our logs clearly show you were traipsing around in your far-off future, and that's a pretty serious offence.  We're not 100% sure what you're up to, but someone from this time period jumping around like that...""" & DDUtils.RNRN &
                                                             "She pauses, gently tapping her finger against her cheek." & DDUtils.RNRN &
                                                             """Figuring that out isn't my job, though.  You're coming with me back to HQ, alright?  No funny business, if you'd be so kind.""", AddressOf initStep4)
    End Sub
    Private Sub initStep4()
        TextEvent.pushYesNo("Go along?", AddressOf cooperate, AddressOf resist)
    End Sub
    Public Shared Sub hostileArrest()
        Game.quickChangeFloor(10000)

        Dim c1 As Chest = DDConst.BASE_CHEST.Create(Game.player1.inv, New Point(58, 10))
        Game.currFloor.chestList.Add(c1)
        Game.currFloor.mBoard(10, 58).Tag = DDConst.TILE_SEEN
        Game.currFloor.mBoard(10, 58).ForeColor = Color.FromArgb(45, 45, 45)
        Game.currFloor.mBoard(10, 58).Text = "#"

        Game.currFloor.mBoard(33, 61).Tag = DDConst.TILE_WALL
        Game.currFloor.mBoard(33, 61).Text = "|"

        CType(Game.player1.quests(qInd.outOfTime), OutOfTime).playerHasContraband = hasContraband(Game.player1)
        Game.player1.inv = New Inventory(True)
        EquipmentDialogBackend.armorChange(Game.player1, "Naked")
        EquipmentDialogBackend.weaponChange(Game.player1, "Fists")
        Equipment.accChange(Game.player1, "Nothing")

        Game.player1.update()
        Game.drawBoard()

        TextEvent.push("As she picks up your frozen body, the time traveler opens another portal through the future and hops through.  You find yourself in a small holding cell, and she props you against the wall before exiting through an empty doorway with your bag and gear." & DDUtils.RNRN &
                       """Don't go anywhere, okay?"" she snickers, slapping a button and activating a shimmering blue energy barrier between the two of you.", AddressOf defrost)
    End Sub
    Protected Shared Function hasContraband(ByRef p As Player) As Boolean
        For Each itm In LootTable.getSpaceChest1Contents
            If p.inv.getCountAt(itm) > 0 Then
                Return True
            End If
        Next

        For Each itm In LootTable.getSpaceChest2Contents
            If p.inv.getCountAt(itm) > 0 Then
                Return True
            End If
        Next

        For Each itm In LootTable.getSpaceChest3Contents
            If p.inv.getCountAt(itm) > 0 Then
                Return True
            End If
        Next

        For Each itm In LootTable.getSpaceChest4Contents
            If p.inv.getCountAt(itm) > 0 Then
                Return True
            End If
        Next

        Return False
    End Function
    Private Shared Sub defrost()
        Game.player1.perks(perk.astatue) = -1
        Game.player1.revertToPState()
        TextEvent.push("After an indeterminate amount of time, feeling returns to you fingers, and you spend the next hour slowly regaining your mobility as you thaw.")
    End Sub
    Private Sub cooperate()
        Game.quickChangeFloor(10000)

        CType(Game.player1.quests(qInd.outOfTime), OutOfTime).playerHasContraband = hasContraband(Game.player1)

        Game.currFloor.mBoard(33, 61).Tag = 0
        Game.currFloor.mBoard(33, 61).Text = "|"

        Game.player1.update()
        Game.drawBoard()

        TextEvent.push("The time traveler opens another portal through the future and, grabbing your hand, hops through.  You find yourself in a small holding cell, and she gives you a few moments to take in your surroundings before exiting through an empty doorway." & DDUtils.RNRN &
                       """Since you've been pretty well behaved so far, I'm gonna let you keep your stuff.  Again: don't try anything, okay?"" she says, slapping a button and activating a shimmering blue energy barrier between the two of you.")
    End Sub
    Private Sub resist()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(43), """That sucks to hear, but I said you're coming with me." & DDUtils.RNRN &
                                                             "If you're going to resist, I guess that's just how it's gonna be.""", AddressOf fightTT)
    End Sub
    Private Sub fightTT()
        Dim m As TimeTravellerFight = New TimeTravellerFight()

        Game.challengeBoss(m)
    End Sub
    Public Shared Function canBreakWalls(ByRef p As Player) As Boolean
        Return Not (p.ongoingQuests.contains("Out of Time") And Game.currFloor.floorNumber = 10000)
    End Function
    Public Overrides Function canGet() As Boolean
        Dim r = Int(Rnd() * 500)
        'MsgBox((Not getActive()) & " " & (Game.mDun.floors.ContainsKey(9999)) & " " & (Not getComplete()) & " " & ((r = 0) Or Settings.active(setting.norng)))
        Return Not getActive() AndAlso Game.mDun.floors.ContainsKey(9999) AndAlso Not getComplete() AndAlso ((r = 0) Or Settings.active(setting.norng))
    End Function
End Class

Friend Class OutOfTimeS1
    Inherits Objective

    Sub New()
        MyBase.New("Leave your cell.")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()

        If Game.player1.equippedArmor.getName.Equals("Naked") Then
            Game.player1.inv.add("Space_Age_Jumpsuit", 1)
            EquipmentDialogBackend.armorChange(Game.player1, "Space_Age_Jumpsuit")
            Game.player1.drawPort()
        End If

        TextEvent.push("An unknown amount of time passes..." & DDUtils.RNRN &
                       "As you wake up one morning, the now familiar hum of the shimmering barrier keeping you isolated from the rest of the faciitly seems to have faded out of your concious senses, and...." & DDUtils.RNRN &
                       "Wait..." & DDUtils.RNRN &
                       "Bolting up, you notice that the doorway is now clear!", AddressOf completeS2)
    End Sub

    Private Sub completeS2()
        Game.currFloor.mBoard(33, 61).Tag = DDConst.TILE_SEEN
        Game.currFloor.mBoard(33, 61).Text = ""

        Game.drawBoard()
    End Sub

    Public Overrides Function getDesc() As String
        Return description
    End Function

    Public Overrides Function isComplete() As Boolean
        Return Game.player1.pos.X = 60 And Game.player1.pos.Y = 33
    End Function
End Class

Friend Class OutOfTimeS2
    Inherits Objective

    Sub New()
        MyBase.New("Find a way out.")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()

        TextEvent.push("A slightly garbled voice coughs before speaking from a strange box on the ceiling." & DDUtils.RNRN &
                       """Prisoner 5, report to conference room A.""" & DDUtils.RNRN &
                       "You look around to see if there are any other prisoners around, and the voice sighs." & DDUtils.RNRN &
                       """PRISONER 5!  YES!  YOU IN THE HALLWAY!  Head up to the junction and then it's the first door on the left.  This is EXACTLY why I've been saying we should paint some arrows and get a drone and-""" & DDUtils.RNRN &
                       "The voice trails off into annoyed mumbling before cutting off abruptly.")
        Game.currFloor.mBoard(18, 58).Text = "G"
    End Sub

    Public Overrides Function getDesc() As String
        Return description
    End Function

    Public Overrides Function isComplete() As Boolean
        Return Game.player1.pos.Y < 32
    End Function
End Class

Friend Class OutOfTimeS3
    Inherits Objective
    Dim idk1 As Boolean = False
    Dim idk2 As Boolean = False

    Sub New()
        MyBase.New("Plead your case.")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()

        TextEvent.push("You approach the desk of a thickly bearded man." & DDUtils.RNRN &
                       "He seems to be reading through a pile of parchment, and gives you a brief glance before folding up an impressively uniform page.", AddressOf timeJudgeIntroduce)
    End Sub
    Protected Sub timeJudgeIntroduce()
        showNPC(ShopNPC.gbl_img.atrs(0).getAt(83), """*Ahem*- Hello.""" & DDUtils.RNRN &
                                                   "He looks up at you, gesturing to another chair besides you." & DDUtils.RNRN &
                                                   """I will be the Chrono-Arbiter handling your case.  Let's make this quick; the events as I understand them seem straightforward enough." & DDUtils.RNRN &
                                                   "I am going to ask you a set of questions, keep your answers consise and honest.""", AddressOf q1)
    End Sub

    '| - Question 1 - |
    Public Sub q1()
        showNPC(ShopNPC.gbl_img.atrs(0).getAt(83), """First:" & DDUtils.RNRN &
                                                   "Did you travel from your home timeline into what- to you- would be the far distant future?""" & DDUtils.PAKTC, AddressOf q1ask)
    End Sub
    Public Sub q1ask()
        Dim options As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))()
        options.Add(New Tuple(Of String, Action)("Yes.", AddressOf q1yes))
        options.Add(New Tuple(Of String, Action)("No.", AddressOf q1no))
        'options.Add(New Tuple(Of String, Action)("Yes, that's how I'm here now.", AddressOf q1yes))
        options.Add(New Tuple(Of String, Action)("I don't know.", AddressOf q1idk))

        TextEvent.pushManySelect("Did you go to the future?", options)
    End Sub
    Public Sub q1no()
        If hasContraband(Game.player1) Then
            showNPC(ShopNPC.gbl_img.atrs(0).getAt(84), """Interesting... and yet, during your arrest, it was found that you had items on your person from a time beyond your own." & DDUtils.RNRN &
                                                       "Where did those come from, if not the time travel clearly indicated by our logs?""" & DDUtils.PAKTC, AddressOf q1noq2)
        Else
            showNPC(ShopNPC.gbl_img.atrs(0).getAt(84), """Interesting... hmmm..." & DDUtils.RNRN &
                                                       "...and yet, during your arrest, it was found that you had items on your person from a time beyond your own." & DDUtils.RNRN &
                                                       "Where did those come from, if not the time travel clearly indicated by our logs?""" & DDUtils.PAKTC, AddressOf q1noq2)
        End If
    End Sub
    Protected Function hasContraband(ByRef p As Player) As Boolean
        Return CType(Game.player1.quests(qInd.outOfTime), OutOfTime).playerHasContraband
    End Function
    Public Sub q1yes()
        showNPC(ShopNPC.gbl_img.atrs(0).getAt(83), """That matches our records.  Do you plan on travelling through time again?""" & DDUtils.PAKTC, AddressOf q1yesq2)
    End Sub
    Public Sub q1idk()
        idk1 = True
        showNPC(ShopNPC.gbl_img.atrs(0).getAt(84), """Mmmm.  Do you plan on travelling through time again?""" & DDUtils.PAKTC, AddressOf q1yesq2)
    End Sub

    '| - Question 2A - |
    Public Sub q1noq2()
        Dim options As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))()
        options.Add(New Tuple(Of String, Action)("Went to the Future.", AddressOf q1noq2yes))
        options.Add(New Tuple(Of String, Action)("Didn't have anything like that.", AddressOf q1noq2no))
        options.Add(New Tuple(Of String, Action)("Don't recall.", AddressOf q1noq2idk))

        TextEvent.pushManySelect("Where did you get your contraband?", options)
    End Sub
    Public Sub q1noq2yes()
        showNPC(ShopNPC.gbl_img.atrs(0).getAt(84), """So- to be clear- you DID travel through time.  That is forbidden, understand?  You can't just- *sigh*" & DDUtils.RNRN &
                                                   "Moving on.  Do you plan to leave your home timeline ever again?""" & DDUtils.PAKTC, AddressOf q1yesq2)
    End Sub
    Public Sub q1noq2no()
        If hasContraband(Game.player1) Then
            showNPC(ShopNPC.gbl_img.atrs(0).getAt(84), """You've proven yourself to be a liar, and worse yet- a scoundrel.  For trespassing through time and for concealing the items you have displaced, you will be contained here for all eternity.""" & DDUtils.RNRN &
                                                       "The arbiter gestures with his hand, and two guards enter the room." & DDUtils.RNRN &
                                                       """Return to your cell, if you wouldn't mind.""", AddressOf returnToCell)
        Else
            showNPC(ShopNPC.gbl_img.atrs(0).getAt(83), """Oh- mmm.  It appears that I was looking at the wrong file.  My apologies, " & If(Game.player1.sex.Equals("Male"), "sir", If(Game.player1.sex.Equals("Female"), "ma'am", "past-dweller")) & "..." & DDUtils.RNRN &
                                                       "Our logs do still indicate that you traveled through time, but other than that..." & DDUtils.RNRN &
                                                       "Hmm... how puzzling...""" & DDUtils.PAKTC, AddressOf cleanup)
        End If
    End Sub
    Public Sub q1noq2idk()
        If hasContraband(Game.player1) Then
            showNPC(ShopNPC.gbl_img.atrs(0).getAt(84), """You've proven yourself to be a liar, and worse yet- a scoundrel.  For trespassing through time and for concealing the items you ""may"" have displaced, you will be contained here for all eternity.""" & DDUtils.RNRN &
                                                       "The arbiter gestures with his hand, and two guards enter the room." & DDUtils.RNRN &
                                                       """Return to your cell, if you wouldn't mind.""", AddressOf returnToCell)
        Else
            showNPC(ShopNPC.gbl_img.atrs(0).getAt(83), """But you did still have- mmm.  I stand corrected, seems that I am looking at the wrong file.  My apologies, " & If(Game.player1.sex.Equals("Male"), "sir", If(Game.player1.sex.Equals("Female"), "ma'am", "past-dweller")) & "..." & DDUtils.RNRN &
                                                       "Our logs do still indicate that you traveled through time, but other than that..." & DDUtils.RNRN &
                                                       "Hmm... how puzzling...""" & DDUtils.PAKTC, AddressOf cleanup)
        End If
    End Sub

    '| - Question 2B - |
    Public Sub q1yesq2()
        Dim options As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))()
        options.Add(New Tuple(Of String, Action)("Yes.", AddressOf q1yesq2yes))
        options.Add(New Tuple(Of String, Action)("No.", AddressOf q1yesq2no))
        options.Add(New Tuple(Of String, Action)("I'm not sure.", Sub() q1yesq2yesq3yes(True)))

        TextEvent.pushManySelect("Do you plan time travel again?", options)
    End Sub
    Public Sub q1yesq2yes()
        showNPC(ShopNPC.gbl_img.atrs(0).getAt(84), """Well... You can't.  Time travel is forbidden.  Do you understand?""" & DDUtils.PAKTC, AddressOf q1yesq2yesq3)
    End Sub
    Public Sub q1yesq2no()
        showNPC(ShopNPC.gbl_img.atrs(0).getAt(83), """Good.  For your prior actions you will be fined 20,000 credits, which adds up to 500 of your gold coins.  Once you've paid, you are free to go.""" & DDUtils.PAKTC, AddressOf fine2)
    End Sub
    Public Sub q1yesq2yesq3()
        TextEvent.pushYesNo("Answer Politely?", AddressOf q1yesq2yesq3yes, AddressOf q1yesq2yesq3no)
    End Sub
    Public Sub q1yesq2yesq3yes(Optional ByVal idk As Boolean = False)
        If idk Then idk2 = True
        showNPC(ShopNPC.gbl_img.atrs(0).getAt(83), """Do.  Not.  Do.  This.  Again." & DDUtils.RNRN &
                                                  "For your prior actions you will be fined 40,000 credits which adds up to 1,000 of your gold coins.  If we catch you outside of your home timeline again, there will be repercussions...""" & DDUtils.PAKTC, AddressOf fine1)
    End Sub
    Public Sub q1yesq2yesq3no()
        showNPC(ShopNPC.gbl_img.atrs(0).getAt(84), """I'm not just going to sit here and take this.  Have at you!""" & DDUtils.PAKTC, AddressOf tjFight)
    End Sub

    '|-- Ends -- |
    Public Sub returnToCell()
        TextEvent.pushYesNo("Return to your cell?", AddressOf returnToCellP2, AddressOf alert)
    End Sub
    Public Sub returnToCellP2()
        TextEvent.push("You return to your cell, and then spend the next eternity as a temporal prisoner." & DDUtils.RNRN &
                       "Is this how you saw your journey ending?" & DDUtils.RNRN &
                       "Game Over!", AddressOf Game.player1.die)
        Game.compOOT = True
    End Sub

    '| - Fines - |
    Public Sub fine1()
        Dim options As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))()
        options.Add(New Tuple(Of String, Action)("Yes", AddressOf payFine1))
        options.Add(New Tuple(Of String, Action)("No", AddressOf tjFight))
        If idk1 And idk2 Then options.Add(New Tuple(Of String, Action)("Couldn't say.", AddressOf tjFight))

        TextEvent.pushManySelect("Pay your fine?", options)
    End Sub
    Public Sub payFine1()
        If Game.player1.getGold < 1000 Then
            Game.player1.perks(perk.owetimebalance) = 1000 - Game.player1.gold
            showNPC(ShopNPC.gbl_img.atrs(0).getAt(84), """*sigh* I suppose it would be too much to ask that you have the proper payment.  Fine, we'll just need to make up the balance later." & DDUtils.RNRN &
                                                       "Now, leave.  The door to the portal to your home timeline is the last one on the left." & DDUtils.RNRN &
                                                       "Do not touch anything else on your way out.""" & DDUtils.PAKTC)
            Game.player1.gold = 0
        Else
            showNPC(ShopNPC.gbl_img.atrs(0).getAt(83), """The door to the portal to your home timeline is the last one on the left." & DDUtils.RNRN &
                                                       "Do not touch anything else on your way out.""" & DDUtils.PAKTC)
            Game.player1.gold -= 1000
        End If

        Game.currFloor.mBoard(5, 49).Tag = DDConst.TILE_SEEN
        Game.currFloor.mBoard(5, 49).Text = ""
        Game.currFloor.mBoard(5, 72).Tag = DDConst.TILE_SEEN
        Game.currFloor.mBoard(5, 72).Text = ""

        Game.compOOT = True

        Game.player1.update()
        Game.drawBoard()
    End Sub
    Public Sub fine2()
        Dim options As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))()
        options.Add(New Tuple(Of String, Action)("Yes", AddressOf payFine2))
        options.Add(New Tuple(Of String, Action)("No", AddressOf alert))
        If idk1 And idk2 Then options.Add(New Tuple(Of String, Action)("Couldn't say.", AddressOf tjFight))

        TextEvent.pushManySelect("Pay your fine?", options)
    End Sub
    Public Sub payFine2()
        If Game.player1.getGold < 500 Then
            Game.player1.perks(perk.owetimebalance) = 500 - Game.player1.gold
            showNPC(ShopNPC.gbl_img.atrs(0).getAt(84), """You'll need to make up the remaining balance later." & DDUtils.RNRN &
                                                       "Now, leave.  The door to the portal to your home timeline is the last one on the left." & DDUtils.RNRN &
                                                       "Do not touch anything else on your way out.""" & DDUtils.PAKTC)
            Game.player1.gold = 0
        Else
            showNPC(ShopNPC.gbl_img.atrs(0).getAt(83), """The door to the portal to your home timeline is the last one on the left." & DDUtils.RNRN &
                                                       "Do not touch anything else on your way out.""" & DDUtils.PAKTC)
            Game.player1.gold -= 500
        End If

        Game.currFloor.mBoard(5, 49).Tag = DDConst.TILE_SEEN
        Game.currFloor.mBoard(5, 49).Text = ""
        Game.currFloor.mBoard(5, 72).Tag = DDConst.TILE_SEEN
        Game.currFloor.mBoard(5, 72).Text = ""

        Game.compOOT = True

        Game.player1.update()
        Game.drawBoard()
    End Sub

    '| - Fights - |
    Public Sub tjFight()
        Dim m As TimeJudgeFight = New TimeJudgeFight()
        alert(False)

        Game.challengeBoss(m)
    End Sub
    Public Shared Sub alert(Optional seeJudge As Boolean = True)
        TextEvent.pushAndLog("A blaring alarm sounds" & If(seeJudge, ", and the judge vanishes in a column of light", "") & "!")
        Game.currFloor.mBoard(18, 58).Text = ""
        Game.compOOT = True
        Game.player1.perks(perk.enemyoftime) = 1

        If Not Game.player1.quests(qInd.outOfTime).getComplete Then Game.player1.quests(qInd.outOfTime).completeEntireQuest()
    End Sub

    Public Sub cleanup()
        TextEvent.push("""We will need to review our logs further to confirm their validity.  Please feel free to roam the facilities in the meantime, we should have a verdict in- say...""" & DDUtils.RNRN &
                       "The arbiter strokes his beard pensively, his expression inscrutible behind his visor." & DDUtils.RNRN &
                       """4 cycles.  I've disengaged the security barriers between here an our breakroom, please wait there for now.  Do NOT return to your timeline using our paradox-console; you need to stay put for the entire 4 cycles so we can resume this investigation at that time.""" & DDUtils.RNRN &
                       "With that warning, the arbiter says his farewells and vanishes in a column of light.")
        Game.currFloor.mBoard(18, 58).Text = ""
        Game.compOOT = True

        'Warp Area
        Game.currFloor.mBoard(5, 43).Tag = DDConst.TILE_SEEN
        Game.currFloor.mBoard(5, 43).Text = ""
        'Contraband Locker
        Game.currFloor.mBoard(10, 60).Tag = DDConst.TILE_SEEN
        Game.currFloor.mBoard(10, 60).Text = ""
        'Disengage Button
        Game.currFloor.mBoard(14, 60).Tag = DDConst.TILE_WALL
        Game.currFloor.mBoard(14, 60).Text = "|"
        'Staff Area
        Game.currFloor.mBoard(17, 17).Tag = DDConst.TILE_SEEN
        Game.currFloor.mBoard(17, 17).Text = ""
        'Interchange
        Game.currFloor.mBoard(22, 72).Tag = DDConst.TILE_SEEN
        Game.currFloor.mBoard(22, 72).Text = ""
        Game.currFloor.mBoard(23, 72).Tag = DDConst.TILE_SEEN
        Game.currFloor.mBoard(23, 72).Text = ""
        Game.currFloor.mBoard(24, 72).Tag = DDConst.TILE_SEEN
        Game.currFloor.mBoard(24, 72).Text = ""
        Game.currFloor.mBoard(25, 72).Tag = DDConst.TILE_SEEN
        Game.currFloor.mBoard(25, 72).Text = ""
    End Sub

    Public Overrides Function getDesc() As String
        Return description
    End Function

    Public Overrides Function isComplete() As Boolean
        Return (Game.player1.pos.Y = 18 And Game.player1.pos.X = 59)
    End Function
End Class

