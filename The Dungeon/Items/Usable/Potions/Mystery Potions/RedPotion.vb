Public Class RedPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Red_Potion")
        MyBase.setDesc("A strange looking potion")
        id = 26
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 300
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
    End Sub
End Class
