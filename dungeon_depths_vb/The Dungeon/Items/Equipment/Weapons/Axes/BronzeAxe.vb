Public Class BronzeAxe
    Inherits Axe

    Public Const ITEM_NAME As String = "Bronze_Battle_Axe"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 84
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        a_boost = 12
        count = 0
        value = 235

        '|Description|
        setDesc("A curved, double-headed bronze axe with a simple wooden handle.  Some might call this a ""Labrys""." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
