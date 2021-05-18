Public Class SteelSword
    Inherits Sword

    Sub New()
        '|ID Info|
        setName("Steel_Sword")
        id = 6
        tier = Nothing

        '|Item Flags|
        usable = false

        '|Stats|
        MyBase.a_boost = 17
        count = 0
        value = 235

        '|Description|
        setDesc("A simple sword forged from steel." & DDUtils.RNRN &
                       getStatInformation())
    End Sub
End Class
