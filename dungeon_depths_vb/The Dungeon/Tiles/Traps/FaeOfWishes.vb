Public Class FaeOfWishes
    Inherits Trap

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.faeofwishes
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(105), """Hi there!  I'm the fae of wishes, and you've just won a free wish!""" & DDUtils.RNRN &
                                                              "Press any non-movement key to continue...", AddressOf displayDialog)
    End Sub

    Private Shared Sub storeWishes(ByRef s As String)
        Dim i = Game.player1.perks(perk.faewishesmade)
        If i = -1 Then i = 1

        Select Case s
            Case "Healing"
                i *= 2
            Case "Restoration"
                i *= 3
            Case "Gold"
                i *= 5
            Case "Food"
                i *= 7
            Case "Skills"
                i *= 11
            Case "Strength"
                i *= 13
            Case "Friendship"
                i *= 17
        End Select

        Game.player1.perks(perk.faewishesmade) = i
    End Sub
    Private Shared Function madeWish(ByRef s As String) As Boolean
        Dim i = Game.player1.perks(perk.faewishesmade)
        If i = -1 Then Return False

        Select Case s
            Case "Healing"
                Return i Mod 2 = 0
            Case "Restoration"
                Return i Mod 3 = 0
            Case "Gold"
                Return i Mod 5 = 0
            Case "Food"
                Return i Mod 7 = 0
            Case "Skills"
                Return i Mod 11 = 0
            Case "Strength"
                Return i Mod 13 = 0
            Case "Friendship"
                Return i Mod 17 = 0
        End Select

        Return False
    End Function
    Sub displayDialog()
        Dim wishes As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))()

        Dim heal = New Tuple(Of String, Action)("Healing", AddressOf FaeOfWishes.heal)
        Dim restoration = New Tuple(Of String, Action)("Restoration", AddressOf FaeOfWishes.restoration)
        Dim gold = New Tuple(Of String, Action)("Gold", AddressOf FaeOfWishes.gold)
        Dim food = New Tuple(Of String, Action)("Food", AddressOf FaeOfWishes.food)
        Dim skills = New Tuple(Of String, Action)("Skills", AddressOf FaeOfWishes.skills)
        Dim stronger = New Tuple(Of String, Action)("Strength", AddressOf FaeOfWishes.stronger)
        Dim friendship = New Tuple(Of String, Action)("Friendship", AddressOf FaeOfWishes.friendship)

        wishes.Add(heal)
        wishes.Add(restoration)
        If Not madeWish("Gold") Then wishes.Add(gold)
        wishes.Add(food)
        If Not madeWish("Skills") Then wishes.Add(skills)
        If Not madeWish("Strength") Then wishes.Add(stronger)
        If Not madeWish("Friendship") Then wishes.Add(friendship)

        TextEvent.pushManySelect("Wish for what?", wishes)
    End Sub

    Shared Sub heal()
        Dim p As Player = Game.player1

        p.health = 1.0
        p.mana = p.getMaxMana
        p.stamina = 100

        p.UIupdate()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(106), "That's an easy one!  Consider your wish granted.")
        If Not madeWish("Healing") Then storeWishes("Healing")
    End Sub
    Shared Sub restoration()
        Dim p As Player = Game.player1

        p.revertToSState()

        p.drawPort()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(106), "That's an easy one!  Consider your wish granted.")
        If Not madeWish("Restoration") Then storeWishes("Restoration")
    End Sub
    Shared Sub gold()
        Dim p As Player = Game.player1

        p.inv.add(SwashMagicEPatch.ITEM_NAME, 1)
        EquipmentDialogBackend.equipGlasses(p, SwashMagicEPatch.ITEM_NAME, False)

        p.drawPort()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(106), """Hmmm...  Gold..." & DDUtils.RNRN &
                                                              "Oh, you know who gets a lot of gold?  Pirates!  You could use this snazzy pirate trick to get more gold!""" & DDUtils.RNRN &
                                                              "+1 " & SwashMagicEPatch.ITEM_NAME)
        If Not madeWish("Gold") Then storeWishes("Gold")
    End Sub
    Shared Sub food()
        Dim p As Player = Game.player1

        p.inv.add(Orange.ITEM_NAME, 50)

        p.UIupdate()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(106), """Yeah, I guess you would need to eat sooner or later...  Consider your wish granted!""" & DDUtils.RNRN &
                                                              "+50 Oranges")
        If Not madeWish("Food") Then storeWishes("Food")
    End Sub
    Shared Sub skills()
        Dim p As Player = Game.player1

        p.inv.add(PirateHandbook.ITEM_NAME, 1)

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(106), """More skills?  I'm not really sure where I would get-" & DDUtils.RNRN &
                                                              "OH!" & DDUtils.RNRN &
                                                              "Check this handbook out!  You could definitely learn a thing or two from the high seas...""" & DDUtils.RNRN &
                                                              "+1 " & PirateHandbook.ITEM_NAME)
        If Not madeWish("Skills") Then storeWishes("Skills")
    End Sub
    Shared Sub stronger()
        Dim p As Player = Game.player1

        p.inv.add(Eyepatch.ITEM_NAME, 1)
        p.inv.add(AttackCharm.ITEM_NAME, 2)

        EquipmentDialogBackend.equipGlasses(p, "Eyepatch", False)
        p.drawPort()

        p.changeClass("Pirate")

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(106), """So you want to be stronger, eh?" & DDUtils.RNRN &
                                                              "Well, there's nothing stronger than a warrior of the sea!" & DDUtils.RNRN &
                                                              "..." & DDUtils.RNRN &
                                                              "Right?""" & DDUtils.RNRN &
                                                              "+1 " & Eyepatch.ITEM_NAME & vbCrLf &
                                                              "+2 " & AttackCharm.ITEM_NAME)
        If Not madeWish("Strength") Then storeWishes("Strength")
    End Sub
    Shared Sub friendship()
        Dim p As Player = Game.player1

        p.inv.add(LanceOfSFury.ITEM_NAME, 50)

        p.UIupdate()

        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(106), "Friendship...  That's a tricky one, hmm..." & DDUtils.RNRN &
                                                              "Well, I can't just make people like you.  But- hey, a really good weapon is kind of like a friend... right?" & DDUtils.RNRN &
                                                              "That's what Miss Cynn says, at least...""" & DDUtils.RNRN &
                                                              "+1 " & LanceOfSFury.ITEM_NAME)
        If Not madeWish("Friendship") Then storeWishes("Friendship")
    End Sub
End Class
