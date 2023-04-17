Public Class UpgradeArmor
    Inherits Item

    Public Const ITEM_NAME As String = "Upgrade_Armor"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 263
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False
        can_be_stolen = False
        MyBase.onBuy = AddressOf fix

        '|Stats|
        count = 0
        value = 1000

        '|Description|
        setDesc("""If your equipped kit is a litte less... practical... than you'd like, I can take a look and see if I can shore anything up.""")
    End Sub

    Sub fix()
        Dim p = Game.player1
        Game.shopMenu.Close()

        If Equipment.antiClothingCurse(p) Then
            Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(29), "Alright, there we go!  That should do you a little better in the defense department.")
            p.drawPort()
        Else
            Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(31), "Hate to say it, but there's not much I can do for you there...")
            p.gold += value
        End If

        count -= 1
    End Sub
End Class
