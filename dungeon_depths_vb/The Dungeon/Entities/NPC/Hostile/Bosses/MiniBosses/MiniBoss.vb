Public Class MiniBoss
    Inherits Monster

    Sub New()
        name = "Explorer"
        setInventory({})
        setupMonsterOnSpawn()
    End Sub

    Shared Function miniBossFactory(ByVal mIndex As Integer) As MiniBoss
        Select mIndex
            Case 1
                Return New Marissa
            Case 2
                Return New Targax
            Case 4
                Return New OEmpress
            Case 7
                Return New SevenTails
            Case Else
                Return New ExplorerBoss
        End Select
    End Function
    Public Overrides Sub attackCMD(ByRef target As Entity)
        If isStunned Then
            TextEvent.push(name & " is stunned!")
            Exit Sub
        End If

        MyBase.attackCMD(target)
    End Sub
End Class
