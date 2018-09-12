Public Class pMorph
    Inherits Transformation
    Dim turnsRemaining As Integer
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean, tr As Integer)
        MyBase.New(n, tts, wi, cbs)
        turnsRemaining = tr
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tr As Integer)
        MyBase.New(cs, n, tts, wi, cbs)
        turnsRemaining = tr
    End Sub

    Overridable Sub revert()

    End Sub
    Overridable Sub transform()

    End Sub

End Class
