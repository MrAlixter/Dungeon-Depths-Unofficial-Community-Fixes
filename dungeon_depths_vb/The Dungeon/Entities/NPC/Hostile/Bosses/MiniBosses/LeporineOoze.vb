Public Class LeporineOoze
    Inherits MiniBoss

    Dim charged As Boolean
    Sub New()
        '|ID Info|
        name = "Leporine Ooze"

        '|Stats|
        maxHealth = 500
        attack = 32
        defense = 0
        speed = 50
        will = 0
        xp_value = 250

        '|Inventory|
        inv.setCount("Omni_Charm", 1)

        '|Dialog Variables|
        pronoun = "it"
        p_pronoun = "its"
        r_pronoun = "it"

        '|Misc|
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub handleStun()
        If Not currTarget Is Nothing Then attackCMD(currTarget)
    End Sub
    Public Overrides Sub attackCMD(ByRef target As Entity)
        If (Int(Rnd() * 4) And getHealth() > 0.1 And Not charged) Or isStunned Then
            Dim dmg = getIntHealth() / 10

            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle()) & "'s entire body pulses, throwing off a layer of slime!")
            TextEvent.pushAndLog("You take " & Entity.calcDamage(dmg, target.getDEF) & " damage!")

            target.takeDMG(Entity.calcDamage(dmg, target.getDEF), Me)
            takeDMG(dmg, target)
            Exit Sub
        End If

        If tfCt > 0 Then
            tfCt = 0
            revert()
            Exit Sub
        End If

        If Not target.getPlayer Is Nothing Then
            If target.getPlayer.equippedWeapon.getAName.Equals(StickWand.ITEM_NAME) Then
                TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle()) & " engulfs your arm.  You yank it out quickly, but a thin tendril of slime is left dangling below." & DDUtils.RNRN &
                               "Your wand is consumed!  +1 " & LepSlimeWhip.ITEM_NAME)
                TextEvent.pushLog("Your wand is consumed!  +1 " & LepSlimeWhip.ITEM_NAME)

                target.getPlayer.inv.add(StickWand.ITEM_NAME, -1)
                target.getPlayer.inv.add(LepSlimeWhip.ITEM_NAME, 1)

                EquipmentDialogBackend.weaponChange(target.getPlayer, LepSlimeWhip.ITEM_NAME, False)
                Exit Sub
            End If

            If target.getPlayer.getLust > 50 And Not charged Then
                TextEvent.pushAndLog("Arcane glyphs begin to glow along " & getNameWithTitle() & "'s body.  It seems to be charging something...")
                charged = True
                Exit Sub
            End If

            If charged Then
                Dim dmg = getSpellDamage(target, getATK() * 4)

                TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle()) & " fires a spike of hardened gel faster than you can dodge!")

                cHit(dmg, target)
                charged = False

                Exit Sub
            End If
        End If

        TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle() & " swipes at you with a tendril of slime!"))
        MyBase.attackCMD(target, False)
    End Sub

    Public Overrides Function reactToSpell(spell As String) As Boolean
        If spell.Contains("Turn to") Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle()) & " morphs and flows out of the way of your spell!")
            Return False
        End If

        Return True
    End Function

    Public Overrides Sub despawn(reason As String)
        MyBase.despawn(reason)

        If Not reason = "cupcake" Then
            playerDeath(Game.player1)
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.npc_list.Clear()

        FanPhanStep3.lose()
    End Sub

    Public Overrides Sub die(ByRef cause As Entity)
        MyBase.die(cause)

        TextEvent.lblEventOnClose = AddressOf FanPhanStep3.win
    End Sub
End Class
