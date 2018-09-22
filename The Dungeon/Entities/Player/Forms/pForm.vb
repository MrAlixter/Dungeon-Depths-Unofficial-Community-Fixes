Public MustInherit Class pForm
    Public h, m, a, d, s, w As Double
    Public name As String
    Public useSleeves As Boolean
    Public revertPassage As String
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

    Overridable Sub revert()
        Dim out = ""
        If Not Game.combatmode Then
            out = revertPassage & vbCrLf & vbCrLf & Game.lblEvent.Text
            If Game.lblEvent.Visible Then Game.lblEvent.Text = out Else Game.pushLblEvent(out)
        Else
            Game.pushLblCombatEvent(revertPassage)
        End If
    End Sub
End Class
