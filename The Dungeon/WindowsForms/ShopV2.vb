Imports System.Text.RegularExpressions

Public Class ShopV2
    Dim sk As ShopNPC = Game.currNPC
    Dim p As Player = Game.player
    Dim skInventory As List(Of String) = Nothing
    Dim pInventory As List(Of String) = Nothing

    Private Sub Done_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Me.Close()
    End Sub
    Private Sub Shop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        skInventory = New List(Of String)
        pInventory = New List(Of String)

        txtdesc.Text = ""

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
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * Me.Size.Width / (288 * 1.75)))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Font = newFont
            Me.Controls(i).Width += CDbl(Me.Controls(i).Width * RW)
            Me.Controls(i).Height += CDbl(Me.Controls(i).Height * RH)
            Me.Controls(i).Left += CDbl(Me.Controls(i).Left * RW)
            Me.Controls(i).Top += CDbl(Me.Controls(i).Top * RH)
        Next

        RefreshScreen()

        lblShopkeeper.Text = sk.name
        lblShopkeeper.Left = boxShopFilter.Left - (6 * RW) - lblShopkeeper.Width - 3 'To keep it right aligned with the shopkeeper filter inventory box
    End Sub
    Private Sub RefreshScreen()
        lblYG.Text = "Gold: " & p.gold
        lblSKG.Text = "Gold: " & sk.gold
        pInventory.Clear()
        boxInventory.Items.Clear()
        skInventory.Clear()
        boxShop.Items.Clear()
        For i = 0 To p.inv.upperBound
            Dim p_inv_i As Item = p.inv.item(i)
            If p.inv.getCountAt(i) > 0 Then
                If p_inv_i.getaname().Equals(p.equippedArmor.getaname()) Or p.inv.item(i).getaname().Equals(p.equippedWeapon.getaname()) Or p_inv_i.getaname().Equals(p.equippedAcce.getaname()) Then
                    If p_inv_i.count > 1 Then
                        boxInventory.Items.Add(lineup(p_inv_i.getaname(), Int(p_inv_i.value / 2), p_inv_i.count - 1))
                        pInventory.Add(p_inv_i.getaname())
                    End If
                Else
                    boxInventory.Items.Add(lineup(p_inv_i.getaname(), Int(p_inv_i.value / 2), p_inv_i.count))
                    pInventory.Add(p_inv_i.getaname())
                End If
            End If
        Next
        Dim skInv = sk.getShopInv
        For i = 0 To skInv.upperBound
            If sk.inv.getCountAt(i) > 0 And i <> 43 Then
                Dim sk_inv_i As Item = skInv.item(i)
                boxShop.Items.Add(lineup(sk_inv_i.getAName(), (sk_inv_i.value)))
                skInventory.Add(sk_inv_i.getAName())
            End If
        Next

        inventoryFilterUpdate()
        shopFilterUpdate()
    End Sub

    'sell
    Private Sub btnSell_Click(sender As Object, e As EventArgs) Handles btnSell.Click
        Dim items = boxInventory.SelectedItems
        Dim cost As Integer = 0
        Dim indexes As List(Of Integer) = New List(Of Integer)
        For i As Integer = 0 To items.Count - 1
            Dim name As String = items(i).Split({" "c, "("c, "."c})(0)
            'Dim name As String = Regex.Split(items(i), ChrW(8203))(0).Trim() 'Read for the zero-width whitespace character
            If name.Last = "." Then name = name.Substring(0, name.Length - 1)
            Dim ind As Integer

            If p.inv.item(name) Is Nothing Then
                For j As Integer = 0 To p.inv.upperBound
                    If p.inv.item(j).getaname().Contains(name) Then
                        ind = j
                        indexes.Add(ind)
                        Exit For
                    End If
                Next
            Else
                ind = p.inv.item(name).getId
                indexes.Add(ind)
            End If

            Dim item As Item = p.inv.item(ind)
            If item.count >= number.Value Then
                cost += (item.value) / 2 * number.Value
            Else
                cost += p.inv.item(ind).value / 2 * item.count
            End If
        Next

        If cost <= sk.gold Then
            For i As Integer = 0 To indexes.Count - 1
                Dim item As Item = p.inv.item(indexes(i))
                If item.getaname().Contains(p.equippedArmor.getaname()) Or item.getaname().Contains(p.equippedWeapon.getaname()) Or item.getaname().Contains(p.equippedAcce.getaname()) Then
                    If item.count - number.Value >= 1 Then
                        item.count -= number.Value
                    Else
                        item.count = 1
                    End If
                Else
                    If item.count >= number.Value Then
                        item.count -= number.Value

                    Else
                        item.count = 0
                    End If
                End If
                If Not item.onSell Is Nothing Then item.onSell()
            Next

            p.gold += cost
            sk.gold -= cost
            txtDesc.Text = "Sale successful. Acquired " & cost & " gold."
        Else
            txtdesc.Text = "Shopkeeper does not have enough gold. They need " & cost - sk.gold & " more."
        End If

        RefreshScreen()

        Game.player.inv.invNeedsUDate = True
        Game.player.UIupdate()
    End Sub
    'buy
    Private Sub btnBuy_Click(sender As Object, e As EventArgs) Handles btnBuy.Click
        Dim items = boxShop.SelectedItems
        Dim cost As Integer = 0
        Dim indexes As List(Of Integer) = New List(Of Integer)
        For i As Integer = 0 To items.Count - 1
            Dim name As String = items(i).Split({" "c, "("c, "."c})(0)
            'Dim name As String = Regex.Split(items(i), ChrW(8203))(0).Trim() 'Read for the zero-width whitespace character

            Dim ind As Integer
            If p.inv.item(name) Is Nothing Then
                For j As Integer = 0 To p.inv.upperBound
                    If p.inv.item(j).getaname().Contains(name) Then
                        ind = j
                        indexes.Add(ind)
                        Exit For
                    End If
                Next
            Else
                ind = p.inv.item(name).getId
                indexes.Add(ind)
            End If

            Dim item As Item = sk.inv.item(ind)
            If number.Value > item.saleLim Then number.Value = item.saleLim
            cost += (item.value) * number.Value
        Next

        If cost <= p.gold Then
            For i As Integer = 0 To indexes.Count - 1
                Dim item = p.inv.item(indexes(i))
                p.inv.add(indexes(i), CInt(number.Value))
                If Not item.onBuy Is Nothing Then item.onBuy()
            Next
            p.gold -= cost
            sk.gold += cost
            txtdesc.Text = "Purchase successful. Spent " & cost & " gold."
        Else
            txtdesc.Text = "Insufficient gold. Need " & cost - p.gold & " more."
        End If

        RefreshScreen()

        Game.player.inv.invNeedsUDate = True
        Game.player.UIupdate()
    End Sub

    Private Sub boxInventory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles boxInventory.SelectedIndexChanged
        Dim ind As Integer
        Dim name As String = boxInventory.SelectedItem.ToString.Split({" "c, "("c, "."c})(0)
        If p.inv.item(name) Is Nothing Then
            For j As Integer = 0 To p.inv.upperBound
                If p.inv.item(j).getAName().Contains(name) Then
                    ind = j
                    Exit For
                End If
            Next
        Else
            ind = p.inv.item(name).getId
        End If

        Dim item As Item = p.inv.item(ind)

        txtDesc.Text = item.getDesc
        boxShop.SelectedIndex = -1
    End Sub
    Private Sub boxShop_SelectedIndexChange(sender As Object, e As EventArgs) Handles boxShop.SelectedIndexChanged
        Dim ind As Integer
        Dim name As String = boxShop.SelectedItem.ToString.Split({" "c, "("c, "."c})(0)
        If p.inv.item(name) Is Nothing Then
            For j As Integer = 0 To p.inv.upperBound
                If p.inv.item(j).getAName().Contains(name) Then
                    ind = j
                    Exit For
                End If
            Next
        Else
            ind = p.inv.item(name).getId
        End If

        Dim item As Item = p.inv.item(ind)

        txtDesc.Text = item.getDesc
        boxInventory.SelectedIndex = -1
    End Sub

    Private Sub boxInventoryFilter_TextChanged(sender As Object, e As EventArgs) Handles boxInventoryFilter.TextChanged
        inventoryFilterUpdate()
    End Sub
    Private Sub boxItemsFilter_TextChanged(sender As Object, e As EventArgs) Handles boxShopFilter.TextChanged
        shopFilterUpdate()
    End Sub
    Private Sub inventoryFilterUpdate()
        boxInventory.Items.Clear()
        For i As Integer = 0 To pInventory.Count - 1
            If pInventory(i).IndexOf(boxInventoryFilter.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                Dim ind As Integer
                For ind = 0 To p.inv.upperBound
                    If p.inv.item(ind).getaname() = pInventory(i) Then
                        Exit For
                    End If
                Next
                If pInventory(i).Equals(p.equippedArmor.getaname()) Or pInventory(i).Equals(p.equippedWeapon.getaname()) Then
                    If p.inv.item(ind).count > 1 Then
                        boxInventory.Items.Add(lineup(p.inv.item(ind).getaname(), Int(p.inv.item(ind).value / 2), p.inv.item(ind).count - 1))
                    End If
                Else
                    boxInventory.Items.Add(lineup(p.inv.item(ind).getaname(), Int(p.inv.item(ind).value / 2), p.inv.item(ind).count))
                End If
            End If
        Next
    End Sub
    Private Sub shopFilterUpdate()
        boxShop.Items.Clear()

        Dim skInv = sk.getShopInv

        For i As Integer = 0 To skInventory.Count - 1
            Dim ind As Integer
            For ind = 0 To skInv.upperBound
                If skInv.item(ind).getaname() = skInventory(i) Then
                    Exit For
                End If
            Next
            If skInventory(i).IndexOf(boxShopFilter.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                boxShop.Items.Add(lineup(skInv.item(ind).getaname(), skInv.item(ind).value))
            End If
        Next
    End Sub

    Function lineup(ByVal s As String, ByVal i As Integer, Optional ByVal j As Integer = -1)
        Dim c As Char = ChrW(8203)

        If s.Length > 17 Then s = s.Substring(0, 16) & "."
        If s.Length < 17 Then
            For x = s.Length To 17
                If s.Last = "​" Then s = s & " "
                s = s & " "
            Next
        End If
        If s.Length = 17 Then s = s & c & " "
        If j = -1 Then
            Return s & c & " " & i & "g"
        Else
            Return s & c & " " & i & "g" & "  x" & j
        End If
    End Function
    Private Sub btnInspect_Click(sender As Object, e As EventArgs) Handles btnInspect.Click
        Dim name As String = Nothing

        If boxInventory.SelectedItems.Count > 0 Then
            name = Regex.Split(boxInventory.SelectedItems(0), ChrW(8203))(0).Trim()
        ElseIf boxShop.SelectedItems.Count > 0 Then
            name = Regex.Split(boxShop.SelectedItems(0), ChrW(8203))(0).Trim()
        End If

        If name IsNot Nothing Then
            If name.Last = "." Then
                name = name.Substring(0, name.Length - 1)
            End If

            For i As Integer = 0 To p.inv.upperBound
                If p.inv.item(i).getaname().Contains(name) Then
                    txtdesc.Text = p.inv.item(i).getDescription()
                    Exit For
                End If
            Next
        End If

    End Sub
End Class