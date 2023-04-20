Public Class SummerShades
    Inherits Glasses

    Public Const ITEM_NAME As String = "Summertime_Shades"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 299
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False
        over_acce = True

        '|Stats|
        count = 0
        value = 1356
        w_boost = 11

        '|Image Index|
        imgInd = New Tuple(Of Integer, Boolean, Boolean)(9, True, True)

        '|Description|
        setDesc("A pair of shiny black glasses in a sleek yellow frame." & DDUtils.RNRN &
                "Triples the defense of any bikinis that its wielder is wearing." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getdBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0

        Return If(p.equippedArmor.getAName.Contains("Bikini"), p.equippedArmor.getDBoost(p) * 2, 0)
    End Function

    Public Overrides Function getDesc() As Object
        Return "A pair of shiny black glasses in a sleek yellow frame." & DDUtils.RNRN &
                "Triples the defense of any bikinis that its wielder is wearing." & DDUtils.RNRN &
                getStatInformation()
    End Function
End Class
