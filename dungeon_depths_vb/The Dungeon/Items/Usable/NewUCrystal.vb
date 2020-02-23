Public Class NewUCrystal
    Inherits Item

    Sub New()
        MyBase.setName("New-U_Crystal")
        MyBase.setDesc("A debugging item that lets one do the random transformation.  Use your powers for good, ok?")
        id = 154
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 2

        MyBase.isRandoTFAcceptable = False
    End Sub

    Overrides Sub use()
        Dim p As Player = Game.player
        p.ongoingTFs.Add(New RandoTF())
        p.update()

        p.inv.add(154, 1)
        count -= 1
    End Sub
End Class
