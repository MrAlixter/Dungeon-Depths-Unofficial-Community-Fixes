Public Class SteelSword
    Inherits Sword

    Sub New()
        '|ID Info|
        MyBase.setName("Steel_Sword")
        id = 6
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)

        '|Stats|
        MyBase.aBoost = 17
        MyBase.count = 0
        MyBase.value = 235

        '|Description|
        MyBase.setDesc("A simple sword forged from steel." & DDUtils.RNRN &
                       getStatInformation())
    End Sub
End Class
