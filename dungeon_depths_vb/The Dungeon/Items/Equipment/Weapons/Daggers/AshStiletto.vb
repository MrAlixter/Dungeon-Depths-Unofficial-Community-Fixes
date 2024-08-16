Public Class AshStiletto
    Inherits Dagger

    Public Const ITEM_NAME As String = "Twisted_Ash_Stiletto"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 444
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        count = 0
        value = 1865
        a_boost = 8
        s_boost = 7

        '|Description|
        setDesc("A gleaming blade, with a handle made of shapely twisted wood." & DDUtils.RNRN &
                "When attacking, the user hits twice." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
