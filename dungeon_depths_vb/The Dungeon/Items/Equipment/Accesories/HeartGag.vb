Public Class HeartGag
    Inherits Accessory

    Sub New()
        '|ID Info|
        setName("Heart_Gag")
        id = 164
        tier = Nothing

        '|Item Flags|
        usable = False
        hide_mouth = True

        '|Stats|
        count = 0
        value = 10

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(13, False, True)

        '|Description|
        setDesc("" & DDUtils.RNRN &
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
