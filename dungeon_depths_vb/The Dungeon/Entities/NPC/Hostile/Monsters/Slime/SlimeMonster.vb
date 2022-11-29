Public Class SlimeMonster
    Inherits Monster

    Public Const BASE_NAME As String = "Slime"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 30
        attack = 17
        defense = 60
        speed = 6

        '|Inventory|
        setInventory({2, 3})

        '|Dialog Variables|

        '|Misc|
        setupMonsterOnSpawn()

        If Int(Rnd() * 30) = 0 Then
            name = "Beautiful Slime"

            inv.setCount(EyeOfTheBeholder.ITEM_NAME, 1)

            intro_taunt = "This slime seems to have an... eyeball..." & DDUtils.RNRN &
                          "A very pretty eyeball..." & DDUtils.RNRN &
                          "Hmm..."
        End If
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If Int(Rnd() * 8) = 0 Then
            TextEvent.push(DDUtils.capitalizeFirst(getNameWithTitle) & " just sits there, bobbing up and down menacingly...")
            TextEvent.pushLog(DDUtils.capitalizeFirst(getNameWithTitle) & " just sits there.")
        ElseIf health < 0.75 And Int(Rnd() * 2) = 0 Then
            TextEvent.pushAndLog(DDUtils.capitalizeFirst(getNameWithTitle) & " uses Absorption!")

            Dim dmg = calcDamage(Me.getATK * 1.5, target.getDEF)
            hit(dmg, target)
            takeDMG(-dmg, Nothing)

            If health > 1.0 Then health = 1.0
        Else
            MyBase.attackCMD(target)
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        'Author Credit: Marionette
        Dim out As String = "As " & getNameWithTitle() & " closes in, you push yourself off the ground with a burst of adrenaline that overcomes your fatigue.  You sidestep as " & r_pronoun & " lunges, and you beat a hasty retreat." & DDUtils.RNRN &
                            "While your back is turned to it, however, " & getNameWithTitle() & " slings a ball of goo towards you; the impact of which causes you to stumble as it strikes your back." & DDUtils.RNRN &
                            "You can already feel it starting to writhe and squirm as it begins to move..."
        despawn("p-death")
        If p.perks(perk.slimetf) = -1 Then
            p.perks(perk.slimetf) = 1
        End If

        p.ongoingTFs.add(New SlimeETF(p.perks(perk.slimetf)))
        TextEvent.push(out, AddressOf p.update)
    End Sub
End Class
