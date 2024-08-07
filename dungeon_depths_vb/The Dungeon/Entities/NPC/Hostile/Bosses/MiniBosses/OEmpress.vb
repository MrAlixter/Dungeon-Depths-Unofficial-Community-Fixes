Public Class OEmpress
    Inherits MiniBoss

    Sub New()
        '|ID Info|
        name = ("Ooze Empress")

        '|Stats|
        maxHealth = 100
        attack = 30
        defense = 70
        speed = 1
        will = 25
        xp_value = 400
        setupMonsterOnSpawn()

        '|Inventory|
        inv.setCount("Gelatinous_Shell", 1)
        inv.setCount("Omni_Charm", 1)
        inv.setCount(SluiceChime.ITEM_NAME, 1)
        inv.setCount("Key", 1)
        inv.setCount("Gold", 5000)
        'random drops
        Dim possible_drops = {"Vial_of_Slime", "Vial_of_Slime", "Vial_of_Slime", "Advanced_Spellbook", "Defense_Charm", "Defense_Charm"}
        Dim number_of_drops = Int(Rnd() * 2) + Int(Rnd() * 3) + 1
        For i = 0 To number_of_drops
            Dim r = Int(Rnd() * (possible_drops.Count))
            inv.setCount(possible_drops(r), 1)
        Next

        '|Dialog Variables|
        title = " the "
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|
        intro_taunt = """Let's see if you've learned anyhing since last time..."" she says with a grin, ""...though I'm sure neither of us would mind a repeat, either..."""
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        MyBase.attackCMD(target)
    End Sub

    Public Overrides Sub die(ByRef cause As Entity)
        MyBase.die(cause)

        TextEvent.lblEventOnClose = AddressOf die2
    End Sub
    Private Sub die2()
        TextEvent.pushYesNo("Take your body back?", AddressOf RandoTF.floor4revert, AddressOf RandoTF.floor4keep)
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(147), """Aww, sweetie, if you wanted another go you could have just asked!"", the Ooze Empress chuckles, her aphrodesiac-laced tendrils wrapping you in their arousing embrace." & DDUtils.RNRN &
                                                             """You really do need to relax, though.  Luckily, I have just the thing for that..."" she states, plunging your entire body once again into her slime." & DDUtils.RNRN &
                                                             "As the overwhelming waves of pleasure wash over you, you resign yourself to another attempt." & DDUtils.RNRN &
                                                             "Well, maybe not... right away...", AddressOf oEmpDeathPt2)
    End Sub
    Sub oEmpDeathPt2()
        Dim p As Player = Game.player1
        p.ongoingTFs.add(New RandoTF())
        p.sState.save(p)
        p.pState.save(p)
        TextEvent.pushAndLog("You awaken once again, in another body, in another part of the dungeon.")

        p.pos = Game.currFloor.randPoint

        p.update()
    End Sub

    Public Overrides Sub preFightDialog()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(147), "As you approach the staircase, you spot the Ooze Empress dangling above.  You wave to get her attention, and she plops down to greet you." & DDUtils.RNRN &
                                                             "You explain your situation to her, but she simply chuckles before twisting closer." & DDUtils.RNRN &
                                                             """You know, I was placed on this floor as, like, a buffer.  Lady Medusa isn't interested in weaklings, and you aren't going anywhere important if you can't even keep track of your own body...""" & DDUtils.RNRN &
                                                             "Noticing a shift in her previously bubbly personality, you leap back as her tentacles flare out around you." & DDUtils.RNRN &
                                                             """Let's see if you've learned anyhing since last time..."" she says with a somewhat menacing grin, ""...though I'm sure neither of us would mind a repeat, either...""", AddressOf Game.ChallengeBoss)
        MyBase.preFightDialog()
    End Sub
End Class
