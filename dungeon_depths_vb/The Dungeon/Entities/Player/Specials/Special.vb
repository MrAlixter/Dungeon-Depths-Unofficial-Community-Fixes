Public Class Special
    Dim cost As Integer
    Dim name As String
    Dim user As Player
    Dim target As NPC

    Dim useableOutOfCombat As Boolean = False
    Sub New(ByRef u As Player, ByRef t As NPC)
        user = u
        target = t
    End Sub
    Sub perform()
        If (user.hunger + cost) > 100 Then
            Game.pushLblEvent("You are too famished to use this special! (" & name & " costs " & cost & " hunger)")
            Game.pushLstLog("You are too hungry!")
            Exit Sub
        End If
        If Not Game.combatmode And Not Game.npcmode And Not useableOutOfCombat Then
            Game.pushLblEvent("You don't have a target for that special!")
            Game.pushLstLog("You don't have a target for that special!")
            Exit Sub
        End If
        Randomize()
        If cost = -1 Then
            Game.cboxSpec.Items.Remove(name)
        Else
            user.hunger += cost
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
    Sub setUOC(ByVal b As Boolean)
        useableOutOfCombat = b
    End Sub

    Function getUser() As Player
        Return user
    End Function
    Function getTarget() As NPC
        Return target
    End Function


    Shared Sub specPerform(ByRef t As NPC, ByRef u As Player, ByVal s As String)
        specroute(u, t, s)
    End Sub
    Shared Sub specroute(ByRef u As Player, ByRef t As NPC, ByRef s As String)
        Dim spec As Special = New AFK(u, t)

        If s.Equals("Berserker Rage") Then
            spec = New BRage(u, t)
        ElseIf s.Equals("Risky Decision") Then
            spec = New RDesc(u, t)
        ElseIf s.Equals("Massive Mammaries") Then
            spec = New MMam(u, t)
        ElseIf s.Equals("Unholy Seduction") Then
            spec = New USed(u, t)
        ElseIf s.Equals("Absorbtion") Then
            spec = New Abso(u, t)
        ElseIf s.Equals("Ironhide Fury") Then
            spec = New IHFu(u, t)
        ElseIf s.Equals("Ritual of Mana") Then
            spec = New RitOfMana(u, t)
        ElseIf s.Equals("Cleanse") Then
            spec = New Cleanse(u, t)
        ElseIf s.Equals("Spot Fusion") Then
            spec = New SpotFusion(u, t)
        ElseIf s.Equals("Rapid Fire Jabs") Then
            spec = New RapidFireJabs(u, t)
        ElseIf s.Equals("Focused Roundhouse") Then
            spec = New FocusedKick(u, t)
        ElseIf s.Equals("Heavy Blow") Then
            spec = New HeavyBlow(u, t)
        ElseIf s.Equals("Focused Barrage") Then
            spec = New FBarra(u, t)
        ElseIf s.Equals("Ki Wave Blast") Or s.Equals("Aura Cannon") Then
            spec = New ACannon(u, t)
        ElseIf s.Equals("Uvona's Blessing") Then
            spec = New UBlessing(u, t)
        ElseIf s.Equals("Shrink_Ray Shot") Then
            spec = New ShrinkRayShoot(u, t)
        ElseIf s.Equals("Bounty's Collection") Then
            spec = New Bounty(u, t)
        ElseIf s.Equals("Blazing Angel Strike") Then
            spec = New BAStrike(u, t)
        ElseIf s.Equals("Pillowy Protect") Then
            spec = New PProt(u, t)
        ElseIf s.Equals("Mana Burst") Then
            spec = New MBurst(u, t)
        ElseIf s.Equals("Inferno Aura") Then
            spec = New InfernoAura(u, t)
        ElseIf s.Equals("Megaton Punch") Then
            spec = New BurningPunch(u, t)
        ElseIf s.Equals("Gigaton Punch") Then
            spec = New GigaPunch(u, t)
        End If

        spec.perform()
    End Sub
    Shared Function specCost(ByVal s As String)
        Select Case s
            Case "Ritual of Mana"
                If Game.player1.getMana < 5 Then
                    Return "+20 hunger"
                ElseIf Game.player1.getMana < 10 Then
                    Return "+40 hunger"
                ElseIf Game.player1.getMana < 15 Then
                    Return "+60 hunger"
                ElseIf Game.player1.getMana < 20 Then
                    Return "+80 hunger"
                ElseIf Game.player1.getMana < 30 Then
                    Return "+100 hunger"
                Else
                    Return "+120 hunger"
                End If
            Case "Cleanse"
                Return "+15 hunger"
            Case "Spot Fusion"
                Return "+50 hunger "
            Case "Rapid Fire Jabs"
                Return "+9 hunger for the first jab, and +6 hunger for each additional jab"
            Case "Focused Roundhouse"
                Return "+16 hunger"
            Case "Heavy Blow"
                Return "+24 hunger"
            Case "Focused Barrage"
                Return "+6 hunger for the first hit, and +4 hunger for each additional hit"
            Case Else
                Return "Useable only once per combat, or consumes an amount of hunger"
        End Select
    End Function
End Class
