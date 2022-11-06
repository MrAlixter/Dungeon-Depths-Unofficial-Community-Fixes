Public Class UBlessing
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Uvona's Blessing")
        MyBase.setUOC(True)
        MyBase.setcost(13)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser
        If p.knownSpecials.Count >= Special.specialList.Count And p.knownSpells.Count >= Spell.spellList.Count Then TextEvent.push("Nothing happens...") : Exit Sub

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


        Dim allKnownSpellsAndSpecials = p.knownSpecials.Union(p.knownSpells)
        Dim r = Int(Rnd() * p.knownSpells.Count)
        forgottenS = allKnownSpellsAndSpecials(r)
        If p.knownSpells.Contains(forgottenS) Then
            p.forgetSpell(forgottenS)
        Else
            p.knownSpecials.RemoveAt(r)
        End If

        If coin = 0 Then
            p.knownSpells.Add(learnedS)
            If learnedS.Equals("Self Polymorph") And p.selfPolyForms.Count = 0 Then p.selfPolyForms.Add("Succubus")
            If learnedS.Equals("Polymorph Enemy") And p.enemPolyForms.Count = 0 Then p.enemPolyForms.Add("Cat-Girl")
        Else
            p.knownSpecials.Add(learnedS)
        End If

        TextEvent.pushLog("Uvona's Blessing!")
        TextEvent.push("Uvona's Blessing!" & vbCrLf & "Praying to the goddess of fugue has caused you to forget " & forgottenS & ", and learn " & learnedS & "!")
    End Sub

    Sub errorout()
        TextEvent.pushLog("Uvona's Blessing!")
        TextEvent.push("Uvona's Blessing!" & vbCrLf & "Praying to the goddess of fugue doesn't do anything!")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Forgets one spell/special to learn another unknown spell/special at random."
    End Function
End Class
