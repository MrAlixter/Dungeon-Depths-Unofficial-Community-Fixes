Public Class PlatinumAxe
    Inherits Axe

    Sub New()
        '|ID Info|
        MyBase.setName("Platinum_Axe")
        id = 255
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.isMonsterDrop = False

        '|Stats|
        MyBase.count = 0
        MyBase.value = 5000
        MyBase.aBoost = 45
        MyBase.sBoost = -2

        '|Description|
        MyBase.setDesc("A glistening, jeweled axe forged for superb slashers." & DDUtils.RNRN &
                       getStatInformation())
    End Sub
End Class
