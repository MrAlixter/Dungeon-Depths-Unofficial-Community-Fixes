Public Class Item
    Implements IComparable
    Dim name As String = ""
    Dim description As String
    Dim isUsable As Boolean
    Public count As Integer
    Public value As Integer
    Public tier As Integer = Nothing
    Public id As Integer = Nothing

    Overloads Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
        If obj.GetHashCode < Me.GetHashCode Then
            Return obj.GetHashCode / Me.GetHashCode
        Else
            Return -1 * (Me.GetHashCode / obj.GetHashCode)
        End If
    End Function
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
    Public Function getTier()
        Return tier
    End Function
    Public Function getId()
        Return id
    End Function
    Sub setUsable(ByVal b As Boolean)
        isUsable = b
    End Sub
    Overridable Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.lstLog.Items.Add("You use the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Sub addOne()
        count += 1
    End Sub
    Overridable Sub add(ByVal i As Integer)
        count += i
    End Sub
    Overridable Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
    End Sub
    Overridable Sub remove()
        Game.lstLog.Items.Add("The " & getName() & " fades into non-existance")
        count -= 1
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Overridable Sub sell(ByVal n As Integer)
        If Game.currNPC.gold >= (value / 2) * n Then
            Game.player.gold += (value / 2) * n
            Game.currNPC.gold -= (value / 2) * n
            count -= n
        Else
            Game.lstLog.Items.Add("The shopkeeper doesn't have the money!")
        End If
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Public Sub examine()
        Game.pushLblEvent(description)
    End Sub
    Function getCount()
        Return count
    End Function
End Class
