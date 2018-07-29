Public Class pForm
    Public h, m, a, d, s, w As Double
    Public name As String
    Public useSleeves As Boolean
    Sub New(hR As Double, aR As Double, mR As Double, dR As Double, sR As Double, wR As Double, n As String, us As Boolean)
        h = hR
        m = mR
        a = aR
        d = dR
        s = sR
        w = wR
        useSleeves = us
        name = n
    End Sub
End Class
