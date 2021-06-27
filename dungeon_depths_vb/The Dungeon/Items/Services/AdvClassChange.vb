Public Class AdvClassChange
    Inherits Item

    Public Shared selectedClass As String = "Classless"
    Const COST As Integer = 5900

    Sub New()
        '|ID Info|
        setName("Advanced_Class_Change")
        id = 124
        tier = Nothing

        '|Item Flags|
        usable = True
        droppable = False
        rando_inv_allowed = False
        can_be_stolen = False
        onBuy = AddressOf teach

        '|Stats|
        count = 0
        value = COST

        '|Description|
        setDesc("""Not fulfilled by your current class?  With a little hypnosis and a well-placed spell, I can help you into a new, better vocation...""")
    End Sub

    Sub teach()
        count = 0

        Game.shopMenu.Close()
        Game.hideNPCButtons()

        If getClasses(Game.player1).Count < 1 Then
            Objective.showNPC(ShopNPC.npcLib.atrs(0).getAt(102), "Hmmm, it doesn't look like your current class meets the prerequisites for any advanced classes at the moment...")
            Game.player1.gold += COST
            Game.npcmode = False
            Exit Sub
        Else
            Game.toPNLSelec("AdvClassChange")
        End If
    End Sub

    Shared Sub hypnotizeP()
        Game.pushNPCDialog("Before we get started, I would like to make sure you really want this.  This lesson will permenantly change a core aspect of your personality for the forseeable future, afterall...", AddressOf warning)
    End Sub

    Shared Sub warning()
        Game.pushPnlYesNo("Start over as a " & selectedClass & "?", AddressOf tf, AddressOf cancel)
    End Sub
    Shared Sub cancel()
        Game.player1.gold += COST
        CType(Game.hteach, HypnoTeach).back()
    End Sub
    Shared Sub tf()
        CType(Game.hteach, HypnoTeach).hypnotize("Perfect!" & DDUtils.RNRN &
                                                 "Speaking of perfection, have you seen my pendant?  I know it is a bit cliched, but does seeing it swing back and forth not just relax you so... perfectly?" & DDUtils.RNRN &
                                                 "Back... and forth... watch it glisten in the light..." & DDUtils.RNRN &
                                                 "Feel yourself go deeper and deeper... deeper... and deeper... until you just..." & DDUtils.RNRN &
                                                 "*SNAP*" & DDUtils.RNRN &
                                                 "...drift away...", AddressOf tf2)
    End Sub
    Shared Sub tf2()
        Dim p = Game.player1

        Dim out = "As soon as she snaps, your entire reality fades away." & DDUtils.RNRN &
                   "You can't bother to recall who you are, or what you're doing, focusing instead solely on your mistresses' silky voice, though in your haze you don't understand much of what's being said." & DDUtils.RNRN &
                   "You pass in and out of conciousness several times until gradually you begin to regain your senses yet again." & DDUtils.RNRN &
                   getTF2Passage(p, selectedClass) & DDUtils.RNRN &
                   """Well then, it seems like my work here is done.  If I can help you with anything else, please do not hesitate to ask!"""

        Game.pushLblEvent(out, AddressOf CType(Game.hteach, HypnoTeach).back)

        p.changeClass(selectedClass)

        p.drawPort()
        p.UIupdate()
        p.savePState()
        p.sState.save(p)
    End Sub

    Shared Function getClasses(ByRef p As Player) As List(Of String)
        Dim l = New List(Of String)()

        If p.className.Equals("Mage") Or p.className.Equals("Cleric") Then l.Add("Warlock")
        If p.className.Equals("Warrior") Or p.className.Equals("Rogue") Then l.Add("Barbarian")
        If p.className.Equals("Warrior") Or p.className.Equals("Cleric") Then l.Add("Paladin")
        If p.className.Equals("Mage") Or p.className.Equals("Rogue") Then l.Add("Necromancer")

        For Each i In l
            If i = p.className Then l.Remove(i) : Exit For
        Next

        Return l
    End Function


    Shared Function getTF2Passage(ByRef p As Player, ByVal c As String) As String
        If c.Equals("Warlock") Then
            If p.inv.getCountAt("Warlock's_Robes") < 1 Then p.inv.add("Warlock's_Robes", 1)
            Equipment.clothesChange(p, "Warlock's_Robes")
            If p.inv.getCountAt("Ring_of_Uvona") < 1 Then p.inv.add("Ring_of_Uvona", 1)
            Equipment.accChange(p, "Ring_of_Uvona")

            Return """...for the last time, I am not interested in your cult!"" the hypnotist teacher states, sounding mildly annoyed." & DDUtils.RNRN &
                   "A cult?  Hardly...  While you're certainly in an arrangement with a deity, it isn't that of a goddess and her worshipper so much as that of a benefactor and their beneficiary.  Uvona, the Goddess of Fugue rarely calls on you to cash in any favors, though when she does it's even rarer that you remember them.  Are there cults devoted to Uvona?  Probably, but you would never-"
        ElseIf c.Equals("Barbarian") Then
            If p.inv.getCountAt("Barbarian_Armor") < 1 Then p.inv.add("Barbarian_Armor", 1)
            Equipment.clothesChange(p, "Barbarian_Armor")
            If p.inv.getCountAt("Corse_War_Axe") < 1 Then p.inv.add("Corse_War_Axe", 1)
            Equipment.weaponChange(p, "Corse_War_Axe")

            Return """...and then we met!  Are you sure you're feeling alright?  Ever you fought off that dragon you've been a little strange..."" the teacher asks, sounding slightly concerned." & DDUtils.RNRN &
                   "Fought a dragon!?  While that sounds like something you'd do, you don't remember it at all...  All the same, you tell this strange, yet beautiful lady that you're fine.  Twirling your heavy weapon deftly, you announce that you've never felt better!"
        Else
            Return """...annnd one.  Wake up now, little " & selectedClass.ToLower & ".  Are you well?  You look a bit confused..."" the teacher asks, stowing something in her pocket and adjusting her glasses.  While it does seem like something has changed, you can't put your finger on it.  You are " & p.getName & " the " & p.className & ", same as you've always been.  Groggily, you tell her that you're fine and just a little dizzy."
        End If
    End Function
End Class
