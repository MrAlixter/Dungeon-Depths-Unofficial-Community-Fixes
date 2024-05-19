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
    clothesbtm      '9
    chest           '10
    clothes         '11
    face            '12
    blush           '13
    facemark        '14
    midhair         '15
    ears            '16
    nose            '17
    mouth           '18
    eyes            '19
    eyebrows        '20
    glasses         '21
    cloak           '22
    accessory       '23
    horns           '24
    fronthair       '25
    hat             '26
End Enum
Public Enum RENDER_MODE
    half
    full
End Enum
Public Class Portrait
    Public Const NUM_IMG_LAYERS As Integer = 26
    Protected Friend Shared STARTING_INDEX() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0} 'the starting indexes of each catagory
    Protected Friend Shared SKIP_RECOLOR_REARHAIR_INDS() As Integer = {25, 26, 32, 34, 35, 36}
    Protected Friend Shared SKIP_RECOLOR_MIDHAIR_INDS() As Integer = {28, 29, 38, 40, 41, 42}
    Protected Friend Shared SKIP_RECOLOR_FRONTHAIR_INDS() As Integer = {26, 27, 36, 38, 39, 40}

    Public ent As Entity

    Public iArr(NUM_IMG_LAYERS) As Bitmap
    Public iArrInd(NUM_IMG_LAYERS) As Tuple(Of Integer, Boolean, Boolean)

    Public haircolor As Color = Color.FromArgb(255, 204, 203, 213)
    Public skincolor As Color = Color.FromArgb(255, 247, 219, 195)
    Public Shared backcolor As Color = Color.FromArgb(255, 32, 34, 38)

    Public renderMode As RENDER_MODE = RENDER_MODE.full

    Public Shared imgLib As ImageCollection
    Public Shared ol_img_lib As OneLayerImageCollection
    Public Shared nullImg As Image

    Shared Sub New()
        imgLib = New ImageCollection(1)
        ol_img_lib = New OneLayerImageCollection()
        nullImg = imgLib.atrs(pInd.clothes).getAt(New Tuple(Of Integer, Boolean, Boolean)(5, False, True))
    End Sub

    Sub New(ByVal sex As Boolean, ByRef e As Entity)
        For i = 0 To Portrait.NUM_IMG_LAYERS
            iArrInd(i) = New Tuple(Of Integer, Boolean, Boolean)(STARTING_INDEX(i), sex, False)
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

    '| - PREPARATION - |
    Public Sub setIArr()
        'Dim startTime As Double = DDDateTime.getTimeNow()

        For i = 0 To Portrait.NUM_IMG_LAYERS
            If Not (checkNDefFemInd(pInd.clothes, 47) Or checkNDefMalInd(pInd.clothes, 5)) And i = pInd.genitalia Then
                iArr(i) = nullImg
                Continue For
            End If

            Try
                iArr(i) = imgLib.atrs(i).getAt(iArrInd(i))
            Catch ex As Exception
                iArr(i) = nullImg
                DDError.portraitCreationError(i)
            End Try
        Next

        changeHairColor(haircolor)
        changeSkinColor(skincolor)

        resolveLayerConflicts()
        lustBlushUpdate()

        hideEars()
        hideRearHair()

        If Not ent Is Nothing AndAlso Not ent.getPlayer Is Nothing Then
            hoodsAndCloaks()
            clothingLayerClipping()

            If ent.getPlayer.perks(perk.hidehat) > 0 And iArrInd(pInd.hat).Item1 > 0 Then
                iArr(pInd.hat) = nullImg
                changeHairColor(haircolor)
                changeSkinColor(skincolor)
                hideEars()
                iArr(pInd.hairacc) = imgLib.atrs(pInd.mouth).getAt(iArrInd(pInd.hairacc))
            End If

            If ent.getPlayer.equippedArmor.hide_dick Or ent.getPlayer.equippedAcce.hide_dick Then
                iArr(pInd.genitalia) = nullImg
            End If

            If ent.getPlayer.perks(perk.lurk) > 0 Then
                iArr(NUM_IMG_LAYERS) = shrub()
            End If

            If ent.getPlayer.className.Equals("Mindless") And Not ent.getPlayer.isPetrified Then
                If sexBool() Then
                    iArr(pInd.eyes) = imgLib.atrs(pInd.eyes).getAt(New Tuple(Of Integer, Boolean, Boolean)(33, True, True))
                    If Not ent.getPlayer.equippedAcce.hide_mouth Then iArr(pInd.mouth) = imgLib.atrs(pInd.mouth).getAt(New Tuple(Of Integer, Boolean, Boolean)(16, True, True))
                Else
                    iArr(pInd.eyes) = imgLib.atrs(pInd.eyes).getAt(New Tuple(Of Integer, Boolean, Boolean)(10, False, True))
                    If Not ent.getPlayer.equippedAcce.hide_mouth Then iArr(pInd.mouth) = imgLib.atrs(pInd.mouth).getAt(New Tuple(Of Integer, Boolean, Boolean)(6, False, True))
                End If
            ElseIf ent.getPlayer.className.Equals("Mindless Bimbo") And Not ent.getPlayer.isPetrified Then
                iArr(pInd.eyes) = imgLib.atrs(pInd.eyes).getAt(New Tuple(Of Integer, Boolean, Boolean)(68, True, True))
                If Not ent.getPlayer.equippedAcce.hide_mouth Then iArr(pInd.mouth) = imgLib.atrs(pInd.mouth).getAt(New Tuple(Of Integer, Boolean, Boolean)(36, True, True))
            End If
        End If

        'Dim endTime = DDDateTime.getTimeNow()
        'Console.WriteLine("setIArr RENDER TIME (" + renderMode.ToString + "): " + (endTime - startTime).ToString())
    End Sub
    Sub resolveLayerConflicts()
        If ent Is Nothing OrElse ent.getPlayer Is Nothing Then Exit Sub

        Dim acce = ent.getPlayer().equippedAcce
        Dim armor = ent.getPlayer().equippedArmor
        Dim glasses = ent.getPlayer().equippedGlasses

        If acce.under_t_clothes Then
            iArr(pInd.clothes) = CreateFullBodyBMP({CharacterGenerator.picPort.Image, iArr(pInd.face), iArr(pInd.accessory), iArr(pInd.clothes)})
            iArr(pInd.face) = CharacterGenerator.picPort.Image
            iArr(pInd.accessory) = CharacterGenerator.picPort.Image
        End If

        If acce.under_chin Then
            iArr(pInd.clothes) = CreateFullBodyBMP({CharacterGenerator.picPort.Image, iArr(pInd.clothes), iArr(pInd.accessory), iArr(pInd.face)})
            iArr(pInd.face) = CharacterGenerator.picPort.Image
            iArr(pInd.accessory) = CharacterGenerator.picPort.Image
        End If

        If acce.hide_mouth Then
            iArr(pInd.mouth) = CharacterGenerator.picPort.Image
        End If

        If acce.hide_eyes Then
            iArr(pInd.eyes) = CharacterGenerator.picPort.Image
        End If

        Dim hatMask As Image = If(iArrInd(pInd.hat).Item1 = 0, imgLib.atrs(pInd.hat).getAt(armor.hood), imgLib.atrs(pInd.hat).getAt(iArrInd(pInd.hat)))
        If Not hatMask Is Nothing AndAlso Not hatMask.Equals(nullImg) Then
            iArr(pInd.rearhair) = hoodHairMask(iArr(pInd.rearhair), hatMask, 150, True)
            iArr(pInd.midhair) = hoodHairMask(iArr(pInd.midhair), hatMask)
            iArr(pInd.fronthair) = hoodHairMask(iArr(pInd.fronthair), hatMask, 150, True)
        End If

        If armor.adjust_sleeve_layer And renderMode <> RENDER_MODE.half Then
            iArr(pInd.clothes) = topClothesMask(iArr(pInd.clothes), iArr(pInd.clothesbtm), getMaskInitialY(ent.getPlayer.breastSize, armor.compress_breast))
        End If

        If (acce.under_b_clothes And renderMode <> RENDER_MODE.half) Or acce.under_b_clothes_halfoverride Then
            iArr(pInd.clothesbtm) = CreateFullBodyBMP({CharacterGenerator.picPort.Image, iArr(pInd.accessory), iArr(pInd.clothesbtm)})
            iArr(pInd.accessory) = CharacterGenerator.picPort.Image
        End If

        If armor.swap_gen_clothesbtm And renderMode <> RENDER_MODE.half Then
            Dim t = iArr(pInd.clothesbtm).Clone
            iArr(pInd.clothesbtm) = iArr(pInd.genitalia).Clone
            iArr(pInd.genitalia) = t
        End If

        If Not acce.under_chin AndAlso Not acce.under_t_clothes AndAlso Not acce.under_b_clothes AndAlso Not acce.under_b_clothes_halfoverride AndAlso glasses.over_acce Then
            iArr(pInd.accessory) = CreateFullBodyBMP({CharacterGenerator.picPort.Image, iArr(pInd.accessory), iArr(pInd.glasses)})
            iArr(pInd.glasses) = CharacterGenerator.picPort.Image
        End If
    End Sub

    '| - MASKING - |
    Shared Function hoodHairMask(ByRef img As Image, ByRef c_mask As Image, Optional ByVal final_y As Integer = 150, Optional ByVal frontHairMask As Boolean = False) As Bitmap
        'Assumes that the two images are the same size
        If img Is Nothing OrElse c_mask Is Nothing OrElse Not img.Size.Equals(c_mask.Size) Then Return img

        Dim bmp As Bitmap = New Bitmap(img)
        Dim b_c_mask As Bitmap = New Bitmap(c_mask)

        Dim clear = Color.FromArgb(0, 0, 0, 0)

        For y = 0 To final_y
            For x = 0 To bmp.Size.Width - 1
                If b_c_mask.GetPixel(x, y).A > 0 AndAlso (Not frontHairMask Or b_c_mask.GetPixel(x, y).A = 1) Then
                    bmp.SetPixel(x, y, clear)
                End If
            Next
        Next

        Return bmp
    End Function
    Shared Function topClothesMask(ByRef img As Image, ByRef c_mask As Image, Optional ByVal initial_y As Integer = 265) As Bitmap
        'Assumes that the two images are the same size
        If img Is Nothing OrElse c_mask Is Nothing OrElse Not img.Size.Equals(c_mask.Size) Then Return img

        Dim bmp As Bitmap = New Bitmap(img)
        Dim b_c_mask As Bitmap = New Bitmap(c_mask)

        Dim clear = Color.FromArgb(0, 0, 0, 0)

        For y = initial_y To bmp.Size.Height - 1
            For x = 0 To bmp.Size.Width - 1
                If b_c_mask.GetPixel(x, y).A > 0 Then
                    bmp.SetPixel(x, y, clear)
                End If
            Next
        Next

        Return bmp
    End Function
    Shared Function getMaskInitialY(ByVal bsize As Integer, ByVal compress As Boolean)
        Select Case bsize
            Case 4
                If compress Then Return 265 Else Return 268
            Case 5
                If compress Then Return 268 Else Return 277
            Case 6
                If compress Then Return 275 Else Return 287
            Case 7
                If compress Then Return 284 Else Return 296
        End Select

        Return 260
    End Function

    '| - BODY LAYERS - |
    Sub hideEars()
        If checkNDefFemInd(pInd.midhair, 41) Or
           (Not ent Is Nothing AndAlso Not ent.getPlayer Is Nothing AndAlso Not ent.getPlayer.equippedArmor Is Nothing AndAlso Not ent.getPlayer.equippedArmor.hood Is Nothing AndAlso (checkFemInd(pInd.ears, 2) Or checkMalInd(pInd.ears, 2))) Then

            iArr(pInd.ears) = nullImg
            Exit Sub
        End If

        Dim mEarIndToNotHide = {1, 2}
        Dim fEarIndToNotHide = {1, 2}

        Dim mHairIndToNotHide = {1, 3, 4}
        Dim fHairIndToNotHide = {8, 11, 12}


        If iArr(pInd.midhair) Is Nothing Then iArr(pInd.midhair) = nullImg
        If iArr(pInd.ears) Is Nothing Then iArr(pInd.ears) = nullImg

        If checkFemInd(pInd.ears, fEarIndToNotHide) Or
           checkFemInd(pInd.midhair, fHairIndToNotHide) Or
           checkMalInd(pInd.ears, mEarIndToNotHide) Or
           checkMalInd(pInd.midhair, mHairIndToNotHide) Then Exit Sub

        Dim t = iArr(pInd.midhair).Clone
        iArr(pInd.midhair) = iArr(pInd.ears).Clone
        iArr(pInd.ears) = t
    End Sub
    Sub colorEars(ByVal c As Color)
        Dim recolorFunction = If(Not ent Is Nothing AndAlso Not ent.getPlayer Is Nothing AndAlso ent.getPlayer.isPetrified, Function(img, clr) petrificationRecolor(img, clr), Function(img, clr) skinRecolor(img, clr))

        If Not ent Is Nothing AndAlso Not ent.getPlayer Is Nothing Then
            Dim armor = ent.getPlayer().equippedArmor
            Dim hatMask As Image = If(iArrInd(pInd.hat).Item1 = 0, imgLib.atrs(pInd.hat).getAt(armor.hood), imgLib.atrs(pInd.hat).getAt(iArrInd(pInd.hat)))
            If Not hatMask Is Nothing AndAlso Not hatMask.Equals(nullImg) Then
                iArr(pInd.ears) = hoodHairMask(iArr(pInd.ears), hatMask, 150, True)
            End If
        End If

        If (Not checkMalInd(pInd.ears, 1) And Not checkFemInd(pInd.ears, 1) And
           Not checkMalInd(pInd.ears, 2) And Not checkFemInd(pInd.ears, 2) And
           Not checkMalInd(pInd.ears, 4) And Not checkFemInd(pInd.ears, 4) And
           Not checkNDefFemInd(pInd.ears, 7) And
           Not checkNDefFemInd(pInd.ears, 9) And
           Not checkNDefFemInd(pInd.ears, 10) And
           Not checkNDefFemInd(pInd.ears, 11) And
           Not checkNDefFemInd(pInd.ears, 13) And
           Not checkNDefFemInd(pInd.ears, 15) And
           Not checkNDefMalInd(pInd.ears, 6)) Or (Not ent Is Nothing AndAlso Not ent.getPlayer Is Nothing AndAlso ent.getPlayer.isPetrified) Then
            iArr(pInd.ears) = recolorFunction(imgLib.atrs(pInd.ears).getAt(iArrInd(pInd.ears)), c)
        End If
    End Sub
    Sub bodyOverlay()
        Dim p As Player
        If Not ent Is Nothing AndAlso ent.GetType Is GetType(Player) Then
            p = CType(ent, Player)
        Else
            Exit Sub
        End If

        If Not p.pForm.getOverlayU(p).Item1 = 0 Then iArrInd(pInd.bodyoverlay) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False) : Exit Sub

        If p.className.Equals("Warrior") Or p.className.Equals("Barbarian") Or p.className.Equals("Paladin") Or p.className.Equals("Amazon") Or p.className.Contains("Valkyrie") Or p.className.Equals("Pirate") Or
         p.formName.Equals("Tigress") Or p.formName.Equals("Orc") Then
            Select Case p.breastSize
                Case -1, -2
                    iArrInd(pInd.bodyoverlay) = New Tuple(Of Integer, Boolean, Boolean)(1, True, False)
                Case 0
                    iArrInd(pInd.bodyoverlay) = New Tuple(Of Integer, Boolean, Boolean)(2, True, False)
                Case Else
                    iArrInd(pInd.bodyoverlay) = New Tuple(Of Integer, Boolean, Boolean)(3, True, False)
            End Select
        ElseIf p.formName.Equals("Minotaur Bull") Then
            Select Case p.breastSize
                Case -1, 2
                    iArrInd(pInd.bodyoverlay) = New Tuple(Of Integer, Boolean, Boolean)(4, True, False)
                Case 0
                    iArrInd(pInd.bodyoverlay) = New Tuple(Of Integer, Boolean, Boolean)(2, True, False)
                Case Else
                    iArrInd(pInd.bodyoverlay) = New Tuple(Of Integer, Boolean, Boolean)(3, True, False)
            End Select
        Else
            iArrInd(pInd.bodyoverlay) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        End If

        spiderBody()

        p.dsizeroute()
    End Sub

    '| - CLOTHING LAYERS - |
    Sub hideRearHair()
        If checkNDefFemInd(pInd.hat, 9) Then
            iArr(pInd.rearhair) = imgLib.atrs(pInd.hat).getAt(New Tuple(Of Integer, Boolean, Boolean)(10, True, True))

        ElseIf checkNDefFemInd(pInd.hat, 11) Then
            iArr(pInd.rearhair) = imgLib.atrs(pInd.hat).getAt(New Tuple(Of Integer, Boolean, Boolean)(12, True, True))

        ElseIf checkFemInd(pInd.hat, 1) Or checkNDefFemInd(pInd.hat, 17) Then
            iArr(pInd.rearhair) = CreateFullBodyBMP({nullImg, imgLib.atrs(pInd.hat).getAt(New Tuple(Of Integer, Boolean, Boolean)(15, True, True)), iArr(pInd.rearhair)})

        ElseIf checkFemInd(pInd.hat, 3) Or checkNDefFemInd(pInd.hat, 18) Then
            iArr(pInd.rearhair) = CreateFullBodyBMP({nullImg, imgLib.atrs(pInd.hat).getAt(New Tuple(Of Integer, Boolean, Boolean)(16, True, True)), iArr(pInd.rearhair)})

        ElseIf checkMalInd(pInd.hat, 2) Or checkNDefFemInd(pInd.hat, 18) Then
            iArr(pInd.rearhair) = CreateFullBodyBMP({nullImg, imgLib.atrs(pInd.hat).getAt(New Tuple(Of Integer, Boolean, Boolean)(16, True, True)), iArr(pInd.rearhair)})

        ElseIf checkMalInd(pInd.hat, 5) Or checkFemInd(pInd.hat, 4) Then
            iArr(pInd.rearhair) = CreateFullBodyBMP({nullImg, imgLib.atrs(pInd.hairacc).getAt(New Tuple(Of Integer, Boolean, Boolean)(29, True, False)), iArr(pInd.rearhair)})

        ElseIf checkMalInd(pInd.hat, 8) Or checkFemInd(pInd.hat, 10) Then
            iArr(pInd.rearhair) = CreateFullBodyBMP({nullImg, imgLib.atrs(pInd.hairacc).getAt(New Tuple(Of Integer, Boolean, Boolean)(30, True, False))})

        ElseIf checkNDefFemInd(pInd.accessory, 14) Or checkNDefMalInd(pInd.accessory, 13) Then
            iArr(pInd.rearhair) = nullImg
        End If
    End Sub
    Sub hoodsAndCloaks()
        If ent.getPlayer.equippedArmor.hide_rearhair Then
            iArr(pInd.rearhair) = nullImg
        End If

        If Not ent.getPlayer.equippedArmor.hood Is Nothing Then
            iArr(pInd.hat) = CreateFullBodyBMP({nullImg, imgLib.atrs(pInd.hat).getAt(ent.getPlayer.equippedArmor.hood), imgLib.atrs(pInd.hat).getAt(iArrInd(pInd.hat))})
            iArr(pInd.hairacc) = nullImg
        End If

        If Not ent.getPlayer.equippedArmor.cloak Is Nothing Then
            iArr(pInd.wings) = CreateFullBodyBMP({nullImg, iArr(pInd.wings), imgLib.atrs(pInd.hairacc).getAt(ent.getPlayer.equippedArmor.getCloak(ent.getPlayer))})
        End If
    End Sub
    Sub clothingLayerClipping()
        If ent.getPlayer.equippedArmor.getAName.Equals(MagGirlOutfitC.ITEM_NAME) Then
            Select Case ent.getPlayer.breastSize
                Case 4
                    iArr(pInd.clothes) = CreateFullBodyBMP({iArr(pInd.clothes), imgLib.atrs(pInd.hairacc).getAt(31)})
                Case 5
                    iArr(pInd.clothes) = CreateFullBodyBMP({iArr(pInd.clothes), imgLib.atrs(pInd.hairacc).getAt(32)})
                Case 6
                    iArr(pInd.clothes) = CreateFullBodyBMP({iArr(pInd.clothes), imgLib.atrs(pInd.hairacc).getAt(33)})
            End Select
        End If
    End Sub

    '| - OTHER LAYERS - |
    Public Sub lustBlushUpdate()
        If ent Is Nothing OrElse ent.getPlayer Is Nothing Then
            iArr(pInd.blush) = nullImg
            Exit Sub
        End If

        Select Case Int(ent.lust / 20)
            Case 0
                iArr(pInd.blush) = nullImg
            Case 1
                iArr(pInd.blush) = Game.picLust1.BackgroundImage
            Case 2
                iArr(pInd.blush) = Game.picLust2.BackgroundImage
            Case 3
                iArr(pInd.blush) = Game.picLust3.BackgroundImage
            Case Else
                iArr(pInd.blush) = Game.picLust4.BackgroundImage
        End Select
    End Sub
    Sub spiderBody()
        If Not iArrInd(pInd.tail) Is Nothing AndAlso iArrInd(pInd.tail).Item1 = 2 Then
            iArr(pInd.clothesbtm) = CreateFullBodyBMP({iArr(pInd.clothesbtm), imgLib.atrs(pInd.horns).getAt(6)})
        End If
    End Sub
    Function shrub() As Image
        Return CreateFullBodyBMP({imgLib.atrs(pInd.bkg).getAt(1), imgLib.atrs(pInd.bodyoverlay).getAt(5), imgLib.atrs(pInd.eyes).getAt(iArrInd(pInd.eyes))})
    End Function

    '| - DRAW - |
    Shared Function CreateBMP(ByRef img() As Image, Optional ByVal drawBoarder As Boolean = True) As Bitmap
        Dim startTime As Double = DDDateTime.getTimeNow()
        Dim bmp As New Bitmap(146, 216)
        Dim g As Graphics = Graphics.FromImage(bmp)

        If img(0).Size.Height < 300 Then g.DrawImage(img(0), 0, 0, 146, 216) Else g.DrawImage(img(0), 0, 0, 144, 144)
        For i = 1 To UBound(img)
            If img(i) Is Nothing Then img(i) = CharacterGenerator.picPort.Image
            g.DrawImage(img(i), getRelativeX(img(i).Size, False), getRelativeY(img(i).Size, False), getRelativeSizeX(img(i).Size), getRelativeSizeY(img(i).Size))
        Next
        If drawBoarder Then g.DrawImage(Game.picPortOutline.BackgroundImage, 0, 0, 146, 216)

        Dim endTime = DDDateTime.getTimeNow()
        Console.WriteLine("HBPRT RENDER TIME: " + (endTime - startTime).ToString())
        Return bmp
    End Function
    Shared Function CreateBMPFast(ByRef img() As Image, Optional ByVal drawBoarder As Boolean = True) As Bitmap
        'Dim startTime As Double = DDDateTime.getTimeNow()
        Dim bmp As New Bitmap(146, 216)

        Dim cachedPixels(bmp.Height, bmp.Width) As Integer

        For i = UBound(img) To 0 Step -1
            If img(i) Is Nothing Then img(i) = CharacterGenerator.picPort.Image
            fastDraw(bmp, img(i), getRelativeX(img(i).Size, False), getRelativeY(img(i).Size, False), getRelativeSizeX(img(i).Size), getRelativeSizeY(img(i).Size), cachedPixels)
        Next

        Dim g As Graphics = Graphics.FromImage(bmp)
        If drawBoarder Then g.DrawImage(Game.picPortOutline.BackgroundImage, 0, 0, 146, 216)

        'Dim endTime = DDDateTime.getTimeNow()
        'Console.WriteLine("HBPRT RENDER TIME: (FAST)" + (endTime - startTime).ToString())
        Return bmp
    End Function
    Shared Sub fastDraw(ByRef bkg As Bitmap, ByRef img As Bitmap, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer, ByRef cachedPixels As Integer(,))
        If Not img.Height = h Or Not img.Width = w Then img = New Bitmap(img, New Size(New Point(w, h)))

        For j = 0 To bkg.Height - 1
            For i = 0 To bkg.Width - 1
                If cachedPixels(j, i) = 1 Then Continue For
                If x + i < 0 Or x + i > w - 1 Then Continue For
                If y + j < 0 Or y + j > h - 1 Then Continue For

                Dim c = img.GetPixel(x + i, y + j)
                If c.A > 0 And Not DDUtils.cEquals(c, backcolor) Then
                    bkg.SetPixel(i, j, c)
                    cachedPixels(j, i) = 1
                End If
            Next
        Next
    End Sub
    Shared Function CreateFullBodyBMP(ByRef img() As Image) As Bitmap
        'Dim startTime As Double = DDDateTime.getTimeNow()

        Dim bmp As New Bitmap(164, 610)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.DrawImage(img(0), 0, 0, 164, 610)
        For i = 1 To UBound(img)
            If img(i) Is Nothing Then img(i) = CharacterGenerator.picPort.Image
            g.DrawImage(img(i), getRelativeX(img(i).Size, True), getRelativeY(img(i).Size, True), getRelativeSizeX(img(i).Size), getRelativeSizeY(img(i).Size))
        Next

        'Dim endTime = DDDateTime.getTimeNow()
        'Console.WriteLine("FBPRT RENDER TIME: " + (endTime - startTime).ToString())
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
    Shared Function getRelativeSizeX(ByVal s As Size)
        If s.Height <= 200 Then
            Return 144
        ElseIf s.Height <= 300 Then
            Return 146
        Else
            Return 164
        End If
    End Function
    Shared Function getRelativeSizeY(ByVal s As Size)
        If s.Height <= 200 Then
            Return 144
        ElseIf s.Height <= 300 Then
            Return 216
        Else
            Return 610
        End If
    End Function

    '| - MISC. - |
    Public Function sexBool() As Boolean
        If Not ent Is Nothing AndAlso ent.GetType() Is GetType(Player) Then
            If CType(ent, Player).dickSize = -1 Then
                Return True
            Else
                Return False
            End If
        End If

        If iArrInd(pInd.genitalia).Item1 = 4 Then
            Return True
        Else
            Return False
        End If
    End Function
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
        '| - Classes - |
        If pClass.Equals("Magical Girl​") Then
            Return ol_img_lib.getImg(0)
        ElseIf pClass.Equals("Valkyrie​") Then
            Return ol_img_lib.getImg(26)
        ElseIf pClass.Equals("Princess​") Then
            Return ol_img_lib.getImg(5)
        ElseIf pClass.Equals("Thong") Then
            Return ol_img_lib.getImg(18)
        ElseIf pClass.Equals("Thong​") Then
            Return ol_img_lib.getImg(19)
        ElseIf pClass.Equals("Fae Bee") Then
            Return ol_img_lib.getImg(24)
        ElseIf pClass.Equals("Fae Bee​") Then
            Return ol_img_lib.getImg(25)
        ElseIf pClass.Equals("Bunny Girl​") Then
            Return ol_img_lib.getImg(4)
        ElseIf pClass.Equals("Cynn Onahole") Then
            Return ol_img_lib.getImg(27)
        ElseIf pClass.Equals("Onahole") Then
            Return ol_img_lib.getImg(28)
        End If

        '| - Forms - |
        If pForm.Equals("Dragon") And Not sexBool() Then
            Return ol_img_lib.getImg(1)
        ElseIf pForm.Equals("Dragon") And sexBool() Then
            Return ol_img_lib.getImg(2)
        ElseIf pForm.Equals("Sheep") Then
            Return ol_img_lib.getImg(7)
        ElseIf pForm.Equals("Cake") Then
            Return ol_img_lib.getImg(3)
        ElseIf pForm.Equals("Frog") Then
            Return ol_img_lib.getImg(6)
        ElseIf pForm.Equals("Half-Dragoness") Then
            Return ol_img_lib.getImg(16)
        ElseIf pForm.Equals("Half-Broodmother") Then
            Return ol_img_lib.getImg(17)
        ElseIf pForm.Equals("Broodmother") Then
            Return ol_img_lib.getImg(15)
        ElseIf pForm.Equals("Horse") Then
            Return ol_img_lib.getImg(11)
        ElseIf pForm.Equals("Unicorn") Then
            Return ol_img_lib.getImg(12)
        ElseIf pForm.Equals("Oni") Then
            Return ol_img_lib.getImg(13)
        ElseIf pForm.Equals("Blob") And Not sexBool() Then
            Return ol_img_lib.getImg(9)
        ElseIf pForm.Equals("Blob") And sexBool() Then
            Return ol_img_lib.getImg(10)
        ElseIf pForm.Equals("Faerie (B)") Then
            Return ol_img_lib.getImg(22)
        ElseIf pForm.Equals("Cow") Then
            Return ol_img_lib.getImg(30)
        ElseIf pForm.Equals("Blow-Up Cynn") Then
            Return ol_img_lib.getImg(29)
        End If

        Return Nothing
    End Function
    Public Function drawFull()
        renderMode = RENDER_MODE.full
        'portraitUDate()

        setIArr()

        Return CreateFullBodyBMP(iArr)
    End Function
    Public Function draw()
        renderMode = RENDER_MODE.half
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
        renderMode = RENDER_MODE.half

        If solFlag Then Return Game.picPortrait.BackgroundImage

        If Not oneLayerImgCheck(pForm, pClass) Is Nothing Then Return CreateBMP({iArr(pInd.bkg), oneLayerImgCheck(pForm, pClass)})

        If Not solFlag Then portraitUDate()

        setIArr()
        Return CreateBMP(iArr)
    End Function

    Public Sub changeHairColor(ByVal c As Color)
        haircolor = c

        If Not checkNDefFemInd(pInd.rearhair, SKIP_RECOLOR_REARHAIR_INDS) Then iArr(pInd.rearhair) = Portrait.hairRecolor(imgLib.atrs(pInd.rearhair).getAt(iArrInd(pInd.rearhair)), c)
        If Not checkNDefFemInd(pInd.midhair, SKIP_RECOLOR_MIDHAIR_INDS) And Not checkNDefMalInd(pInd.midhair, 5) Then iArr(pInd.midhair) = Portrait.hairRecolor(imgLib.atrs(pInd.midhair).getAt(iArrInd(pInd.midhair)), c)
        iArr(pInd.eyebrows) = Portrait.hairRecolor(imgLib.atrs(pInd.eyebrows).getAt(iArrInd(pInd.eyebrows)), c)
        If Not checkNDefFemInd(pInd.fronthair, SKIP_RECOLOR_FRONTHAIR_INDS) And Not checkNDefMalInd(pInd.fronthair, 6) Then iArr(pInd.fronthair) = Portrait.hairRecolor(imgLib.atrs(pInd.fronthair).getAt(iArrInd(pInd.fronthair)), c)

        If checkFemInd(pInd.wings, 10) Then iArr(pInd.wings) = Portrait.hairRecolor(imgLib.atrs(pInd.wings).getAt(iArrInd(pInd.wings)), DDUtils.cShift(c, Color.White, 75))

        If Not ent Is Nothing AndAlso Not ent.getPlayer Is Nothing AndAlso ent.getPlayer.isPetrified Then
            iArr(pInd.eyes) = Portrait.hairRecolor(imgLib.atrs(pInd.eyes).getAt(iArrInd(pInd.eyes)), skincolor)
            iArr(pInd.mouth) = Portrait.hairRecolor(imgLib.atrs(pInd.mouth).getAt(iArrInd(pInd.mouth)), skincolor)
            iArr(pInd.nose) = Portrait.hairRecolor(imgLib.atrs(pInd.nose).getAt(iArrInd(pInd.nose)), skincolor)
        End If
    End Sub
    Public Sub changeSkinColor(ByVal c As Color)
        skincolor = c

        bodyOverlay()

        Dim recolorFunction = If(Not ent Is Nothing AndAlso Not ent.getPlayer Is Nothing AndAlso ent.getPlayer.isPetrified, Function(img, clr) petrificationRecolor(img, clr), Function(img, clr) skinRecolor(img, clr))

        Dim p = If((Not ent Is Nothing AndAlso ent.GetType Is GetType(Player)), CType(ent, Player), Nothing)

        If c.A = 255 Then
            '| -- Body -- |
            iArr(pInd.body) = recolorFunction(imgLib.atrs(pInd.body).getAt(iArrInd(pInd.body)), c)
            If Not p Is Nothing AndAlso Not p.pForm.getOverlayU(p).Item1 = 0 Then
                Dim form_overlay As Image = imgLib.atrs(pInd.bodyoverlay).getAt(p.pForm.getOverlayU(p))
                If p.isPetrified Then form_overlay = recolorFunction(form_overlay, c)
                iArr(pInd.body) = CreateFullBodyBMP({nullImg, iArr(pInd.body), form_overlay})
            End If

            '| -- Chest -- |
            iArr(pInd.chest) = recolorFunction(imgLib.atrs(pInd.chest).getAt(iArrInd(pInd.chest)), c)
            If Not p Is Nothing AndAlso Not p.pForm.getOverlayB(p).Item1 = 0 Then
                Dim form_overlay As Image = imgLib.atrs(pInd.bodyoverlay).getAt(p.pForm.getOverlayB(p))
                If p.isPetrified Then form_overlay = recolorFunction(form_overlay, c)
                iArr(pInd.chest) = CreateFullBodyBMP({nullImg, iArr(pInd.chest), form_overlay})
            End If

            '| -- Shoulders -- |
            iArr(pInd.shoulders) = recolorFunction(imgLib.atrs(pInd.shoulders).getAt(iArrInd(pInd.shoulders)), c)
            If Not p Is Nothing AndAlso Not p.pForm.getOverlayS(p).Item1 = 0 Then
                Dim form_overlay As Image = imgLib.atrs(pInd.bodyoverlay).getAt(p.pForm.getOverlayS(p))
                If p.isPetrified Then form_overlay = recolorFunction(form_overlay, c)
                iArr(pInd.shoulders) = CreateFullBodyBMP({nullImg, iArr(pInd.shoulders), form_overlay})
            End If

            '| -- Main Body Overlay -- |
            iArr(pInd.bodyoverlay) = recolorFunction(imgLib.atrs(pInd.bodyoverlay).getAt(iArrInd(pInd.bodyoverlay)), c)
        Else
            'If the transparancy is less than complete, combine all body layers before recoloring
            Dim bImg = CreateFullBodyBMP({imgLib.atrs(pInd.body).getAt(iArrInd(pInd.body)), imgLib.atrs(pInd.bodyoverlay).getAt(iArrInd(pInd.bodyoverlay)),
                                          imgLib.atrs(pInd.shoulders).getAt(iArrInd(pInd.shoulders)), imgLib.atrs(pInd.chest).getAt(iArrInd(pInd.chest))})
            iArr(pInd.body) = recolorFunction(bImg, c)
            iArr(pInd.chest) = nullImg
            iArr(pInd.shoulders) = nullImg
            iArr(pInd.bodyoverlay) = nullImg
        End If

        '| -- ;) -- |
        If renderMode <> RENDER_MODE.half Then iArr(pInd.genitalia) = recolorFunction(imgLib.atrs(pInd.genitalia).getAt(iArrInd(pInd.genitalia)), c)

        '| -- Face -- |
        iArr(pInd.face) = recolorFunction(imgLib.atrs(pInd.face).getAt(iArrInd(pInd.face)), c)
        If Not p Is Nothing AndAlso Not p.pForm.getOverlayF(p).Item1 = 0 Then
            Dim form_overlay As Image = imgLib.atrs(pInd.bodyoverlay).getAt(p.pForm.getOverlayF(p))
            If p.isPetrified Then form_overlay = recolorFunction(form_overlay, c)
            iArr(pInd.face) = CreateFullBodyBMP({nullImg, iArr(pInd.face), form_overlay})
        End If

        '| -- Misc. -- |
        If Not p Is Nothing AndAlso p.isPetrified Then
            iArr(pInd.wings) = recolorFunction(iArr(pInd.wings), c)
            iArr(pInd.horns) = recolorFunction(iArr(pInd.horns), c)
            iArr(pInd.tail) = recolorFunction(iArr(pInd.tail), c)
        End If

        colorEars(c)
    End Sub

    Shared Function mkIAInd(ByVal i As Integer, ByVal fem As Boolean, ByVal non_def As Boolean) As Tuple(Of Integer, Boolean, Boolean)
        Return New Tuple(Of Integer, Boolean, Boolean)(i, fem, non_def)
    End Function
    Sub setIAInd(ByVal attrInd As pInd, ByVal i As Integer, ByVal fem As Boolean, ByVal non_def As Boolean)
        iArrInd(attrInd) = mkIAInd(i, fem, non_def)
    End Sub
    Sub setIAInd(ByVal attrInd As pInd, ByVal iaInd As Tuple(Of Integer, Boolean, Boolean))
        iArrInd(attrInd) = iaInd
    End Sub

    Function checkNDefFemInd(ByVal attrInd As pInd, ByVal i As Integer) As Boolean
        Dim ind = iArrInd(attrInd)
        If ind Is Nothing Then Return False
        If Not ind.Item2 Then Return False
        If imgLib.atrs(attrInd).rosf(ind.Item1) = i Then Return True Else Return False
    End Function
    Private Function checkNDefFemInd(ByVal attrInd As pInd, inds As Integer()) As Boolean
        For Each ind In inds
            If checkNDefFemInd(attrInd, ind) Then Return True
        Next

        Return False
    End Function
    Function checkNDefMalInd(ByVal attrInd As pInd, ByVal i As Integer) As Boolean
        Dim ind = iArrInd(attrInd)
        If ind Is Nothing Then Return False
        If ind.Item2 Or ind.Item3 Then Return False
        If imgLib.atrs(attrInd).rosm(ind.Item1) = i Then Return True Else Return False
    End Function
    Private Function checkNDefMalInd(ByVal attrInd As pInd, inds As Integer()) As Boolean
        For Each ind In inds
            If checkNDefMalInd(attrInd, ind) Then Return True
        Next

        Return False
    End Function
    Function checkFemInd(ByVal attrInd As pInd, ByVal i As Integer) As Boolean
        Dim ind = iArrInd(attrInd)
        If ind Is Nothing Then Return False
        If Not ind.Item2 Or ind.Item3 Then Return False
        If ind.Item1 = i Then Return True Else Return False
    End Function
    Private Function checkFemInd(ByVal attrInd As pInd, inds As Integer()) As Boolean
        For Each ind In inds
            If checkFemInd(attrInd, ind) Then Return True
        Next

        Return False
    End Function
    Function checkMalInd(ByVal attrInd As pInd, ByVal i As Integer) As Boolean
        Dim ind = iArrInd(attrInd)
        If ind Is Nothing Then Return False
        If ind.Item2 Or ind.Item3 Then Return False
        If ind.Item1 = i Then Return True Else Return False
    End Function
    Private Function checkMalInd(ByVal attrInd As pInd, inds As Integer()) As Boolean
        For Each ind In inds
            If checkMalInd(attrInd, ind) Then Return True
        Next

        Return False
    End Function
    Public Function Clone() As Portrait
        Dim prt As Portrait = New Portrait(sexBool, ent)

        prt.iArr = iArr.Clone
        prt.iArrInd = iArrInd.Clone

        prt.haircolor = haircolor
        prt.skincolor = skincolor

        prt.renderMode = renderMode

        Return prt
    End Function

    'hairRecolor changes the color of an image, assumed to be of the same base color as the player's hair 
    Shared Function hairRecolor(ByVal img As Bitmap, ByVal c As Color) As Image
        If img Is Nothing Then Return Nothing
        Dim cImg As Bitmap = img.Clone
        For x = 0 To img.Width - 1
            For y = 0 To img.Height - 1
                If Not img.GetPixel(x, y).A = 0 Then
                    Dim afactor As Double = (img.GetPixel(x, y).A / 255)
                    Dim rfactor As Double = (img.GetPixel(x, y).R / 203)
                    Dim gfactor As Double = (img.GetPixel(x, y).G / 204)
                    Dim bfactor As Double = (img.GetPixel(x, y).B / 213)

                    Dim A As Integer = (c.A * (afactor))
                    Dim R As Integer = (c.R * (rfactor))
                    Dim G As Integer = (c.G * (gfactor))
                    Dim B As Integer = (c.B * (bfactor))
                    If A > 255 Then A = 255
                    If R > 255 Then R = 255
                    If G > 255 Then G = 255
                    If B > 255 Then B = 255

                    Dim c1 As Color = Color.FromArgb(A, R, G, B)

                    cImg.SetPixel(x, y, c1)
                End If
            Next
        Next
        Return cImg
    End Function
    'skinRecolor changes the color of an image, assumed to be of the same base color as the player's skin
    Shared Function skinRecolor(ByVal img As Bitmap, ByVal c As Color) As Image
        If img Is Nothing Then Return Nothing
        Dim cImg As Bitmap = img.Clone
        For x = 0 To img.Width - 1
            For y = 0 To img.Height - 1
                If Not img.GetPixel(x, y).A = 0 Then 
                    Dim afactor As Double = (img.GetPixel(x, y).A / 255)
                    Dim rfactor As Double = (img.GetPixel(x, y).R / 249)
                    Dim gfactor As Double = (img.GetPixel(x, y).G / 220)
                    Dim bfactor As Double = (img.GetPixel(x, y).B / 195)

                    Dim A As Integer = (c.A * (afactor))
                    Dim R As Integer = (c.R * (rfactor))
                    Dim G As Integer = (c.G * (gfactor))
                    Dim B As Integer = (c.B * (bfactor))
                    If A > 255 Then A = 255
                    If R > 255 Then R = 255
                    If G > 255 Then G = 255
                    If B > 255 Then B = 255

                    Dim c1 As Color = Color.FromArgb(A, R, G, B)

                    cImg.SetPixel(x, y, c1)
                End If
            Next
        Next
        Return cImg
    End Function
    Shared Function petrificationRecolor(ByVal img As Bitmap, ByVal c As Color) As Image
        If img Is Nothing Then Return Nothing
        Dim cImg As Bitmap = img.Clone
        For x = 0 To img.Width - 1
            For y = 0 To img.Height - 1
                If Not img.GetPixel(x, y).A = 0 Then
                    Dim afactor As Double = (img.GetPixel(x, y).A / 255)
                    Dim rfactor As Double = (img.GetPixel(x, y).R / 249) '243
                    Dim gfactor As Double = (img.GetPixel(x, y).G / 220) '189
                    Dim bfactor As Double = (img.GetPixel(x, y).B / 195) '149

                    Dim avgfactor = (rfactor + gfactor + bfactor) / 3

                    Dim A As Integer = (c.A * (afactor))
                    Dim R As Integer = (c.R * (avgfactor))
                    Dim G As Integer = (c.G * (avgfactor))
                    Dim B As Integer = (c.B * (avgfactor))
                    If A > 255 Then A = 255
                    If R > 255 Then R = 255
                    If G > 255 Then G = 255
                    If B > 255 Then B = 255

                    Dim c1 As Color = Color.FromArgb(A, R, G, B)

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

        iArrInd(pInd.clothes) = p.equippedArmor.getClothesIMGTop(p)
        iArrInd(pInd.clothesbtm) = p.equippedArmor.getClothesIMGBtm(p)

        If Not p.equippedArmor.fits(p) Then
            getNaked()
        End If

        setBreastImage(p)

        If p.equippedAcce Is Nothing OrElse (p.equippedAcce.fInd Is Nothing And p.equippedAcce.mInd Is Nothing) Then
            p.equippedAcce = New noAcce()
        Else
            iArrInd(pInd.accessory) = p.equippedAcce.getAccIMG(p)
        End If

        If p.equippedGlasses Is Nothing OrElse p.equippedGlasses.imgInd Is Nothing Then
            p.equippedGlasses = New noGlasses()
        Else
            If Not p.equippedGlasses.imgInd Is Nothing Then iArrInd(pInd.glasses) = p.equippedGlasses.imgInd Else iArrInd(pInd.glasses) = p.equippedGlasses.imgInd
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

    Public Sub getNaked()
        Dim p As Player = ent.getPlayer
        If p Is Nothing Then Exit Sub

        EquipmentDialogBackend.equipArmor(p, "Naked", False)

        portraitUDate()

        TextEvent.pushLog("Your clothes don't fit!")
    End Sub
    Private Sub setBreastImage(ByRef p As Player)
        If p.equippedArmor.getName.Equals("Naked") Or Not p.equippedArmor.compress_breast Then
            Select Case p.breastSize
                Case -2
                    setIAInd(pInd.chest, 0, True, False)
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
        ElseIf p.equippedArmor.compress_breast And p.equippedArmor.show_underboob Then
            Select Case p.breastSize
                Case -2
                    setIAInd(pInd.chest, 0, True, False)
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
        ElseIf p.equippedArmor.compress_breast And Not p.equippedArmor.show_underboob Then
            Select Case p.breastSize
                Case -2
                    setIAInd(pInd.chest, 0, True, False)
                Case -1
                    setIAInd(pInd.chest, 0, True, False)
                Case 0
                    setIAInd(pInd.chest, 1, True, False)
                Case 1
                    setIAInd(pInd.chest, 16, True, False)
                Case 2
                    setIAInd(pInd.chest, 17, True, False)
                Case 3
                    setIAInd(pInd.chest, 18, True, False)
                Case 4
                    setIAInd(pInd.chest, 19, True, False)
                Case 5
                    setIAInd(pInd.chest, 20, True, False)
                Case 6
                    setIAInd(pInd.chest, 21, True, False)
                Case 7
                    setIAInd(pInd.chest, 22, True, False)
            End Select
        End If
    End Sub
End Class
