Public Class BimbovisionGoggles
    Inherits Glasses

    Public Const ITEM_NAME As String = "Bimbovision_Goggles"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 396
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|    
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(13, True, True)

        '|Description|
        setDesc("A pair of black glasses etched with a series of runes that enhance one's vision beyond what is probably adviseable." & DDUtils.RNRN &
                DDUtils.TODO & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        Game.mDun.world_flags(wFlag.bimbovision) = 1
        p.setPlayerImage()
        Game.drawBoard()
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)

        Game.mDun.world_flags(wFlag.bimbovision) = -1
        p.setPlayerImage()
        Game.drawBoard()
    End Sub
End Class
