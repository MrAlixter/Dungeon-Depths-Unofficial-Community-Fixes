Public Class MysteryPotion
    Inherits Item
    Dim realName As String
    Sub New()
        MyBase.setName("Mystery_Potion")
        MyBase.setDesc("A mysterios potion who's name hasn't been loaded potion")
        id = Nothing
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 0
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.lstLog.Items.Add("You drink the " & getName())
        If Not MyBase.getName().Equals(realName) Then
            Game.lstLog.Items.Add("The " & getName() & " was actually a " & realName)
            'Dim ind As Integer = Array.IndexOf(Game.HPotionNames, MyBase.getName)
            MyBase.setName(realName)
            'Game.HPotionNames(ind) = realName
        End If
        effect()
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
    Overridable Sub effect()
        Game.lstLog.Items.Add("Not a real number")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Sub setRealName(ByVal s As String)
        realName = s
    End Sub
    Function getRealName()
        Return realName
    End Function
End Class
