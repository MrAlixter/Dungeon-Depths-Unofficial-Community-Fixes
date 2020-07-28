Public Class Alraune
    Inherits Monster

    Dim firstMove = True

    Sub New()
        name = "Alraune"
        maxHealth = 175
        attack = 15
        defence = 35
        speed = 1

        inv.setCount("Medicinal_Tea", 3)
        inv.setCount("Garden_Salad", 2)

        setupMonsterOnSpawn()

        pronoun = "she"
        pPronoun = "her"
        rPronoun = "her"
        xpValue = 40
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If target.GetType() Is GetType(Player) Then
            If firstMove Then
                Game.pushLblEvent("The " & getName() & " puffs out a haze of pollen!")
                Game.player1.ongoingTFs.Add(New AlrauneTF())
                firstMove = False
                Exit Sub
            ElseIf Int(Rnd() * 6) = 0 Then
                Game.pushLblEvent("The " & getName() & " casts healing aura!")
                health += 0.25
                If health > 1 Then health = 1
                target.health += 0.25
                If target.health > 1 Then target.health = 1
                Exit Sub
            ElseIf Int(Rnd() * 3) = 0 And Not CType(target, Player).pClass.name.Equals("Mindless") Then
                Game.pushLblEvent("The " & getName() & " casts Mesmeric Bloom!")
                Dim tf = New MindlessTF()
                tf.step1alt()
            End If
        End If
        Game.pushLstLog(("The " & getName() & " uses vine lash!"))
        Game.pushLblCombatEvent(("The " & getName() & " uses vine lash!"))
        MyBase.attackCMD(target)
    End Sub
End Class
