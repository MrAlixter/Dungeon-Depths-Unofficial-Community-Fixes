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

        '|Inventory|
        inv.setCount("Health_Potion", 2)
        inv.setCount("Major_Health_Potion", 3)
        inv.setCount("Combat_Manual", 1)
        inv.setCount("Sword_of_the_Brutal", 1)
        inv.setCount("Warrior's_Cuirass", CInt(Rnd() * 2))
        inv.setCount("Attack_Charm", 1 + CInt(Rnd() * 2))
        inv.setCount("Omni_Charm", 1)
        inv.setCount("Gold", 2500)

        '|Dialog Variables|
        title = " "
        pronoun = "he"
        pPronoun = "his"
        rPronoun = "him"

        '|Misc|
        setupMonsterOnSpawn()
        combatCounter = 0

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)

        If combatCounter Mod 6 = 0 And health < 0.66 Then
            If Int(Rnd() * 2) = 0 Then
                Game.pushLstLog((getName() & " focuses their energy!"))
                Game.pushLblCombatEvent((getName() & " focuses all " & pPronoun & " energy into " & pPronoun & " blade!"))

                attack *= 1.2
                defense *= 0.7
                speed *= 1.2
            ElseIf Int(Rnd() * 2) = 0 Then
                Game.pushLstLog((getName() & " fires off a shockwave!"))
                Dim out = (getName() & " fires off a psychic shockwave, knocking you back!")

                Dim ownedPotions As List(Of Item) = New List(Of Item)
                For Each p In target.inv.getPotions()
                    If p.count > 0 Then ownedPotions.Add(p)
                Next

                If ownedPotions.Count > 0 Then
                    Dim i = Int(Rnd() * ownedPotions.Count)
                    out += "  As you stumble backwards, you fall, landing on your " &
                        ownedPotions(i).getAName & ", which breaks open!"
                    target.inv.item(ownedPotions(i).getAName).use(Game.player1)
                End If

                target.takeDMG(10, Me)

                Game.pushLblCombatEvent(out)
            End If
        End If


        Game.pushLstLog((getName() & " slashes at you!"))
        Game.pushLblCombatEvent((getName() & " slashes at you!"))
        MyBase.attackCMD(target)
    End Sub

    Public Overrides Function reactToSpell(spell As String) As Boolean
        If Rnd() < (0.6) Then
            Return True
        Else
            Game.pushLstLog("The spell bounces off Targax!")
            Game.pushLblCombatEvent("The spell bounces off Targax!")
            Return False
        End If
    End Function
End Class
