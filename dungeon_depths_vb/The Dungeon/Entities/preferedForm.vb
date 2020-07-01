Public Class preferedForm
    Public hairColor As Color
    Public skinColor As Color
    Public hasFemaleHair As Boolean
    Public fHairInd, rHairInd As Integer
    Public isFemale As Boolean
    Public breastSize As Integer
    Public isSlut As Boolean
    Public earType As Integer
    Public onComplete As Action

    Public Sub New(ByVal hc As Color, ByVal sc As Color, ByVal fh As Boolean, ByVal f As Boolean, ByVal bs As Integer, ByVal s As Boolean, ByVal et As Integer,
                   Optional fhi As Integer = -1, Optional rhi As Integer = -1, Optional oc As Action = Nothing)
        hairColor = hc
        skinColor = sc
        hasFemaleHair = fh
        If fhi = -1 Then fHairInd = Int(Rnd() * 5) Else fHairInd = fhi
        If rhi = -1 Then rHairInd = Int(Rnd() * 5) Else rHairInd = rhi
        isFemale = f
        breastSize = bs
        isSlut = s
        earType = et
        onComplete = oc
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
        Return p.prt.sexBool = isFemale And p.prt.iArrInd(pInd.rearhair).Item2 = hasFemaleHair And
        p.prt.iArrInd(pInd.rearhair).Item1 = rHairInd And p.prt.iArrInd(pInd.fronthair).Item1 = fHairInd + 1 And
        p.breastSize = breastSize And p.prt.iArrInd(pInd.ears).Item1 = earType And
        ((p.perks(perk.slutcurse) > -1 And isSlut) Or (p.perks(perk.slutcurse) = -1 And Not isSlut))
    End Function

    Public Sub shiftTowards(ByRef p As Player)
        Randomize()
        If Not p.pClass.name.equals("Thrall") Then p.pClass = p.classes(perk.thrall)
        If playerMeetsForm(p) Then Exit Sub

        If Not p.prt.haircolor.Equals(hairColor) Then p.changeHairColor(Game.cShift(p.prt.haircolor, hairColor, 8))
        If Not p.prt.skincolor.Equals(skinColor) Then p.changeSkinColor(Game.cShift(p.prt.skincolor, skinColor, 8))

        If Int(Rnd() * 3) = 0 Then
            p.prt.iArrInd(pInd.rearhair) = New Tuple(Of Integer, Boolean, Boolean)(rHairInd, hasFemaleHair, False)
            p.prt.iArrInd(pInd.midhair) = New Tuple(Of Integer, Boolean, Boolean)(rHairInd, hasFemaleHair, False)
        End If
        If Int(Rnd() * 3) = 0 Then
            p.prt.setIAInd(pInd.fronthair, fHairInd + 1, hasFemaleHair, False)
        End If

        If p.prt.sexBool <> isFemale And Int(Rnd() * 3) = 0 Then
            If p.prt.sexBool Then
                p.FtM()
            Else
                p.MtF()
            End If
        End If

        If p.breastSize > breastSize Then
            p.breastSize -= 1
            p.reverseallroute()
        ElseIf p.breastSize < breastSize Then
            p.breastSize += 1
            p.reverseallroute()
        End If

        If isFemale And ((p.perks(perk.slutcurse) = -1 And isSlut) Or (p.perks(perk.slutcurse) > -1 And Not isSlut)) And Int(Rnd() * 3) = 0 Then
            If (p.perks(perk.slutcurse) = -1 And isSlut) Then
                p.perks(perk.slutcurse) = 0
                Equipment.clothingCurse1(p)
            Else
                p.perks(perk.slutcurse) = -1
                Equipment.antiClothingCurse(p)
            End If
        End If

        If Not p.prt.iArrInd(pInd.ears).Item1 = earType And Int(Rnd() * 3) = 0 Then
            p.prt.setIAInd(pInd.ears, earType, isFemale, False)
        End If

        If p.prt.sexBool Then
            p.prt.setIAInd(pInd.eyes, 19, True, True)
        Else
            p.prt.setIAInd(pInd.eyes, 8, False, True)
        End If

        p.drawPort()
    End Sub
    Public Sub snapShift(ByRef p As Player)
        Randomize()
        If Not p.pClass.name.equals("Thrall") Then p.pClass = p.classes(perk.thrall)
        If playerMeetsForm(p) Then Exit Sub

        p.changeHairColor(hairColor)
        p.changeSkinColor(skinColor)

        p.prt.setIAInd(pInd.rearhair, rHairInd, hasFemaleHair, False)
        p.prt.setIAInd(pInd.midhair, rHairInd, hasFemaleHair, False)

        p.prt.setIAInd(pInd.fronthair, fHairInd + 1, hasFemaleHair, False)

        If p.prt.sexBool <> isFemale Then
            If p.prt.sexBool Then
                p.FtM()
            Else
                p.MtF()
            End If
        End If

        If p.breastSize > breastSize Then
            While p.breastSize > breastSize
                p.breastSize -= 1
                p.reverseallroute()
            End While
        ElseIf p.breastSize < breastSize Then
            While p.breastSize < breastSize
                p.breastSize += 1
                p.reverseallroute()
            End While
        End If

        If isFemale And ((p.perks(perk.slutcurse) = -1 And isSlut) Or (p.perks(perk.slutcurse) > -1 And Not isSlut)) Then
            If (p.perks(perk.slutcurse) = -1 And isSlut) Then
                p.perks(perk.slutcurse) = 0
                Equipment.clothingCurse1(p)
            Else
                p.perks(perk.slutcurse) = -1
                Equipment.antiClothingCurse(p)
            End If
        End If

        If Not p.prt.iArrInd(pInd.ears).Item1 = earType Then
            p.prt.setIAInd(pInd.ears, earType, isFemale, False)
        End If

        If p.prt.sexBool Then
            p.prt.setIAInd(pInd.eyes, 19, True, True)
        Else
            p.prt.setIAInd(pInd.eyes, 8, False, True)
        End If

        If Not onComplete Is Nothing Then onComplete()

        p.drawPort()
    End Sub

    Public Overrides Function ToString() As String
        Return (hairColor.A & "$" & hairColor.R & "$" & hairColor.G & "$" & hairColor.B & "$" &
                skinColor.A & "$" & skinColor.R & "$" & skinColor.G & "$" & skinColor.B & "$" &
                hasFemaleHair & "$" & isFemale & "$" & breastSize & "$" & isSlut & "$" & earType) '& "$" &
        'fHairInd & "$" & rHairInd & "$" & onComplete.ToString)
    End Function
End Class

Public Class SuccMaid
    Inherits preferedForm

    Public Sub New(ByVal hc As Color, ByVal sc As Color, ByVal fh As Boolean, ByVal f As Boolean, ByVal bs As Integer, ByVal s As Boolean, ByVal et As Integer,
               Optional fhi As Integer = -1, Optional rhi As Integer = -1, Optional oc As Action = Nothing)
        hairColor = Color.White
        skinColor = Color.FromArgb(255, 255, 78, 78)
        hasFemaleHair = True
        fHairInd = 26
        rHairInd = 6
        isFemale = True
        breastSize = 2
        isSlut = True
        earType = 0
        onComplete = AddressOf changeEquipment
    End Sub
    Sub New()
        MyBase.New(Color.White, Color.FromArgb(255, 255, 78, 78), True, True, 2, True, 0, 26, 6, AddressOf changeEquipment)
    End Sub

    Shared Sub changeEquipment()
        Dim p = Game.player1

        If p.inv.item("Maid_Lingerie").count < 1 Then p.inv.add("Maid_Lingerie", 1)
        Equipment.clothesChange("Maid_Lingerie")

        p.prt.setIAInd(pInd.eyes, 12, True, True)
        p.prt.setIAInd(pInd.glasses, 2, True, False)
        p.prt.setIAInd(pInd.wings, 2, True, False)
        p.prt.setIAInd(pInd.horns, 3, True, False)

        p.pClass = p.classes("Maid")
        p.pForm = p.forms("Half-Succubus")
    End Sub
End Class
