Public Class LeporineOoze
    Inherits MiniBoss

    Public Const BASE_NAME As String = "Leporine Ooze"

    Dim charged As Boolean
    Dim suit_name As String = BunnySuit.ITEM_NAME

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 450
        attack = 32
        defense = 0
        speed = 10
        will = 0
        setupMonsterOnSpawn()

        '|Inventory|
        setBunnySuit()

        Dim r1 As Integer = Int(Rnd() * 3)
        If r1 > 1 Then r1 = 0
        inv.add(FantomaWand.ITEM_NAME, r1)

        Dim r2 As Integer = Int(Rnd() * 3)
        If r2 > 1 Then r2 = 0
        inv.add(LepSlimeWhip.ITEM_NAME, r2)

        '|Dialog Variables|
        pronoun = "it"
        p_pronoun = "its"
        r_pronoun = "it"

        '|Misc|
    End Sub

    Public Sub setBunnySuit()
        Dim suits As List(Of String) = New List(Of String)()
        suits.AddRange({BunnySuit.ITEM_NAME, ReverseBunnySuit.ITEM_NAME, BunnySuitG.ITEM_NAME, GShowgirlOutfit.ITEM_NAME})

        suit_name = suits(Int(Rnd() * suits.Count))
        inv.add(suit_name, 1)
    End Sub

    Public Overrides Sub handleStun()
        If Not currTarget Is Nothing Then attackCMD(currTarget)
    End Sub
    Public Overrides Sub attackCMD(ByRef target As Entity)
        If (Int(Rnd() * 4) = 0 And getHealth() > 0.1 And Not charged) Or isStunned Then
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
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle()) & " twists and morphs out of the way of your spell!")
            Return False
        End If

        Return True
    End Function

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        p.changeHairColor(Color.FromArgb(255, 40, 39, 48))

        DancerTF.step1RND(suit_name)

        TextEvent.push("You collapse, defeated." & DDUtils.RNRN &
                       "As you black out, the rabbit-eared slime lurches closer, slowly absorbing your limp arm..." & DDUtils.RNRN &
                       "Later, you wake up with a jolt; the Ooze having long since moved on.  It does seem to have left you a few souvenirs, though...")

        p.health = 0.4

        p.UIupdate()
        p.drawPort()
    End Sub
End Class
