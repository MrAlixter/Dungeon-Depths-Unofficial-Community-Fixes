Public Class MistwarpedPolearm
    Inherits Bludgeon

    Public Const ITEM_NAME As String = "Mistwarped_Polearm"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 427
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        a_boost = 9
        s_boost = -5
        count = 0
        value = 138

        '|Description|
        setDesc("A wobbly pink phallus, more than a meter long.  It doesn't have an edge or spiked tip, but it seems to have enough heft to do some damage." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
