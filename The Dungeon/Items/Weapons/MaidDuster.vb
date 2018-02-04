Public Class MaidDuster
    Inherits Weapon

    Sub New()
        MyBase.setName("Duster")
        MyBase.setDesc("A grey feather duster that looks like you could use for cleaning.")
        MyBase.setUsable(True)
        MyBase.aBoost = 5
        MyBase.count = 0
        MyBase.value = 375
    End Sub

    Overrides Sub use()
        Dim p As Player = Form1.player
        Form4.transform(p, "maid", 0)
    End Sub
End Class
