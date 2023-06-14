Public Class CWarAxe
    Inherits Axe

    Public Const ITEM_NAME As String = "Corse_War_Axe"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 118
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        a_boost = 25
        s_boost = -10
        count = 0
        value = 1000

        '|Description|
        setDesc("A roughly finished, yet sturdy steel axe attached to a  beaten up wooden shaft.  Its uneven constuction, while boosting attack, also decreases speed slightly." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f10f12
                Return 3
            Case LootTable.bracket.f13
                Return 3
            Case LootTable.bracket.f14fXX
                Return 3
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function
End Class
