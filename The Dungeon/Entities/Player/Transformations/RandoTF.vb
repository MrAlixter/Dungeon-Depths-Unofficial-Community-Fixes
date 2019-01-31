Public Class RandoTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "RandoTF"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "RandoTF"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Sub step1()

        'assign a pointer to the player character
        Dim p As player = game.player

        'assign a random starter class
        Dim classes = {"Warrior", "Mage", "Paladin", "Warrior", "Mage", "Bimbo"}
        p.pClass = p.classes(classes(Int(Rnd() * classes.Length)))

        'assign a random sex
        Randomize()
        Dim r = Int(Rnd() * 2)
        If r = 0 Or p.pClass.Equals("Bimbo") Then
            p.sex = "Female"
            p.sexBool = p.sexbool
            p.breastSize = Int(Rnd() * 3) + 1
        Else
            p.sex = "Male"
            p.sexBool = False
            p.breastSize = -1
        End If

        'assign random stats
        p.health = 1.0
        p.maxHealth = 70 + Int(Rnd() * 50)
        p.mana = Int(Rnd() * 7)
        p.maxMana = CInt(p.mana.ToString)
        p.attack = 10 + Int(Rnd() * 7)
        p.defence = 7 + Int(Rnd() * 7)
        p.will = 5 + Int(Rnd() * 7)
        p.speed = 9 + Int(Rnd() * 7)
        p.gold = 25 + Int(Rnd() * 200)
        p.lust = 0
        p.hunger = 0
        p.hBuff = 0
        p.mBuff = 0
        p.wBuff = 0
        p.aBuff = 0
        p.dBuff = 0

        'set a random hair color
        p.haircolor = Color.FromArgb(255, Int(Rnd() * 125) + 100, Int(Rnd() * 125) + 100, Int(Rnd() * 125) + 100)

        'set a random skin color
        Select Case Int(Rnd() * 6)
            Case 0
                p.skincolor = (Color.AntiqueWhite)
            Case 1
                p.skincolor = (Color.FromArgb(255, 247, 219, 195))
            Case 2
                p.skincolor = (Color.FromArgb(255, 240, 184, 160))
            Case 3
                p.skincolor = (Color.FromArgb(255, 210, 161, 140))
            Case 4
                p.skincolor = (Color.FromArgb(255, 180, 138, 120))
            Case Else
                p.skincolor = (Color.FromArgb(255, 105, 80, 70))
        End Select

        'set the rest of the portrait randomly
        r = Int(Rnd() * 5)
        p.iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(r, p.sexBool, False)
        p.iArrInd(2) = New Tuple(Of Integer, Boolean, Boolean)(0, p.sexBool, False)
        p.iArrInd(4) = New Tuple(Of Integer, Boolean, Boolean)(0, p.sexBool, False)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean, Boolean)(r, p.sexBool, False)
        r = Int(Rnd() * 5)
        p.iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(r, p.sexBool, False)
        r = Int(Rnd() * 4)
        p.iArrInd(6) = New Tuple(Of Integer, Boolean, Boolean)(r, p.sexBool, False)
        p.iArrInd(7) = New Tuple(Of Integer, Boolean, Boolean)(0, p.sexBool, False)
        r = Int(Rnd() * 3)
        If r = 1 Then r = 4
        p.iArrInd(8) = New Tuple(Of Integer, Boolean, Boolean)(r, p.sexBool, False)
        r = Int(Rnd() * 3)
        p.iArrInd(9) = New Tuple(Of Integer, Boolean, Boolean)(r, p.sexBool, False)
        p.iArrInd(10) = New Tuple(Of Integer, Boolean, Boolean)(0, p.sexBool, False)
        p.iArrInd(11) = New Tuple(Of Integer, Boolean, Boolean)(0, p.sexBool, False)
        p.iArrInd(12) = New Tuple(Of Integer, Boolean, Boolean)(0 + (2 * Int(Rnd() * 3)), p.sexBool, False)
        p.iArrInd(13) = New Tuple(Of Integer, Boolean, Boolean)(0, p.sexBool, False)
        p.iArrInd(14) = New Tuple(Of Integer, Boolean, Boolean)(0, p.sexBool, False)
        r = Int(Rnd() * 4) + 1
        p.iArrInd(15) = New Tuple(Of Integer, Boolean, Boolean)(r, p.sexBool, False)
        p.iArrInd(16) = New Tuple(Of Integer, Boolean, Boolean)(0, p.sexBool, False)

        'clear all player associated lists
        p.createInvPerks()

        'assign random equipment
        Dim armor = New Integer() {5, 5, 5, 7, 12, 16, 17, 17, 17, 18, 19, 19, 19, 20, 38, 38, 39, 46, 47, 64, 71}
        Dim armorIndex = armor(Int(Rnd() * (armor.Length)))
        Dim weapon = New Integer() {6, 6, 9, 9, 21, 21, 22, 22, 23, 63}
        Dim weaponIndex = weapon(Int(Rnd() * (weapon.Length)))
        p.inv.add(armorIndex, 1)
        p.inv.add(weaponIndex, 1)
        p.equippedArmor = p.inv.item(armorIndex)
        p.equippedWeapon = p.inv.item(weaponIndex)

        For i = 0 To 4
            Dim invInd As Integer = 8
            While invInd = 8 Or invInd = 10 Or invInd = 24 Or invInd = 53
                invInd = Int(Rnd() * (Game.player.inv.upperBound + 1))
            End While
            p.inv.add(invInd, CInt(Int(Rnd() * 2) + 1))
        Next

        p.inv.add(2, 1)
        p.inv.add(13, 1)

        'set class stats
        If p.pClass.Equals("Warrior") Or p.pClass.Equals("Paladin") Then
            p.attack += 10 + Int(Rnd() * 5)
            p.defence += 5 + Int(Rnd() * 5)
            p.speed -= Int(Rnd() * 5)
        ElseIf p.pClass.Equals("Mage") Or p.pClass.Equals("Paladin") Then
            p.attack -= Int(Rnd() * 5)
            p.defence -= Int(Rnd() * 5)
            p.speed += Int(Rnd() * 5)
            p.mana += 8 + Int(Rnd() * 5)
            p.inv.add(4, 1)
        ElseIf p.pClass.Equals("Bimbo") Then
            p.changeHairColor(BimboTF.bimboyellow)
            p.will = 1
            p.perks("slutcurse") = 1
            If Int(Rnd() * 10) = 7 Then p.inv.add(4, 1)
        End If

        'set other player stuff
        p.TextColor = Color.White
        If Game.floor < 6 Then p.pImage = Game.picPlayer.BackgroundImage Else p.pImage = Game.picPlayerf.BackgroundImage
        p.bsizeroute()

        p.inv.invNeedsUDate = True
        p.UIupdate()

        Dim si As Integer = p.sState.iArrInd(3).Item1
        p.currState.save(p)
        p.pState.save(p)
        p.sState.save(p)
        p.sState.iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(si, p.sexBool, False)
    End Sub
    Shared Sub floor4FirstBossEncounter()
        Game.pushLblEvent("Turning around, you are about to move on when a " & _
                          "giggle coming from behind you causes you to stop." & _
                          "Looking over your shoulder, you see the chest " & _
                          "behind you become swallowed into a mass of turquoise " & _
                          "slime.  Drawing your weapon, you turn around and " & _
                          "prepare yourself for a fight.  As you begin your " & _
                          "attack, a single, large, gooey tendril shoots out" & _
                          "of the mass, yanking your weapon from your hand " & _
                          "before several smaller tentacles wrap around your " & _
                          "limbs, restraining you." & vbCrLf & vbCrLf & _
                          """Well, well, well.  What do we have here?"", a " & _
                          "slightly distorted female voice chuckles from " & _
                          "somewhere behind you." & vbCrLf & vbCrLf & "Suddenly, you " & _
                          "find yourself being flipped upside down and dragged " & _
                          "upwards to the ceiling, where you meet the gaze of " & _
                          "a translucent, teal woman who's lower half seems to be" & _
                          " a mass of tentacles that has it rooted firmly to " & _
                          "the roof.  Her remarkably curvy figure, as well as" & _
                          "her more mature attitude suggest that you might be " & _
                          "in for something unique from the other slime girls" & _
                          "you've encountered so far.  As you look closer, you " & _
                          "notice some vaugely human-shaped bodies mixed in with " & _
                          "the writhing tendrils of slime, and you wonder what " & _
                          "exactly you're in for here. ""I ..."" the slime says, drawing your attention " & _
                          "back to her, ""... am the Ooze Empress.  This floor" & _
                          ", and all who inhabit it fall under my ..."".  As " & _
                          "she introduces herself, you find it harder and " & _
                          "harder to focus.  Your body, especially where her" & _
                          " tentacles are making direct contact, feels as though" & _
                          " every inch of it is flushing with arousal.", AddressOf floor4FirstBossEncounterP2)
    End Sub
    Shared Sub floor4FirstBossEncounterP2()
        Dim p As player = game.player
        Game.preBSBody = New State(p)
        Game.preBSInventory = New ArrayList()
        For i = 0 To p.inv.upperBound
            Game.preBSInventory.Add(p.inv.getCountAt(i))
        Next
        p.ongoingTFs.Add(New RandoTF())
        p.update()
        p.sState.save(p)
        p.pState.save(p)
        Game.pushLblEvent("The " & _
                          "warmth slowly builds until you are burning with " & _
                          "lust, and you can't help but lose intrest in what " & _
                          "your captor is saying, lost in the fog of your " & _
                          "pleasure.  A small giggle tells you that your " & _
                          "distraction has not gone unnoticed.  ""Enjoying " & _
                          "yourself?"" the Empress asks, giving you a gentle" & _
                          " shake, ""What you're feeling now is the powerful " & _
                          "aphrodesiac that is mixed into my body.  Would you " & _
                          "like a more intimate taste, little one?"".  In your " & _
                          "state, you don't even need to consider her offer.  " & _
                          "After you give her a vigorous nod, the slime purrs " & _
                          """Wonderful, darling, you seem like you could use a " & _
                          "little relaxation."", plunging you into the mass of " & _
                          "her tendrils.  If the aphrodisiac was overwhelming " & _
                          "before, being submmerged in it practically puts you in" & _
                          " a pleasure coma.  Before passing out from the burning " & _
                          "need flowing throug every part of your body, you catch her " & _
                          "motherly gaze as she giggles, ""Have fun!""." & vbCrLf & vbCrLf & _
                          "When you come to, you can tell some time has passed.  Though " & _
                          "the Emperess is nowhere to be found, the amount of slime" & _
                          " you are drenched still fills you with a bit of lust.  " & _
                          "Looking down, however, you are not met with your familiar body, " & _
                          "but instead that of a stranger!  You must have had one hell " & _
                          "of a time to wake up in the wrong body, and a quick pat down" & _
                          " reveals that all of your belongings, including the key, are " & _
                          "missing as well!  At least the ooze didn't seem that malevolent, " & _
                          "maybe if you can find her again you can straighten this out.")
    End Sub
    Shared Sub floor4revert()
        Dim p As player = game.player
        Game.preBSStartState.load(p)
        p.sState.save(p)
        Game.preBSBody.load(p)
        p.pState.save(p)
        p.revertToPState()
        For i = 0 To Game.preBSInventory.Count - 1
            p.inv.add(i, Game.preBSInventory(i))
        Next
        p.canMoveFlag = p.sexbool
        Game.lblEvent.Visible = False
        Game.player = p
        p.UIupdate()
    End Sub
    Shared Sub floor4keep()
        Dim p As player = game.player
        For i = 0 To Game.preBSInventory.Count - 1
            p.inv.add(i, Game.preBSInventory(i))
        Next
        p.canMoveFlag = p.sexbool
        Game.lblEvent.Visible = False
        Game.player = p
        p.UIupdate()
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = game.player
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
