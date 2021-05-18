Public Class PlatinumStaff
    Inherits Staff

    Sub New()
        '|ID Info|
        setName("Platinum_Staff")
        id = 257
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.droppable = False

        '|Stats|
        count = 0
        value = 5000
        MyBase.m_boost = 70
        MyBase.a_boost = 2


        '|Description|
        setDesc("A glistening, jeweled staff crafted for supreme spellcasters." & DDUtils.RNRN &
                        getStatInformation())
    End Sub
End Class
