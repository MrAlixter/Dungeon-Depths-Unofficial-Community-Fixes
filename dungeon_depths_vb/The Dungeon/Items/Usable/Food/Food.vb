Public Class Food
    Inherits Item
    Dim calories As Integer
    Sub New()
        MyBase.setName("Food")
        MyBase.setDesc("This is invisible.")
        MyBase.setUsable(True)
        MyBase.count = 0
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        If getName() = "Medicinal_Tea" Then Game.pushLstLog("You drink the " & getName()) Else Game.pushLstLog("You eat the " & getName())

        p.stamina += calories
        If Game.player1.stamina > 100 Then Game.player1.stamina = 100
        Effect()
        count -= 1
    End Sub
    Overridable Sub Effect()

    End Sub
    Sub setCalories(ByVal i As Integer)
        calories = i
    End Sub
    Function getCalories()
        Return calories
    End Function
End Class
