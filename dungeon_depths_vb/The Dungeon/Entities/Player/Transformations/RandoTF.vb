Public NotInheritable Class RandoTF
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.rando

    Sub New()
        MyBase.New(1, 0, 0, False)
        tf_name = TF_IND
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Sub step1()

        'assign a pointer to the player character
        Dim p As player = Game.player1
        If Not p.preBSStartState.initFlag Then p.preBSStartState = p.sState.clone(p)

        'assign a starter class / form
        p.changeClass("Classless")
        p.changeForm("Human")

        'remove the player's gear
        EquipmentDialogBackend.equipArmor(p, "Naked", False)
        EquipmentDialogBackend.equipWeapon(p, "Fists", False)
        EquipmentDialogBackend.equipAcce(p, "Nothing", False)

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
        p.defense = 10 + Int(Rnd() * 7)
        p.speed = 10 + Int(Rnd() * 7)
        p.gold = 25 + Int(Rnd() * 200)
        p.lust = 0
        p.stamina = 100
        p.hBuff = 0
        p.mBuff = 0
        p.wBuff = 0
        p.aBuff = 0
        p.dBuff = 0

        p.prt.setIAInd(pInd.wings, 0, True, False)
        p.prt.setIAInd(pInd.horns, 0, True, False)
        p.prt.setIAInd(pInd.hairacc, 0, True, False)

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
        r = Int(Rnd() * 5)
        p.prt.setIAInd(pInd.facemark, r, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.accessory, 0, True, False)
        r = Int(Rnd() * 8) + 1
        p.prt.setIAInd(pInd.fronthair, r, True, False)
        p.prt.setIAInd(pInd.hat, 0, True, False)
        p.prt.setIAInd(pInd.tail, 0, True, False)
        p.prt.setIAInd(pInd.horns, 0, True, False)
        p.prt.setIAInd(pInd.wings, 0, True, False)

        'clear all player associated lists
        p.inv = New Inventory(True)
        p.resetPerks()

        'assign random equipment
        setLoadout()

        p.TextColor = Color.White

        p.inv.invNeedsUDate = True
        p.UIupdate()

        Dim si As Integer = p.sState.iArrInd(pInd.clothes).Item1
        p.currState.save(p)
        p.pState.save(p)
        p.sState.save(p)
        p.ongoingTFs.reset()
        p.sState.iArrInd(pInd.clothes) = New Tuple(Of Integer, Boolean, Boolean)(si, p.prt.sexBool, False)
    End Sub
    Sub setLoadout()
        Randomize()
        Dim p = Game.player1
        Dim armor() As Integer = {}
        Dim weapon() As Integer = {}
        Dim armorIndex As Integer = -1
        Dim weaponIndex As Integer = -1

        Select Case Int(Rnd() * 23)
            Case 0   'basic warrior
                p.changeClass("Warrior")
                armor = New Integer() {5, 19, 46, 83}
                weapon = New Integer() {6, 23, 84, 176}
            Case 1   'basic mage
                p.changeClass("Mage")
                armor = New Integer() {5, 17, 46, 83}
                weapon = New Integer() {21, 22}
            Case 2   'advanced warrior
                p.changeClass("Warrior")
                armor = New Integer() {5, 19, 38, 46, 101}
                weapon = New Integer() {6, 23, 40, 118, 176}
            Case 3   'advanced mage
                p.changeClass("Mage")
                armor = New Integer() {5, 17, 46, 83}
                weapon = New Integer() {21, 22}
            Case 4   'basic bimbo
                p.changeClass("Bimbo")
                p.sex = "Female"
                armor = New Integer() {7, 12, 18, 20, 39, 47, 71, 72, 78, 85, 103, 105, 107, 116, 129, 177}
                weapon = New Integer() {6, 22, 23, 84}
            Case 5   'combat bimbo
                p.changeForm("Amazon")
                p.changeClass("Bimbo++")
                p.sex = "Female"
                armor = New Integer() {7, 12, 18, 20, 39, 47, 71, 72, 78, 85, 99, 103, 105, 107, 116, 129}
            Case 6   'amazon princess
                p.changeForm("Amazon")
                p.changeClass("Princess")
                p.sex = "Female"
                p.prt.skincolor = (Color.FromArgb(255, 210, 161, 140))
                armor = New Integer() {39, 85, 99}
            Case 7   'amazon warrior
                p.changeForm("Amazon")
                p.changeClass("Warrior")
                p.sex = "Female"
                p.prt.skincolor = (Color.FromArgb(255, 210, 161, 140))
                armor = New Integer() {7, 41, 71, 85, 99, 177}
            Case 8   'succubus
                p.changeForm("Succubus")
                p.changeClass("Warrior")
                armor = New Integer() {39, 74}
                weapon = New Integer() {6, 21, 22, 23, 63, 63, 63, 177}
                p.sex = "Female"
                p.prt.setIAInd(pInd.wings, 2, True, False)
                p.prt.setIAInd(pInd.horns, 3, True, False)
                p.prt.skincolor = Color.FromArgb(255, 255, 105, 180)
            Case 4   'succubus bimbo
                p.changeForm("Succubus")
                p.changeClass("Bimbo")
                p.sex = "Female"
                armor = New Integer() {7, 12, 18, 20, 39, 47, 71, 72, 78, 85, 103, 105, 107, 116, 129, 177}
                weapon = New Integer() {6, 21, 22, 23, 63, 63, 63}
                p.prt.setIAInd(pInd.wings, 2, True, False)
                p.prt.setIAInd(pInd.horns, 3, True, False)
                p.prt.skincolor = Color.FromArgb(255, 255, 105, 180)
            Case 10   'barbarian
                p.changeClass("Barbarian")
                armor = New Integer() {101}
                weapon = New Integer() {84, 118}
            Case 11   'warlock
                p.changeClass("Warlock")
                armor = New Integer() {115}
                weapon = New Integer() {22}
            Case 12   'space warrior
                p.changeClass("Warrior")
                armor = New Integer() {102, 104, 106}
                weapon = New Integer() {111, 112, 120}
            Case 13   'classless
                armor = New Integer() {5, 17, 19, 83}
                weapon = New Integer() {6, 22, 23, 84}
            Case 14   'magic maid
                p.changeForm("Half-Succubus")
                p.changeClass("Maid")
                armor = New Integer() {72}
                weapon = New Integer() {6, 21, 22, 23, 63, 63, 63}
                p.sex = "Female"
                p.prt.setIAInd(pInd.wings, 2, True, False)
                p.prt.haircolor = Color.FromArgb(255, 155, 0, 0)
            Case 15   'valkyrie
                p.changeForm("Angel")
                p.changeClass("Warrior")
                armor = New Integer() {7, 19, 83, 85, 95, 105}
                weapon = New Integer() {6, 23, 40, 112, 177, 176}
                p.sex = "Female"
                p.prt.setIAInd(pInd.wings, 1, True, False)
            Case 16   'bunny girl
                p.changeClass("Bunny Girl")
                armor = New Integer() {16, 94, 129}
                weapon = New Integer() {6, 21, 22, 23, 40, 41, 63}
                p.sex = "Female"
                p.inv.item("Bowtie").add(1)
                Equipment.accChange(p, "Bowtie")
            Case 17   'cow girl
                p.changeForm("Minotaur Cow")
                p.changeClass("Barbarian")
                armor = New Integer() {19, 71, 101}
                weapon = New Integer() {6, 23, 40, 118, 177}
                p.sex = "Female"
                p.prt.setIAInd(pInd.horns, 2, True, False)
            Case 18   'cow male
                p.changeForm("Minotaur Bull")
                p.changeClass("Barbarian")
                armor = New Integer() {19, 101}
                weapon = New Integer() {6, 23, 40, 118, 176}
                p.sex = "Male"
                p.prt.setIAInd(pInd.horns, 2, True, False)
            Case 19   'basic warrior
                p.changeClass("Warrior")
                armor = New Integer() {5, 19, 46, 83}
                weapon = New Integer() {6, 23, 84, 176}
            Case 20   'basic mage
                p.changeClass("Mage")
                armor = New Integer() {5, 17, 46, 83}
                weapon = New Integer() {21, 22}
            Case 21  'advanced warrior
                p.changeClass("Warrior")
                armor = New Integer() {5, 19, 38, 46, 101}
                weapon = New Integer() {6, 23, 40, 118, 176}
            Case 22  'advanced mage
                p.changeClass("Mage")
                armor = New Integer() {5, 17, 46, 83}
                weapon = New Integer() {21, 22}
        End Select

        For i = 0 To 4
            Dim invInd As Integer = 8
            While Not p.inv.item(invInd).rando_inv_allowed
                invInd = Int(Rnd() * (Game.player1.inv.upperBound + 1))
            End While
            p.inv.add(invInd, CInt(Int(Rnd() * 2) + 1))
        Next

        p.inv.add(2, 1)
        p.inv.add(13, 1)

        'set other player stuff
        If p.sex.Equals("Female") Then
            p.breastSize = Int(Rnd() * 3) + 1
            p.buttSize = Int(Rnd() * 3) + 1
            p.dickSize = -1
        Else
            For i = 1 To Portrait.NUM_IMG_LAYERS
                p.prt.setIAInd(i, p.prt.iArrInd(i).Item1, False, False)
            Next
            p.breastSize = -1
            p.buttSize = -1
            p.dickSize = Int(Rnd() * 3) + 1
        End If

        p.lust += 10

        If armor.Length > 0 Then
            armorIndex = armor(Int(Rnd() * (armor.Length)))
            p.inv.add(armorIndex, 1)
            EquipmentDialogBackend.equipArmor(p, p.inv.item(armorIndex).getAName, False)
        End If
        If weapon.Length > 0 Then
            weaponIndex = weapon(Int(Rnd() * (weapon.Length)))
            p.inv.add(weaponIndex, 1)
             EquipmentDialogBackend.weaponChange(p, p.inv.item(weaponIndex).getAName)
        End If

        Equipment.accChange(p, "Nothing")
    End Sub

    Shared Sub floor4FirstBossEncounter()
        TextEvent.push("Once you've plucked a key from the chest, a giggle from behind you stops you in your tracks." & DDUtils.RNRN &
                       "As you look back over your shoulder, the chest is swallowed and then dissolved by a blob of turquoise slime that rapidly makes its way towards you.  Drawing your weapon, you stash the key and prepare yourself for a fight!" & DDUtils.RNRN &
                       "Before you can attack, though, a large, gooey tendril shoots out and yanks your weapon from your hands.  Several smaller tentacles wrap around your limbs and pin you to the wall, as a final tendril flows into your mouth, gagging you." & DDUtils.RNRN &
                       """Well, well, well.  What do we have here?"", a slightly distorted female voice chuckles from somewhere behind you.", AddressOf floor4FirstBossEncounterP2)
    End Sub
    Shared Sub floor4FirstBossEncounterP2()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(147), "Suddenly, you find yourself being flipped upside down and dragged upwards to the ceiling, where you meet the translucent smug gaze of a teal woman made of slime." & DDUtils.RNRN &
                                                             "Her lower half seems to be a writhing mass of tentacles rooted firmly to the dungeon's roof, and closer inspection highlights a number of vaugely human-shaped bodies mixed in with the tendrils of slime.  Her curvy figure and mature demeanor set her apart as unique from any other goo girl you've encountered so far." & DDUtils.RNRN &
                                                             """I..."" the slime says, drawing your attention back to her, ""...am the Ooze Empress.  This fourth floor, and all who inhabit it, fall well under my control.""" & DDUtils.PAKTC, AddressOf floor4FirstBossEncounterP3)
    End Sub
    Shared Sub floor4FirstBossEncounterP3()
        Dim p As Player = Game.player1
        p.preBSBody = If(Transformation.canBeTFed(p), New State(p), p.pState.clone(p))
        Game.floor_4_starting_inv = New ArrayList()
        For i = 0 To p.inv.upperBound
            Game.floor_4_starting_inv.Add(p.inv.getCountAt(i))
        Next
        p.ongoingTFs.add(New RandoTF())
        p.update()
        p.sState.save(p)
        p.savePState()
        TextEvent.push("As she introduces herself, you find it harder and harder to focus.  Wherever her tentacles make direct contact, your body flushing with an overwhelming arousal." & DDUtils.RNRN &
                       "The heat slowly builds until you consumed with lust, and despite your best attempts you lose intrest in what your captor is saying, lost in the fog of your pleasure." & DDUtils.RNRN &
                       "A small giggle tells you that your distraction has not gone unnoticed." & DDUtils.RNRN &
                       """Enjoying yourself?"" the Empress asks, giving you a gentle shake, ""What you're feeling now is the powerful aphrodesiac that is mixed into my body.  Would you like a more intimate taste, little one?""" & DDUtils.RNRN &
                       "In your state, you don't even need to consider her offer.  After you give her a vigorous nod, the slime purrs ""Wonderful, darling, you seem like you could use a little relaxation."", plunging you into the mass of her tendrils." & DDUtils.RNRN &
                       "If the aphrodisiac was overwhelming before, being submmerged in it practically puts you in a horny coma.  Before passing out from the burning need flowing through every part of your body, you catch her motherly gaze as she giggles," & DDUtils.RNRN &
                       """Have fun!""", AddressOf floor4FirstBossEncounterP4)
    End Sub
    Shared Sub floor4FirstBossEncounterP4()
        Dim p = Game.player1
        TextEvent.push("When you come to, it's obvious some time has passed." & DDUtils.RNRN &
                       "Though the Emperess is nowhere to be found, the amount of slime she's left you drenched in still fills you with a bit of lust.  Your body... well, the body that you're currently inhabiting... still tingles with longing from your encounter." & DDUtils.RNRN &
                       "It seems you've woken up in the wrong body, and a quick pat down reveals that all of your belongings, including the key, are missing as well!" & DDUtils.RNRN &
                       "Hmm, at least the ooze didn't seem that" & If(p.className.Contains("Bimbo") Or p.className.Contains("Bimbo"), " malevolent...", ", like, mean...") & " maybe if you can find her again you can straighten this out?")
    End Sub
    Shared Sub floor4revert()
        Dim p As player = Game.player1
        p.preBSStartState.load(p)
        p.sState.save(p)
        p.preBSBody.load(p)
        p.pState.save(p)
        p.revertToPState()
        For i = 0 To Game.floor_4_starting_inv.Count - 1
            p.inv.add(i, Game.floor_4_starting_inv(i))
        Next
        p.canMoveFlag = True
        Game.lblEvent.Visible = False
        Game.player1 = p
        p.UIupdate()
    End Sub
    Shared Sub floor4keep()
        Dim p As player = Game.player1
        For i = 0 To Game.floor_4_starting_inv.Count - 1
            p.inv.add(i, Game.floor_4_starting_inv(i))
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
        Dim p As player = Game.player1
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
