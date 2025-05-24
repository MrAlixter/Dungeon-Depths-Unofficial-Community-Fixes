Public Class CrossedStarTag
    Inherits Item

    Public Const ITEM_NAME As String = "Crossed_Star_Spelltag"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 461
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 7500

        '|Description|
        setDesc("A small paper tag with instructions to apply it to your equipment.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        Game.leaveNPC()
        Game.mDun.world_flags(wFlag.stellarwitchswapped) = 1
        Game.swiz.hasMetPlayer = False
        TextEvent.fpush("A", AddressOf use2)
        count -= 1
    End Sub

    Protected Sub use2()
        TextEvent.fpush("B")
    End Sub

    Public Overrides Function getUsable() As Boolean
        Return Not Game.mDun Is Nothing AndAlso Game.mDun.getWorldFlag(wFlag.stellarwitchswapped) < 0 AndAlso Game.shop_npc_engaged AndAlso Game.active_shop_npc.Equals(Game.swiz)
    End Function
End Class
