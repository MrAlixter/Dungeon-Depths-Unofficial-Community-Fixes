Public Class CursedCoupon
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("Cursed_Coupon")
        id = 182
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)

        '|Stats|
        MyBase.count = 0
        MyBase.value = 560

        '|Description|
        MyBase.setDesc("A small slip of paper advertising some sort of shady magic store.  While you have the sense not to grab it directly, who knows what havoc it could unleash if you got a little careless...")
    End Sub

    Public Overrides Sub use(ByRef p As Player)

        If Game.combatmode And Not p.currTarget Is Nothing Then
            'regular effecth
            p.currTarget.isStunned = True
            p.currTarget.stunct = 2
            Game.pushLstLog("With a poof, " & p.currTarget.getName & " becomes an inflated version of themselves!")
            Game.pushLblCombatEvent("With a poof " & p.currTarget.getName & " becomes an inflated version of themselves!")
        ElseIf Game.npcmode And Not Game.currNPC Is Nothing Then
            Dim out = ""
            If Game.currNPC.getName.Contains("Shady") Then out = "The second they take hold of the coupon, the magical grifter's eyes widen and a powerful backlash of magic washes over them...   "
            Game.pushLblEvent(out & "With a poof " & Game.currNPC.getName & " becomes an inflated version of themselves!", AddressOf Game.currNPC.toDoll)
        Else
            Game.player1.ongoingTFs.Add(New BUDollTF())
            Game.player1.update()
        End If
        count -= 1
    End Sub
End Class
