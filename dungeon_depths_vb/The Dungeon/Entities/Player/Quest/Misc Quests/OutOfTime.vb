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

        Game.pushLblEvent("As you are walking along, another glowing rift in space and time opens in front of you." & DDUtils.RNRN &
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
        Game.pushPnlYesNo("Cooperate?", AddressOf cooperate, AddressOf resist)
    End Sub
    Public Shared Sub hostileArrest()
        Game.quickChangeFloor(10000)

        Dim c1 As Chest = Game.baseChest.Create(Game.player1.inv, New Point(28, 10))
        Game.currFloor.chestList.Add(c1)
        Game.currFloor.mBoard(10, 28).ForeColor = Color.FromArgb(45, 45, 45)
        Game.currFloor.mBoard(10, 28).Text = "#"

        Game.currFloor.mBoard(33, 61).Tag = 0
        Game.currFloor.mBoard(33, 61).Text = "|"

        Game.player1.inv = New Inventory(True)
        Equipment.clothesChange(Game.player1, "Naked")
        Equipment.weaponChange(Game.player1, "Fists")
        Equipment.accChange(Game.player1, "Nothing")

        Game.player1.update()
        Game.drawBoard()

        Game.pushLblEvent("As she picks up your frozen body, the time traveler opens another portal through the future and hops through.  You find yourself in a small holding cell, and she props you against the wall before exiting through an empty doorway with your bag and gear." & DDUtils.RNRN &
                          """Don't go anywhere, okay?"" she snickers, slapping a button and activating a shimmering blue energy barrier between the two of you.", AddressOf defrost)
    End Sub
    Private Shared Sub defrost()
        Game.player1.perks(perk.astatue) = -1
        Game.player1.revertToPState()
        Game.pushLblEvent("After an indeterminate amount of time, feeling returns to you fingers, and you spend the next hour slowly regaining your mobility as you thaw.")
    End Sub
    Private Sub cooperate()
        Game.quickChangeFloor(10000)

        Game.currFloor.mBoard(33, 61).Tag = 0
        Game.currFloor.mBoard(33, 61).Text = "|"

        Game.player1.update()
        Game.drawBoard()

        Game.pushLblEvent("The time traveler opens another portal through the future and, grabbing your hand, hops through.  You find yourself in a small holding cell, and she gives you a few moments to take in your surroundings before exiting through an empty doorway." & DDUtils.RNRN &
                          """Since you've been pretty well behaved so far, I'm gonna let you keep your stuff.  Don't try anything, okay?"" she says, slapping a button and activating a shimmering blue energy barrier between the two of you.")
    End Sub
    Private Sub resist()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(43), "Well, one way or another I'm taking you in.  If you're going to resist, I guess that's just how it's gonna be.", AddressOf fightTT)
    End Sub
    Private Sub fightTT()
        Dim m As TimeTravellerFight = New TimeTravellerFight()

        Monster.targetRoute(m)

        Game.toCombat()
        Game.pushLstLog((m.getName() & " attacks!"))
        Game.turn += 1
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
            Equipment.clothesChange(Game.player1, "Space_Age_Jumpsuit")
            Game.player1.drawPort()
        End If

        Game.pushLblEvent("An unknown amount of time passes..." & DDUtils.RNRN & DDUtils.RNRN & DDUtils.RNRN &
                          "As you wake up one morning, the now familiar hum of the shimmering barrier keeping you isolated from the rest of the faciitly seems to have faded out of your concious senses, and...." & DDUtils.RNRN &
                          "wait..." & DDUtils.RNRN &
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

        MsgBox("A")
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

        MsgBox("B")
    End Sub

    Public Overrides Function getDesc() As String
        Return description
    End Function

    Public Overrides Function isComplete() As Boolean
        Return Game.player1.pos.Y < 32
    End Function
End Class

