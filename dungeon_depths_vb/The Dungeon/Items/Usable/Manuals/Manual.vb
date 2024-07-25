Public MustInherit Class Manual
    Inherits Item

    Public MustOverride Function specials() As String()

    Overrides Sub use(ByRef p As Player)
        If playerKnowsAllSpecials(p) Then
            TextEvent.pushLog("You read the " & getName().Replace("_", " ") & "... but you already know all the specials it contains.")
            Exit Sub
        End If

        learnSpecial(p)

        count -= 1
    End Sub

    Protected Function playerKnowsAllSpecials(ByRef p As Player) As Boolean
        For Each s In specials()
            If Not p.knownSpecials.Contains(s) Then Return False
        Next

        Return True
    End Function

    Protected Sub learnSpecial(ByRef p As Player)
        Randomize()

        Dim learnable_specials = New List(Of String)(specials)
        Dim learned_special As String = ""

        While learnable_specials.Count > 0 And learned_special = ""
            Dim spec As String = learnable_specials(Int(Rnd() * learnable_specials.Count))

            If Not p.knownSpecials.Contains(spec) Then learned_special = spec

            learnable_specials.Remove(spec)
        End While

        If Not p.knownSpecials.Contains(learned_special) Then p.knownSpecials.Add(learned_special)

        TextEvent.pushLog("You read the " & getName().Replace("_", " ") & ".  " & learned_special & " learned!")
    End Sub

    Public Overrides Sub examine()
        If durability > 99 Then
            TextEvent.push(getDescription() & DDUtils.RNRN &
                           "On closer inspection, you see that you may also be able to change your melee discipline using this manual...", AddressOf melTypeChange)
        Else
            TextEvent.push(getDescription() & DDUtils.RNRN &
                           "On closer inspection, you see that you may also be able to change your melee discipline using this manual..." & DDUtils.RNRN &
                           "Durability: " & durability & " (Breaks at 0)", AddressOf melTypeChange)
        End If
    End Sub

    Public Sub melTypeChange()
        Dim options As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))()

        If Not (Game.player1.perks(perk.meltype) = melType.sword) Then options.Add(New Tuple(Of String, Action)("Sword", AddressOf selectSword))
        If Not (Game.player1.perks(perk.meltype) = melType.axe) Then options.Add(New Tuple(Of String, Action)("Axe", AddressOf selectAxe))
        If Not (Game.player1.perks(perk.meltype) = melType.spear) Then options.Add(New Tuple(Of String, Action)("Spear", AddressOf selectSpear))
        If Not (Game.player1.perks(perk.meltype) = melType.dagger) Then options.Add(New Tuple(Of String, Action)("Dagger", AddressOf selectDagger))
        If Not (Game.player1.perks(perk.meltype) = melType.whip) Then options.Add(New Tuple(Of String, Action)("Whip", AddressOf selectWhip))
        If Not (Game.player1.perks(perk.meltype) = melType.bludgeon) Then options.Add(New Tuple(Of String, Action)("Bludgeon", AddressOf selectBludgeon))
        If Not (Game.player1.perks(perk.meltype) = melType.fist) Then options.Add(New Tuple(Of String, Action)("Fist", AddressOf selectFist))
        If Not (Game.player1.perks(perk.meltype) = melType.misc) Then options.Add(New Tuple(Of String, Action)("Misc", AddressOf selectMisc))

        TextEvent.pushManySelect("Select a new melee discipline?", options)
    End Sub
    Private Sub selectSword()
        Game.player1.perks(perk.meltype) = melType.sword
        count -= 1

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
    Private Sub selectAxe()
        Game.player1.perks(perk.meltype) = melType.axe
        count -= 1

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
    Private Sub selectDagger()
        Game.player1.perks(perk.meltype) = melType.dagger
        count -= 1

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
    Private Sub selectSpear()
        Game.player1.perks(perk.meltype) = melType.spear
        count -= 1

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
    Private Sub selectWhip()
        Game.player1.perks(perk.meltype) = melType.whip
        count -= 1

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
    Private Sub selectBludgeon()
        Game.player1.perks(perk.meltype) = melType.bludgeon
        count -= 1

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
    Private Sub selectFist()
        Game.player1.perks(perk.meltype) = melType.fist
        count -= 1

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
    Private Sub selectMisc()
        Game.player1.perks(perk.meltype) = melType.misc
        count -= 1

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
End Class
