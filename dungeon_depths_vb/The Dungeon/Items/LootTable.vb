Public Class LootTable
    Public Enum bracket
        misc
        f1f2
        f3f5
        f6f9
        f10f12
        f13
        f14fXX
    End Enum

    '| -- Loot Table Template -- |

    'Public Overrides Function getTier(floor_num As Integer) As Integer
    '    Select Case LootTable.getBracket(floor_num)
    '        Case LootTable.bracket.f1f2
    '        Case LootTable.bracket.f3f5
    '        Case LootTable.bracket.f6f9
    '        Case LootTable.bracket.f10f12
    '        Case LootTable.bracket.f13
    '        Case LootTable.bracket.f14fXX
    '        Case Else
    '            Return MyBase.getTier(floor_num)
    '    End Select
    'End Function

    Private Shared loot_table(,) As Integer

    'Shared Sub New()
    '    Dim inv As Inventory = New Inventory(False)

    '    ReDim loot_table(inv.count, [Enum].GetValues(GetType(bracket)).Length)

    '    setLootTable(inv.idOfKey(Compass.ITEM_NAME), 1, 1, 1, 1, 1, Nothing)
    'End Sub

    Shared Sub setLootTable(ByVal itmid As Integer, ByVal ParamArray weights() As Integer)
        For i = 0 To UBound(weights)
            loot_table(itmid, i) = weights(i)
        Next
    End Sub

    Protected Friend Shared Function getBracket(ByVal floor_num As Integer) As bracket
        If Settings.active(setting.oldloot) Or floor_num = 91017 Then Return bracket.misc

        Select Case floor_num
            Case 1, 2
                Return bracket.f1f2
            Case 3, 4, 5
                Return bracket.f3f5
            Case 6, 7, 8, 9
                Return bracket.f6f9
            Case 10, 11, 12
                Return bracket.f10f12
            Case 13
                Return bracket.f13
            Case Else
                Return bracket.f14fXX
        End Select
    End Function
End Class
