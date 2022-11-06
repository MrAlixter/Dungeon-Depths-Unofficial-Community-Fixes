Public Class CharacterGenerator
    '| - SELECTION HANDLERS - |
    Dim selected_pind As pInd
    Dim selected_pind_button As New Button

    '| - PORTRAIT - |
    Dim portrait As Portrait = New Portrait(False, Nothing)
    Private Shared default_img_lib As ImageCollection

    '| - MISC. VARIABLES - |
    Public quit_early As Boolean = False

    '| - CONSTRUCTORS - |
    Shared Sub New()
        'only set the default image library once when the game starts
        default_img_lib = New ImageCollection(0)
    End Sub

    '| - EVENT HANDLERS -|
    Private Sub CharacterGenerator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DDUtils.resizeForm(Me)
        Me.CenterToParent()

        btnBody_Click(sender, e)

        setDefaultProfilePic()

        setAvailibleClasses(cboxClass)

        picPort.BackgroundImage = portrait.draw()

        getPresets()
    End Sub
    Private Sub CharacterGenerator_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'set the player's image, name, and class
        setPlayerPortrait(Game.player1)
        Game.player1.setName(sanitizeName(txtName.Text))
        Game.player1.setClassLoadout(cboxClass.Text)

        'if selected, save a preset using the currently selected images
        If chkSavePreset.Checked And Not quit_early Then
            Dim preset = New PCPreset()
            preset.save(cboxClass.Text)
        End If
    End Sub
    Private Sub cboxClass_TextChanged(sender As Object, e As EventArgs) Handles cboxClass.TextChanged
        'if an unrecognized class is selected, default to the first valid one we can find
        If Not cboxClass.Items.Contains(cboxClass.Text) Then cboxClass.Text = cboxClass.Items(0)
        btnSave.Focus()
    End Sub
    Private Sub cBoxPresets_TextChanged(sender As Object, e As EventArgs) Handles cboxPresets.TextChanged
        'load the selected preset (if possible)
        If cboxPresets.Text = "--- (none) ---" Or cboxPresets.SelectedIndex = -1 Then Exit Sub
        Dim preset = New PCPreset("presets/" & cboxPresets.Text)

        If Not cboxClass.Items.Contains(preset.pClass) Then cboxClass.Items.Add(preset.pClass)
        cboxClass.SelectedItem = preset.pClass

        txtName.Text = preset.pName
        portrait.iArrInd = preset.iArrInd

        If preset.sexbool Then
            If btnFemale.Enabled Then btnFemale_Click(sender, e)
        Else
            If btnMale.Enabled Then btnMale_Click(sender, e)
        End If

        ReDim portrait.iArrInd(portrait.NUM_IMG_LAYERS)
        For i = 0 To UBound(portrait.iArrInd)
            portrait.iArrInd(i) = (preset.iArrInd(i))
        Next

        portrait.haircolor = preset.haircolor
        portrait.skincolor = preset.skincolor

        picPort.BackgroundImage = portrait.draw
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        'don't highlight the selected preset (it looks weird)
        MyBase.OnPaint(e)

        cboxPresets.SelectionLength = 0
    End Sub

    '| - BUTTON HANDLERS - |
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'closes the form, finalizing the player's character choices
        Me.Close()
    End Sub
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'quits to main menu without starting a game
        quit_early = True
        Me.Close()
    End Sub
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

    Private Sub btnHC_Click(sender As Object, e As EventArgs) Handles btnHC.Click
        Dim cd As New ColorDialog()
        cd.Color = portrait.haircolor
        cd.ShowDialog()
        changeHC(cd.Color)
        If selected_pind_button.Equals(btnBHair) Then
            btnBHair_Click(sender, e)
        End If
        If selected_pind_button.Equals(btnFHair) Then
            btnFHair_Click(sender, e)
        End If
        If selected_pind_button.Equals(btnEyebrows) Then
            btnEyebrows_Click(sender, e)
        End If
        cd.Dispose()
    End Sub
    Private Sub btnSC_Click(sender As Object, e As EventArgs) Handles btnSC.Click
        Dim cd As New SCPicker
        cd.ShowDialog()
        changeSC(cd.sc)
        cd.Dispose()
        btnBody_Click(sender, e)
    End Sub

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

    Sub PicOnClick(ByVal sender As Object, ByVal e As EventArgs)
        'when you click on one of the image options for the selected pind, apply it to the portrait
        Try
            If selected_pind.Equals(pInd.rearhair) Then
                Dim ind As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(pnlBody.Controls.IndexOf(sender), portrait.sexBool, False)

                portrait.setIAInd(pInd.rearhair, ind)
                portrait.setIAInd(pInd.midhair, ind)

                picPort.BackgroundImage = portrait.draw()
                Exit Sub
            ElseIf selected_pind.Equals(pInd.body) Then
                If portrait.sexBool Then
                    setFBody()
                Else
                    setMBody()
                End If

                picPort.BackgroundImage = portrait.draw()
                Exit Sub
            ElseIf selected_pind.Equals(pInd.clothes) Then
                Dim ind As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(pnlBody.Controls.IndexOf(sender), portrait.sexBool, False)

                portrait.setIAInd(pInd.clothes, ind)
                portrait.setIAInd(pInd.clothesbtm, New Tuple(Of Integer, Boolean, Boolean)(pnlBody.Controls.IndexOf(sender) * 2, portrait.sexBool, False))

                picPort.BackgroundImage = portrait.draw()
                Exit Sub
            Else
                Dim i As Integer = selected_pind
                Dim ind As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(pnlBody.Controls.IndexOf(sender), portrait.sexBool, False)
                portrait.setIAInd(i, ind)

                picPort.BackgroundImage = portrait.draw()
            End If
        Catch ex As Exception
            DDError.characterCreationError()
        End Try
    End Sub

    Private Sub btnBody_Click(sender As Object, e As EventArgs) Handles btnBody.Click
        pnlBody.Controls.Clear()

        selected_pind_button.Enabled = True
        selected_pind_button = btnBody
        selected_pind_button.Enabled = False

        selected_pind = pInd.body
        Dim sexAttrList1, sexAttrList2, sexAttrList3, sexAttrList4 As List(Of Image)
        If portrait.sexBool Then
            sexAttrList1 = default_img_lib.atrs(pInd.body).getF
            sexAttrList2 = default_img_lib.atrs(pInd.shoulders).getF
            sexAttrList3 = default_img_lib.atrs(pInd.genitalia).getF
            sexAttrList4 = default_img_lib.atrs(pInd.chest).getF
        Else
            sexAttrList1 = default_img_lib.atrs(pInd.body).getM
            sexAttrList2 = default_img_lib.atrs(pInd.shoulders).getM
            sexAttrList3 = default_img_lib.atrs(pInd.genitalia).getM
            sexAttrList4 = default_img_lib.atrs(pInd.chest).getM
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

            img.BackgroundImage = portrait.skinRecolor(portrait.CreateFullBodyBMP(bodyArr), portrait.skincolor)
            img.Location = New Point(x, y - 20)
            img.Size = New Point(70 * Me.Size.Width / 581, 260 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnFHair_Click(sender As Object, e As EventArgs) Handles btnFHair.Click
        pnlBody.Controls.Clear()

        selected_pind_button.Enabled = True
        selected_pind_button = btnFHair
        selected_pind_button.Enabled = False

        selected_pind = pInd.fronthair
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = default_img_lib.atrs(pInd.fronthair).getF
        Else
            sexAttrList = default_img_lib.atrs(pInd.fronthair).getM
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

        selected_pind_button.Enabled = True
        selected_pind_button = btnEyes
        selected_pind_button.Enabled = False

        selected_pind = pInd.eyes
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = default_img_lib.atrs(pInd.eyes).getF
        Else
            sexAttrList = default_img_lib.atrs(pInd.eyes).getM
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

        selected_pind_button.Enabled = True
        selected_pind_button = btnMouth
        selected_pind_button.Enabled = False

        selected_pind = pInd.mouth
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = default_img_lib.atrs(pInd.mouth).getF
        Else
            sexAttrList = default_img_lib.atrs(pInd.mouth).getM
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

        selected_pind_button.Enabled = True
        selected_pind_button = btnMark
        selected_pind_button.Enabled = False

        selected_pind = pInd.facemark
        Dim sexAttrList1 As List(Of Image)
        If portrait.sexBool Then
            sexAttrList1 = default_img_lib.atrs(pInd.facemark).getF
        Else
            sexAttrList1 = default_img_lib.atrs(pInd.facemark).getM
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

        selected_pind_button.Enabled = True
        selected_pind_button = btnAcca
        selected_pind_button.Enabled = False

        selected_pind = pInd.accessory
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = default_img_lib.atrs(pInd.accessory).getF
        Else
            sexAttrList = default_img_lib.atrs(pInd.accessory).getM
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

        selected_pind_button.Enabled = True
        selected_pind_button = btnFace
        selected_pind_button.Enabled = False

        selected_pind = pInd.face
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = default_img_lib.atrs(pInd.face).getF
        Else
            sexAttrList = default_img_lib.atrs(pInd.face).getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = portrait.skinRecolor(sexAttrList(i), portrait.skincolor)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 70 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnBHair_Click(sender As Object, e As EventArgs) Handles btnBHair.Click
        pnlBody.Controls.Clear()

        selected_pind_button.Enabled = True
        selected_pind_button = btnBHair
        selected_pind_button.Enabled = False

        selected_pind = pInd.rearhair
        Dim sexAttrList1, sexAttrList2 As List(Of Image)
        If portrait.sexBool Then
            sexAttrList1 = default_img_lib.atrs(pInd.rearhair).getF
            sexAttrList2 = default_img_lib.atrs(pInd.midhair).getF
        Else
            sexAttrList1 = default_img_lib.atrs(pInd.rearhair).getM
            sexAttrList2 = default_img_lib.atrs(pInd.midhair).getM
        End If
        For i = 0 To sexAttrList1.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            Dim hairArr(2) As Image
            hairArr(0) = picPort.Image
            hairArr(1) = sexAttrList1(i)
            hairArr(2) = sexAttrList2(i)

            img.BackgroundImage = portrait.hairRecolor(portrait.CreateFullBodyBMP(hairArr), portrait.haircolor)
            img.Location = New Point(x, y)
            img.Size = New Point(70 * Me.Size.Width / 581, 260 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnEyebrows_Click(sender As Object, e As EventArgs) Handles btnEyebrows.Click
        pnlBody.Controls.Clear()

        selected_pind_button.Enabled = True
        selected_pind_button = btnEyebrows
        selected_pind_button.Enabled = False

        selected_pind = pInd.eyebrows
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = default_img_lib.atrs(pInd.eyebrows).getF
        Else
            sexAttrList = default_img_lib.atrs(pInd.eyebrows).getM
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

        selected_pind_button.Enabled = True
        selected_pind_button = btnEars
        selected_pind_button.Enabled = False

        selected_pind = pInd.ears
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = default_img_lib.atrs(pInd.ears).getF
        Else
            sexAttrList = default_img_lib.atrs(pInd.ears).getM
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

        selected_pind_button.Enabled = True
        selected_pind_button = btnClothes
        selected_pind_button.Enabled = False

        selected_pind = pInd.clothes
        Dim sexAttrList1, sexAttrList2 As List(Of Image)
        If portrait.sexBool Then
            sexAttrList1 = default_img_lib.atrs(pInd.clothes).getF
            sexAttrList2 = default_img_lib.atrs(pInd.clothesbtm).getF
        Else
            sexAttrList1 = default_img_lib.atrs(pInd.clothes).getM
            sexAttrList2 = default_img_lib.atrs(pInd.clothesbtm).getM
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

        selected_pind_button.Enabled = True
        selected_pind_button = btnGlasses
        selected_pind_button.Enabled = False

        selected_pind = pInd.glasses
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = default_img_lib.atrs(pInd.glasses).getF
        Else
            sexAttrList = default_img_lib.atrs(pInd.glasses).getM
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
    Private Sub btnCloak_Click(sender As Object, e As EventArgs) Handles btnCloak.Click
        pnlBody.Controls.Clear()

        selected_pind_button.Enabled = True
        selected_pind_button = btnCloak
        selected_pind_button.Enabled = False

        selected_pind = pInd.cloak
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = default_img_lib.atrs(pInd.cloak).getF
        Else
            sexAttrList = default_img_lib.atrs(pInd.cloak).getM
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

        selected_pind_button.Enabled = True
        selected_pind_button = btnHat
        selected_pind_button.Enabled = False

        selected_pind = pInd.hat
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = default_img_lib.atrs(pInd.hat).getF
        Else
            sexAttrList = default_img_lib.atrs(pInd.hat).getM
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
    Private Sub btnChest_Click(sender As Object, e As EventArgs)
        pnlBody.Controls.Clear()

        selected_pind_button.Enabled = True
        'selected_pind_button = btnChest
        selected_pind_button.Enabled = False

        selected_pind = pInd.chest
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = default_img_lib.atrs(pInd.chest).getF
        Else
            sexAttrList = default_img_lib.atrs(pInd.chest).getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = portrait.skinRecolor(sexAttrList(i), portrait.skincolor)
            img.Location = New Point(x, y - 20)
            img.Size = New Point(70 * Me.Size.Width / 581, 260 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub
    Private Sub btnShoulders_Click(sender As Object, e As EventArgs)
        pnlBody.Controls.Clear()

        selected_pind_button.Enabled = True
        'selected_pind_button = btnShoulders
        selected_pind_button.Enabled = False

        selected_pind = pInd.shoulders
        Dim sexAttrList As List(Of Image)
        If portrait.sexBool Then
            sexAttrList = default_img_lib.atrs(pInd.shoulders).getF
        Else
            sexAttrList = default_img_lib.atrs(pInd.shoulders).getM
        End If
        For i = 0 To sexAttrList.Count - 1
            Dim x As Integer = (i * 71 * Me.Size.Width / 581)
            Dim y As Integer = 0
            Dim img As New PictureBox
            img.BackgroundImage = portrait.skinRecolor(sexAttrList(i), portrait.skincolor)
            img.Location = New Point(x, y - 20)
            img.Size = New Point(70 * Me.Size.Width / 581, 260 * Me.Size.Width / 581)
            img.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler img.Click, AddressOf PicOnClick
            pnlBody.Controls.Add(img)
        Next
    End Sub

    '| - PORTRAIT SETTER METHODS - |
    Sub changeHC(ByVal c As Color)
        portrait.haircolor = c

        picPort.BackgroundImage = portrait.draw
    End Sub
    Sub changeSC(ByVal c As Color)
        portrait.skincolor = c

        picPort.BackgroundImage = portrait.draw()
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
    Sub setDefaultProfilePic()
        Dim hc = portrait.haircolor
        Dim sc = portrait.skincolor
        portrait = New Portrait(portrait.sexBool, Nothing)
        portrait.haircolor = hc
        portrait.skincolor = sc
    End Sub

    '| - PLAYER SETTER METHODS - |
    Private Sub setPlayerPortrait(ByRef p As Player)
        p.prt.iArr = portrait.iArr
        p.prt.iArrInd = portrait.iArrInd
        p.prt.haircolor = portrait.haircolor
        p.prt.skincolor = portrait.skincolor

        If portrait.sexBool Then
            p.sex = "Female"
            p.breastSize = 1
            p.dickSize = -1
            p.buttSize = 1
        Else
            p.sex = "Male"
            p.breastSize = -1
            p.dickSize = 1
            p.buttSize = -1
        End If
    End Sub

    '| - PLAYER CHARACTER PRESETS - |
    Sub getPresets()
        Dim dir = New IO.DirectoryInfo("Presets")
        Try
            Dim presets = dir.GetFiles("*.pset", IO.SearchOption.AllDirectories).ToList
            For Each pset In presets.OrderBy(Function(i) i.Name)
                cboxPresets.Items.Add(pset.Name)
            Next
        Catch e As Exception
        End Try
    End Sub

    '| - MISC. FUNCTIONS - |
    Private Sub setAvailibleClasses(ByVal cbox As ComboBox)
        'start by clearing any classes that are already listed in cbox
        cbox.Items.Clear()

        'add the standard classes
        cbox.Items.Add("Warrior")
        cbox.Items.Add("Mage")
        cbox.Items.Add("Rogue")
        cbox.Items.Add("Cleric")
        cbox.Items.Add("Magical Girl")
        cbox.Items.Add("Valkyrie")

        'add the classes unlocked by special events
        If DDDateTime.isHallow Then cbox.Items.Add("Witch")
        If Game.compOOT Then cbox.Items.Add("Time Cop")

        'select a class at random
        cbox.Text = cbox.Items(Int(Rnd() * cbox.Items.Count))
    End Sub
    Private Function sanitizeName(ByRef name As String) As String
        name = name.Replace("*", "")
        name = name.Replace("~", "")
        name = name.Replace("@", "")
        name = name.Replace(":", "")

        Return name
    End Function
End Class