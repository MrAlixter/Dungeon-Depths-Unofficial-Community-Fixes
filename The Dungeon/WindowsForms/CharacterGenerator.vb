Public Class CharacterGenerator
    'CharacterGenerator1 is the form that allows the assembly of a player portrait

    'iArrKey
    '0 = Background
    '1 = RearHair2 / Wings
    '2 = Body
    '3 = Clothes
    '4 = Face
    '5 = RearHair1
    '6 = Ears / Horns
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

    'CharacterGenerator1's instance variables
    'Dim attrOrder As List(Of Image)
    Dim graph As Graphics = Me.CreateGraphics()
    Dim currAttribute As ImageAttribute
    Dim currAtrButton As New Button
    Dim newForm As Boolean = True

    Public quit As Boolean = False

    Dim portrait As Portrait = New Portrait(False, Nothing)

    Dim defImgLib As ImageCollection = New ImageCollection(0)

    'CharGen1_Load handles the loading of the character generator
    Private Sub CharGen1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'scale to the screen size
        Dim startingWidth = Me.Width
        Dim startingHeight = Me.Height
        If Game.screenSize = "Small" Then
            Size = New Size(Size.Width * 0.8, Size.Height * 0.8)
        ElseIf Game.screenSize = "Medium" Then
            Size = New Size(Size.Width * 0.9, Size.Height * 0.9)
        ElseIf Game.screenSize = "XLarge" Then
            Size = New Size(Size.Width * 1.3, Size.Height * 1.3)
        End If
        Dim RW As Double = (Me.Width - startingWidth) / startingWidth ' Ratio change of width
        Dim RH As Double = (Me.Height - startingHeight) / startingHeight ' Ratio change of height
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * Me.Size.Width / 581))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Font = newFont
            Me.Controls(i).Width += CDbl(Me.Controls(i).Width * RW)
            Me.Controls(i).Height += CDbl(Me.Controls(i).Height * RH)
            Me.Controls(i).Left += CDbl(Me.Controls(i).Left * RW)
            Me.Controls(i).Top += CDbl(Me.Controls(i).Top * RH)
        Next

        currAtrButton = btnBody

        currAttribute = defImgLib.atrs("Body")
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs("Body").getF
        Else
            sexAttrList = defImgLib.atrs("Body").getM
        End If
            For i = 0 To sexAttrList.Count - 1
                Dim x As Integer = (i * 71 * Me.Size.Width / 581)
                Dim y As Integer = 0
                Dim img As New PictureBox
                img.BackgroundImage = sexAttrList(i)
                img.Location = New Point(x, y - 20)
                img.Size = New Point(70 * Me.Size.Width / 581, 104 * Me.Size.Width / 581)
                img.BackgroundImageLayout = ImageLayout.Stretch
                AddHandler img.Click, AddressOf PicOnClick
                pnlBody.Controls.Add(img)
            Next
       
        btnBody.Enabled = False

        setDefaultProfilePic()

        ComboBox2.Items.Add("Warrior")
        ComboBox2.Items.Add("Mage")
        ComboBox2.Items.Add("Magic Girl")
        ComboBox2.Text = ComboBox2.Items(Int(Rnd() * ComboBox2.Items.Count))
        picPort.BackgroundImage = portrait.draw()

            'init()
    End Sub
    'CharacterGenerator1_FormClosing handles the finalization of the in game image library
    Private Sub CharacterGenerator1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Game.player.prt.iArr = portrait.iArr
        Game.player.prt.iArrInd = portrait.iArrInd
        Game.player.prt.haircolor = portrait.haircolor
        Game.player.prt.skincolor = portrait.skincolor

        If Not ComboBox2.Items.Contains(ComboBox2.Text) Then
            If MessageBox.Show("Woah there! You entered in a non recognized class.  You sure you want to do that?", "Sneeky sneek", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If
        Game.player.name = TextBox1.Text
        If portrait.sexBool Then
            Game.player.sex = "Female"
            Game.player.breastSize = 1
        Else
            Game.player.sex = "Male"
            Game.player.breastSize = -1
        End If
        Game.player.setClassLoadout(ComboBox2.Text)

        CommonClothes.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(CInt(portrait.iArrInd(3).Item1), False, False)
        CommonClothes.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(CInt(portrait.iArrInd(3).Item1), True, False)
        If portrait.iArrInd(3).Item1 < 5 Then
            CommonClothes.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(portrait.imgLib.atrs("Clothes").osf(CInt(portrait.iArrInd(3).Item1) + 99), True, False)
        ElseIf portrait.iArrInd(3).Item1 = 5 Then
            CommonClothes.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(portrait.imgLib.atrs("Clothes").osf(123), True, True)
        ElseIf portrait.iArrInd(3).Item1 = 6 Then
            CommonClothes.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(portrait.imgLib.atrs("Clothes").osf(124), True, True)
        Else
            CommonClothes.bsize2 = Nothing
        End If
    end sub
    'initializes and orders the image libraries without launching a CharacterGenerator1
    Public Sub init()

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
        Try
            If currAttribute.Equals(defImgLib.atrs("RearHair2")) Then
                Dim ind As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(pnlBody.Controls.IndexOf(sender), portrait.sexBool, False)

                portrait.setIAInd(1, ind)
                portrait.setIAInd(5, ind)

                picPort.BackgroundImage = portrait.draw()
                Exit Sub
            Else
                Dim i As Integer = defImgLib.atrs.Values.ToList.IndexOf(currAttribute)
                Dim ind As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(pnlBody.Controls.IndexOf(sender), portrait.sexBool, False)
                portrait.setIAInd(i, ind)

                picPort.BackgroundImage = portrait.draw()
            End If
        Catch ex As Exception
            If MessageBox.Show("Error! Exeption thrown in character creation.  Restart application?", "D_D Error 001", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Application.Restart()
            Else
                Application.Exit()
                End
            End If
        End Try
    End Sub
    

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

        currAtrButton.Enabled = True
        currAtrButton = btnBody
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("Body")
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs("Body").getF
        Else
            sexAttrList = defImgLib.atrs("Body").getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = recolor2(sexAttrList(i), portrait.skincolor)
            img.Location = New Point(x, y - 20)
            img.Size = New Point(70 * Me.Size.Width / 581, 104 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnFHair_Click(sender As Object, e As EventArgs) Handles btnFHair.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnFHair
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("FrontHair")
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs("FrontHair").getF
        Else
            sexAttrList = defImgLib.atrs("FrontHair").getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = recolor(sexAttrList(i), portrait.haircolor)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnEyes_Click(sender As Object, e As EventArgs) Handles btnEyes.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnEyes
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("Eyes")
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs("Eyes").getF
        Else
            sexAttrList = defImgLib.atrs("Eyes").getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = sexAttrList(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnMouth_Click(sender As Object, e As EventArgs) Handles btnMouth.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnMouth
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("Mouth")
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs("Mouth").getF
        Else
            sexAttrList = defImgLib.atrs("Mouth").getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = sexAttrList(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnMark_Click(sender As Object, e As EventArgs) Handles btnMark.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnMark
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("FacialMark")
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs("FacialMark").getF
        Else
            sexAttrList = defImgLib.atrs("FacialMark").getM
        End If

        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = sexAttrList(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnAcca_Click(sender As Object, e As EventArgs) Handles btnAcca.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnAcca
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("AccA")
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs("AccA").getF
        Else
            sexAttrList = defImgLib.atrs("AccA").getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = sexAttrList(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnFace_Click(sender As Object, e As EventArgs) Handles btnFace.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnFace
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("Face")
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs("Face").getF
        Else
            sexAttrList = defImgLib.atrs("Face").getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = recolor2(sexAttrList(i), portrait.skincolor)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnBHair_Click(sender As Object, e As EventArgs) Handles btnBHair.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnBHair
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("RearHair2")
        Dim sexAttrList1, sexAttrList2 As List(Of Image)
        If portrait.sexBool Then
            sexAttrList1 = defImgLib.atrs("RearHair2").getF
            sexAttrList2 = defImgLib.atrs("RearHair1").getF
        Else
            sexAttrList1 = defImgLib.atrs("RearHair2").getM
            sexAttrList2 = defImgLib.atrs("RearHair1").getM
        End If
        For i = 0 To sexAttrList1.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            Dim hairArr(1) As Image
            hairArr(0) = sexAttrList1(i)
            hairArr(1) = sexAttrList2(i)

            img.BackgroundImage = recolor(portrait.CreateBMP(hairArr), portrait.haircolor)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 104 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnEyebrows_Click(sender As Object, e As EventArgs) Handles btnEyebrows.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnEyebrows
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("Eyebrows")
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs("Eyebrows").getF
        Else
            sexAttrList = defImgLib.atrs("Eyebrows").getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = sexAttrList(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnEars_Click(sender As Object, e As EventArgs) Handles btnEars.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnEars
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("Ears")
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs("Ears").getF
        Else
            sexAttrList = defImgLib.atrs("Ears").getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = recolor2(sexAttrList(i), portrait.skincolor)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnClothes_Click(sender As Object, e As EventArgs) Handles btnClothes.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnClothes
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("Clothes")
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs("Clothes").getF
        Else
            sexAttrList = defImgLib.atrs("Clothes").getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = sexAttrList(i)
            img.Location = New Point(x, y - 20)
            img.Size = New Point(70 * Me.Size.Width / 581, 104 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnGlasses_Click(sender As Object, e As EventArgs) Handles btnGlasses.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnGlasses
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("Glasses")
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs("Glasses").getF
        Else
            sexAttrList = defImgLib.atrs("Glasses").getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = sexAttrList(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnCloak_Click(sender As Object, e As EventArgs) Handles btnCloak.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnCloak
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("Cloak")
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs("Cloak").getF
        Else
            sexAttrList = defImgLib.atrs("Cloak").getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = sexAttrList(i)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnHat_Click(sender As Object, e As EventArgs) Handles btnHat.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnHat
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("Hat")
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs("Hat").getF
        Else
            sexAttrList = defImgLib.atrs("Hat").getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = sexAttrList(i)
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
    'sets the default profile image based on the current sex
    Sub setDefaultProfilePic()
        Dim hc = portrait.haircolor
        Dim sc = portrait.skincolor
        portrait = New Portrait(portrait.sexBool, Nothing)
        portrait.haircolor = hc
        portrait.skincolor = sc
    End Sub
    'sex Selection buttons
    Private Sub btnMale_Click(sender As Object, e As EventArgs) Handles btnMale.Click
        portrait.setIAInd(2, 0, False, False)
        btnBody_Click(sender, e)

        btnFemale.Enabled = True
        btnMale.Enabled = False

        setDefaultProfilePic()

        picPort.BackgroundImage = portrait.draw
    End Sub
    Private Sub btnFemale_Click(sender As Object, e As EventArgs) Handles btnFemale.Click
        portrait.setIAInd(2, 0, True, False)
        btnBody_Click(sender, e)

        btnMale.Enabled = True
        btnFemale.Enabled = False

        setDefaultProfilePic()

        picPort.BackgroundImage = portrait.draw
    End Sub
    'haircolor change methods
    Private Sub btnHC_Click(sender As Object, e As EventArgs) Handles btnHC.Click
        Dim cd As New ColorDialog()
        cd.Color = portrait.haircolor
        cd.ShowDialog()
        changeHC(cd.Color)
        If currAtrButton.Equals(btnBHair) Then
            btnBHair_Click(sender, e)
        End If
        If currAtrButton.Equals(btnFHair) Then
            btnFHair_Click(sender, e)
        End If
        If currAtrButton.Equals(btnEyebrows) Then
            btnEyebrows_Click(sender, e)
        End If
        cd.Dispose()
    End Sub
    Sub changeHC(ByVal c As Color)
        portrait.haircolor = c

        picPort.BackgroundImage = portrait.draw
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
        portrait.skincolor = c

        picPort.BackgroundImage = portrait.draw()
    End Sub
    'randomizes the players portrait
    Private Sub btnRandom_Click(sender As Object, e As EventArgs) Handles btnRandom.Click
        Randomize()

        Dim r As Integer = Int(Rnd() * 7)
        portrait.setIAInd(1, r, portrait.sexBool, False)
        portrait.setIAInd(5, r, portrait.sexBool, False)

        r = Int(Rnd() * 7)
        portrait.setIAInd(3, r, portrait.sexBool, False)

        r = Int(Rnd() * 4)
        portrait.setIAInd(6, r, portrait.sexBool, False)

        r = Int(Rnd() * 11)
        portrait.setIAInd(8, r, portrait.sexBool, False)

        r = Int(Rnd() * 9)
        portrait.setIAInd(9, r, portrait.sexBool, False)

        r = Int(Rnd() * 8) + 1
        portrait.setIAInd(15, r, portrait.sexBool, False)

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

        picPort.BackgroundImage = portrait.draw
    End Sub

    Private Sub ComboBox2_TextChanged(sender As Object, e As EventArgs) Handles ComboBox2.TextChanged
        If Not ComboBox2.Items.Contains(ComboBox2.Text) Then ComboBox2.Text = ComboBox2.Items(0)
        btnSave.Focus()
    End Sub
End Class