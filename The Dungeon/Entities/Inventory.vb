Public NotInheritable Class Inventory
    Public items As Dictionary(Of String, Item)

    Public ReadOnly Property Count As Integer
        Get
            Return items.Count
        End Get
    End Property

    Default Property item(i As Integer)
        Get
            Return GetItemByIndex(i)
        End Get
        Set(value)
            If i < items.Count Then
                items(items.ElementAt(i).Key) = value
            End If
        End Set
    End Property

    Default Property item(s As String)
        Get
            Return GetItemByName(s)
        End Get
        Set(value)
            If items.ContainsKey(s) Then
                items(s) = value
            End If
        End Set
    End Property

    Default Property item(i As Item)
        Get
            Return items.Item(i.getName()).value
        End Get
        Set(value)
            If items.ContainsKey(i.getName()) Then
                items(i.getName()) = value
            End If
        End Set
    End Property

    Public Sub New()
        items = New Dictionary(Of String, Item)
    End Sub

    Public Sub Add(i As Item)
        items.Add(i.getName(), i)
    End Sub

    Public Function GetItemByIndex(i As Integer)
        Return items.ElementAt(i)
    End Function

    Public Function GetItemByName(name As String)
        Return items.Item(name).value
    End Function

    Public Function GetItemByName(item As Item)
        Dim name As String = item.getName()
        Return GetItemByName(name)
    End Function

    Public Function GetItemByItem(item As Item)
        Return GetItemByName(item)
        'For Each i As Item In items.Values
        '    If i.GetType() Is item.GetType() Then
        '        Return i
        '    End If
        'Next
    End Function
End Class
