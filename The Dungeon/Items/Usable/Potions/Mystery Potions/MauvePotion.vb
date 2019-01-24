Public Class MauvePotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Mauve_Potion")
        MyBase.setDesc("A funny looking potion")
        id = 28
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 300
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
    End Sub
End Class
