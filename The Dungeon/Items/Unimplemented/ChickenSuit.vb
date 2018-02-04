Public Class ChickenSuit
    Inherits Armor

    Sub New()
        MyBase.setName("Chicken_Suit")
        MyBase.setDesc("Utterly worthless for combat, this suit makes its wearer look like a bird. -30 DEF")
        MyBase.setUsable(False)
        MyBase.aBoost = -30
        MyBase.count = 0
        MyBase.value = 0
    End Sub

    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
