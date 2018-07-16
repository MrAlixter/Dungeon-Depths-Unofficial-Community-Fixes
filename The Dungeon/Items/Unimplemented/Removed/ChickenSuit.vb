Public Class ChickenSuit
    Inherits Armor

    Sub New()
        MyBase.setName("Chicken_Suit")
        MyBase.setDesc("Utterly worthless for combat, this suit makes its wearer look like a bird. -30 DEF")
        id = 8
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = -30
        MyBase.count = 0
        MyBase.value = 0
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
