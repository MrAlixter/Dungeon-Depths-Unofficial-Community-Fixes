Public MustInherit Class pForm
    Public h, m, a, d, s, w As Double
    Public name As String
    Public useSleeves As Boolean
    Public canBeBound As Boolean = True
    Public revertPassage As String

    Public bsizeneg2 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Public bsizeneg1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Public bsize0 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(1, False, False)
    Public bsize1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(2, True, False)
    Public bsize2 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(3, True, False)
    Public bsize3 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(4, True, False)
    Public bsize4 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(5, True, False)
    Public bsize5 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(6, True, False)
    Public bsize6 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(7, True, False)
    Public bsize7 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(8, True, False)

    Protected overlayshouldersneg1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Protected overlayshoulders0 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Protected overlayshoulders1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)

    Protected overlaybsizeneg1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Protected overlaybsize0 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Protected overlaybsize1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Protected overlaybsize2 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Protected overlaybsize3 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Protected overlaybsize4 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Protected overlaybsize5 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Protected overlaybsize6 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Protected overlaybsize7 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)

    Protected overlaybsize1C As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Protected overlaybsize2C As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Protected overlaybsize3C As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Protected overlaybsize4C As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Protected overlaybsize5C As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Protected overlaybsize6C As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Protected overlaybsize7C As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)

    Protected overlayusizeneg1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Protected overlayusize0 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Protected overlayusize1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Protected overlayusize2 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Protected overlayusize3 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Protected overlayusize4 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Protected overlayusize5 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)

    Protected overlayface As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)

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
    End Sub

    Overridable Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills As Boolean = True)
    End Sub
    Overridable Sub deLVL(ByVal toLevel As Integer, ByRef p As Player)
    End Sub

    Overridable Function getOverlayF(ByVal p As Player) As Tuple(Of Integer, Boolean, Boolean)
        Return overlayface
    End Function
    Overridable Function getOverlayB(ByVal p As Player) As Tuple(Of Integer, Boolean, Boolean)
        If p.equippedArmor.compressesBreasts Then
            Select Case p.breastSize
                Case 1
                    Return overlaybsize1C
                Case 2
                    Return overlaybsize2C
                Case 3
                    Return overlaybsize3C
                Case 4
                    Return overlaybsize4C
                Case 5
                    Return overlaybsize5C
                Case 6
                    Return overlaybsize6C
                Case 7
                    Return overlaybsize7C
            End Select
        Else
            Select Case p.breastSize
                Case -1
                    Return overlaybsizeneg1
                Case 0
                    Return overlaybsize0
                Case 1
                    Return overlaybsize1
                Case 2
                    Return overlaybsize2
                Case 3
                    Return overlaybsize3
                Case 4
                    Return overlaybsize4
                Case 5
                    Return overlaybsize5
                Case 6
                    Return overlaybsize6
                Case 7
                    Return overlaybsize7
            End Select
        End If

        Return New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    End Function
    Overridable Function getOverlayS(ByVal p As Player) As Tuple(Of Integer, Boolean, Boolean)
        Select Case p.breastSize
            Case -1
                Return overlayshouldersneg1
            Case 0
                Return overlayshoulders0
            Case 1, 2, 3, 4, 5, 6, 7
                Return overlayshoulders1
            Case Else
                Return New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        End Select
    End Function
    Overridable Function getOverlayU(ByVal p As Player) As Tuple(Of Integer, Boolean, Boolean)
        Select Case p.buttSize
            Case -1
                Return overlayusizeneg1
            Case 0
                Return overlayusize0
            Case 1
                Return overlayusize1
            Case 2
                Return overlayusize2
            Case 3
                Return overlayusize3
            Case 4
                Return overlayusize4
            Case 5
                Return overlayusize5
            Case Else
                Return New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        End Select
    End Function
End Class
