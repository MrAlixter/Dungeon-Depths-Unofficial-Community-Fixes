Public Class MaidDuster
    Inherits Weapon

    Sub New()
        setName("Duster")
        setDesc("A grey feather duster that looks like you could use for cleaning.")
        id = 45
        tier = 3
        usable = true
        MyBase.a_boost = 5
        count = 0
        value = 375
    End Sub

    Overrides Sub use(ByRef p As Player)
        p.ongoingTFs.Add(New MaidTF())
        p.update()
    End Sub
End Class
