Public Class EveryNewItem
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
    Public Overrides Sub use(ByRef p As Player)
        For i = 193 To 250
            p.inv.add(i, 1)
        Next

        Game.pushLblEvent("Added one of every new item in v10.X.X!")
        count -= 1
    End Sub
End Class
