Public Class RestorationPotion
    Inherits Item

    Public Const ITEM_NAME As String = "Restore_Potion"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 14
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 854

        '|Description|
        setDesc("""Restores ye to ye original form"" says the bottle.")

    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f13
                Return Nothing
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You drink the " & getName())

        Dim rEffect = New RestEffect
        rEffect.apply(p)

        count -= 1
    End Sub
End Class
