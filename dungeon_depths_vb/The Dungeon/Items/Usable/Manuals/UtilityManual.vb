Public Class UtilityManual
    Inherits Manual

    Public Const ITEM_NAME As String = "Utility_Manual"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 89
        tier = 2

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 500

        '|Description|
        setDesc("A simple, leather-bound book that likely contains some helpful skills.")
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f10f12
                Return 1
            Case LootTable.bracket.f13
                Return 1
            Case LootTable.bracket.f14fXX
                Return 1
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Public Shared Shadows Function getSpecials() As String()
        Return New UtilityManual().specials
    End Function
    Public Overrides Function specials() As String()
        Return {"Ritual of Mana", "Cleanse", "Spot Fusion", "Uvona's Blessing", "Charm"}
    End Function
End Class
