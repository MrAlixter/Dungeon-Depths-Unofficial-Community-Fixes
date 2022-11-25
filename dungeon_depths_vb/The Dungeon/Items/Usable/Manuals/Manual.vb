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
End Class
