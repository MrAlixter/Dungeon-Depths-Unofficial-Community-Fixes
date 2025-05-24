Public Class ShoppersCoin
    Inherits Item

    Public Const ITEM_NAME As String = "Shopper's_Coin"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 461

        '|Item Flags|
        usable = False
        tier = Nothing
        rando_inv_allowed = False
        only_drop_one = True

        '|Stats|
        count = 0
        value = 2

        '|Description|
        setDesc("A glistening gold coin." & DDUtils.RNRN &
                "...")
    End Sub
End Class
