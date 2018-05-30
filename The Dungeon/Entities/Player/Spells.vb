Public Class Spells
    Shared Sub spellCast(ByRef t As Monster, ByRef c As Player, ByVal s As String)
        If Not t.sName = "Targax the Brutal" Then
            spellroute(c, t, s)
        ElseIf t.getName = "Shopkeeper" Then
            Dim r As Integer = Int(Rnd() * 73)
            If r = 0 Then
                spellroute(c, t, s)
            Else
                Game.lstLog.Items.Add("The spell bounces off the Shopkeeper!")
                Game.pushLblCombatEvent("The spell bounces off the Shopkeeper!")
                c.mana -= 10
                If c.mana < 0 Then c.mana = 0
            End If
        Else
            Dim r As Integer = Int(Rnd() * 3)
            If r = 0 Then
                spellroute(c, t, s)
            Else
                Game.lstLog.Items.Add("The spell bounces off Targax!")
                Game.pushLblCombatEvent("The spell bounces off Targax!")
                c.mana -= 10
                If c.mana < 0 Then c.mana = 0
            End If
        End If
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub DragonsBreath(ByRef target As Monster, ByRef caster As Player)
        If caster.mana < 10 And caster.title <> "Dragon" Then
            Game.lstLog.Items.Add("Not enough mana!")
            Game.pushLblCombatEvent("Not enough mana!")
            Exit Sub
        End If
        Game.lstLog.Items.Add("Breath FIRE!")
        target.takeDMG(75)
        If caster.title <> "Dragon" Then caster.mana -= 10
        Game.lstLog.Items.Add(CStr("You hit the " & target.name & " for 75 damage!"))
        Game.pushLblCombatEvent(CStr("You hit the " & target.name & " for 75 damage!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub Fireball(ByRef target As Monster, ByRef caster As Player)
        If caster.mana < 5 And caster.title <> "Fire Elemental" Then
            Game.lstLog.Items.Add("Not enough mana!")
            Game.pushLblCombatEvent("Not enough mana!")
            Exit Sub
        End If
        Game.lstLog.Items.Add("Cast Fireball!")
        target.takeDMG(45)
        If caster.title <> "Fire Elemental" Then caster.mana -= 5
        Game.lstLog.Items.Add(CStr("You hit the " & target.name & " for 45 damage!"))
        Game.pushLblCombatEvent(CStr("You hit the " & target.name & " for 45 damage!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub SuperFireball(ByRef target As Monster, ByRef caster As Player)
        If caster.mana < 8 And caster.title <> "Fire Elemental" Then
            Game.lstLog.Items.Add("Not enough mana!")
            Game.pushLblCombatEvent("Not enough mana!")
            Exit Sub
        ElseIf caster.title = "Fire Elemental" And caster.mana < 2 Then
            Game.lstLog.Items.Add("Not enough mana!")
            Exit Sub
        End If
        Game.lstLog.Items.Add("Cast Super Fireball!")
        target.takeDMG(60)
        If caster.title <> "Fire Elemental" Then caster.mana -= 8 Else caster.mana -= 2
        Game.lstLog.Items.Add(CStr("You hit the " & target.name & " for 60 damage!"))
        Game.pushLblCombatEvent(CStr("You hit the " & target.name & " for 60 damage!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub HBSC(ByRef target As Monster, ByRef caster As Player)
        If caster.mana < 6 Then
            Game.lstLog.Items.Add("Not enough mana!")
            Game.pushLblCombatEvent("Not enough mana!")
            Exit Sub
        End If
        Game.lstLog.Items.Add("Cast Heartblast Starcannon!")
        target.takeDMG(65)
        caster.mana -= 5
        Game.lstLog.Items.Add(CStr("You hit the " & target.name & " for 65 damage!"))
        Game.pushLblCombatEvent(CStr("You hit the " & target.name & " for 65 damage!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub IcicleSpear(ByRef target As Monster, ByRef caster As Player)
        If caster.mana < 6 And caster.title <> "Ice Elemental" Then
            Game.lstLog.Items.Add("Not enough mana!")
            Game.pushLblCombatEvent("Not enough mana!")
            Exit Sub
        End If
        Game.lstLog.Items.Add("Cast Icicle Spear!")
        target.takeDMG(55)
        If caster.title <> "Ice Elemental" Then caster.mana -= 6
        Game.lstLog.Items.Add(CStr("You hit the " & target.name & " for 55 damage!"))
        Game.pushLblCombatEvent(CStr("You hit the " & target.name & " for 55 damage!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub SelfPolymorph(ByRef caster As Player)
        If caster.mana < 5 Then
            Game.lstLog.Items.Add("Not enough mana!")
            Game.pushLblCombatEvent("Not enough mana!")
            Exit Sub
        End If
        Game.lstLog.Items.Add("Cast Self Polymorph!")
        caster.mana -= 5
        Polymorph.porm = True
        Dim p As Polymorph = New Polymorph
        p.ShowDialog()
        p.Dispose()
        Game.lstLog.Items.Add(CStr("You turn yourself into a " & Game.player.title & "!"))
        Game.pushLblCombatEvent(CStr("You turn yourself into a " & Game.player.title & "!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub EnemyPolymorph(ByRef target As Monster, ByRef caster As Player)
        If caster.mana < 5 Then
            Game.lstLog.Items.Add("Not enough mana!")
            Game.pushLblCombatEvent("Not enough mana!")
            Exit Sub
        End If
        Game.lstLog.Items.Add("Cast Enemy Polymorph!")
        caster.mana -= 5
        Polymorph.porm = False
        Dim p As Polymorph = New Polymorph
        p.target = target
        p.ShowDialog()
        p.Dispose()
        If target.GetType() Is GetType(NPC) Then
            target.update()
        End If
        Game.lstLog.Items.Add(CStr("You transform" & target.title & " " & target.name & "!"))
        Game.pushLblCombatEvent(CStr("You transform" & target.title & " " & target.name & "!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub turnToFrog(ByRef target As Monster, ByRef caster As Player)
        If caster.mana < 9 Then
            Game.lstLog.Items.Add("Not enough mana!")
            Game.pushLblCombatEvent("Not enough mana!")
            Exit Sub
        End If
        Game.lstLog.Items.Add("Cast Turn to Frog!")
        target.tfCt = 1
        target.tfEnd = 15
        target.form = "Frog"
        target.attack = 1
        target.defence = 1
        target.speed = 1
        If target.health > 50 Then target.health = 50
        target.maxHealth = 50
        caster.mana -= 9
        Game.lstLog.Items.Add(CStr("You hit the " & target.name & ", turning " & target.rPronoun & " into a frog!"))
        Game.pushLblCombatEvent(CStr("You hit the " & target.name & ", turning " & target.rPronoun & " into a frog!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub turnToFrogN(ByRef target As NPC, ByRef caster As Player)
        If caster.mana < 9 Then
            Game.lstLog.Items.Add("Not enough mana!")
            Game.pushLblCombatEvent("Not enough mana!")
            Exit Sub
        End If
        Game.lstLog.Items.Add("Cast Turn to Frog!")
        target.tfCt = 1
        target.tfEnd = 15
        target.form = "Frog"
        target.attack = 1
        target.defence = 1
        target.speed = 1
        target.npcIndex = 1
        Game.npcIndex = target.npcIndex
        If target.health > 50 Then target.health = 50
        target.maxHealth = 50
        caster.mana -= 9
        Game.lstLog.Items.Add(CStr("You hit the " & target.name & ", turning " & target.rPronoun & " into a frog!"))
        Game.pushLblCombatEvent(CStr("You hit the " & target.name & ", turning " & target.rPronoun & " into a frog!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub MindShrink(ByRef target As Monster, ByRef caster As Player)
        If caster.mana < 3 Then
            Game.lstLog.Items.Add("Not enough mana!")
            Game.pushLblCombatEvent("Not enough mana!")
            Exit Sub
        End If
        Game.lstLog.Items.Add("Cast Mindshrink!")
        If target.attack > 0 Then target.attack -= 5
        If target.defence > 0 Then target.defence -= 5
        If target.speed > 0 Then target.speed -= 5

        If target.attack < 0 Then target.attack = 0
        If target.defence < 0 Then target.defence = 0
        If target.speed < 0 Then target.speed = 0

        caster.mana -= 3
        Game.lstLog.Items.Add(CStr("You reduced the " & target.name & "'s stats!"))
        Game.pushLblCombatEvent(CStr("You reduced the " & target.name & "'s stats!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub ArcaneHypnosis(ByRef target As Monster, ByRef caster As Player)
        If caster.mana < 7 Then
            Game.lstLog.Items.Add("Not enough mana!")
            Game.pushLblCombatEvent("Not enough mana!")
            Exit Sub
        End If
        Game.lstLog.Items.Add("Cast Arcane Hypnosis!")
        caster.mana -= 7
        Dim p As Hypnosis = New Hypnosis
        p.target = target
        p.ShowDialog()
        p.Dispose()
        Game.lstLog.Items.Add(CStr("You transform" & target.title & " " & target.name & "!"))
        Game.pushLblCombatEvent(CStr("You transform" & target.title & " " & target.name & "!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub Petrify(ByRef target As Monster, ByRef caster As Player)
        If caster.mana < 5 And caster.title <> "Gorgon" Then
            Game.lstLog.Items.Add("Not enough mana!")
            Game.pushLblCombatEvent("Not enough mana!")
            Exit Sub
        End If
        Game.lstLog.Items.Add("Cast Petrify!")
        If caster.title <> "Gorgon" Then caster.mana -= 5
        If target.GetType() Is GetType(Monster) Then
            Game.lstLog.Items.Add(CStr("Your magic strikes the " & target.name & " in the chest, turning it briefly to stone!"))
            Game.pushLblCombatEvent(CStr("Your magic strikes the " & target.name & " in the chest, turning it briefly to stone!"))
        Else
            Game.lstLog.Items.Add(CStr("Your magic strikes " & target.name & " in the chest, turning " & target.rPronoun & " to stone"))
            Game.pushLblCombatEvent(CStr("Your magic strikes " & target.name & " in the chest, turning " & target.rPronoun & " to stone"))
        End If
        If target.speed Mod 5 > 0 Then
            Game.lstLog.Items.Add(CStr(target.speed Mod 5 & " more until they become a statue!"))
            Game.pushLblCombatEvent(CStr(target.speed Mod 5 & " more until they become a statue!"))
        End If

        If target.speed > 0 Then
            If caster.title <> "Gorgon" Then target.speed -= 5 Else target.speed -= 100
        Else
            target.toStatue()
            Game.lstLog.Items.Add(CStr("You see a statue here."))
        End If
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub turnToBlade(ByRef target As Monster, ByRef caster As Player)
        If caster.mana < 9 Then
            Game.lstLog.Items.Add("Not enough mana!")
            Game.pushLblCombatEvent("Not enough mana!")
            Exit Sub
        End If
        Game.lstLog.Items.Add("Cast Turn to Blade!")
        caster.inventory.Item(9).addOne()
        If caster.inventory.Item(9).count < 1 Then caster.inventory.Item(9).remove()
        caster.UIupdate()
        caster.inventory.Item(9).absorb(target)
        caster.mana -= 9
        Game.lstLog.Items.Add(CStr("You hit the " & target.name & ", turning " & target.rPronoun & " into a sword!"))
        Game.pushLblCombatEvent(CStr("You hit the " & target.name & ", turning " & target.rPronoun & " into a sword!"))
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub

    Shared Sub spellroute(ByRef c As Player, ByRef t As Monster, ByRef s As String)
        If s = "Dragon's Breath" Then
            Spells.DragonsBreath(t, c)
        ElseIf s = "Fireball" Then
            Spells.Fireball(t, c)
        ElseIf s = "Super Fireball" Then
            Spells.SuperFireball(t, c)
        ElseIf s = "Icicle Spear" Then
            Spells.IcicleSpear(t, c)
        ElseIf s = "Heartblast Starcannon" Then
            Spells.HBSC(t, c)
        ElseIf s = "Petrify" Then
            Spells.Petrify(t, c)
        Else
            Dim range As Integer = Int(Rnd() * 20)
            Dim diceroll As Integer = Int(Rnd() * 20)
            If diceroll < range Then
                If s = "Self Polymorph" And Not c.title.Equals("Magic Girl") Then
                    Spells.SelfPolymorph(c)
                ElseIf s = "Self Polymorph" And c.title.Equals("Magic Girl") Then
                    Game.lstLog.Items.Add("You can't polymorph yourself!")
                    Game.pushLblCombatEvent("You can't polymorph yourself!")
                End If
                If s = "Polymorph Enemy" Then Spells.EnemyPolymorph(t, c)
                If s = "Turn to Frog" Then Spells.turnToFrog(t, c)
                If s = "Mindshrink" Then Spells.MindShrink(t, c)
                If s = "Petrify" Then Spells.Petrify(t, c)
                If s = "Turn to Blade" Then Spells.turnToBlade(t, c)
            Else
                If 1 = 1 Then
                    Game.lstLog.Items.Add("The spell fails as you cast it!")
                    Game.pushLblCombatEvent("The spell fails as you cast it!")
                Else
                    Game.lstLog.Items.Add("The spell bounces off your opponent!")
                End If
                c.mana -= 10
                If c.mana < 0 Then c.mana = 0
            End If
        End If
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
End Class
