Public Class Alraune
    Inherits Monster

    Public Const BASE_NAME As String = "Alraune"

    Dim firstMove = True

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 175
        attack = 15
        defense = 35
        speed = 1
        will = 13
        setupMonsterOnSpawn()

        '|Inventory|
        inv.setCount("Medicinal_Tea", 3)
        inv.setCount("Garden_Salad", 2)
        inv.setCount("Plant_Bikini", If(Int(Rnd() * 4) = 0, 1, 0))

        '|Dialog Variables|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"

        '|Misc|

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If target.GetType() Is GetType(Player) Then
            If firstMove Then
                TextEvent.pushAndLog("The " & getName() & " puffs out a haze of pollen!")
                target.getPlayer.ongoingTFs.add(New AlrauneTF())
                firstMove = False
                Exit Sub

            ElseIf target.getPlayer.perks(perk.mesmerized) < 0 And Int(Rnd() * 3) = 0 Then
                TextEvent.pushAndLog("The " & getName() & " casts Mesmeric Bloom!")
                TextEvent.push("The alraune's spell puts you into a trance!")

                target.getPlayer.perks(perk.mesmerized) = 3

            ElseIf Int(Rnd() * 6) = 0 Or getIntHealth() < 10 Then
                TextEvent.pushAndLog("The " & getName() & " casts healing aura!")
                health += 0.25
                If health > 1 Then health = 1
                target.health += 0.25
                If target.health > 1 Then target.health = 1
                Exit Sub

            End If
        End If
        TextEvent.pushLog(("The " & getName() & " uses vine lash!"))
        TextEvent.pushCombat(("The " & getName() & " uses vine lash!"))
        MyBase.attackCMD(target)
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Dim tf As action = AddressOf New AlrauneTF().fullTF
        tf()

        TextEvent.push("As you collapse to the ground in the haze of pollen, your alraune opponent giggles, and your conciousness slowly fades away." & DDUtils.RNRN &
                          """Good night, honey!""" & DDUtils.RNRN &
                          "You are now an Alraune!")
        p.drawPort()
    End Sub
End Class
