Public Class MaidDuster
    Inherits Weapon

    Sub New()
        MyBase.setName("Duster")
        MyBase.setDesc("A grey feather duster that looks like you could use for cleaning.")
        id = 45
        tier = 3
        MyBase.setUsable(True)
        MyBase.aBoost = 5
        MyBase.count = 0
        MyBase.value = 375
    End Sub

    Overrides Sub use()
        Dim p As Player = Game.player
        p.ongoingTFs.Add(New MaidTF())
        p.update()
    End Sub
End Class
