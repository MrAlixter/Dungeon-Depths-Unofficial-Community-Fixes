Public Class WeaknessPotion
    Inherits Potion
    Sub New()
        MyBase.setRealName("Weakness_Potion")
        MyBase.setDesc("An atypical looking potion")
        MyBase.value = 250
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Form1.player
        p.inventorynames(26) = "Weakness_Potion"
        'weaken all p stats by 10%
    End Sub
End Class
