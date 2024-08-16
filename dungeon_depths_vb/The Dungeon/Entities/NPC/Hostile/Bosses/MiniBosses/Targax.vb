Public Class Targax
    Inherits MiniBoss

    Dim combatCounter As Integer
    Sub New()
        '|ID Info|
        name = "Targax the Brutal"

        '|Stats|
        maxHealth = 250
        attack = 50
        defense = 20
        speed = 5
        will = 10
        xp_value = 200
        setupMonsterOnSpawn()

        '|Inventory|
        inv.setCount(TargaxSword.ITEM_NAME, 1)
        inv.setCount(OmniCharm.ITEM_NAME, 1)
        inv.setCount("Gold", 2500)
        'random drops
        Dim possible_drops = {CombatManual.ITEM_NAME, WarriorsCuirass.ITEM_NAME, AttackCharm.ITEM_NAME}
        Dim number_of_drops = Int(Rnd() * 2) + Int(Rnd() * 2) + 1
        For i = 0 To number_of_drops
            Dim r = Int(Rnd() * (possible_drops.Count))
            inv.setCount(possible_drops(r), 1)
        Next

        '|Dialog Variables|
        title = " "
        pronoun = "he"
        p_pronoun = "his"
        r_pronoun = "him"

        '|Misc|
        combatCounter = 0
        intro_taunt = """...""" & DDUtils.RNRN &
                      "The silent man before you is enormous; wielding an equally massive blade."
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)

        If combatCounter Mod 6 = 0 And health < 0.66 Then
            If Int(Rnd() * 2) = 0 Then
                TextEvent.pushLog((getName() & " focuses their energy!"))
                TextEvent.pushCombat((getName() & " focuses all " & p_pronoun & " energy into " & p_pronoun & " blade!"))

                attack *= 1.2
                defense *= 0.7
                speed *= 1.2
            ElseIf Int(Rnd() * 2) = 0 Then
                TextEvent.pushLog((getName() & " fires off a shockwave!"))
                TextEvent.pushCombat(getName() & " fires off a psychic shockwave, knocking you back!")
                target.takeDMG(10, Me)

                Dim ownedPotions As List(Of Item) = New List(Of Item)
                For Each p In target.inv.getPotions()
                    If p.count > 0 Then ownedPotions.Add(p)
                Next

                If ownedPotions.Count > 0 Then
                    Dim i = Int(Rnd() * ownedPotions.Count)
                    TextEvent.pushLog("You fall on your " & ownedPotions(i).getAName & "!")
                    TextEvent.pushCombat("You stagger backwards and trip, landing on your " & ownedPotions(i).getAName & " and splattering it all over yourself!")
                    target.inv.item(ownedPotions(i).getAName).use(Game.player1)
                End If
            End If
        End If

        TextEvent.pushAndLog((getName() & " slashes at you!"))
        MyBase.attackCMD(target)
    End Sub

    Public Overrides Function reactToSpell(spell As String) As Boolean
        If Game.player1.passDieRoll(20, 11) Then
            Return True
        Else
            TextEvent.pushLog("The spell bounces off Targax!")
            TextEvent.pushCombat("The spell bounces off Targax!")
            Return False
        End If
    End Function
End Class
