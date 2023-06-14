Public Class GemOfProg
    Inherits Item

    Public Const ITEM_NAME As String = "Gem_of_Progress"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 206
        tier = Nothing

        '|Item Flags|
        usable = True
        droppable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 4500

        '|Description|
        setDesc("A glittering azure jewel that looks like it could be embeded into a wand.")
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f6f9
                Return 4
            Case LootTable.bracket.f10f12
                Return 4
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

        If p.inv.getCountAt("Magical_Girl_Wand") > 0 Then
            p.inv.add("Magical_Girl_Wand", -1)
            p.inv.add("Pro_Mag._Girl_Wand", 1)
            If p.equippedWeapon.getName.Equals("Magical_Girl_Wand") Then  EquipmentDialogBackend.weaponChange(p, "Pro_Mag._Girl_Wand")
            TextEvent.pushLog("You apply the " & getName() & ".  Magical_Girl_Wand upgraded!")
        Else
            TextEvent.pushLog("Without something to use it on, the gem is basically useless...")
        End If

        count -= 1
    End Sub
End Class
