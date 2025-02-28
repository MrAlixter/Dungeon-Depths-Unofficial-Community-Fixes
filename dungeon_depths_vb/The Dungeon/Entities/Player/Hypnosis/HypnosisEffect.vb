Public Enum h_ind
    misc
    namechange
    formreset
    learnspell
    learnspecial
    forgetspell
    forgetspecial
    classchange
    strip
    run
    surrender
    wait
    castspell
    attack
    focusup
    bimbokiss
End Enum

Public Class HypnosisEffect
    Public Shared Function hypnotize(ByRef p As Player, ByVal will_chk As Integer, ByVal i As h_ind) As Boolean
        If p.getWIL() > will_chk Then
            TextEvent.pushLog("Your will holds strong...")
            Return False
        End If

        p.perks(perk.hypnotized) = i

        Return True
    End Function

    '| - Triggers - |
    Public Shared Function trigger(ByRef p As Player, ByVal i As h_ind, Optional ByVal aux As String = "") As Boolean
        If p.perks(perk.hypnotized) <> i Then Return False

        p.perks(perk.hypnotized) = -1

        Select Case i
            Case h_ind.namechange
                Return nameChangeTrigger(p, aux)
            Case h_ind.formreset
                Return formResetTrigger(p)
            Case h_ind.learnspell
                Return learnSpellTrigger(p, aux)
            Case h_ind.learnspecial
                Return learnSpecialTrigger(p, aux)
            Case h_ind.forgetspell
                Return forgetSpellTrigger(p, aux)
            Case h_ind.forgetspecial
                Return forgetSpecialTrigger(p, aux)
            Case h_ind.classchange
                Return classChangeTrigger(p, aux)
            Case h_ind.strip
                Return stripTrigger(p)
            Case h_ind.run
                Return runTrigger(p)
            Case h_ind.surrender
                Return surrenderTrigger(p)
            Case h_ind.wait
                Return waitTrigger(p)
            Case h_ind.castspell
                Return castSpellTrigger(p, aux)
            Case h_ind.attack
                Return attackTrigger(p)
            Case h_ind.focusup
                Return focusUpTrigger(p)
            Case h_ind.bimbokiss
                Return bimboKissTrigger(p)
        End Select

        Return False
    End Function
    Protected Shared Function nameChangeTrigger(ByRef p As Player, ByVal name As String) As Boolean
        p.setName(name)

        TextEvent.pushLog("Your name has been changed to """ & name & """...")

        Return True
    End Function
    Protected Shared Function formResetTrigger(ByRef p As Player) As Boolean
        p.pState.save(p)
        p.sState.save(p)

        TextEvent.pushLog("Your base form has been reset to your current appearance.")

        Return True
    End Function
    Protected Shared Function learnSpellTrigger(ByRef p As Player, ByVal spell As String) As Boolean
        p.learnSpell(spell)

        Return True
    End Function
    Protected Shared Function learnSpecialTrigger(ByRef p As Player, ByVal spec As String) As Boolean
        p.learnSpecial(spec)

        Return True
    End Function
    Protected Shared Function forgetSpellTrigger(ByRef p As Player, ByVal spell As String) As Boolean
        p.forgetSpell(spell)

        Return True
    End Function
    Protected Shared Function forgetSpecialTrigger(ByRef p As Player, ByVal spec As String) As Boolean
        If Not Game.player1.knownSpecials.Contains(spec) Then Return False

        Game.player1.knownSpecials.Remove(spec)
        TextEvent.pushLog(spec & " special forgotten!")

        Return True
    End Function
    Protected Shared Function classChangeTrigger(ByRef p As Player, ByVal c_name As String) As Boolean
        p.changeClass(c_name)

        Return True
    End Function
    Protected Shared Function stripTrigger(ByRef p As Player) As Boolean
        If EquipmentDialogBackend.equipArmor(p, "Naked") Then
            TextEvent.pushLog("You strip out of your " & DDUtils.amrOrClth(p) & ".")
        Else
            TextEvent.pushLog("You try to strip out of your " & DDUtils.amrOrClth(p) & ", but it doesn't work...")
        End If

        Return True
    End Function
    Protected Shared Function runTrigger(ByRef p As Player) As Boolean
        If Game.combat_engaged Then
            p.nextCombatAction = Sub() Game.run()
        Else
            Return False
        End If

        Return True
    End Function
    Protected Shared Function surrenderTrigger(ByRef p As Player) As Boolean
        If Game.combat_engaged Then
            p.nextCombatAction = Sub() Game.player1.die(Game.player1.currTarget)
        Else
            Return False
        End If


        Return True
    End Function
    Protected Shared Function waitTrigger(ByRef p As Player) As Boolean
        TextEvent.pushAndLog("You stare forward, blankly...")
        Game.waitAction(Not Game.combat_engaged)

        Return True
    End Function
    Protected Shared Function castSpellTrigger(ByRef p As Player, ByVal spellname As String) As Boolean
        Game.selectMagic(spellname)

        Return True
    End Function
    Protected Shared Function attackTrigger(ByRef p As Player) As Boolean
        Game.attackKey()

        Return True
    End Function
    Protected Shared Function focusUpTrigger(ByRef p As Player) As Boolean
        If p.className.Equals("Bimbo") Or p.className.Equals("Magical Slut") Then
            TextEvent.fpushAndLog("You, like, totally can't, ummm... focus right now!")
            Return False
        ElseIf p.className.Equals("Mindless") Or p.className.Equals("Unconscious") Or p.className.Equals("Thrall") Then
            TextEvent.fpushAndLog("You can't focus right now!")
            Return False
        ElseIf p.getWIL < 20 And Not Game.combat_engaged Then
            TextEvent.fpushAndLog("You need 20 or more WIL to focus out of combat...")
            Return False
        End If

        TextEvent.fpushAndLog("Focus Up!  -50 Lust.")
        p.addLust(-50)
        p.UIupdate()

        Return True
    End Function
    Protected Shared Function bimboKissTrigger(ByRef p As Player) As Boolean
        If Not Game.active_shop_npc.img_index = 18 And Game.active_shop_npc.hasMetPlayer Then
            TextEvent.pushAndLog("You fall into a mindless trance, and kiss " & Game.active_shop_npc.getNameWithTitle() & ".  They turn into a bimbo!")
            Polymorph.transformN(Game.active_shop_npc, "Bimbo")

            If Not p.passDieRoll(2) Then Game.shopNPCToCombat(Game.active_shop_npc)
        End If

        p.perks(perk.hypnotized) = h_ind.bimbokiss
        Return False
    End Function

    '| - Misc - |
    Shared Function getHIndCommonName(ByVal i As Integer) As String
        Select Case i
            Case h_ind.namechange
                Return "to change your name"
            Case h_ind.formreset
                Return "to reset your starting form"
            Case h_ind.learnspell
                Return "to learn a spell"
            Case h_ind.learnspecial
                Return "to learn a special"
            Case h_ind.forgetspell
                Return "to forget a spell"
            Case h_ind.forgetspecial
                Return "to forget a special"
            Case h_ind.classchange
                Return "to change your class"
            Case h_ind.strip
                Return "to strip out of your armor"
            Case h_ind.run
                Return "to run away from your next fight"
            Case h_ind.surrender
                Return "to give up at the next opportunity"
            Case h_ind.wait
                Return "to wait through your next turn"
            Case h_ind.castspell
                Return "to cast a spell"
            Case h_ind.attack
                Return "to attack without thought"
            Case h_ind.focusup
                Return "to focus up"
            Case Else
                Return "with an unknown effect"
        End Select
    End Function
End Class
