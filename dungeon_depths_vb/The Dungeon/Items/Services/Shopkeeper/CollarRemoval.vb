Public Class CollarRemoval
    Inherits Item

    Public Const ITEM_NAME As String = "Collar_Removal"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 434
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False
        can_be_stolen = False
        MyBase.onBuy = AddressOf snip

        '|Stats|
        count = 0
        value = 1120

        '|Description|
        setDesc("""Do you have one of those pesky collars latched to your neck?  I can take a look at getting rid of it, if you'd like.""")
    End Sub

    Sub snip()
        Dim p = Game.player1
        Game.shopMenu.Close()
        count = 0

        If p.equippedAcce.getAName.Equals("Slave_Collar") Then
            Game.picNPC.BackgroundImage = ShopNPC.gbl_img.atrs(0).getAt(0)
            Game.picNPC.Visible = True

            TextEvent.pushNPCDialog("""Ah, let's get that taken off.""" & DDUtils.RNRN &
                                    "The Shopkeeper snips off the collar on your neck.")
            TextEvent.pushLog("The Shopkeeper snips off the collar on your neck.")

            EquipmentDialogBackend.equipAcce(p, "Nothing", False)
        Else
            Game.picNPC.BackgroundImage = ShopNPC.gbl_img.atrs(0).getAt(0)
            Game.picNPC.Visible = True
            p.inv.add(Gold.ITEM_NAME, CInt(value * (1.0 - Game.shopkeeper.discount)))
            TextEvent.pushNPCDialog("Fortunately it does not appear that you have a collar latched on... I'm glad to give you a full refund.")
        End If

        p.drawPort()
        p.UIupdate()
    End Sub
End Class
