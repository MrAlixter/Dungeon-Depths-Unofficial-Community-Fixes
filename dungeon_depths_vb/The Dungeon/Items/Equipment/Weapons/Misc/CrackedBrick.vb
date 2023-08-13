Public Class CrackedBrick
    Inherits Weapon

    Public Const ITEM_NAME As String = "Cracked_Brick"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 390
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 30
        a_boost = 10
        s_boost = -10

        '|Description|

        setDesc("A cracked gray brick; one of the many that formed the floor on the early floors of this dungeon. " & DDUtils.RNRN &
                "Can be thrown using the ""Use"" button." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Overridable Sub wThrow(ByRef p As Player, ByRef m As Entity)
        If m Is Nothing Then
            TextEvent.pushAndLog("You throw the brick across the dungeon at nothing in particular.")
        Else
            If m.getNPC() Is Nothing Then
                TextEvent.pushAndLog("You throw the " & getName.Replace("_", " ") & "!")
            Else
                TextEvent.pushAndLog("You throw the " & getName.Replace("_", " ") & " at " & m.getNPC.getNameWithTitle & "!")
            End If

            Dim dmg As Integer = (p.getATK) + (15) + Int(Rnd() * 3 + 1)
            p.hit(dmg, m)
        End If

        Dim w_dmg = 30 + Int(Rnd() * 6 + 1) + Int(Rnd() * 6 + 1)
        durability -= w_dmg
        If durability <= 0 Then
            break()
        ElseIf Not m.isDead Then
            TextEvent.pushAndLog("The " & getName.Replace("_", " ") & " takes " & w_dmg & " damage.")
        Else
            TextEvent.pushLog("The " & getName.Replace("_", " ") & " takes " & w_dmg & " damage.")
        End If
    End Sub

    Public Overrides Sub use(ByRef p As Player)
        wThrow(p, p.currTarget)
    End Sub
End Class
