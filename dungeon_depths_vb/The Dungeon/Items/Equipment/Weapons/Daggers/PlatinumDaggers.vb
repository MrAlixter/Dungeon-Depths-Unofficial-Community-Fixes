Public Class PlatinumDaggers
    Inherits Dagger

    Sub New()
        '|ID Info|
        MyBase.setName("Platinum_Daggers")
        id = 256
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.isMonsterDrop = False

        '|Stats|
        MyBase.count = 0
        MyBase.value = 5000
        MyBase.aBoost = 20
        MyBase.sBoost = 15

        '|Description|
        MyBase.setDesc("A glistening, jeweled pair of daggers concealed by the stealthiest sneakers." & DDUtils.RNRN &
                       "Hits twice" & DDUtils.RNRN &
                       getStatInformation())
    End Sub
End Class
