Public Class OutOfTime
    Inherits Quest

    Sub New()
        MyBase.New("Out of Time")

        qInd = qInds.outOfTime

        objectives.Add(New OutOfTimeS1)
        objectives.Add(New OutOfTimeS2)
        objectives.Add(New OutOfTimeS3)
    End Sub

    Public Overrides Sub init()
        MyBase.init()

        TextEvent.push("As you are walking along, another glowing rift in space and time opens in front of you." & DDUtils.RNRN &
                          "To your suprise, a woman in goggles steps out of it and glances around before locking eyes with you, grinning, and striking a dramatic pose.", AddressOf initStep2)
    End Sub
    Private Sub initStep2()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(39), "HELLO, DENIZEN OF THE PAST!  You haven't exactly been keeping to your timeline, now have you?", AddressOf initStep3)
    End Sub
    Private Sub initStep3()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(43), "Our logs clearly show you were traipsing around in the far-off future, and that's a pretty severe infraction." & DDUtils.RNRN &
                          "Lucky for you, it doesn't look like you're up to anything, and this is a first time offense so you're probably just gonna get a slap on the wrist." & DDUtils.RNRN &
                          "Of course, that all depends on how cooprative you are through the arrest process.  I'm not gonna need to beat you up, right?", AddressOf initStep4)
    End Sub
    Private Sub initStep4()
        TextEvent.pushYesNo("Cooperate?", AddressOf cooperate, AddressOf resist)
    End Sub
    Public Shared Sub hostileArrest()
        Game.quickChangeFloor(10000)

        Dim c1 As Chest = DDConst.BASE_CHEST.Create(Game.player1.inv, New Point(28, 10))
        Game.currFloor.chestList.Add(c1)
        Game.currFloor.mBoard(10, 28).ForeColor = Color.FromArgb(45, 45, 45)
        Game.currFloor.mBoard(10, 28).Text = "#"

        Game.currFloor.mBoard(33, 61).Tag = 0
        Game.currFloor.mBoard(33, 61).Text = "|"

        Game.player1.inv = New Inventory(True)
        EquipmentDialogBackend.armorChange(Game.player1, "Naked")
        EquipmentDialogBackend.weaponChange(Game.player1, "Fists")
        Equipment.accChange(Game.player1, "Nothing")

        Game.player1.update()
        Game.drawBoard()

        TextEvent.push("As she picks up your frozen body, the time traveler opens another portal through the future and hops through.  You find yourself in a small holding cell, and she props you against the wall before exiting through an empty doorway with your bag and gear." & DDUtils.RNRN &
                          """Don't go anywhere, okay?"" she snickers, slapping a button and activating a shimmering blue energy barrier between the two of you.", AddressOf defrost)
    End Sub
    Private Shared Sub defrost()
        Game.player1.perks(perk.astatue) = -1
        Game.player1.revertToPState()
        TextEvent.push("After an indeterminate amount of time, feeling returns to you fingers, and you spend the next hour slowly regaining your mobility as you thaw.")
    End Sub
    Private Sub cooperate()
        Game.quickChangeFloor(10000)

        Game.currFloor.mBoard(33, 61).Tag = 0
        Game.currFloor.mBoard(33, 61).Text = "|"

        Game.player1.update()
        Game.drawBoard()

        TextEvent.push("The time traveler opens another portal through the future and, grabbing your hand, hops through.  You find yourself in a small holding cell, and she gives you a few moments to take in your surroundings before exiting through an empty doorway." & DDUtils.RNRN &
                          """Since you've been pretty well behaved so far, I'm gonna let you keep your stuff.  Don't try anything, okay?"" she says, slapping a button and activating a shimmering blue energy barrier between the two of you.")
    End Sub
    Private Sub resist()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(43), "Well, one way or another I'm taking you in.  If you're going to resist, I guess that's just how it's gonna be.", AddressOf fightTT)
    End Sub
    Private Sub fightTT()
        Dim m As TimeTravellerFight = New TimeTravellerFight()

        Monster.targetRoute(m)
        Game.toCombat(m)

        TextEvent.pushLog((m.getName() & " attacks!"))
    End Sub

    Public Overrides Function canGet() As Boolean
        'MsgBox((Not getActive()) & " " & (Game.mDun.floors.ContainsKey(9999)) & " " & (Not getComplete()) & " " & ((Int(Rnd() * 100) = 0) Or Game.noRNG))
        Return Not getActive() And Game.mDun.floors.ContainsKey(9999) And Not getComplete() And ((Int(Rnd() * 100) = 0) Or Game.noRNG)
    End Function
End Class

Public Class OutOfTimeS1
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
        Game.currFloor.mBoard(33, 61).Tag = 2
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

Public Class OutOfTimeS2
    Inherits Objective

    Sub New()
        MyBase.New("Find a way out.")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()

        TextEvent.push("A slightly garbled voice coughs before speaking from a strange box on the ceiling..." & DDUtils.RNRN &
                          """Prisoner 5, report to conference room A.""" & DDUtils.RNRN &
                          "You look around to see if there are any other prisoners around, and the voice sighs." & DDUtils.RNRN &
                          """Geez, didn't she explain anything to you?  YES!  YOU IN THE HALLWAY!  Head up to the junction and then it's the first door on the left.  This is EXACTLY why I've been saying we should paint some arrows in...""" & DDUtils.RNRN &
                          "...the voice trails off into annoyed mumbling before cutting off abruptly.")
        Game.currFloor.mBoard(18, 58).Text = "G"
    End Sub

    Public Overrides Function getDesc() As String
        Return description
    End Function

    Public Overrides Function isComplete() As Boolean
        Return Game.player1.pos.Y < 32
    End Function
End Class

Public Class OutOfTimeS3
    Inherits Objective

    Sub New()
        MyBase.New("Plead your case.")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()

        showNPC(ShopNPC.npcLib.atrs(0).getAt(83), "Hello.  I'll be the Time Judge handling your case.  From what I've seen it should be open and shut, so let's get the procedure started." & DDUtils.RNRN &
                "I am going to ask you a set of questions, keep your answers consise and honest.", AddressOf q1)
    End Sub

    Public Sub q1()
        showNPC(ShopNPC.npcLib.atrs(0).getAt(83), "First things first, did you intend to send yourself into the future?", AddressOf q1ask)
    End Sub
    Public Sub q1ask()
        TextEvent.pushYesNo("Did you try to go to the future?", AddressOf q1yes, AddressOf q1no)
    End Sub

    Public Sub q1no()
        showNPC(ShopNPC.npcLib.atrs(0).getAt(83), "Good to hear.  Do you plan on returning to this point in time ever again?", AddressOf q1noq2)
    End Sub
    Public Sub q1yes()
        showNPC(ShopNPC.npcLib.atrs(0).getAt(84), "Interesting... and did you consider the potential consequences that a time warp might have?", AddressOf q1yesq2)
    End Sub

    Public Sub q1noq2()
        TextEvent.pushYesNo("Do you plan on returning?", AddressOf q1noq2yes, AddressOf q1noq2no)
    End Sub
    Public Sub q1noq2yes()
        showNPC(ShopNPC.npcLib.atrs(0).getAt(84), "Hmmm.  You intend to violate time law intentionally?  Have you fully considered the weight of travelling into the future?", AddressOf q1yesq2)
    End Sub
    Public Sub q1noq2no()
        showNPC(ShopNPC.npcLib.atrs(0).getAt(83), "Well then, I see no reason to hold you here any further.  You are free to go, " & If(Game.player1.sex.Equals("Male"), "sir", "ma'am") & "...", AddressOf cleanup)
    End Sub

    Public Sub q1yesq2()
        TextEvent.pushYesNo("Did you fully think out time travel?", AddressOf q1yesq2yes, AddressOf q1yesq2no)
    End Sub
    Public Sub q1yesq2yes()
        showNPC(ShopNPC.npcLib.atrs(0).getAt(84), "And still you risk tearing at the fabric of the universe?  Who do you think you are?!", AddressOf q1yesq2yesq3)
    End Sub
    Public Sub q1yesq2no()
        showNPC(ShopNPC.npcLib.atrs(0).getAt(83), "So, you are simply reckless... not great for your case, but not terrible either...", AddressOf q1yesq2noq3)
    End Sub

    Public Sub q1yesq2yesq3()
        TextEvent.pushYesNo("Answer Politely?", AddressOf q1yesq2yesq3yes, AddressOf q1yesq2yesq3no)
    End Sub
    Public Sub q1yesq2yesq3yes()
        showNPC(ShopNPC.npcLib.atrs(0).getAt(83), "Do.  Not.  Do.  This.  Again." & DDUtils.RNRN &
                                                  "For your prior actions you will be fined 40,000 credits which adds up to 1,000 of your gold coins.  If we catch you outside of your source timeline again, there will be repercussions...", AddressOf fine1)
    End Sub
    Public Sub fine1()
        TextEvent.pushYesNo("Pay your fine?", AddressOf payFine1, AddressOf tjFight)
    End Sub
    Public Sub payFine1()
        If Game.player1.getGold < 1000 Then
            Game.player1.perks(perk.owetimebalance) = 1000 - Game.player1.gold
            showNPC(ShopNPC.npcLib.atrs(0).getAt(84), "*sigh* I suppose it would be too much to ask that you have the proper payment.  Fine, we'll just need to make up the balance later.  Now leave.  The door to the portal to your home timeline is the last one on the left.")
            Game.player1.gold = 0
        Else
            showNPC(ShopNPC.npcLib.atrs(0).getAt(83), "Now leave.  The door to the portal to your home timeline is the last one on the left.")
            Game.player1.gold -= 1000
        End If

        Game.currFloor.mBoard(5, 49).Tag = 2
        Game.currFloor.mBoard(5, 49).Text = ""
        Game.currFloor.mBoard(5, 72).Tag = 2
        Game.currFloor.mBoard(5, 72).Text = ""

        Game.compOOT = True

        Game.player1.update()
        Game.drawBoard()
    End Sub
    Public Sub q1yesq2yesq3no()
        showNPC(ShopNPC.npcLib.atrs(0).getAt(84), "I'm not just going to sit here and take this.  Have at you!", AddressOf tjFight)
    End Sub


    Public Sub q1yesq2noq3()
        showNPC(ShopNPC.npcLib.atrs(0).getAt(83), "Do you plan on returning to this point in time ever again?", AddressOf q1yesq2noq3ask)
    End Sub
    Public Sub q1yesq2noq3ask()
        TextEvent.pushYesNo("Do you plan on returning?", AddressOf q1yesq2noq3yes, AddressOf q1yesq2noq3no)
    End Sub
    Public Sub q1yesq2noq3yes()
        showNPC(ShopNPC.npcLib.atrs(0).getAt(84), "Well then, I'm afraid that you can't be allowed to leave.  Please return to your cell.", AddressOf q1yesq2noq3yesq4)
    End Sub
    Public Sub q1yesq2noq3no()
        showNPC(ShopNPC.npcLib.atrs(0).getAt(83), "Well, see that you don't.  For your prior actions you will be fined 20,000 credits which adds up to 500 of your gold coins and then you are free to go.", AddressOf fine2)
    End Sub
    Public Sub fine2()
        TextEvent.pushYesNo("Pay your fine?", AddressOf payFine2, AddressOf alert)
    End Sub
    Public Sub payFine2()
        If Game.player1.getGold < 500 Then
            Game.player1.perks(perk.owetimebalance) = 500 - Game.player1.gold
            showNPC(ShopNPC.npcLib.atrs(0).getAt(84), "We'll just need to make up the remaining balance later.  Now leave.  The door to the portal to your home timeline is the last one on the left.")
            Game.player1.gold = 0
        Else
            showNPC(ShopNPC.npcLib.atrs(0).getAt(83), "The door to the portal to your home timeline is the last one on the left.")
            Game.player1.gold -= 500
        End If

        Game.currFloor.mBoard(5, 49).Tag = 2
        Game.currFloor.mBoard(5, 49).Text = ""
        Game.currFloor.mBoard(5, 72).Tag = 2
        Game.currFloor.mBoard(5, 72).Text = ""

        Game.compOOT = True

        Game.player1.update()
        Game.drawBoard()
    End Sub

    Public Sub q1yesq2noq3yesq4()
        TextEvent.pushYesNo("Return to your cell?", AddressOf q1yesq2noq3yesq4yes, AddressOf alert)
    End Sub
    Public Sub q1yesq2noq3yesq4yes()
        TextEvent.push("You return to your cell, and then spend the next eternity as a temporal prisoner." & DDUtils.RNRN &
                          "Is this truly how you saw your journey ending?" & DDUtils.RNRN &
                          "Game Over!", AddressOf Game.player1.die)
        Game.compOOT = True
    End Sub


    Public Sub tjFight()
        Dim m As TimeJudgeFight = New TimeJudgeFight()

        Monster.targetRoute(m)
        Game.toCombat(m)

        TextEvent.pushLog((m.getName() & " attacks!"))
    End Sub

    Public Shared Sub alert(Optional seeJudge As Boolean = True)
        TextEvent.push("A blaring alarm sounds" & If(seeJudge, ", and the judge vanishes in a column of light", "") & "!")
        Game.currFloor.mBoard(18, 58).Text = ""
        Game.compOOT = True
        Game.player1.perks(perk.enemyoftime) = 1
    End Sub
    Public Sub cleanup()
        TextEvent.push("""Head up to the next room on the left, there's a control switch for the security barriers there.""" & DDUtils.RNRN & "Once your discussion wraps up, the judge says his farewells and vanishes in a column of light.")
        Game.currFloor.mBoard(18, 58).Text = ""
        Game.compOOT = True
    End Sub

    Public Overrides Function getDesc() As String
        Return description
    End Function

    Public Overrides Function isComplete() As Boolean
        Return (Game.player1.pos.Y = 18 And Game.player1.pos.X = 59) Or Game.compOOT
    End Function
End Class

