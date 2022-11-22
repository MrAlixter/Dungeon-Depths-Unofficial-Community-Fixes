Public Class Spellbook
    Inherits Item

    Public Const ITEM_NAME As String = "Spellbook"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 4
        tier = 2

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 500

        '|Description|
        setDesc("A simple, leather-bound book that likely contains some cool magic knowledge.")
    End Sub

    Public Shared Function getSpells() As String()
        Return New Spellbook().spells
    End Function
    Public Overridable Function spells() As String()
        Return {"Super Fireball", "Icicle Spear", "Self Polymorph", "Turn to Frog", "Polymorph Enemy", "Petrify", "Heal", "Illuminate", "Fireball", "Warp", "Arcane Compass", "Hydrodart"}
    End Function
    Public Overridable Function selfPolyForms() As String()
        Return {"Dragon", "Succubus", "Slime", "Tigress", "Human"}
    End Function
    Public Overridable Function enemPolyForms() As String()
        Return {"Sheep", "Princess", "Bunny"}
    End Function

    Overrides Sub use(ByRef p As Player)
        If playerKnowsAllSpells(p) Then
            TextEvent.pushLog("You read the " & getName().Replace("_", " ") & "... but you already know all the spells it contains.")
            Exit Sub
        End If

        learnSpell(p)

        count -= 1
    End Sub

    Protected Function playerKnowsAllSpells(ByRef p As Player) As Boolean
        For Each s In spells()
            If Not p.knownSpells.Contains(s) Then Return False
        Next

        For Each sp_form In selfPolyForms()
            If Not p.selfPolyForms.Contains(sp_form) Then Return False
        Next

        For Each ep_form In enemPolyForms()
            If Not p.enemPolyForms.Contains(ep_form) Then Return False
        Next

        Return True
    End Function

    Protected Sub learnSpell(ByRef p As Player)
        Randomize()

        Dim learnable_spells = New List(Of String)(spells)
        Dim learned_spell As String = ""

        While learnable_spells.Count > 0 And learned_spell = ""
            Dim spell As String = learnable_spells(Int(Rnd() * learnable_spells.Count))

            If Not Game.player1.knownSpells.Contains(spell) Or spell.Equals("Polymorph Enemy") Or spell.Equals("Self Polymorph") Then
                learned_spell = spell

                If spell = "Self Polymorph" AndAlso Not learnSelfPolymorph(p) Then learned_spell = ""
                If spell = "Polymorph Enemy" AndAlso Not learnEnemyPolymorph(p) Then learned_spell = ""
            End If

            learnable_spells.Remove(spell)
        End While

        If Not p.knownSpells.Contains(learned_spell) Then p.knownSpells.Add(learned_spell)

        TextEvent.pushLog("You read the " & getName().Replace("_", " ") & ".  " & learned_spell & " learned!")
    End Sub

    Protected Function learnSelfPolymorph(ByRef p As Player) As Boolean
        Dim poly_forms = New List(Of String)(selfPolyForms)
        Dim poly_form = ""

        While poly_forms.Count > 0
            Dim form As String = poly_forms(Int(Rnd() * poly_forms.Count))

            If Not p.selfPolyForms.Contains(form) Then
                TextEvent.pushLog("You learn how to polymorph yourself into a " & form & "!")
                p.selfPolyForms.Add(form)
                Return True
            End If

            poly_forms.Remove(form)
        End While

        Return False
    End Function

    Protected Function learnEnemyPolymorph(ByRef p As Player) As Boolean
        Dim poly_forms = New List(Of String)(enemPolyForms)
        Dim poly_form = ""

        While poly_forms.Count > 0
            Dim form As String = poly_forms(Int(Rnd() * poly_forms.Count))

            If Not p.enemPolyForms.Contains(form) Then
                TextEvent.pushLog("You learn how to polymorph an enemy into a " & form & "!")
                p.enemPolyForms.Add(form)
                Return True
            End If

            poly_forms.Remove(form)
        End While

        Return False
    End Function
End Class
