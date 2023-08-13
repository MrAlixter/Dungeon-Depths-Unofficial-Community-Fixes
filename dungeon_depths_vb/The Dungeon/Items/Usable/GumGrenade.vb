Public Class GumGrenade
    Inherits Item

    Public Const ITEM_NAME As String = "Gum_Grenade"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 416
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 560

        '|Description|
        setDesc("A brushed-metal canister with only an ominious pink button to break up its surface.  It seems foolproof enough... right?")
    End Sub

    Public Overrides Sub use(ByRef p As Player)
        If Not Game.active_shop_npc Is Nothing Then
            TextEvent.pushAndLog("The grenade douses " & Game.active_shop_npc.getNameWithTitle & " in a pink mist, turning them into a bimbo!")
            Game.active_shop_npc.toBimbo()
        ElseIf Game.combat_engaged = False Then
            BimboTF.polymorphTf(p, 70)
            p.drawPort()

            TextEvent.pushAndLog("The grenade goes off in your hand, and douses you in a pink mist.  It turns you into a bimbo for 70 turns!")
        ElseIf (Int(Rnd() * 5) = 1) Or p.currTarget Is Nothing Then
            'backfire
            BimboTF.polymorphTf(p, 3)
            p.drawPort()

            TextEvent.pushAndLog("The grenade goes off early in your hand, and douses you in a pink mist.  It turns you into a bimbo for 3 turns!")
        Else
            'regular effect
            p.currTarget.perks(npc_perk.stun) = 2
            TextEvent.pushAndLog("The grenade douses " & p.currTarget.getNameWithTitle & " in a pink mist, stunning " & p.currTarget.r_pronoun & " for 3 turns!")
        End If

        count -= 1
    End Sub
End Class
