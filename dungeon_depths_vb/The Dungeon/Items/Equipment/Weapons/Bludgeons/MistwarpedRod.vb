Public Class MistwarpedRod
    Inherits Bludgeon

    Public Const ITEM_NAME As String = "Mistwarped_Rod"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 428
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        count = 0
        value = 138
        a_boost = 3
        s_boost = 5

        '|Description|
        setDesc("A wobbly pink phallus, about the length of a wand; or of a dagger.  It doesn't have an edge, but it seems to have enough heft to do some damage." & DDUtils.RNRN &
                "Can be thrown using the ""Use"" button." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Overridable Sub wThrow(ByRef p As Player, ByRef m As Entity)
        If m Is Nothing Then
            TextEvent.pushAndLog("You throw the rod across the dungeon at nothing in particular.")
        Else
            If m.getNPC() Is Nothing Then
                TextEvent.pushAndLog("You throw the " & getName.Replace("_", " ") & "!")
            Else
                TextEvent.pushAndLog("You throw the " & getName.Replace("_", " ") & " at " & m.getNPC.getNameWithTitle & "!")
            End If

            Dim dmg As Integer = (p.getATK) + (a_boost) + Int(Rnd() * 3 + 1)
            p.hit(dmg, m)
        End If

        Dim w_dmg = p.getATK() + Int(Rnd() * 14) + 1
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
