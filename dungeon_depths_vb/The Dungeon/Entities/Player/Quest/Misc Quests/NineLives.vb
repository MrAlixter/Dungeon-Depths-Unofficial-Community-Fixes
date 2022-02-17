Public Class NineLives
    Inherits Quest

    Sub New()
        MyBase.New("Nine Lives")

        qInd = qInds.nineLives

        objectives.Add(New NineLivesS1)
        objectives.Add(New NineLivesS2)
    End Sub

    Public Overrides Sub init()
        MyBase.init()

        TextEvent.push("""Hey!  Help, Over here!"" you hear someone call out behind you.  You quickly turn around before relaxing slightly as a floppily-behatted young woman approaches you, panting as though she has been running for quite some time.", AddressOf introDialog)
    End Sub

    Private Sub introDialog()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(99), """Oh, thank you for stopping..."" she says, sheepishly.  She turns around, revealing that there is an unconscious cat in a pouch slung across her back." & DDUtils.RNRN &
                          """My familiar got hurt and-  I mean, I just had to run-  Can you please help me get some medical supplies together?  Everything down here is more than I can handle...""", AddressOf introDialog2)
    End Sub

    Private Sub introDialog2()
        TextEvent.pushYesNo("Help her out?", AddressOf helpOut, AddressOf beADick)
    End Sub

    Private Sub helpOut()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(99), """Great, you're the best!  Thank you so, so much... Ok, um, first we need to pick up two health potions and a restoration potion.  I have a recipe for, um... a potent healing ritual, and the first step is getting the medicine together...""" & DDUtils.RNRN & "Quest ""Nine Lives"" acquired!")
    End Sub

    Private Sub beADick()
        TextEvent.push("Wordlessly you turn back around, continuing on your way." & DDUtils.RNRN &
                          """JERK!"" the woman cries out, without following you." & DDUtils.RNRN &
                          "..." & DDUtils.RNRN &
                          "If not for the fact that nearly everything in this dungeon is some kind of weird trap, you'd probably agree...")

        completeEntireQuest()
    End Sub

    Public Overrides Function canGet() As Boolean
        Return Not getActive() And Game.currFloor.floorNumber > 5 And Not getComplete() And Game.player1.inv.getCountAt("Restore_Potion") > 0
    End Function
End Class

Public Class NineLivesS1
    Inherits Objective

    Sub New()
        MyBase.New("Acquire 2 health potions and a restore potion.")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()

        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(99), """Thank you so much for your help, I don't know what I'd, um, do without you...  The last thing we need is a mana potion to power the incantation.  Um... I know those can be bit pricy, so please take this gold to help cover any costs...""" & DDUtils.RNRN &
                          "+300 gold")
        Game.player1.gold += 300
        Game.player1.UIupdate()
    End Sub

    Private Function getProgress() As Integer
        Return Math.Min(Game.player1.inv.getCountAt("Health_Potion"), 2) + Math.Min(Game.player1.inv.getCountAt("Restore_Potion"), 1)
    End Function
    Public Overrides Function getDesc() As String
        Return description & "  [" & getProgress() & "/3]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return getProgress() >= 3
    End Function
End Class

Public Class NineLivesS2
    Inherits Objective

    Sub New()
        MyBase.New("Acquire a mana potion.")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()

        Game.player1.perks(perk.mrevived) = 1
        TextEvent.push("While you've been off acquiring ingredients, the woman appears to have set up a small camp.  ""Oh, um, hey!"" she greets you, stiring a mixture in a small cauldron, ""D-did you get the potion?  Awesome!""" & DDUtils.RNRN &
                          "You hand it to her, and she pours it into the brew." & DDUtils.RNRN &
                          """Awesome, awesome, awesome...  I can't thank you enough for helping me out on this.  We've got the medicine and enough concentrated mana to power the ritual, and you helping me out was the final ingredient.  An act of kindness...""", AddressOf complete2)
    End Sub

    Public Sub complete2()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(100), """...from an enemy.""" & DDUtils.RNRN &
                          "You pause for a couple seconds before asking what she's talking about.  The woman bursts into a rather sinister giggle before pushing her glasses back into place with an uncharacteristically confident grin." & DDUtils.RNRN &
                          """This isn't my familiar, it's all that's left of Lady Marissa after YOU got through with her!  If she weren't the best enchantress in history, she'd be dead!""" & DDUtils.RNRN &
                          "You remind her that Marissa was the one to attack you, but she cuts you off by drawing her staff and charging a spell." & DDUtils.RNRN &
                          """SELF POLYMORPH!"" she anounces, flaring with a magical glow...", AddressOf complete3)
    End Sub

    Public Sub complete3()
        Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(97), "I won't let you interfere with Lady Marissa's revival, you... jerk..." & DDUtils.RNRN &
                          "If you're going to fight anyone, it's gonna be ME!", AddressOf fightMayue)
    End Sub

    Public Sub fightMayue()
        Dim m As Mayue = New Mayue()

        Monster.targetRoute(m)
        Game.toCombat(m)

        TextEvent.pushLog((m.getName() & " attacks!"))
    End Sub

    Private Function getProgress() As Integer
        Return Math.Min(Game.player1.inv.getCountAt("Mana_Potion"), 1)
    End Function
    Public Overrides Function getDesc() As String
        Return description & "  [" & getProgress() & "/1]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return getProgress() >= 1
    End Function
End Class

