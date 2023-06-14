Public Class BronzeSpear
    Inherits Spear

    Public Const ITEM_NAME As String = "Bronze_Spear"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 155
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        MyBase.a_boost = 15
        MyBase.s_boost = -5
        count = 0
        value = 400

        '|Description|
        setDesc("A simple bronze spear.  It's more likely to hit critically than a sword, but also more likely to miss altogether." & DDUtils.RNRN &
                "Can be thrown using the ""Use"" button." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f1f2
                Return 2
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function
End Class
