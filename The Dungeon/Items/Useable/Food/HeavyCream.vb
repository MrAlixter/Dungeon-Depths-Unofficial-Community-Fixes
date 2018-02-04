Public Class HeavyCream
    Inherits Food

    Sub New()
        MyBase.setName("Heavy_Cream")
        MyBase.setDesc("An increadibly heavy cream that probably isn't the best for you. -30 Hunger")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 265
        setCalories(30)
    End Sub
    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Form1.lstLog.Items.Add("You drink the " & getName())
        Form1.player.hunger -= getCalories()
        If Form1.player.hunger < 0 Then Form1.player.hunger = 0
        Effect()
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
    Public Overrides Sub Effect()
        Dim r As Integer = Int(Rnd() * 3)
        If r = 0 Then Form1.player.be()
        If Not Form1.player.perks(5) Or Not Form1.player.title.Equals("Magic Girl") Then
            Form1.player.pState.save(Form1.player)
        End If
    End Sub
End Class
