Public Class JunkChime
    Inherits Item

    Public Const ITEM_NAME As String = "Junk_Chime"
    Dim target As Player

    Dim fae_woods_dialog_sections As List(Of Action) = New List(Of Action)({AddressOf FaeWoodsQ1A.askForApology, AddressOf FaeWoodsQ1A.askForClass, AddressOf FaeWoodsQ1A.askForName, AddressOf FaeWoodsQ1A.askForNameAgain,
                                                                            AddressOf FaeWoodsQ1A.askForNameAlternate, AddressOf FaeWoodsQ1A.BimboTFEnd, AddressOf FaeWoodsQ1A.ClericTFEnd, AddressOf FaeWoodsQ1A.declineToGiveName1,
                                                                            AddressOf FaeWoodsQ1A.declineToGiveName2, AddressOf FaeWoodsQ1A.fairyDustEnd, AddressOf FaeWoodsQ1A.giveApology, AddressOf FaeWoodsQ1A.giveName,
                                                                            AddressOf FaeWoodsQ1A.giveTitle, AddressOf FaeWoodsQ1A.RebelEnd, AddressOf FaeWoodsQ1A.refuseApology})

    Public Shared inv As Inventory
    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 436
        tier = Nothing

        '|Item Flags|
        usable = True
        only_drop_one = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 4

        '|Description|
        setDesc("A small, dinged-up piece of metal that rings out a melodic note when struck.  It seems to glint unnaturally in the dungeon's ambient light.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        If Game.currFloor.floorNumber = 13 AndAlso Not inv Is Nothing Then
            Dim quit As Boolean = False

            If fae_woods_dialog_sections.Contains(TextEvent.lblEventOnClose) OrElse fae_woods_dialog_sections.Contains(TextEvent.yesAction) OrElse fae_woods_dialog_sections.Contains(TextEvent.noAction) Then
                Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(167), """Alright, chief, here's-""" & DDUtils.RNRN &
                                                                      "The Fairy within the " & getName().Replace("_", " ") & " pauses, looking to the other fae you're talking too." & DDUtils.RNRN &
                                                                      """HEY!  WE'RE TRYIN' TO DO BUSINESS HERE!  SCRAM!""", AddressOf FaeWoodsQ1A.altCompleteEntireQuest)
                quit = True
            ElseIf p.formName = "Horse" Or p.formName = "Unicorn" Then
                TextEvent.push("The Fairy within the " & getName().Replace("_", " ") & " seems to be ignoring you...")
                quit = True
            End If

            If quit Then Exit Sub
        End If

        If inv Is Nothing Then
            inv = New Inventory()
            TextEvent.push("You ring the chime, but nothing happens... so you ring it again... and again, and again." & DDUtils.RNRN &
                           "With small *poof*, and a string of curses, a tiny fairy pops into being beside the chime...", AddressOf introToThistle)
        ElseIf Not Game.shop_npc_engaged Then
            Dim profit As Integer = 0
            Dim ct As Integer = 0

            For i = 0 To p.inv.count - 1
                If p.inv.item(i).getName().Contains(p.equippedArmor.getName()) Or p.inv.item(i).getName().Contains(p.equippedWeapon.getName()) Or p.inv.item(i).getName().Contains(p.equippedAcce.getName()) Or p.inv.item(i).getName().Contains(p.equippedGlasses.getName()) Then
                    If p.inv.item(i).getCount > 1 And inv.item(i).getCount > 0 Then
                        profit += (p.inv.item(i).getCount - 1 * p.inv.item(i).value * 0.45) / 2
                        p.inv.setCount(i, 1)
                        ct += 1
                    End If
                Else
                    If p.inv.item(i).getCount > 0 And inv.item(i).getCount > 0 Then
                        profit += (p.inv.item(i).getCount * p.inv.item(i).value * 0.45) / 2
                        p.inv.setCount(i, 0)
                        ct += 1
                    End If
                End If
            Next

            If profit = 0 And ct > 0 Then
                Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(166), """Sorry, chief.  Nothing here worth sellin', so I tossed that crap in a river.""")
            ElseIf profit = 0 Then
                Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(166), """Sorry, chief.  Nothing here to sell.""")
            Else
                p.gold += profit
                Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(165), """Alright, chief, here's your cut.""" & DDUtils.RNRN &
                                  "+" & profit & " gold!")
            End If
        Else
            TextEvent.pushAndLog("The Fairy within the " & getName().Replace("_", " ") & " seems to be ignoring you...")
        End If
    End Sub

    Private Sub introToThistle()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(167), """What's goin' on out here, eh?  You just like ringin' bells or-""" & DDUtils.RNRN &
                                                              "The fairy snaps to look up at you with, seemingly puzzled." & DDUtils.RNRN &
                                                              """Well- uh... you're new...""", AddressOf introToThistle2)
    End Sub
    Private Sub introToThistle2()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(164), """I guess it doesn't really matter as long as you've got junk to sell too...""" & DDUtils.RNRN &
                                                              "With a clap of her hands, her sour expression turns to a cheeky grin." & DDUtils.RNRN &
                                                              """Alright!  So here's how this works." & DDUtils.RNRN &
                                                              "You- give me- the crap you don't want.  I take it- sell it on the black market- and then give you... 45%."" she says." & DDUtils.RNRN &
                                                              """Anywhere, anytime, by the way- you're gettin' a good deal.  Like, no more wanderin' around tryin' to find a shop.  You just ring the chime, and I'll take care of it.""", AddressOf introToThistle3)
    End Sub
    Private Sub introToThistle3()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(164), """I'll keep one of each of the items you don't want- you can take 'em back whenever.  If you need to talk to me about that, just Inspect this chime." & DDUtils.RNRN &
                                                              "Remember- Inspect to change the list; Use to sell your junk." & DDUtils.RNRN &
                                                              "So, what do ya got for me?""", AddressOf changeInv)
    End Sub

    Public Overrides Function getDescription()
        If inv Is Nothing Then
            Return MyBase.getDescription
        Else
            Return MyBase.getDescription & DDUtils.RNRN &
                   """Use"" will sell all items in the player's inventory that have been given to the fairy.  ""Inspect"" will allow changes to the list of given items."
        End If
    End Function
    Public Overrides Sub examine()
        If durability > 99 And Not inv Is Nothing Then
            TextEvent.push(getDescription() & DDUtils.RNRN &
                           "You hear the fairy within asking if you want to make any changes to her list...", AddressOf changeInv)
        ElseIf Not inv Is Nothing Then
            TextEvent.push(getDescription() & DDUtils.RNRN &
                           "You hear the fairy within asking if you want to make any changes to her list..." & DDUtils.RNRN &
                           "Durability: " & durability & " (Breaks at 0)", AddressOf changeInv)
        Else
            MyBase.examine()
        End If
    End Sub
    Private Sub changeInv()
        If inv Is Nothing Then inv = New Inventory()

        Dim menu = ThistleMenuV3
        menu.ShowDialog()
        'If Game.floor_4_starting_inv.Count > 0 Then
        '    menu.txtDesc.Text = """Woah..."" says the fairy, ""We doin' some fraud today?"""
        'End If

        menu.Dispose()
    End Sub
End Class
