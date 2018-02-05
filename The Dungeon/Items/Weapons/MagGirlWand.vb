Public Class MagGirlWand
    Inherits Weapon

    Sub New()
        MyBase.setName("Magic_Girl_Wand")
        MyBase.setDesc("A mysterious wand used by a mysterious protector. +10 ATK")
        MyBase.setUsable(False)
        MyBase.aBoost = 10
        MyBase.count = 0
        MyBase.value = 1000
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
