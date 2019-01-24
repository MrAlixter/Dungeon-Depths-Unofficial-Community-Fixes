Public Class GlitteryPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Glittery_Potion")
        MyBase.setDesc("A puzzling looking potion")
        id = 62
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 300
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
    End Sub
End Class
