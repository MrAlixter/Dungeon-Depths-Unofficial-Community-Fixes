Public Class VipersFang
    Inherits Dagger

    Public Const ITEM_NAME As String = "Viper's_Fangs"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 339
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        a_boost = 15
        s_boost = 10
        w_boost = 8
        count = 0
        value = 4340

        '|Description|
        setDesc("A pair of small daggers that can be concealed and drawn incredibly quickly.  The blades glow with a suble green aura." & DDUtils.RNRN &
                "Hits twice" & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
