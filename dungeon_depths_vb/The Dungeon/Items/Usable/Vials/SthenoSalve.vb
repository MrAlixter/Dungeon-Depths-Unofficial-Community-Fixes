Public Class SthenoSalve
    Inherits Item

    Public Const ITEM_NAME As String = "Stheno's_Salve"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 338
        tier = 4

        '|Item Flags|
        usable = True
        npc_drop_only = True

        '|Stats|
        count = 0
        value = 2248

        '|Description|
        setDesc("A glass vial filled to the brim with a brilliant golden elixir.  A small label with a crude drawing of a smiling gorgon states that it should be used ""for mistakes""...")
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f1f2
                Return Nothing
            Case LootTable.bracket.f6f9
                Return Nothing
            Case LootTable.bracket.f10f12
                Return 3
            Case LootTable.bracket.f13
                Return 3
            Case LootTable.bracket.f14fXX
                Return 3
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        TextEvent.pushLog("You apply the " & getName())

        If p.perks(perk.astatue) > 0 Then
            p.perks(perk.astatue) = -1
            p.revertToPState()
            p.canMoveFlag = True

            TextEvent.push("You rock yourself over, deftly landing on the vial of salve and nothing else.  It shatters, and the contents within liquify into a glowing puddle that surrounds your inanimate form.  Some feeling returns to your body, and the golden aura dims as you spring to your feet." & DDUtils.RNRN &
                           "You can move once again!")
        Else
            TextEvent.push("You crack open the vial, and pour its content all over yourself.  Somewhat disappointingly, nothing happens...")
        End If

        count -= 1
    End Sub
End Class
