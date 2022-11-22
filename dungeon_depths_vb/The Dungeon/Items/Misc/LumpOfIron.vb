Public Class LumpOfIron
    Inherits Item

    Public Const ITEM_NAME As String = "Lump_of_Iron"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 352
        tier = 2

        '|Item Flags|
        usable = False
        rando_inv_allowed = False
        only_drop_one = True
        onSell = AddressOf doOnSell

        '|Stats|
        count = 0
        value = 480

        '|Description|
        setDesc("A small lump of metal ore." & DDUtils.RNRN &
                "Perhaps a smith could make something if they bought it from you...")
    End Sub

    Sub doOnSell()
        If Game.active_shop_npc.getName.ToUpper.Contains("SMITH") Then
            TextEvent.pushAndLog("Iron Dagger now availible for sale!")
            Game.active_shop_npc.inv.add(IronDagger.ITEM_NAME, 1)
            Game.player1.perks(perk.irondagger) = 1
        End If
    End Sub

    Public Overrides Function getTier() As Integer
        If Game.player1.perks(perk.irondagger) > 0 Then Return Nothing Else Return MyBase.getTier()
    End Function
End Class
