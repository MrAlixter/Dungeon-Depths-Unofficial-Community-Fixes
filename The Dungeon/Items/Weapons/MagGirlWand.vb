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
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
