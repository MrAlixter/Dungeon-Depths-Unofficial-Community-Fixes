Public Class ShadyWizard
    Inherits ShopNPC
    Sub New()
        name = "Shady Wizard"
        health = (1.0)
        maxHealth = (9999)
        attack = (999)
        defense = (99)
        speed = (99)
        'Define the inventory
        inv = New Inventory(False)
        'Useables
        inv.setCount("Spellbook", 1)
        inv.setCount("Mana_Charm", 1)
        'Potions
        inv.setCount("Mana_Potion", 1)

        'Foods
        inv.setCount("Apple​", 1)
        inv.setCount("Angel_Food_Cake", 1)
        inv.setCount("Stick_of_Gum", 1)
        inv.setCount("Berry_Stick_of_Gum", 1)
        inv.setCount("Melon_Stick_of_Gum", 1)

        'Armors
        inv.setCount("Bronze_Bikini", 1)
        inv.setCount("Bunny_Suit", 1)
        inv.setCount("Witch_Cosplay", 1)
        inv.setCount("Brawler_Cosplay", 1)
        inv.setCount("Cowbell", 1)
        inv.setCount("Crystalline_Armor", 1)

        'Weapons
        inv.setCount("Duster", 1)
        inv.setCount("Scepter_of_Ash", 1)

        isShop = True
        gold = 99999
        pronoun = "he"
        pPronoun = "his"
        rPronoun = "him"
        picNormal = ShopNPC.npcLib.atrs(0).getAt(6)
        picPrincess = ShopNPC.npcLib.atrs(0).getAt(8)
        picBunny = ShopNPC.npcLib.atrs(0).getAt(7)
        picArachne = ShopNPC.npcLib.atrs(0).getAt(68)

        picNPC = New List(Of Image)
        picNPC.AddRange({picNormal, ShopNPC.npcLib.atrs(0).getAt(4), ShopNPC.npcLib.atrs(0).getAt(5), picPrincess, picBunny})

        picNPC.AddRange({ShopNPC.npcLib.atrs(0).getAt(9),
                         picArachne,
                         ShopNPC.npcLib.atrs(0).getAt(90),
                         ShopNPC.npcLib.atrs(0).getAt(96)})
        If speed = Game.player1.speed Then speed -= 1
        title = " the "
    End Sub

    Public Overrides Sub encounter()

        If Game.mDun.numCurrFloor < 3 Then
            inv.setCount("Scale_Bikini", 1)
        Else
            inv.setCount("Gold_Adornment", 1)
        End If

        MyBase.encounter()

        MyBase.discount = 0

        If npcIndex = 0 Then
            If CInt(Game.player1.health * Game.player1.getMaxHealth()) = 69 Then
                Game.pushNPCDialog("Ehehe. Your health. Nice." & vbCrLf & "Anyway, what are you buying?")
            Else
                Game.pushNPCDialog("What are you buying?")
            End If
        ElseIf npcIndex = 1 Then
            Game.pushNPCDialog("Ribbit.  Ribbit!")
        ElseIf npcIndex = 2 Then
            Game.pushNPCDialog("*bleets*")
        ElseIf npcIndex = 3 Then
            Game.pushNPCDialog("Hey, " & Game.player1.className & ", how's it going?")
        ElseIf npcIndex = 4 Then
            Game.pushNPCDialog("So are these real or fake?  My ears, I mean.")
        ElseIf npcIndex = 5 Or npcIndex = 8 Then
            Game.pushNPCDialog("...")
        ElseIf npcIndex = 7 Then
            Game.pushNPCDialog("Damn it, and I set aside the extra-skimpy bikini for this too...")
        ElseIf npcIndex = 6 Then
            If Game.player1.formName.Equals("Arachne") And Game.player1.equippedArmor.getAntiSlutVarInd > 0 Then
                Game.pushNPCDialog("Ooh, darling, are you the one who laid that snare?  Aren't you a cutie...")
            ElseIf Game.player1.formName.Equals("Arachne") And Game.player1.equippedArmor.getSlutVarInd > 0 Then
                Game.pushNPCDialog("Ooh, darling, are you the one who laid that snare?  You know, you could spice your look up a bit...")
            ElseIf Game.player1.formName.Equals("Arachne") Then
                Game.pushNPCDialog("Ooh, darling, are you the one who laid that snare?  Let me know if you'd like any tips on your bondage technique...")
            Else
                Game.pushNPCDialog("Ooh, darling, you should really give the whole ""8-Legs"" thing a chance... I have a more...potent...venom if you'd like...")
            End If
        End If

        If npcIndex = getArachneImageInd() And Not Game.player1.formName.Equals("Arachne") Then inv.setCount(244, 1) Else inv.setCount(244, 0)
    End Sub

    Public Overrides Function toFight() As String
        If npcIndex = 0 Or npcIndex = 7 Then
            Return "Alright, get ready to fight.  This ain't going well for you."
        ElseIf npcIndex = 1 Then
            Return "Ribbit . . ."
        ElseIf npcIndex = 2 Then
            Return "BAAAAAHHHH!"
        ElseIf npcIndex = 3 Then
            Return "Get ready, I was trained by the royal mage's guild and I certainly won't submit easily."
        ElseIf npcIndex = 4 Then
            Return "Whaaaat!?!"
        ElseIf npcIndex = 5 Or npcIndex = 8 Then
            Return "..."
        ElseIf npcIndex = 6 Then
            Game.pushNPCDialog("*tsk* *tsk* *tsk* Not too bright...")
        End If
        Return "Bad move."
    End Function
    Public Overrides Function hitBySpell() As String
        If npcIndex = 0 Or npcIndex = 7 Then
            Game.NPCtoCombat(Me)
            Return "Ha!  That's just sloppy."
        ElseIf npcIndex = 1 Then
            Game.NPCtoCombat(Me)
            Return "Ribbit!!!"
        ElseIf npcIndex = 2 Then
            Game.NPCtoCombat(Me)
            Return "[angry bleets]!"
        ElseIf npcIndex = 3 Then
            Game.NPCtoCombat(Me)
            Return "I've seen better spellwork, but that was a decent attempt."
        ElseIf npcIndex = 4 Then
            Return "That's neat!"
        ElseIf npcIndex = 5 Or npcIndex = 8 Then
            Return "..."
        ElseIf npcIndex = 6 Then
            Game.NPCtoCombat(Me)
            Game.pushNPCDialog("Oooh, is that really your best?  Adorable...")
        End If
        Return "Woah there!"
    End Function

    Public Overrides Sub toFemale(form As String)
        MyBase.toFemale(form)
        setName("Shady Witch")
    End Sub
    Public Overrides Sub toMale(form As String)
        MyBase.toMale(form)
        setName("Shady Wizard")
    End Sub

    Public Overrides Sub toDoll()
        MyBase.toDoll()
        MyBase.npcIndex = 5
        isShop = False
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.fromCombat()
        Dim out = "You collapse to the ground, the wizard's onslaught wearing down your last defenses.  Twirling " & pPronoun & " staff, they fire off one final blast, and as it hits your lifeforce...surges?  Startled, you notice that your body is coursing with magical energy, far more than you were capable of mustering before.  You spring back to your feet, resuming a fighting stance though your confusion over this turn of events has you puzzled enough to hold off on attacking." & DDUtils.RNRN &
                  """Give it a sec,"" " & pronoun & " states, ""Or don't.  I don't really care.""" & DDUtils.RNRN &
                  "You desperatly lunge at them, the flood of mana coursing through you still increasing, and before you can take three steps your body shrinks with a sudden jolt, leaving you looking at a far larger world.  The energy within you seems to have only been focused by your diminished stature.  Its electric flow overwhelms you, and you see small crystals of pure mana begining to form on your arms.  You try to flee, but your now giant opponent simply places the crook of their staff around you.  Escape no longer an option, you can do nothing but cower as the crystals swiftly replace your flesh and bone.  Nothing more than a gem full of magical energy now, you can't even react as the wizard raises their staff to inspect you."
        Game.picPortrait.BackgroundImage = Game.picStaffEnd.BackgroundImage
        Game.pushLblEvent(out, AddressOf SWizDeath2)
    End Sub
    Sub SWizDeath2()
        Dim p = Game.player1

        Game.fromCombat()
        Dim out = """Wow, you're in there good,"" they remark.  ""Geez, looks like somehow you got embeded in the wood.  I'm not walking around with a loser like you in one of my products.  You didn't even make that good of a crystal!  If I want to sell this now, I'm going to need to make you more...eyecatching.""" & DDUtils.RNRN &
                  pronoun & " snaps " & rPronoun & " fingers, and though you can not see it your body is instantly changed to that of an incredibly busty, nude young woman." & DDUtils.RNRN &
                  """Now that's a look that will draw in customers.  I might have to make more of these, assuming I can find a couple more shmucks like you!  I wonder what that food guy is up to...""" & DDUtils.RNRN &
                  "GAME OVER!"
        Game.picPortrait.BackgroundImage = Game.picStaffEnd.BackgroundImage
        Game.pushLblEvent(out, AddressOf p.die)
    End Sub
End Class
