Public Class Potion
    Inherits Item
    Dim realName As String
    Sub New()
        MyBase.setName("Mystery_Potion")
        MyBase.setDesc("A mysterios potion who's name hasn't been loaded potion")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 0
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Form1.lstLog.Items.Add("You drink the " & getName())
        If Not MyBase.getName().Equals(realName) Then
            Form1.lstLog.Items.Add("The " & getName() & " was actually a " & realName)
            Dim ind As Integer = Array.IndexOf(Form1.HPotionNames, MyBase.getName)
            MyBase.setName(realName)
            Form1.HPotionNames(ind) = realName
        End If
        effect()
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
    Overridable Sub effect()
        Form1.lstLog.Items.Add("Not a real number")
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
    End Sub
    Sub setRealName(ByVal s As String)
        realName = s
    End Sub
End Class
