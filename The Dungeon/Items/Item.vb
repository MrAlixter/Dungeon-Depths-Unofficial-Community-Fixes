Public Class Item
    Dim name As String = ""
    Dim description As String
    Dim isUsable As Boolean
    Public count As Integer
    Public value As Integer

    'getters/setters
    Function getName()
        Return name
    End Function
    Sub setName(ByVal s As String)
        name = s
    End Sub
    Function getDesc()
        Return description
    End Function
    Sub setDesc(ByVal s As String)
        description = s
    End Sub
    Public Function getUsable()
        Return isUsable
    End Function
    Sub setUsable(ByVal b As Boolean)
        isUsable = b
    End Sub
    Overridable Sub use()
        If Me.getUsable() = False Then Exit Sub
        Form1.lstLog.Items.Add("You use the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
    End Sub
    Sub addOne()
        count += 1
    End Sub
    Overridable Sub add(ByVal i As Integer)
        count += i
    End Sub
    Overridable Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
    End Sub
    Overridable Sub remove()
        Form1.lstLog.Items.Add("The " & getName() & " fades into non-existance")
        count -= 1
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
    End Sub
    Overridable Sub sell(ByVal n As Integer)
        If Form1.currNPC.gold >= (value / 2) * n Then
            Form1.player.gold += (value / 2) * n
            Form1.currNPC.gold -= (value / 2) * n
            count -= n
        Else
            Form1.lstLog.Items.Add("The shopkeeper doesn't have the money!")
        End If
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
    End Sub
    Public Sub examine()
        Form1.pushLblEvent(description)
    End Sub
    Function getCount()
        Return count
    End Function
End Class
