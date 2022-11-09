Public Class ManySquirrels
    Inherits Monster

    Public Const BASE_NAME As String = "Innumerable Squirrels"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 90
        attack = 15
        defense = 20
        speed = 60
        setupMonsterOnSpawn()

        '|Inventory|
        Dim r As Integer = Int(Rnd() * 6)
        inv.add(Acorn.ITEM_NAME, r)

        '|Dialog Variables|
        pronoun = "they"
        p_pronoun = "their"
        r_pronoun = "them"

        '|Misc|

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        Dim crit = Int(Rnd() * 20) 'roll for a critical
        Dim damage = calcDamage(Me.getATK, target.getDEF) 'calculate the hit
        If damage > 0 Then damage += Int(Rnd() * 3) + -1 'adds some variance
        damage = Math.Min(getIntHealth, damage)

        Select Case crit
            Case 19
                TextEvent.pushAndLog("The horde furiously chitters!  " & damage * 2 & " squirrels lunge in...")
                cHit(damage, target)
            Case Else
                TextEvent.pushAndLog("The horde chitters and writhes!  " & damage & " squirrels lunge in...")
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

    Public Overrides Sub takeDMG(ByVal dmg As Integer, ByRef source As Entity)
        Dim startHealth = getIntHealth()

        MyBase.takeDMG(dmg, source)

        If Not Game.lblEvent.Visible Then
            TextEvent.pushAndLog(dmg & " squirrels are defeated!")
        Else
            TextEvent.pushLog(startHealth & " squirrels are defeated!")
        End If
    End Sub

    Protected Overrides Sub miss(target As Player)
        TextEvent.pushAndLog(CStr("You are able to evade your opponents!"))
    End Sub
End Class
