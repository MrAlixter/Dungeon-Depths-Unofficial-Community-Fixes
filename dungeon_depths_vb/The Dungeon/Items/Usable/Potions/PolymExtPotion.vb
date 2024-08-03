Public Class PolymExtPotion
    Inherits Item

    Public Const ITEM_NAME As String = "Polymorph_Extend._Pot."

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 437
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 620

        '|Description|
        setDesc("""Extends ye polymorpherization."" says the bottle.")

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

        p.perks(perk.polymorphed) += 100
        For i = p.ongoingTFs.getTFs.Count - 1 To 0 Step -1
            tf = p.ongoingTFs.getTFs(i)
            If tf.GetType().IsSubclassOf(GetType(PolymorphTF)) Then tf.addTurnsTilStep(100)
        Next

        count -= 1
    End Sub
End Class
