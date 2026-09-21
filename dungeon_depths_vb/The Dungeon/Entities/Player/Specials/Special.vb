Public Class Special
    Dim cost As Integer
    Dim name As String
    Dim user As Player
    Dim target As NPC

    Public Shared specialList As Dictionary(Of String, Special)
    Dim useableOutOfCombat As Boolean = False

    Shared Sub init()
        specialList = New Dictionary(Of String, Special)

        specialList.Add("Berserker Rage", New BRage(Nothing, Nothing))
        specialList.Add("Risky Decision", New RDesc(Nothing, Nothing))
        specialList.Add("Massive Mammaries", New MMam(Nothing, Nothing))
        specialList.Add("Unholy Seduction", New USed(Nothing, Nothing))
        specialList.Add("Charm", New USed(Nothing, Nothing))
        specialList.Add("Drain Soul", New DrainSoul(Nothing, Nothing))
        specialList.Add("Absorbtion", New Absorption(Nothing, Nothing))
        specialList.Add("Ironhide Fury", New IHFu(Nothing, Nothing))
        specialList.Add("Ritual of Mana", New RitOfMana(Nothing, Nothing))
        specialList.Add("Cleanse", New Cleanse(Nothing, Nothing))
        specialList.Add("Spot Fusion", New SpotFusion(Nothing, Nothing))
        specialList.Add("Rapid Fire Jabs", New RapidFireJabs(Nothing, Nothing))
        specialList.Add("Focused Roundhouse", New FocusedRoundhouse(Nothing, Nothing))
        specialList.Add("Heavy Blow", New HeavyBlow(Nothing, Nothing))
        specialList.Add("Focused Barrage", New FocusedBarrage(Nothing, Nothing))
        specialList.Add("Ki Wave Blast", New AuraCannon(Nothing, Nothing))
        specialList.Add("Aura Cannon", New AuraCannon(Nothing, Nothing))
        specialList.Add("Uvona's Blessing", New UBlessing(Nothing, Nothing))
        specialList.Add("Shrink_Ray Shot", New ShrinkRayShoot(Nothing, Nothing))
        specialList.Add("Bounty's Collection", New BountysCollection(Nothing, Nothing))
        specialList.Add("Helix Slash", New HelixSlash(Nothing, Nothing))
        specialList.Add("Pillowy Protect", New PProt(Nothing, Nothing))
        specialList.Add("Mana Burst", New MBurst(Nothing, Nothing))
        specialList.Add("Inferno Aura", New InfernoAura(Nothing, Nothing))
        specialList.Add("Megaton Punch", New MegatonPunch(Nothing, Nothing))
        specialList.Add("Gigaton Punch", New GigatonPunch(Nothing, Nothing))
        specialList.Add("Dodge", New Shapeshift(Nothing, Nothing))
        specialList.Add("Tits Up", New Shapeshift(Nothing, Nothing, "bup"))
        specialList.Add("Tits Down", New Shapeshift(Nothing, Nothing, "bdn"))
        specialList.Add("Dick Up", New Shapeshift(Nothing, Nothing, "dup"))
        specialList.Add("Dick Down", New Shapeshift(Nothing, Nothing, "ddn"))
        specialList.Add("Ass Up", New Shapeshift(Nothing, Nothing, "wup"))
        specialList.Add("Ass Down", New Shapeshift(Nothing, Nothing, "wdn"))
        specialList.Add("Chameleon (Blonde)", New Chameleon(Nothing, Nothing, "blo"))
        specialList.Add("Chameleon (Black Hair)", New Chameleon(Nothing, Nothing, "bla"))
        specialList.Add("Chameleon (Redhead)", New Chameleon(Nothing, Nothing, "red"))
        specialList.Add("Chameleon (Brunette)", New Chameleon(Nothing, Nothing, "bru"))
        specialList.Add("Chameleon (Pastels)", New Chameleon(Nothing, Nothing, "pst"))
        specialList.Add("Chameleon (Neon)", New Chameleon(Nothing, Nothing, "neo"))
        specialList.Add("Nothing", New AFK(Nothing, Nothing))
        specialList.Add("Blade Breaker", New BladeBreaker(Nothing, Nothing))
        specialList.Add("Guard Up", New GuardUp(Nothing, Nothing))
        specialList.Add("Triple Strike", New TripleStrike(Nothing, Nothing))
        specialList.Add("Will Up", New WillUp(Nothing, Nothing))
        specialList.Add("Flash Strike", New FlashStrike(Nothing, Nothing))
        specialList.Add("Attack Up", New AttackUp(Nothing, Nothing))
        specialList.Add("Lurk", New Lurk(Nothing, Nothing))
        specialList.Add("Snare", New Snare(Nothing, Nothing))
        specialList.Add("Focus Up", New FocusUp(Nothing, Nothing))
        specialList.Add("Mirage Dance", New MirageDance(Nothing, Nothing))
        specialList.Add("Pluck", New Pluck(Nothing, Nothing))
        specialList.Add("Cleansing Light", New CLight(Nothing, Nothing))
        specialList.Add("Swashbuckle", New Swashbuckle(Nothing, Nothing))
        specialList.Add("Crow's Nest", New Crowsnest(Nothing, Nothing))
        specialList.Add("Chameleon", New Chameleon(Nothing, Nothing))
        specialList.Add("Absorption", New Absorption(Nothing, Nothing))
        specialList.Add("Absorption II", New AbsorptionII(Nothing, Nothing))
        specialList.Add("Keep Away", New KeepAway(Nothing, Nothing))
        specialList.Add("Pierce And Punish", New PierceAndPunish(Nothing, Nothing))
        specialList.Add("Power Drill", New PowerDrill(Nothing, Nothing))
        specialList.Add("Vampiric Thrust", New VampiricThrust(Nothing, Nothing))
        specialList.Add("Optimal Chop", New OptimalChop(Nothing, Nothing))
        specialList.Add("Guillotine", New Guillotine(Nothing, Nothing))
        specialList.Add("Twofold Slash", New TwofoldSlash(Nothing, Nothing))
        specialList.Add("Cleave", New Cleave(Nothing, Nothing))
        specialList.Add("Zoom Step", New ZoomStep(Nothing, Nothing))
        specialList.Add("Thwack Barrage", New ThwackBarrage(Nothing, Nothing))
        specialList.Add("Draw Cut", New DrawCut(Nothing, Nothing))
        specialList.Add("Fencing Flurry", New FencingFlurry(Nothing, Nothing))
        specialList.Add("Mordhau", New Mordhau(Nothing, Nothing))
        specialList.Add("Slit", New Slit(Nothing, Nothing))
        specialList.Add("Stab Barrage", New StabBarrage(Nothing, Nothing))
        specialList.Add("Precision Incision", New PrecisionIncision(Nothing, Nothing))
        specialList.Add("Hit and Run", New HitAndRun(Nothing, Nothing))
        specialList.Add("Crackleg Snare", New CracklegSnare(Nothing, Nothing))
        specialList.Add("Yoink", New Yoink(Nothing, Nothing))
        specialList.Add("Countercrack", New Countercrack(Nothing, Nothing))
        specialList.Add("Shapeshift", New Shapeshift(Nothing, Nothing))
        specialList.Add("Enskimpen", New Enskimpen(Nothing, Nothing))
        specialList.Add("Beelzebodkin", New Beelzebodkin(Nothing, Nothing))
        specialList.Add("Blade of Nails", New BladeOfNails(Nothing, Nothing))
        specialList.Add("Lililash", New Lililash(Nothing, Nothing))
        specialList.Add("Lucifork", New Lucifork(Nothing, Nothing))
    End Sub

    Sub New(ByRef u As Player, ByRef t As NPC)
        user = u
        target = t
    End Sub
    Sub perform()
        Try

            If getCost() = -1 And user.skillsUsedThisCombat.Contains(name) Then
                TextEvent.push("You've already used '" & name & "' this combat!")
                TextEvent.pushLog("You've already used '" & name & "' this combat!")
                Exit Sub
            ElseIf getCost() = -1 Then
                user.skillsUsedThisCombat.Add(name)
            End If
            If (user.stamina - getCost()) < 0 Then
                TextEvent.push("You don't have enough stamina to use this special! (" & name & " costs " & getCost() & " stamina)")
                TextEvent.pushLog("You don't have enough stamina to use this special!")
                Exit Sub
            End If
            If Not Game.combat_engaged And Not Game.shop_npc_engaged And Not useableOutOfCombat Then
                TextEvent.push("You don't have a target for that special!")
                TextEvent.pushLog("You don't have a target for that special!")
                Exit Sub
            End If
            Randomize()
            If getCost() = -1 Then
                Game.cboxSpec.Items.Remove(name)
            Else
                user.stamina -= getCost()
            End If

            TextEvent.push("You perform " & name & "!")
            TextEvent.pushLog("You perform " & name & "!")
            GameDiagnostics.Remember("Special: " & name, GameDiagnostics.Context(user, Game.currFloor, target))
            effect()
        Catch diagnosticError As Exception
            GameDiagnostics.Record(diagnosticError, "perform", GameDiagnostics.Context(user, Game.currFloor, target))
            Throw
        End Try
    End Sub
    Overridable Sub effect()
        TextEvent.push("No effects.")
    End Sub
    Sub setName(ByVal s As String)
        name = s
    End Sub
    Sub setcost(ByVal i As Integer)
        cost = i
    End Sub
    Overridable Function getCost() As Integer
        Return cost
    End Function
    Sub setUOC(ByVal b As Boolean)
        useableOutOfCombat = b
    End Sub

    Function getUser() As Player
        Return user
    End Function
    Function getTarget() As NPC
        Return target
    End Function
    Function getName() As String
        Return name
    End Function
    Public Overridable Function getDesc(ByRef c As Player, ByRef t As NPC)
        Return "Description not added."
    End Function
    Sub redefineCandT(ByRef u As Player, ByRef t As NPC)
        user = u
        target = t
    End Sub

    Public Shared Sub specHit(spec As String, dmg As Integer, user As Player, target As NPC, Optional postfix As String = "")
        Dim t_took_dmg = target.takeDMG(dmg, user)

        If t_took_dmg And Not target.isDead Then
            TextEvent.push(CStr(spec & "!" & DDUtils.RNRN & "You hit " & target.getNameWithTitle() & " for " & DDUtils.formatBigNumber(dmg) & " damage!" & postfix))
            TextEvent.pushLog(CStr(spec & "!  You hit " & target.getNameWithTitle() & " for " & DDUtils.formatBigNumber(dmg) & " damage!" & postfix))
        ElseIf t_took_dmg Then
            TextEvent.push3rdLastLog(CStr(spec & "!  You hit " & target.getNameWithTitle() & " for " & DDUtils.formatBigNumber(dmg) & " damage!" & postfix))
        End If
    End Sub

    Shared Sub specPerform(ByRef t As NPC, ByRef u As Player, ByVal s As String)
        specroute(u, t, s)
    End Sub
    Shared Sub specroute(ByRef u As Player, ByRef t As NPC, ByRef s As String)
        Dim spec As Special = specialList(s)
        spec.redefineCandT(u, t)

        spec.perform()
    End Sub
    Shared Function specCost(ByVal s As String)
        Dim spec As Special = specialList(s)
        spec.redefineCandT(Game.player1, Nothing)

        Select Case s
            Case "Rapid Fire Jabs"
                Return "-9 stamina for the first jab, and -6 stamina for each additional jab"
            Case "Focused Barrage"
                Return "-6 stamina for the first hit, and -4 stamina for each additional hit"
            Case Else
                Dim cost = spec.getCost

                If cost > 0 Then
                    Return "-" & cost & " stamina"
                Else
                    Return "Useable only once per combat, or consumes an amount of stamina"
                End If
        End Select
    End Function
End Class
