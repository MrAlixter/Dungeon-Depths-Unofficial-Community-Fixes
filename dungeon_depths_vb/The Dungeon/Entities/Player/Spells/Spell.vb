Public Class Spell
    Dim cost, tier As Integer
    Dim name As String
    Dim caster As Player
    Dim target As NPC

    Shared spellList As Dictionary(Of String, Spell)
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
        spellList.Add("Adorable Sunbeam", New CuteBeam(Nothing, Nothing))
    End Sub

    Sub New(ByRef c As Player, ByRef t As NPC)
        caster = c
        target = t
    End Sub
    Sub cast()
        If caster.mana < cost Then
            Game.pushLblEvent("You don't have enough mana! (" & name & " costs " & cost & " mana)")
            Game.pushLstLog("You don't have enough mana!")

            Exit Sub
        End If
        If Not Game.combatmode And Not Game.npcmode And Not useableOutOfCombat Then
            Game.pushLblEvent("You don't have a target for that spell!")
            Game.pushLstLog("You don't have a target for that spell!")

            Exit Sub
        End If
        Randomize()
        caster.mana -= cost

        Select Case tier
            Case 2
                If Rnd() < 0.9 Then
                    Game.pushLblEvent("You cast " & name & "!")
                    Game.pushLstLog("You cast " & name & "!")
                    effect()
                Else
                    Game.pushLblEvent("You try to cast " & name & ", but it fizzles into nothing!")
                    Game.pushLstLog("You try to cast " & name & ", but it fizzles into nothing!")
                End If
            Case 3
                If Rnd() < 0.8 Then
                    Game.pushLblEvent("You cast " & name & "!")
                    Game.pushLstLog("You cast " & name & "!")
                    effect()
                Else
                    If Rnd() < 0.5 Then
                        Game.pushLblEvent("You try to cast " & name & ", but it fizzles into nothing!")
                        Game.pushLstLog("You try to cast " & name & ", but it fizzles into nothing!")
                    Else
                        Game.pushLblEvent("You try to cast " & name & ", but it backfires!")
                        Game.pushLstLog("You try to cast " & name & ", but it backfires!")
                        backfire()
                    End If
                End If
            Case 4
                If Rnd() < 0.7 Then
                    Game.pushLblEvent("You cast " & name & "!")
                    Game.pushLstLog("You cast " & name & "!")
                    effect()
                Else
                    If Rnd() < 0.35 Then
                        Game.pushLblEvent("You try to cast " & name & ", but it fizzles into nothing!")
                        Game.pushLstLog("You try to cast " & name & ", but it fizzles into nothing!")
                    Else
                        Game.pushLblEvent("You try to cast " & name & ", but it backfires!")
                        Game.pushLstLog("You try to cast " & name & ", but it backfires!")
                        backfire()
                    End If
                End If
            Case 5
                If Rnd() < 0.6 Then
                    Game.pushLblEvent("You cast " & name & "!")
                    Game.pushLstLog("You cast " & name & "!")
                    effect()
                Else
                    If Rnd() < 0.2 Then
                        Game.pushLblEvent("You try to cast " & name & ", but it fizzles into nothing!")
                        Game.pushLstLog("You try to cast " & name & ", but it fizzles into nothing!")
                    Else
                        Game.pushLblEvent("You try to cast " & name & ", but it backfires!")
                        Game.pushLstLog("You try to cast " & name & ", but it backfires!")
                        backfire()
                    End If
                End If
            Case Else
                Game.pushLblEvent("You cast " & name & "!")
                Game.pushLstLog("You cast " & name & "!")
                effect()
        End Select

    End Sub
    Overridable Sub effect()
        Game.pushLblEvent("No effects.")
    End Sub
    Overridable Sub backfire()
        Game.pushLblEvent("No effects.")
    End Sub

    Sub setName(ByVal s As String)
        name = s
    End Sub
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

    Shared Sub spellCast(ByRef t As NPC, ByRef c As Player, ByVal s As String)
        If Game.combatmode Or Game.npcmode Then
            If t.reactToSpell(s) Or s = "Heal" Then
                spellroute(c, t, s)
            End If
        Else
            spellroute(c, t, s)
        End If
    End Sub
    Shared Sub spellroute(ByRef c As Player, ByRef t As NPC, ByRef s As String)
        If s.Contains("Heartblast Starcan.") Then s = "Heartblast Starcannon"
        If Not spellList.Keys.Contains(s) Then s = "Frazzle"

        If s.Equals("Self Polymorph") And Not Transformation.canBeTFed(c) Then
            Game.pushLstLog("You can't polymorph yourself!")
            Game.pushLblCombatEvent("You can't polymorph yourself!")
            Exit Sub
        ElseIf s.Equals("Heal") Then
            If Game.player1.pClass.name.Equals("Soul-Lord") Then
                Game.pushLblEvent("You scoff at the thought of healing in this moment, instead firing off a much more agressive fireball.  Settling down slightly, you muse on what a waste of time a heal spell would be." & vbCrLf & vbCrLf & """Only someone who cares about their mortal vessel would bother to maintain it.")
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
                If Game.player1.pForm.name.Equals("Dragon") Then Return "No cost" Else Return "-6 mana"
            Case "Molten Fireball"
                Return "-4 health"
            Case Else
                Return "-" & spellList(s).cost & " mana"
        End Select
    End Function
End Class
