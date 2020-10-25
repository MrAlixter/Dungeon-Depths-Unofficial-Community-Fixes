Public Class Special
    Dim cost As Integer
    Dim name As String
    Dim user As Player
    Dim target As NPC

    Shared specialList As Dictionary(Of String, Special)
    Dim useableOutOfCombat As Boolean = False
    Shared Sub init()
        specialList = New Dictionary(Of String, Special)

        specialList.Add("Berserker Rage", New BRage(Nothing, Nothing))
        specialList.Add("Risky Decision", New RDesc(Nothing, Nothing))
        specialList.Add("Massive Mammaries", New MMam(Nothing, Nothing))
        specialList.Add("Unholy Seduction", New USed(Nothing, Nothing))
        specialList.Add("Charm", New USed(Nothing, Nothing))
        specialList.Add("Drain Soul", New DrainSoul(Nothing, Nothing))
        specialList.Add("Absorbtion", New Abso(Nothing, Nothing))
        specialList.Add("Ironhide Fury", New IHFu(Nothing, Nothing))
        specialList.Add("Ritual of Mana", New RitOfMana(Nothing, Nothing))
        specialList.Add("Cleanse", New Cleanse(Nothing, Nothing))
        specialList.Add("Spot Fusion", New SpotFusion(Nothing, Nothing))
        specialList.Add("Rapid Fire Jabs", New RapidFireJabs(Nothing, Nothing))
        specialList.Add("Focused Roundhouse", New FocusedKick(Nothing, Nothing))
        specialList.Add("Heavy Blow", New HeavyBlow(Nothing, Nothing))
        specialList.Add("Focused Barrage", New FBarra(Nothing, Nothing))
        specialList.Add("Ki Wave Blast", New ACannon(Nothing, Nothing))
        specialList.Add("Aura Cannon", New ACannon(Nothing, Nothing))
        specialList.Add("Uvona's Blessing", New UBlessing(Nothing, Nothing))
        specialList.Add("Shrink_Ray Shot", New ShrinkRayShoot(Nothing, Nothing))
        specialList.Add("Bounty's Collection", New Bounty(Nothing, Nothing))
        specialList.Add("Blazing Angel Strike", New BAStrike(Nothing, Nothing))
        specialList.Add("Helix Slash", New BAStrike(Nothing, Nothing))
        specialList.Add("Pillowy Protect", New PProt(Nothing, Nothing))
        specialList.Add("Mana Burst", New MBurst(Nothing, Nothing))
        specialList.Add("Inferno Aura", New InfernoAura(Nothing, Nothing))
        specialList.Add("Megaton Punch", New BurningPunch(Nothing, Nothing))
        specialList.Add("Gigaton Punch", New GigaPunch(Nothing, Nothing))
        specialList.Add("Dodge", New Dodge(Nothing, Nothing))
        specialList.Add("Tits Up", New TUp(Nothing, Nothing))
        specialList.Add("Tits Down", New TDn(Nothing, Nothing))
        specialList.Add("Dick Up", New DUp(Nothing, Nothing))
        specialList.Add("Dick Down", New DDn(Nothing, Nothing))
        specialList.Add("Ass Up", New UUp(Nothing, Nothing))
        specialList.Add("Ass Down", New UDn(Nothing, Nothing))
        specialList.Add("Chameleon (Blonde)", New CHBlonde(Nothing, Nothing))
        specialList.Add("Chameleon (Black Hair)", New CHBlackHair(Nothing, Nothing))
        specialList.Add("Chameleon (Redhead)", New CHRedhead(Nothing, Nothing))
        specialList.Add("Chameleon (Brunette)", New CHBrunette(Nothing, Nothing))
        specialList.Add("Chameleon (Pastels)", New CHPastels(Nothing, Nothing))
        specialList.Add("Chameleon (Neon)", New CHNeon(Nothing, Nothing))
        specialList.Add("Nothing", New AFK(Nothing, Nothing))
        specialList.Add("Blade Breaker", New BladeBreaker(Nothing, Nothing))
        specialList.Add("Guard Up", New GuardUp(Nothing, Nothing))
        specialList.Add("Triple Strike", New TripleStrike(Nothing, Nothing))
        specialList.Add("Will Up", New WillUp(Nothing, Nothing))
        specialList.Add("Flash Strike", New FlashStrike(Nothing, Nothing))
        specialList.Add("Attack Up", New AttackUp(Nothing, Nothing))
        specialList.Add("Lurk", New Lurk(Nothing, Nothing))
        specialList.Add("Snare", New Snare(Nothing, Nothing))
    End Sub

    Sub New(ByRef u As Player, ByRef t As NPC)
        user = u
        target = t
    End Sub
    Sub perform()
        If (user.stamina - getCost()) < 0 Then
            Game.pushLblEvent("You don't have enough stamina to use this special! (" & name & " costs " & getCost() & " stamina)")
            Game.pushLstLog("You don't have enough stamina to use this special!")
            Exit Sub
        End If
        If Not Game.combatmode And Not Game.npcmode And Not useableOutOfCombat Then
            Game.pushLblEvent("You don't have a target for that special!")
            Game.pushLstLog("You don't have a target for that special!")
            Exit Sub
        End If
        Randomize()
        If getCost() = -1 Then
            Game.cboxSpec.Items.Remove(name)
        Else
            user.stamina -= getCost()
        End If

        Game.pushLblEvent("You perform " & name & "!")
        Game.pushLstLog("You perform " & name & "!")
        effect()
    End Sub
    Overridable Sub effect()
        Game.pushLblEvent("No effects.")
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
    Sub redefineCandT(ByRef u As Player, ByRef t As NPC)
        user = u
        target = t
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
