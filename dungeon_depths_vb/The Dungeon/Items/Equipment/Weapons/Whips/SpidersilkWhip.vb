Public Class SpidersilkWhip
    Inherits Whip

    Public Const ITEM_NAME As String = "Spidersilk_Whip"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 63
        tier = 3

        '|Item Flags|
        usable = False
        npc_drop_only = True

        '|Stats| 
        a_boost = 25
        count = 0
        value = 928

        '|Description|
        setDesc("A white silk whip that critically hits more often than a standard sword." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
