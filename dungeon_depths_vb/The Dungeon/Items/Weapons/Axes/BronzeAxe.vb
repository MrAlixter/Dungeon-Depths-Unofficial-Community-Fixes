Public Class BronzeAxe
    Inherits Axe

    Sub New()
        MyBase.setName("Bronze_Battle_Axe")
        MyBase.setDesc("A curved, double-headed bronze axe with a simple wooden handle.  Some might call this a ""Labrys""." & vbCrLf &
                       "+12 ATK")
        id = 84
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 12
        MyBase.count = 0
        MyBase.value = 235
    End Sub
End Class
