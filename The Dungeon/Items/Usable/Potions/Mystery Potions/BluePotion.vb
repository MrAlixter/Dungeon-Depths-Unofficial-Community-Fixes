Public Class BluePotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Blue_Potion")
        MyBase.setDesc("A chancy looking potion")
        id = 59
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 300
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
    End Sub
End Class
