Public Class Item
    Implements IComparable

    '| -- Constructor Layout Example -- |
    '|ID Info|


    '|Item Flags|


    '|Stats|


    '|Description|


    Dim name As String = ""
    Dim description As String
    Public usable As Boolean = False
    Public count As Integer
    Public value As Integer
    Protected tier As Integer = Nothing
    Public id As Integer = -1
    Public droppable As Boolean = False
    Public rando_inv_allowed = True
    Public can_be_stolen As Boolean = True

    Public saleLim As Integer = 999
    Public onSell As Action = Nothing
    Public onBuy As Action = Nothing
    Public durability As Integer = 100

    '| -- Comparable -- |
    Overloads Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
        If Not obj.GetType().IsSubclassOf(GetType(Item)) Or obj Is Nothing OrElse obj.getname Is Nothing OrElse Me.getName Is Nothing Then Return 0

        Return Me.getName.CompareTo(obj.getName.ToString)
    End Function

    '| -- Getters/Setters -- |
    Overridable Function getName() As String
        Return name
    End Function
    Function getAName() As String
        Return name
    End Function
    Sub setName(ByVal s As String)
        name = s
    End Sub
    Public Overridable Function getDesc()
        Return description
    End Function
    Sub setDesc(ByVal s As String)
        description = s
    End Sub
    Public Function getUsable()
        Return usable
    End Function
    Public Overridable Function getTier() As Integer
        Return tier
    End Function
    Public Function getId()
        Return id
    End Function
    Public Function getDescription()
        Return description
    End Function
    Function getCount()
        Return count
    End Function

    '| -- Inventory -- |
    Sub addOne()
        count += 1
    End Sub
    Overridable Sub add(ByVal i As Integer)
        count += i
    End Sub
    Overridable Sub discard()
        TextEvent.pushLog("You drop the " & getName())
        count -= 1
    End Sub
    Overridable Sub remove()
        TextEvent.pushLog("The " & getName() & " fades into non-existance")
        count -= 1

    End Sub

    '| -- Player Interaction -- |
    Overridable Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You use the " & getName())
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
        TextEvent.pushLog("The " & getName() & " breaks!")
        count -= 1
        durability = 100
    End Sub

    '| -- Misc. -- |
    Public Sub examine()
        If durability > 99 Then
            TextEvent.push(getDesc())
        Else
            TextEvent.push(getDesc() & DDUtils.RNRN & "Durability: " & durability & " (Breaks at 0)")
        End If

    End Sub
End Class
