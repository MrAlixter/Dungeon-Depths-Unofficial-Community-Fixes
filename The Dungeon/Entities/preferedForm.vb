Public Class preferedForm
    Public hairColor As Color
    Public skinColor As Color
    Public hasFemaleHair As Boolean
    Public fHairInd, rHairInd As Integer
    Public isFemale As Boolean
    Public breastSize As Integer
    Public isSlut As Boolean
    Public earType As Integer

    Public Sub New(ByVal hc As Color, ByVal sc As Color, ByVal fh As Boolean, ByVal f As Boolean, ByVal bs As Integer, ByVal s As Boolean, ByVal et As Integer)
        hairColor = hc
        skinColor = sc
        hasFemaleHair = fh
        fHairInd = Int(Rnd() * 5)
        rHairInd = Int(Rnd() * 5)
        isFemale = f
        breastSize = bs
        isSlut = s
        earType = et
    End Sub
    Public Sub New()
        hairColor = Color.FromArgb(255, Int(Rnd() * 125) + 100, Int(Rnd() * 125) + 100, Int(Rnd() * 125) + 100)

        Dim r1 As Integer = Int(Rnd() * 6)
        Select Case r1
            Case 0
                skinColor = (Color.AntiqueWhite)
            Case 1
                skinColor = (Color.FromArgb(255, 247, 219, 195))
            Case 2
                skinColor = (Color.FromArgb(255, 240, 184, 160))
            Case 3
                skinColor = (Color.FromArgb(255, 210, 161, 140))
            Case 4
                skinColor = (Color.FromArgb(255, 180, 138, 120))
            Case 5
                skinColor = (Color.FromArgb(255, 228, 241, 255))
            Case 6
                skinColor = (Color.FromArgb(255, 184, 218, 245))
            Case 7
                skinColor = (Color.FromArgb(255, 235, 187, 198))
            Case Else
                skinColor = (Color.FromArgb(255, 105, 80, 70))
        End Select

        If Int(Rnd() * 2) = 0 Then
            hasFemaleHair = True
        Else
            hasFemaleHair = False
        End If

        If Int(Rnd() * 2) = 0 Then
            isFemale = True
        Else
            isFemale = False
        End If

        breastSize = Int(Rnd() * 5)
        If breastSize = 0 Then breastSize = -1

        If Int(Rnd() * 2) = 0 Then
            isSlut = True
        Else
            isSlut = False
        End If

        earType = Int(Rnd() * 5)
    End Sub

    Public Function playerMeetsForm(ByRef p As Player)
        Return p.haircolor.Equals(hairColor) And p.skincolor.Equals(skinColor) And
               p.sexBool = isFemale And p.iArrInd(1).Item2 = hasFemaleHair And
               p.iArrInd(1).Item1 = rHairInd And p.iArrInd(15).Item1 = fHairInd + 1 And
               p.breastSize = breastSize And p.iArrInd(6).Item1 = earType And
               ((p.perks("slutcurse") > -1 And isSlut) Or (p.perks("slutcurse") = -1 And Not isSlut))
    End Function

    Public Sub shiftTowards(ByRef p As Player)
        Randomize()
        If playerMeetsForm(p) Then Exit Sub

        If Not p.haircolor.Equals(hairColor) Then p.changeHairColor(Game.cShift(p.haircolor, hairColor, 8))
        If Not p.skincolor.Equals(skinColor) Then p.changeSkinColor(Game.cShift(p.skincolor, skinColor, 8))

        If Not p.iArrInd(1).Item2 = hasFemaleHair And Int(Rnd() * 3) = 0 Then
            p.iArrInd(1) = New Tuple(Of Integer, Boolean)(rHairInd, hasFemaleHair)
            p.iArrInd(5) = New Tuple(Of Integer, Boolean)(rHairInd, hasFemaleHair)
        End If
        If Not p.iArrInd(15).Item2 = hasFemaleHair And Int(Rnd() * 3) = 0 Then
            p.iArrInd(15) = New Tuple(Of Integer, Boolean)(fHairInd + 1, hasFemaleHair)
        End If

        If p.sexBool <> isFemale And Int(Rnd() * 3) = 0 Then
            If p.sexBool Then
                p.FtM()
            Else
                p.MtF()
            End If
        End If

        If p.breastSize > breastSize Then
            p.bs()
        ElseIf p.breastSize < breastSize Then
            p.be()
        End If

        If isFemale And ((p.perks("slutcurse") = -1 And isSlut) Or (p.perks("slutcurse") > -1 And Not isSlut)) And Int(Rnd() * 3) = 0 Then
            If (p.perks("slutcurse") = -1 And isSlut) Then
                p.perks("slutcurse") = 0
                Equipment.clothingCurse1()
            Else
                p.perks("slutcurse") = -1
                Equipment.antiClothingCurse()
            End If
        End If

        If Not p.iArrInd(6).Item1 = earType And Int(Rnd() * 3) = 0 Then
            p.iArrInd(6) = New Tuple(Of Integer, Boolean)(earType, isFemale)
        End If

        Equipment.portraitUDate()
    End Sub
    Public Sub snapShift(ByRef p As Player)
        Randomize()
        If playerMeetsForm(p) Then Exit Sub

        p.changeHairColor(hairColor)
        p.changeSkinColor(skinColor)

        p.iArrInd(1) = New Tuple(Of Integer, Boolean)(rHairInd, hasFemaleHair)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean)(rHairInd, hasFemaleHair)

        p.iArrInd(15) = New Tuple(Of Integer, Boolean)(fHairInd + 1, hasFemaleHair)

        If p.sexBool <> isFemale Then
            If p.sexBool Then
                p.FtM()
            Else
                p.MtF()
            End If
        End If

        If p.breastSize > breastSize Then
            While p.breastSize > breastSize
                p.bs()
            End While
        ElseIf p.breastSize < breastSize Then
            While p.breastSize < breastSize
                p.be()
            End While
        End If

        If isFemale And ((p.perks("slutcurse") = -1 And isSlut) Or (p.perks("slutcurse") > -1 And Not isSlut)) Then
            If (p.perks("slutcurse") = -1 And isSlut) Then
                p.perks("slutcurse") = 0
                Equipment.clothingCurse1()
            Else
                p.perks("slutcurse") = -1
                Equipment.antiClothingCurse()
            End If
        End If

        If Not p.iArrInd(6).Item1 = earType Then
            p.iArrInd(6) = New Tuple(Of Integer, Boolean)(earType, isFemale)
        End If

        Equipment.portraitUDate()
    End Sub

    Public Overrides Function ToString() As String
        Return (hairColor.A & "$" & hairColor.R & "$" & hairColor.G & "$" & hairColor.B & "$" & _
                skinColor.A & "$" & skinColor.R & "$" & skinColor.G & "$" & skinColor.B & "$" & _
                hasFemaleHair & "$" & isFemale & "$" & breastSize & "$" & isSlut & "$" & earType)
    End Function
End Class
