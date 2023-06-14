Public Class AllSeeingShades
    Inherits Glasses

    Public Const ITEM_NAME As String = "All-Seeing_Shades"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 319
        tier = 4

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
        setDesc("A pair of black glasses etched with a series of runes that enhance one's vision beyond what is probably adviseable." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Public Overrides Sub onUnequip(ByRef p As Player)
        p.perks(perk.blind) = 1
        Game.drawBoard()
    End Sub
End Class
