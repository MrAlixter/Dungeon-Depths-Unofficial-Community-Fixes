Public Class KestrelKnife
    Inherits Dagger

    Public Const ITEM_NAME As String = "Kestrel's_Talon"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 422
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        a_boost = 9
        s_boost = 4
        d_boost = -9
        count = 0
        value = 2378


        '|Description|

        setDesc("A small blade, weighted in such a way that glides through the air when thrown. Engraved along its length is the profile of a tiny bird of prey. " & DDUtils.RNRN &
                "Critical hit rate increases the faster you are than your foe." & DDUtils.RNRN &
                "Can be thrown using the ""Use"" button." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f3f5
                Return 4
            Case LootTable.bracket.f6f9
                Return 3
            Case LootTable.bracket.f10f12
                Return 3
            Case LootTable.bracket.f14fXX
                Return 2
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        '1st hit
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            p.miss(m)
        ElseIf dmg >= 11 Or getAltCrit(p, m) Then
            If (p.getATK * 2) >= m.getIntHealth Then Return -2
            p.cHit(p.getATK, m)
        Else
            dmg += (p.getATK) + (Me.getABoost(p))
            If (Player.calcDamage(dmg, m.defense)) >= m.getIntHealth Then Return Player.calcDamage(dmg, m.defense)
            p.hit(Player.calcDamage(dmg, m.defense), m)
        End If

        '2nd hit
        dmg = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 11 Or getAltCrit(p, m) Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.getABoost(p))
        Return Player.calcDamage(dmg, m.defense)
    End Function

    Function getAltCrit(ByRef p As Player, ByRef m As Entity) As Boolean
        If m.getSPD >= p.getSPD Then Return False

        Dim ratio As Double = Math.Min(p.getSPD / m.getSPD, 5.0)

        Return (Rnd() * ratio) > 1.0
    End Function

    Overridable Sub wThrow(ByRef p As Player, ByRef m As Entity)
        If m Is Nothing Then
            TextEvent.pushAndLog("You throw the knife across the dungeon at nothing in particular.")
        Else
            If m.getNPC() Is Nothing Then
                TextEvent.pushAndLog("You throw the " & getName.Replace("_", " ") & "!")
            Else
                TextEvent.pushAndLog("You throw the " & getName.Replace("_", " ") & " at " & m.getNPC.getNameWithTitle & "!")
            End If

            Dim dmg As Integer = (p.getATK) + (10) + Int(Rnd() * 3 + 1)
            p.hit(dmg, m)
        End If

        Dim w_dmg = 20 + Int(Rnd() * 6 + 1) + Int(Rnd() * 6 + 1)
        durability -= w_dmg
        If durability <= 0 Then
            break()
        ElseIf Not m Is Nothing AndAlso Not m.isDead Then
            TextEvent.pushAndLog("The " & getName.Replace("_", " ") & " takes " & w_dmg & " damage.")
        Else
            TextEvent.pushLog("The " & getName.Replace("_", " ") & " takes " & w_dmg & " damage.")
        End If
    End Sub

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
