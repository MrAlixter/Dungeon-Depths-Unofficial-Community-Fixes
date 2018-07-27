Imports System.Text.RegularExpressions

Public Class ShopV2
    Dim sk As NPC = Game.currNPC
    Dim p As Player = Game.player
    Dim skInventory As ArrayList = Nothing
    'Dim ind As Integer = -1
    Private Sub Done_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Me.Close()
    End Sub
    Private Sub Shop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        skInventory = New ArrayList()

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
        lblShopkeeper.Left = boxShopFilter.Left - (6 * RW) - lblShopkeeper.Width 'To keep it right aligned with the shopkeeper filter inventory box
    End Sub

    Private Sub RefreshScreen()
        lblYG.Text = "Gold: " & p.gold
        lblSKG.Text = "Gold: " & sk.gold
        boxInventory.Items.Clear()
        skInventory.Clear()
        boxShop.Items.Clear()
        For i = 0 To p.inventory.Count - 1
            ' If p.inventory(i).count > 0 And (Not (p.inventory(i).getName.Equals(p.equippedArmor.getName) Or p.inventory(i).getName.Equals(p.equippedWeapon.getName))) Then
            If p.inventory(i).count > 0 Then
                If p.inventory(i).getName().Equals(p.equippedArmor.getName()) Or p.inventory(i).getName().Equals(p.equippedWeapon.getName()) Then
                    If p.inventory(i).count > 1 Then
                        boxInventory.Items.Add(lineup(p.inventory(i).getName(), Int(p.inventory(i).value / 2), p.inventory(i).count - 1))
                    End If
                Else
                    boxInventory.Items.Add(lineup(p.inventory(i).getName(), Int(p.inventory(i).value / 2), p.inventory(i).count))
                End If
            End If
        Next
        For i = 0 To sk.inventory.Count - 1
            If sk.inventory(i) > 0 Then
                boxShop.Items.Add(lineup(p.inventory(i).getName(), p.inventory(i).value))
                skInventory.Add(p.inventory(i))
            End If
        Next
    End Sub

    'sell
    Private Sub btnSell_Click(sender As Object, e As EventArgs) Handles btnSell.Click
        Dim items = boxInventory.SelectedItems
        Dim cost As Integer = 0
        Dim indexes As List(Of Integer) = New List(Of Integer)
        For i As Integer = 0 To items.Count - 1
            Dim name As String = Regex.Split(items(i), "\s*?[0-9]*?g")(0)
            Dim ind As Integer
            For j As Integer = 0 To p.inventory.Count - 1
                If CType(p.inventory(j), Item).getName() = name Then
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
                If item.getName().Equals(p.equippedArmor.getName()) Or item.getName().Equals(p.equippedWeapon.getName()) Then
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
            Dim name As String = Regex.Split(items(i), "\s*?[0-9]*?g")(0)
            Dim ind As Integer
            For j As Integer = 0 To p.inventory.Count - 1
                If CType(p.inventory(j), Item).getName() = name Then
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

    ''buy
    'Private Sub cBoxBuy_SelectedValueChanged(sender As Object, e As EventArgs)
    '    Try
    '        ind = cBoxBuy.Items.IndexOf(cBoxBuy.Text)
    '        cBoxBuyQTY.Items.Clear()
    '        Dim numCanBuy As Integer = Math.Floor(p.gold / pCanBuy(ind).value)
    '        If numCanBuy < 1 Then
    '            cBoxBuyQTY.Text = "N/a"
    '            cBoxBuyQTY.Items.Add("N/a")
    '            Exit Sub
    '        End If
    '        If numCanBuy >= 1 Then cBoxBuyQTY.Items.Add(1)
    '        If numCanBuy >= 2 Then cBoxBuyQTY.Items.Add(2)
    '        If numCanBuy >= 3 Then cBoxBuyQTY.Items.Add(3)
    '        If numCanBuy >= 5 Then cBoxBuyQTY.Items.Add(5)
    '        If numCanBuy >= 10 Then cBoxBuyQTY.Items.Add(10)
    '        cBoxBuyQTY.Text = 1
    '    Catch ex As NullReferenceException

    '    End Try
    'End Sub
    'Private Sub btnBuy_Click(sender As Object, e As EventArgs)
    '    If cBoxBuy.Text = "-- Select --" Or cBoxBuyQTY.Text = "" Or cBoxBuyQTY.Text = "N/a" Then Exit Sub
    '    If ind <> -1 AndAlso p.gold >= (pCanBuy(ind).value * (CInt(cBoxBuyQTY.Text))) Then
    '        pCanBuy(ind).add((CInt(cBoxBuyQTY.Text)))
    '        p.gold -= pCanBuy(ind).value * (CInt(cBoxBuyQTY.Text))
    '        sk.gold += pCanBuy(ind).value * (CInt(cBoxBuyQTY.Text))
    '    ElseIf p.gold < (pCanBuy(ind).value * (CInt(cBoxBuyQTY.Text))) Then
    '        Game.lstLog.Items.Add("You don't have the money!")
    '        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    '    End If
    '    cBoxSell.Items.Clear()
    '    pCanSell.Clear()
    '    For i = 0 To p.inventory.Count - 1
    '        If p.inventory(i).count > 0 And (Not (p.inventory(i).getName.Equals(p.equippedArmor.getName) Or p.inventory(i).getName.Equals(p.equippedWeapon.getName))) Then
    '            cBoxSell.Items.Add(lineup(p.inventory(i).getName(), Int(p.inventory(i).value / 2)))
    '            pCanSell.Add(p.inventory(i))
    '        End If
    '    Next
    '    lblYG.Text = "Your Gold = " & p.gold
    '    lblSKG.Text = sk.name & "'s Gold = " & sk.gold
    '    cBoxBuy.Text = "-- Select --"
    '    cBoxBuyQTY.Text = ""
    '    Game.player.invNeedsUDate = True
    '    Game.player.UIupdate()
    'End Sub

    Function lineup(ByVal s As String, ByVal i As Integer, Optional ByVal j As Integer = -1)
        If s.Length > 14 Then s = s.Substring(0, 13) & "."
        If s.Length < 14 Then
            For x = s.Length To 14
                s = s & " "
            Next
        End If
        If s.Length = 14 Then s = s & " "
        If j = -1 Then
            Return s & " " & i & "g"
        Else
            Return s & " " & i & "g" & "  x" & j
        End If
    End Function
End Class