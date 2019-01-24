Public Class AzurePotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Azure_Potion")
        MyBase.setDesc("A vexing looking potion")
        id = 61
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 300
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
    End Sub
End Class
