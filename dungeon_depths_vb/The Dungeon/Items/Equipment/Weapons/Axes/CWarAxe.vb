Public Class CWarAxe
    Inherits Axe

    Sub New()
        '|ID Info|
        setName("Corse_War_Axe")
        id = 118
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        a_boost = 25
        s_boost = -10
        count = 0
        value = 1000

        '|Description|
        setDesc("A roughly finished, yet sturdy steel axe attached to a  beaten up wooden shaft.  Its uneven constuction, while boosting attack, also decreases speed slightly." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
