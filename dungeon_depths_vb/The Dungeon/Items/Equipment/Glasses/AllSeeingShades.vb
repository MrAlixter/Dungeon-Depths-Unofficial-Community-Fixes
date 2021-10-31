Public Class AllSeeingShades
    Inherits Glasses

    Sub New()
        '|ID Info|
        setName("All-Seeing_Shades")
        id = 319
        tier = 4

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|    
        count = 0
        value = 0

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(11, True, True)

        '|Description|
        setDesc("A pair of black glasses etched with a series of runes that enhance one's vision beyond what is probably adviseable." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        p.perks(perk.blind) = 1
        Game.drawBoard()
    End Sub
End Class
