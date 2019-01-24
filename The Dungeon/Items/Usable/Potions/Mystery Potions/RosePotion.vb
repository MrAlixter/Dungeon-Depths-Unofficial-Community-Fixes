Public Class RosePotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Rose_Potion")
        MyBase.setDesc("A off looking potion")
        id = 29
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 300
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
    End Sub
End Class
