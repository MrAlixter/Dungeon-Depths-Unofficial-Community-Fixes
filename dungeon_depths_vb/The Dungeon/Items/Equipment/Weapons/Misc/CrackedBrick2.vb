Public Class CrackedBrick2
    Inherits Weapon

    Public Const ITEM_NAME As String = "Cracked_Brick_II"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 440
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 100
        a_boost = 20
        s_boost = -10

        '|Description|

        setDesc("A cracked tan brick; one of the many that formed the floor on the later floors of this dungeon. " & DDUtils.RNRN &
                "Can be thrown using the ""Use"" button." & DDUtils.RNRN &
                getStatInformation())
    End Sub


    Public Overrides Function getTier(floor_num As Integer) As Integer
        If Game.player1.formName = "Dove" Then
            Select Case LootTable.getBracket(floor_num)
                Case LootTable.bracket.f1f2
                    If floor_num <> 1 Then Return 2
                Case Else
                    Return 1
            End Select
        End If

        Return Nothing
    End Function

    Overridable Sub wThrow(ByRef p As Player, ByRef m As Entity)
        If m Is Nothing Then
            TextEvent.pushAndLog("You throw the brick across the dungeon at nothing in particular.")
        Else
            If m.getNPC() Is Nothing Then
                TextEvent.pushAndLog("You throw the " & getName.Replace("_", " ") & "!")
            Else
                TextEvent.pushAndLog("You throw the " & getName.Replace("_", " ") & " at " & m.getNPC.getNameWithTitle & "!")
            End If

            Dim dmg As Integer = (p.getATK) + (30) + Int(Rnd() * 3 + 1)
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
        wThrow(p, p.currTarget)
    End Sub
End Class
