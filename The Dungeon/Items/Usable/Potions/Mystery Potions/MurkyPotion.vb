Public Class MurkyPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Murky_Potion")
        MyBase.setDesc("A bizzare looking potion")
        id = 60
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 300
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
    End Sub
End Class
