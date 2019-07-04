Public Class Portrait
    Dim ent As Entity
    Public iArr(16) As Image
    Public iArrInd(16) As Tuple(Of Integer, Boolean, Boolean)
    Public haircolor As Color = Color.FromArgb(255, 204, 203, 213)
    Public skincolor As Color = Color.FromArgb(255, 247, 219, 195)
    Public wingInd = 0
    Public hornInd = 0
    Public Shared imgLib As ImageCollection = New ImageCollection(1)
    Public Shared nullImg As Image = imgLib.atrs("Clothes").getAt(New Tuple(Of Integer, Boolean, Boolean)(5, False, True))
    Dim sInts() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0} 'the starting indexes of each catagory

    Sub New(ByVal sex As Boolean, ByRef e As Entity)
        Dim defInd0 = New Tuple(Of Integer, Boolean, Boolean)(0, sex, False)
        Dim defInd1 = New Tuple(Of Integer, Boolean, Boolean)(1, sex, False)
        iArr(0) = imgLib.atrs("bkg").getAt(defInd0)
        iArr(1) = imgLib.atrs("RearHair2").getAt(defInd0)
        iArr(2) = imgLib.atrs("Body").getAt(defInd0)
        iArr(3) = imgLib.atrs("Clothes").getAt(defInd0)
        iArr(4) = imgLib.atrs("Face").getAt(defInd0)
        iArr(5) = imgLib.atrs("RearHair1").getAt(defInd0)
        iArr(6) = imgLib.atrs("Ears").getAt(defInd0)
        iArr(7) = imgLib.atrs("Nose").getAt(defInd0)
        iArr(8) = imgLib.atrs("Mouth").getAt(defInd0)
        iArr(9) = imgLib.atrs("Eyes").getAt(defInd0)
        iArr(10) = imgLib.atrs("Eyebrows").getAt(defInd0)
        iArr(11) = nullImg
        iArr(12) = nullImg
        iArr(13) = nullImg
        iArr(14) = nullImg
        iArr(15) = imgLib.atrs("FrontHair").getAt(defInd1)
        iArr(16) = nullImg

        For i = 0 To 16
            iArrInd(i) = New Tuple(Of Integer, Boolean, Boolean)(sInts(i), sex, False)
        Next

        ent = e
    End Sub
    Shared Sub init()
        imgLib = New ImageCollection(1)
        nullImg = imgLib.atrs("Clothes").getAt(New Tuple(Of Integer, Boolean, Boolean)(5, False, True))
    End Sub
    'converts an array of images into a .bmp image
    Shared Function CreateBMP(ByRef img() As Image) As Bitmap
        Dim bmp As New Bitmap(146, 216)
        Dim g As Graphics = Graphics.FromImage(bmp)
        If img(0).Size.Height <> 144 Then g.DrawImage(img(0), 0, 0, 146, 216) Else g.DrawImage(img(0), 0, 0, 144, 144)
        For i = 1 To UBound(img)
            If img(i) Is Nothing Then img(i) = CharacterGenerator.picPort.Image
            If img(i).Size.Height <= 144 Then g.DrawImage(img(i), 1, 1, 144, 144) Else g.DrawImage(img(i), 1, 1, 144, 216)
        Next
        Return bmp
    End Function
    'exports the current assembled portrait as a .bmp image
    Public Function ExportIMG() As Image
        Dim bmp As New Bitmap(146, 216)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.DrawImage(iArr(0), 0, 0, 146, 216)
        For i = 1 To UBound(iArr)
            g.DrawImage(iArr(i), 1, 1)
        Next
        Return bmp
    End Function

    Function oneLayerImgCheck(ByVal pForm As String, ByVal pClass As String) As Image
        If pForm.Equals("Dragon") Then
            Game.picPortrait.BackgroundImage = CreateBMP({Game.picDragon.BackgroundImage})
            Return Game.picPortrait.BackgroundImage
        ElseIf pClass.Equals("Magic Girl​") Then
            Game.picPortrait.BackgroundImage = CreateBMP({Game.picmgp1.BackgroundImage})
            Return Game.picPortrait.BackgroundImage
        ElseIf pForm.Equals("Sheep") Then
            Game.picPortrait.BackgroundImage = CreateBMP({Game.picSheep.BackgroundImage})
            Return Game.picPortrait.BackgroundImage
        ElseIf pForm.Equals("Cake") Then
            Game.picPortrait.BackgroundImage = CreateBMP({Game.picCake.BackgroundImage})
            Return Game.picPortrait.BackgroundImage
        ElseIf pForm.Equals("Frog") Then
            Game.picPortrait.BackgroundImage = CreateBMP({Game.picFrog.BackgroundImage})
            Return Game.picPortrait.BackgroundImage
        ElseIf pClass.Equals("Princess​") Then
            Game.picPortrait.BackgroundImage = CreateBMP({Game.picPrin.BackgroundImage})
            Return Game.picPortrait.BackgroundImage
        ElseIf pClass.Equals("Bunny Girl​") Then
            Game.picPortrait.BackgroundImage = CreateBMP({Game.picBun.BackgroundImage})
            Return Game.picPortrait.BackgroundImage
        End If
        Return Nothing
    End Function
    Public Function draw()
        portraitUDate()
        If ent Is Nothing Then
            Select Case sexBool()
                Case False
                    setIAInd(2, 0, False, False)
                Case True
                    setIAInd(2, 5, True, True)
            End Select
        End If

        For i = 0 To 16
            Try
                iArr(i) = imgLib.atrs(imgLib.atrs.Keys(i)).getAt(iArrInd(i))
            Catch ex As Exception
                MsgBox("Error!  Exception thrown in portrait creation (specifically in the " & imgLib.atrs.Keys(i) & " layer).  The player character will now revert to default.")
            End Try
        Next

        changeHairColor(haircolor)
        changeSkinColor(skincolor)

        hideEars()

        If Not ent Is Nothing AndAlso ent.lust > 0 Then lustBlushUpdate()
        If wingInd > 0 Then addWings(wingInd)
        If hornInd > 0 Then addHorns(hornInd)

        Return CreateBMP(iArr)
    End Function
    Public Function draw(ByVal solFlag As Boolean, ByVal isPetrified As Boolean, ByVal errorAction As action, ByVal pForm As String, ByVal pClass As String) As Image
        If solFlag Then Return Game.picPortrait.BackgroundImage

        If Not oneLayerImgCheck(pForm, pClass) Is Nothing Then Return oneLayerImgCheck(pForm, pClass)

        If Not solFlag Then portraitUDate()

        For i = 0 To 16
            Try
                iArr(i) = imgLib.atrs(imgLib.atrs.Keys(i)).getAt(iArrInd(i))
            Catch ex As Exception
                MsgBox("Error!  Exception thrown in portrait creation (specifically in the " & imgLib.atrs.Keys(i) & " layer).  The player character will now revert to default.")
                errorAction()
            End Try
        Next

        changeHairColor(haircolor)
        changeSkinColor(skincolor)

        If isPetrified Then
            iArr(8) = recolor(iArr(8), skincolor)
            iArr(9) = recolor(iArr(9), skincolor)
        End If

        hideEars()
        If ent.lust > 0 Then lustBlushUpdate()
        If wingInd > 0 Then addWings(wingInd)
        If hornInd > 0 Then addHorns(hornInd)

        Return CreateBMP(iArr)
    End Function

    Public Sub changeHairColor(ByVal c As Color)
        haircolor = c

        If Not checkNDefFemInd(1, 26) Then iArr(1) = Portrait.recolor(imgLib.atrs("RearHair2").getAt(iArrInd(1)), c)
        If Not checkNDefFemInd(5, 29) Then iArr(5) = Portrait.recolor(imgLib.atrs("RearHair1").getAt(iArrInd(5)), c)
        iArr(10) = Portrait.recolor(imgLib.atrs("Eyebrows").getAt(iArrInd(10)), c)
        If Not checkNDefFemInd(15, 27) Then iArr(15) = Portrait.recolor(imgLib.atrs("FrontHair").getAt(iArrInd(15)), c)
    End Sub
    Public Sub changeSkinColor(ByVal c As Color)
        skincolor = c

        iArr(2) = portrait.recolor2(imgLib.atrs("Body").getAt(iArrInd(2)), c)
        iArr(4) = portrait.recolor2(imgLib.atrs("Face").getAt(iArrInd(4)), c)
        colorEars(c)
        iArr(7) = portrait.recolor2(imgLib.atrs("Nose").getAt(iArrInd(7)), c)
    End Sub
    Public Sub lustBlushUpdate()
        Select Case Int(ent.lust / 20)
            Case 0
            Case 1
                iArr(4) = CreateBMP({iArr(4), Game.picLust1.BackgroundImage})
            Case 2
                iArr(4) = CreateBMP({iArr(4), Game.picLust2.BackgroundImage})
            Case 3
                iArr(4) = CreateBMP({iArr(4), Game.picLust3.BackgroundImage})
            Case Else
                iArr(4) = CreateBMP({iArr(4), Game.picLust4.BackgroundImage})
        End Select
    End Sub
    Sub addWings(ByVal i As Integer)
        iArr(1) = CreateBMP({imgLib.atrs("Wings").getM(i), iArr(1)})
    End Sub
    Sub addHorns(ByVal i As Integer)
        iArr(15) = CreateBMP({imgLib.atrs("Horns").getM(i), iArr(15)})
    End Sub
    Sub hideEars()
        If iArrInd(6).Item1 = 1 Or iArrInd(6).Item1 = 2 Or (Not iArrInd(5).Item2 And iArrInd(5).Item1 <> 2) Or (iArrInd(5).Item2 And checkNDefFemInd(5, 10)) Then Exit Sub

        Dim t = iArr(5).Clone
        iArr(5) = iArr(6).Clone
        iArr(6) = t
    End Sub
    Sub colorEars(ByVal c As Color)
        If Not checkNDefMalInd(6, 4) And
           Not checkNDefFemInd(6, 4) And
           Not checkNDefFemInd(6, 9) Then
            iArr(6) = Portrait.recolor2(imgLib.atrs("Ears").getAt(iArrInd(6)), c)
        End If
    End Sub
    Sub setIAInd(ByVal attrInd As Integer, ByVal i As Integer, ByVal b As Boolean, ByVal nonDefFlag As Boolean)
        iArrInd(attrInd) = New Tuple(Of Integer, Boolean, Boolean)(i, b, nonDefFlag)
    End Sub
    Sub setIAInd(ByVal attrInd As Integer, ByVal iaInd As Tuple(Of Integer, Boolean, Boolean))
        iArrInd(attrInd) = iaInd
    End Sub
    Function checkNDefFemInd(ByVal attrInd As Integer, ByVal i As Integer) As Boolean
        Dim ind = iArrInd(attrInd)
        If Not ind.Item2 Then Return False
        If imgLib.atrs(imgLib.atrs.Keys(attrInd)).rosf(ind.Item1) = i Then Return True Else Return False
    End Function
    Function checkNDefMalInd(ByVal attrInd As Integer, ByVal i As Integer) As Boolean
        Dim ind = iArrInd(attrInd)
        If ind.Item2 Or ind.Item3 Then Return False
        If imgLib.atrs(imgLib.atrs.Keys(attrInd)).rosm(ind.Item1) = i Then Return True Else Return False
    End Function
    Function checkFemInd(ByVal attrInd As Integer, ByVal i As Integer) As Boolean
        Dim ind = iArrInd(attrInd)
        If Not ind.Item2 Or Not ind.Item3 Then Return False
        If ind.Item1 = i Then Return True Else Return False
    End Function
    Function checkMalInd(ByVal attrInd As Integer, ByVal i As Integer) As Boolean
        Dim ind = iArrInd(attrInd)
        If ind.Item2 Or ind.Item3 Then Return False
        If ind.Item1 = i Then Return True Else Return False
    End Function

    'recolor changes the color of an image, assumed to be of the same color as the players hair 
    Shared Function recolor(ByVal img As Bitmap, ByVal c As Color)
        If img Is Nothing Then Return Nothing
        Dim cImg As Bitmap = img.Clone
        For x = 0 To img.Width - 1
            For y = 0 To img.Height - 1
                If Not img.GetPixel(x, y).A = 0 Then
                    Dim rfactor As Double = (img.GetPixel(x, y).R / 204)
                    Dim gfactor As Double = (img.GetPixel(x, y).G / 203)
                    Dim bfactor As Double = (img.GetPixel(x, y).B / 212)
                    'If Not checkColors(rfactor, gfactor, bfactor) Then
                    Dim R As Integer = (c.R * (rfactor))
                    Dim G As Integer = (c.G * (gfactor))
                    Dim B As Integer = (c.B * (bfactor))
                    If R > 255 Then R = 255
                    If G > 255 Then G = 255
                    If B > 255 Then B = 255
                    Dim c1 As Color = Color.FromArgb(c.A, R, G, B)
                    cImg.SetPixel(x, y, c1)
                    'End If
                End If
            Next
        Next
        Return cImg
    End Function
    'recolor2 changes the color of an image, assumed to be of the same color as the players skin
    Shared Function recolor2(ByVal img As Bitmap, ByVal c As Color)
        If img Is Nothing Then Return Nothing
        Dim cImg As Bitmap = img.Clone
        For x = 0 To img.Width - 1
            For y = 0 To img.Height - 1
                If Not img.GetPixel(x, y).A = 0 Then 'And img.GetPixel(x, y).GetBrightness() > 0.5 Then
                    'MsgBox(img.GetPixel(x, y).GetBrightness())
                    Dim rfactor As Double = (img.GetPixel(x, y).R / 247)
                    Dim gfactor As Double = (img.GetPixel(x, y).G / 219)
                    Dim bfactor As Double = (img.GetPixel(x, y).B / 195)
                    Dim R As Integer = (c.R * (rfactor))
                    Dim G As Integer = (c.G * (gfactor))
                    Dim B As Integer = (c.B * (bfactor))
                    If R > 255 Then R = 255
                    If G > 255 Then G = 255
                    If B > 255 Then B = 255
                    Dim c1 As Color = Color.FromArgb(c.A, R, G, B)

                    cImg.SetPixel(x, y, c1)
                End If
            Next
        Next
        Return cImg
    End Function

    'portraitUDate updates the player's portrait based on their breastsize and armor
    Public Sub portraitUDate()
        If ent Is Nothing Then Exit Sub
        Dim p As Player
        If ent.GetType Is GetType(Player) Then
            p = CType(ent, Player)
        Else
            Exit Sub
        End If

        If p.solFlag Then Exit Sub
        If p.equippedArmor.getName = "Skimpy_Clothes" Then
            skimpyClothesUpdate()
        ElseIf p.equippedArmor.getName = "Magic_Girl_Outfit" Then
            mgoutfitUpdate()
        ElseIf p.equippedArmor.getName = "Common_Clothes" Then
            cclothesUpdate()
        Else
            Select Case p.breastSize
                Case -1
                    iArrInd(3) = p.equippedArmor.bsizeneg1
                Case 0
                    If p.equippedArmor.bsize0 Is Nothing Then
                        iArrInd(3) = p.equippedArmor.bsizeneg1
                    Else
                        iArrInd(3) = p.equippedArmor.bsize0
                    End If
                Case 1
                    iArrInd(3) = p.equippedArmor.bsize1
                Case 2
                    iArrInd(3) = p.equippedArmor.bsize2
                Case 3
                    iArrInd(3) = p.equippedArmor.bsize3
                Case 4
                    iArrInd(3) = p.equippedArmor.bsize4
                Case 5
                    iArrInd(3) = p.equippedArmor.bsize5
                Case 6
                    iArrInd(3) = p.equippedArmor.bsize6
                Case 7
                    iArrInd(3) = p.equippedArmor.bsize7
            End Select
            If iArrInd(3) Is Nothing Then
                getNaked()
            End If
        End If
        If Not p.equippedArmor.getName.Equals("Naked") And p.equippedArmor.compressesBreasts And Not p.pClass.name.Equals("Magic Girl") Then
            compressBreasts()
        ElseIf p.equippedArmor.getName.Equals("Naked") Or Not p.equippedArmor.compressesBreasts Then
            notcompress()
        End If

        If p.equippedAcce Is Nothing Or (p.equippedAcce.fInd Is Nothing And p.equippedAcce.mInd Is Nothing) Then
            p.equippedAcce = New noAcce()
        Else
            If sexBool() Then
                If Not p.equippedAcce.fInd Is Nothing Then iArrInd(14) = p.equippedAcce.fInd Else iArrInd(4) = p.equippedAcce.mInd
            Else
                If Not p.equippedAcce.mInd Is Nothing Then iArrInd(14) = p.equippedAcce.mInd Else iArrInd(4) = p.equippedAcce.fInd
            End If
        End If


        'Form1.picPortrait.BackgroundImage = CharacterGenerator1.CreateBMP(p.iArr)
    End Sub
    Public Sub skimpyClothesUpdate()
        Dim p As Player
        If ent.GetType Is GetType(Player) Then
            p = CType(ent, Player)
        Else
            Exit Sub
        End If

        Select Case p.breastSize
            Case -1
                iArrInd(3) = p.equippedArmor.bsizeneg1
            Case 0
                iArrInd(3) = p.equippedArmor.bsize0
            Case 1
                iArrInd(3) = p.equippedArmor.bsize1
            Case 2
                iArrInd(3) = p.equippedArmor.bsize2
            Case 3
                iArrInd(3) = p.equippedArmor.bsize3
            Case 4
                iArrInd(3) = p.equippedArmor.bsize4
            Case Else
                getNaked()
        End Select
    End Sub
    Public Sub mgoutfitUpdate()
        Dim p As Player
        If ent.GetType Is GetType(Player) Then
            p = CType(ent, Player)
        Else
            Exit Sub
        End If

        If Not p.pClass.name.Equals("Magic Girl") And Not (p.pClass.name.Equals("Bimbo") And p.breastSize = 3) Then
            getNaked()
        End If
        Select Case p.breastSize
            Case 1
                iArrInd(3) = p.equippedArmor.bsize1
            Case 3
                haircolor = Color.FromArgb(255, 255, 250, 205)
                iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(10, True, True)
                iArrInd(5) = New Tuple(Of Integer, Boolean, Boolean)(10, True, True)
                iArrInd(15) = New Tuple(Of Integer, Boolean, Boolean)(7, True, True)
                iArrInd(3) = p.equippedArmor.bsize3
            Case Else
                getNaked()
        End Select
    End Sub
    Public Sub cclothesUpdate()
        If ent Is Nothing Then Exit Sub
        Dim p As Player
        If ent.GetType Is GetType(Player) Then
            p = CType(ent, Player)
        Else
            Exit Sub
        End If

        Select Case p.breastSize
            Case -1
                iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(p.sState.iArrInd(3).Item1, iArrInd(2).Item2, False)
            Case 0
                iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(p.sState.iArrInd(3).Item1, iArrInd(2).Item2, False)
            Case 1
                iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(p.sState.iArrInd(3).Item1, iArrInd(2).Item2, False)
            Case 2
                Select Case p.sState.iArrInd(3).Item1
                    Case 0, 1, 2, 3, 4
                        iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(imgLib.atrs("Clothes").osf(CInt(p.sState.iArrInd(3).Item1) + 99), True, False)
                    Case 5
                        iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(imgLib.atrs("Clothes").osf(123), True, False)
                    Case 6
                        iArrInd(3) = New Tuple(Of Integer, Boolean, Boolean)(imgLib.atrs("Clothes").osf(124), True, False)
                    Case Else
                        getNaked()
                End Select
            Case Else
                getNaked()
        End Select
    End Sub
    Public Sub compressBreasts()
        Dim p As Player
        If ent.GetType Is GetType(Player) Then
            p = CType(ent, Player)
        Else
            Exit Sub
        End If

        If Not checkNDefFemInd(2, 10) And Not checkNDefFemInd(2, 16) And Not checkNDefFemInd(2, 21) Then
            Select Case p.breastSize
                Case -1
                    setIAInd(2, 0, False, False)
                Case 0
                    setIAInd(2, 2, False, True)
                Case 1
                    setIAInd(2, 5, True, True)
                Case 2
                    setIAInd(2, 6, True, True)
                Case 3
                    setIAInd(2, 7, True, True)
                Case 4
                    setIAInd(2, 8, True, True)
                Case 5
                    setIAInd(2, 9, True, True)
                Case 6
                    setIAInd(2, 18, True, True)
                Case 7
                    setIAInd(2, 20, True, True)
            End Select
        End If
    End Sub
    Public Sub getNaked()
        Dim p As Player
        If ent.GetType Is GetType(Player) Then
            p = CType(ent, Player)
        Else
            Exit Sub
        End If

        Equipment.clothesChange("Naked")
        Game.pushLstLog("Your clothes don't fit!")
        If sexBool() Then
            setIAInd(3, 47, True, True)
        Else
            setIAInd(3, 5, False, True)
        End If
    End Sub
    Public Sub notcompress()
        Dim p As Player
        If ent.GetType Is GetType(Player) Then
            p = CType(ent, Player)
        Else
            Exit Sub
        End If

        If Not checkNDefFemInd(2, 10) And Not checkNDefFemInd(2, 16) And Not checkNDefFemInd(2, 21) Then
            Select Case p.breastSize
                Case -1
                    setIAInd(2, 0, False, False)
                Case 0
                    setIAInd(2, 2, False, True)
                Case 1
                    setIAInd(2, 0, True, False)
                Case 2
                    setIAInd(2, 1, True, True)
                Case 3
                    setIAInd(2, 2, True, True)
                Case 4
                    setIAInd(2, 3, True, True)
                Case 5
                    setIAInd(2, 4, True, True)
                Case 6
                    setIAInd(2, 17, True, True)
                Case 7
                    setIAInd(2, 19, True, True)
            End Select
        End If
    End Sub

    'gets the player's current sexBool
    Public Function sexBool() As Boolean
        Return iArrInd(2).Item2
    End Function
End Class
