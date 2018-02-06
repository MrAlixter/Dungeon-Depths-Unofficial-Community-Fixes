Public Class WeaknessPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setRealName("Weakness_Potion")
        MyBase.setDesc("An atypical looking potion")
        id = Nothing
        tier = Nothing
        MyBase.value = 250
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Game.player
        p.inventorynames(26) = "Weakness_Potion"
        'weaken all p stats by 10%
    End Sub
End Class
