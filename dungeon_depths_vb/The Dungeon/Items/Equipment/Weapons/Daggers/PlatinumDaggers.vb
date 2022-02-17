Public Class PlatinumDaggers
    Inherits Dagger

    Public Const ITEM_NAME As String = "Platinum_Daggers"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 256
        tier = Nothing

        '|Item Flags|
        usable = false
        droppable = False

        '|Stats|
        a_boost = 20
        s_boost = 15
        count = 0
        value = 5000

        '|Description|
        setDesc("A glistening, jeweled pair of daggers concealed by the stealthiest sneakers." & DDUtils.RNRN &
                "Hits twice" & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
