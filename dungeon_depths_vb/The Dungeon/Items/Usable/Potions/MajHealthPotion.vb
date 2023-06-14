Public Class MajHealthPotion
    Inherits Item

    Public Const ITEM_NAME As String = "Major_Health_Potion"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 82
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 550

        '|Description|
        setDesc("A turbo-charged health potion that heals all wounds completely.")

    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f1f2
                Return Nothing
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
        If p.className.Equals("Soul-Lord") Then
            TextEvent.push("You spike the health potion on the ground, shattering it all over the dungeon floor.  As you go back to your business, you muse on how cowardly healing is." & DDUtils.RNRN & """Only someone who cares about their mortal vessel would bother to maintain it.")
            p.UIupdate()
            Exit Sub
        End If
        TextEvent.pushLog("You drink the " & getName())
        Dim phHealth = p.health
        p.health = 1.0
        TextEvent.push("You drink the " & getName() & ".  +" & CInt((p.health - phHealth) * p.getMaxHealth) & " health!")
        count -= 1
    End Sub
End Class
