Public Class CharacterGenerator
    'CharacterGenerator1 is the form that allows the assembly of a player portrait

    'iArrKey
    '0 = Background
    '1 = RearHair2 / Wings
    '2 = Body
    '3 = Clothes
    '4 = Face
    '5 = RearHair1
    '6 = Ears
    '7 = Nose
    '8 = Mouth
    '9 = Eyes
    '10 = EyeBrows
    '11 = FacialMark
    '12 = Glasses
    '13 = Cloak
    '14 = Accessory
    '15 = FrontHair
    '16 = Hat
    '17 = facial expresion

    'CharacterGenerator1's instance variables
    Dim iArr(16) As Image
    Dim graph As Graphics = Me.CreateGraphics()
    Public currSex As Boolean = False
    Dim currAttribute As List(Of Image)
    Dim currAtrButton As New Button
    Dim newForm As Boolean = True

    Public quit As Boolean = False

    Public attrOrder(16) As List(Of Image)
    Dim iArrInd(16) As Tuple(Of Integer, Boolean)
    Dim sInts() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0} 'the starting indexes of each catagory

    Dim hairColor As Color = Color.FromArgb(255, 204, 203, 213)
    Dim skincolor As Color = Color.FromArgb(255, 247, 219, 195)

    Public Shared fGlasses, fEyes, fFace, fFacialMark, fMouth, fBody, fCloak, fClothing, fFrontHair, fEyebrows, fNose, fRearHair1, fEars, fAccA, fHat, fRearHair2, bkg As List(Of Image)
    Public Shared mGlasses, mEyes, mFace, mFacialMark, mMouth, mBody, mCloak, mClothing, mFrontHair, mEyebrows, mNose, mRearHair1, mEars, mAccA, mHat, mRearHair2 As List(Of Image)
    Public Shared fTFAccA, fTFBody, fTFClothes, fTFEars, fTFEyes, fTFface, fTfFrontHair, fTFMouth, fTFNose, fTFRearhair1, fTfRearhair2 As List(Of Image)
    Public Shared mTFAccA, mTFBody, mTFClothes, mTFEars, mTFEyes, mTFface, mTfFrontHair, mTFMouth, mTFNose, mTFRearhair1, mTfRearhair2 As List(Of Image)
    Public Shared wings As List(Of Image)

    Public Shared mAttributes(16) As List(Of Image)
    Public Shared fAttributes(16) As List(Of Image)

    'CharGen1_Load handles the loading of the character generator
    Private Sub CharGen1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Game.player.skincolor = skincolor
        Game.player.haircolor = hairColor

        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * Me.Size.Width / 581))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Font = newFont
        Next
        currAtrButton = btnBody
        fGlasses = getImg("img/fGlasses")
        fAccA = getImg("img/fAccA")
        fHat = getImg("img/fHat")
        fBody = getImg("img/fBody")
        fCloak = getImg("img/fCloakF")
        fClothing = getImg("img/fClothing")
        fEars = getImg("img/fEars")
        fEyebrows = getImg("img/fEyebrows")
        fEyes = getImg("img/fEyes")
        fFace = getImg("img/fFace")
        fFacialMark = getImg("img/fFacialMark")
        fFrontHair = getImg("img/fFrontHair")
        fMouth = getImg("img/fMouth")
        fNose = getImg("img/fNose")
        fRearHair1 = getImg("img/fRearHair1")
        fRearHair2 = getImg("img/fRearHair2")
        bkg = getImg("img/bkg")

        initTF()

        mGlasses = getImg("img/mGlasses")
        mAccA = getImg("img/mAccA")
        mHat = getImg("img/mHat")
        mBody = getImg("img/mBody")
        mCloak = getImg("img/mCloakF")
        mClothing = getImg("img/mClothing")
        mEars = getImg("img/mEars")
        mEyebrows = getImg("img/mEyebrows")
        mEyes = getImg("img/mEyes")
        mFace = getImg("img/mFace")
        mFacialMark = getImg("img/mFacialMark")
        mFrontHair = getImg("img/mFrontHair")
        mMouth = getImg("img/mMouth")
        mNose = getImg("img/mNose")
        mRearHair1 = getImg("img/mRearHair1")
        mRearHair2 = getImg("img/mRearHair2")

        mTFAccA = getImg("img/mTF/tfAccA")
        mTFBody = getImg("img/mTF/tfBody")
        mTFEars = getImg("img/mTF/tfEars")
        mTFEyes = getImg("img/mTF/tfEyes")
        mTFface = getImg("img/mTF/tfFace")
        mTfFrontHair = getImg("img/mTF/tfFrontHair")
        mTFMouth = getImg("img/mTF/tfMouth")
        mTFNose = getImg("img/mTF/tfNose")
        mTFRearhair1 = getImg("img/mTF/tfRearHair1")
        mTfRearhair2 = getImg("img/mTF/tfRearHair2")

        If currSex Then currAttribute = fBody Else currAttribute = mBody
        If Not currSex Then
            For i = 0 To mBody.Count - 1
                Dim x As Integer = (i * 71 * Me.Size.Width / 581)
                Dim y As Integer = 0
                Dim img As New PictureBox
                img.BackgroundImage = mBody(i)
                img.Location = New Point(x, y - 20)
                img.Size = New Point(70 * Me.Size.Width / 581, 104 * Me.Size.Width / 581)
                img.BackgroundImageLayout = ImageLayout.Stretch
                AddHandler img.Click, AddressOf PicOnClick
                pnlBody.Controls.Add(img)
            Next
        Else
            For i = 0 To fBody.Count - 1
                Dim x As Integer = (i * 71 * Me.Size.Width / 581)
                Dim y As Integer = 0
                Dim img As New PictureBox
                img.BackgroundImage = fBody(i)
                img.Location = New Point(x, y - 20)
                img.Size = New Point(70 * Me.Size.Width / 581, 104 * Me.Size.Width / 581)
                img.BackgroundImageLayout = ImageLayout.Stretch
                AddHandler img.Click, AddressOf PicOnClick
                pnlBody.Controls.Add(img)
            Next
        End If
        btnBody.Enabled = False

        If currSex = True Then
            iArr(0) = bkg(0)
            iArr(1) = fRearHair2(0)
            iArr(2) = fBody(0)
            iArr(3) = fClothing(0)
            iArr(4) = fFace(0)
            iArr(5) = fRearHair1(0)
            iArr(6) = fEars(0)
            iArr(7) = fNose(0)
            iArr(8) = fMouth(0)
            iArr(9) = fEyes(0)
            iArr(10) = fEyebrows(0)
            iArr(11) = picPort.Image
            iArr(12) = picPort.Image
            iArr(13) = picPort.Image
            iArr(14) = picPort.Image
            iArr(15) = fFrontHair(1)
            iArr(16) = picPort.Image

            attrOrder(0) = bkg
            attrOrder(1) = fRearHair2
            attrOrder(2) = fBody
            attrOrder(3) = fClothing
            attrOrder(4) = fFace
            attrOrder(5) = fRearHair1
            attrOrder(6) = fEars
            attrOrder(7) = fNose
            attrOrder(8) = fMouth
            attrOrder(9) = fEyes
            attrOrder(10) = fEyebrows
            attrOrder(11) = fFacialMark
            attrOrder(12) = fGlasses
            attrOrder(13) = fCloak
            attrOrder(14) = fAccA
            attrOrder(15) = fFrontHair
            attrOrder(16) = fHat
        Else
            iArr(0) = bkg(0)
            iArr(1) = mRearHair2(0)
            iArr(2) = mBody(0)
            iArr(3) = mClothing(0)
            iArr(4) = mFace(0)
            iArr(5) = mRearHair1(0)
            iArr(6) = mEars(0)
            iArr(7) = mNose(0)
            iArr(8) = mMouth(0)
            iArr(9) = mEyes(0)
            iArr(10) = mEyebrows(0)
            iArr(11) = picPort.Image
            iArr(12) = picPort.Image
            iArr(13) = picPort.Image
            iArr(14) = picPort.Image
            iArr(15) = mFrontHair(1)
            iArr(16) = picPort.Image

            attrOrder(0) = bkg
            attrOrder(1) = mRearHair2
            attrOrder(2) = mBody
            attrOrder(3) = mClothing
            attrOrder(4) = mFace
            attrOrder(5) = mRearHair1
            attrOrder(6) = mEars
            attrOrder(7) = mNose
            attrOrder(8) = mMouth
            attrOrder(9) = mEyes
            attrOrder(10) = mEyebrows
            attrOrder(11) = mFacialMark
            attrOrder(12) = mGlasses
            attrOrder(13) = mCloak
            attrOrder(14) = mAccA
            attrOrder(15) = mFrontHair
            attrOrder(16) = mHat
        End If
        For i = 0 To 16
            iArrInd(i) = New Tuple(Of Integer, Boolean)(sInts(i), currSex)
        Next
        ComboBox2.Items.Add("Warrior")
        ComboBox2.Items.Add("Mage")
        picPort.BackgroundImage = CreateBMP(iArr)

        init()
    End Sub
    'CharacterGenerator1_FormClosing handles the finalization of the in game image library
    Private Sub CharacterGenerator1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Game.player.iArr = iArr
        fFrontHair = getImg("img/fFrontHair")
        fRearHair1 = getImg("img/fRearHair1")
        fRearHair2 = getImg("img/fRearHair2")
        fEyebrows = getImg("img/fEyebrows")
        mFrontHair = getImg("img/mFrontHair")
        mRearHair1 = getImg("img/mRearHair1")
        mRearHair2 = getImg("img/mRearHair2")
        mEyebrows = getImg("img/mEyebrows")
        wings = getImg("img/Wings")

        Game.player.iArrInd = iArrInd
        fFacialMark(0) = picPort.Image

        fAccA.AddRange(fTFAccA)
        fBody.AddRange(fTFBody)
        fClothing.AddRange(fTFClothes)
        fEars.AddRange(fTFEars)
        fEyes.AddRange(fTFEyes)
        fFace.AddRange(fTFface)
        fFrontHair.AddRange(fTfFrontHair)
        fMouth.AddRange(fTFMouth)
        fNose.AddRange(fTFMouth)
        fRearHair1.AddRange(fTFRearhair1)
        fRearHair2.AddRange(fTfRearhair2)

        fHat.Add(fTFBody(10))
        fHat.Add(fTFBody(12))
        fHat.Add(fTFBody(13))

        'fFrontHair.Add(Game.picMarkBFHair.BackgroundImage)
        'fRearHair1.Add(Game.picMarkBRearHair1.BackgroundImage)
        'fRearHair2.Add(Game.picMarkBRearHair2.BackgroundImage)
        'fClothing.Add(Game.picMarkBClothes.BackgroundImage)
        'fFrontHair.Add(Game.picFMarkFHair.BackgroundImage)
        'fRearHair1.Add(Game.picFMarkRHair1.BackgroundImage)
        'fRearHair2.Add(Game.picFMarkRHair2.BackgroundImage)
        'fClothing.Add(Game.picfMarkClothes.BackgroundImage)
        'fBody.Add(Game.picFMarkBody.BackgroundImage)

        mAccA.AddRange(mTFAccA)
        mBody.AddRange(mTFBody)
        mClothing.AddRange(mTFClothes)
        mEars.AddRange(mTFEars)
        mEyes.AddRange(mTFEyes)
        mFace.AddRange(mTFface)
        mFrontHair.AddRange(mTfFrontHair)
        mMouth.AddRange(mTFMouth)
        mNose.AddRange(mTFMouth)
        mRearHair1.AddRange(mTFRearhair1)
        mRearHair2.AddRange(mTfRearhair2)

        'mFrontHair.Add(Game.picMarkFHair.BackgroundImage)
        'mEyebrows.Add(Game.picMarkEyebrows.BackgroundImage)
        'mRearHair1.Add(Game.picMarkRHair1.BackgroundImage)
        'mRearHair2.Add(Game.picMarkRHair2.BackgroundImage)
        'mClothing.Add(Game.picMarkClothes.BackgroundImage)

        fAttributes(0) = bkg
        fAttributes(1) = fRearHair2
        fAttributes(2) = fBody
        fAttributes(3) = fClothing
        fAttributes(4) = fFace
        fAttributes(5) = fRearHair1
        fAttributes(6) = fEars
        fAttributes(7) = fNose
        fAttributes(8) = fMouth
        fAttributes(9) = fEyes
        fAttributes(10) = fEyebrows
        fAttributes(11) = fFacialMark
        fAttributes(12) = fGlasses
        fAttributes(13) = fCloak
        fAttributes(14) = fAccA
        fAttributes(15) = fFrontHair
        fAttributes(16) = fHat

        mAttributes(0) = bkg
        mAttributes(1) = mRearHair2
        mAttributes(2) = mBody
        mAttributes(3) = mClothing
        mAttributes(4) = mFace
        mAttributes(5) = mRearHair1
        mAttributes(6) = mEars
        mAttributes(7) = mNose
        mAttributes(8) = mMouth
        mAttributes(9) = mEyes
        mAttributes(10) = mEyebrows
        mAttributes(11) = mFacialMark
        mAttributes(12) = mGlasses
        mAttributes(13) = mCloak
        mAttributes(14) = mAccA
        mAttributes(15) = mFrontHair
        mAttributes(16) = mHat

        fGlasses(0) = picPort.Image
        fCloak(0) = picPort.Image
        fAccA(0) = picPort.Image
        fHat(0) = picPort.Image
        fFacialMark(0) = picPort.Image
        fFrontHair(0) = picPort.Image
        mGlasses(0) = picPort.Image
        mCloak(0) = picPort.Image
        mAccA(0) = picPort.Image
        mHat(0) = picPort.Image
        mFrontHair(0) = picPort.Image
        mFacialMark(0) = picPort.Image

        If (ComboBox2.Text <> "Warrior" And ComboBox2.Text <> "Mage") Then
            If MessageBox.Show("Woah there buddy! One of your choices was a bit of a write in, eh?  You sure you want to do that?", "Sneeky sneek", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If
        Game.player.name = TextBox1.Text
        If currSex Then
            Game.player.sexBool = True
            Game.player.sex = "Female"
        Else
            Game.player.sexBool = False
            Game.player.sex = "Male"
        End If
        Game.player.setClass(ComboBox2.Text)

        NormalClothes.bsizeneg1 = New Tuple(Of Integer, Boolean)(CInt(Game.player.iArrInd(3).Item1), False)
        NormalClothes.bsize1 = New Tuple(Of Integer, Boolean)(CInt(Game.player.iArrInd(3).Item1), True)
        NormalClothes.bsize2 = New Tuple(Of Integer, Boolean)(CInt(Game.player.iArrInd(3).Item1) + 99, True)
        If Game.player.name = "Mark" Then NormalClothes.bsize2 = New Tuple(Of Integer, Boolean)(CharacterGenerator.fClothing.Count - 1, True)
    End Sub

    'displays the assembled portrait image
    Sub drawImg()
        graph.DrawImage(iArr(0), picPort.Location)
        For i = 1 To UBound(iArr.ToArray())
            graph.DrawImage(iArr(i), picPort.Location.X - 1, picPort.Location.Y - 1)
        Next
    End Sub
    'converts an array of images into a .bmp image
    Shared Function CreateBMP(ByRef img() As Image) As Bitmap
        Dim bmp As New Bitmap(146, 216)
        Dim g As Graphics = Graphics.FromImage(bmp)
        If img(0).Size.Height <> 144 Then g.DrawImage(img(0), 0, 0, 146, 216) Else g.DrawImage(img(0), 0, 0, 144, 144)
        For i = 1 To UBound(img)
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
    'exports the image array
    Public Function ExportImgArr() As Image()
        Return iArr
    End Function
    'initializes and orders the image libraries without launching a CharacterGenerator1
    Public Sub init() '(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        'Dim worker As System.ComponentModel.BackgroundWorker = CType(sender, System.ComponentModel.BackgroundWorker)

        currAtrButton = btnBody
        'worker.ReportProgress(1)
        fGlasses = getImg("img/fGlasses")
        fAccA = getImg("img/fAccA")
        fHat = getImg("img/fHat")
        fBody = getImg("img/fBody")
        fCloak = getImg("img/fCloakF")
        fClothing = getImg("img/fClothing")
        fEars = getImg("img/fEars")
        'worker.ReportProgress(15)
        fEyebrows = getImg("img/fEyebrows")
        fEyes = getImg("img/fEyes")
        fFace = getImg("img/fFace")
        fFacialMark = getImg("img/fFacialMark")
        fFrontHair = getImg("img/fFrontHair")
        fMouth = getImg("img/fMouth")
        fNose = getImg("img/fNose")
        fRearHair1 = getImg("img/fRearHair1")
        fRearHair2 = getImg("img/fRearHair2")
        bkg = getImg("img/bkg")

        initTF()
        'worker.ReportProgress(50)

        mGlasses = getImg("img/mGlasses")
        mAccA = getImg("img/mAccA")
        mHat = getImg("img/mHat")
        mBody = getImg("img/mBody")
        mCloak = getImg("img/mCloakF")
        mClothing = getImg("img/mClothing")
        mEars = getImg("img/mEars")
        mEyebrows = getImg("img/mEyebrows")
        mEyes = getImg("img/mEyes")
        mFace = getImg("img/mFace")
        mFacialMark = getImg("img/mFacialMark")
        mFrontHair = getImg("img/mFrontHair")
        mMouth = getImg("img/mMouth")
        mNose = getImg("img/mNose")
        mRearHair1 = getImg("img/mRearHair1")
        mRearHair2 = getImg("img/mRearHair2")
        'worker.ReportProgress(60)

        mTFAccA = getImg("img/mTf/tfAccA")
        mTFBody = getImg("img/mTf/tfBody")
        mTFEars = getImg("img/mTf/tfEars")
        mTFEyes = getImg("img/mTf/tfEyes")
        mTFface = getImg("img/mTf/tfFace")
        'worker.ReportProgress(65)
        mTfFrontHair = getImg("img/mTf/tfFrontHair")
        mTFMouth = getImg("img/mTf/tfMouth")
        mTFNose = getImg("img/mTf/tfNose")
        mTFRearhair1 = getImg("img/mTf/tfRearHair1")
        mTfRearhair2 = getImg("img/mTf/tfRearHair2")
        'worker.ReportProgress(70)

        wings = getImg("img/Wings")
        'worker.ReportProgress(75)

        fGlasses(0) = picPort.Image
        fCloak(0) = picPort.Image
        fAccA(0) = picPort.Image
        fHat(0) = picPort.Image
        fFacialMark(0) = picPort.Image
        fFrontHair(0) = picPort.Image
        mGlasses(0) = picPort.Image
        mCloak(0) = picPort.Image
        mAccA(0) = picPort.Image
        mHat(0) = picPort.Image
        mFrontHair(0) = picPort.Image
        mFacialMark(0) = picPort.Image
        'worker.ReportProgress(78)

        fAccA.AddRange(fTFAccA)
        fBody.AddRange(fTFBody)
        fClothing.AddRange(fTFClothes)
        fEars.AddRange(fTFEars)
        fEyes.AddRange(fTFEyes)
        fFace.AddRange(fTFface)
        fFrontHair.AddRange(fTfFrontHair)
        fMouth.AddRange(fTFMouth)
        fNose.AddRange(fTFMouth)
        fRearHair1.AddRange(fTFRearhair1)
        fRearHair2.AddRange(fTfRearhair2)
        fHat.Add(fTFBody(10))
        fHat.Add(fTFBody(12))
        fHat.Add(fTFBody(13))
        'worker.ReportProgress(80)

        'fFrontHair.Add(Game.picMarkBFHair.BackgroundImage)
        'fRearHair1.Add(Game.picMarkBRearHair1.BackgroundImage)
        'fRearHair2.Add(Game.picMarkBRearHair2.BackgroundImage)
        'fClothing.Add(Game.picMarkBClothes.BackgroundImage)
        'fFrontHair.Add(Game.picFMarkFHair.BackgroundImage)
        'fRearHair1.Add(Game.picFMarkRHair1.BackgroundImage)
        'fRearHair2.Add(Game.picFMarkRHair2.BackgroundImage)
        'fClothing.Add(Game.picfMarkClothes.BackgroundImage)
        'fBody.Add(Game.picFMarkBody.BackgroundImage)
        'worker.ReportProgress(85)

        mAccA.AddRange(mTFAccA)
        mBody.AddRange(mTFBody)
        mClothing.AddRange(mTFClothes)
        mEars.AddRange(mTFEars)
        mEyes.AddRange(mTFEyes)
        mFace.AddRange(mTFface)
        mFrontHair.AddRange(mTfFrontHair)
        mMouth.AddRange(mTFMouth)
        mNose.AddRange(mTFMouth)
        mRearHair1.AddRange(mTFRearhair1)
        mRearHair2.AddRange(mTfRearhair2)
        mHat.Add(fTFBody(5))
        mHat.Add(fTFBody(7))
        'mFrontHair.Add(Game.picMarkFHair.BackgroundImage)
        'mEyebrows.Add(Game.picMarkEyebrows.BackgroundImage)
        'mRearHair1.Add(Game.picMarkRHair1.BackgroundImage)
        'mRearHair2.Add(Game.picMarkRHair2.BackgroundImage)
        'mClothing.Add(Game.picMarkClothes.BackgroundImage)
        'worker.ReportProgress(90)

        fAttributes(0) = bkg
        fAttributes(1) = fRearHair2
        fAttributes(2) = fBody
        fAttributes(3) = fClothing
        fAttributes(4) = fFace
        fAttributes(5) = fRearHair1
        fAttributes(6) = fEars
        fAttributes(7) = fNose
        fAttributes(8) = fMouth
        fAttributes(9) = fEyes
        fAttributes(10) = fEyebrows
        fAttributes(11) = fFacialMark
        fAttributes(12) = fGlasses
        fAttributes(13) = fCloak
        fAttributes(14) = fAccA
        fAttributes(15) = fFrontHair
        fAttributes(16) = fHat

        'worker.ReportProgress(95)

        mAttributes(0) = bkg
        mAttributes(1) = mRearHair2
        mAttributes(2) = mBody
        mAttributes(3) = mClothing
        mAttributes(4) = mFace
        mAttributes(5) = mRearHair1
        mAttributes(6) = mEars
        mAttributes(7) = mNose
        mAttributes(8) = mMouth
        mAttributes(9) = mEyes
        mAttributes(10) = mEyebrows
        mAttributes(11) = mFacialMark
        mAttributes(12) = mGlasses
        mAttributes(13) = mCloak
        mAttributes(14) = mAccA
        mAttributes(15) = mFrontHair
        mAttributes(16) = mHat
        'worker.ReportProgress(100)
    End Sub
    'orders the image libraries by number, not name
    Sub initTF()
        Dim range, temp As List(Of Image)
        Dim offset As Integer
        fTFAccA = getImg("img/fTF/tfAccA")

        fTFBody = getImg("img/fTF/tfBody")
        offset = fTFBody.Count - 5
        range = fTFBody.GetRange(offset, 5)
        fTFBody = fTFBody.GetRange(0, offset)
        fTFBody.InsertRange(4, range)

        fTFClothes = getImg("img/fTF/tfClothes")
        offset = fTFClothes.Count - 5
        range = fTFClothes.GetRange(offset, 5)
        temp = fTFClothes.GetRange(0, offset)
        range.AddRange(temp)
        fTFClothes = range

        mTFClothes = getImg("img/mTF/tfClothes")
        offset = mTFClothes.Count - 5
        range = mTFClothes.GetRange(offset, 5)
        temp = mTFClothes.GetRange(0, offset)
        range.AddRange(temp)
        mTFClothes = range

        fTFEars = getImg("img/fTF/tfEars")

        fTFEyes = getImg("img/fTF/tfEyes")
        'offset = fTFEyes.Count - 3
        'range = fTFEyes.GetRange(offset, 3)
        'temp = fTFEyes.GetRange(0, offset)
        'range.AddRange(temp)
        'fTFEyes = range

        fTFface = getImg("img/fTF/tfFace")
        fTfFrontHair = getImg("img/fTF/tfFrontHair")
        offset = fTfFrontHair.Count - 4
        range = fTfFrontHair.GetRange(offset, 4)
        temp = fTfFrontHair.GetRange(0, offset)
        range.AddRange(temp)
        fTfFrontHair = range

        fTFMouth = getImg("img/fTF/tfMouth")
        offset = fTFMouth.Count - 5
        range = fTFMouth.GetRange(offset, 5)
        temp = fTFMouth.GetRange(0, offset)
        range.AddRange(temp)
        fTFMouth = range

        fTFNose = getImg("img/fTF/tfNose")

        fTFRearhair1 = getImg("img/fTF/tfRearHair1")
        offset = fTFRearhair1.Count - 5
        range = fTFRearhair1.GetRange(offset, 5)
        temp = fTFRearhair1.GetRange(0, offset)
        range.AddRange(temp)
        fTFRearhair1 = range

        fTfRearhair2 = getImg("img/fTF/tfRearHair2")
        offset = fTfRearhair2.Count - 5
        range = fTfRearhair2.GetRange(offset, 5)
        temp = fTfRearhair2.GetRange(0, offset)
        range.AddRange(temp)
        fTfRearhair2 = range
    End Sub
    'getImg reads all .png files in a directory into a List data structure
    Shared Function getImg(ByVal direct As String) As List(Of Image)
        Dim dir = New IO.DirectoryInfo(direct)
        Dim images = dir.GetFiles("*.png", IO.SearchOption.AllDirectories).ToList
        Dim pictures As New List(Of Image)
        For Each img In images.OrderBy(Function(i) i.Name)
            Dim picture As Image
            picture = Image.FromFile(img.FullName)
            pictures.Add(picture)
        Next
        Return pictures
    End Function
    'PicOnClick handles the selecting of images via click
    Sub PicOnClick(ByVal sender As Object, ByVal e As EventArgs)
        If currAttribute.Count = 1 Then Exit Sub
        If currAttribute.Equals(fRearHair2) Or currAttribute.Equals(mRearHair2) Then
            Dim ind As Integer = pnlBody.Controls.IndexOf(sender)
            iArr(1) = currAttribute(ind)
            If currAttribute.Equals(fRearHair2) Then
                iArr(5) = fRearHair1(ind)
            ElseIf currAttribute.Equals(mRearHair2) Then
                iArr(5) = mRearHair1(ind)
            End If
            iArrInd(1) = New Tuple(Of Integer, Boolean)(ind, currSex)
            iArrInd(5) = New Tuple(Of Integer, Boolean)(ind, currSex)
            picPort.BackgroundImage = CreateBMP(iArr)
            Exit Sub
        End If
        Try
            For i = 0 To currAttribute.Count - 1
                If currAttribute(i).Equals(sender.BackgroundImage) Then
                    Dim ind As Integer = Array.IndexOf(attrOrder, currAttribute)
                    If Not ((ind >= 11)) And i <> 0 Then
                        iArr(ind) = currAttribute(i)
                        iArrInd(ind) = New Tuple(Of Integer, Boolean)(i, currSex)
                    ElseIf ((ind >= 11)) And i = 0 Then
                        iArr(ind) = picPort.Image
                        iArrInd(ind) = New Tuple(Of Integer, Boolean)(0, currSex)
                    Else
                        iArr(ind) = currAttribute(i)
                        iArrInd(ind) = New Tuple(Of Integer, Boolean)(i, currSex)
                    End If
                    If currAttribute.Equals(fRearHair2) Then
                        iArr(5) = fRearHair1(i)
                        iArrInd(ind) = New Tuple(Of Integer, Boolean)(i, currSex)
                    ElseIf currAttribute.Equals(mRearHair2) Then
                        iArr(5) = mRearHair1(i)
                        iArrInd(ind) = New Tuple(Of Integer, Boolean)(i, currSex)
                    End If
                    picPort.BackgroundImage = CreateBMP(iArr)
                    Exit For
                End If
            Next
        Catch ex As Exception
            If MessageBox.Show("Error! Exeption thrown in character creation.  Restart application?", "D_D Error 001", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Application.Restart()
            Else
                Game.Close()
                Application.Exit()
            End If
        End Try
    End Sub
    'recolor changes the color of an image, assumed to be of the same color as the players hair 
    Shared Function recolor(ByRef img As Bitmap, ByVal c As Color)
        Dim cImg As Bitmap = img
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
    Shared Function recolor2(ByRef img As Bitmap, ByVal c As Color)
        Dim cImg As Bitmap = img
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
    'checkColors checks for similar colors amongst pixels
    Shared Function checkColors(ByVal d1 As Double, ByVal d2 As Double, ByVal d3 As Double)
        Dim out = True
        If d1 / d2 > 1.05 Or d1 / d2 < 0.95 Then out = False
        If d2 / d3 > 1.05 Or d2 / d3 < 0.95 Then out = False
        If d3 / d1 > 1.05 Or d3 / d1 < 0.95 Then out = False
        If d2 / d1 > 1.05 Or d2 / d1 < 0.95 Then out = False
        If d3 / d2 > 1.05 Or d3 / d2 < 0.95 Then out = False
        If d1 / d3 > 1.05 Or d1 / d3 < 0.95 Then out = False

        Return out
    End Function
    'attribute selection methods
    Private Sub btnBody_Click(sender As Object, e As EventArgs) Handles btnBody.Click
        pnlBody.Controls.Clear()
        If currSex Then
            currAttribute = fBody
        Else
            currAttribute = mBody
        End If
        currAtrButton.Enabled = True
        currAtrButton = btnBody
        currAtrButton.Enabled = False

        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = currAttribute(i)
            img.Location = New Point(x, y - 20)
            img.Size = New Point(70 * Me.Size.Width / 581, 104 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnFHair_Click(sender As Object, e As EventArgs) Handles btnFHair.Click
        pnlBody.Controls.Clear()
        If currSex Then
            currAttribute = fFrontHair
        Else
            currAttribute = mFrontHair
        End If
        currAtrButton.Enabled = True
        currAtrButton = btnFHair
        currAtrButton.Enabled = False

        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = currAttribute(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnEyes_Click(sender As Object, e As EventArgs) Handles btnEyes.Click
        pnlBody.Controls.Clear()
        If currSex Then
            currAttribute = fEyes
        Else
            currAttribute = mEyes
        End If
        currAtrButton.Enabled = True
        currAtrButton = btnEyes
        currAtrButton.Enabled = False

        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = currAttribute(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnMouth_Click(sender As Object, e As EventArgs) Handles btnMouth.Click
        pnlBody.Controls.Clear()
        If currSex Then
            currAttribute = fMouth
        Else
            currAttribute = mMouth
        End If
        currAtrButton.Enabled = True
        currAtrButton = btnMouth
        currAtrButton.Enabled = False

        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = currAttribute(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnMark_Click(sender As Object, e As EventArgs) Handles btnMark.Click
        pnlBody.Controls.Clear()
        If currSex Then
            currAttribute = fFacialMark
        Else
            currAttribute = mFacialMark
        End If
        currAtrButton.Enabled = True
        currAtrButton = btnMark
        currAtrButton.Enabled = False

        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = currAttribute(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnAcca_Click(sender As Object, e As EventArgs) Handles btnAcca.Click
        pnlBody.Controls.Clear()
        If currSex Then
            currAttribute = fAccA
        Else
            currAttribute = mAccA
        End If
        currAtrButton.Enabled = True
        currAtrButton = btnAcca
        currAtrButton.Enabled = False

        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = currAttribute(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnFace_Click(sender As Object, e As EventArgs) Handles btnFace.Click
        pnlBody.Controls.Clear()
        If currSex Then
            currAttribute = fFace
        Else
            currAttribute = mFace
        End If
        currAtrButton.Enabled = True
        currAtrButton = btnFace
        currAtrButton.Enabled = False

        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = currAttribute(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnBHair_Click(sender As Object, e As EventArgs) Handles btnBHair.Click
        pnlBody.Controls.Clear()
        If currSex Then
            currAttribute = fRearHair2
        Else
            currAttribute = mRearHair2
        End If
        currAtrButton.Enabled = True
        currAtrButton = btnBHair
        currAtrButton.Enabled = False
        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            Dim hairArr(1) As Image
            hairArr(0) = currAttribute(i)
            If currSex Then
                hairArr(1) = fRearHair1(i)
            Else
                hairArr(1) = mRearHair1(i)
            End If
            img.BackgroundImage = CreateBMP(hairArr)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 104 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnEyebrows_Click(sender As Object, e As EventArgs) Handles btnEyebrows.Click
        pnlBody.Controls.Clear()
        If currSex Then
            currAttribute = fEyebrows
        Else
            currAttribute = mEyebrows
        End If
        currAtrButton.Enabled = True
        currAtrButton = btnEyebrows
        currAtrButton.Enabled = False

        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = currAttribute(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnEars_Click(sender As Object, e As EventArgs) Handles btnEars.Click
        pnlBody.Controls.Clear()
        If currSex Then
            currAttribute = fEars
        Else
            currAttribute = mEars
        End If
        currAtrButton.Enabled = True
        currAtrButton = btnEars
        currAtrButton.Enabled = False

        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = currAttribute(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnClothes_Click(sender As Object, e As EventArgs) Handles btnClothes.Click
        pnlBody.Controls.Clear()
        If currSex Then
            currAttribute = fClothing
            iArr(2) = fTFBody(4)
            recolor2(iArr(2), skincolor)
            picPort.BackgroundImage = CreateBMP(iArr)
        Else
            currAttribute = mClothing
        End If
        currAtrButton.Enabled = True
        currAtrButton = btnClothes
        currAtrButton.Enabled = False

        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = currAttribute(i)
            img.Location = New Point(x, y - 20)
            img.Size = New Point(70 * Me.Size.Width / 581, 104 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnGlasses_Click(sender As Object, e As EventArgs) Handles btnGlasses.Click
        pnlBody.Controls.Clear()
        If currSex Then
            currAttribute = fGlasses
        Else
            currAttribute = mGlasses
        End If
        currAtrButton.Enabled = True
        currAtrButton = btnGlasses
        currAtrButton.Enabled = False

        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = currAttribute(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnCloak_Click(sender As Object, e As EventArgs) Handles btnCloak.Click
        pnlBody.Controls.Clear()
        If currSex Then
            currAttribute = fCloak
        Else
            currAttribute = mCloak
        End If
        currAtrButton.Enabled = True
        currAtrButton = btnCloak
        currAtrButton.Enabled = False

        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = currAttribute(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnHat_Click(sender As Object, e As EventArgs) Handles btnHat.Click
        pnlBody.Controls.Clear()
        If currSex Then
            currAttribute = fHat
        Else
            currAttribute = mHat
        End If
        currAtrButton.Enabled = True
        currAtrButton = btnHat
        currAtrButton.Enabled = False

        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = currAttribute(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    'btnSave_Click closes the form, finalizing the players choices
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Close()
    End Sub
    'Quits to main menu without starting the game
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        quit = True
        Me.Close()
    End Sub
    'sex Selection buttons
    Private Sub btnMale_Click(sender As Object, e As EventArgs) Handles btnMale.Click
        currSex = False
        Game.player.sexBool = False
        pnlBody.Controls.Clear()
        currAttribute = mBody
        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = currAttribute(i)
            img.Location = New Point(x, y - 20)
            img.Size = New Point(70 * Me.Size.Width / 581, 104 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
        btnFemale.Enabled = True
        btnMale.Enabled = False
        currAtrButton.Enabled = True
        currAtrButton = btnBody
        btnBody.Enabled = False

        iArr(0) = bkg(0)
        iArr(1) = mRearHair2(0)
        iArr(2) = mBody(0)
        iArr(3) = mClothing(0)
        iArr(4) = mFace(0)
        iArr(5) = mRearHair1(0)
        iArr(6) = mEars(0)
        iArr(7) = mNose(0)
        iArr(8) = mMouth(0)
        iArr(9) = mEyes(0)
        iArr(10) = mEyebrows(0)
        iArr(11) = picPort.Image
        iArr(12) = picPort.Image
        iArr(13) = picPort.Image
        iArr(14) = picPort.Image
        iArr(15) = mFrontHair(1)
        iArr(16) = picPort.Image

        iArrInd(1) = New Tuple(Of Integer, Boolean)(0, False)
        iArrInd(2) = New Tuple(Of Integer, Boolean)(0, False)
        iArrInd(3) = New Tuple(Of Integer, Boolean)(0, False)
        iArrInd(4) = New Tuple(Of Integer, Boolean)(0, False)
        iArrInd(5) = New Tuple(Of Integer, Boolean)(0, False)
        iArrInd(6) = New Tuple(Of Integer, Boolean)(0, False)
        iArrInd(7) = New Tuple(Of Integer, Boolean)(0, False)
        iArrInd(8) = New Tuple(Of Integer, Boolean)(0, False)
        iArrInd(9) = New Tuple(Of Integer, Boolean)(0, False)
        iArrInd(10) = New Tuple(Of Integer, Boolean)(0, False)
        iArrInd(11) = New Tuple(Of Integer, Boolean)(0, False)
        iArrInd(12) = New Tuple(Of Integer, Boolean)(0, False)
        iArrInd(13) = New Tuple(Of Integer, Boolean)(0, False)
        iArrInd(14) = New Tuple(Of Integer, Boolean)(0, False)
        iArrInd(15) = New Tuple(Of Integer, Boolean)(1, False)
        iArrInd(16) = New Tuple(Of Integer, Boolean)(0, False)

        attrOrder(0) = bkg
        attrOrder(1) = mRearHair2
        attrOrder(2) = mBody
        attrOrder(3) = mClothing
        attrOrder(4) = mFace
        attrOrder(5) = mRearHair1
        attrOrder(6) = mEars
        attrOrder(7) = mNose
        attrOrder(8) = mMouth
        attrOrder(9) = mEyes
        attrOrder(10) = mEyebrows
        attrOrder(11) = mFacialMark
        attrOrder(12) = mGlasses
        attrOrder(13) = mCloak
        attrOrder(14) = mAccA
        attrOrder(15) = mFrontHair
        attrOrder(16) = mHat

        changeHC(hairColor)
        changeSC(skincolor)
        picPort.BackgroundImage = CreateBMP(iArr)
    End Sub
    Private Sub btnFemale_Click(sender As Object, e As EventArgs) Handles btnFemale.Click
        currSex = True
        Game.player.sexBool = True
        currAttribute = fBody
        pnlBody.Controls.Clear()
        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = currAttribute(i)
            img.Location = New Point(x, y - 20)
            img.Size = New Point(70 * Me.Size.Width / 581, 104 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
        currAtrButton.Enabled = True
        currAtrButton = btnBody
        btnBody.Enabled = False
        btnMale.Enabled = True
        btnFemale.Enabled = False
        iArr(0) = bkg(0)
        iArr(1) = fRearHair2(0)
        iArr(2) = fBody(0)
        iArr(3) = fClothing(0)
        iArr(4) = fFace(0)
        iArr(5) = fRearHair1(0)
        iArr(6) = fEars(0)
        iArr(7) = fNose(0)
        iArr(8) = fMouth(0)
        iArr(9) = fEyes(0)
        iArr(10) = fEyebrows(0)
        iArr(11) = picPort.Image
        iArr(12) = picPort.Image
        iArr(13) = picPort.Image
        iArr(14) = picPort.Image
        iArr(15) = fFrontHair(1)
        iArr(16) = picPort.Image

        iArrInd(1) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(2) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(3) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(4) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(5) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(6) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(7) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(8) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(9) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(10) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(11) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(12) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(14) = New Tuple(Of Integer, Boolean)(0, True)
        iArrInd(15) = New Tuple(Of Integer, Boolean)(1, True)
        iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)

        attrOrder(0) = bkg
        attrOrder(1) = fRearHair2
        attrOrder(2) = fBody
        attrOrder(3) = fClothing
        attrOrder(4) = fFace
        attrOrder(5) = fRearHair1
        attrOrder(6) = fEars
        attrOrder(7) = fNose
        attrOrder(8) = fMouth
        attrOrder(9) = fEyes
        attrOrder(10) = fEyebrows
        attrOrder(11) = fFacialMark
        attrOrder(12) = fGlasses
        attrOrder(13) = fCloak
        attrOrder(14) = fAccA
        attrOrder(15) = fFrontHair
        attrOrder(16) = fHat

        changeHC(hairColor)
        changeSC(skincolor)
        picPort.BackgroundImage = CreateBMP(iArr)
    End Sub
    'haircolor change methods
    Private Sub btnHC_Click(sender As Object, e As EventArgs) Handles btnHC.Click
        Dim cd As New ColorDialog()
        cd.Color = Game.player.haircolor
        cd.ShowDialog()
        changeHC(cd.Color)
        If currAtrButton.Equals(btnBHair) Then
            btnBHair_Click(sender, e)
            currAttribute = mRearHair2
        End If
        If currAtrButton.Equals(btnFHair) Then
            btnFHair_Click(sender, e)
            currAttribute = mFrontHair
        End If
        If currAtrButton.Equals(btnEyebrows) Then
            btnEyebrows_Click(sender, e)
            currAttribute = mEyebrows
        End If
        For i = 0 To currAttribute.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = currAttribute(i)
            img.Location = New Point(x, y - 20)
            img.Size = New Point(70 * Me.Size.Width / 581, 104 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
        cd.Dispose()
    End Sub
    Sub changeHC(ByVal c As Color)
        Game.player.haircolor = c
        hairColor = c
        If Game.player.sexBool Then
            fFrontHair = getImg("img/fFrontHair")
            fRearHair1 = getImg("img/fRearHair1")
            fRearHair2 = getImg("img/fRearHair2")
            fEyebrows = getImg("img/fEyebrows")
            For i = 1 To fFrontHair.Count - 1
                fFrontHair(i) = recolor(fFrontHair(i), c)
            Next
            attrOrder(15) = fFrontHair
            For i = 0 To fRearHair1.Count - 1
                fRearHair1(i) = recolor(fRearHair1(i), c)
            Next
            attrOrder(5) = fRearHair1
            For i = 0 To fRearHair2.Count - 1
                fRearHair2(i) = recolor(fRearHair2(i), c)
            Next
            attrOrder(1) = fRearHair2
            For i = 0 To fEyebrows.Count - 1
                fEyebrows(i) = recolor(fEyebrows(i), c)
            Next
            attrOrder(10) = fEyebrows

            iArr(1) = fRearHair2(iArrInd(1).Item1)
            iArr(5) = fRearHair1(iArrInd(5).Item1)
            iArr(10) = fEyebrows(iArrInd(10).Item1)
            If Not iArr(15).Equals(picPort.Image) Then iArr(15) = fFrontHair(iArrInd(15).Item1)
        Else
            mFrontHair = getImg("img/mFrontHair")
            mRearHair1 = getImg("img/mRearHair1")
            mRearHair2 = getImg("img/mRearHair2")
            mEyebrows = getImg("img/mEyebrows")
            For i = 1 To mFrontHair.Count - 1
                mFrontHair(i) = recolor(mFrontHair(i), c)
            Next
            attrOrder(15) = mFrontHair
            For i = 0 To mRearHair1.Count - 1
                mRearHair1(i) = recolor(mRearHair1(i), c)
            Next
            attrOrder(5) = mRearHair1
            For i = 0 To mRearHair2.Count - 1
                mRearHair2(i) = recolor(mRearHair2(i), c)
            Next
            attrOrder(1) = mRearHair2
            For i = 0 To mEyebrows.Count - 1
                mEyebrows(i) = recolor(mEyebrows(i), c)
            Next
            attrOrder(10) = mEyebrows
            iArr(1) = mRearHair2(iArrInd(1).Item1)
            iArr(5) = mRearHair1(iArrInd(5).Item1)
            iArr(10) = mEyebrows(iArrInd(10).Item1)
            If Not iArr(15).Equals(picPort.Image) Then iArr(15) = mFrontHair(iArrInd(15).Item1)
        End If
        picPort.BackgroundImage = CreateBMP(iArr)
    End Sub
    'skincolor change methods
    Private Sub btnSC_Click(sender As Object, e As EventArgs) Handles btnSC.Click
        Dim cd As New SCPicker
        cd.ShowDialog()
        changeSC(cd.sc)
        cd.Dispose()
        btnBody_Click(sender, e)
    End Sub
    Sub changeSC(ByVal c As Color)
        Game.player.skincolor = c
        skincolor = c
        If Game.player.sexBool Then
            'body
            fBody = getImg("img/fBody")
            Dim range As List(Of Image)
            Dim offset As Integer

            fTFBody = getImg("img/fTF/tfBody")
            offset = fTFBody.Count - 5
            range = fTFBody.GetRange(offset, 5)
            fTFBody = fTFBody.GetRange(0, offset)
            fTFBody.InsertRange(4, range)
            For i = 0 To fBody.Count - 1
                fBody(i) = recolor2(fBody(i), c)
            Next
            For i = 0 To fTFBody.Count - 1
                If i <> 2 And i <> 4 And i <> 5 And i <> 6 And i <> 7 Then fTFBody(i) = recolor2(fTFBody(i), c)
            Next
            attrOrder(2) = fBody
            'face
            fFace = getImg("img/fFace")
            For i = 0 To fFace.Count - 1
                fFace(i) = recolor2(fFace(i), c)
            Next
            attrOrder(4) = fFace
            'nose
            fNose = getImg("img/fNose")
            For i = 0 To fNose.Count - 1
                fNose(i) = recolor2(fNose(i), c)
            Next
            attrOrder(7) = fNose
            'ears
            fEars = getImg("img/fEars")
            For i = 0 To fEars.Count - 1
                If i = 0 Or i = 3 Then fEars(i) = recolor2(fEars(i), c)
            Next
            attrOrder(6) = fEars
            fTFEars = getImg("img/fTF/tfEars")
            For i = 0 To fTFEars.Count - 1
                If i = 2 Or i = 3 Then fTFEars(i) = recolor2(fTFEars(i), c)
            Next
            'WARNING: THIS ISN'T UPDATED
            'attrOrder(6) = 

            iArr(2) = fBody(iArrInd(2).Item1)
            iArr(4) = fFace(iArrInd(4).Item1)
            iArr(7) = fNose(iArrInd(7).Item1)
            iArr(6) = fEars(iArrInd(6).Item1)
        Else
            'body
            mBody = getImg("img/mBody")
            For i = 0 To mBody.Count - 1
                mBody(i) = recolor2(mBody(i), c)
            Next
            attrOrder(2) = mBody
            'face
            mFace = getImg("img/mFace")
            For i = 0 To mFace.Count - 1
                mFace(i) = recolor2(mFace(i), c)
            Next
            attrOrder(4) = mFace
            'nose
            mNose = getImg("img/mNose")
            For i = 0 To mNose.Count - 1
                mNose(i) = recolor2(mNose(i), c)
            Next
            attrOrder(7) = mNose
            'ears
            mEars = getImg("img/mEars")
            For i = 0 To mEars.Count - 1
                If i = 0 Or i = 3 Then mEars(i) = recolor2(mEars(i), c)
            Next
            attrOrder(6) = mEars

            iArr(2) = mBody(iArrInd(2).Item1)
            iArr(4) = mFace(iArrInd(4).Item1)
            iArr(7) = mNose(iArrInd(7).Item1)
            iArr(6) = mEars(iArrInd(6).Item1)
        End If
        picPort.BackgroundImage = CreateBMP(iArr)
    End Sub
    'randomizes the players portrait
    Private Sub btnRandom_Click(sender As Object, e As EventArgs) Handles btnRandom.Click
        Randomize()
        If currSex Then
            Dim r As Integer = Int(Rnd() * 5)
            iArrInd(1) = New Tuple(Of Integer, Boolean)(r, currSex)
            iArr(1) = fRearHair1(r)
            iArrInd(5) = New Tuple(Of Integer, Boolean)(r, currSex)
            iArr(5) = fRearHair2(r)
            r = Int(Rnd() * 5)
            iArrInd(3) = New Tuple(Of Integer, Boolean)(r, currSex)
            iArr(3) = fClothing(r)
            r = Int(Rnd() * 4)
            iArrInd(6) = New Tuple(Of Integer, Boolean)(r, currSex)
            iArr(6) = fEars(r)
            r = Int(Rnd() * 3)
            If r = 1 Then r = 4
            iArrInd(8) = New Tuple(Of Integer, Boolean)(r, currSex)
            iArr(8) = fMouth(r)
            r = Int(Rnd() * 3)
            iArrInd(9) = New Tuple(Of Integer, Boolean)(r, currSex)
            iArr(9) = fEyes(r)
            r = Int(Rnd() * 4) + 1
            iArrInd(15) = New Tuple(Of Integer, Boolean)(r, currSex)
            iArr(15) = fFrontHair(r)
        Else
            Dim r As Integer = Int(Rnd() * 5)
            iArrInd(1) = New Tuple(Of Integer, Boolean)(r, currSex)
            iArr(1) = mRearHair1(r)
            iArrInd(5) = New Tuple(Of Integer, Boolean)(r, currSex)
            iArr(5) = mRearHair2(r)
            r = Int(Rnd() * 5)
            iArrInd(3) = New Tuple(Of Integer, Boolean)(r, currSex)
            iArr(3) = mClothing(r)
            r = Int(Rnd() * 4)
            iArrInd(6) = New Tuple(Of Integer, Boolean)(r, currSex)
            iArr(6) = mEars(r)
            r = Int(Rnd() * 3)
            If r = 1 Then r = 4
            iArrInd(8) = New Tuple(Of Integer, Boolean)(r, currSex)
            iArr(8) = mMouth(r)
            r = Int(Rnd() * 3)
            iArrInd(9) = New Tuple(Of Integer, Boolean)(r, currSex)
            iArr(9) = mEyes(r)
            r = Int(Rnd() * 4) + 1
            iArrInd(15) = New Tuple(Of Integer, Boolean)(r, currSex)
            iArr(15) = mFrontHair(r)
        End If

        changeHC(Color.FromArgb(255, Int(Rnd() * 125) + 100, Int(Rnd() * 125) + 100, Int(Rnd() * 125) + 100))


        Dim r1 As Integer = Int(Rnd() * 6)
        Select Case r1
            Case 0
                changeSC(Color.AntiqueWhite)
            Case 1
                changeSC(Color.FromArgb(255, 247, 219, 195))
            Case 2
                changeSC(Color.FromArgb(255, 240, 184, 160))
            Case 3
                changeSC(Color.FromArgb(255, 210, 161, 140))
            Case 4
                changeSC(Color.FromArgb(255, 180, 138, 120))
            Case Else
                changeSC(Color.FromArgb(255, 105, 80, 70))
        End Select
    End Sub
End Class