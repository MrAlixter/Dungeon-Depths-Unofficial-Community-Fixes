Public Class Spell
    Dim cost, tier As Integer
    Dim name As String
    Dim caster As Player
    Dim target As Monster

    Dim useableOutOfCombat As Boolean = False

    Sub New(ByRef c As Player, ByRef t As Monster)
        caster = c
        target = t
    End Sub
    Sub cast()
        If caster.mana < cost Then
            Game.pushLblEvent("You don't have enough mana!")
            Game.lstLog.Items.Add("You don't have enough mana!")
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
            Exit Sub
        End If
        If Not Game.combatmode And Not Game.npcmode And Not useableOutOfCombat Then
            Game.pushLblEvent("You don't have a target for that spell!")
            Game.lstLog.Items.Add("You don't have a target for that spell!")
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
            Exit Sub
        End If
        Randomize()
        caster.mana -= cost
        Select Case tier
            Case 1
                Game.pushLblEvent("You cast " & name & "!")
                Game.lstLog.Items.Add("You cast " & name & "!")
                effect()
            Case 2
                If Rnd() < 0.9 Then
                    Game.pushLblEvent("You cast " & name & "!")
                    Game.lstLog.Items.Add("You cast " & name & "!")
                    effect()
                Else
                    Game.pushLblEvent("You try to cast " & name & ", but it fizzles into nothing!")
                    Game.lstLog.Items.Add("You try to cast " & name & ", but it fizzles into nothing!")
                End If
            Case 3
                If Rnd() < 0.8 Then
                    Game.pushLblEvent("You cast " & name & "!")
                    Game.lstLog.Items.Add("You cast " & name & "!")
                    effect()
                Else
                    If Rnd() < 0.5 Then
                        Game.pushLblEvent("You try to cast " & name & ", but it fizzles into nothing!")
                        Game.lstLog.Items.Add("You try to cast " & name & ", but it fizzles into nothing!")
                    Else
                        Game.pushLblEvent("You try to cast " & name & ", but it backfires!")
                        Game.lstLog.Items.Add("You try to cast " & name & ", but it backfires!")
                        backfire()
                    End If
                End If
            Case 4
                If Rnd() < 0.7 Then
                    Game.pushLblEvent("You cast " & name & "!")
                    Game.lstLog.Items.Add("You cast " & name & "!")
                    effect()
                Else
                    If Rnd() < 0.35 Then
                        Game.pushLblEvent("You try to cast " & name & ", but it fizzles into nothing!")
                        Game.lstLog.Items.Add("You try to cast " & name & ", but it fizzles into nothing!")
                    Else
                        Game.pushLblEvent("You try to cast " & name & ", but it backfires!")
                        Game.lstLog.Items.Add("You try to cast " & name & ", but it backfires!")
                        backfire()
                    End If
                End If
            Case Else
                If Rnd() < 0.6 Then
                    Game.pushLblEvent("You cast " & name & "!")
                    Game.lstLog.Items.Add("You cast " & name & "!")
                    effect()
                Else
                    If Rnd() < 0.2 Then
                        Game.pushLblEvent("You try to cast " & name & ", but it fizzles into nothing!")
                        Game.lstLog.Items.Add("You try to cast " & name & ", but it fizzles into nothing!")
                    Else
                        Game.pushLblEvent("You try to cast " & name & ", but it backfires!")
                        Game.lstLog.Items.Add("You try to cast " & name & ", but it backfires!")
                        backfire()
                    End If
                End If
        End Select
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
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
    Function getTarget() As Monster
        Return target
    End Function

    Sub Dispose()
        Me.Finalize()
    End Sub

    Shared Sub spellCast(ByRef t As Monster, ByRef c As Player, ByVal s As String)
        If Game.combatmode Or Game.npcmode Then
            If Not t.sName = "Targax the Brutal" Then
                spellroute(c, t, s)
            ElseIf t.getName = "Shopkeeper" Then
                If Rnd() < (0.01) Then
                    spellroute(c, t, s)
                Else
                    Game.lstLog.Items.Add("The spell bounces off the Shopkeeper!")
                    Game.pushLblCombatEvent("The spell bounces off the Shopkeeper!")
                End If
            Else
                If Rnd() < (0.6) Then
                    spellroute(c, t, s)
                Else
                    Game.lstLog.Items.Add("The spell bounces off Targax!")
                    Game.pushLblCombatEvent("The spell bounces off Targax!")
                End If
            End If
        Else
            spellroute(c, t, s)
        End If

        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub spellroute(ByRef c As Player, ByRef t As Monster, ByRef s As String)
        Dim spell As Spell = Nothing
        If s = "Dragon's Breath" Then
            spell = New DragonsBreath(c, t)
        ElseIf s = "Fireball" Then
            spell = New Fireball(c, t)
        ElseIf s = "Super Fireball" Then
            spell = New SuperFireball(c, t)
        ElseIf s = "Icicle Spear" Then
            spell = New IcicleSpear(c, t)
        ElseIf s = "Heartblast Starcannon" Then
            spell = New HBSC(c, t)
        ElseIf s = "Self Polymorph" And Polymorph.canBeTFed(c) Then
            spell = New SelfPolymorph(c, t)
        ElseIf s = "Self Polymorph" And Not Polymorph.canBeTFed(c) Then
            Game.lstLog.Items.Add("You can't polymorph yourself!")
            Game.pushLblCombatEvent("You can't polymorph yourself!")
        ElseIf s = "Polymorph Enemy" Then
            spell = New EnemyPolymorph(c, t)
        ElseIf s = "Turn to Frog" Then
            spell = New turnToFrog(c, t)
        ElseIf s = "Petrify" Then
            spell = New Petrify(c, t)
        ElseIf s = "Turn to Blade" Then
            spell = New turnToBlade(c, t)
        ElseIf s = "Turn to Cupcake" Then
            spell = New turnToCupcake(c, t)
        ElseIf s = "Heal" Then
            spell = New Heal(c, t)
        ElseIf s = "Dowse" Then
            spell = New Dowse(c, t)
        ElseIf s = "Illuminate" Then
            spell = New Illumiate(c, t)
        ElseIf s = "Arcane Compass" Then
            spell = New ArcaneCompass(c, t)
        End If
        spell.cast()
        spell.Dispose()
    End Sub
    Shared Function spellCost(ByVal s As String)
        Select Case s
            Case "Dragon's Breath"
                If Game.player.title.Equals("Dragon") Then Return "No cost." Else Return "-6 mana."
            Case "Fireball"
                Return "-3 mana."
            Case "Super Fireball"
                Return "-6 mana."
            Case "Icicle Spear"
                Return "-5 mana."
            Case "Heartblast Starcannon"
                Return "-5 mana."
            Case "Petrify"
                Return "-6 mana."
            Case "Self Polymorph"
                Return "-7 mana."
            Case "Polymorph Enemy"
                Return "-7 mana."
            Case "Turn to Frog"
                Return "-5 mana."
            Case "Mindshrink"
                Return "-5 mana."
            Case "Turn to Blade"
                Return "-9 mana."
            Case "Turn to Cupcake"
                Return "-9 mana."
            Case Else
                Return "This costs some degree of mana."
        End Select
    End Function
End Class
