Public Class BronzeAxe
    Inherits Axe

    Sub New()
        setName("Bronze_Battle_Axe")
        setDesc("A curved, double-headed bronze axe with a simple wooden handle.  Some might call this a ""Labrys""." & vbCrLf &
                       "+12 ATK")
        id = 84
        tier = Nothing
        usable = false
        MyBase.a_boost = 12
        count = 0
        value = 235
    End Sub
End Class
