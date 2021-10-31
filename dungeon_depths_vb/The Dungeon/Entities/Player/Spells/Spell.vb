Public Class Spell
    Dim cost, tier As Integer
    Dim name As String
    Dim caster As Player
    Dim target As NPC

    Public Shared spellList As Dictionary(Of String, Spell)
    Dim useableOutOfCombat As Boolean = False
    Shared Sub init()
        spellList = New Dictionary(Of String, Spell)

        spellList.Add("Dragon's Breath", New DragonsBreath(Nothing, Nothing))
        spellList.Add("Fireball", New Fireball(Nothing, Nothing))
        spellList.Add("Super Fireball", New SuperFireball(Nothing, Nothing))
        spellList.Add("Icicle Spear", New IcicleSpear(Nothing, Nothing))
        spellList.Add("Heartblast Starcannon", New HBSC(Nothing, Nothing))
        spellList.Add("Self Polymorph", New SelfPolymorph(Nothing, Nothing))
        spellList.Add("Polymorph Enemy", New EnemyPolymorph(Nothing, Nothing))
        spellList.Add("Turn to Frog", New turnToFrog(Nothing, Nothing))
        spellList.Add("Petrify", New Petrify(Nothing, Nothing))
        spellList.Add("Turn to Blade", New turnToBlade(Nothing, Nothing))
        spellList.Add("Turn to Cupcake", New turnToCupcake(Nothing, Nothing))
        spellList.Add("Heal", New Heal(Nothing, Nothing))
        spellList.Add("Dowse", New Dowse(Nothing, Nothing))
        spellList.Add("Illuminate", New Illumiate(Nothing, Nothing))
        spellList.Add("Arcane Compass", New ArcaneCompass(Nothing, Nothing))
        spellList.Add("Magma Spear", New MagmaSpear(Nothing, Nothing))
        spellList.Add("Petrify II", New Petrify2(Nothing, Nothing))
        spellList.Add("Major Heal", New MajorHeal(Nothing, Nothing))
        spellList.Add("Warp", New Warp(Nothing, Nothing))
        spellList.Add("Uvona's Fugue", New UvonasFugue(Nothing, Nothing))
        spellList.Add("Molten Fireball", New MoltenFireball(Nothing, Nothing))
        spellList.Add("Snowball", New Snowball(Nothing, Nothing))
        spellList.Add("Mesmeric Bloom", New MesmericBloom(Nothing, Nothing))
        spellList.Add("Frazzle", New Frazzle(Nothing, Nothing))
        spellList.Add("Heartbreak Supernova", New HBSN(Nothing, Nothing))
        spellList.Add("Sweet Sunbeam", New CuteBeam(Nothing, Nothing))
        spellList.Add("Shiny Sparking Missile", New SSMissile(Nothing, Nothing))
        spellList.Add("Raise Lust", New RLust(Nothing, Nothing))
        spellList.Add("Puff Up", New PuffUp(Nothing, Nothing))
        spellList.Add("Flash Bolt", New FlashBolt(Nothing, Nothing))
        spellList.Add("Firestorm", New FireStorm(Nothing, Nothing))
        spellList.Add("Cynn's Disguise", New CynnsDisguise(Nothing, Nothing))
        spellList.Add("Summon Battery", New SummonBattery(Nothing, Nothing))
        spellList.Add("Flames of Amaraphne", New FlamesOfAmaraphne(Nothing, Nothing))
        spellList.Add("Cleansing Light", New CleansingLight(Nothing, Nothing))
        spellList.Add("Benediction", New Benediction(Nothing, Nothing))
        spellList.Add("Smite", New Smite(Nothing, Nothing))
        spellList.Add("Hellfireball", New Hellfireball(Nothing, Nothing))
        spellList.Add("Reductive Mending", New SizeForLife(Nothing, Nothing))
        spellList.Add("Summon Apple", New SummonApple(Nothing, Nothing))
        spellList.Add("Tentacle Crushcannon", New TentacleCrushcannon(Nothing, Nothing))
        spellList.Add("Flash Heal", New FlashHeal(Nothing, Nothing))
        spellList.Add("Aquageyser", New Aquageyser(Nothing, Nothing))
        spellList.Add("Hydrodart", New Hydrodart(Nothing, Nothing))
        spellList.Add("Death Cutter", New DeathCutter(Nothing, Nothing))
    End Sub

    Sub New(ByRef c As Player, ByRef t As NPC)
        caster = c
        target = t
    End Sub
    Sub cast()
        If caster.mana < getcost() Then
            TextEvent.pushAndLog("You don't have enough mana! (" & name & " costs " & getcost() & " mana)")
            Exit Sub
        End If
        If Not Game.combat_engaged And Not Game.shop_npc_engaged And Not useableOutOfCombat Then
            TextEvent.pushAndLog("You don't have a target for that spell!")
            Exit Sub
        End If
        If caster.perks(perk.gagged) > 0 Then
            TextEvent.pushAndLog("Your gag prevents you from casting spells!")
            Exit Sub
        End If

        Randomize()
        caster.mana -= getcost()

        Select Case tier
            Case 2
                If caster.passDieRoll(10, 9) Then
                    TextEvent.pushAndLog("You cast " & name & "!")
                    effect()
                Else
                    TextEvent.pushAndLog("You try to cast " & name & ", but it fizzles into nothing!")
                End If
            Case 3
                If caster.passDieRoll(10, 8) Then
                    TextEvent.pushAndLog("You cast " & name & "!")
                    effect()
                Else
                    If caster.passDieRoll(10, 5) Then
                        TextEvent.pushAndLog("You try to cast " & name & ", but it fizzles into nothing!")
                    Else
                        TextEvent.pushAndLog("You try to cast " & name & ", but it backfires!")
                        backfire()
                    End If
                End If
            Case 4
                If caster.passDieRoll(10, 7) Then
                    TextEvent.pushAndLog("You cast " & name & "!")
                    effect()
                Else
                    If caster.passDieRoll(100, 35) Then
                        TextEvent.pushAndLog("You try to cast " & name & ", but it fizzles into nothing!")
                    Else
                        TextEvent.pushAndLog("You try to cast " & name & ", but it backfires!")
                        backfire()
                    End If
                End If
            Case 5
                If caster.passDieRoll(10, 6) Then
                    TextEvent.pushAndLog("You cast " & name & "!")
                    effect()
                Else
                    If caster.passDieRoll(10, 2) Then
                        TextEvent.pushAndLog("You try to cast " & name & ", but it fizzles into nothing!")
                    Else
                        TextEvent.pushAndLog("You try to cast " & name & ", but it backfires!")
                        backfire()
                    End If
                End If
            Case Else
                TextEvent.pushAndLog("You cast " & name & "!")
                effect()
        End Select

    End Sub
    Overridable Sub effect()
        TextEvent.push("No effects.")
    End Sub
    Overridable Sub backfire()
        TextEvent.push("No effects.")
    End Sub

    Sub setName(ByVal s As String)
        name = s
    End Sub
    Overridable Function getcost() As Integer
        Return cost
    End Function
    Sub setcost(ByVal i As Integer)
        cost = i
    End Sub
    Sub settier(ByVal i As Integer)
        tier = i
    End Sub
    Sub setUOC(ByVal b As Boolean)
        useableOutOfCombat = b
    End Sub

    Function getCaster() As Player
        Return caster
    End Function
    Function getTarget() As NPC
        Return target
    End Function
    Sub redefineCandT(ByRef c As Player, ByRef t As NPC)
        caster = c
        target = t
    End Sub
    Public Overridable Function getDesc(ByRef c As Player, ByRef t As NPC)
        Return "Description not added."
    End Function

    Shared Sub spellCast(ByRef t As NPC, ByRef c As Player, ByVal s As String)
        'during an npc encounter, the NPC is the only viable target
        If Game.shop_npc_engaged Then t = Game.active_shop_npc

        'check for a target
        If Not t Is Nothing Then
            'if we have a target, check if the spell hits them
            If t.reactToSpell(s) Then spellroute(c, t, s)
        Else
            'otherwise just cast the spell
            spellroute(c, t, s)
        End If
    End Sub
    Shared Sub spellroute(ByRef c As Player, ByRef t As NPC, ByRef s As String)
        If s.Contains("Heartblast Starcann.") Then s = "Heartblast Starcannon"
        If s.Contains("Tentacle Crushcanno.") Then s = "Tentacle Crushcannon"
        If s.Contains("Heartbreak Supernov.") Then s = "Heartblast Starcannon"
        If s.Contains("Shiny Sparking Miss.") Then s = "Tentacle Crushcannon"

        If Not spellList.Keys.Contains(s) Then s = "Frazzle"

        If s.Equals("Self Polymorph") And Not Transformation.canBeTFed(c) Then
            TextEvent.pushLog("You can't polymorph yourself!")
            TextEvent.pushCombat("You can't polymorph yourself!")
            Exit Sub
        ElseIf s.Equals("Heal") Then
            If Game.player1.className.Equals("Soul-Lord") Then
                TextEvent.push("You scoff at the thought of healing in this moment, instead firing off a much more agressive fireball.  Settling down slightly, you muse on what a waste of time a heal spell would be." & DDUtils.RNRN & """Only someone who cares about their mortal vessel would bother to maintain it.")
                s = "Fireball"
            End If
        End If

        Dim spell As Spell = spellList(s)
        spell.redefineCandT(c, t)

        spell.cast()
    End Sub
    Shared Function spellCost(ByVal s As String)
        If Not spellList.Keys.Contains(s) Then s = "Frazzle"

        Select Case s
            Case "Dragon's Breath"
                If Game.player1.formName.Equals("Dragon") Then Return "No cost" Else Return "-6 mana"
            Case "Molten Fireball"
                Return "-4 health"
            Case Else
                Return "-" & spellList(s).cost & " mana"
        End Select
    End Function
End Class
