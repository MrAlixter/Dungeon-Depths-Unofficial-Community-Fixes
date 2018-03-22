Public Class Chest
    Public contents() As Integer
    Public pos As Point
    Public tier1 = New ArrayList()
    Public tier2 = New ArrayList()
    Public tier3 = New ArrayList()
    Public tiers() = {Nothing, tier1, tier2, tier3}
    Sub New()
        'Empty. 
        'For duplication of baseChest (to later be filled)
    End Sub
    Sub New(size As Integer)
        contents = New Integer(size) {}
        'This should be used for creating the baseChest
        'This should be the only constructor used for the baseChest
    End Sub
    Function Create(ByVal x As Integer, ByVal y As Integer, ByVal code As String)
        Dim chest = Me.Clone()

        chest.pos = New Point(x, y)
        generateFromCode(chest, code)
        Return chest
    End Function
    Function Create(ByVal p As Point, ByVal code As String)
        Dim chest = Me.Clone()

        chest.pos = p
        generateFromCode(chest, code)
        Return chest
    End Function
    Function Create(ByVal p As Point)
        Dim chest = Me.Clone()
        chest.pos = p
        Return chest
    End Function
    Function Create(ByVal x As Integer, ByVal y As Integer)
        Dim chest = Me.Clone()
        chest.pos = New Point(x, y)
        Return chest
    End Function
    Function Create(ByVal i() As Integer, ByVal p As Point)
        Dim chest = Me.Clone()

        For ind = 0 To UBound(i)
            chest.contents(ind) += i(ind)
        Next

        If chest.contents(43) < 1 Then chest.contents(43) = Int(Rnd() * 250)
        chest.pos = p
        Return chest
    End Function
    Function Create(ByVal s As String)
        Dim chest = Me.Clone()

        Dim cArray() As String = s.Split("*")
        chest.pos = New Point(cArray(0), cArray(1))
        For i = 2 To UBound(contents)
            chest.contents(i) = cArray(i)
        Next

        Return chest
    End Function
    Sub generateFromCode(ByRef chest As Chest, ByVal code As String)
        Dim x As Integer = chest.pos.X
        Dim y As Integer = chest.pos.Y
        Randomize(code.GetHashCode)
        Dim numC As Integer = CInt(Int(Rnd() * 5) + 1)
        For i = 0 To numC
            Dim r As Integer = Int(Rnd() * 10)
            Dim itemTier As Integer = 1
            Select Case r
                Case 0 To 4
                    itemTier = 1
                Case 9
                    itemTier = 3
                Case Else
                    itemTier = 2
            End Select
            If itemTier < 1 Or itemTier > tiers.Length - 1 Then
                MessageBox.Show("Chest @ (" & CStr(x) & ", " & CStr(y) & ") tried making an item out of tier range.\nDefaulting to tier 1.")
                itemTier = 1
            End If

            Dim rng As Integer = Int(Rnd() * tiers(itemTier).Count)
            If rng > tiers(itemTier).Count - 1 Then rng = tiers(itemTier).Count - 1
            Dim itemID As Integer = tiers(itemTier)(rng).id 'Int(Rnd() * tier.Length))
            chest.add(itemID, 1)
            If itemID = 43 Then contents(itemID) += Int(Rnd() * 150)
        Next
    End Sub
    Function Clone()
        Dim toReturn = New Chest()
        toReturn.tier1 = Me.tier1
        toReturn.tier2 = Me.tier2
        toReturn.tier3 = Me.tier3
        toReturn.tiers = Me.tiers
        toReturn.contents = New Integer(Me.contents.Length - 1) {}
        Return toReturn
    End Function
    Sub open()

        If Game.player.pos <> pos Then Exit Sub
        If Not Game.combatmode And Game.floor >= 3 Then
            Dim mOdds As Integer
            If Game.floor = 3 Then
                mOdds = Int(Rnd() * 2)
            Else
                mOdds = Int(Rnd() * 10)
            End If
            If mOdds = 0 And Not contents(53) > 0 Then
                Monster.createMimic(contents)
                Exit Sub
            End If
        End If
        Dim c As String = "Chest Contents: " & vbCrLf
        For i = 0 To UBound(contents)
            Game.player.inventory.Item(i).add(contents(i))
            
            If contents(i) > 0 Then
                If Game.player.inventory(i).GetType().IsSubclassOf(GetType(MysteryPotion)) Then
                    c += " " & vbCrLf & "+" & contents(i) & " " & Game.player.inventory(i).getName() & " "
                Else
                    c += " " & vbCrLf & "+" & contents(i) & " " & Game.player.inventory(i).getName() & " "
                End If
            End If
        Next

        c += " " & vbCrLf & " " & vbCrLf & "Press ';' to continue."
        Game.lblEvent.Text = c
        Game.lblEvent.BringToFront()
        Game.lblEvent.Location = New Point((250 * Game.Size.Width / 688) - (Game.lblEvent.Size.Width / 2), 65 * Game.Size.Width / 688)
        Game.lblEvent.Visible = True
        Game.player.invNeedsUDate = True
        Game.player.UIupdate()
        Game.lstLog.Items.Add("You open a chest!")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Public Overrides Function ToString() As String
        Dim output As String = ""
        output += CStr(pos.X & "*")
        output += CStr(pos.Y & "*")
        For i = 0 To UBound(contents)
            output += (contents(i) & "*")
        Next
        Return output
    End Function
    Public Sub add(ByVal i As Integer, ByVal c As Integer)
        contents(i) += c
    End Sub
End Class
