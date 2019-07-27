Public Class NewStuff
    Inherits item
    Sub New()
        MyBase.setName("Every_New_Item")
        MyBase.setDesc("This item is for obtaining every new item in the game, and should not be in the base game")
        id = 143
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 0

        MyBase.isRandoTFAcceptable = False
    End Sub
    Public Overrides Sub use()
        Dim p As Player = Game.player

        For i = 87 To 145
            p.inv.add(i, 1)
        Next

        Game.pushLblEvent("Added one of every new item in v0.8!")
        count -= 1
    End Sub
End Class
