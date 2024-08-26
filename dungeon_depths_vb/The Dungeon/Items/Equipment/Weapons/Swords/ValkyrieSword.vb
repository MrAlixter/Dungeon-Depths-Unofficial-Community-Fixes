Public Class ValkyrieSword
    Inherits Sword

    Public Const ITEM_NAME As String = "Valkyrie_Sword"

    Protected uniform_id As Integer = 95

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 96
        tier = 3

        '|Item Flags|
        usable = false

        '|Stats|
        MyBase.m_boost = 7
        MyBase.a_boost = 22
        count = 0
        value = 1168

        '|Description|
        setDesc("A blazing sword used by a winged protector." & DDUtils.RNRN &
                       getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f6f9
                Return 4
            Case LootTable.bracket.f10f12
                Return Nothing
            Case LootTable.bracket.f13
                Return Nothing
            Case LootTable.bracket.f14fXX
                Return Nothing
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.className.Equals("Valkyrie") And Not p.perks(perk.tfedbyweapon) > 0 Then
            Dim valkyrieTF = New ValkyrieTF2(1, 0, 0, False)

            valkyrieTF.update()
            p.ongoingTFs.add(valkyrieTF)

            p.perks(perk.tfcausingsword) = id
            p.perks(perk.tfedbyweapon) = 1
        End If
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player, ByRef w As Weapon)
        If (p.className.Equals("Valkyrie") Or p.perks(perk.tfedbyweapon) > 0) And Not w Is Nothing AndAlso Not w.GetType.IsSubclassOf(GetType(Sword)) And p.perks(perk.tfcausingsword) = id Then
            If Not Game.lblEvent.Visible Then TextEvent.fpush("Sighing, you sheath your blade and revert to your base form.")

            p.inv.add(uniform_id, -1)

            p.perks(perk.tfedbyweapon) = -1

            p.revertToPState()
        ElseIf (p.className.Equals("Valkyrie") Or p.perks(perk.tfedbyweapon) > 0) And Not w Is Nothing AndAlso Not w.GetType.IsSubclassOf(GetType(Sword)) Then
            CType(p.inv.item(p.perks(perk.tfcausingsword)), Sword).onUnequip(p, w)
        End If
    End Sub
End Class
