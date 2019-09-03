Public Class Chest
    Public contents As Inventory
    Public pos As Point
    Public tier1 = New List(Of Item)
    Public tier2 = New List(Of Item)
    Public tier3 = New List(Of Item)
    Public tiers() As List(Of Item) = {Nothing, tier1, tier2, tier3}
    '|CONSTRUCTORS|
    Sub New()
        contents = New Inventory(False)
    End Sub

    '|PSEUDOCONSTRUCTORS|
    Function Create(ByVal p As Point, ByVal code As String) As Chest
        'functions as a pseudo constructor for a chest object
        'creates a chest from a point and a randomization seed
        Dim chest = Me.Clone()
        chest.pos = p
        generateFromCode(chest, code)
        Return chest
    End Function
    Function Create(ByVal p As Point) As Chest
        'functions as a pseudo constructor for a chest object
        'creates an empty chest from a point
        Dim chest = Me.Clone()
        chest.pos = p
        Return chest
    End Function
    Function Create(ByVal i As Inventory, ByVal p As Point, Optional addGold As Boolean = True) As Chest
        'functions as a pseudo constructor for a chest object
        'creates a chest from an inventory array and a point
        Dim chest = Me.Clone()

        For x = 0 To contents.upperBound
            chest.contents.setCount(x, i.getCountAt(x))
        Next

        If addGold And chest.contents.getCountAt(43) < 1 Then chest.contents.setCount(43, CInt(Rnd() * 250))
        chest.pos = p
        Return chest
    End Function
    Function Create(ByVal s As String) As Chest
        'functions as a pseudo constructor for a chest object
        'loads a chest from a saved string
        Dim chest = Me.Clone()
        Dim cArray() As String = s.Split("*")
        chest.pos = New Point(cArray(0), cArray(1))
        chest.contents.load(cArray(2))

        Return chest
    End Function

    '|CHEST GENERATION METHOD|
    Sub generateFromCode(ByRef chest As Chest, ByVal code As String)
        'populates a chest's iventory based from a randomization seed
        Dim x As Integer = chest.pos.X
        Dim y As Integer = chest.pos.Y
        Randomize(code.GetHashCode)
        Dim numC As Integer = CInt(Int(Rnd() * Game.chestRichnessRange) + Game.chestRichnessBase)
        For i = 0 To numC
            Dim r As Integer = Int(Rnd() * 10)
            Dim itemTier As Integer = 1
            Select Case r
                Case 0, 1, 2, 3, 4
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
            If itemID = 43 Then
                contents.setCount(itemID, CInt(Rnd() * 150))
            Else
                chest.add(itemID, 1)
            End If
        Next
    End Sub

    '|UTILITY METHODS|
    Function Clone() As Chest
        'creates a hard copy of a chest
        Dim toReturn = New Chest()
        toReturn.tier1 = Me.tier1
        toReturn.tier2 = Me.tier2
        toReturn.tier3 = Me.tier3
        toReturn.tiers = Me.tiers
        toReturn.contents = New Inventory(False)
        Return toReturn
    End Function
    Public Overridable Sub open()
        'handles the opening of a chest
        If Game.player.pos <> pos Then Exit Sub
        If Not Game.combatmode And game.mDun.numCurrFloor >= 3 And Not Me.GetType Is GetType(LoadedChest) Then
            Dim mOdds As Integer
            If game.mDun.numCurrFloor = 3 Then
                mOdds = Int(Rnd() * 2)
            Else
                mOdds = Int(Rnd() * 10)
            End If
            If game.mDun.numCurrFloor <> 9999 And mOdds = 0 And Not contents.getCountAt(53) > 0 Then
                Monster.createMimic(contents)
                Exit Sub
            End If
        End If
        pushLblEventChest()
        Game.player.UIupdate()
        Game.pushLstLog("You open a chest!")
        
    End Sub
    Public Sub pushLblEventChest()
        Dim c As String = "Chest Contents: " & vbCrLf

        Game.player.inv.merge(contents)
        For i = 0 To contents.upperBound
            Dim content As Item = contents.item(i)
            If contents.getCountAt(i) > 0 Then
                c += " " & vbCrLf & "+" & content.count & " " & Game.player.inv.item(i).getName() & " "
            End If
        Next
        c += " " & vbCrLf & " " & vbCrLf & "Press any non-movement key to continue."
        Game.lblEvent.Text = c
        Game.lblEvent.BringToFront()
        Game.lblEvent.Location = New Point((250 * Game.Size.Width / 688) - (Game.lblEvent.Size.Width / 2), 65 * Game.Size.Width / 688)
        Game.lblEvent.Visible = True
        Game.player.inv.invNeedsUDate = True
    End Sub
    Public Sub add(ByVal i As Integer, ByVal c As Integer)
        'adds a quantity "c" to inventory slot "i"
        contents.add(i, c)
    End Sub

    '|SAVE METHOD|
    Public Overrides Function ToString() As String
        Dim output As String = ""
        output += CStr(pos.X & "*")
        output += CStr(pos.Y & "*")
        output += contents.save()
        Return output
    End Function
End Class
