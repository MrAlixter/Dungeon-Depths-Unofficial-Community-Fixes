Public Class CharacterGenerator
    'CharacterGenerator1 is the form that allows the assembly of a player portrait

    'CharacterGenerator1's instance variables
    'Dim attrOrder As List(Of Image)
    Dim graph As Graphics = Me.CreateGraphics()
    Dim currAttribute As pInd
    Dim currAtrButton As New Button
    Dim newForm As Boolean = True

    Public quit As Boolean = False

    Dim portrait As Portrait = New Portrait(False, Nothing)

    Dim defImgLib As ImageCollection = New ImageCollection(0)

    'CharGen1_Load handles the loading of the character generator
    Private Sub CharGen1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'scale to the screen size
        DDUtils.resizeForm(Me)

        btnBody_Click(sender, e)

        setDefaultProfilePic()

        ComboBox2.Items.Add("Warrior")
        ComboBox2.Items.Add("Mage")
        ComboBox2.Items.Add("Rogue")
        ComboBox2.Items.Add("Cleric")
        ComboBox2.Items.Add("Magical Girl")
        ComboBox2.Items.Add("Valkyrie")
        'ComboBox2.Items.Add("Evil Mage")
        If DDDateTime.isHallow Then ComboBox2.Items.Add("Witch")
        If Game.compOOT Then ComboBox2.Items.Add("Time Cop")

        ComboBox2.Text = ComboBox2.Items(Int(Rnd() * ComboBox2.Items.Count))
        picPort.BackgroundImage = portrait.draw()

        'init()
        getPresets()
    End Sub
    'CharacterGenerator1_FormClosing handles the finalization of the in game image library
    Private Sub CharacterGenerator1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Game.player1.prt.iArr = portrait.iArr
        Game.player1.prt.iArrInd = portrait.iArrInd
        Game.player1.prt.haircolor = portrait.haircolor
        Game.player1.prt.skincolor = portrait.skincolor

        If Not ComboBox2.Items.Contains(ComboBox2.Text) Then
            If MessageBox.Show("Woah there! You entered in a non recognized class.  You sure you want to do that?", "Sneeky sneek", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If
        Game.player1.name = TextBox1.Text
        If portrait.sexBool Then
            Game.player1.sex = "Female"
            Game.player1.breastSize = 1
            Game.player1.dickSize = -1
            Game.player1.buttSize = 1
        Else
            Game.player1.sex = "Male"
            Game.player1.breastSize = -1
            Game.player1.dickSize = 1
            Game.player1.buttSize = -1
        End If

        Game.player1.setClassLoadout(ComboBox2.Text)

        If chkSavePreset.Checked And Not quit Then
            Dim preset = New PCPreset()
            preset.save(ComboBox2.Text)
        End If
    End Sub
    'initializes and orders the image libraries without launching a CharacterGenerator1
    Public Sub init()

    End Sub
    Sub getPresets()
        Dim dir = New IO.DirectoryInfo("Presets")
        Try
            Dim presets = dir.GetFiles("*.pset", IO.SearchOption.AllDirectories).ToList
            For Each pset In presets.OrderBy(Function(i) i.Name)
                cBoxPresets.Items.Add(pset.Name)
            Next
        Catch e As Exception
        End Try
    End Sub
    'PicOnClick handles the selecting of images via click
    Sub PicOnClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If currAttribute.Equals(pInd.rearhair) Then
                Dim ind As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(pnlBody.Controls.IndexOf(sender), portrait.sexBool, False)

                portrait.setIAInd(pInd.rearhair, ind)
                portrait.setIAInd(pInd.midhair, ind)

                picPort.BackgroundImage = portrait.draw()
                Exit Sub
            ElseIf currAttribute.Equals(pInd.body) Then
                If portrait.sexBool Then
                    setFBody()
                Else
                    setMBody()
                End If

                picPort.BackgroundImage = portrait.draw()
                Exit Sub
            ElseIf currAttribute.Equals(pInd.clothes) Then
                Dim ind As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(pnlBody.Controls.IndexOf(sender), portrait.sexBool, False)

                portrait.setIAInd(pInd.clothes, ind)
                portrait.setIAInd(pInd.clothesbtm, New Tuple(Of Integer, Boolean, Boolean)(pnlBody.Controls.IndexOf(sender) * 2, portrait.sexBool, False))

                picPort.BackgroundImage = portrait.draw()
                Exit Sub
            Else
                Dim i As Integer = currAttribute
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

        currAttribute = pInd.body
        Dim sexAttrList1, sexAttrList2, sexAttrList3, sexAttrList4 As List(Of Image)
        If portrait.sexBool Then
            sexAttrList1 = defImgLib.atrs(pInd.body).getF
            sexAttrList2 = defImgLib.atrs(pInd.shoulders).getF
            sexAttrList3 = defImgLib.atrs(pInd.genitalia).getF
            sexAttrList4 = defImgLib.atrs(pInd.chest).getF
        Else
            sexAttrList1 = defImgLib.atrs(pInd.body).getM
            sexAttrList2 = defImgLib.atrs(pInd.shoulders).getM
            sexAttrList3 = defImgLib.atrs(pInd.genitalia).getM
            sexAttrList4 = defImgLib.atrs(pInd.chest).getM
        End If
        For i = 0 To sexAttrList1.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox

            Dim bodyArr(3) As Image
            bodyArr(0) = sexAttrList1(i)
            bodyArr(1) = sexAttrList2(i)
            bodyArr(2) = sexAttrList3(i)
            bodyArr(3) = sexAttrList4(i)

            img.BackgroundImage = Portrait.skinRecolor(portrait.CreateFullBodyBMP(bodyArr), portrait.skincolor)
            img.Location = New Point(x, y - 20)
            img.Size = New Point(70 * Me.Size.Width / 581, 260 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Sub setMBody()
        portrait.setIAInd(pInd.body, New Tuple(Of Integer, Boolean, Boolean)(0, False, False))
        portrait.setIAInd(pInd.chest, New Tuple(Of Integer, Boolean, Boolean)(0, False, False))
        portrait.setIAInd(pInd.shoulders, New Tuple(Of Integer, Boolean, Boolean)(0, False, False))
        portrait.setIAInd(pInd.genitalia, New Tuple(Of Integer, Boolean, Boolean)(1, False, False))
    End Sub
    Sub setFBody()
        portrait.setIAInd(pInd.body, New Tuple(Of Integer, Boolean, Boolean)(0, True, False))
        portrait.setIAInd(pInd.chest, New Tuple(Of Integer, Boolean, Boolean)(9, True, False))
        portrait.setIAInd(pInd.shoulders, New Tuple(Of Integer, Boolean, Boolean)(2, True, False))
        portrait.setIAInd(pInd.genitalia, New Tuple(Of Integer, Boolean, Boolean)(4, True, False))
    End Sub
    Private Sub btnFHair_Click(sender As Object, e As EventArgs) Handles btnFHair.Click
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        currAtrButton = btnFHair
        currAtrButton.Enabled = False

        currAttribute = pInd.fronthair
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs(pInd.fronthair).getF
        Else
            sexAttrList = defImgLib.atrs(pInd.fronthair).getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = portrait.CreateFullBodyBMP({picPort.Image, portrait.hairRecolor(sexAttrList(i), portrait.haircolor)})
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 260 * Me.Size.Width / 581)
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

        currAttribute = pInd.eyes
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs(pInd.eyes).getF
        Else
            sexAttrList = defImgLib.atrs(pInd.eyes).getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = portrait.CreateBMP({picPort.Image, sexAttrList(i)}, False)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 120 * Me.Size.Width / 581)
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

        currAttribute = pInd.mouth
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs(pInd.mouth).getF
        Else
            sexAttrList = defImgLib.atrs(pInd.mouth).getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = portrait.CreateBMP({picPort.Image, sexAttrList(i)}, False)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 120 * Me.Size.Width / 581)
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

        currAttribute = pInd.facemark
        Dim sexAttrList1 As List(Of Image)
        If portrait.sexBool Then
            sexAttrList1 = defImgLib.atrs(pInd.facemark).getF
        Else
            sexAttrList1 = defImgLib.atrs(pInd.facemark).getM
        End If

        For i = 0 To sexAttrList1.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            If i <> 0 Then img.BackgroundImage = portrait.CreateFullBodyBMP({portrait.nullImg, portrait.iArr(pInd.face), sexAttrList1(i)}) Else img.BackgroundImage = portrait.CreateFullBodyBMP({portrait.nullImg, sexAttrList1(i)})
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 260 * Me.Size.Width / 581)
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

        currAttribute = pInd.accessory
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs(pInd.accessory).getF
        Else
            sexAttrList = defImgLib.atrs(pInd.accessory).getM
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

        currAttribute = pInd.face
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs(pInd.face).getF
        Else
            sexAttrList = defImgLib.atrs(pInd.face).getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = Portrait.skinRecolor(sexAttrList(i), portrait.skincolor)
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

        currAttribute = pInd.rearhair
        Dim sexAttrList1, sexAttrList2 As List(Of Image)
        If portrait.sexBool Then
            sexAttrList1 = defImgLib.atrs(pInd.rearhair).getF
            sexAttrList2 = defImgLib.atrs(pInd.midhair).getF
        Else
            sexAttrList1 = defImgLib.atrs(pInd.rearhair).getM
            sexAttrList2 = defImgLib.atrs(pInd.midhair).getM
        End If
        For i = 0 To sexAttrList1.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            Dim hairArr(2) As Image
            hairArr(0) = picPort.Image
            hairArr(1) = sexAttrList1(i)
            hairArr(2) = sexAttrList2(i)

            img.BackgroundImage = Portrait.hairRecolor(portrait.CreateFullBodyBMP(hairArr), portrait.haircolor)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 260 * Me.Size.Width / 581)
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

        currAttribute = pInd.eyebrows
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs(pInd.eyebrows).getF
        Else
            sexAttrList = defImgLib.atrs(pInd.eyebrows).getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = portrait.CreateBMP({picPort.Image, sexAttrList(i)}, False)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 120 * Me.Size.Width / 581)
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

        currAttribute = pInd.ears
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs(pInd.ears).getF
        Else
            sexAttrList = defImgLib.atrs(pInd.ears).getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = portrait.CreateBMP({picPort.Image, portrait.skinRecolor(sexAttrList(i), portrait.skincolor)}, False)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 120 * Me.Size.Width / 581)
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

        currAttribute = pInd.clothes
        Dim sexAttrList1, sexAttrList2 As List(Of Image)
        If portrait.sexBool Then
            sexAttrList1 = defImgLib.atrs(pInd.clothes).getF
            sexAttrList2 = defImgLib.atrs(pInd.clothesbtm).getF
        Else
            sexAttrList1 = defImgLib.atrs(pInd.clothes).getM
            sexAttrList2 = defImgLib.atrs(pInd.clothesbtm).getM
        End If
        For i = 0 To sexAttrList1.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox

            Dim clothesArr(2) As Image
            clothesArr(1) = sexAttrList1(i)

            clothesArr(0) = sexAttrList2(i * 2)


            img.BackgroundImage = portrait.CreateFullBodyBMP(clothesArr)
            img.Location = New Point(x, y - 70)
            img.Size = New Point(70 * Me.Size.Width / 581, 260 * Me.Size.Width / 581)
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

        currAttribute = pInd.glasses
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs(pInd.glasses).getF
        Else
            sexAttrList = defImgLib.atrs(pInd.glasses).getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = portrait.CreateBMP({picPort.Image, sexAttrList(i)}, False)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 130 * Me.Size.Width / 581)
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

        currAttribute = pInd.cloak
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs(pInd.cloak).getF
        Else
            sexAttrList = defImgLib.atrs(pInd.cloak).getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = portrait.CreateBMP({picPort.Image, sexAttrList(i)}, False)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 130 * Me.Size.Width / 581)
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

        currAttribute = pInd.hat
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs(pInd.hat).getF
        Else
            sexAttrList = defImgLib.atrs(pInd.hat).getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = portrait.CreateBMP({picPort.Image, sexAttrList(i)}, False)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 130 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnChest_Click(sender As Object, e As EventArgs)
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        'currAtrButton = btnChest
        currAtrButton.Enabled = False

        currAttribute = pInd.chest
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs(pInd.chest).getF
        Else
            sexAttrList = defImgLib.atrs(pInd.chest).getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = Portrait.skinRecolor(sexAttrList(i), portrait.skincolor)
            img.Location = New Point(x, y - 20)
            img.Size = New Point(70 * Me.Size.Width / 581, 260 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnShoulders_Click(sender As Object, e As EventArgs)
        pnlBody.Controls.Clear()

        currAtrButton.Enabled = True
        'currAtrButton = btnShoulders
        currAtrButton.Enabled = False

        currAttribute = pInd.shoulders
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = defImgLib.atrs(pInd.shoulders).getF
        Else
            sexAttrList = defImgLib.atrs(pInd.shoulders).getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = Portrait.skinRecolor(sexAttrList(i), portrait.skincolor)
            img.Location = New Point(x, y - 20)
            img.Size = New Point(70 * Me.Size.Width / 581, 260 * Me.Size.Width / 581)
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
        portrait.setIAInd(pInd.genitalia, 1, False, False)
        btnBody_Click(sender, e)

        btnFemale.Enabled = True
        btnMale.Enabled = False

        setDefaultProfilePic()

        picPort.BackgroundImage = portrait.draw
    End Sub
    Private Sub btnFemale_Click(sender As Object, e As EventArgs) Handles btnFemale.Click
        portrait.setIAInd(pInd.genitalia, 4, True, False)
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
        portrait.setIAInd(pInd.rearhair, r, portrait.sexBool, False)
        portrait.setIAInd(pInd.midhair, r, portrait.sexBool, False)

        Dim r2 = Int(Rnd() * 8)
        portrait.setIAInd(pInd.clothes, r2, portrait.sexBool, False)
        portrait.setIAInd(pInd.clothesbtm, r2 * 2, portrait.sexBool, False)

        r = Int(Rnd() * 4)
        portrait.setIAInd(pInd.ears, r, portrait.sexBool, False)

        r = Int(Rnd() * 6)
        portrait.setIAInd(pInd.facemark, r, portrait.sexBool, False)

        r = Int(Rnd() * 11)
        portrait.setIAInd(pInd.mouth, r, portrait.sexBool, False)

        r = Int(Rnd() * 9)
        portrait.setIAInd(pInd.eyes, r, portrait.sexBool, False)

        r = Int(Rnd() * 8) + 1
        portrait.setIAInd(pInd.fronthair, r, portrait.sexBool, False)

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

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        cBoxPresets.SelectionLength = 0
    End Sub

    Private Sub cBoxPresets_TextChanged(sender As Object, e As EventArgs) Handles cBoxPresets.TextChanged
        If cBoxPresets.Text = "--- (none) ---" Or cBoxPresets.SelectedIndex = -1 Then Exit Sub
        Dim preset = New PCPreset("presets/" & cBoxPresets.Text)

        If Not ComboBox2.Items.Contains(preset.pClass) Then ComboBox2.Items.Add(preset.pClass)
        ComboBox2.SelectedItem = preset.pClass

        TextBox1.Text = preset.pName
        portrait.iArrInd = preset.iArrInd

        If preset.sexbool Then
            If btnFemale.Enabled Then btnFemale_Click(sender, e)
        Else
            If btnMale.Enabled Then btnMale_Click(sender, e)
        End If

        ReDim portrait.iArrInd(UBound(preset.iArrInd))
        For i = 0 To UBound(portrait.iArrInd)
            portrait.iArrInd(i) = (preset.iArrInd(i))
        Next

        portrait.haircolor = preset.haircolor
        portrait.skincolor = preset.skincolor

        picPort.BackgroundImage = portrait.draw
    End Sub
End Class