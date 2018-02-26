Public Class Equipment
    'Form3 is the form that handles the equiping of armor and weapons

    'instance variables for Form3
    'armor
    Public aNameList() As String = {"Common_Clothes", "Steel_Armor", "Skimpy_Clothes", "Steel_Bikini"}
    Public aList() As Armor = {New NormalClothes(), Game.player.inventory(5), New SkimpyClothes()}
    'weapons
    Public wNameList() As String = {"Fists", "Steel_Sword", "SoulBlade", "Magic_Girl_Wand"}
    Public wList() As Weapon = {New BareFists(), New SteelSword(), Game.player.inventory.Item(9)}

    'define a shorthand representation of the main player
    Dim p As Player = Game.player


    'init triggers an initialion Form3's global variables
    Public Sub init()
        p = Game.player

        Dim a As Tuple(Of String(), Armor())
        Dim w As Tuple(Of String(), Weapon())
        a = p.getArmors
        w = p.getWeapons


        aNameList = a.Item1
        aList = a.Item2

        wNameList = w.Item1
        wList = w.Item2
    End Sub

    'handles the click of the 'ok' button
    Private Sub btnACPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnACPT.Click
        'checks if the player is a chicken (the chicken tf is not in the game at the moment)
        'If p.perks(3) Then
        '    Form1.lstLog.Items.Add("Chickens can't change clothes!")
        '    Me.Close()
        '    Exit Sub
        'End If

        'if clothes offer resistance on the way off, this handles that
        If (p.equippedArmor.getName.Equals("Ropes") And cmbobxArmor.SelectedItem <> "Ropes") Or (p.equippedArmor.getName.Equals("Living_Armor") _
            And cmbobxArmor.SelectedItem <> "Living_Armor") Or (p.equippedArmor.getName.Equals("Living_Lingerie") And cmbobxArmor.SelectedItem <> "Living_Lingerie") Then
            If Int(Rnd() * 2) = 0 Then
                Game.pushLblEvent("Despite a struggle agaisnt your bonds, you are unable to escape!  Oh well, maybe next time...")
                Me.Close()
                Exit Sub
            Else
                Game.pushLblEvent("You deftly take off your clothes, despite the resistance they put up.")
            End If
        End If

        'this handles the revert from the magical girl form, if needed
        Dim revertFlag As Boolean = False
        If p.equippedWeapon.getName.Equals("Magic_Girl_Wand") And p.title.Equals("Magic Girl") And Not cmbobxWeapon.Text.Equals("Magic_Girl_Wand") Then
            Game.lstLog.Items.Add("Putting away your wand causes you to change into your regular self!")
            p.inventory.Item(10).add(-1)
            p.magGState.save(p)
            p.revert2()
            revertFlag = True
        End If

        'handles the equiping of weapons
        Dim sWeapon As Weapon = Nothing
        If cmbobxWeapon.SelectedItem <> "" Then
            For i = 0 To UBound(wNameList)
                If cmbobxWeapon.SelectedItem.ToString().Split()(0) = wNameList(i) Then
                    sWeapon = wList(i)
                    Exit For
                End If
            Next
            If sWeapon Is Nothing Then Exit Sub
            p.equippedWeapon = sWeapon
        End If
        If p.equippedWeapon.mBoost > 0 Then p.mana += p.equippedWeapon.mBoost

        'equip the new armor
        If Not revertFlag Then clothesChange(cmbobxArmor.Text)
        If p.equippedArmor.mBoost > 0 Then p.mana += p.equippedArmor.mBoost

        If p.mana > p.getmaxMana Then p.mana = p.getmaxMana

        'if the player has the slutty dress curse, this takes care of it
        If p.perks("slutcurse") > -1 Then
            clothingCurse1()
        End If

        'handles any tfs or triggers triggered by equipping of certain weapons
        If p.equippedWeapon.getName = "Magic_Girl_Wand" And Not p.title.Equals("Magic Girl") Then
            Polymorph.transform(p, "Magic Girl")
        ElseIf p.equippedWeapon.getName = "Sword_of_the_Brutal" And Not p.perks("swordpossess") > -1 Then
            p.perks("swordpossess") = 0
        End If

        If p.title.Equals("Magic Girl") And p.equippedArmor.getName.Equals("Magic_Girl_Outfit") And Not revertFlag Then
            p.equippedArmor = p.inventory.Item(10)
            Game.lstLog.Items.Add("A magic girl needs her uniform!")
        End If

        If p.title.Equals("Blow-Up Doll") Then
            p.equippedArmor = New Naked
        End If

        'handles any tfs or triggers triggered by equipping of certain armors
        If p.equippedArmor.getName = "Living_Armor" And Not p.perks("livearm") > -1 Then
            p.perks("livearm") = 0
        ElseIf p.equippedArmor.getName = "Living_Lingerie" And Not p.perks("livelinge") > -1 Then
            p.perks("livelinge") = 0
        End If

        'updates the player, the stat display, and the portrait before the form closes
        portraitUDate()
        p.UIupdate()
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        Me.Close()
    End Sub
    'handles the loading of this form
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'initializes all variables in case this is the first time it is loaded
        init()

        'scales the text size of the form to the display size
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * Me.Size.Width / 210))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Font = newFont
        Next

        'adds the default clothes for various forms
        cmbobxArmor.Items.Add("Naked")
        If p.title = "Bimbo" Or p.perks("slutcurse") > -1 Then
            cmbobxArmor.Items.Add("Skimpy_Clothes")
        ElseIf p.title = "Princess" Then
            cmbobxArmor.Items.Add("Regal_Gown")
        ElseIf p.title = "Maid" Then
            cmbobxArmor.Items.Add("Maid_Outfit")
        ElseIf p.title = "Succubus" Then
            cmbobxArmor.Items.Add("Succubus_Garb")
        ElseIf p.title = "Goddess" Then
            cmbobxArmor.Items.Add("Goddess_Gown")
        Else
            cmbobxArmor.Items.Add("Common_Clothes")
        End If

        'adds the default weapon (fists)
        cmbobxWeapon.Items.Add("Fists")

        'adds all weapons and armors that the player posesses to their respective menus
        Dim a As Armor()
        Dim w As Weapon()
        a = p.getArmors.Item2
        w = p.getWeapons.Item2

        For i = 5 To UBound(a)
            If a(i).count > 0 Then cmbobxArmor.Items.Add(a(i).getName())
        Next
        For i = 1 To UBound(w)
            If w(i).count > 0 Then cmbobxWeapon.Items.Add(w(i).getName())
        Next

        'sets the text of the drop-downs to the player's equipment
        cmbobxWeapon.SelectedItem = p.equippedWeapon.getName()
        cmbobxArmor.SelectedItem = p.equippedArmor.getName()
    End Sub

    'clothingCurse1 routes the normal versions of armors to their slut forms, if they have them.
    Sub clothingCurse1()
        If p.perks("polymorphed") > -1 Then Exit Sub
        Dim affectedFlag As Boolean = True
        Select Case p.equippedArmor.getName.GetHashCode
            Case "Steel_Armor".GetHashCode
                p.inventory.Item(5).count -= 1
                p.equippedArmor = New SteelBikini
                p.inventory.Item(7).addOne()
            Case "Sorcerer's_Robes".GetHashCode
                p.inventory.Item(17).count -= 1
                p.equippedArmor = New WitchCosplay
                p.inventory.Item(18).addOne()
            Case "Warrior's_Cuirass".GetHashCode
                p.inventory.Item(19).count -= 1
                p.equippedArmor = New BrawlerCosplay
                p.inventory.Item(20).addOne()
            Case "Gold_Armor".GetHashCode
                p.inventory.Item(38).count -= 1
                p.equippedArmor = New GoldAdornment
                p.inventory.Item(39).add(1)
            Case "Living_Armor".GetHashCode
                p.inventory.Item(55).count -= 1
                p.equippedArmor = New LiveLingerie
                p.inventory.Item(56).add(1)
            Case "Common_Clothes".GetHashCode
                p.equippedArmor = New SkimpyClothes
            Case Else
                affectedFlag = False
        End Select
        If affectedFlag Then
            Game.lstLog.Items.Add("Your curse changes your clothes.")
            Game.lblEvent.ForeColor = Color.Pink
            If Not Game.Visible Then Game.pushLblEvent("As you don your new clothes, a shimmering light covers them, and they morph to better suit your style.")
            portraitUDate()
        End If
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Sub antiClothingCurse()
        If p.perks("polymorphed") > -1 Then Exit Sub
        Dim affectedFlag As Boolean = True
        Select Case p.equippedArmor.getName.GetHashCode
            Case "Steel_Bikini".GetHashCode
                p.inventory.Item(7).count -= 1
                p.equippedArmor = New SteelArmor
                p.inventory.Item(5).addOne()
            Case "Witch_Cosplay".GetHashCode
                p.inventory.Item(18).count -= 1
                p.equippedArmor = New SorcerersRobes
                p.inventory.Item(17).addOne()
            Case "Brawler_Cosplay".GetHashCode
                p.inventory.Item(20).count -= 1
                p.equippedArmor = New WarriorsCuirass
                p.inventory.Item(19).addOne()
            Case "Gold_Adornment".GetHashCode
                p.inventory.Item(39).count -= 1
                p.equippedArmor = New GoldArmor
                p.inventory.Item(38).add(1)
            Case "Living_Lingerie".GetHashCode
                p.inventory.Item(56).count -= 1
                p.equippedArmor = New LiveArmor
                p.inventory.Item(55).add(1)
            Case "Skimpy_Clothes".GetHashCode
                p.equippedArmor = New NormalClothes
            Case Else
                affectedFlag = False
        End Select
        If affectedFlag Then
            Game.lstLog.Items.Add("Your curse is broken!")
            Game.lblEvent.ForeColor = Color.Pink
            Game.pushLblEvent("Your curse is broken! Unfortunatly, nothing can be done about the clothes in your inventory that have been affected.")
            portraitUDate()
        End If
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    'clothesChange handles the equipping and unequipping of armors
    Public Sub clothesChange(ByVal clothes As String)
        If aNameList.Count < 5 Then init()
        Dim sArmor As Armor = Nothing
        If clothes <> "" Then
            For i = 0 To UBound(aNameList)
                If clothes = aNameList(i) Then
                    'MsgBox("{" & cmbobxArmor.SelectedItem & "}&[" & aNameList(i) & "]")
                    sArmor = aList(i)
                    Exit For
                End If
            Next
            If sArmor Is Nothing Then Exit Sub
            If clothes = "Chicken_Suit" Then Polymorph.transform(p, "Chicken2")
            p.equippedArmor = sArmor
        End If
    End Sub
    'portraitUDate updates the player's portrait based on their breastsize and armor
    Public Sub portraitUDate()
        If p.iArrInd(2).Item1 <> 4 Then p.bsizeroute()
        If p.equippedArmor.getName = "Skimpy_Clothes" Then
            Select Case p.breastSize
                Case 1
                    p.iArrInd(3) = p.equippedArmor.bsize1
                Case 2
                    p.iArrInd(3) = p.equippedArmor.bsize2
                Case 3
                    If Game.isMark And (p.title = "Bimbo" Or p.perks("slutcurse")) Then p.iArrInd(3) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fClothing.Count - 2, True) Else p.iArrInd(3) = p.equippedArmor.bsize3
                Case 4
                    p.iArrInd(3) = p.equippedArmor.bsize4
                Case Else
                    clothesChange("Naked")
                    If p.sexBool Then
                        p.iArrInd(3) = New Tuple(Of Integer, Boolean)(47, True)
                    Else
                        p.iArrInd(3) = New Tuple(Of Integer, Boolean)(5, False)
                    End If
            End Select
        ElseIf p.equippedArmor.getName = "Chicken_Suit" Then
            Select Case p.breastSize
                Case -1
                    p.iArrInd(16) = New Tuple(Of Integer, Boolean)(CharacterGenerator.mHat.Count - 2, False)
                    'Case 3
                    '    p.iArrInd(1) = New Tuple(Of Integer, Boolean)(12, True)
                    '    p.iArrInd(3) = New Tuple(Of Integer, Boolean)(36, True)
                    '    p.iArrInd(5) = New Tuple(Of Integer, Boolean)(12, True)
                    '    p.iArrInd(15) = New Tuple(Of Integer, Boolean)(13, True)
                Case Else
                    p.iArrInd(16) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fHat.Count - 2, True)
            End Select
        ElseIf p.equippedArmor.getName = "Magic_Girl_Outfit" Then
            Select Case p.breastSize
                Case 1
                    p.iArrInd(3) = p.equippedArmor.bsize1
                Case 3
                    p.haircolor = Color.FromArgb(255, 255, 250, 205)
                    p.iArrInd(1) = New Tuple(Of Integer, Boolean)(10, True)
                    p.iArrInd(5) = New Tuple(Of Integer, Boolean)(10, True)
                    p.iArrInd(15) = New Tuple(Of Integer, Boolean)(7, True)
                    p.iArrInd(3) = p.equippedArmor.bsize3
                Case Else
                    clothesChange("Naked")
                    If p.sexBool Then
                        p.iArrInd(3) = New Tuple(Of Integer, Boolean)(47, True)
                    Else
                        p.iArrInd(3) = New Tuple(Of Integer, Boolean)(5, False)
                    End If
            End Select
        ElseIf p.equippedArmor.getName = "Common_Clothes" Then
            Select Case p.breastSize
                Case -1
                    If Game.isMark Then
                        p.iArrInd(3) = New Tuple(Of Integer, Boolean)(CharacterGenerator.mClothing.Count - 1, False)
                    Else
                        p.iArrInd(3) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(3).Item1, p.iArrInd(2).Item2)
                    End If
                Case 1
                    p.iArrInd(3) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(3).Item1, p.iArrInd(2).Item2)
                Case 2
                    If Game.isMark Then
                        p.iArrInd(3) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fClothing.Count - 1, True)
                    Else
                        clothesChange("Naked")
                        Game.lstLog.Items.Add("Your clothes don't fit!")
                        If p.sexBool Then
                            p.iArrInd(3) = New Tuple(Of Integer, Boolean)(47, True)
                        Else
                            p.iArrInd(3) = New Tuple(Of Integer, Boolean)(5, False)
                        End If
                    End If
                Case Else
                    clothesChange("Naked")
                    Game.lstLog.Items.Add("Your clothes don't fit!")
                    If p.sexBool Then
                        p.iArrInd(3) = New Tuple(Of Integer, Boolean)(47, True)
                    Else
                        p.iArrInd(3) = New Tuple(Of Integer, Boolean)(5, False)
                    End If
            End Select
        Else
            Select Case p.breastSize
                Case -1
                    p.iArrInd(3) = p.equippedArmor.bsizeneg1
                Case 1
                    p.iArrInd(3) = p.equippedArmor.bsize1
                Case 2
                    p.iArrInd(3) = p.equippedArmor.bsize2
                Case 3
                    p.iArrInd(3) = p.equippedArmor.bsize3
                Case 4
                    p.iArrInd(3) = p.equippedArmor.bsize4
                Case 5
                    p.iArrInd(3) = p.equippedArmor.bsize5
            End Select
            If p.iArrInd(3) Is Nothing Then
                clothesChange("Naked")
                Game.lstLog.Items.Add("Your clothes don't fit!")
                If p.sexBool Then
                    p.iArrInd(3) = New Tuple(Of Integer, Boolean)(47, True)
                Else
                    p.iArrInd(3) = New Tuple(Of Integer, Boolean)(5, False)
                End If
            End If
        End If
        If Not p.equippedArmor.getName.Equals("Naked") And Not p.title.Equals("Magic Girl") Then
            If p.iArrInd(2).Item1 <> 10 And p.iArrInd(2).Item1 <> 16 Then
                Select Case p.breastSize
                    Case -1
                        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(0, False)
                    Case 1
                        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(5, True)
                    Case 2
                        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(6, True)
                    Case 3
                        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(7, True)
                    Case 4
                        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(8, True)
                    Case 5
                        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(9, True)
                End Select
            End If
        ElseIf p.equippedArmor.getName.Equals("Naked") Then
            If p.iArrInd(2).Item1 <> 4 And p.iArrInd(2).Item1 <> 16 Then
                Select Case p.breastSize
                    Case -1
                        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(0, False)
                    Case 1
                        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(0, True)
                    Case 2
                        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(1, True)
                    Case 3
                        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(2, True)
                    Case 4
                        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(3, True)
                    Case 5
                        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(4, True)
                End Select
            End If
        End If
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        p.createP()
        'Form1.picPortrait.BackgroundImage = CharacterGenerator1.CreateBMP(p.iArr)
        Game.picPortrait.Update()
    End Sub
End Class