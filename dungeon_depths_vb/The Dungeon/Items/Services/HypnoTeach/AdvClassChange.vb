Public Class AdvClassChange
    Inherits HypnoService

    Public Const ITEM_NAME As String = "Advanced_Class_Change"
    Public Const COST As Integer = 5900

    Public Shared selected_class As String = "Classless"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 124
        tier = Nothing

        '|Item Flags|
        usable = True
        droppable = False
        rando_inv_allowed = False
        can_be_stolen = False
        onBuy = Sub() teach(h_ind.classchange)

        '|Stats|
        count = 0
        value = COST

        '|Description|
        setDesc("""Not fulfilled by your current class?  With a little hypnosis and a well-placed spell, I can help you into a new, better vocation...""")
    End Sub

    Protected Overrides Function passesPreCheck(ByRef p As Player) As Boolean
        If Not canHypnotize(p) Then
            failToHypno(p, False)
            TextEvent.pushNPCDialog("Unfortunately, your current class does not meet the prerequisites for any advanced classes.")
            Return False
        End If

        Return True
    End Function

    '| - OUTCOMES - |
    Protected Overrides Function doHypnosis(ByRef plr As Player, ByVal i As h_ind, Optional ByVal hypnoDesc As String = "") As Boolean
        Game.toPNLSelec("AdvClassChange")

        Return True 'MyBase.doHypnosis(plr, i, hypnoDesc)
    End Function
    Protected Overrides Sub doTrigger(ByRef p As Player, ByVal i As h_ind)
        'Don't do anything
    End Sub
    Protected Overrides Sub wakeup(ByRef p As Player, Optional ByVal noticedChanges As String = "")
        Dim out = "As soon as she snaps, your entire reality fades away." & DDUtils.RNRN &
                   "You can't bother to recall who you are, or what you're doing, focusing instead solely on your mistresses' silky voice, though in your haze you don't understand much of what's being said." & DDUtils.RNRN &
                   "You pass in and out of conciousness several times until gradually you begin to regain your senses yet again." & DDUtils.RNRN &
                   getWakeupPassage(p, selected_class) & DDUtils.RNRN &
                   """Well then, it seems like my work here is done.  If I can help you with anything else, please do not hesitate to ask!"""

        TextEvent.push(out, AddressOf CType(Game.hteach, HypnoTeach).back)

        HypnosisEffect.trigger(p, h_ind.classchange, selected_class)

        p.drawPort()
        p.UIupdate()
        p.savePState()
        p.sState.save(p)
    End Sub

    '| - MISC - |
    Protected Overrides Function canHypnotize(ByRef p As Player) As Boolean
        Return getClasses(Game.player1).Count > 0
    End Function

    '| - TRANSFORMATION - |
    Shared Sub hypnotizeP()
        TextEvent.pushNPCDialog("""Before we get started, I would like to confirm that you understand your selection.  This lesson will alter who you are now, and how you remember your 'original' self...""" & DDUtils.PAKTC, AddressOf warning)
    End Sub
    Shared Sub warning()
        TextEvent.pushYesNo("Become a " & selected_class & "?", AddressOf tf, AddressOf cancel)
    End Sub
    Shared Sub cancel()
        Game.player1.gold += getRefundAmount(Game.hteach, COST)
        CType(Game.hteach, HypnoTeach).back()
    End Sub

    Shared Sub tf()
        Dim p = Game.player1
        CType(Game.hteach, HypnoTeach).hypnotize(getHypnoDesc(p), p, h_ind.classchange, Sub() CType(p.inv.item(ITEM_NAME), AdvClassChange).wakeup(p))
    End Sub

    Shared Function getClasses(ByRef p As Player) As List(Of String)
        Dim l = New List(Of String)()

        If p.className.Equals("Mage") Or p.className.Equals("Cleric") Then l.Add("Warlock")
        If p.className.Equals("Warrior") Or p.className.Equals("Rogue") Then l.Add("Barbarian")
        If p.className.Equals("Warrior") Or p.className.Equals("Cleric") Then l.Add("Paladin")
        If p.className.Equals("Mage") Or p.className.Equals("Rogue") Then l.Add("Necromancer")
        If p.className.Equals("Bimbo") Or p.className.Equals("Maid") Or p.className.Equals("Bunny Girl") Or p.className.Equals("Maiden") Then l.Add("Battlemaiden")

        For Each i In l
            If i = p.className Then l.Remove(i) : Exit For
        Next

        Return l
    End Function

    Shared Function getWakeupPassage(ByRef p As Player, ByVal c As String) As String
        If c.Equals("Warlock") Then
            If p.inv.getCountAt("Warlock's_Robes") < 1 Then p.inv.add("Warlock's_Robes", 1)
            EquipmentDialogBackend.armorChange(p, "Warlock's_Robes")
            If p.inv.getCountAt("Ring_of_Uvona") < 1 Then p.inv.add("Ring_of_Uvona", 1)
            Equipment.accChange(p, "Ring_of_Uvona")
            Return """...for the last time, I am not interested in your cult!"" the hypnotist teacher states, sounding mildly annoyed." & DDUtils.RNRN &
                   "A cult?  Hardly...  While you're certainly in an arrangement with a deity, it isn't that of a goddess and her worshipper so much as that of a benefactor and their beneficiary.  Uvona, the Goddess of Fugue rarely calls on you to cash in any favors, though when she does it's even rarer that you remember them.  Are there cults devoted to Uvona?  Probably, but you would never-"

        ElseIf c.Equals("Barbarian") Then
            If p.inv.getCountAt("Barbarian_Armor") < 1 Then p.inv.add("Barbarian_Armor", 1)
            EquipmentDialogBackend.armorChange(p, "Barbarian_Armor")
            If p.inv.getCountAt("Corse_War_Axe") < 1 Then p.inv.add("Corse_War_Axe", 1)
            EquipmentDialogBackend.weaponChange(p, "Corse_War_Axe")
            Return """...and then we met!  Are you sure you're feeling alright?  Ever you fought off that dragon you've been a little strange..."" the teacher asks, sounding slightly concerned." & DDUtils.RNRN &
                   "Fought a dragon!?  While that sounds like something you'd do, you don't remember it at all...  All the same, you tell this strange, yet beautiful lady that you're fine.  Twirling your heavy weapon deftly, you announce that you've never felt better!"

        ElseIf c.Equals("Necromancer") Then
            If p.inv.getCountAt("Necromancer's_Robes") < 1 Then p.inv.add("Necromancer's_Robes", 1)
            EquipmentDialogBackend.armorChange(p, "Necromancer's_Robes")

        ElseIf c.Equals("Paladin") Then
            If p.inv.getCountAt("Paladin's_Armor") < 1 Then p.inv.add("Paladin's_Armor", 1)
            EquipmentDialogBackend.armorChange(p, "Paladin's_Armor")

        ElseIf c.Equals("Battlemaiden") Then
            If p.inv.getCountAt("Maid's_Armor") < 1 Then p.inv.add("Maid's_Armor", 1)
            EquipmentDialogBackend.armorChange(p, "Maid's_Armor")
            If p.inv.getCountAt("Featherlight_Rapier") < 1 Then p.inv.add("Featherlight_Rapier", 1)
            EquipmentDialogBackend.weaponChange(p, "Featherlight_Rapier")

        End If

        Return """...annnd one.  Wake up now, little " & selected_class.ToLower & ".  Are you well?  You look a bit confused..."" the teacher asks, stowing something in her pocket and adjusting her glasses.  While it does seem like something has changed, you can't put your finger on it.  You are " & p.getName & " the " & p.className & ", same as you've always been.  Groggily, you tell her that you're fine and just a little dizzy."
    End Function
End Class
