Public Class SevenTails
    Inherits MiniBoss
    Dim shouldRun As Boolean = False

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

        If shouldRun Then runAway() : Exit Sub

        Game.pushLstLog((getName() & " casts Super Fireball!"))
        Game.pushLblCombatEvent((getName() & " casts Super Fireball!"))
        MyBase.attackCMD(target)
    End Sub

    Public Overrides Sub takeDMG(dmg As Integer, ByRef source As Entity)
        shouldRun = True
        MyBase.takeDMG(dmg, source)
    End Sub
    Public Overrides Sub takeCritDMG(dmg As Integer, ByRef source As Entity)
        shouldRun = True
        MyBase.takeCritDMG(dmg, source)
    End Sub

    Public Sub runAway()
        shouldRun = False
        Game.fromCombat()
        Game.pushLblEvent("With a poof of smoke, " & getName() & " vanishes into the forest...")
    End Sub
End Class
