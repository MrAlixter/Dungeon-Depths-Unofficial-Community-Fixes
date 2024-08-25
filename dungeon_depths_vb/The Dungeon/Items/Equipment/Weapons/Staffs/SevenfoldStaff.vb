Public Class SevenfoldStaff
    Inherits Staff

    Public Const ITEM_NAME As String = "Sevenfold_Staff"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 448
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False

        '|Stats|
        a_boost = 7
        count = 0
        value = 1820

        '|Description|
        setDesc("A rune-lined scepter, carved from fine mahogany.  At its tip, seven copper rings crackle with energy." & DDUtils.RNRN &
                "Grants WIL and Max MP equal to seven times the player's current level." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getMBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 7

        Return p.level * 7
    End Function
    Public Overrides Function getWBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 7

        Return p.level * 7
    End Function

    Public Overrides Function getDescription() As Object
        Return "A rune-lined scepter, carved from fine mahogany.  At its tip, seven copper rings crackle with energy." & DDUtils.RNRN &
               "Grants WIL and Max MP equal to seven times the player's current level." & DDUtils.RNRN &
               getStatInformation()
    End Function
End Class
