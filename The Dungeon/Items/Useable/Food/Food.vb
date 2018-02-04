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
        If getName() = "Medicinal_Tea" Then Form1.lstLog.Items.Add("You drink the " & getName()) Else Form1.lstLog.Items.Add("You eat the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        Form1.player.hunger -= calories
        If Form1.player.hunger < 0 Then Form1.player.hunger = 0
        Effect()
        count -= 1
    End Sub
    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
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
