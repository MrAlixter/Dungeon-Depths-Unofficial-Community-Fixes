Public Class Item
    Implements IComparable
    Dim name As String = ""
    Dim description As String
    Dim isUsable As Boolean = False
    Public count As Integer
    Public value As Integer
    Public tier As Integer = Nothing
    Public id As Integer = Nothing
    Public isMonsterDrop As Boolean = False

    Public saleLim As Integer = 999
    Public onSell As Action = Nothing
    Public onBuy As Action = Nothing

    Overloads Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
        Dim r As Integer
        Try
            r = Me.getName.CompareTo(obj.getName.ToString)
        Catch ex As Exception
            r = 0
        End Try
        Return r
    End Function
    'getters/setters
    Overridable Function getName() As String
        Return name
    End Function
    Function getAName() As String
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
        Game.pushLstLog("You use the " & getName())

    End Sub
    Sub addOne()
        count += 1
    End Sub
    Overridable Sub add(ByVal i As Integer)
        count += i
    End Sub
    Overridable Sub discard()
        Game.pushLstLog("You drop the " & getName())
        count -= 1
    End Sub
    Overridable Sub remove()
        Game.pushLstLog("The " & getName() & " fades into non-existance")
        count -= 1

    End Sub

    Public Sub examine()
        Game.pushLblEvent(description)
    End Sub
    Public Function getDescription()
        Return description
    End Function
    Function getCount()
        Return count
    End Function
End Class
