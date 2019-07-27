Public Class mTile
    'since the original (not picture) board was made of labels, and the picture board eliminated the need
    'for it to be seen, I've replaced the labels with a smaller data type that uses only the essential
    'portions of the label (the tag, text, and forecolor)
    Public Tag As Integer
    Public Text As String
    Public ForeColor As Color

    'New creates a new instance of a mTile
    Sub New(ByVal t As Integer, ByVal s As String, ByVal c As Color)
        Tag = t
        Text = s
        ForeColor = c
    End Sub
    'dispose removes an old instance of a mTile
    Public Sub Dispose()
        Tag = Nothing
        Text = Nothing
        ForeColor = Nothing
        Me.Finalize()
    End Sub
End Class
