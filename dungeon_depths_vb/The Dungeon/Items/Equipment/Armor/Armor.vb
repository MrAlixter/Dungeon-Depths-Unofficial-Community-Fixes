Public Class Armor
    Inherits EquipmentItem

    '| -- Constructor Layout Example -- |
    '|ID Info|


    '|Item Flags|


    '|Stats|


    '|Image Index|


    '|Description|


    'Armor is an Item subtype that provides a defencive boost, and has artworks for each breast size
    Const MINBSIZE = -2
    Const MAXBSIZE = 7
    Const MINUSIZE = -2
    Const MAXUSIZE = 5

    Protected slut_var_ind As Integer = -1
    Protected anti_slut_ind As Integer = -1
    Public bsizeneg1 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public bsize0 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public bsize1 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public bsize2 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public bsize3 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public bsize4 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public bsize5 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public bsize6 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public bsize7 As Tuple(Of Integer, Boolean, Boolean) = Nothing

    Public bsizeneg2 As Tuple(Of Integer, Boolean, Boolean) = Nothing

    Public usizeneg1 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public usize0 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public usize1 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public usize2 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public usize3 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public usize4 As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public usize5 As Tuple(Of Integer, Boolean, Boolean) = Nothing

    Public usizeneg2 As Tuple(Of Integer, Boolean, Boolean) = Nothing

    Public hood As Tuple(Of Integer, Boolean, Boolean) = Nothing
    Public cloak As Tuple(Of Integer, Boolean, Boolean) = Nothing

    Public compress_breast As Boolean = True
    Public hide_rearhair As Boolean = False
    Public adjust_sleeve_layer As Boolean = True
    Public show_underboob As Boolean = False
    Public hide_dick As Boolean = True
    Public swap_gen_clothesbtm As Boolean = False
    Public bind_wearer As Boolean = False

    Overridable Function getSlutVarInd()
        Return slut_var_ind
    End Function
    Overridable Function getAntiSlutInd()
        Return anti_slut_ind
    End Function

    Public Overridable Function getClothesIMGTop(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
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
    Public Overridable Function getClothesIMGBtm(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
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
    Public Overridable Function getCloak(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
        Return cloak
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
        Return Not getClothesIMGTop(p) Is Nothing AndAlso Not getClothesIMGBtm(p) Is Nothing AndAlso (p.pForm.canBeBound Or Not bind_wearer)
    End Function

    Public Overrides Sub discard()
        If cursed And Not owner Is Nothing AndAlso owner.equippedArmor.getAName.Equals(getAName) Then
            TextEvent.push("You are unable to drop your equipped equipment.")
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
        out += "Fits waist sizes " & minU & " through " & maxU

        Return out
    End Function

    Overrides Sub break()
        Dim p = Game.player1

        TextEvent.pushLog("The " & getName() & " breaks!")

        p.inv.add(id, -1)
        p.inv.item(id).durability = 100

        If Not p Is Nothing Then
            If p.equippedArmor.getAName.Equals(getAName) Then EquipmentDialogBackend.equipArmor(p, "Naked", False)
            p.UIupdate()
        End If
    End Sub
End Class
