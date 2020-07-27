Public NotInheritable Class RandoTF
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
        Dim p As player = game.player1
        p.sState.load(p)
        If Game.preBSStartState Is Nothing Then Game.preBSStartState = New State(p)

        'assign a starter class / form
        p.pClass = p.classes("Classless")
        p.pForm = p.forms("Human")
        'assign a random sex
        Randomize()
        Dim r = Int(Rnd() * 2)
        If r = 0 Then p.sex = "Female" Else p.sex = "Male"

        'assign random stats
        p.health = 1.0
        p.maxHealth = 100 + Int(Rnd() * 50)
        p.mana = 3 + Int(Rnd() * 7)
        p.maxMana = CInt(p.mana.ToString)
        p.attack = 10 + Int(Rnd() * 7)
        p.defence = 10 + Int(Rnd() * 7)
        p.speed = 10 + Int(Rnd() * 7)
        p.gold = 25 + Int(Rnd() * 200)
        p.lust = 0
        p.stamina = 0
        p.hBuff = 0
        p.mBuff = 0
        p.wBuff = 0
        p.aBuff = 0
        p.dBuff = 0

        p.prt.setIAInd(pInd.wings, 0, True, True)
        p.prt.setIAInd(pInd.horns, 0, True, False)

        'set a random hair color
        p.prt.haircolor = Color.FromArgb(255, Int(Rnd() * 125) + 100, Int(Rnd() * 125) + 100, Int(Rnd() * 125) + 100)

        'set a random skin color
        Select Case Int(Rnd() * 6)
            Case 0
                p.prt.skincolor = (Color.AntiqueWhite)
            Case 1
                p.prt.skincolor = (Color.FromArgb(255, 247, 219, 195))
            Case 2
                p.prt.skincolor = (Color.FromArgb(255, 240, 184, 160))
            Case 3
                p.prt.skincolor = (Color.FromArgb(255, 210, 161, 140))
            Case 4
                p.prt.skincolor = (Color.FromArgb(255, 180, 138, 120))
            Case Else
                p.prt.skincolor = (Color.FromArgb(255, 105, 80, 70))
        End Select

        'set the rest of the portrait randomly
        r = Int(Rnd() * 7)
        p.prt.setIAInd(pInd.rearhair, r, True, False)
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, r, True, False)
        r = Int(Rnd() * 7)
        p.prt.setIAInd(pInd.clothes, r, True, False)
        p.prt.setIAInd(pInd.ears, 5, True, False)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        r = Int(Rnd() * 11)
        p.prt.setIAInd(pInd.mouth, r, True, False)
        r = Int(Rnd() * 5)
        p.prt.setIAInd(pInd.eyes, r, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.facemark, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.accessory, 0, True, False)
        r = Int(Rnd() * 8) + 1
        p.prt.setIAInd(pInd.fronthair, r, True, False)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        'clear all player associated lists
        p.createInvPerks()

        'assign random equipment
        setLoadout()

        p.TextColor = Color.White
        If game.mDun.numCurrFloor < 6 Then p.pImage = Game.picPlayer.BackgroundImage Else p.pImage = Game.picPlayerf.BackgroundImage
        p.reverseallroute()
        p.sState.save(p)

        p.inv.invNeedsUDate = True
        p.UIupdate()

        Dim si As Integer = p.sState.iArrInd(pInd.clothes).Item1
        p.currState.save(p)
        p.pState.save(p)
        p.sState.save(p)
        p.sState.iArrInd(pInd.clothes) = New Tuple(Of Integer, Boolean, Boolean)(si, p.prt.sexBool, False)
    End Sub
    Sub setLoadout()
        Randomize()
        Dim p = Game.player1
        Dim armor() As Integer = {}
        Dim weapon() As Integer = {}
        Dim armorIndex As Integer = -1
        Dim weaponIndex As Integer = -1

        Equipment.clothesChange("Naked")
        Equipment.weaponChange("Fists")
        Select Case Int(Rnd() * 23)
            Case 0   'basic warrior
                p.pClass = p.classes("Warrior")
                armor = New Integer() {5, 19, 46, 83}
                weapon = New Integer() {6, 23, 84, 176}
            Case 1   'basic mage
                p.pClass = p.classes("Mage")
                armor = New Integer() {5, 17, 46, 83}
                weapon = New Integer() {21, 22}
            Case 2   'advanced warrior
                p.pClass = p.classes("Warrior")
                armor = New Integer() {5, 19, 38, 46, 101}
                weapon = New Integer() {6, 23, 40, 118, 176}
            Case 3   'advanced mage
                p.pClass = p.classes("Mage")
                armor = New Integer() {5, 17, 46, 83}
                weapon = New Integer() {21, 22}
            Case 4   'basic bimbo
                p.pClass = p.classes("Bimbo")
                p.sex = "Female"
                armor = New Integer() {7, 12, 18, 20, 39, 47, 71, 72, 78, 85, 103, 105, 107, 116, 129, 177}
                weapon = New Integer() {6, 22, 23, 84}
            Case 5   'combat bimbo
                p.pForm = p.forms(perk.amazon)
                p.pClass = p.classes("Bimbo++")
                p.sex = "Female"
                armor = New Integer() {7, 12, 18, 20, 39, 47, 71, 72, 78, 85, 99, 103, 105, 107, 116, 129}
            Case 6   'amazon princess
                p.pForm = p.forms(perk.amazon)
                p.pClass = p.classes("Princess")
                p.sex = "Female"
                p.prt.skincolor = (Color.FromArgb(255, 210, 161, 140))
                armor = New Integer() {39, 85, 99}
            Case 7   'amazon warrior
                p.pForm = p.forms(perk.amazon)
                p.pClass = p.classes("Warrior")
                p.sex = "Female"
                p.prt.skincolor = (Color.FromArgb(255, 210, 161, 140))
                armor = New Integer() {7, 41, 71, 85, 99, 177}
            Case 8   'succubus
                p.pForm = p.forms("Succubus")
                p.pClass = p.classes("Warrior")
                armor = New Integer() {39, 74}
                weapon = New Integer() {6, 21, 22, 23, 63, 63, 63, 177}
                p.sex = "Female"
                p.prt.setIAInd(pInd.wings, 2, True, False)
                p.prt.setIAInd(pInd.horns, 3, True, False)
                p.prt.skincolor = Color.FromArgb(255, 255, 105, 180)
            Case 4   'succubus bimbo
                p.pForm = p.forms("Succubus")
                p.pClass = p.classes("Bimbo")
                p.sex = "Female"
                armor = New Integer() {7, 12, 18, 20, 39, 47, 71, 72, 78, 85, 103, 105, 107, 116, 129, 177}
                weapon = New Integer() {6, 21, 22, 23, 63, 63, 63}
                p.prt.setIAInd(pInd.wings, 2, True, False)
                p.prt.setIAInd(pInd.horns, 3, True, False)
                p.prt.skincolor = Color.FromArgb(255, 255, 105, 180)
            Case 10   'barbarian
                p.pClass = p.classes(perk.barbarian)
                armor = New Integer() {101}
                weapon = New Integer() {84, 118}
            Case 11   'warlock
                p.pClass = p.classes("Warlock")
                armor = New Integer() {115}
                weapon = New Integer() {22}
            Case 12   'space warrior
                p.pClass = p.classes("Warrior")
                armor = New Integer() {102, 104, 106}
                weapon = New Integer() {111, 112, 120}
            Case 13   'classless
                armor = New Integer() {5, 17, 19, 83}
                weapon = New Integer() {6, 22, 23, 84}
            Case 14   'magic maid
                p.pForm = p.forms("Half-Succubus")
                p.pClass = p.classes("Maid")
                armor = New Integer() {72}
                weapon = New Integer() {6, 21, 22, 23, 63, 63, 63}
                p.sex = "Female"
                p.prt.setIAInd(pInd.wings, 2, True, False)
                p.prt.haircolor = Color.FromArgb(255, 155, 0, 0)
            Case 15   'valkyrie
                p.pForm = p.forms("Angel")
                p.pClass = p.classes("Warrior")
                armor = New Integer() {7, 19, 83, 85, 95, 105}
                weapon = New Integer() {6, 23, 40, 112, 177, 176}
                p.sex = "Female"
                p.prt.setIAInd(pInd.wings, 1, True, False)
            Case 16   'bunny girl
                p.pClass = p.classes("Bunny Girl")
                armor = New Integer() {16, 94, 129}
                weapon = New Integer() {6, 21, 22, 23, 40, 41, 63}
                p.sex = "Female"
                p.inv.item(perk.bowtie).add(1)
                Equipment.accChange(perk.bowtie)
            Case 17   'cow girl
                p.pForm = p.forms("Minotaur Cow")
                p.pClass = p.classes(perk.barbarian)
                armor = New Integer() {19, 71, 101}
                weapon = New Integer() {6, 23, 40, 118, 177}
                p.sex = "Female"
                p.prt.setIAInd(pInd.horns, 2, True, False)
            Case 18   'cow male
                p.pForm = p.forms("Minotaur Bull")
                p.pClass = p.classes(perk.barbarian)
                armor = New Integer() {19, 101}
                weapon = New Integer() {6, 23, 40, 118, 176}
                p.sex = "Male"
                p.prt.setIAInd(pInd.horns, 2, True, False)
            Case 19   'basic warrior
                p.pClass = p.classes("Warrior")
                armor = New Integer() {5, 19, 46, 83}
                weapon = New Integer() {6, 23, 84, 176}
            Case 20   'basic mage
                p.pClass = p.classes("Mage")
                armor = New Integer() {5, 17, 46, 83}
                weapon = New Integer() {21, 22}
            Case 21  'advanced warrior
                p.pClass = p.classes("Warrior")
                armor = New Integer() {5, 19, 38, 46, 101}
                weapon = New Integer() {6, 23, 40, 118, 176}
            Case 22  'advanced mage
                p.pClass = p.classes("Mage")
                armor = New Integer() {5, 17, 46, 83}
                weapon = New Integer() {21, 22}
        End Select

        For i = 0 To 4
            Dim invInd As Integer = 8
            While Not p.inv.item(invInd).isRandoTFAcceptable
                invInd = Int(Rnd() * (Game.player1.inv.upperBound + 1))
            End While
            p.inv.add(invInd, CInt(Int(Rnd() * 2) + 1))
        Next

        p.inv.add(2, 1)
        p.inv.add(13, 1)

        'set other player stuff
        If p.sex.Equals("Female") Then
            p.breastSize = Int(Rnd() * 3) + 1
        Else
            For i = 1 To Portrait.NUM_IMG_LAYERS
                p.prt.setIAInd(i, p.prt.iArrInd(i).Item1, False, False)
            Next
            p.breastSize = -1
        End If

        If armor.Length > 0 Then
            armorIndex = armor(Int(Rnd() * (armor.Length)))
            p.inv.add(armorIndex, 1)
            Equipment.clothesChange(p.inv.item(armorIndex).getAName)
        End If
        If weapon.Length > 0 Then
            weaponIndex = weapon(Int(Rnd() * (weapon.Length)))
            p.inv.add(weaponIndex, 1)
            Equipment.weaponChange(p.inv.item(weaponIndex).getAName)
        End If
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
        Dim p As player = game.player1
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
        Dim p As player = game.player1
        Game.preBSStartState.load(p)
        p.sState.save(p)
        Game.preBSBody.load(p)
        p.pState.save(p)
        p.revertToPState()
        For i = 0 To Game.preBSInventory.Count - 1
            p.inv.add(i, Game.preBSInventory(i))
        Next
        p.canMoveFlag = True
        Game.lblEvent.Visible = False
        Game.player1 = p
        p.UIupdate()
    End Sub
    Shared Sub floor4keep()
        Dim p As player = game.player1
        For i = 0 To Game.preBSInventory.Count - 1
            p.inv.add(i, Game.preBSInventory(i))
        Next
        p.canMoveFlag = True
        Game.lblEvent.Visible = False
        Game.player1 = p
        p.UIupdate()
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = game.player1
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
