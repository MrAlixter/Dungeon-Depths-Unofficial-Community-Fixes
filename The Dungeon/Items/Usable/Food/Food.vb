Public Class Food
    Inherits Item
    Dim calories As Integer
    Sub New()
        MyBase.setName("Food")
        MyBase.setDesc("This is invisible.")
        MyBase.setUsable(True)
        MyBase.count = 0
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        If getName() = "Medicinal_Tea" Then Game.pushLstLog("You drink the " & getName()) Else Game.pushLstLog("You eat the " & getName())
        
        Game.player.hunger -= calories
        If Game.player.hunger < 0 Then Game.player.hunger = 0
        Effect()
        count -= 1
    End Sub
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
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
