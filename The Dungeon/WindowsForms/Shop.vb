Public Class Shop
    Dim sk As NPC = Form1.currNPC
    Dim p As Player = Form1.player
    Dim pCanBuy As ArrayList = New ArrayList
    Dim pCanSell As ArrayList = New ArrayList
    Dim ind As Integer = -1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub Shop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * Me.Size.Width / 288))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Font = newFont
        Next
        lblYG.Text = "Your Gold = " & p.gold
        lblSKG.Text = sk.name & "'s Gold = " & sk.gold
        For i = 0 To p.inventory.Count - 1
            If p.inventory(i).count > 0 And (Not (p.inventory(i).getName.Equals(p.equippedArmor.getName) Or p.inventory(i).getName.Equals(p.equippedWeapon.getName))) Then
                cBoxSell.Items.Add(lineup(p.inventory(i).getName(), Int(p.inventory(i).value / 2)))
                pCanSell.Add(p.inventory(i))
            End If
        Next
        For i = 0 To UBound(sk.inventory)
            If sk.inventory(i) > 0 Then
                cBoxBuy.Items.Add(lineup(p.inventory(i).getName(), p.inventory(i).value))
                pCanBuy.Add(p.inventory(i))
            End If
        Next
    End Sub

    'sell
    Private Sub cBoxSell_SelectedValueChanged(sender As Object, e As EventArgs) Handles cBoxSell.SelectedValueChanged
        Try
            ind = cBoxSell.Items.IndexOf(cBoxSell.Text)
            cBoxSellQTY.Items.Clear()
            For i = 1 To pCanSell(ind).getCount()
                cBoxSellQTY.Items.Add(i)
            Next
            cBoxSellQTY.Text = 1
        Catch ex As NullReferenceException

        End Try
    End Sub
    Private Sub btnSell_Click(sender As Object, e As EventArgs) Handles btnSell.Click
        If ind <> -1 Then
            pCanSell(ind).sell(CInt(cBoxSellQTY.Text))
        End If
        lblYG.Text = "Your Gold = " & p.gold
        lblSKG.Text = sk.name & "'s Gold = " & sk.gold
        ind = -1
        cBoxSell.Items.Clear()
        pCanSell.Clear()
        For i = 0 To p.inventory.Count - 1
            If p.inventory(i).count > 0 And (Not (p.inventory(i).getName.Equals(p.equippedArmor.getName) Or p.inventory(i).getName.Equals(p.equippedWeapon.getName))) Then
                cBoxSell.Items.Add(lineup(p.inventory(i).getName(), Int(p.inventory(i).value / 2)))
                pCanSell.Add(p.inventory(i))
            End If
        Next
        cBoxSell.Text = "-- Select --"
        cBoxSellQTY.Text = ""
        Form1.player.invNeedsUDate = True
        Form1.player.UIupdate()
    End Sub

    'buy
    Private Sub cBoxBuy_SelectedValueChanged(sender As Object, e As EventArgs) Handles cBoxBuy.SelectedValueChanged
        Try
            ind = cBoxBuy.Items.IndexOf(cBoxBuy.Text)
            cBoxBuyQTY.Items.Clear()
            Dim numCanBuy As Integer = Math.Floor(p.gold / pCanBuy(ind).value)
            If numCanBuy < 1 Then
                cBoxBuyQTY.Text = "N/a"
                cBoxBuyQTY.Items.Add("N/a")
                Exit Sub
            End If
            If numCanBuy >= 1 Then cBoxBuyQTY.Items.Add(1)
            If numCanBuy >= 2 Then cBoxBuyQTY.Items.Add(2)
            If numCanBuy >= 3 Then cBoxBuyQTY.Items.Add(3)
            If numCanBuy >= 5 Then cBoxBuyQTY.Items.Add(5)
            If numCanBuy >= 10 Then cBoxBuyQTY.Items.Add(10)
            cBoxBuyQTY.Text = 1
        Catch ex As NullReferenceException

        End Try
    End Sub
    Private Sub btnBuy_Click(sender As Object, e As EventArgs) Handles btnBuy.Click
        If cBoxBuy.Text = "-- Select --" Or cBoxBuyQTY.Text = "" Or cBoxBuyQTY.Text = "N/a" Then Exit Sub
        If ind <> -1 AndAlso p.gold >= (pCanBuy(ind).value * (CInt(cBoxBuyQTY.Text))) Then
            pCanBuy(ind).count += (CInt(cBoxBuyQTY.Text))
            p.gold -= pCanBuy(ind).value * (CInt(cBoxBuyQTY.Text))
            sk.gold += pCanBuy(ind).value * (CInt(cBoxBuyQTY.Text))
        ElseIf p.gold < (pCanBuy(ind).value * (CInt(cBoxBuyQTY.Text))) Then
            Form1.lstLog.Items.Add("You don't have the money!")
            Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        End If
        cBoxSell.Items.Clear()
        pCanSell.Clear()
        For i = 0 To p.inventory.Count - 1
            If p.inventory(i).count > 0 And (Not (p.inventory(i).getName.Equals(p.equippedArmor.getName) Or p.inventory(i).getName.Equals(p.equippedWeapon.getName))) Then
                cBoxSell.Items.Add(lineup(p.inventory(i).getName(), Int(p.inventory(i).value / 2)))
                pCanSell.Add(p.inventory(i))
            End If
        Next
        lblYG.Text = "Your Gold = " & p.gold
        lblSKG.Text = sk.name & "'s Gold = " & sk.gold
        cBoxBuy.Text = "-- Select --"
        cBoxBuyQTY.Text = ""
        Form1.player.invNeedsUDate = True
        Form1.player.UIupdate()
    End Sub

    Function lineup(ByVal s As String, ByVal i As Integer)
        If s.Length > 14 Then s = s.Substring(0, 13) & "."
        If s.Length < 14 Then
            For x = s.Length To 14
                s = s & " "
            Next
        End If
        If s.Length = 14 Then s = s & " "
        Return s & " " & i & "g"
    End Function
End Class