Public Class GoldSword
    Inherits Sword

    Sub New()
        '|ID Info|
        MyBase.setName("Gold_Sword")
        id = 40
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)

        '|Stats|
        MyBase.aBoost = 35
        MyBase.count = 0
        MyBase.value = 3200

        '|Description|
        MyBase.setDesc("A shiny sword forged from a gold alloy." & DDUtils.RNRN &
                       getStatInformation())
    End Sub
End Class
