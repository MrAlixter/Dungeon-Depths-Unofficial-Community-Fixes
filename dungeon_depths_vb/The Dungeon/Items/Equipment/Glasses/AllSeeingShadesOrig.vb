Public Class AllSeeingShadesOrig
    Inherits Glasses

    Public Const ITEM_NAME As String = "All-Seeing_Shades_(Orig.)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 447
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        rando_inv_allowed = False
        over_acce = True

        '|Stats|    
        count = 0
        w_boost = 25
        value = 2366

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(11, True, True)

        '|Description|
        setDesc("The original-planned version of a pair of black glasses etched with a series of runes that enhance one's vision beyond what is probably adviseable." & DDUtils.RNRN &
                "Increases critical hit chance with weapons to a minimum of 50%.  Don't use both this and the " & SevenBandedRing.ITEM_NAME & " at the same time, please and thank you." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        p.perks(perk.blind) = 1
        Game.drawBoard()
    End Sub
End Class
