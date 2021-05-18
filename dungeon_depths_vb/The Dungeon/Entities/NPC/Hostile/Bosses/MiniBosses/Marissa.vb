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

        '|Inventory|
        inv.setCount("Health_Potion", 3)
        inv.setCount("Spellbook", 2)
        inv.setCount("Cat_Lingerie", 1)
        inv.setCount("Restore_Potion", 1)
        inv.setCount("Cat_Ears", 1)
        inv.setCount("Mana_Charm", 1 + CInt(Rnd() * 2))
        inv.setCount("Omni_Charm", 1)
        inv.setCount("Sorcerer's_Robes", CInt(Rnd() * 2))
        inv.setCount("Gold", 1000)

        '|Dialog Variables|
        title = " "
        pronoun = "she"
        pPronoun = "her"
        rPronoun = "her"

        '|Misc|
        setupMonsterOnSpawn()

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If target.GetType() Is GetType(Player) Then
            If Game.player1.perks(perk.nekocurse) = -1 Then
                Game.pushLstLog((getName() & " casts a curse on you!"))
                Game.pushLblCombatEvent((getName() & " casts a curse on you!"))
                Game.player1.ongoingTFs.Add(New NekoTF(7, 1, 0.3, True))
                Exit Sub
            ElseIf Game.player1.perks(perk.nekocurse) > -1 And getIntHealth() < 45 Then
                Dim healvalue = Int(Rnd() * 4) + Int(Rnd() * 2) + 30
                If getIntHealth() + healvalue > getMaxHealth() Then healvalue = getMaxHealth() - getIntHealth()
                Game.pushLstLog((getName() & " heals herself!  +" & healvalue & " health!"))
                Game.pushLblCombatEvent((getName() & " heals herself for " & healvalue & " health!"))
                takeDMG(-healvalue, Nothing)
                Exit Sub
            ElseIf Game.player1.getIntHealth < 20 Then
                Game.pushLstLog((getName() & " waits expectantly..."))
                Game.pushLblCombatEvent((getName() & " waits expectantly..."))
                Exit Sub
            End If
        End If

        Game.pushLstLog((getName() & " casts lightning bolt!"))
        Game.pushLblCombatEvent((getName() & " casts lightning bolt!"))
        MyBase.attackCMD(target)
    End Sub
End Class
