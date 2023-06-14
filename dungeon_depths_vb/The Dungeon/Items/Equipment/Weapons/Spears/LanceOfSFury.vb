Public Class LanceOfSFury
    Inherits Spear

    Public Enum mode
        normal
        bimbo
    End Enum

    Public Const ITEM_NAME As String = "Lance_of_Scarlet_Fury"

    Public Shared current_mode As mode = mode.normal

    Shared happy As Image = Nothing
    Shared annoy As Image = Nothing
    Shared cast1 As Image = Nothing
    Shared cast2 As Image = Nothing

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 362
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        a_boost = 40
        s_boost = -10
        count = 0
        value = 3900

        '|Description|
        setDesc("An impressive spear made of a brilliant platinum alloy.  It glows with a shimmering crimson aura as your hand approaches, and it almost feels as though you are being judged.  Once in your grip, burning runes dance along its length." & DDUtils.RNRN &
                "This was the favored weapon of Cynthia, Archangel Paladin." & DDUtils.RNRN &
                "More likely to hit critically than a sword, but also more likely to miss altogether." & DDUtils.RNRN &
                "Can be thrown using the ""Use"" button." & DDUtils.RNRN &
                getStatInformation())

        '|Misc|
        setImg(current_mode)
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        If Not p.perks(perk.metcynthia) > -1 And Not Game.combat_engaged Then
            TextEvent.push("As you equip the Lance, blazing runes begin to dance along its length.  You toss it aside to avoid getting burned!" & DDUtils.RNRN &
                           "From within the cerise flames, an angelic phantom manifests...", AddressOf onEquip2)

            p.perks(perk.metcynthia) = 2
        ElseIf Not p.perks(perk.metcynthia) > -1 Then
            TextEvent.pushAndLog("You meet Cynthia, the spirit inhabiting the " & LanceOfSFury.ITEM_NAME & "!  She understands the urgency of combat and agrees to help you...")
            p.perks(perk.metcynthia) = 2
        End If
    End Sub

    Protected Sub onEquip2()
        Objective.showNPC(annoy, """WHO THE HELL ARE YOU?  WHAT'S GOING ON?  Wait...  AM I DEAD?!""" & DDUtils.RNRN &
                                 "You introduce yourself, and explain that you were simply given this lance by the fae of wishes.  The spirit seems uncertain, but she eventually calms down and you are able to re-equip the lance." & DDUtils.RNRN &
                                 """Did... I- I guess the Celestial War must have gone worse than I thought...""")
        TextEvent.pushLog("You meet Cynthia, the spirit inhabiting the " & LanceOfSFury.ITEM_NAME & "!")
    End Sub
    Public Shared Sub setImg(ByVal m As mode)
        Select Case m
            Case mode.bimbo
                happy = ShopNPC.gbl_img.atrs(0).getAt(134)
                annoy = ShopNPC.gbl_img.atrs(0).getAt(137)
                cast1 = ShopNPC.gbl_img.atrs(0).getAt(135)
                cast2 = ShopNPC.gbl_img.atrs(0).getAt(136)
            Case Else
                happy = ShopNPC.gbl_img.atrs(0).getAt(130)
                annoy = ShopNPC.gbl_img.atrs(0).getAt(133)
                cast1 = ShopNPC.gbl_img.atrs(0).getAt(131)
                cast2 = ShopNPC.gbl_img.atrs(0).getAt(132)
        End Select
    End Sub

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If current_mode = mode.bimbo Then Return 22

        Return a_boost
    End Function
    Public Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1)

        If dmg <= 8 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 10 Then
            Return -2
        End If

        dmg += (p.getATK) + (Me.getABoost(p))
        Return Player.calcDamage(dmg, m.defense)
    End Function

    Public Overrides Sub outOfCombatAttack(ByRef p As Player)
        Dim out = ""

        If current_mode = mode.bimbo Then
            If DDUtils.containsIgnoreCase(p.className, "Bimbo") Or DDUtils.containsIgnoreCase(p.className, "Slut") Or DDUtils.containsIgnoreCase(p.formName, "Succubus") Or DDUtils.containsIgnoreCase(p.formName, "Demon") Then
                out = "Tia materializes next to you." & DDUtils.RNRN & """I'm, like, soooo gonna be stuck like this forever, aren't I..."""
                Game.picPortrait.BackgroundImage = annoy
            ElseIf DDUtils.containsIgnoreCase(p.className, "Valkyrie​") Or DDUtils.containsIgnoreCase(p.className, "Paladin") Or DDUtils.containsIgnoreCase(p.formName, "Angel") Then
                out = "Cynthia materializes next to you." & DDUtils.RNRN & """Hey, like, you can undo this curse thingy... riiiiight?"""
                Game.picPortrait.BackgroundImage = happy
            Else
                out = "Cynthia materializes next to you." & DDUtils.RNRN & """Woah, nice thrust you got there...  AH!  Like, no, I, uh- um, never mind."""
                Game.picPortrait.BackgroundImage = cast1
            End If
        Else
            If DDUtils.containsIgnoreCase(p.className, "Bimbo") Or DDUtils.containsIgnoreCase(p.className, "Slut") Or DDUtils.containsIgnoreCase(p.formName, "Succubus") Or DDUtils.containsIgnoreCase(p.formName, "Demon") Then
                out = "Cynthia materializes next to you." & DDUtils.RNRN & """Ugh, what are you even doing?  If we aren't in a fight, don't bother attacking."""
                Game.picPortrait.BackgroundImage = annoy
            ElseIf DDUtils.containsIgnoreCase(p.className, "Valkyrie​") Or DDUtils.containsIgnoreCase(p.className, "Paladin") Or DDUtils.containsIgnoreCase(p.formName, "Angel") Then
                out = "Cynthia materializes next to you." & DDUtils.RNRN & """Yep, I used to do that too...  Practice makes perfect, right?"""
                Game.picPortrait.BackgroundImage = happy
            Else
                out = "Cynthia materializes next to you." & DDUtils.RNRN & """Practicing your thrust?  Heh, those monsters don't stand a chance."""
                Game.picPortrait.BackgroundImage = cast1
            End If
        End If


        TextEvent.push(out, AddressOf cleanupPortraitImage)
        TextEvent.pushLog("You swing your " & getName().Replace("_", " ") & " at the air.")
    End Sub

    Public Shared Sub levelUp()
        out = "Cynthia materializes next to you." & DDUtils.RNRN & """Hey, congrats on leveling up!  Keep up the good work."""
        Game.picPortrait.BackgroundImage = happy
        TextEvent.push(out, AddressOf cleanupPortraitImage)
    End Sub

    Overrides Sub wThrow(ByRef p As Player, ByRef m As Entity)
        If Not p.equippedWeapon.getAName.Equals(getAName()) Then
            TextEvent.pushAndLog("The lance slips from your grip!  If only it were equipped...")
            Exit Sub
        End If

        If m Is Nothing Then
            Dim out = "As you throw the lance across the dungeon at nothing in particular, " & If(current_mode = mode.bimbo, "Tia", "Cynthia") & " materializes next to you and extends a hand." & DDUtils.RNRN &
                        """" & If(current_mode = mode.bimbo, "Magic Lance", "Righteous Incandescence") & "!"" she shouts, and it bursts into an inferno of cherry-red flame!"

            If p.inv.getCountAt(AngelicSweater.ITEM_NAME) < 1 AndAlso CType(p.inv.item(AngelicSweater.ITEM_NAME), AngelicSweater).fits(p) Then
                out += DDUtils.RNRN & "In the aftermath of the blast, a familiar outfit flutters to the ground..."
                TextEvent.pushLog("+1 " & AngelicSweater.ITEM_NAME)
                p.inv.add(AngelicSweater.ITEM_NAME, 1)
            End If

            TextEvent.push(out, AddressOf cleanupPortraitImage)
            TextEvent.pushLog("You throw the lance across the dungeon at nothing in particular.")

            Game.picPortrait.BackgroundImage = cast2
        Else
            Dim out = "You hurl the lance, and " & If(current_mode = mode.bimbo, "Tia", "Cynthia") & " materializes next to you and extends a hand." & DDUtils.RNRN &
            """" & If(current_mode = mode.bimbo, "Magic Lance", "Righteous Incandescence") & "!"" she shouts, and it bursts into an inferno of cherry-red flame!"

            TextEvent.push(out)
            TextEvent.pushLog("You throw the lance, and " & If(current_mode = mode.bimbo, "Tia", "Cynthia") & " casts " & If(current_mode = mode.bimbo, "Heat of Hotness", "Righteous Incandescence") & "!")

            Dim dmg As Integer = p.getSpellDamage(m, (Me.getABoost(owner)) + (Me.getABoost(owner)) + Int(Rnd() * 3 + 1))
            TextEvent.pushAndLog(CStr("You hit the " & m.name & " for " & dmg & " damage!"))
            m.takeDMG(dmg, p)
        End If
    End Sub

    Shared Sub cleanupPortraitImage()
        Game.player1.drawPort()
    End Sub

    Public Overrides Function getDescription() As Object
        If current_mode = mode.bimbo Then
            Return "An impressive spear made of a brilliant platinum alloy.  It glows with a shimmering cerise aura as your hand approaches, and it almost feels as though you are being judged.  Once in your grip, sparkly runes dance along its length." & DDUtils.RNRN &
                   "This was the favored weapon of Tia, Human Bimbo." & DDUtils.RNRN &
                   "More likely to hit critically than a sword, but also more likely to miss altogether." & DDUtils.RNRN &
                   "Can be thrown using the ""Use"" button." & DDUtils.RNRN &
                   getStatInformation()
        End If

        Return "An impressive spear made of a brilliant platinum alloy.  It glows with a shimmering crimson aura as your hand approaches, and it almost feels as though you are being judged.  Once in your grip, burning runes dance along its length." & DDUtils.RNRN &
                "This was the favored weapon of Cynthia, Archangel Paladin." & DDUtils.RNRN &
                "More likely to hit critically than a sword, but also more likely to miss altogether." & DDUtils.RNRN &
                "Can be thrown using the ""Use"" button." & DDUtils.RNRN &
                getStatInformation()
    End Function
End Class
