Public Class MarissasRation
    Inherits Food

    Public Const ITEM_NAME As String = "Marissa's_Ration"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 409
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 140
        setCalories(25)

        '|Description|
        setDesc("A pouch of dried meat and roasted nuts.  It seems to have been cursed by Marissa the Enchantress." & DDUtils.RNRN &
                "+25 Stamina")
    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        DubiousRations.marissasEnchantment(p)
    End Sub
End Class
