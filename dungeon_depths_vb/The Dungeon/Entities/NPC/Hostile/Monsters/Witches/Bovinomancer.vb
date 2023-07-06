Public Class Bovinomancer
    Inherits Monster

    Public Const BASE_NAME As String = "Bovinaemancer"

    Dim tfInd As Integer
    Dim knows_p_cant_be_tfed As Boolean

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 250
        maxMana = 45
        attack = 15
        defense = 10
        speed = 45
        will = 50
        setupMonsterOnSpawn()

        '|Inventory|
        setInventory({25, 34, 70, 71, 197})

        '|Dialog Variables|
        If Int(Rnd() * 2) = 0 Then
            pronoun = "she"
            p_pronoun = "her"
            r_pronoun = "her"
        Else
            pronoun = "he"
            p_pronoun = "his"
            r_pronoun = "him"
        End If

        '|Misc|
        tfInd = 0
        knows_p_cant_be_tfed = False
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If Not ("Cow".Equals(target.getPlayer.formName)) AndAlso Int(Rnd() * 2) = 0 And mana > 15 And Not knows_p_cant_be_tfed Then
            If Transformation.canBeTFed(target.getPlayer) Then
                spell1(target)
            Else
                TextEvent.pushAndLog("The " & getName() & " casts ""Bovinize"", but your form prevents you from being transformed...")
                knows_p_cant_be_tfed = True
            End If
        ElseIf mana > 5 Then
            spell2(target)
        Else
            MyBase.attackCMD(target)
        End If
    End Sub

    Sub spell1(ByRef e As Entity)
        mana -= 14
        TextEvent.pushAndLog("The " & getName() & " casts ""Bovinize"", turning you into a cow!")

        If Not e.getPlayer Is Nothing Then
            playerSpell1(e.getPlayer)
        ElseIf Not e.getNPC Is Nothing Then
            npcSpell1(e.getNPC)
        End If
    End Sub
    Sub playerSpell1(ByRef p As Player)
        Polymorph.transform(p, "Cow")
    End Sub
    Sub npcSpell1(ByRef n As NPC)
        n.perks(npc_perk.tfdur) = Int(Rnd() * 7) + 3
        n.form = "Cow"
        n.attack = 1
        n.defense = 20
        n.speed = 1
        If n.getIntHealth > 150 Then n.health = 1
        n.maxHealth = 150
    End Sub

    Sub spell2(ByRef e As Entity)
        mana -= 5
        Dim dmg As Integer = 35 + Int(Rnd() * 20)
        dmg = getSpellDamage(e, dmg)

        TextEvent.pushAndLog("The " & getName() & " casts ""Cattle Prod"", zapping you for " & dmg & " damage!")

        e.takeDMG(dmg, Me)

        If e.getIntHealth < 1 Then Exit Sub

        If Not e.getPlayer Is Nothing Then
            playerSpell2(e.getPlayer)
        End If
    End Sub
    Sub playerSpell2(ByRef p As Player)
        If p.formName.Equals("Cow") Then Exit Sub

        If tfInd = 0 Then
            p.prt.setIAInd(pInd.ears, 8, True, True)
            TextEvent.pushAndLog("The " & getName() & "'s spell gives you cow ears!")
        ElseIf tfInd = 1 Then
            If Int(Rnd() * 2) = 0 Then
                p.prt.setIAInd(pInd.horns, 1, True, False)
                TextEvent.pushAndLog("The " & getName() & "'s spell gives you cow horns!")
            Else
                p.prt.setIAInd(pInd.horns, 2, True, False)
                TextEvent.pushAndLog("The " & getName() & "'s spell gives you bull horns!")
            End If
        Else
            p.be()
            TextEvent.pushAndLog("The " & getName() & "'s spell gives you bigger boobs!")
        End If

        tfInd += 1

        p.drawPort()
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        '| -- Battle Cleanup -- |
        despawn("p-death")

        '| -- TF Description -- |
        Dim out As String = "As you collapse to the ground, still smoldering from the previous encounter, your foe saunters over with a smug grin." & DDUtils.RNRN &
                            """Really, you shouldn't be suprised by this..."" " & pronoun & " says, charging another spell.  ""This is how things should be, clearly your natual state is to be cowed before your superior.""" & DDUtils.RNRN

        If Transformation.canBeTFed(p) Or p.formName.Equals("Cow") Then
            out += "The " & getName() & " casts Greater Bovinize, turning you into a cow!  This transformation will have some lasting effects even after it wears off..."
        Else
            out += "The " & getName() & " casts Greater Bovinize, turning you into a cow!  Your current form disrupts the lasting effects the spell may have had..."
        End If

        '| -- Transformation -- |
        Try
            '| -- Revert any temporary polymorphs -- |
            If p.polymorphs.ContainsKey(p.className) Or p.polymorphs.ContainsKey(p.formName) Then
                p.ongoingTFs.resetPolymorphs()
                p.perks(perk.polymorphed) = -1
                p.revertToPState()
            End If

            '| -- Lasting Effects Transformation -- |
            If p.sex = "Male" Then
                p.MtF()
            End If

            p.breastSize = Math.Min(p.breastSize + 3, 7)

            p.prt.setIAInd(pInd.rearhair, 16, True, True)
            p.prt.setIAInd(pInd.midhair, 20, True, True)
            p.prt.setIAInd(pInd.ears, 8, True, True)
            p.prt.setIAInd(pInd.horns, 2, True, False)
            p.savePState()

            '| -- Cow Transformation -- |
            Polymorph.transform(p, "Cow", False)
        Catch ex As Exception
            out = "As you collapse to the ground, still smoldering from the previous encounter, your foe saunters over with a smug grin." & DDUtils.RNRN &
                  """Really, you shouldn't be suprised by this..."" " & pronoun & " says, stroking your cheek.  ""This is how things should be, clearly your natual state is to be cowed before your superior.""" & DDUtils.RNRN
        End Try

        TextEvent.push(out, AddressOf p.update)
    End Sub
End Class
