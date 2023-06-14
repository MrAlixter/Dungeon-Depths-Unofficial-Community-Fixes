Public Class HealthCharm
    Inherits Item

    Public Const ITEM_NAME As String = "Health_Charm"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 48
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 1750

        '|Description|
        setDesc("A charm that slightly boosts your health.")
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f1f2
                Return 4
            Case LootTable.bracket.f10f12
                Return 2
            Case LootTable.bracket.f13
                Return 2
            Case LootTable.bracket.f14fXX
                Return 2
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        If p.className.Equals("Soul-Lord") Then
            TextEvent.push("You spike the health charm on the ground, shattering it all over the dungeon floor.  As you go back to your business, you muse on how cowardly healing is." & DDUtils.RNRN & """Only someone who cares about their mortal vessel would bother to maintain it.")
            p.UIupdate()
            Exit Sub
        End If
        TextEvent.pushLog("You use the " & getName() & ". +10 base health!")

        Game.player1.maxHealth += 10
        Game.player1.health += 10 / Game.player1.getMaxHealth()
        If Game.player1.health > 1 Then Game.player1.health = 1
        Game.player1.UIupdate()
        count -= 1
    End Sub
End Class
