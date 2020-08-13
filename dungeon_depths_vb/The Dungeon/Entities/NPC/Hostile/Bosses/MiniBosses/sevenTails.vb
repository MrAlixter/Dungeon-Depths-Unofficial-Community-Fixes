Public Class SevenTails
    Inherits MiniBoss

    Sub New()
        name = "Seven-Tails"
        maxHealth = 7
        attack = 77
        defense = 7777777
        speed = 777

        inv.setCount("Fox_Ears", 3)
        inv.setCount("Mana_Charm", 1 + CInt(Rnd() * 2))
        inv.setCount("Omni_Charm", 1)
        inv.setCount("Gold", 7000)

        setupMonsterOnSpawn()

        title = " "
        pronoun = "she"
        pPronoun = "her"
        rPronoun = "her"
        xpValue = 100
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If target.GetType() Is GetType(Player) Then
            Dim p = CType(target, Player)
        End If

        Game.pushLstLog((getName() & " casts Super Fireball!"))
        Game.pushLblCombatEvent((getName() & " casts Super Fireball!"))
        MyBase.attackCMD(target)
    End Sub
End Class
