Public Class TKnife
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
            TextEvent.push("You throw the knife across the dungeon at nothing in particular.")
            TextEvent.pushLog("You throw the knife across the dungeon at nothing in particular.")
        Else
            TextEvent.pushLog("You throw the knife!")
            Dim dmg As Integer = (p.getATK) + (10) + Int(Rnd() * 3 + 1)
            p.hit(dmg, m)
        End If

        durability -= 30 + Int(Rnd() * 6 + 1) + Int(Rnd() * 6 + 1)
        If durability <= 0 Then break()
    End Sub

    Public Overrides Sub use(ByRef p As Player)
        wThrow(p, p.currTarget)
    End Sub
End Class
