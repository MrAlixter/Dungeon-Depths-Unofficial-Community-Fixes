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
    Dim iArr(16) As Image
    'Dim attrOrder As List(Of Image)
    Dim graph As Graphics = Me.CreateGraphics()
    Public currSex As Boolean = False
    Dim currAttribute As ImageAttribute
    Dim currAtrButton As New Button
    Dim newForm As Boolean = True

    Public quit As Boolean = False

    Dim iArrInd(16) As Tuple(Of Integer, Boolean)
    Dim sInts() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0} 'the starting indexes of each catagory

    Dim hairColor As Color = Color.FromArgb(255, 204, 203, 213)
    Dim skincolor As Color = Color.FromArgb(255, 247, 219, 195)

    Dim defImgLib As ImageCollection = New ImageCollection(0)
    Public imgLib As ImageCollection = New ImageCollection(-1)

    'CharGen1_Load handles the loading of the character generator
    Private Sub CharGen1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Game.player.skincolor = skincolor
        Game.player.haircolor = hairColor

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
        If currSex Then
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
            picPort.BackgroundImage = CreateBMP(iArr)

            'init()
    End Sub
    'CharacterGenerator1_FormClosing handles the finalization of the in game image library
    Private Sub CharacterGenerator1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Game.player.iArr = iArr
        Game.player.iArrInd = iArrInd

        imgLib.removePlaceholderNullImg(picPort.Image)

        If (ComboBox2.Text <> "Warrior" And ComboBox2.Text <> "Mage") Then
            If MessageBox.Show("Woah there! You entered in a non recognized class.  You sure you want to do that?", "Sneeky sneek", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
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
        Game.player.setClassLoadout(ComboBox2.Text)

        NormalClothes.bsizeneg1 = New Tuple(Of Integer, Boolean)(CInt(Game.player.iArrInd(3).Item1), False)
        NormalClothes.bsize1 = New Tuple(Of Integer, Boolean)(CInt(Game.player.iArrInd(3).Item1), True)
        NormalClothes.bsize2 = New Tuple(Of Integer, Boolean)(CInt(Game.player.iArrInd(3).Item1) + 99, True)
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
                Dim ind As Tuple(Of Integer, Boolean) = New Tuple(Of Integer, Boolean)(pnlBody.Controls.IndexOf(sender), currSex)
                iArr(1) = imgLib.atrs("RearHair2").getAt(ind)
                iArr(5) = imgLib.atrs("RearHair1").getAt(ind)

                iArrInd(1) = ind
                iArrInd(5) = ind
                picPort.BackgroundImage = CreateBMP(iArr)
                Exit Sub
            Else
                Dim i As Integer = defImgLib.atrs.Values.ToList.IndexOf(currAttribute)
                Dim ind As Tuple(Of Integer, Boolean) = New Tuple(Of Integer, Boolean)(pnlBody.Controls.IndexOf(sender), currSex)
                iArr(1) = imgLib.atrs("RearHair2").getAt(ind)
                iArrInd(1) = ind
                picPort.BackgroundImage = CreateBMP(iArr)
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
        If currSex Then
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
    End Sub
    Private Sub btnFHair_Click(sender As Object, e As EventArgs) Handles btnFHair.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnFHair
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("FrontHair")
        Dim sexAttrList As List(Of Image)
        If currSex Then
            sexAttrList = defImgLib.atrs("FrontHair").getF
        Else
            sexAttrList = defImgLib.atrs("FrontHair").getM
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
    Private Sub btnEyes_Click(sender As Object, e As EventArgs) Handles btnEyes.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnEyes
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("Eyes")
        Dim sexAttrList As List(Of Image)
        If currSex Then
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
        If currSex Then
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
        If currSex Then
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
        If currSex Then
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
        If currSex Then
            sexAttrList = defImgLib.atrs("Face").getF
        Else
            sexAttrList = defImgLib.atrs("Face").getM
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
    Private Sub btnBHair_Click(sender As Object, e As EventArgs) Handles btnBHair.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnBHair
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("RearHair2")
        Dim sexAttrList1, sexAttrList2 As List(Of Image)
        If currSex Then
            sexAttrList1 = defImgLib.atrs("RearHair2").getF
            sexAttrList2 = defImgLib.atrs("RearHair2").getF
        Else
            sexAttrList1 = defImgLib.atrs("RearHair1").getM
            sexAttrList2 = defImgLib.atrs("RearHair1").getM
        End If
        For i = 0 To sexAttrList1.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            Dim hairArr(1) As Image
            hairArr(0) = sexAttrList1(i)
            hairArr(1) = sexAttrList2(i)

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

        currAtrButton.Enabled = True
        currAtrButton = btnEyebrows
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("Eyebrows")
        Dim sexAttrList As List(Of Image)
        If currSex Then
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
        If currSex Then
            sexAttrList = defImgLib.atrs("Ears").getF
        Else
            sexAttrList = defImgLib.atrs("Ears").getM
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
    Private Sub btnClothes_Click(sender As Object, e As EventArgs) Handles btnClothes.Click
        pnlBody.Controls.Clear()
        
        currAtrButton.Enabled = True
        currAtrButton = btnClothes
        currAtrButton.Enabled = False

        currAttribute = defImgLib.atrs("Clothes")
        Dim sexAttrList As List(Of Image)
        If currSex Then
            sexAttrList = defImgLib.atrs("Clothes").getF
            iArr(2) = imgLib.atrs("Body").getF(4)
            recolor2(iArr(2), skincolor)
            picPort.BackgroundImage = CreateBMP(iArr)
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
        If currSex Then
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
        If currSex Then
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
        If currSex Then
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
        Dim defInd0 = New Tuple(Of Integer, Boolean)(0, currSex)
        Dim defInd1 = New Tuple(Of Integer, Boolean)(1, currSex)
        iArr(0) = defImgLib.atrs("bkg").getAt(defInd0)
        iArr(1) = defImgLib.atrs("RearHair2").getAt(defInd0)
        iArr(2) = defImgLib.atrs("Body").getAt(defInd0)
        iArr(3) = defImgLib.atrs("Clothes").getAt(defInd0)
        iArr(4) = defImgLib.atrs("Face").getAt(defInd0)
        iArr(5) = defImgLib.atrs("RearHair1").getAt(defInd0)
        iArr(6) = defImgLib.atrs("Ears").getAt(defInd0)
        iArr(7) = defImgLib.atrs("Nose").getAt(defInd0)
        iArr(8) = defImgLib.atrs("Mouth").getAt(defInd0)
        iArr(9) = defImgLib.atrs("Eyes").getAt(defInd0)
        iArr(10) = defImgLib.atrs("Eyebrows").getAt(defInd0)
        iArr(11) = picPort.Image
        iArr(12) = picPort.Image
        iArr(13) = picPort.Image
        iArr(14) = picPort.Image
        iArr(15) = defImgLib.atrs("FrontHair").getAt(defInd1)
        iArr(16) = picPort.Image

        For i = 0 To 16
            iArrInd(i) = New Tuple(Of Integer, Boolean)(sInts(i), currSex)
        Next
    End Sub
    'sex Selection buttons
    Private Sub btnMale_Click(sender As Object, e As EventArgs) Handles btnMale.Click
        currSex = False
        Game.player.sexBool = False

        btnBody_Click(sender, e)

        btnFemale.Enabled = True
        btnMale.Enabled = False

        setDefaultProfilePic()

        changeHC(hairColor)
        changeSC(skincolor)
        picPort.BackgroundImage = CreateBMP(iArr)
    End Sub
    Private Sub btnFemale_Click(sender As Object, e As EventArgs) Handles btnFemale.Click
        currSex = True
        Game.player.sexBool = True
        
        btnBody_Click(sender, e)

        btnMale.Enabled = True
        btnFemale.Enabled = False

        setDefaultProfilePic()

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
        Game.player.haircolor = c
        hairColor = c
        
        iArr(1) = recolor(imgLib.atrs("RearHair2").getAt(iArrInd(1)), c)
        iArr(5) = recolor(imgLib.atrs("RearHair1").getAt(iArrInd(5)), c)
        iArr(10) = recolor(imgLib.atrs("Eyebrows").getAt(iArrInd(10)), c)
        iArr(15) = recolor(imgLib.atrs("FrontHair").getAt(iArrInd(15)), c)

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
        
        iArr(2) = recolor2(imgLib.atrs("Body").getAt(iArrInd(2)), c)
        iArr(4) = recolor2(imgLib.atrs("Face").getAt(iArrInd(4)), c)
        iArr(6) = recolor2(imgLib.atrs("Ears").getAt(iArrInd(6)), c)
        iArr(7) = recolor2(imgLib.atrs("Nose").getAt(iArrInd(7)), c)
        
        picPort.BackgroundImage = CreateBMP(iArr)
    End Sub
    'randomizes the players portrait
    Private Sub btnRandom_Click(sender As Object, e As EventArgs) Handles btnRandom.Click
        Randomize()

            Dim r As Integer = Int(Rnd() * 5)
            iArrInd(1) = New Tuple(Of Integer, Boolean)(r, currSex)
        iArr(1) = imgLib.atrs("RearHair2").getAt(iArrInd(1))
            iArrInd(5) = New Tuple(Of Integer, Boolean)(r, currSex)
        iArr(5) = imgLib.atrs("RearHair1").getAt(iArrInd(5))
            r = Int(Rnd() * 5)
            iArrInd(3) = New Tuple(Of Integer, Boolean)(r, currSex)
        iArr(3) = imgLib.atrs("Clothes").getAt(iArrInd(3))
            r = Int(Rnd() * 4)
            iArrInd(6) = New Tuple(Of Integer, Boolean)(r, currSex)
        iArr(6) = imgLib.atrs("Ears").getAt(iArrInd(6))
            r = Int(Rnd() * 3)
            If r = 1 Then r = 4
            iArrInd(8) = New Tuple(Of Integer, Boolean)(r, currSex)
        iArr(8) = imgLib.atrs("Mouth").getAt(iArrInd(8))
            r = Int(Rnd() * 3)
            iArrInd(9) = New Tuple(Of Integer, Boolean)(r, currSex)
        iArr(9) = imgLib.atrs("Eyes").getAt(iArrInd(9))
            r = Int(Rnd() * 4) + 1
            iArrInd(15) = New Tuple(Of Integer, Boolean)(r, currSex)
        iArr(15) = imgLib.atrs("FrontHair").getAt(iArrInd(15))

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