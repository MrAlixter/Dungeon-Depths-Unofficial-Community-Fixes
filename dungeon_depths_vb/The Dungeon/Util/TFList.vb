Public Class TFList
    Dim internalList As Dictionary(Of String, Transformation)
    Sub New()
        reset()
    End Sub

    Sub add(ByRef tf As Transformation)
        If tf Is Nothing Then Exit Sub
        If tf.getTFName Is Nothing Then MsgBox("Error 007: " & tf.GetType.ToString & " transformation missing name field!")
        If Not tf.getTFName Is Nothing AndAlso Not internalList.ContainsKey(tf.getTFName) Then internalList.Add(tf.getTFName(), tf)
    End Sub

    Sub ping(Optional ByRef pUpdateFlag = False)
        For i = internalList.Count - 1 To 0 Step -1
            tf = internalList.Values(i)
            If tf Is Nothing Then Continue For
            If tf.getTFDone Then
                remove(internalList.Keys(i))
            Else
                Dim c = tf.getturnsTilNextStep
                If c = 0 Then pUpdateFlag = True
                Try
                    tf.update()
                Catch ex As Exception
                    MsgBox("Error 008: " & tf.GetType.ToString & " transformation has thrown an unhandled exception!")
                End Try
            End If
        Next
    End Sub

    Sub remove(ByVal s As String)
        If internalList.ContainsKey(s) Then
            internalList(s).stopTF()
            internalList.Remove(s)
        End If
    End Sub

    Sub reset()
        internalList = New Dictionary(Of String, Transformation)
    End Sub

    Sub resetPolymorphs()
        For i = internalList.Count - 1 To 0 Step -1
            tf = internalList.Values(i)
            If tf.GetType().IsSubclassOf(GetType(PolymorphTF)) Then internalList.Remove(tf.getTFName)
        Next
    End Sub

    Function getAt(ByVal s As String) As Transformation
        If Not internalList.Keys.Contains(s) Then Return Nothing

        Return internalList(s)
    End Function

    Function count() As Integer
        Return internalList.Count
    End Function

    Function save() As String
        Dim output = ""
        output += internalList.Count - 1 & "Ͱ"
        For Each tf In internalList
            output += tf.Value.ToString & "Ͱ"
        Next

        Return output
    End Function

    Sub load(ByVal s As String)

    End Sub
End Class
