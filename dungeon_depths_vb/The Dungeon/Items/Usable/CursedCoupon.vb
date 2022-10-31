Public Class CursedCoupon
    Inherits Item

    Public Const ITEM_NAME As String = "Cursed_Coupon"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 182
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 560

        '|Description|
        setDesc("A small slip of paper advertising some sort of shady magic store.  While you have the sense not to grab it directly, who knows what havoc it could unleash if you got a little careless...")
    End Sub

    Public Overrides Sub use(ByRef p As Player)

        If Game.combat_engaged And Not p.currTarget Is Nothing Then
            'regular effecth
            p.currTarget.isStunned = True
            p.currTarget.stunct = 2
            TextEvent.pushLog("With a poof, " & p.currTarget.getName & " becomes an inflated version of themselves!")
            TextEvent.pushCombat("With a poof " & p.currTarget.getName & " becomes an inflated version of themselves!")
        ElseIf Game.shop_npc_engaged And Not Game.active_shop_npc Is Nothing Then
            Dim out = ""
            If Game.active_shop_npc.getName.Contains("Shady") Then out = "The second they take hold of the coupon, the magical grifter's eyes widen and a powerful backlash of magic washes over them..."
            TextEvent.push(out & "With a poof " & Game.active_shop_npc.getName & " becomes an inflated version of themselves!", AddressOf Game.active_shop_npc.toDoll)
        Else
            Game.player1.ongoingTFs.Add(New BUDollTF())
            Game.player1.update()
        End If
        count -= 1
    End Sub
End Class
