Public Class PlatinumAxe
    Inherits Axe

    Sub New()
        '|ID Info|
        setName("Platinum_Axe")
        id = 255
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.droppable = False

        '|Stats|
        count = 0
        value = 5000
        MyBase.a_boost = 45
        MyBase.s_boost = -2

        '|Description|
        setDesc("A glistening, jeweled axe forged for superb slashers." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
