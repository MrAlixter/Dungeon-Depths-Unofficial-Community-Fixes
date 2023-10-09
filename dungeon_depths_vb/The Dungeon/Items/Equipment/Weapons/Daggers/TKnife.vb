Public Class ThrowingKnife
    Inherits Dagger

    Public Const ITEM_NAME As String = "Throwing_Knife"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 162
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 235
        a_boost = 4

        '|Description|

        setDesc("A small blade weighted in such a way that it tumbles end over end when hurled at a target. " & DDUtils.RNRN &
                "Can be thrown using the ""Use"" button." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f1f2
                Return 2
            Case LootTable.bracket.f3f5
                Return 1
            Case LootTable.bracket.f6f9
                Return 1
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
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

        Dim w_dmg = 30 + Int(Rnd() * 6 + 1) + Int(Rnd() * 6 + 1)
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
