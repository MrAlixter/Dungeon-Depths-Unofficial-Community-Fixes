Public Class StealthGear
    Inherits Accessory

    Public Const ITEM_NAME As String = "Stealth_Gear"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 164
        tier = Nothing

        '|Item Flags|
        usable = False
        under_t_clothes = True
        hide_mouth = True

        '|Stats|
        s_boost = 4
        count = 0
        value = 10

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(13, False, True)

        '|Description|
        setDesc("Wraps of fabric that tighten down loose clothing in order to make its wearer more sneaky." & DDUtils.RNRN &
                "Reduces encouter rate, low dodge chance." & DDUtils.RNRN &
                getStatInformation())
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        p.perks(perk.stealth) = 1
        Game.drawBoard()
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.perks(perk.stealth) = -1
        Game.drawBoard()
    End Sub
End Class
