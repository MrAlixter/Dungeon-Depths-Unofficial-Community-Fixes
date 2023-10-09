Public Class Spear
    Inherits Weapon
    Protected Friend weight As Integer = 17

    Overridable Sub wThrow(ByRef p As Player, ByRef m As Entity)
        If m Is Nothing Then
            TextEvent.pushAndLog("You throw the spear across the dungeon at nothing in particular.")
        Else
            If m.getNPC() Is Nothing Then
                TextEvent.pushAndLog("You throw the " & getName.Replace("_", " ") & "!")
            Else
                TextEvent.pushAndLog("You throw the " & getName.Replace("_", " ") & " at " & m.getNPC.getNameWithTitle & "!")
            End If

            Dim dmg As Integer = (p.getATK) + (Me.a_boost) + (Me.a_boost) + Int(Rnd() * 3 + 1)
            p.hit(dmg, m)
        End If

        Dim w_dmg = weight + Int(Rnd() * 6 + 1) + Int(Rnd() * 6 + 1)
        durability -= w_dmg
        If durability <= 0 Then
            break()
        ElseIf Not m Is Nothing AndAlso Not m.isDead Then
            TextEvent.pushAndLog("The " & getName.Replace("_", " ") & " takes " & w_dmg & " damage.")
        Else
            TextEvent.pushLog("The " & getName.Replace("_", " ") & " takes " & w_dmg & " damage.")
        End If
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) +
            Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1) + Int(Rnd() * 2 + 1)
        If dmg <= 8 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 10 Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.getABoost(p))
        Return Player.calcDamage(dmg, m.defense)
    End Function

    Public Overrides Sub use(ByRef p As Player)
        If Game.combat_engaged Then
            throw_cached_p = p
            p.nextCombatAction = Sub(m As Entity) wThrow(throw_cached_p, m)
            Game.updatable_queue.add(p, DDUtils.INTLMT)
        Else
            wThrow(p, p.currTarget)
        End If
    End Sub
End Class
