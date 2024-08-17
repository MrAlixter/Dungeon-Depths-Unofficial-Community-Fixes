Public Class InnumerableBugs
    Inherits Monster

    Public Const BASE_NAME As String = "Innumerable Bugs"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 90
        attack = 15
        defense = 20
        will = 1
        speed = 60
        xp_value = 75
        setupMonsterOnSpawn(Math.Max(1, Game.player1.level + 1))

        '|Inventory|
        setInventory({445})

        '|Dialog Variables|
        pronoun = "they"
        p_pronoun = "their"
        r_pronoun = "them"

        '|Misc|

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)

        baseAttackCMD(target)
    End Sub
    Sub baseAttackCMD(ByRef target As Entity)
        Dim crit = Int(Rnd() * 20) 'roll for a critical
        Dim damage = calcDamage(Me.getATK, target.getDEF) 'calculate the hit
        If damage > 0 Then damage += Int(Rnd() * 3) + -1 'adds some variance
        damage = Math.Min(getIntHealth, damage)

        Select Case crit
            Case 19
                TextEvent.pushAndLog("The horde of pixels flashes and strobes!  " & damage * 2 & " bugs lunge in...")
                cHit(damage, target)
            Case Else
                TextEvent.pushAndLog("The horde of pixels strobes!  " & damage & " bug lunge in...")
                If target.getSPD <= 20 Then
                    If crit < 1 Then miss(target) Else hit(damage, target)
                ElseIf target.getSPD <= 40 Then
                    If crit < 2 Then miss(target) Else hit(damage, target)
                ElseIf target.getSPD <= 60 Then
                    If crit < 3 Then miss(target) Else hit(damage, target)
                ElseIf target.getSPD <= 80 Then
                    If crit < 4 Then miss(target) Else hit(damage, target)
                ElseIf target.getSPD <= 100 Then
                    If crit < 5 Then miss(target) Else hit(damage, target)
                Else
                    Dim ebound = 5 + ((target.getSPD / 9999) * 5)
                    If ebound > 12 Then ebound = 12
                    If crit < ebound Then miss(target) Else hit(damage, target)
                End If
        End Select
    End Sub

    Public Overrides Function takeDMG(ByRef dmg As Integer, ByRef source As Entity) As Boolean
        Dim startHealth = getIntHealth()

        Dim took_damage = MyBase.takeDMG(dmg, source)

        If Not Game.lblEvent.Visible Then
            TextEvent.pushAndLog(dmg & " bugs are patched!")
        Else
            TextEvent.pushLog(startHealth & " bugs are patched!")
        End If

        Return took_damage
    End Function

    Protected Overrides Sub miss(target As Player)
        TextEvent.pushAndLog(CStr("You are able to evade your opponents!"))
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        Game.player1.pos = Game.currFloor.randPoint

        TextEvent.push("Before you can be swarmed by the cluster of bugs, your feet clip through the floor and you wind up somewhere else.")
    End Sub
End Class
