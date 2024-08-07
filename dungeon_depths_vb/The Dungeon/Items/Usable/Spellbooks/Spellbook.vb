Public Class Spellbook
    Inherits Item

    Public Const ITEM_NAME As String = "Spellbook"
    Dim use_spellbook_tier As Boolean = False

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 4
        tier = 2

        '|Item Flags|
        usable = True
        use_spellbook_tier = True

        '|Stats|
        count = 0
        value = 500

        '|Description|
        setDesc("A simple, leather-bound book that likely contains some cool magic knowledge.")
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        If Not use_spellbook_tier Then Return MyBase.getTier(floor_num)

        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f10f12
                Return 1
            Case LootTable.bracket.f13
                Return 1
            Case LootTable.bracket.f14fXX
                Return 1
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Public Shared Function getSpells() As String()
        Return New Spellbook().spells
    End Function
    Public Overridable Function spells() As String()
        Dim options As List(Of String) = New List(Of String)({"Heal", "Warp", "Arcane Compass", "Hydrodart"})
        Dim p As Player = Game.player1

        Select Case p.perks(perk.magtype)
            Case magType.fire
                'options = DDUtils.union(options, New List(Of String)({"Fireball", "Super Fireball", "Self Polymorph"}))
                options = New List(Of String)({"Polymorph Enemy"})
            Case magType.ice
                options = DDUtils.union(options, New List(Of String)({"Icicle Spear", "Self Polymorph"}))
            Case magType.plant
                options = DDUtils.union(options, New List(Of String)({"Self Polymorph"}))
            Case magType.light
                options = DDUtils.union(options, New List(Of String)({"Illuminate", "Self Polymorph"}))
            Case magType.blight
                options = DDUtils.union(options, New List(Of String)({"Petrify", "Turn to Frog", "Polymorph Enemy"}))
            Case magType.flux
                options = DDUtils.union(options, New List(Of String)({"Self Polymorph", "Polymorph Enemy", "Pandemonium Ray"}))
        End Select

        Return options.ToArray()
    End Function
    Public Overridable Function selfPolyForms() As String()
        Dim options As List(Of String) = New List(Of String)({"Slime_Paladin", "Tigress_Barbarian", "Succubus_Assassin"})
        Dim p As Player = Game.player1
        'elf sage

        Select Case p.perks(perk.magtype)
            Case magType.fire
                'phoenix
                options = DDUtils.union(options, New List(Of String)({"Dragon"}))
                'options = New List(Of String)({"Tigress_Barbarian"})
            Case magType.ice
                'ice golem
                options = DDUtils.union(options, New List(Of String)({}))
            Case magType.plant
                'dryad
                options = DDUtils.union(options, New List(Of String)({}))
            Case magType.light
                'dove
                options = DDUtils.union(options, New List(Of String)({}))
            Case magType.blight
                'giant snake
                options = DDUtils.union(options, New List(Of String)({}))
            Case magType.flux
                'oni warrior
                'minotaur bull
                options = DDUtils.union(options, New List(Of String)({"Human"}))
        End Select

        Return options.ToArray()
    End Function
    Public Overridable Function enemPolyForms() As String()
        Dim options As List(Of String) = New List(Of String)({"Sheep"})
        Dim p As Player = Game.player1
        'slime
        'cleric

        Select Case p.perks(perk.magtype)
            Case magType.fire
                'imp
                'options = DDUtils.union(options, New List(Of String)({}))
                options = New List(Of String)({"Cat-Girl"})
            Case magType.ice
                'snowman
                options = DDUtils.union(options, New List(Of String)({}))
            Case magType.plant
                'sunflower
                options = DDUtils.union(options, New List(Of String)({}))
            Case magType.light
                'dove
                options = DDUtils.union(options, New List(Of String)({}))
            Case magType.blight
                'goblin
                'newt
                options = DDUtils.union(options, New List(Of String)({}))
            Case magType.flux
                'turtle
                options = DDUtils.union(options, New List(Of String)({"Princess", "Bunny"}))
        End Select

        Return options.ToArray()
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

            If Not p.knownSpells.Contains(spell) Or spell.Equals("Polymorph Enemy") Or spell.Equals("Self Polymorph") Then
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

    Public Overrides Sub examine()
        If durability > 99 Then
            TextEvent.push(getDescription() & DDUtils.RNRN &
                           "On closer inspection, you see that you may also be able to change your magic discipline using this spellbook...", AddressOf magTypeChange)
        Else
            TextEvent.push(getDescription() & DDUtils.RNRN &
                           "On closer inspection, you see that you may also be able to change your magic discipline using this spellbook..." & DDUtils.RNRN &
                           "Durability: " & durability & " (Breaks at 0)", AddressOf magTypeChange)
        End If
    End Sub

    Public Sub magTypeChange()
        Dim options As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))()

        If Not (Game.player1.perks(perk.magtype) = magType.fire) Then options.Add(New Tuple(Of String, Action)("Fire", AddressOf selectFire))
        If Not (Game.player1.perks(perk.magtype) = magType.ice) Then options.Add(New Tuple(Of String, Action)("Ice", AddressOf selectIce))
        If Not (Game.player1.perks(perk.magtype) = magType.plant) Then options.Add(New Tuple(Of String, Action)("Plant", AddressOf selectPlant))
        If Not (Game.player1.perks(perk.magtype) = magType.light) Then options.Add(New Tuple(Of String, Action)("Light", AddressOf selectLight))
        If Not (Game.player1.perks(perk.magtype) = magType.blight) Then options.Add(New Tuple(Of String, Action)("Blight", AddressOf selectBlight))
        If Not (Game.player1.perks(perk.magtype) = magType.flux) Then options.Add(New Tuple(Of String, Action)("Flux", AddressOf selectFlux))
        'If Not (Game.player1.perks(perk.magtype) = magType.psychic) Then options.Add(New Tuple(Of String, Action)("Psychic", AddressOf selectPsychic))
        If Not (Game.player1.perks(perk.magtype) = magType.misc) Then options.Add(New Tuple(Of String, Action)("Misc", AddressOf selectMisc))

        TextEvent.pushManySelect("Select a new magic discipline?", options)
    End Sub
    Private Sub selectFire()
        Game.player1.perks(perk.magType) = magType.Fire
        count -= 1

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
    Private Sub selectIce()
        Game.player1.perks(perk.magType) = magType.Ice
        count -= 1

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
    Private Sub selectLight()
        Game.player1.perks(perk.magType) = magType.Light
        count -= 1

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
    Private Sub selectPlant()
        Game.player1.perks(perk.magType) = magType.Plant
        count -= 1

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
    Private Sub selectBlight()
        Game.player1.perks(perk.magType) = magType.Blight
        count -= 1

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
    Private Sub selectFlux()
        Game.player1.perks(perk.magType) = magType.Flux
        count -= 1

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
    Private Sub selectPsychic()
        Game.player1.perks(perk.magType) = magType.Psychic
        count -= 1

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
    Private Sub selectMisc()
        Game.player1.perks(perk.magType) = magType.misc
        count -= 1

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
End Class
