Public Enum cTier
    null
    tier1
    tier2
    tier3
    tier4
    tier5
End Enum
Public Class Chest
    Public contents As Inventory
    Public pos As Point
    Dim cached_lt_bracket As LootTable.bracket = -1
    Public tiers() As List(Of Item) = {Nothing, New List(Of Item), New List(Of Item), New List(Of Item), New List(Of Item)}

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
        Dim cArray() As String = s.Split("*")
        If cArray(0).Equals("LOADED") Then Return New LoadedChest(s)
        Dim chest = Me.Clone()

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
            Dim r As Integer = Int(Rnd() * 17)
            Dim itemTier As Integer = cTier.tier1
            Select Case r
                Case 19
                    itemTier = cTier.tier5
                Case 18, 17
                    itemTier = cTier.tier4
                Case 16, 15
                    itemTier = cTier.tier3
                Case 14, 13, 12, 11, 10, 9
                    itemTier = cTier.tier2
                Case Else
                    itemTier = cTier.tier1
            End Select
            If itemTier < 1 Or itemTier > tiers.Length - 1 Then
                Console.Out.WriteLine("Chest @ (" & CStr(x) & ", " & CStr(y) & ") tried making an item out of tier range.\nDefaulting to tier 1.")
                itemTier = 1
            End If

            Dim rng As Integer = Int(Rnd() * tiers(itemTier).Count)
            If rng > tiers(itemTier).Count - 1 Then rng = Math.Max(0, tiers(itemTier).Count - 1)

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
        toReturn.tiers = Me.tiers
        toReturn.contents = New Inventory(False)
        Return toReturn
    End Function
    Public Overridable Sub open(Optional ByVal try_mimic As Boolean = True)
        'handles the opening of a chest
        If Game.player1.pos <> pos Then Exit Sub
        If Not Game.combat_engaged And Game.mDun.numCurrFloor >= 3 And Not Me.GetType Is GetType(LoadedChest) Then
            Dim mOdds As Integer
            If Game.player1.perks(perk.cogreed) > -1 Then
                mOdds = 0
            ElseIf Game.mDun.numCurrFloor = 3 Then
                mOdds = Int(Rnd() * 2)
            Else
                mOdds = Int(Rnd() * 10)
            End If
            If try_mimic AndAlso Game.mDun.numCurrFloor <> 9999 And Game.mDun.numCurrFloor <> 10000 And Game.mDun.numCurrFloor <> 91017 And mOdds = 0 And Not contents.getCountAt(53) > 0 And Not Game.shop_npc_engaged And Not Game.combat_engaged Then
                Monster.createMimic(contents)
                Exit Sub
            End If
        End If
        pushLblEventChest()
        Game.player1.UIupdate()
        TextEvent.pushLog("You open a chest!")
    End Sub
    Public Sub pushLblEventChest()
        Dim c As String = "Chest Contents: " & vbCrLf


        For i = 0 To contents.upperBound
            Dim content As Item = contents.item(i)

            If content.only_drop_one Then
                If Game.player1.inv.getCountAt(i) > 0 Then contents.item(i).count = 0
                If content.getCount > 1 Then contents.item(i).count = 1
            End If

            If contents.getCountAt(i) > 0 And Not i = 43 Then
                c += " " & vbCrLf & "+" & content.count & " " & Game.player1.inv.item(i).getName() & " "
            End If
        Next

        Game.player1.inv.merge(contents)

        If contents.getCountAt(43) > 0 Then c += " " & vbCrLf & "+" & contents.getCountAt(43) & " " & Game.player1.inv.item(43).getName() & " "

        c += " " & DDUtils.PAKTC
        Game.lblEvent.Text = c
        If Settings.active(setting.textcolors) Then Game.lblEvent.ForeColor = Game.player1.textColor
        Game.lblEvent.BringToFront()
        Game.lblEvent.Location = New Point((250 * Game.Size.Width / 688) - (Game.lblEvent.Size.Width / 2), 65 * Game.Size.Width / 688)
        Game.lblEvent.Visible = True
        Game.player1.inv.invNeedsUDate = True
    End Sub
    Public Sub add(ByVal i As Integer, ByVal c As Integer)
        'adds a quantity "c" to inventory slot "i"
        contents.add(i, c)
    End Sub
    Public Function getCachedLootTableBracket(ByVal floor_num As Integer, Optional ByVal refresh As Boolean = False) As LootTable.bracket
        If refresh Then cached_lt_bracket = LootTable.getBracket(floor_num)

        Return cached_lt_bracket
    End Function
End Class
