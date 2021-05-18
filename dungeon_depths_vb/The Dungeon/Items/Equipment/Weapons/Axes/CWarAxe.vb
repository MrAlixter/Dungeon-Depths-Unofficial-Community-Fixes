Public Class CWarAxe
    Inherits Axe

    Sub New()
        setName("Corse_War_Axe")
        setDesc("A roughly finished, yet sturdy steel axe attached to a  beaten up wooden shaft.  Its uneven constuction, while boosting attack, also decreases speed slightly." & vbCrLf &
                       "+25 ATK, -10 DEF")
        id = 118
        tier = Nothing
        usable = false
        MyBase.a_boost = 25
        MyBase.s_boost = -10
        count = 0
        value = 1000
    End Sub
End Class
