Public Class PlatinumDaggers
    Inherits Dagger

    Sub New()
        '|ID Info|
        setName("Platinum_Daggers")
        id = 256
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.droppable = False

        '|Stats|
        count = 0
        value = 5000
        MyBase.a_boost = 20
        MyBase.s_boost = 15

        '|Description|
        setDesc("A glistening, jeweled pair of daggers concealed by the stealthiest sneakers." & DDUtils.RNRN &
                "Hits twice" & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
