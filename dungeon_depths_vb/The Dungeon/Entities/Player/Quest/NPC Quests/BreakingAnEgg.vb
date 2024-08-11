Public Class BreakingAnEgg
    Inherits Quest

    Sub New()
        MyBase.New("Breaking an Egg")

        quest_index = qInd.banEgg

        objectives.Add(New BEggGetSword)
    End Sub

    Public Overrides Sub init()
        MyBase.init()

        Dim out As String = """Hey " & If(Game.player1.sex.Equals("Male"), "guy", "you") & ", d'ya mind doing me a favor?" & DDUtils.RNRN &
                            "I've been scouting ahead, and I can give my menu an overhaul if I can deal with some of the bigger mosters that are roaming around.  I need a better weapon for that, though.  There's this cursed sword floating around on floor 2, think you can track it down?" & DDUtils.RNRN &
                            "Trust me, I've got the psychic chops to handle its... well... psychic chops.""" & DDUtils.RNRN &
                            "Quest 'Breaking an Egg' acquired!"
        If Game.player1.inv.getCountAt(TargaxSword.ITEM_NAME) > 0 Then
            TextEvent.pushNPCDialog(out & "  Press any non-movement key to continue...", AddressOf immediateComplete)
        Else
            TextEvent.pushNPCDialog(out)
        End If
    End Sub

    Private Sub immediateComplete()
        Game.leaveNPC()

        Game.picNPC.BackgroundImage = ShopNPC.gbl_img.atrs(0).getAt(11)
        Game.picNPC.Visible = True

        TextEvent.pushNPCDialog("""Woah, is that it in your pack now?  You sure you want to hand 'er over?""" & DDUtils.PAKTC, AddressOf complete2)
    End Sub

    Private Sub complete2()
        TextEvent.pushYesNo("Turn over the sword?", AddressOf complete3, AddressOf Objective.fromNPC)
    End Sub

    Private Sub complete3()
        Game.player1.inv.add(TargaxSword.ITEM_NAME, -1)
        If Game.player1.equippedWeapon.getAName.Equals(TargaxSword.ITEM_NAME) Then EquipmentDialogBackend.equipWeapon(Game.player1, "Fists", False)

        Game.player1.perks(perk.fvHasSword) = 1
        Game.player1.addXP(1000)
        completeEntireQuest()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(11), """Nice, thanks!  Give me a sec, I'll have all sorts of new stuff to try in a little bit.""" & DDUtils.RNRN &
                                                             "+1000 XP" & DDUtils.PAKTC, AddressOf Game.leaveNPC)
    End Sub
    Public Overrides Function canGet() As Boolean
        Return Not getActive() And Game.currFloor.floorNumber > 3 And Not getComplete() And Not Game.player1.perks(perk.fvHasSword) > 0
    End Function
End Class

Friend Class BEggGetSword
    Inherits Objective

    Sub New()
        MyBase.New("Collect the " & New TargaxSword().getAName & ".")
    End Sub

    Public Overrides Sub complete()
        MyBase.complete()

        Game.picNPC.BackgroundImage = ShopNPC.gbl_img.atrs(0).getAt(11)
        Game.picNPC.Visible = True

        TextEvent.pushNPCDialog("Hey, awesome!  You sure you just want to hand 'er over?", AddressOf complete2)
    End Sub
    Private Sub complete2()
        TextEvent.pushYesNo("Turn over the sword?", AddressOf complete3, AddressOf fromNPC)
    End Sub
    Private Sub complete3()
        If Game.shop_npc_engaged Then Game.leaveNPC()

        Game.player1.inv.add(TargaxSword.ITEM_NAME, -1)
        If Game.player1.equippedWeapon.getAName.Equals(TargaxSword.ITEM_NAME) Then EquipmentDialogBackend.equipWeapon(Game.player1, "Fists", False)

        Game.player1.perks(perk.fvHasSword) = 1
        Game.player1.addXP(1000)
        showNPC(ShopNPC.gbl_img.atrs(0).getAt(11), """Nice, thanks!  Stop by the ol' stand when you get the chance, I'll have all sorts of new stuff to try.""" & DDUtils.RNRN &
                                                  "+1000 XP")
    End Sub

    Shared Sub completeStep()
        If Not Game.player1.quests(qInd.banEgg).getActive Then Exit Sub

        Dim obj = New BEggGetSword

        Game.shopMenu.Close()

        obj.complete3()
    End Sub
    Public Overrides Function getDesc() As String
        Return description & "  [" & Game.player1.inv.getCountAt(New TargaxSword().getAName) & "/1]"
    End Function

    Public Overrides Function isComplete() As Boolean
        Return Game.player1.inv.getCountAt(24) > 0 And (Game.player1.pos.X <> Game.fvend.pos.X Or Game.player1.pos.Y <> Game.fvend.pos.Y)
    End Function
End Class

