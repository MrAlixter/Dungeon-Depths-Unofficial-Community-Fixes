Public Class MShank
    Inherits Dagger

    Public Const ITEM_NAME As String = "Mugger's_Shank"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 165
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        count = 0
        value = 235
        a_boost = 3
        s_boost = 5

        '|Description|
        setDesc("A well-worn blade small enough to be concealed and drawn at will." & DDUtils.RNRN &
                "When attacking, the user hits twice." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
