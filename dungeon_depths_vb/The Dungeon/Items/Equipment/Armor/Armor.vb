Public Class Armor
    Inherits EquipmentItem

    'Armor is an Item subtype that provides a defencive boost, and has artworks for each breast size
    Const MINBSIZE = -2
    Const MAXBSIZE = 7
    Const MINUSIZE = -2
    Const MAXUSIZE = 5

    Protected slutVarInd As Integer = -1
    Protected antiSlutVarInd As Integer = -1
    Public bsizeneg1 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize0 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize1 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize2 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize3 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize4 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize5 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize6 As Tuple(Of Integer, Boolean, Boolean)
    Public bsize7 As Tuple(Of Integer, Boolean, Boolean)

    Public bsizeneg2 As Tuple(Of Integer, Boolean, Boolean) = Nothing

    Public usizeneg1 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public usize0 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public usize1 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public usize2 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public usize3 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public usize4 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public usize5 As Tuple(Of Integer, Boolean, Boolean) = Nothing

    Public usizeneg2 As Tuple(Of Integer, Boolean, Boolean) = Nothing

    Public compressesBreasts As Boolean
    Public hidesDick As Boolean = True
    Public bindsWearer As Boolean = False

    Overridable Function getSlutVarInd()
        Return slutVarInd
    End Function
    Overridable Function getAntiSlutVarInd()
        Return antiSlutVarInd
    End Function

    Public Function getClothesIMGTop(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
        Select Case p.breastSize
            Case -2
                Return bsizeneg2
            Case -1
                Return bsizeneg1
            Case 0
                If bsize0 Is Nothing Then
                    Return bsizeneg1
                Else
                    Return bsize0
                End If
            Case 1
                Return bsize1
            Case 2
                Return bsize2
            Case 3
                Return bsize3
            Case 4
                Return bsize4
            Case 5
                Return bsize5
            Case 6
                Return bsize6
            Case 7
                Return bsize7
        End Select

        Return Nothing
    End Function
    Public Function getClothesIMGBtm(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
        Select Case p.buttSize
            Case -2
                Return usizeneg2
            Case -1
                Return usizeneg1
            Case 0
                Return usize0
            Case 1
                Return usize1
            Case 2
                Return usize2
            Case 3
                Return usize3
            Case 4
                Return usize4
            Case 5
                Return usize5
        End Select

        Return Nothing
    End Function
    Public Function getClothesIMGTop(ByVal i As Integer) As Tuple(Of Integer, Boolean, Boolean)
        Select Case i
            Case -2
                Return bsizeneg2
            Case -1
                Return bsizeneg1
            Case 0
                If bsize0 Is Nothing Then
                    Return bsizeneg1
                Else
                    Return bsize0
                End If
            Case 1
                Return bsize1
            Case 2
                Return bsize2
            Case 3
                Return bsize3
            Case 4
                Return bsize4
            Case 5
                Return bsize5
            Case 6
                Return bsize6
            Case 7
                Return bsize7
        End Select

        Return Nothing
    End Function
    Public Function getClothesIMGBtm(ByVal i As Integer) As Tuple(Of Integer, Boolean, Boolean)
        Select Case i
            Case -2
                Return usizeneg2
            Case -1
                Return usizeneg1
            Case 0
                Return usize0
            Case 1
                Return usize1
            Case 2
                Return usize2
            Case 3
                Return usize3
            Case 4
                Return usize4
            Case 5
                Return usize5
        End Select

        Return Nothing
    End Function

    Public Function fits(ByRef p As Player)
        Return Not getClothesIMGTop(p) Is Nothing AndAlso Not getClothesIMGBtm(p) Is Nothing
    End Function

    Public Overrides Sub discard()
        If isCursed And Not owner Is Nothing AndAlso owner.equippedArmor.getAName.Equals(getAName) Then
            Game.pushLblEvent("You are unable to drop your equipped equipment.")
        Else
            MyBase.discard()
        End If
    End Sub

    Public Function getSizeInformation() As String
        Dim out = ""

        Dim minB = MINBSIZE
        Dim maxB = MAXBSIZE
        For i = MINBSIZE To MAXBSIZE
            If Not getClothesIMGTop(i) Is Nothing Then minB = i : Exit For
        Next
        For i = MAXBSIZE To MINBSIZE Step -1
            If Not getClothesIMGTop(i) Is Nothing Then maxB = i : Exit For
        Next

        Dim minU = MINUSIZE
        Dim maxU = MAXUSIZE
        For i = MINUSIZE To MAXUSIZE
            If Not getClothesIMGBtm(i) Is Nothing Then minU = i : Exit For
        Next
        For i = MAXUSIZE To MINUSIZE Step -1
            If Not getClothesIMGBtm(i) Is Nothing Then maxU = i : Exit For
        Next

        out += "Fits chest sizes " & minB & " through " & maxB & vbCrLf
        out += "Fits waist sizes " & minU & " through " & maxU & vbCrLf

        Return out
    End Function
End Class
