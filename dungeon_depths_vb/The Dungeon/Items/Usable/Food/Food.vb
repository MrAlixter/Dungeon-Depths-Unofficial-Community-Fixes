Public Class Food
    Inherits Item
    Dim calories As Integer
    Sub New()
        setName("Food")
        setDesc("This is invisible.")
        usable = true
        count = 0
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        If getName() = "Medicinal_Tea" Then TextEvent.pushLog("You drink the " & getName()) Else TextEvent.pushLog("You eat the " & getName())

        p.stamina += calories
        If p.stamina > 100 Then p.stamina = 100
        Effect(p)
        count -= 1
    End Sub
    Overridable Sub effect(ByRef p As Player)

    End Sub
    Sub setCalories(ByVal i As Integer)
        calories = i
    End Sub
    Function getCalories()
        Return calories
    End Function
End Class
