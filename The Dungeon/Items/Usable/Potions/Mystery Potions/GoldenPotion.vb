Public Class GoldenPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Golden_Potion")
        MyBase.setDesc("A weird looking potion")
        id = 25
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 300
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
    End Sub
End Class
