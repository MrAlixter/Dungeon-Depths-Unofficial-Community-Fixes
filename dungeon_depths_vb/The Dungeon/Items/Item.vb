Public Class Item
    Implements IComparable
    Dim name As String = ""
    Dim description As String
    Dim isUsable As Boolean = False
    Public count As Integer
    Public value As Integer
    Protected tier As Integer = Nothing
    Public id As Integer = Nothing
    Public isMonsterDrop As Boolean = False
    Public isRandoTFAcceptable = True

    Public saleLim As Integer = 999
    Public onSell As Action = Nothing
    Public onBuy As Action = Nothing
    Public durability As Integer = 100

    Overloads Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
        If Not obj.GetType().IsSubclassOf(GetType(Item)) Or obj Is Nothing OrElse obj.getname Is Nothing OrElse Me.getName Is Nothing Then Return 0

        Return Me.getName.CompareTo(obj.getName.ToString)
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
    Public Overridable Function getTier() As Integer
        Return tier
    End Function
    Public Function getId()
        Return id
    End Function
    Sub setUsable(ByVal b As Boolean)
        isUsable = b
    End Sub
    Overridable Sub use(ByRef p As Player)
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
    Overridable Function damage(ByVal i As Integer) As Boolean
        durability -= i
        If durability <= 0 Then
            break()
            Return True
        End If
        Return False
    End Function
    Overridable Sub break()
            Game.pushLstLog("The " & getName() & " breaks!")
            count -= 1
            durability = 100
    End Sub
    Overridable Sub remove()
        Game.pushLstLog("The " & getName() & " fades into non-existance")
        count -= 1

    End Sub

    Public Sub examine()
        If durability > 99 Then
            Game.pushLblEvent(description)
        Else
            Game.pushLblEvent(description & DDUtils.RNRN & "Durability: " & durability & " (Breaks at 0)")
        End If

    End Sub
    Public Function getDescription()
        Return description
    End Function
    Function getCount()
        Return count
    End Function
End Class
