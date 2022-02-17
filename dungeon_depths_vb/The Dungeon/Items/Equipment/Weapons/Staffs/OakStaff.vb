Public Class OakStaff
    Inherits Staff

    Public Const ITEM_NAME As String = "Oak_Staff"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 21
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        m_boost = 15
        a_boost = 4
        count = 0
        value = 125

        '|Description|
        setDesc("A simple oak staff for casing spells." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
