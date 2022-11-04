Public MustInherit Class pClass
    Public h, m, a, d, s, w As Double
    Public name As String
    Public revertPassage As String
    Public transformPassage As String
    Public canBeTFed As Boolean = True

    Sub New(hR As Double, aR As Double, mR As Double, dR As Double, sR As Double, wR As Double, n As String)
        h = hR
        m = mR
        a = aR
        d = dR
        s = sR
        w = wR
        name = n
    End Sub

    Overridable Sub revert()
    End Sub

    Overridable Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills As Boolean = True)
    End Sub
    Overridable Sub deLVL(ByVal level As Integer, ByRef p As Player)
    End Sub
End Class
