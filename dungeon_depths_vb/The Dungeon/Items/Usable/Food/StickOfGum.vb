Public Class StickOfGum
    Inherits Food

    Public Const ITEM_NAME As String = "Stick_of_Gum"
    Dim use_gum_tier As Boolean = False

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 1
        tier = 1

        '|Item Flags|
        usable = True
        onSell = AddressOf npcTF
        use_gum_tier = True

        '|Stats|
        count = 0
        value = 100
        setCalories(10)

        '|Description|
        setDesc("An ordinary looking piece of gum with a faint chemical smell." & DDUtils.RNRN &
                "+10 Stamina")

    End Sub

    Sub npcTF()
        If ShopV3.current_value >= 50 And Not Game.active_shop_npc.form.Equals("Bimbo") Then
            TextEvent.pushLog("As the " & Game.active_shop_npc.getNameWithTitle() & " accepts the pile of gum, the air crackles with pink energy...")
            Game.active_shop_npc.toBimbo()
        End If
    End Sub

    Overrides Sub effect(ByRef p As Player)
        If p.className.Equals("Bimbo++") Then
            TextEvent.push("Chewing the gum makes your head feel all warm and fuzzy..." & DDUtils.RNRN &
                           "...but fortunately the haze clears from your mind shortly afterwards.")
            bimboPPEffect(p)
        ElseIf p.className.Contains("Bimbo") Then
            TextEvent.push("Chewing the gum makes your head feel all warm and fuzzy and stuff..." & DDUtils.RNRN &
                           "You, like, totally love this gum!")
            bimboEffect(p)
        ElseIf p.perks(perk.bimbotf) = -1 Then
            TextEvent.pushAndLog("Chewing the gum causes a dizzy calm wash to over you.")
            tfEffect(p)
        End If
    End Sub

    Overridable Sub tfEffect(ByRef p As Player)
        p.ongoingTFs.add(New BimboTF(2, 5, 0.25, True))
        p.perks(perk.bimbotf) = 0
    End Sub
    Overridable Sub bimboEffect(ByRef p As Player)
    End Sub
    Overridable Sub bimboPPEffect(ByRef p As Player)
        bimboEffect(p)
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        If use_gum_tier Then Return MyBase.getTier(floor_num)

        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f1f2
                Return 1
            Case LootTable.bracket.f3f5
                Return 1
            Case LootTable.bracket.f6f9
                Return 1
            Case LootTable.bracket.misc
                Return MyBase.getTier(floor_num)
            Case Else
                Return Nothing
        End Select
    End Function
End Class
