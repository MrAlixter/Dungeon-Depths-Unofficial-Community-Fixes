Public Class ShrinkPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setRealName("Shrink_Potion")
        MyBase.setDesc("An uncanny looking potion")
        id = Nothing
        tier = Nothing
        MyBase.value = 250
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Game.player
        p.inventorynames(26) = "Shrink_Potion"
        'shrink tf here (1/10 stats, 10x evade)
    End Sub
End Class
