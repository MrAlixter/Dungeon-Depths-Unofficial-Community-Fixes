Public Class CWarAxe
    Inherits Axe

    Sub New()
        MyBase.setName("Corse_War_Axe")
        MyBase.setDesc("A roughly finished, yet sturdy steel axe attached to a  beaten up wooden shaft.  Its uneven constuction, while boosting attack, also decreases speed slightly." & vbCrLf &
                       "+25 ATK, -10 DEF")
        id = 118
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 25
        MyBase.sBoost = -10
        MyBase.count = 0
        MyBase.value = 1000
    End Sub
End Class
