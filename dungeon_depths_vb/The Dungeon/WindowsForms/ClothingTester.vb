Public Class ClothingTester
    Dim p As Player

    Private Sub ClothingTester_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        p.drawPort()
    End Sub

    Private Sub ClothingTester_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim startTime As Double = DDDateTime.getTimeNow()
        p = Game.player1

        DDUtils.resizeForm(Me)
        Me.CenterToParent()

        cmbArmor.Items.Clear()
        cmbArmor.Items.AddRange(p.inv.getArmors.Item1())
        cmbArmor.SelectedText = p.equippedArmor.getAName

        drawImg()
    End Sub

    Sub drawImg()
        Dim pImg = p.prt.oneLayerImgCheck(p.formName, p.className)

        If p.prt.oneLayerImgCheck(p.formName, p.className) Is Nothing Then
            pImg = p.prt.drawFull
        End If

        lblBS.Text = p.breastSize
        lblAS.Text = p.buttSize

        picDescPort.BackgroundImage = pImg
    End Sub

    Private Sub btnBSizeMinus_Click(sender As Object, e As EventArgs) Handles btnBSizeMinus.Click
        p.bs()
        drawImg()
    End Sub
    Private Sub btnBSizePlus_Click(sender As Object, e As EventArgs) Handles btnBSizePlus.Click
        p.be()
        drawImg()
    End Sub

    Private Sub btnUSizeMinus_Click(sender As Object, e As EventArgs) Handles btnUSizeMinus.Click
        p.us()
        drawImg()
    End Sub
    Private Sub btnUSizePlus_Click(sender As Object, e As EventArgs) Handles btnUSizePlus.Click
        p.ue()
        drawImg()
    End Sub

    Private Sub cmbArmor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbArmor.SelectedValueChanged
        If Not cmbArmor.SelectedItem = "Naked" AndAlso p.inv.item(cmbArmor.SelectedItem).count < 1 Then p.inv.add(cmbArmor.SelectedItem, 1)
        EquipmentDialogBackend.armorChange(p, cmbArmor.SelectedItem)

        p.prt.portraitUDate()
        drawImg()
    End Sub
End Class