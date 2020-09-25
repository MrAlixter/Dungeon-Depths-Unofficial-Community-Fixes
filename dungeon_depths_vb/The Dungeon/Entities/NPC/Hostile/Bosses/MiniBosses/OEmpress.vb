Public Class OEmpress
    Inherits MiniBoss

    Sub New()
        name = ("Ooze Empress")
        maxHealth = 100
        attack = 30
        defense = 70
        speed = 1
        will = 25
        setInventory({3, 58, 65})
        inv.setCount("Defense_Charm", 1 + CInt(Rnd() * 2))
        inv.setCount("Omni_Charm", 1)
        inv.setCount("Gold", 5000)

        setupMonsterOnSpawn()

        title = " "
        pronoun = "she"
        pPronoun = "her"
        rPronoun = "her"
        xpValue = 400
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        MyBase.attackCMD(target)
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")
        Game.pushLblEvent("""Aww, sweetie, if you wanted another go you should have just asked!"", the Ooze Empress chuckles, her aphrodesiac-laced tendrils wrapping you in their arousing embrace.  ""You really do need to relax more.  Lucky for you, I have just the thing..."" she states, plunging your entire body deeper into her slime.  As the pleasure once again overtakes you, you resign yourself to needing to try again.  Well, maybe not right away...", AddressOf oEmpDeathPt2)
    End Sub
    Sub oEmpDeathPt2()
        Dim p As Player = Game.player1
        p.ongoingTFs.add(New RandoTF())
        p.sState.save(p)
        p.pState.save(p)
        Game.pushLblEvent("You awaken once again, in another body, in another part of the dungeon.")

        p.pos = Game.currFloor.randPoint

        p.update()
    End Sub
End Class
