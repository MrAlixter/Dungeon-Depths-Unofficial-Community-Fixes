Public Class ClothingTester
    Dim p As Player
    'armor
    Public aList As Dictionary(Of String, Armor) = New Dictionary(Of String, Armor)

    Private Sub ClothingTester_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        p = Game.player1
        DDUtils.resizeForm(Me, 320)

        Dim a As Tuple(Of String(), Armor())
        a = p.inv.getArmors

        aList.Clear()

        For i = 0 To UBound(a.Item1)
            aList.Add(a.Item1(i), a.Item2(i))
        Next

        For Each v In aList.Values
            If v.usize1 Is Nothing Then
                cmbArmor.Items.Add(v.getName())
            Else
                cmbArmor.Items.Insert(0, v.getName())
            End If

        Next
        cmbArmor.SelectedText = p.equippedArmor.getAName

        drawImg()
    End Sub

    Sub drawImg()
        Dim pImg = p.prt.oneLayerImgCheck(p.pForm.name, p.pClass.name)
        If p.prt.oneLayerImgCheck(p.pForm.name, p.pClass.name) Is Nothing Then
            p.prt.setIArr()
            pImg = Portrait.CreateFullBodyBMP(p.prt.iArr)
        End If

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
        If p.inv.item(cmbArmor.SelectedItem).count < 1 Then p.inv.add(cmbArmor.SelectedItem, 1)
        Equipment.clothesChange(cmbArmor.SelectedItem)

        p.prt.portraitUDate()
        drawImg()
    End Sub
End Class