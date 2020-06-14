'pi defines the various portrait indexes
Public Enum pInd
    bkg             '0
    tail            '1
    wings           '2
    rearhair        '3
    hairacc         '4
    shoulders       '5
    body            '6
    bodyoverlay     '7
    genitalia       '8
    chest           '9
    clothesbtm      '10
    clothes         '11
    face            '12
    midhair         '13
    horns           '14
    ears            '15
    nose            '16
    mouth           '17
    eyes            '18
    eyebrows        '19
    facemark        '20
    glasses         '21
    cloak           '22
    accessory       '23
    fronthair       '24
    hat             '25
End Enum

Public Class Portrait
    Public Const NUM_IMG_LAYERS As Integer = 25

    Dim ent As Entity
    Public iArr(NUM_IMG_LAYERS) As Bitmap
    Public iArrInd(NUM_IMG_LAYERS) As Tuple(Of Integer, Boolean, Boolean)
    Public haircolor As Color = Color.FromArgb(255, 204, 203, 213)
    Public skincolor As Color = Color.FromArgb(255, 247, 219, 195)
    Public Shared imgLib As ImageCollection
    Public Shared nullImg As Image
    Dim sInts() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0} 'the starting indexes of each catagory
    Shared Sub New()
        imgLib = New ImageCollection(1)
        nullImg = imgLib.atrs(pInd.clothes).getAt(New Tuple(Of Integer, Boolean, Boolean)(5, False, True))
    End Sub

    Sub New(ByVal sex As Boolean, ByRef e As Entity)
        For i = 0 To Portrait.NUM_IMG_LAYERS
            iArrInd(i) = New Tuple(Of Integer, Boolean, Boolean)(sInts(i), sex, False)
        Next

        If sex Then
            setIAInd(pInd.body, New Tuple(Of Integer, Boolean, Boolean)(0, True, False))
            setIAInd(pInd.chest, New Tuple(Of Integer, Boolean, Boolean)(9, True, False))
            setIAInd(pInd.shoulders, New Tuple(Of Integer, Boolean, Boolean)(2, True, False))
            setIAInd(pInd.genitalia, New Tuple(Of Integer, Boolean, Boolean)(4, True, False))
        Else
            setIAInd(pInd.body, New Tuple(Of Integer, Boolean, Boolean)(0, False, False))
            setIAInd(pInd.chest, New Tuple(Of Integer, Boolean, Boolean)(0, False, False))
            setIAInd(pInd.shoulders, New Tuple(Of Integer, Boolean, Boolean)(0, False, False))
            setIAInd(pInd.genitalia, New Tuple(Of Integer, Boolean, Boolean)(1, False, False))
        End If

        For i = 0 To Portrait.NUM_IMG_LAYERS
            iArr(i) = imgLib.atrs(i).getAt(iArrInd(i))
        Next

        ent = e
    End Sub
    Shared Sub init()
        imgLib = New ImageCollection(1)
        nullImg = imgLib.atrs(pInd.clothes).getAt(New Tuple(Of Integer, Boolean, Boolean)(5, False, True))
    End Sub
    'converts an array of images into a .bmp image
    Shared Function CreateBMP(ByRef img() As Image) As Bitmap
        Dim startTime As Double = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds

        Dim bmp As New Bitmap(146, 216)
        Dim g As Graphics = Graphics.FromImage(bmp)
        If img(0).Size.Height < 300 Then g.DrawImage(img(0), 0, 0, 146, 216) Else g.DrawImage(img(0), 0, 0, 144, 144)
        For i = 1 To UBound(img)
            If img(i) Is Nothing Then img(i) = CharacterGenerator.picPort.Image
            g.DrawImage(img(i), getRelativeX(img(i).Size, False), getRelativeY(img(i).Size, False))
        Next
        g.DrawImage(Game.picPortOutline.BackgroundImage, 0, 0, 146, 216)

        Dim endTime = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
        Console.WriteLine("HBPRT RENDER TIME: " + (endTime - startTime).ToString())
        Return bmp
    End Function
    Shared Function CreateFullBodyBMP(ByRef img() As Image) As Bitmap
        Dim startTime As Double = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds

        Dim bmp As New Bitmap(164, 610)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.DrawImage(img(0), 0, 0, 164, 610)
        For i = 1 To UBound(img)
            If img(i) Is Nothing Then img(i) = CharacterGenerator.picPort.Image
            g.DrawImage(img(i), getRelativeX(img(i).Size, True), getRelativeY(img(i).Size, True))
        Next

        Dim endTime = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
        Console.WriteLine("FBPRT RENDER TIME: " + (endTime - startTime).ToString())
        Return bmp
    End Function
    Shared Function getRelativeX(ByVal s As Size, ByVal fullBody As Boolean)
        If fullBody Then
            If s.Height <= 300 Then
                Return 12
            End If
        Else
            If s.Height <= 300 Then
                Return 1
            Else
                Return -11
            End If
        End If

        Return 0
    End Function
    Shared Function getRelativeY(ByVal s As Size, ByVal fullBody As Boolean)
        If fullBody Then
            If s.Height <= 300 Then
                Return 39
            End If
        Else
            If s.Height <= 300 Then
                Return 1
            Else
                Return -38
            End If
        End If

        Return 0
    End Function

    'exports the current assembled portrait as a .bmp image
    Public Function ExportIMG() As Image
        Dim bmp As New Bitmap(146, 216)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.DrawImage(iArr(pInd.bkg), 0, 0, 146, 216)
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
        ElseIf pForm.Equals("Horse") Then
            pic = Game.picHorse.BackgroundImage
        ElseIf pForm.Equals("Unicorn") Then
            pic = Game.picUnicorn.BackgroundImage
        ElseIf pForm.Equals("Oni") Then
            pic = Game.picOniF.BackgroundImage
        ElseIf pForm.Equals("Blob") And Not sexBool() Then
            pic = Game.picBlobM.BackgroundImage
        ElseIf pForm.Equals("Blob") And sexBool() Then
            pic = Game.picBlobF.BackgroundImage
        End If
        Return pic
    End Function

    Public Sub setIArr()
        For i = 0 To Portrait.NUM_IMG_LAYERS
            If Not (checkNDefFemInd(pInd.clothes, 47) Or checkNDefMalInd(pInd.clothes, 5)) And i = pInd.genitalia Then
                iArr(i) = nullImg
                Continue For
            End If

            Try
                iArr(i) = imgLib.atrs(i).getAt(iArrInd(i))
            Catch ex As Exception
                iArr(i) = nullImg
                MsgBox("Error!  Exception thrown in portrait creation (specifically in the " & imgLib.atrs.Keys(i).ToString & " layer).")
            End Try
        Next

        changeHairColor(haircolor)
        changeSkinColor(skincolor)
        accUnderClothes()

        hideEars()
        hideRearHair()

        If Not ent Is Nothing AndAlso ent.lust > 0 Then lustBlushUpdate()
    End Sub
    Public Function draw()
        portraitUDate()
        If ent Is Nothing Then
            Select Case sexBool()
                Case False
                    setIAInd(pInd.body, 0, False, False)
                Case True
                    setIAInd(pInd.body, 0, True, False)
            End Select
        End If

        setIArr()

        Return CreateBMP(iArr)
    End Function
    Public Function draw(ByVal solFlag As Boolean, ByVal isPetrified As Boolean, ByVal errorAction As action, ByVal pForm As String, ByVal pClass As String) As Image
        If solFlag Then Return Game.picPortrait.BackgroundImage

        If Not oneLayerImgCheck(pForm, pClass) Is Nothing Then Return CreateBMP({iArr(pInd.bkg), oneLayerImgCheck(pForm, pClass)})


        If Not solFlag Then portraitUDate()

        setIArr()

        Return CreateBMP(iArr)
    End Function

    Public Sub changeHairColor(ByVal c As Color)
        haircolor = c

        If Not checkNDefFemInd(pInd.rearhair, 26) Then iArr(pInd.rearhair) = Portrait.recolor(imgLib.atrs(pInd.rearhair).getAt(iArrInd(pInd.rearhair)), c)
        If Not checkNDefFemInd(pInd.midhair, 29) Then iArr(pInd.midhair) = Portrait.recolor(imgLib.atrs(pInd.midhair).getAt(iArrInd(pInd.midhair)), c)
        iArr(pInd.eyebrows) = Portrait.recolor(imgLib.atrs(pInd.eyebrows).getAt(iArrInd(pInd.eyebrows)), c)
        If Not checkNDefFemInd(pInd.fronthair, 27) Then iArr(pInd.fronthair) = Portrait.recolor(imgLib.atrs(pInd.fronthair).getAt(iArrInd(pInd.fronthair)), c)
    End Sub
    Public Sub changeSkinColor(ByVal c As Color)
        skincolor = c

        bodyOverlay()

        If c.A = 255 Then
            iArr(pInd.body) = Portrait.recolor2(imgLib.atrs(pInd.body).getAt(iArrInd(pInd.body)), c)
            iArr(pInd.chest) = Portrait.recolor2(imgLib.atrs(pInd.chest).getAt(iArrInd(pInd.chest)), c)
            iArr(pInd.shoulders) = Portrait.recolor2(imgLib.atrs(pInd.shoulders).getAt(iArrInd(pInd.shoulders)), c)
            iArr(pInd.bodyoverlay) = Portrait.recolor2(imgLib.atrs(pInd.bodyoverlay).getAt(iArrInd(pInd.bodyoverlay)), c)
        Else
            Dim bImg = CreateFullBodyBMP({imgLib.atrs(pInd.body).getAt(iArrInd(pInd.body)), imgLib.atrs(pInd.bodyoverlay).getAt(iArrInd(pInd.bodyoverlay)),
                                          imgLib.atrs(pInd.shoulders).getAt(iArrInd(pInd.shoulders)), imgLib.atrs(pInd.chest).getAt(iArrInd(pInd.chest))})
            iArr(pInd.body) = Portrait.recolor2(bImg, c)
            iArr(pInd.chest) = nullImg
            iArr(pInd.shoulders) = nullImg
            iArr(pInd.bodyoverlay) = nullImg
        End If

        iArr(pInd.genitalia) = Portrait.recolor2(imgLib.atrs(pInd.genitalia).getAt(iArrInd(pInd.genitalia)), c)
        iArr(pInd.face) = Portrait.recolor2(imgLib.atrs(pInd.face).getAt(iArrInd(pInd.face)), c)



        colorEars(c)
        iArr(pInd.nose) = Portrait.recolor2(imgLib.atrs(pInd.nose).getAt(iArrInd(pInd.nose)), c)
    End Sub
    Public Sub lustBlushUpdate()
        Select Case Int(ent.lust / 20)
            Case 0
            Case 1
                iArr(pInd.face) = CreateBMP({CharacterGenerator.picPort.Image, iArr(pInd.face), Game.picLust1.BackgroundImage})
            Case 2
                iArr(pInd.face) = CreateBMP({CharacterGenerator.picPort.Image, iArr(pInd.face), Game.picLust2.BackgroundImage})
            Case 3
                iArr(pInd.face) = CreateBMP({CharacterGenerator.picPort.Image, iArr(pInd.face), Game.picLust3.BackgroundImage})
            Case Else
                iArr(pInd.face) = CreateBMP({CharacterGenerator.picPort.Image, iArr(pInd.face), Game.picLust4.BackgroundImage})
        End Select
    End Sub
    Sub hideEars()
        If iArrInd(pInd.ears).Item1 = 1 Or iArrInd(pInd.ears).Item1 = 2 Or (Not iArrInd(pInd.midhair).Item2 And iArrInd(pInd.midhair).Item1 <> 2) Or (iArrInd(pInd.midhair).Item2 And checkNDefFemInd(pInd.midhair, 10)) Then Exit Sub
        Dim t = iArr(pInd.midhair).Clone
        iArr(pInd.midhair) = iArr(pInd.ears).Clone
        iArr(pInd.ears) = t
    End Sub
    Sub colorEars(ByVal c As Color)
        If Not checkNDefMalInd(pInd.ears, 3) And
           Not checkNDefFemInd(pInd.ears, 3) And
           Not checkNDefFemInd(pInd.ears, 9) Then
            iArr(pInd.ears) = Portrait.recolor2(imgLib.atrs(pInd.ears).getAt(iArrInd(pInd.ears)), c)
        End If
    End Sub
    Sub hideRearHair()
        If checkNDefFemInd(pInd.hat, 9) Then
            iArr(pInd.rearhair) = imgLib.atrs(pInd.hat).getAt(New Tuple(Of Integer, Boolean, Boolean)(10, True, True))
        ElseIf checkNDefFemInd(pInd.hat, 11) Then
            iArr(pInd.rearhair) = imgLib.atrs(pInd.hat).getAt(New Tuple(Of Integer, Boolean, Boolean)(12, True, True))
        ElseIf checkNDefFemInd(pInd.accessory, 14) Or checkNDefMalInd(pInd.accessory, 13) Then
            iArr(pInd.rearhair) = imgLib.atrs(pInd.ears).getAt(New Tuple(Of Integer, Boolean, Boolean)(5, True, True))
        End If
    End Sub
    Sub accUnderClothes()
        If checkNDefFemInd(pInd.accessory, 14) Or checkNDefMalInd(pInd.accessory, 13) Then
            iArr(pInd.midhair) = CreateFullBodyBMP({CharacterGenerator.picPort.Image, iArr(pInd.accessory), iArr(pInd.clothes), iArr(pInd.midhair)})
            iArr(pInd.accessory) = CharacterGenerator.picPort.Image
            iArr(pInd.mouth) = CharacterGenerator.picPort.Image
        ElseIf checkNDefFemInd(pInd.accessory, 12) Or checkNDefFemInd(pInd.accessory, 15) Or checkNDefMalInd(pInd.accessory, 14) Then
            iArr(pInd.midhair) = CreateFullBodyBMP({CharacterGenerator.picPort.Image, iArr(pInd.accessory), iArr(pInd.clothes), iArr(pInd.midhair)})
            iArr(pInd.accessory) = CharacterGenerator.picPort.Image
        End If
    End Sub
    Sub bodyOverlay()
        Dim p As Player
        If Not ent Is Nothing AndAlso ent.GetType Is GetType(Player) Then
            p = CType(ent, Player)
        Else
            Exit Sub
        End If

        If p.pClass.name.Equals("Warrior") Or p.pClass.name.Equals("Barbarian") Or p.pClass.name.Equals("Paladin") Or p.pClass.name.Equals("Amazon") Or p.pClass.name.Equals("Valkyrie") Or
         p.pForm.name.Equals("Tigress") Then
            Select Case p.breastSize
                Case -1
                    iArrInd(pInd.bodyoverlay) = New Tuple(Of Integer, Boolean, Boolean)(1, True, False)
                Case 0
                    iArrInd(pInd.bodyoverlay) = New Tuple(Of Integer, Boolean, Boolean)(2, True, False)
                Case Else
                    iArrInd(pInd.bodyoverlay) = New Tuple(Of Integer, Boolean, Boolean)(3, True, False)
            End Select
        Else
            iArrInd(pInd.bodyoverlay) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        End If

        If Not p.equippedArmor.getAName.Equals("Naked") And p.equippedArmor.hidesDick Then iArrInd(pInd.genitalia) = New Tuple(Of Integer, Boolean, Boolean)(4, True, False) Else p.dsizeroute()
    End Sub
    Sub setIAInd(ByVal attrInd As pInd, ByVal i As Integer, ByVal b As Boolean, ByVal nonDefFlag As Boolean)
        iArrInd(attrInd) = New Tuple(Of Integer, Boolean, Boolean)(i, b, nonDefFlag)
    End Sub
    Sub setIAInd(ByVal attrInd As pInd, ByVal iaInd As Tuple(Of Integer, Boolean, Boolean))
        iArrInd(attrInd) = iaInd
    End Sub
    Function checkNDefFemInd(ByVal attrInd As pInd, ByVal i As Integer) As Boolean
        Dim ind = iArrInd(attrInd)
        If Not ind.Item2 Then Return False
        If imgLib.atrs(attrInd).rosf(ind.Item1) = i Then Return True Else Return False
    End Function
    Function checkNDefMalInd(ByVal attrInd As pInd, ByVal i As Integer) As Boolean
        Dim ind = iArrInd(attrInd)
        If ind.Item2 Or ind.Item3 Then Return False
        If imgLib.atrs(attrInd).rosm(ind.Item1) = i Then Return True Else Return False
    End Function
    Function checkFemInd(ByVal attrInd As pInd, ByVal i As Integer) As Boolean
        Dim ind = iArrInd(attrInd)
        If Not ind.Item2 Or Not ind.Item3 Then Return False
        If ind.Item1 = i Then Return True Else Return False
    End Function
    Function checkMalInd(ByVal attrInd As pInd, ByVal i As Integer) As Boolean
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
                    Dim rfactor As Double = (img.GetPixel(x, y).R / 203)
                    Dim gfactor As Double = (img.GetPixel(x, y).G / 204)
                    Dim bfactor As Double = (img.GetPixel(x, y).B / 213)
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

        Select Case p.buttSize
            Case -1
                iArrInd(pInd.clothesbtm) = p.equippedArmor.usizeneg1
            Case 0
                iArrInd(pInd.clothesbtm) = p.equippedArmor.usize0
            Case 1
                iArrInd(pInd.clothesbtm) = p.equippedArmor.usize1
            Case 2
                iArrInd(pInd.clothesbtm) = p.equippedArmor.usize2
            Case 3
                iArrInd(pInd.clothesbtm) = p.equippedArmor.usize3
            Case 4
                iArrInd(pInd.clothesbtm) = p.equippedArmor.usize4
            Case 5
                iArrInd(pInd.clothesbtm) = p.equippedArmor.usize5
        End Select

        If iArrInd(pInd.clothes) Is Nothing Or iArrInd(pInd.clothesbtm) Is Nothing Then getNaked()

        If Not p.equippedArmor.getName.Equals("Naked") And p.equippedArmor.compressesBreasts Then
            compressBreasts()
        ElseIf p.equippedArmor.getName.Equals("Naked") Or Not p.equippedArmor.compressesBreasts Then
            notcompress()
        End If

        If p.equippedAcce Is Nothing Or (p.equippedAcce.fInd Is Nothing And p.equippedAcce.mInd Is Nothing) Then
            p.equippedAcce = New noAcce()
        Else
            If sexBool() Then
                If Not p.equippedAcce.fInd Is Nothing Then iArrInd(pInd.accessory) = p.equippedAcce.fInd Else iArrInd(pInd.accessory) = p.equippedAcce.mInd
            Else
                If Not p.equippedAcce.mInd Is Nothing Then iArrInd(pInd.accessory) = p.equippedAcce.mInd Else iArrInd(pInd.accessory) = p.equippedAcce.fInd
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
    Public Sub compressBreasts()
        Dim p As Player
        If ent.GetType Is GetType(Player) Then
            p = CType(ent, Player)
        Else
            Exit Sub
        End If

        Select Case p.breastSize
            Case -1
                setIAInd(pInd.chest, 0, True, False)
            Case 0
                setIAInd(pInd.chest, 1, True, False)
            Case 1
                setIAInd(pInd.chest, 9, True, False)
            Case 2
                setIAInd(pInd.chest, 10, True, False)
            Case 3
                setIAInd(pInd.chest, 11, True, False)
            Case 4
                setIAInd(pInd.chest, 12, True, False)
            Case 5
                setIAInd(pInd.chest, 13, True, False)
            Case 6
                setIAInd(pInd.chest, 14, True, False)
            Case 7
                setIAInd(pInd.chest, 15, True, False)
        End Select
    End Sub
    Public Sub getNaked()
        Dim p As Player
        If ent.GetType Is GetType(Player) Then
            p = CType(ent, Player)
        Else
            Exit Sub
        End If

        Equipment.equipArmor("Naked", False)
        Game.pushLstLog("Your clothes don't fit!")
    End Sub
    Public Sub notcompress()
        Dim p As Player
        If ent.GetType Is GetType(Player) Then
            p = CType(ent, Player)
        Else
            Exit Sub
        End If

        Select Case p.breastSize
            Case -1
                setIAInd(pInd.chest, 0, True, False)
            Case 0
                setIAInd(pInd.chest, 1, True, False)
            Case 1
                setIAInd(pInd.chest, 2, True, False)
            Case 2
                setIAInd(pInd.chest, 3, True, False)
            Case 3
                setIAInd(pInd.chest, 4, True, False)
            Case 4
                setIAInd(pInd.chest, 5, True, False)
            Case 5
                setIAInd(pInd.chest, 6, True, False)
            Case 6
                setIAInd(pInd.chest, 7, True, False)
            Case 7
                setIAInd(pInd.chest, 8, True, False)
        End Select
    End Sub

    'gets the player's current sexBool
    Public Function sexBool() As Boolean

        Dim p As Player
        If Not ent Is Nothing AndAlso ent.GetType Is GetType(Player) Then
            p = CType(ent, Player)
        Else
            Return (iArrInd(pInd.body).Item2)
        End If

        If iArrInd(pInd.genitalia).Item1 = -1 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
