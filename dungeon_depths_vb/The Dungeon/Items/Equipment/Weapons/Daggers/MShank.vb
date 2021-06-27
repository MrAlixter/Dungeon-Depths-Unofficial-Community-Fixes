Public Class MShank
    Inherits Dagger

    Sub New()
        '|ID Info|
        setName("Mugger's_Shank")
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
                getStatInformation() & vbcrlf &
                "Hits twice")

    End Sub
End Class
