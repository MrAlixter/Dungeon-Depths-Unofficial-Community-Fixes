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

        '|Inventory|
        inv.setCount("Gelatinous_Shell", 1)
        inv.setCount("Omni_Charm", 1)
        inv.setCount("Gold", 5000)
        'random drops
        Dim possible_drops = {"Vial_of_Slime", "Vial_of_Slime", "Vial_of_Slime", "Fusion_Crystal", "Advanced_Spellbook", "Defense_Charm", "Defense_Charm"}
        Dim number_of_drops = Int(Rnd() * 2) + Int(Rnd() * 3) + 1
        For i = 0 To number_of_drops
            Dim r = Int(Rnd() * (possible_drops.Count))
            inv.setCount(possible_drops(r), 1)
        Next

        '|Dialog Variables|
        title = " "
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|
        setupMonsterOnSpawn()

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
        TextEvent.push("""Aww, sweetie, if you wanted another go you should have just asked!"", the Ooze Empress chuckles, her aphrodesiac-laced tendrils wrapping you in their arousing embrace.  ""You really do need to relax more.  Lucky for you, I have just the thing..."" she states, plunging your entire body deeper into her slime." & DDUtils.RNRN &
                          "As the pleasure once again overtakes you, you resign yourself to needing to try again.  Well, maybe not right away...", AddressOf oEmpDeathPt2)
    End Sub
    Sub oEmpDeathPt2()
        Dim p As Player = Game.player1
        p.ongoingTFs.add(New RandoTF())
        p.sState.save(p)
        p.pState.save(p)
        TextEvent.push("You awaken once again, in another body, in another part of the dungeon.")

        p.pos = Game.currFloor.randPoint

        p.update()
    End Sub
End Class
