Public Class ScepterOfAsh
    Inherits Staff

    Public Const ITEM_NAME As String = "Scepter_of_Ash"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 145
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        a_boost = 12
        m_boost = 42
        w_boost = 12
        count = 0
        value = 2567

        '|Description|
        setDesc("A polished staff of a light wood capped off by a gistening, vaugly woman shaped red gem.  While the ""Ash"" portion of its name might refer to the type of wood that its made of, it could also refer to the immense magical power it bears." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
