Public Class ESuccPrincess
    Inherits ESuccubus

    Public Shadows Const BASE_NAME As String = "Succubus Princess"

    Private Enum mode
        none
        cow
        dick
        slut
        angel
    End Enum

    Dim pref_mode As mode = mode.none
    Dim tf_stage As Integer = 0

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 266
        attack = 99
        defense = 66
        speed = 666
        will = 69

        levelDrainThres = 2
        lustRaiseThres = 66
        levelsToDrain = 2
        lustToIncrease = Int(Rnd() * 6) + 6

        '|Inventory|
        setInventory({25, 74, 168, 194, 182, 205, 214, 218, 226, 227})

        '|Dialog Variables|
        pref_mode = getPrefMode()
        intro_taunt = getIntroTaunt()

        '|Misc|
        setupMonsterOnSpawn()
    End Sub

    '| - COMBAT - |
    Public Overrides Sub attackCMD(ByRef target As Entity)
        Dim d9 = Int(Rnd() * 9)

        If d9 = 0 Then
            If pref_mode = mode.slut Then
                curseOfTheSlut(target)
            ElseIf pref_mode = mode.cow Then
                mooForMe(target)
            ElseIf pref_mode = mode.dick Then
                standAtAttention(target)
            ElseIf pref_mode = mode.angel Then
                kissOfAmaraphne(target)
            End If
        Else
            MyBase.attackCMD(target)
        End If
    End Sub

    Private Sub curseOfTheSlut(ByRef target As Entity)
        If target.getPlayer Is Nothing Then
            MyBase.attackCMD(target)
            Exit Sub
        End If

        If target.getPlayer.className.Equals("Bimbo") And target.getPlayer.perks(perk.succubuscow) < 0 And Int(Rnd() * 2) = 0 Then
            pref_mode = mode.cow
            TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " pauses, as " & pronoun & " thinks something over." & DDUtils.RNRN &
                           """Hmm, maybe you'd make a better cow...""")
            MyBase.attackCMD(target)
            Exit Sub
        End If

        If target.getPlayer.perks(perk.succubuscurse) = -1 Then
            Dim p As Player = target.getPlayer

            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts ""Curse of the Slut!""")

            p.perks(perk.succubuscurse) = 0

            p.formStates(stateInd.dembimState1).save(p)
            p.formStates(stateInd.dembimState2).save(p)

        ElseIf target.getPlayer.getLust() < 33 Then
            Dim p As Player = target.getPlayer
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts ""Raise Lust!""")

            p.addLust(33 - p.getLust)

        ElseIf target.getPlayer.getLust() < 66 Then
            Dim p As Player = target.getPlayer
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " casts ""Raise Lust!""")

            p.addLust(66 - p.getLust)

        ElseIf target.getPlayer.getLust() >= 66 And tf_stage < 1 Then
            Dim p As Player = target.getPlayer
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " draws a myterious sigil on your abdomen.")

            If p.inv.getCountAt(SPCursemark.ITEM_NAME) < 1 Then p.inv.add(SPCursemark.ITEM_NAME, 1)
            EquipmentDialogBackend.equipAcce(p, SPCursemark.ITEM_NAME, False)

            tf_stage = 2

        ElseIf tf_stage >= 1 Then
            pref_mode = mode.none
            TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " giggles as you swoon under the effect of " & p_pronoun & " curse." & DDUtils.RNRN &
                           """See, isn't that better?""")
        End If
    End Sub

    Private Sub mooForMe(ByRef target As Entity)
        If target.getPlayer Is Nothing Then
            MyBase.attackCMD(target)
            Exit Sub
        End If

        If target.getPlayer.perks(perk.succubuscurse) < 0 And Not target.getPlayer.className.Equals("Bimbo") And Int(Rnd() * 2) = 0 Then
            pref_mode = mode.slut
            TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " pauses, as " & pronoun & " thinks something over." & DDUtils.RNRN &
                           """Hmm, maybe you could use some help relaxing...""")
            MyBase.attackCMD(target)
            Exit Sub
        End If

        If Not target.getPlayer.formName.Equals("Succubus") And target.getPlayer.perks(perk.succubuscow) = -1 Then
            TextEvent.pushAndLog("The " & getName() & " casts ""Moo for Me!""")
            target.getPlayer.perks(perk.succubuscow) = 1
            MinoDTF.tfPlayer(CType(target, Player).perks(perk.succubuscow), CType(target, Player))

        ElseIf Not target.getPlayer.formName.Equals("Succubus") Then
            TextEvent.pushAndLog("The " & getName() & " casts ""Moo for Me!""")
            target.getPlayer.perks(perk.succubuscow) += 1
            MinoDTF.tfPlayer(CType(target, Player).perks(perk.succubuscow), CType(target, Player))

        ElseIf target.getPlayer.formName.Equals("Succubus") And target.getPlayer.perks(perk.succubuscow) <> -1 And target.getPlayer.breastSize > 3 Then
            pref_mode = mode.none
            TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " giggles as you struggle to keep your balance, thrown off by your swaying udders." & DDUtils.RNRN &
                           """You can thank me with your soul...""")

        Else
            pref_mode = mode.none
            MyBase.attackCMD(target)
        End If
    End Sub

    Private Sub standAtAttention(ByRef target As Entity)
        If target.getPlayer Is Nothing Then
            MyBase.attackCMD(target)
            Exit Sub
        End If

        If target.getPlayer.dickSize < 0 Then
            TextEvent.push("The " & getName() & " casts Stand at Attention!  You now have a penis...")
            TextEvent.pushLog("The " & getName() & " casts Stand at Attention!")

            target.getPlayer.de()
            target.getPlayer.addLust(33)

        ElseIf target.getPlayer.dickSize < 3 Then
            TextEvent.pushAndLog("The " & getName() & " casts Stand at Attention!  Your dick tingles warmly!")

            target.getPlayer.de()
            target.getPlayer.addLust(33)

        ElseIf target.getPlayer.dickSize >= 3 Then
            pref_mode = mode.none
            MyBase.attackCMD(target)
        End If
    End Sub

    Private Sub kissOfAmaraphne(ByRef target As Entity)
        If target.getPlayer Is Nothing Then
            MyBase.attackCMD(target)
            Exit Sub
        End If

        If tf_stage = 0 Then

        ElseIf tf_stage = 1 Then

        End If
    End Sub

    Public Overrides Sub sapLevel(ByRef t As Entity)
        If t.GetType Is GetType(Player) Then sapPlayer(CType(t, Player)) Else sapEntity(t)

        maxHealth *= 1.2
        attack *= 1.2
        defense *= 1.2
        speed *= 1.2

        TextEvent.push("The " & getName() & " used Drain Soul!  " & levelsToDrain & " levels drained!")
        TextEvent.pushLog("The " & getName() & " used Drain Soul!  " & levelsToDrain & " levels drained!")
    End Sub
    Public Overrides Sub sapPlayer(ByRef p As Player)
        drainedXP += p.deLevel(levelsToDrain)
        If Not explainedDrain Then TextEvent.pushAndLog("Defeat " & getNameWithTitle() & " to regain your lost XP!") : explainedDrain = True
    End Sub
    Public Overrides Sub sapEntity(ByRef e As Entity)
        e.maxHealth *= 0.8
        e.attack *= 0.8
        e.defense *= 0.8
        e.maxMana *= 0.8
        e.speed *= 0.8
        e.will *= 0.8
    End Sub

    Public Overrides Sub charm(ByRef t As Entity)
        If Int(Rnd() * t.will) < 15 Then
            t.addLust(lustRaiseThres)
            TextEvent.push("The " & getName() & " used Charm!")
            TextEvent.pushLog("The " & getName() & " used Charm!")
        Else
            TextEvent.push("The " & getName() & " used Charm...but it fails...")
            TextEvent.pushLog("The " & getName() & " used Charm...but it fails...")
        End If
    End Sub

    '| - DEATH - |
    Public Overrides Sub die(ByRef cause As Entity)
        If cause.GetType() Is GetType(Player) Then
            Dim p = CType(cause, Player)

            If p.perks(perk.cynnsq1ct1) > -1 Then p.perks(perk.cynnsq1ct1) += 1

            If p.perks(perk.succubuscurse) > -1 Then

                Dim isPTFed = p.perks(perk.succubuscurse) > 0

                p.perks(perk.succubuscurse) = -1

                TextEvent.pushLog("The succubus's curse is lifted!")
                TextEvent.push(If(isPTFed, "The succubus's curse is lifted!  However, this does not revert your transformation...", "The succubus's curse is lifted!"))
            End If
        End If

        MyBase.die(cause)
    End Sub

    '| - MISC - |
    Private Function getPrefMode() As mode
        Dim r = Int(Rnd() * 3)

        'If (Game.player1.formName.Equals("Angel") Or Game.player1.className.Equals("Valkyrie")) And Not pref_mode = mode.angel Then
        '    Return mode.angel
        'End If 

        If r = 0 And Not pref_mode = mode.slut Then
            Return mode.slut
        ElseIf r = 1 And Not pref_mode = mode.cow Then
            Return mode.cow
        ElseIf r = 2 And Not pref_mode = mode.dick Then
            Return mode.dick
        End If

        Return mode.none
    End Function
    Private Function getIntroTaunt() As String
        Dim intro As String = DDUtils.capitalizeFirst(getNameWithTitle) & " cackles with sadistic glee as " & pronoun & " sizes you up." & DDUtils.RNRN

        Select Case pref_mode
            Case mode.slut
                Return intro & """Ooh, you look so serious...  Wouldn't things just be better if you just relaxed?"""
            Case mode.cow
                Return intro & """Would you mind giving me a little 'moo'?  No?  Hmm, let's change that attitude of yours..."""
            Case mode.dick
                Return intro & """Oh, you'd make a cute toy... with some tweaks, of course..."""
            Case mode.angel
                Return intro & """Poor little angel...  You could be so much happier if only you'd embrace another path."""
            Case Else
                Return intro & """Hello there...  Say, would you like to be my pet?"""
        End Select
    End Function
End Class
