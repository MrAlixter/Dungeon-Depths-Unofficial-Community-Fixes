Public Class MiniBoss
    Inherits Monster

    Shared Function miniBossFactory(ByVal mIndex As Integer) As MiniBoss
        Select mIndex
            Case 1
                Return New Marissa
            Case 2
                Return New Targax
            Case 4
                Return New OEmpress
            Case Else
                Return New ExplorerBoss
        End Select
    End Function
    Public Overrides Sub attackCMD(ByRef target As Entity)
        If isStunned Then
            Game.pushLblEvent(name & " is stunned!")
            Exit Sub
        End If

        MyBase.attackCMD(target)
    End Sub
End Class
