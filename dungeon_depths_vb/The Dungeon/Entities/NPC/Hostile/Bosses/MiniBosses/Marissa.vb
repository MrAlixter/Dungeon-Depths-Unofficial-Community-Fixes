Public Class Marissa
    Inherits MiniBoss

    Sub New()
        '|ID Info|
        name = "Marissa the Enchantress"

        '|Stats|
        maxHealth = 150
        attack = 25
        defense = -5
        speed = 10
        will = 20
        xp_value = 100
        setupMonsterOnSpawn()

        '|Inventory|
        inv.setCount("Cat_Lingerie", 1)
        inv.setCount("Restore_Potion", 1)
        inv.setCount("Omni_Charm", 1)
        inv.setCount("Gold", 1000)
        'random drops
        Dim possible_drops = {"Health_Potion", "Mana_Potion", "Spellbook", "Cat_Ears", "Mana_Charm", "Sorcerer's_Robes"}
        Dim number_of_drops = Int(Rnd() * 3) + Int(Rnd() * 3) + 1
        For i = 0 To number_of_drops
            Dim r = Int(Rnd() * (possible_drops.Count))
            inv.setCount(possible_drops(r), 1)
        Next

        '|Dialog Variables|
        title = " "
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If target.GetType() Is GetType(Player) Then
            If Game.player1.perks(perk.nekocurse) = -1 Then
                TextEvent.pushLog((getName() & " casts a curse on you!"))
                TextEvent.pushCombat((getName() & " casts a curse on you!"))
                Game.player1.ongoingTFs.Add(New NekoTF(7, 1, 0.3, True))
                Exit Sub
            ElseIf Game.player1.perks(perk.nekocurse) > -1 And getIntHealth() < 45 Then
                Dim healvalue = Int(Rnd() * 4) + Int(Rnd() * 2) + 30
                If getIntHealth() + healvalue > getMaxHealth() Then healvalue = getMaxHealth() - getIntHealth()
                TextEvent.pushLog((getName() & " heals herself!  +" & healvalue & " health!"))
                TextEvent.pushCombat((getName() & " heals herself for " & healvalue & " health!"))
                takeDMG(-healvalue, Nothing)
                Exit Sub
            ElseIf Game.player1.getIntHealth < 20 Then
                TextEvent.pushLog((getName() & " waits expectantly..."))
                TextEvent.pushCombat((getName() & " waits expectantly..."))
                Exit Sub
            End If
        End If

        attackSpell(target, "a lightning bolt", getATK)
    End Sub
End Class
