Public Class GoldenStaff
    Inherits Staff

    Public Const ITEM_NAME As String = "Golden_Staff"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 41
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        m_boost = 50
        a_boost = 10
        count = 0
        value = 3200

        '|Description|
        setDesc("A glowing runed staff for powerful spellcasters." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
