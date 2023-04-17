Public Class SellHellfireBlade
    Inherits Item

    Public Const ITEM_NAME As String = "Sell_Hellfire_Blade"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 403
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False
        can_be_stolen = False
        MyBase.onBuy = AddressOf fix

        '|Stats|
        count = 0
        value = 3666

        '|Description|
        setDesc("A jet black blade that becomes engulfed in a ball of rosy flame once pulled from its leather scabbard." & DDUtils.RNRN &
                "This sword will take damage from each attack." & DDUtils.RNRN &
                "Each attack will its wielder's lust by one third." & DDUtils.RNRN &
                "Purchasing this sword consumes 3x " & SuccubusGarb.ITEM_NAME)
    End Sub

    Sub fix()
        Dim p = Game.player1
        Game.shopMenu.Close()

        If p.inv.getCountAt(SuccubusGarb.ITEM_NAME) >= 3 AndAlso Not (p.equippedArmor.getAName.Equals(SuccubusGarb.ITEM_NAME) And p.inv.getCountAt(SuccubusGarb.ITEM_NAME) = 3) Then
            TextEvent.pushNPCDialog("Alright, there we go!")
            TextEvent.pushLog("+1 " & HellflamingSword.ITEM_NAME)
            TextEvent.pushLog("-3 " & SuccubusGarb.ITEM_NAME)

            p.inv.add(SuccubusGarb.ITEM_NAME, -3)
            p.inv.add(HellflamingSword.ITEM_NAME, 1)
            p.UIupdate()
        ElseIf p.equippedArmor.getAName.Equals(SuccubusGarb.ITEM_NAME) And p.inv.getCountAt(SuccubusGarb.ITEM_NAME) = 3 Then
            TextEvent.pushNPCDialog("You're gonna have to... um... get naked, right?  You're wearing " & SuccubusGarb.ITEM_NAME & " number 3.")
            p.gold += value
        Else
            TextEvent.pushNPCDialog("Hate to say it, but there's not much I can do for you there..." & DDUtils.RNRN &
                                    "You're gonna have to fight some more succubi, I guess.")
            p.gold += value
        End If

        count -= 1
    End Sub
End Class
