Public Class GreenPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Green_Potion")
        MyBase.setDesc("A curious looking potion")
        id = 27
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 300
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
    End Sub
End Class
