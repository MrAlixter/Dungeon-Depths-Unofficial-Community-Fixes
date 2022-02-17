Imports System.Text.RegularExpressions

Friend Enum inv_type
    player
    shopkeeper
End Enum

Public Class ShopV3
    Private Const P_ITEMNAME_LENGTH As Integer = 23
    Private Const S_ITEMNAME_LENGTH As Integer = 28
    Private Const P_PRICE_LENGTH As Integer = 7
    Private Const S_PRICE_LENGTH As Integer = 8

    Dim sk As ShopNPC = Game.active_shop_npc
    Dim skInventory As List(Of String) = Nothing

    Dim p As Player = Game.player1
    Dim pInventory As List(Of String) = Nothing

    Private Sub RefreshScreen()
        lblYG.Text = "Gold: " & p.gold
        lblSKG.Text = "Gold: " & sk.gold
        pInventory.Clear()
        boxInventory.Items.Clear()
        skInventory.Clear()
        boxShop.Items.Clear()

        'update the player's inventory
        For Each itm In getFormattedInventory(p.inv, inv_type.player)
            If Not itm.EndsWith(":") And Not itm.Equals("") Then
                boxInventory.Items.Add(lineup(p.inv.item(itm).getAName(), (p.inv.item(itm).value / 2), p.inv.item(itm).count))
                pInventory.Add(itm)
            Else
                boxInventory.Items.Add(itm)
            End If
        Next

        'update the shopkeeper's inventory
        For Each itm In getFormattedInventory(sk.inv, inv_type.shopkeeper)
            If Not itm.EndsWith(":") And Not itm.Equals("") Then
                boxShop.Items.Add(lineupSeller(sk.inv.item(itm).getAName(), (sk.inv.item(itm).value)))
                skInventory.Add(itm)
            Else
                boxShop.Items.Add(itm)
            End If
        Next
    End Sub
    Private Function getFormattedInventory(ByVal inv As Inventory, ByVal type As inv_type) As List(Of String)
        Dim formattedInventory = New List(Of String)()

        '| -- Useables -- |
        formattedInventory.Add("-USEABLES:")
        Array.Sort(inv.getUseable)
        For Each itm In inv.getUseable
            If itm.getCount > 0 Then formattedInventory.Add(If(type = inv_type.shopkeeper, itm.getAName(), itm.getName()))
        Next
        If formattedInventory(formattedInventory.Count - 1).Equals("-USEABLES:") Then formattedInventory.Remove("-USEABLES:") Else formattedInventory.Add("")

        '| -- Potions -- |
        formattedInventory.Add("-POTIONS:")
        Array.Sort(inv.getPotions)
        For Each itm In inv.getPotions
            If itm.getCount > 0 Then formattedInventory.Add(If(type = inv_type.shopkeeper, itm.getAName(), itm.getName()))
        Next
        If formattedInventory(formattedInventory.Count - 1).Equals("-POTIONS:") Then formattedInventory.Remove("-POTIONS:") Else formattedInventory.Add("")

        '| -- Food -- |
        formattedInventory.Add("-FOOD:")
        Array.Sort(inv.getFood)
        For Each itm In inv.getFood
            If itm.getCount > 0 Then formattedInventory.Add(If(type = inv_type.shopkeeper, itm.getAName(), itm.getName()))
        Next
        If formattedInventory(formattedInventory.Count - 1).Equals("-FOOD:") Then formattedInventory.Remove("-FOOD:") Else formattedInventory.Add("")

        '| -- Armor -- |
        formattedInventory.Add("-ARMOR:")
        Array.Sort(inv.getArmors.Item2)
        For Each itm In inv.getArmors.Item2
            If itm.getCount > 0 Then formattedInventory.Add(If(type = inv_type.shopkeeper, itm.getAName(), itm.getName()))
        Next
        If formattedInventory(formattedInventory.Count - 1).Equals("-ARMOR:") Then formattedInventory.Remove("-ARMOR:") Else formattedInventory.Add("")

        '| -- Weapons -- |
        formattedInventory.Add("-WEAPONS:")
        Array.Sort(inv.getWeapons.Item2)
        For Each itm In inv.getWeapons.Item2
            If itm.getCount > 0 Then formattedInventory.Add(If(type = inv_type.shopkeeper, itm.getAName(), itm.getName()))
        Next
        If formattedInventory(formattedInventory.Count - 1).Equals("-WEAPONS:") Then formattedInventory.Remove("-WEAPONS:") Else formattedInventory.Add("")

        '| -- Accessories -- |
        formattedInventory.Add("-ACCESSORIES:")
        Array.Sort(inv.getAccesories.Item2)
        For Each itm In inv.getAccesories.Item2
            If itm.getCount > 0 Then formattedInventory.Add(If(type = inv_type.shopkeeper, itm.getAName(), itm.getName()))
        Next
        If formattedInventory(formattedInventory.Count - 1).Equals("-ACCESSORIES:") Then formattedInventory.Remove("-ACCESSORIES:") Else formattedInventory.Add("")

        '| -- Glasses -- |
        formattedInventory.Add("-GLASSES:")
        Array.Sort(inv.getGlasses.Item2)
        For Each itm In inv.getGlasses.Item2
            If itm.getCount > 0 Then formattedInventory.Add(If(type = inv_type.shopkeeper, itm.getAName(), itm.getName()))
        Next
        If formattedInventory(formattedInventory.Count - 1).Equals("-GLASSES:") Then formattedInventory.Remove("-GLASSES:") Else formattedInventory.Add("")

        '| -- Services -- |
        formattedInventory.Add("-SERVICES:")
        Array.Sort(inv.getServices)
        For Each itm In inv.getServices
            If itm.getCount > 0 Then formattedInventory.Add(If(type = inv_type.shopkeeper, itm.getAName(), itm.getName()))
        Next
        If formattedInventory(formattedInventory.Count - 1).Equals("-SERVICES:") Then formattedInventory.Remove("-SERVICES:") Else formattedInventory.Add("")

        '| -- Misc -- |
        formattedInventory.Add("-MISC:")
        Array.Sort(inv.getMisc)
        For Each itm In inv.getMisc
            If itm.getCount > 0 And itm.getId <> 43 Then formattedInventory.Add(If(type = inv_type.shopkeeper, itm.getAName(), itm.getName()))
        Next
        If formattedInventory(formattedInventory.Count - 1).Equals("-MISC:") Then formattedInventory.Remove("-MISC:") Else formattedInventory.Add("")

        Return formattedInventory
    End Function

    '| - EVENT HANDLERS - |
    Private Sub Shop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        skInventory = New List(Of String)
        pInventory = New List(Of String)

        txtDesc.Text = ""

        DDUtils.resizeForm(Me)

        RefreshScreen()
        lblPlayer.Text = p.getName
        lblShopkeeper.Text = sk.name
    End Sub
    Private Sub inventory_SelectedIndexChange(sender As Object, e As EventArgs) Handles boxInventory.SelectedIndexChanged, boxShop.SelectedIndexChanged
        If sender.SelectedItem Is Nothing Or sender.SelectedItem.endsWith(":") Or sender.SelectedItem.Equals("") Then Exit Sub

        Dim ind As Integer
        Dim name As String = Replace(sender.SelectedItem.ToString.Substring(0, P_ITEMNAME_LENGTH).TrimEnd, " ", "_")

        If p.inv.item(name) Is Nothing Then
            'if the item name is abrevieated, find the full name
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
    End Sub
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
                If p.inv.item(i).getAName().Contains(name) Then
                    txtDesc.Text = p.inv.item(i).getDescription()
                    Exit For
                End If
            Next
        End If

    End Sub

    '| - TEXT FORMATTING - |
    Function lineup(ByVal itemName As String, ByVal price As Integer, ByVal count As Integer)
        'Text Format - IIIIIIIIIIIIIIIIIIIIIII_PPPPPPg__xCCCC
        ' I - Item Name
        ' P - Price
        ' C - Count

        'item name formatting
        If itemName.Length > P_ITEMNAME_LENGTH Then s = itemName.Substring(0, P_ITEMNAME_LENGTH - 1) & "."
        Do While itemName.Replace("​", "").Length < P_ITEMNAME_LENGTH
            itemName += " "
        Loop

        'price formatting
        Dim formattedPrice = price.ToString + "g"
        Do While formattedPrice.Length < P_PRICE_LENGTH
            formattedPrice += " "
        Loop

        Return Replace(itemName & " " & formattedPrice & " x" & count, "_", " ")
    End Function
    Function lineupSeller(ByVal itemName As String, ByVal price As Integer)
        'Text Format - IIIIIIIIIIIIIIIIIIIIIIIIII_PPPPPPPPg
        ' I - Item Name
        ' P - Price

        'item name formatting
        If itemName.Length > S_ITEMNAME_LENGTH Then s = itemName.Substring(0, S_ITEMNAME_LENGTH - 1) & "."
        Do While itemName.Replace("​", "").Length < S_ITEMNAME_LENGTH
            itemName += " "
        Loop

        'price formatting
        Dim formattedPrice = price.ToString + "g"
        Do While formattedPrice.Length < S_PRICE_LENGTH
            formattedPrice += " "
        Loop

        Return Replace(itemName & " " & formattedPrice, "_", " ")
    End Function

    '| - SELL - |
    Private Sub btnSell_Click(sender As Object, e As EventArgs) Handles btnSell.Click
        Dim cost As Integer = 0
        Dim item_indexes_to_sell As List(Of Integer) = New List(Of Integer)
        Dim items = boxInventory.SelectedItems

        For Each itm In items
            If itm.ToString.EndsWith(":") Or itm.ToString.Equals("") Then Continue For

            Dim item_index As Integer
            Dim name As String = Replace(itm.ToString.Substring(0, P_ITEMNAME_LENGTH).TrimEnd, " ", "_")

            If p.inv.item(name) Is Nothing Then
                'if the item name is abrevieated, find the full name
                For j As Integer = 0 To p.inv.upperBound
                    If p.inv.item(j).getName().Contains(name) Then
                        item_index = j
                        item_indexes_to_sell.Add(item_index)
                        Exit For
                    End If
                Next
            Else
                item_index = p.inv.item(name).getId
                item_indexes_to_sell.Add(item_index)
            End If

            Dim item As Item = p.inv.item(item_index)
            If item.count >= number.Value Then
                cost += (item.value) / 2 * number.Value
            Else
                cost += p.inv.item(item_index).value / 2 * item.count
            End If
        Next


        If cost <= sk.gold Then
            'sell each of the items to the shopkeeper if they can afford them
            For Each index In item_indexes_to_sell
                Dim item As Item = p.inv.item(index)

                If item.getName().Contains(p.equippedArmor.getName()) Or item.getName().Contains(p.equippedWeapon.getName()) Or item.getName().Contains(p.equippedAcce.getName()) Then
                    If item.count - number.Value >= 1 Then
                        item.count -= number.Value
                    Else
                        item.count = 1
                        cost -= item.value / 2
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
            txtDesc.Text = "Sale completed. Acquired " & cost & " gold."
        Else
            txtDesc.Text = "Shopkeeper does not have enough gold. They need " & cost - sk.gold & " more."
        End If

        RefreshScreen()

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub

    '| - BUY - |
    Private Sub btnBuy_Click(sender As Object, e As EventArgs) Handles btnBuy.Click
        Dim cost As Integer = 0
        Dim item_indexes_to_buy As List(Of Integer) = New List(Of Integer)
        Dim items = boxShop.SelectedItems

        For Each itm In items
            If itm.ToString.EndsWith(":") Or itm.ToString.Equals("") Then Continue For

            Dim item_index As Integer
            Dim name As String = Replace(itm.ToString.Substring(0, S_ITEMNAME_LENGTH).TrimEnd, " ", "_")

            If p.inv.item(name) Is Nothing Then
                'if the item name is abrevieated, find the full name
                For j As Integer = 0 To p.inv.upperBound
                    If p.inv.item(j).getAName().Contains(name) Then
                        item_index = j
                        item_indexes_to_buy.Add(item_index)
                        Exit For
                    End If
                Next
            Else
                item_index = p.inv.item(name).getId
                item_indexes_to_buy.Add(item_index)
            End If

            'add the value of the shopkeeper's item to the total
            Dim item As Item = sk.getShopInv.item(item_index)
            If number.Value > item.saleLim Then number.Value = item.saleLim
            cost += (item.value) * number.Value
        Next

        If cost <= p.gold Then
            'sell each of the items to the player if they can afford them
            For Each index In item_indexes_to_buy
                Dim item = p.inv.item(index)
                p.inv.add(index, CInt(number.Value))
                If Not item.onBuy Is Nothing Then item.onBuy()
            Next

            p.gold -= cost
            sk.gold += cost
            txtDesc.Text = "Purchase successful. Spent " & cost & " gold."
        Else
            txtDesc.Text = "Insufficient gold. Need " & cost - p.gold & " more."
        End If

        RefreshScreen()

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
    End Sub

    '| - INVENTORY FILTER - |
    Private Sub boxInventoryFilter_TextChanged(sender As Object, e As EventArgs) Handles boxInventoryFilter.TextChanged
        inventoryFilterUpdate()
    End Sub
    Private Sub boxItemsFilter_TextChanged(sender As Object, e As EventArgs) Handles boxShopFilter.TextChanged
        shopFilterUpdate()
    End Sub
    Private Sub inventoryFilterUpdate()
        If boxInventoryFilter.Text.Trim = "" Then RefreshScreen() : Exit Sub

        boxInventory.Items.Clear()

        For i As Integer = 0 To pInventory.Count - 1
            If pInventory(i).IndexOf(boxInventoryFilter.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                Dim ind As Integer
                For ind = 0 To p.inv.upperBound
                    If p.inv.item(ind).getAName() = pInventory(i) Then
                        Exit For
                    End If
                Next
                If pInventory(i).Equals(p.equippedArmor.getAName()) Or pInventory(i).Equals(p.equippedWeapon.getAName()) Then
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
        If boxShopFilter.Text.Trim = "" Then RefreshScreen() : Exit Sub

        boxShop.Items.Clear()

        Dim skInv = sk.getShopInv

        For i As Integer = 0 To skInventory.Count - 1
            Dim ind As Integer
            For ind = 0 To skInv.upperBound
                If skInv.item(ind).getAName() = skInventory(i) Then
                    Exit For
                End If
            Next
            If skInventory(i).IndexOf(boxShopFilter.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                boxShop.Items.Add(lineupSeller(skInv.item(ind).getAName(), skInv.item(ind).value))
            End If
        Next
    End Sub

    '| - LISTBOX DISPLAY - |
    Private Sub Inventory_DrawItem(sender As Object, e As DrawItemEventArgs) Handles boxInventory.DrawItem, boxShop.DrawItem
        e.DrawBackground()
        Dim textBrush As Brush = New SolidBrush(sender.ForeColor)
        Dim drawFont As Font = e.Font

        If e.Index < 0 Then Exit Sub

        Dim text = DirectCast(sender, ListBox).Items(e.Index).ToString()

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(New SolidBrush(sender.BackColor), e.Bounds)
            If Not text.StartsWith("-") Then textBrush = Brushes.Gold
        End If


        If text.StartsWith("-") Then
            drawFont = DDUtils.scaledFont(drawFont, drawFont.Size, True)
        ElseIf Not (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            Dim i = 80
            textBrush = New SolidBrush(Color.FromArgb(sender.ForeColor.A,
                                                      sender.ForeColor.R - i,
                                                      sender.ForeColor.B - i,
                                                      sender.ForeColor.G - i))
        End If

        e.Graphics.DrawString(text,
                              drawFont,
                              textBrush,
                              e.Bounds,
                              StringFormat.GenericDefault)
    End Sub
    Private Sub Inventory_MeasureItem(sender As Object, e As MeasureItemEventArgs) Handles boxInventory.MeasureItem, boxShop.MeasureItem
        Dim text = DirectCast(sender, ListBox).Items(e.Index).ToString()

        If Not (text.Equals("")) Then
            e.ItemHeight = TextRenderer.MeasureText(text, DirectCast(sender, ListBox).Font).Height
        Else
            e.ItemHeight *= 0.33
        End If
    End Sub
End Class