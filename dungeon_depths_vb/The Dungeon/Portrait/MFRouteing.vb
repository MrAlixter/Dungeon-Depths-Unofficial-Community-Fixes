Public Class MFRouting
    Dim mInds As List(Of Integer)
    Dim fInds As List(Of Integer)

    Sub New(ByVal m As Integer(), ByVal f As Integer())
        mInds = New List(Of Integer)(m)
        fInds = New List(Of Integer)(f)
    End Sub

    Public Function getMfromF(ByVal f As Integer) As Integer
        Dim i = fInds.IndexOf(f)

        If i >= 0 And i < mInds.Count Then Return mInds(i)
        Return -1
    End Function
    Public Function getFfromM(ByVal m As Integer) As Integer
        Dim i = mInds.IndexOf(m)

        If i >= 0 And i < fInds.Count Then Return fInds(i)
        Return -1
    End Function
End Class
