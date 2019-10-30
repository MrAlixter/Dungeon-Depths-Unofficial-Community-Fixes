'pi defines the various portrait indexes
Public Enum pInd
    bkg             '0
    rearhair        '1
    body            '2
    clothes         '3
    face            '4
    midhair         '5
    ears            '6
    nose            '7
    mouth           '8
    eyes            '9
    eyebrows        '10
    facemark        '11
    glasses         '12
    cloak           '13
    accessory       '14
    fronthair       '15
    hat             '16
End Enum

Public Class Portrait
    Dim ent As Entity
    Public iarr(16) As Image
    Public iArrInd(16) As Tuple(Of Integer, Boolean, Boolean)
    Public haircolor As Color = Color.FromArgb(255, 204, 203, 213)
    Public skincolor As Color = Color.FromArgb(255, 247, 219, 195)
    Public wingInd = 0
    Public hornInd = 0
    Public hBowInd = 0
    Public Shared imgLib As ImageCollection = New ImageCollection(1)
    Public Shared nullImg As Image = imgLib.atrs("Clothes").getAt(New Tuple(Of Integer, Boolean, Boolean)(5, False, True))
    Dim sInts() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0} 'the starting indexes of each catagory

    Sub New(ByVal sex As Boolean, ByRef e As Entity)
        Dim defInd0 = New Tuple(Of Integer, Boolean, Boolean)(0, sex, False)
        Dim defInd1 = New Tuple(Of Integer, Boolean, Boolean)(1, sex, False)
        iarr(pind.bkg) = imgLib.atrs("bkg").getAt(defInd0)
        iarr(pind.rearhair) = imgLib.atrs("RearHair2").getAt(defInd0)
        iarr(pind.body) = imgLib.atrs("Body").getAt(defInd0)
        iarr(pind.clothes) = imgLib.atrs("Clothes").getAt(defInd0)
        iarr(pind.face) = imgLib.atrs("Face").getAt(defInd0)
        iarr(pind.midhair) = imgLib.atrs("RearHair1").getAt(defInd0)
        iarr(pind.ears) = imgLib.atrs("Ears").getAt(defInd0)
        iarr(pind.nose) = imgLib.atrs("Nose").getAt(defInd0)
        iarr(pind.mouth) = imgLib.atrs("Mouth").getAt(defInd0)
        iarr(pind.eyes) = imgLib.atrs("Eyes").getAt(defInd0)
        iarr(pind.eyebrows) = imgLib.atrs("Eyebrows").getAt(defInd0)
        iArr(pInd.facemark) = nullImg
        iArr(pInd.glasses) = nullImg
        iArr(pInd.cloak) = nullImg
        iarr(pInd.accessory) = nullImg
        iarr(pind.fronthair) = imgLib.atrs("FrontHair").getAt(defInd1)
        iarr(pind.hat) = nullImg

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
        Dim startTime As Double = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds

        Dim bmp As New Bitmap(146, 216)
        Dim g As Graphics = Graphics.FromImage(bmp)
        If img(0).Size.Height < 300 Then g.DrawImage(img(0), 0, 0, 146, 216) Else g.DrawImage(img(0), 0, 0, 144, 144)
        For i = 1 To UBound(img)
            If img(i) Is Nothing Then img(i) = CharacterGenerator.picPort.Image
            If img(i).Size.Height <= 144 Then
                g.DrawImage(img(i), 1, 1, 144, 144)
            ElseIf img(i).Size.Height <= 300 Then
                g.DrawImage(img(i), 1, 1, 144, 216)
            Else
                g.DrawImage(img(i), -11, -38, 164, 610)
            End If
        Next
        g.DrawImage(Game.picPortOutline.BackgroundImage, 0, 0, 146, 216)

        Dim endTime = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
        Console.WriteLine("RENDER TIME: " + (endTime - startTime).ToString())
        Return bmp
    End Function
    Shared Function CreateFullBodyBMP(ByRef img() As Image) As Bitmap
        Dim bmp As New Bitmap(164, 610)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.DrawImage(img(0), 0, 0, 164, 610)
        For i = 1 To UBound(img)
            If img(i) Is Nothing Then img(i) = CharacterGenerator.picPort.Image
            If img(i).Size.Height <= 144 Then
                g.DrawImage(img(i), 12, 39, 144, 144)
            ElseIf img(i).Size.Height <= 300 Then
                g.DrawImage(img(i), 12, 39, 144, 216)
            Else
                g.DrawImage(img(i), 0, 0, 164, 610)
            End If
        Next
        Return bmp
    End Function
    Shared Function fastCreateBMP(ByVal img() As Image, Optional fullBodyFlag As Boolean = False) As Bitmap
        Dim startTime As Double = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds

        Dim bmp As Bitmap

        Dim workingImg(UBound(img)) As Bitmap

        If fullBodyFlag Then
            bmp = New Bitmap(164, 610)
            For l = 0 To UBound(img)
                If img(l).Size.Height <= 300 Then workingImg(l) = CreateFullBodyBMP({img(l)}) Else workingImg(l) = img(l)
            Next
        Else
            bmp = New Bitmap(146, 216)
            For l = 0 To UBound(img)
                If img(l).Size.Height > 300 Or img(l).Size.Height < 200 Then img(l) = CreateBMP({img(l)}) Else workingImg(l) = img(l)
            Next
        End If

        Dim bkgColor = Color.FromArgb(255, 32, 34, 38)

        For i = 0 To bmp.Size.Height
            For j = 0 To bmp.Size.Width
                For k = UBound(img) To 0 Step -1
                    If workingImg(k) Is Nothing Then Exit For
                    If Not workingImg(k).GetPixel(i, j).IsEmpty AndAlso workingImg(k).GetPixel(j, i).Equals(bkgColor) Then
                        k = pInd.rearhair
                    ElseIf workingImg(k).GetPixel(j, i).A <> 0 Then
                        bmp.SetPixel(j, i, workingImg(k).GetPixel(j, i))
                        Exit For
                    End If
                Next
            Next
        Next

        Dim endTime = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
        Console.WriteLine("RENDER TIME: " + (endTime - startTime).ToString())
        Return bmp
    End Function
    'exports the current assembled portrait as a .bmp image
    Public Function ExportIMG() As Image
        Dim bmp As New Bitmap(146, 216)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.DrawImage(iarr(pind.bkg), 0, 0, 146, 216)
        For i = 1 To UBound(iArr)
            g.DrawImage(iArr(i), 1, 1)
        Next
        Return bmp
    End Function

    Function oneLayerImgCheck(ByVal pForm As String, ByVal pClass As String) As Image
        Dim pic = Nothing
        If pForm.Equals("Dragon") And Not sexBool() Then
            pic = Game.picDragonM.BackgroundImage
        ElseIf pForm.Equals("Dragon") And sexBool() Then
            pic = Game.picDragonF.BackgroundImage
        ElseIf pClass.Equals("Magical Girl​") Then
            pic = Game.picmgp1.BackgroundImage
        ElseIf pForm.Equals("Sheep") Then
            pic = Game.picSheep.BackgroundImage
        ElseIf pForm.Equals("Cake") Then
            pic = Game.picCake.BackgroundImage
        ElseIf pForm.Equals("Frog") Then
            pic = Game.picFrog.BackgroundImage
        ElseIf pClass.Equals("Princess​") Then
            pic = Game.picPrin.BackgroundImage
        ElseIf pClass.Equals("Bunny Girl​") Then
            pic = Game.picBun.BackgroundImage
        ElseIf pForm.Equals("Half-Dragoness") Then
            pic = Game.picHalfDragon1.BackgroundImage
        ElseIf pForm.Equals("Half-Broodmother") Then
            pic = Game.picHalfDragon2.BackgroundImage
        ElseIf pForm.Equals("Broodmother") Then
            pic = Game.picBroodmother.BackgroundImage
        End If
        Return pic
    End Function
    Public Function draw()
        portraitUDate()
        If ent Is Nothing Then
            Select Case sexBool()
                Case False
                    setIAInd(pInd.body, 0, False, False)
                Case True
                    setIAInd(pInd.body, 5, True, True)
            End Select
        End If

        For i = 0 To 16
            Try
                iArr(i) = imgLib.atrs(imgLib.atrs.Keys(i)).getAt(iArrInd(i))
            Catch ex As Exception
                MsgBox("Error!  Exception thrown in portrait creation (specifically in the " & imgLib.atrs.Keys(i).ToString & " layer).  The player character will now revert to default.")
            End Try
        Next

        changeHairColor(haircolor)
        changeSkinColor(skincolor)
        accUnderClothes()

        hideEars()
        hideRearHair()

        If Not ent Is Nothing AndAlso ent.lust > 0 Then lustBlushUpdate()
        If wingInd > 0 Then addWings(wingInd)
        If hornInd > 0 Then addHorns(hornInd)
        If hBowInd > 0 Then addHBow(hBowInd)

        Return CreateBMP(iArr)
    End Function
    Public Function draw(ByVal solFlag As Boolean, ByVal isPetrified As Boolean, ByVal errorAction As action, ByVal pForm As String, ByVal pClass As String) As Image
        If solFlag Then Return Game.picPortrait.BackgroundImage

        If Not oneLayerImgCheck(pForm, pClass) Is Nothing Then Return CreateBMP({iarr(pind.bkg), oneLayerImgCheck(pForm, pClass)})


        If Not solFlag Then portraitUDate()

        For i = 0 To 16
            Try
                iArr(i) = imgLib.atrs(imgLib.atrs.Keys(i)).getAt(iArrInd(i))
            Catch ex As Exception
                MsgBox("Error!  Exception thrown in portrait creation (specifically in the " & imgLib.atrs.Keys(i).ToString & " layer).  The player character will now revert to default.")
                'errorAction()
            End Try
        Next

        changeHairColor(haircolor)
        changeSkinColor(skincolor)

        If isPetrified Then
            iarr(pind.mouth) = recolor(iarr(pind.mouth), skincolor)
            iarr(pind.eyes) = recolor(iarr(pind.eyes), skincolor)
        End If

        hideEars()
        hideRearHair()
        accUnderClothes()

        If ent.lust > 0 Then lustBlushUpdate()
        If wingInd > 0 Then addWings(wingInd)
        If hornInd > 0 Then addHorns(hornInd)
        If hBowInd > 0 Then addHBow(hBowInd)

        Return CreateBMP(iArr)
    End Function

    Public Sub changeHairColor(ByVal c As Color)
        haircolor = c

        If Not checkNDefFemInd(1, 26) Then iarr(pind.rearhair) = Portrait.recolor(imgLib.atrs("RearHair2").getAt(iArrInd(pInd.rearhair)), c)
        If Not checkNDefFemInd(5, 29) Then iarr(pind.midhair) = Portrait.recolor(imgLib.atrs("RearHair1").getAt(iArrInd(pInd.midhair)), c)
        iarr(pind.eyebrows) = Portrait.recolor(imgLib.atrs("Eyebrows").getAt(iArrInd(pInd.eyebrows)), c)
        If Not checkNDefFemInd(15, 27) Then iarr(pInd.fronthair) = Portrait.recolor(imgLib.atrs("FrontHair").getAt(iArrInd(pInd.fronthair)), c)
    End Sub
    Public Sub changeSkinColor(ByVal c As Color)
        skincolor = c

        iarr(pind.body) = Portrait.recolor2(imgLib.atrs("Body").getAt(iArrInd(pInd.body)), c)
        iarr(pind.face) = Portrait.recolor2(imgLib.atrs("Face").getAt(iArrInd(pInd.face)), c)
        colorEars(c)
        iarr(pind.nose) = Portrait.recolor2(imgLib.atrs("Nose").getAt(iArrInd(pInd.nose)), c)
    End Sub
    Public Sub lustBlushUpdate()
        Select Case Int(ent.lust / 20)
            Case 0
            Case 1
                iarr(pind.face) = CreateBMP({iarr(pind.face), Game.picLust1.BackgroundImage})
            Case 2
                iarr(pind.face) = CreateBMP({iarr(pind.face), Game.picLust2.BackgroundImage})
            Case 3
                iarr(pind.face) = CreateBMP({iarr(pind.face), Game.picLust3.BackgroundImage})
            Case Else
                iarr(pind.face) = CreateBMP({iarr(pind.face), Game.picLust4.BackgroundImage})
        End Select
    End Sub
    Sub addWings(ByVal i As Integer)
        iarr(pind.rearhair) = CreateFullBodyBMP({CharacterGenerator.picPort.Image, imgLib.atrs("Wings").getM(i), iarr(pind.rearhair)})
    End Sub
    Sub addHBow(ByVal i As Integer)
        iarr(pind.rearhair) = CreateFullBodyBMP({CharacterGenerator.picPort.Image, iarr(pind.rearhair), imgLib.atrs("HBows").getM(i)})
    End Sub
    Sub addHorns(ByVal i As Integer)
        iarr(pind.fronthair) = CreateFullBodyBMP({CharacterGenerator.picPort.Image, imgLib.atrs("Horns").getM(i), iarr(pind.fronthair)})
    End Sub
    Sub hideEars()
        If iArrInd(pInd.ears).Item1 = 1 Or iArrInd(pInd.ears).Item1 = 2 Or (Not iArrInd(pInd.midhair).Item2 And iArrInd(pInd.midhair).Item1 <> 2) Or (iArrInd(pInd.midhair).Item2 And checkNDefFemInd(5, 10)) Then Exit Sub
        Dim t = iarr(pind.midhair).Clone
        iarr(pind.midhair) = iarr(pind.ears).Clone
        iarr(pind.ears) = t
    End Sub
    Sub colorEars(ByVal c As Color)
        If Not checkNDefMalInd(6, 3) And
           Not checkNDefFemInd(6, 3) And
           Not checkNDefFemInd(6, 9) Then
            iarr(pind.ears) = Portrait.recolor2(imgLib.atrs("Ears").getAt(iArrInd(pInd.ears)), c)
        End If
    End Sub
    Sub hideRearHair()
        If checkNDefFemInd(16, 9) Then
            iarr(pind.rearhair) = imgLib.atrs("Hat").getAt(New Tuple(Of Integer, Boolean, Boolean)(10, True, True))
        ElseIf checkNDefFemInd(16, 11) Then
            iarr(pind.rearhair) = imgLib.atrs("Hat").getAt(New Tuple(Of Integer, Boolean, Boolean)(12, True, True))
        ElseIf checkNDefFemInd(14, 14) Or checkNDefMalInd(14, 13) Then
            iarr(pind.rearhair) = imgLib.atrs("Ears").getAt(New Tuple(Of Integer, Boolean, Boolean)(5, True, True))
        End If
    End Sub
    Sub accUnderClothes()
        If checkNDefFemInd(14, 14) Or checkNDefMalInd(14, 13) Then
            iarr(pInd.midhair) = CreateFullBodyBMP({CharacterGenerator.picPort.Image, iarr(pInd.accessory), iarr(pInd.clothes), iarr(pInd.midhair)})
            iarr(pInd.accessory) = CharacterGenerator.picPort.Image
            iarr(pInd.mouth) = CharacterGenerator.picPort.Image
        ElseIf checkNDefFemInd(14, 12) Then
            iarr(pInd.midhair) = CreateFullBodyBMP({CharacterGenerator.picPort.Image, iarr(pInd.accessory), iarr(pInd.clothes), iarr(pInd.midhair)})
            iarr(pInd.accessory) = CharacterGenerator.picPort.Image
        End If
    End Sub
    Sub setIAInd(ByVal attrInd As pInd, ByVal i As Integer, ByVal b As Boolean, ByVal nonDefFlag As Boolean)
        iArrInd(attrInd) = New Tuple(Of Integer, Boolean, Boolean)(i, b, nonDefFlag)
    End Sub
    Sub setIAInd(ByVal attrInd As pInd, ByVal iaInd As Tuple(Of Integer, Boolean, Boolean))
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
        ElseIf p.equippedArmor.getName = "Common_Clothes" Then
            cclothesUpdate()
        Else
            Select Case p.breastSize
                Case -1
                    iArrInd(pInd.clothes) = p.equippedArmor.bsizeneg1
                Case 0
                    If p.equippedArmor.bsize0 Is Nothing Then
                        iArrInd(pInd.clothes) = p.equippedArmor.bsizeneg1
                    Else
                        iArrInd(pInd.clothes) = p.equippedArmor.bsize0
                    End If
                Case 1
                    iArrInd(pInd.clothes) = p.equippedArmor.bsize1
                Case 2
                    iArrInd(pInd.clothes) = p.equippedArmor.bsize2
                Case 3
                    iArrInd(pInd.clothes) = p.equippedArmor.bsize3
                Case 4
                    iArrInd(pInd.clothes) = p.equippedArmor.bsize4
                Case 5
                    iArrInd(pInd.clothes) = p.equippedArmor.bsize5
                Case 6
                    iArrInd(pInd.clothes) = p.equippedArmor.bsize6
                Case 7
                    iArrInd(pInd.clothes) = p.equippedArmor.bsize7
            End Select
            If iArrInd(pInd.clothes) Is Nothing Then
                getNaked()
            End If
        End If
        If Not p.equippedArmor.getName.Equals("Naked") And p.equippedArmor.compressesBreasts Then
            compressBreasts()
        ElseIf p.equippedArmor.getName.Equals("Naked") Or Not p.equippedArmor.compressesBreasts Then
            notcompress()
        End If

        If p.equippedAcce Is Nothing Or (p.equippedAcce.fInd Is Nothing And p.equippedAcce.mInd Is Nothing) Then
            p.equippedAcce = New noAcce()
        Else
            If sexBool() Then
                If Not p.equippedAcce.fInd Is Nothing Then iArrInd(pInd.accessory) = p.equippedAcce.fInd Else iArrInd(pInd.face) = p.equippedAcce.mInd
            Else
                If Not p.equippedAcce.mInd Is Nothing Then iArrInd(pInd.accessory) = p.equippedAcce.mInd Else iArrInd(pInd.face) = p.equippedAcce.fInd
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
                iArrInd(pInd.clothes) = p.equippedArmor.bsizeneg1
            Case 0
                iArrInd(pInd.clothes) = p.equippedArmor.bsize0
            Case 1
                iArrInd(pInd.clothes) = p.equippedArmor.bsize1
            Case 2
                iArrInd(pInd.clothes) = p.equippedArmor.bsize2
            Case 3
                iArrInd(pInd.clothes) = p.equippedArmor.bsize3
            Case 4
                iArrInd(pInd.clothes) = p.equippedArmor.bsize4
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
                iArrInd(pInd.clothes) = New Tuple(Of Integer, Boolean, Boolean)(p.sState.iArrInd(pInd.clothes).Item1, iArrInd(pInd.body).Item2, False)
            Case 0
                iArrInd(pInd.clothes) = New Tuple(Of Integer, Boolean, Boolean)(p.sState.iArrInd(pInd.clothes).Item1, iArrInd(pInd.body).Item2, False)
            Case 1
                iArrInd(pInd.clothes) = New Tuple(Of Integer, Boolean, Boolean)(p.sState.iArrInd(pInd.clothes).Item1, iArrInd(pInd.body).Item2, False)
            Case 2
                Select Case p.sState.iArrInd(pInd.clothes).Item1
                    Case 0, 1, 2, 3, 4
                        iArrInd(pInd.clothes) = New Tuple(Of Integer, Boolean, Boolean)(imgLib.atrs("Clothes").osf(CInt(p.sState.iArrInd(pInd.clothes).Item1) + 99), True, False)
                    Case 5
                        iArrInd(pInd.clothes) = New Tuple(Of Integer, Boolean, Boolean)(imgLib.atrs("Clothes").osf(123), True, False)
                    Case 6
                        iArrInd(pInd.clothes) = New Tuple(Of Integer, Boolean, Boolean)(imgLib.atrs("Clothes").osf(124), True, False)
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
                    setIAInd(pInd.body, 0, False, False)
                Case 0
                    setIAInd(pInd.body, 2, False, True)
                Case 1
                    setIAInd(pInd.body, 5, True, True)
                Case 2
                    setIAInd(pInd.body, 6, True, True)
                Case 3
                    setIAInd(pInd.body, 7, True, True)
                Case 4
                    setIAInd(pInd.body, 8, True, True)
                Case 5
                    setIAInd(pInd.body, 9, True, True)
                Case 6
                    setIAInd(pInd.body, 18, True, True)
                Case 7
                    setIAInd(pInd.body, 20, True, True)
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
            setIAInd(pInd.clothes, 47, True, True)
        Else
            setIAInd(pInd.clothes, 5, False, True)
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
                    setIAInd(pInd.body, 0, False, False)
                Case 0
                    setIAInd(pInd.body, 2, False, True)
                Case 1
                    setIAInd(pInd.body, 0, True, False)
                Case 2
                    setIAInd(pInd.body, 1, True, True)
                Case 3
                    setIAInd(pInd.body, 2, True, True)
                Case 4
                    setIAInd(pInd.body, 3, True, True)
                Case 5
                    setIAInd(pInd.body, 4, True, True)
                Case 6
                    setIAInd(pInd.body, 17, True, True)
                Case 7
                    setIAInd(pInd.body, 19, True, True)
            End Select
        End If
    End Sub

    'gets the player's current sexBool
    Public Function sexBool() As Boolean
        If checkNDefMalInd(2, 1) Then Return True
        Return iArrInd(pInd.body).Item2
    End Function
End Class
