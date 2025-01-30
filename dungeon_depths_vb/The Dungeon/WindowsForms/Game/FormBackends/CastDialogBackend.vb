Public Class CastDialogBackend
    Private Shared sosDescs As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Private Shared target As NPC = Nothing
    Private Shared sosIND As SpellOrSpec = SpellOrSpec.SPECIAL

    Shared Sub toPNLCast(sender As Object, e As EventArgs, ByRef p As Player, ByRef n As NPC, ByVal sos As SpellOrSpec)
        If Not TextEvent.lblEventOnClose Is Nothing Then
            Game.doLblEventOnClose()
            Game.closeLblEvent()
            Exit Sub
        End If

        Game.cboxCast.Items.Clear()
        sosDescs.Clear()
        target = Nothing

        If sos = SpellOrSpec.SPECIAL Then
            p.specialRoute()

            Dim knownSpecials = DDUtils.union(p.knownSpecials, DDUtils.cboxToList(Game.cboxSpec.Items))

            If knownSpecials.count <= 0 Then TextEvent.push("You don't know any specials!") : Exit Sub
            For Each s In knownSpecials
                If Not sosDescs.ContainsKey(s) Then sosDescs.Add(s, Special.specialList(s).getDesc(p, p.currTarget)) : Game.cboxCast.Items.Add(s)
            Next

            Game.lblKnownAbilities.Text = "Known Specials:"
            Game.btnCastSpell.Text = "Use"
        ElseIf sos = SpellOrSpec.SPELL Then
            p.magicRoute()

            If p.knownSpells.count <= 0 Then TextEvent.push("You don't know any spells!") : Exit Sub
            For Each s In p.knownSpells
                If Not sosDescs.ContainsKey(s) Then sosDescs.Add(s, Spell.spellList(s).getDesc(p, p.currTarget)) : Game.cboxCast.Items.Add(s)
            Next

            Game.lblKnownAbilities.Text = "Known Spells:"
            Game.btnCastSpell.Text = "Cast"
        Else
            Exit Sub
        End If

        target = n
        sosIND = sos

        Game.cboxCast.SelectedIndex = 0
        Game.lblCastCost.Text = "Cost: " & getCost(Game.cboxCast.Text)
        Game.cboxCast.Focus()
        Game.pnlCastUse.Visible = True
        Game.pnlCombat.Visible = False
    End Sub

    Shared Function getCost(ByVal s As String)
        If sosIND = SpellOrSpec.SPECIAL Then
            Return Special.specCost(s)
        Else
            Return Spell.spellCost(s)
        End If
    End Function

    Shared Sub cboxCastSelectedItemChanged(sender As Object, e As EventArgs, ByRef p As Player)
        Game.txtCastDesc.Text = sosDescs(Game.cboxCast.Text)

        Game.lblCastCost.Text = "Cost: " & getCost(Game.cboxCast.Text)
    End Sub

    Shared Sub doCastUse(sender As Object, e As EventArgs, ByRef p As Player)
        If Game.combat_engaged Then
            If sosIND = SpellOrSpec.SPECIAL Then
                p.nextCombatAction = Sub(t As Entity) Special.specPerform(t, Game.player1, Game.cboxCast.Text)
            Else
                If Game.cboxCast.Text = FlashBolt.SPELL_NAME Then
                    Spell.spellCast(target, p, Game.cboxCast.Text)
                Else
                    p.nextCombatAction = Sub(t As Entity) Spell.spellCast(t, Game.player1, Game.cboxCast.Text)
                End If
            End If
        Else
            If sosIND = SpellOrSpec.SPECIAL Then
                Special.specPerform(target, p, Game.cboxCast.Text)
            Else
                Spell.spellCast(target, p, Game.cboxCast.Text)
            End If
        End If

        Game.progressTurn()

        fromPNLCast(sender, e, p)
    End Sub

    Shared Sub fromPNLCast(sender As Object, e As EventArgs, ByRef p As Player)
        Game.lblEvent.Focus()
        Game.pnlCastUse.Visible = False
        If Game.combat_engaged Then Game.pnlCombat.Visible = True
    End Sub
End Class
