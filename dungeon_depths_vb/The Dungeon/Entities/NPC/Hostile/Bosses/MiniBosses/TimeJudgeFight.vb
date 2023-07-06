Public Class TimeJudgeFight
    Inherits Boss
    Sub New()
        '|ID Info|
        name = "Time Judge"

        '|Stats|
        maxHealth = 200
        attack = 30
        defense = 90
        speed = 10
        will = 90
        xp_value = (maxHealth + attack + defense + speed) / 4

        '|Inventory|
        inv.setCount("AAAAAA_Battery", CInt(Int(Rnd() * 20)) + 1)
        inv.setCount("Phase_Hammer", 1)

        '|Dialog Variables|
        title = " The "
        pronoun = "he"
        p_pronoun = "his"
        r_pronoun = "him"

        '|Misc|
        health = 1.0
        sName = name
        sMaxHealth = maxHealth
        sMaxMana = maxMana
        sAttack = attack
        sdefense = defense
        sWill = will
        sSpeed = speed
        If Game.player1.perks(perk.lurk) > 0 Then perks(npc_perk.stun) = 0
        If speed = Game.player1.getSPD Then speed -= 1
        pos = Game.player1.pos
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        Dim dmg As Integer = Int(Rnd() * 12) + 1

        If dmg <= 3 Then
            If Not target.getPlayer Is Nothing Then target.getPlayer.miss(Me)
            Exit Sub
        End If


        dmg += (getATK())

        If inv.getCountAt("AAAAAA_Battery") < 1 Then
            dmg = Entity.calcDamage(dmg, target.getDEF)
            TextEvent.pushCombat("The Judge's strike is not powered!")
            target.takeDMG(dmg, Me)
        Else
            inv.add("AAAAAA_Battery", -1)
            dmg += 69
            dmg = Entity.calcDamage(dmg, target.getDEF)
            TextEvent.pushAndLog("The Judge's hammer head ejects a smoldering battery shell.")
            target.takeDMG(dmg, Me)
        End If
    End Sub

    Public Overrides Sub reactToTF()
        If title.Equals("Princess") Then
            despawn("judgetfeds")

            Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(86), "HOW DARE YOU?!  Get out of my courtroom you curr!", AddressOf OutOfTimeS3.alert)
        ElseIf title.Equals("Bunny") Then
            despawn("judgetfeds")

            Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(85), "Wh-what the hell did you do to me?!  G-g-g-go away!", AddressOf OutOfTimeS3.alert)
        ElseIf title.Equals("Cat-Girl") Then
            despawn("judgetfeds")

            Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(87), "Alright, alright, just leave...", AddressOf OutOfTimeS3.alert)
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        TextEvent.pushLog("The Time Judge tosses a cryogrenade at you!")
        p.petrify(Color.FromArgb(255, 75, 209, 255), 9999)
        p.drawPort()

        TextEvent.push("The Time judge tosses a cryogrenade that you are too weak to avoid, and with a flash your body freezes solid." & DDUtils.RNRN &
                          """You've proven yourself to be too large of a risk to be allowed to exist..."" the judge says readying a powerful swing ""...so on the charge of endangering the entire space time continuum, I find you...""" & DDUtils.RNRN &
                          "CRASH!!!" & DDUtils.RNRN &
                          """...guilty...""" & DDUtils.RNRN & DDUtils.RNRN & "GAME OVER!", AddressOf p.die)
    End Sub

    Public Overrides Sub die(ByRef cause As Entity)
        MyBase.die(cause)

        OutOfTimeS3.alert()
    End Sub
End Class
