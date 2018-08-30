Imports System.Text.RegularExpressions

Public Class ShopV2
    Dim sk As NPC = Game.currNPC
    Dim p As Player = Game.player
    Dim skInventory As List(Of String) = Nothing
    Dim pInventory As List(Of String) = Nothing

    Private Sub Done_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Me.Close()
    End Sub

    Private Sub Shop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        skInventory = New List(Of String)
        pInventory = New List(Of String)

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
        For i = 0 To p.inventory.Count - 1
            If p.inventory(i).count > 0 Then
                If p.inventory(i).getName().Equals(p.equippedArmor.getName()) Or p.inventory(i).getName().Equals(p.equippedWeapon.getName()) Then
                    If p.inventory(i).count > 1 Then
                        boxInventory.Items.Add(lineup(p.inventory(i).getName(), Int(p.inventory(i).value / 2), p.inventory(i).count - 1))
                        pInventory.Add(p.inventory(i).getName())
                    End If
                Else
                    boxInventory.Items.Add(lineup(p.inventory(i).getName(), Int(p.inventory(i).value / 2), p.inventory(i).count))
                    pInventory.Add(p.inventory(i).getName())
                End If
            End If
        Next
        For i = 0 To sk.inventory.Count - 1
            If sk.inventory(i) > 0 Then
                boxShop.Items.Add(lineup(p.inventory(i).getName(), p.inventory(i).value))
                skInventory.Add(p.inventory(i).getName())
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
            'Dim name As String = Regex.Split(items(i), "\s*?[0-9]*?g")(0)
            Dim name As String = Regex.Split(items(i), ChrW(8203))(0).Trim() 'Read for the zero-width whitespace character
            If name.Last = "." Then
                name = name.Substring(0, name.Length - 1)
            End If
            Dim ind As Integer
            For j As Integer = 0 To p.inventory.Count - 1
                If CType(p.inventory(j), Item).getName().Contains(name) Then
                    ind = j
                    indexes.Add(ind)
                    Exit For
                End If
            Next
            Dim item As Item = p.inventory(ind)
            If item.count >= number.Value Then
                cost += (item.value) / 2 * number.Value
            Else
                cost += (CType(p.inventory(ind), Item).value) / 2 * item.count
            End If
        Next

        If cost <= sk.gold Then
            For i As Integer = 0 To indexes.Count - 1
                Dim item As Item = p.inventory(indexes(i))
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
            Next
            p.gold += cost
            sk.gold -= cost
        End If

        RefreshScreen()

        Game.player.invNeedsUDate = True
        Game.player.UIupdate()
    End Sub

    'buy
    Private Sub btnBuy_Click(sender As Object, e As EventArgs) Handles btnBuy.Click
        Dim items = boxShop.SelectedItems
        Dim cost As Integer = 0
        Dim indexes As List(Of Integer) = New List(Of Integer)
        For i As Integer = 0 To items.Count - 1
            'Dim name As String = Regex.Split(items(i), "\s*?[0-9]*?g")(0)
            Dim name As String = Regex.Split(items(i), ChrW(8203))(0).Trim() 'Read for the zero-width whitespace character
            If name.Last = "." Then
                name = name.Substring(0, name.Length - 1)
            End If
            Dim ind As Integer
            For j As Integer = 0 To p.inventory.Count - 1
                If CType(p.inventory(j), Item).getName().Contains(name) Then
                    ind = j
                    indexes.Add(ind)
                    Exit For
                End If
            Next
            Dim item As Item = p.inventory(ind)
            cost += (item.value) * number.Value
        Next

        If cost <= p.gold Then
            For i As Integer = 0 To indexes.Count - 1
                p.inventory(indexes(i)).count += number.Value
            Next
            p.gold -= cost
            sk.gold += cost
        End If

        RefreshScreen()

        Game.player.invNeedsUDate = True
        Game.player.UIupdate()
    End Sub

    Private Sub boxInventory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles boxInventory.SelectedIndexChanged
        boxShop.SelectedIndex = -1
    End Sub

    Private Sub boxShop_SelectedIndexChange(sender As Object, e As EventArgs) Handles boxShop.SelectedIndexChanged
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
                For ind = 0 To p.inventory.Count - 1
                    If CType(p.inventory(ind), Item).getName() = pInventory(i) Then
                        Exit For
                    End If
                Next
                If pInventory(i).Equals(p.equippedArmor.getName()) Or pInventory(i).Equals(p.equippedWeapon.getName()) Then
                    If p.inventory(ind).count > 1 Then
                        boxInventory.Items.Add(lineup(p.inventory(ind).getName(), Int(p.inventory(ind).value / 2), p.inventory(ind).count - 1))
                    End If
                Else
                    boxInventory.Items.Add(lineup(p.inventory(ind).getName(), Int(p.inventory(ind).value / 2), p.inventory(ind).count))
                End If
            End If
        Next
    End Sub

    Private Sub shopFilterUpdate()
        boxShop.Items.Clear()
        For i As Integer = 0 To skInventory.Count - 1
            Dim ind As Integer
            For ind = 0 To p.inventory.Count - 1
                If CType(p.inventory(ind), Item).getName() = skInventory(i) Then
                    Exit For
                End If
            Next
            If skInventory(i).IndexOf(boxShopFilter.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                boxShop.Items.Add(lineup(p.inventory(ind).getName(), p.inventory(ind).value))
            End If
        Next
    End Sub

    Function lineup(ByVal s As String, ByVal i As Integer, Optional ByVal j As Integer = -1)
        Dim c As Char = ChrW(8203)
        If s.Length > 14 Then s = s.Substring(0, 13) & "."
        If s.Length < 14 Then
            For x = s.Length To 14
                s = s & " "
            Next
        End If
        If s.Length = 14 Then s = s & c & " "
        If j = -1 Then
            Return s & c & " " & i & "g"
        Else
            Return s & c & " " & i & "g" & "  x" & j
        End If
    End Function

    Private Sub btnInspect_Click(sender As Object, e As EventArgs) Handles btnInspect.Click
        Dim name As String = Nothing
        If boxInventory.SelectedItems.Count > 0 Then
            name = Regex.Split(boxInventory.SelectedItems(0), "\s*?[0-9]*?g\s*?x[0-9]*?")(0)
        ElseIf boxShop.SelectedItems.Count > 0 Then
            name = Regex.Split(boxShop.SelectedItems(0), "\s*?[0-9]*?g")(0)
        End If

        If name IsNot Nothing Then
            For i As Integer = 0 To p.inventory.Count - 1
                If p.inventory(i).getName() = name Then
                    p.inventory(i).examine()
                    Exit For
                End If
            Next
        End If

    End Sub
End Class