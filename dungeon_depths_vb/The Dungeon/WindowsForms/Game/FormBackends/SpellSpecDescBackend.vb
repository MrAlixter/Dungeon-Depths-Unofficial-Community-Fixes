Public Enum SpellOrSpec
    SPELL
    SPECIAL
End Enum

Public Class SpellSpecDescBackend
    Private Shared sosDescs As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Shared Sub toPNLSpellSpecDesc(sender As Object, e As EventArgs, ByRef p As Player, ByVal sos As SpellOrSpec)
        Game.cboxSpellSpecialDescSelector.Items.Clear()
        sosDescs.Clear()

        If sos = SpellOrSpec.SPECIAL Then
            p.specialRoute()

            Dim knownSpecials = DDUtils.union(p.knownSpecials, DDUtils.cboxToList(Game.cboxSpec.Items))

            If knownSpecials.Count <= 0 Then Game.pushLblEvent("You don't know any specials!") : Exit Sub
            For Each s In knownSpecials
                If Not sosDescs.ContainsKey(s) Then sosDescs.Add(s, Special.specialList(s).getDesc(p, p.currTarget)) : Game.cboxSpellSpecialDescSelector.Items.Add(s)
            Next
        ElseIf sos = SpellOrSpec.SPELL Then
            p.magicRoute()

            If p.knownSpells.Count <= 0 Then Game.pushLblEvent("You don't know any spells!") : Exit Sub
            For Each s In p.knownSpells
                If Not sosDescs.ContainsKey(s) Then sosDescs.Add(s, Spell.spellList(s).getDesc(p, p.currTarget)) : Game.cboxSpellSpecialDescSelector.Items.Add(s)
            Next
        Else
            Exit Sub
        End If

        Game.cboxSpellSpecialDescSelector.SelectedIndex = 0
        Game.cboxSpellSpecialDescSelector.Focus()
        Game.pnlSpellSpecial.Visible = True
    End Sub

    Shared Sub cboxSpellSpecIndexChanged(sender As Object, e As EventArgs, ByRef p As Player)
        Game.txtSpellSpecialDesc.Text = sosDescs(Game.cboxSpellSpecialDescSelector.Text)
    End Sub

    Shared Sub fromPNLSpellSpecDesc(sender As Object, e As EventArgs, ByRef p As Player)
        Game.lblEvent.Focus()
        Game.pnlSpellSpecial.Visible = False
    End Sub
End Class
