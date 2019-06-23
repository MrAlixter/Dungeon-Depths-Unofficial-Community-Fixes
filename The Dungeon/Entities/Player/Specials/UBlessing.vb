Public Class UBlessing
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Uvona's Blessing")
        MyBase.setUOC(True)
        MyBase.setcost(13)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser

        Dim forgottenS As String = "none"
        Dim learnedS As String = "none"

        Dim coin = Int(Rnd() * 2)


        If coin = 0 Then
            Dim omniSpells() As String = ASpellbook.spells.Union(Spellbook.spells).ToArray
            If omniSpells.Count = p.knownSpells.Count Then
                errorout()
                Exit Sub
            End If

            learnedS = omniSpells(Int(Rnd() * omniSpells.Length))
            While p.knownSpells.Contains(learnedS)
                learnedS = omniSpells(Int(Rnd() * omniSpells.Length))
            End While
        Else
            Dim omniSpec() As String = CombatManual.specials.Union(UtilityManual.specials).ToArray
            If omniSpec.Count = p.knownSpecials.Count Then
                errorout()
                Exit Sub
            End If

            learnedS = omniSpec(Int(Rnd() * omniSpec.Length))
            While p.knownSpecials.Contains(learnedS)
                learnedS = omniSpec(Int(Rnd() * omniSpec.Length))
            End While
        End If

        If coin = 0 Then
            p.knownSpells.Add(learnedS)
        Else
            p.knownSpecials.Add(learnedS)
        End If

        If Int(Rnd() * 2) = 0 Then
            Dim r = Int(Rnd() * p.knownSpells.Count)
            forgottenS = p.knownSpells(r)
            p.knownSpells.RemoveAt(r)
        Else
            Dim r = Int(Rnd() * p.knownSpecials.Count)
            forgottenS = p.knownSpecials(r)
            p.knownSpecials.RemoveAt(r)
        End If



        Game.pushLstLog("Uvona's Blessing!")
        Game.pushLblEvent("Uvona's Blessing!" & vbCrLf & "Praying to the goddess of fugue has caused you to forget " & forgottenS & ", and learn " & learnedS & "!")
    End Sub

    Sub errorout()
        Game.pushLstLog("Uvona's Blessing!")
        Game.pushLblEvent("Uvona's Blessing!" & vbCrLf & "Praying to the goddess of fugue doesn't do anything!")
    End Sub
End Class
