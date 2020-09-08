Imports System.Text.RegularExpressions

Public Class ShopV2
    Dim sk As ShopNPC = Game.currNPC
    Dim p As Player = Game.player1
    Dim skInventory, pInventory As List(Of String)
    Dim skInvInds, pInvInds As List(Of Integer)

    Private Sub Done_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Me.Close()
    End Sub
    Private Sub Shop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        skInventory = New List(Of String)
        pInventory = New List(Of String)

        skInvInds = New List(Of Integer)
        pInvInds = New List(Of Integer)

        txtdesc.Text = ""

        RefreshScreen()
        lblShopkeeper.Text = sk.name

        DDUtils.resizeForm(Me)
    End Sub

    'refresh
    Private Sub RefreshScreen()
        '|Player Inventory Refresh|
        lblYG.Text = "Gold: " & p.gold
        pInventory.Clear()
        boxInventory.Items.Clear()
        pInvInds.Clear()

        For i = 0 To p.inv.upperBound
            Dim p_inv_i = p.inv.item(i)
            If p.inv.getCountAt(i) > 0 Then
                If p_inv_i.getAName().Equals(p.equippedArmor.getAName()) Or p.inv.item(i).getAName().Equals(p.equippedWeapon.getAName()) Or p_inv_i.getAName().Equals(p.equippedAcce.getAName()) Then
                    If p_inv_i.count > 1 Then addItemToPInv(p_inv_i, True)
                Else
                    addItemToPInv(p_inv_i)
                End If
            End If
        Next

        '|Shop Inventory Refresh|
        lblSKG.Text = "Gold: " & sk.gold
        skInventory.Clear()
        boxShop.Items.Clear()
        skInvInds.Clear()

        Dim skInv = sk.getShopInv
        For i = 0 To skInv.upperBound
            If sk.inv.getCountAt(i) > 0 And i <> 43 Then
                Dim sk_inv_i As Item = skInv.item(i)
                addItemToSkInv(sk_inv_i)
            End If
        Next

        '|Apply Filter|
        inventoryFilterUpdate()
        shopFilterUpdate()
    End Sub
    Private Sub addItemToPInv(ByRef i As Item, Optional ByVal reduced As Boolean = False)
        If Not reduced Then boxInventory.Items.Add(lineup(i.getName(), Int(i.value / 2), i.count)) Else boxInventory.Items.Add(lineup(i.getName(), Int(i.value / 2), i.count - 1))
        pInventory.Add(i.getAName())
        pInvInds.Add(i.id)
    End Sub
    Private Sub addItemToSkInv(ByRef i As Item)
        boxShop.Items.Add(lineup(i.getAName(), (i.value)))
        skInventory.Add(i.getAName())
        skInvInds.Add(i.id)

    End Sub

    'sell
    Private Sub btnSell_Click(sender As Object, e As EventArgs) Handles btnSell.Click
        Dim items = boxInventory.SelectedItems
        Dim cost As Integer = 0
        Dim indexes As List(Of Integer) = New List(Of Integer)

        'Determine the items that are being sold and the total count
        For i As Integer = 0 To items.Count - 1
            Dim item As Item = p.inv.item(pInvInds(i))

            If item.count >= number.Value Then
                cost += (item.value) / 2 * number.Value
            Else
                cost += item.value / 2 * item.count
            End If
        Next

        'Make the sale
        If cost <= sk.gold Then
            For i As Integer = 0 To indexes.Count - 1
                Dim item As Item = p.inv.item(pInvInds(i))
                If item.getName().Contains(p.equippedArmor.getName()) Or item.getName().Contains(p.equippedWeapon.getName()) Or item.getName().Contains(p.equippedAcce.getName()) Then
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

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub
    'buy
    Private Sub btnBuy_Click(sender As Object, e As EventArgs) Handles btnBuy.Click
        Dim cost As Integer = 0
        Dim itemToBuy As Item = sk.getShopInv.item(skInvInds(boxShop.SelectedIndex))
       
        If number.Value > itemToBuy.saleLim Then number.Value = itemToBuy.saleLim
        cost = (itemToBuy.value) * number.Value

        If cost <= p.gold Then
            p.inv.add(itemToBuy.id, CInt(number.Value))
            If Not itemToBuy.onBuy Is Nothing Then itemToBuy.onBuy()

            p.gold -= cost
            sk.gold += cost
            txtdesc.Text = "Purchase successful. Spent " & cost & " gold."
        Else
            txtdesc.Text = "Insufficient gold. Need " & cost - p.gold & " more."
        End If

        RefreshScreen()

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub

    Private Sub boxInventory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles boxInventory.SelectedIndexChanged
        Dim ind As Integer = 0
        If boxInventory.SelectedItem Is Nothing Then Exit Sub
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
        If boxShop.SelectedItem Is Nothing Then Exit Sub
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
                        boxInventory.Items.Add(lineup(p.inv.item(ind).getName(), Int(p.inv.item(ind).value / 2), p.inv.item(ind).count - 1))
                    End If
                Else
                    boxInventory.Items.Add(lineup(p.inv.item(ind).getName(), Int(p.inv.item(ind).value / 2), p.inv.item(ind).count))
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

        If s.Length > 16 Then s = s.Substring(0, 16) & "."
        If s.Length < 16 Then
            For x = s.Length To 16
                If s.Last = "​" Then s = s & " "
                s = s & " "
            Next
        End If
        If s.Length = 16 Then s = s.Substring(0, 15) & "." & c & " "
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

    Private Sub txtDesc_TextChanged(sender As Object, e As EventArgs) Handles txtDesc.TextChanged

    End Sub
End Class