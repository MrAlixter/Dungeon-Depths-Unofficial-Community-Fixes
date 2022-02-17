Public Class PlatinumStaff
    Inherits Staff

    Public Const ITEM_NAME As String = "Platinum_Staff"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 257
        tier = Nothing

        '|Item Flags|
        usable = false
        droppable = False

        '|Stats|
        m_boost = 70
        a_boost = 2
        count = 0
        value = 5000

        '|Description|
        setDesc("A glistening, jeweled staff crafted for supreme spellcasters." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
