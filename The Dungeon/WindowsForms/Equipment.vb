Public Class Equipment
    'Form3 is the form that handles the equiping of armor and weapons

    'instance variables for Form3
    'armor
    Public aList As Dictionary(Of String, Armor) = New Dictionary(Of String, Armor)
    'weapons
    Public wList As Dictionary(Of String, Weapon) = New Dictionary(Of String, Weapon)
    'accessories
    Public acList As Dictionary(Of String, Accessory) = New Dictionary(Of String, Accessory)
    'define a shorthand representation of the main player
    Dim p As Player = Game.player


    'init triggers an initialion Form3's global variables
    Public Sub init()
        p = Game.player

        Dim a As Tuple(Of String(), Armor())
        Dim w As Tuple(Of String(), Weapon())
        Dim ac As Tuple(Of String(), Accessory())

        a = p.getArmors
        w = p.getWeapons
        ac = p.getAccesories

        aList.Clear()
        wList.Clear()
        acList.Clear()

        For i = 0 To UBound(a.Item1)
            aList.Add(a.Item1(i), a.Item2(i))
        Next

        For i = 0 To UBound(w.Item1)
            wList.Add(w.Item1(i), w.Item2(i))
        Next

        For i = 0 To UBound(ac.Item1)
            acList.Add(ac.Item1(i), ac.Item2(i))
        Next
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
            And cmbobxArmor.SelectedItem <> "Living_Armor") Or (p.equippedArmor.getName.Equals("Living_Lingerie") And cmbobxArmor.SelectedItem <> "Living_Lingerie") _
            Or (p.equippedAcce.getName.Equals("Slave_Collar") And cboxAccessory.SelectedItem <> "Slave_Collar") Then
            If Int(Rnd() * 2) = 0 Then
                Game.pushLblEvent("Despite a struggle agaisnt your bonds, you are unable to escape!  Oh well, maybe next time...")
                Me.Close()
                Exit Sub
            Else
                Game.pushLblEvent("You deftly take off your clothes, despite the resistance they put up.")
            End If
        End If

        Dim oW, oA, oAc As String
        oW = p.equippedWeapon.getName
        oA = p.equippedArmor.getName
        oAc = p.equippedAcce.getName

        'this handles the revert from the magical girl form, if needed
        Dim revertFlag As Boolean = False
        If p.equippedWeapon.getName.Equals("Magic_Girl_Wand") And p.pClass.name.Equals("Magic Girl") And Not cmbobxWeapon.Text.Equals("Magic_Girl_Wand") Then
            Game.lstLog.Items.Add("Putting away your wand causes you to change into your regular self!")
            p.inventory.Item(10).add(-1)
            p.magGState.save(p)
            p.revertToPState()
            revertFlag = True
        End If

        'handles the equiping of weapons
        If Not cmbobxWeapon.Text.Equals(p.equippedWeapon.getName) Then
            If p.equippedWeapon.mBoost > 0 Then p.mana += p.equippedWeapon.mBoost
        End If
        weaponChange(cmbobxWeapon.Text)

        'equip the new armor
        If Not revertFlag Then
            If Not cmbobxArmor.Text.Equals(p.equippedArmor.getName) Then
                If p.equippedArmor.mBoost > 0 Then p.mana += p.equippedArmor.mBoost
            End If
            clothesChange(cmbobxArmor.Text)
        End If

        'equip the new accessory
        If Not revertFlag Then accChange(cboxAccessory.Text)
        If p.equippedAcce.mBoost > 0 Then p.mana += p.equippedAcce.mBoost

        If p.mana > p.getmaxMana Then p.mana = p.getmaxMana

        'if the player has the slutty dress curse, this takes care of it
        If p.perks("slutcurse") > -1 Then
            clothingCurse1()
        End If
        'handles any tfs or triggers triggered by equipping of certain weapons
        If p.pClass.name.Equals("Magic Girl") And p.equippedArmor.getName.Equals("Magic_Girl_Outfit") And Not revertFlag Then
            p.equippedArmor = p.inventory.Item(10)
            Game.lstLog.Items.Add("A magic girl needs her uniform!")
        End If
        If p.pForm.name.Equals("Blow-Up Doll") Then
            p.equippedArmor = New Naked
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
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * Me.Size.Width / 210))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Font = newFont
            Me.Controls(i).Width += CDbl(Me.Controls(i).Width * RW)
            Me.Controls(i).Height += CDbl(Me.Controls(i).Height * RH)
            Me.Controls(i).Left += CDbl(Me.Controls(i).Left * RW)
            Me.Controls(i).Top += CDbl(Me.Controls(i).Top * RH)
        Next

        'adds the default clothes for various forms
        cmbobxArmor.Items.Add("Naked")
        If p.pClass.name = "Bimbo" Or p.perks("slutcurse") > -1 Then
            cmbobxArmor.Items.Add("Skimpy_Clothes")
        ElseIf p.pClass.name = "Princess" Then
            cmbobxArmor.Items.Add("Regal_Gown")
        ElseIf p.pClass.name = "Maid" Then
            cmbobxArmor.Items.Add("Maid_Outfit")
        ElseIf p.pForm.name = "Succubus" Or p.pForm.name = "Half-Succubus" Then
            cmbobxArmor.Items.Add("Succubus_Garb")
        ElseIf p.pClass.name = "Goddess" Then
            cmbobxArmor.Items.Add("Goddess_Gown")
        Else
            cmbobxArmor.Items.Add("Common_Clothes")
        End If

        'adds the default weapon (fists)
        cmbobxWeapon.Items.Add("Fists")

        'adds the default accessory (nothing)
        cboxAccessory.Items.Add("Nothing")

        'adds all weapons and armors that the player posesses to their respective menus
        For Each v In aList.Values
            If v.count > 0 Then cmbobxArmor.Items.Add(v.getName())
        Next
        For Each v In wList.Values
            If v.count > 0 Then cmbobxWeapon.Items.Add(v.getName())
        Next
        For Each v In acList.Values
            If v.count > 0 Then cboxAccessory.Items.Add(v.getName())
        Next

        'sets the text of the drop-downs to the player's equipment
        cmbobxWeapon.SelectedItem = p.equippedWeapon.getName()
        cmbobxArmor.SelectedItem = p.equippedArmor.getName()
        cboxAccessory.SelectedItem = p.equippedAcce.getName()
    End Sub

    'clothingCurse1 routes the normal versions of armors to their slut forms, if they have them.
    Function clothingCurse1() As Boolean
        If p.perks("polymorphed") > -1 Then Return False
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
            Return True
        End If
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        Return False
    End Function
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
        If aList.Count < 1 Then init()
        If Not p.equippedArmor Is Nothing AndAlso clothes.Equals(p.equippedArmor.getName) Then Exit Sub
        Dim sArmor As Armor = Nothing
        If clothes <> "" Then
            For Each k In aList.Keys
                If clothes.Equals(k) Then
                    'MsgBox("{" & cmbobxArmor.SelectedItem & "}&[" & aNameList(i) & "]")
                    sArmor = aList(k)
                    If Not p.equippedArmor Is Nothing Then p.equippedArmor.onUnequip()
                    Exit For
                End If
            Next
            If sArmor Is Nothing Then Exit Sub
            p.equippedArmor = sArmor
            p.equippedArmor.onEquip()
        End If
    End Sub
    'clothesChange handles the equipping and unequipping of weapon
    Public Sub weaponChange(ByVal weapon As String)
        If wList.Count < 1 Then init()
        Dim sWeapon As Weapon = Nothing
        If Not p.equippedWeapon Is Nothing AndAlso weapon.Equals(p.equippedWeapon.getName) Then Exit Sub
        If weapon <> "" Then
            For Each k In acList.Keys
                If weapon.Split()(0).Equals(k) Then
                    sWeapon = wList(k)
                    If Not p.equippedWeapon Is Nothing Then p.equippedWeapon.onUnequip()
                    Exit For
                End If
            Next
            If sWeapon Is Nothing Then Exit Sub
            p.equippedWeapon = sWeapon
            p.equippedWeapon.onEquip()
        End If
    End Sub
    'accChange handles the equipping and unequipping of accessories
    Public Sub accChange(ByVal acc As String)
        If acList.Count < 1 Then init()
        If Not p.equippedAcce Is Nothing AndAlso acc.Equals(p.equippedAcce.getName) Then Exit Sub
        Dim sAcc As Accessory = Nothing
        If acc <> "" Then
            For Each k In acList.Keys
                If acc.Equals(k) Then
                    'MsgBox("{" & acList(i).getName & "}&[" & acNameList(i) & "]")
                    sAcc = acList(k)
                    If Not p.equippedAcce Is Nothing Then p.equippedAcce.onUnequip()
                    Exit For
                End If
            Next
            If sAcc Is Nothing Then Exit Sub
            p.equippedAcce = sAcc
            p.equippedAcce.onEquip()
        End If
    End Sub
    'portraitUDate updates the player's portrait based on their breastsize and armor
    Public Sub portraitUDate()
        If p.iArrInd(2).Item1 <> 4 Then p.bsizeroute()
        If p.equippedArmor.getName = "Skimpy_Clothes" Then
            skimpyClothesUpdate()
        ElseIf p.equippedArmor.getName = "Magic_Girl_Outfit" Then
            mgoutfitUpdate()
        ElseIf p.equippedArmor.getName = "Common_Clothes" Then
            cclothesUpdate()
        Else
            Select Case p.breastSize
                Case -1
                    p.iArrInd(3) = p.equippedArmor.bsizeneg1
                Case 0
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
                Case 6
                    p.iArrInd(3) = p.equippedArmor.bsize6
                Case 7
                    p.iArrInd(3) = p.equippedArmor.bsize7
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
        If Not p.equippedArmor.getName.Equals("Naked") And p.equippedArmor.compressesBreasts And Not p.pClass.name.Equals("Magic Girl") Then
            compressBreasts()
        ElseIf p.equippedArmor.getName.Equals("Naked") Or Not p.equippedArmor.compressesBreasts Then
            notcompress()
        End If

        If p.equippedAcce Is Nothing Or (p.equippedAcce.fInd Is Nothing And p.equippedAcce.mInd Is Nothing) Then
            p.equippedAcce = New noAcce()
        Else
            If p.sexBool Then
                If Not p.equippedAcce.fInd Is Nothing Then p.iArrInd(14) = p.equippedAcce.fInd Else p.iArrInd(4) = p.equippedAcce.mInd
            Else
                If Not p.equippedAcce.mInd Is Nothing Then p.iArrInd(14) = p.equippedAcce.mInd Else p.iArrInd(4) = p.equippedAcce.fInd
            End If
        End If

        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        p.createP()
        'Form1.picPortrait.BackgroundImage = CharacterGenerator1.CreateBMP(p.iArr)
    End Sub
    Public Sub skimpyClothesUpdate()
        Select Case p.breastSize
            Case 1
                p.iArrInd(3) = p.equippedArmor.bsize1
            Case 2
                p.iArrInd(3) = p.equippedArmor.bsize2
            Case 3
                p.iArrInd(3) = p.equippedArmor.bsize3
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
    End Sub
    Public Sub mgoutfitUpdate()
        If Not p.pClass.name.Equals("Magic Girl") And Not (p.pClass.name.Equals("Bimbo") And p.breastSize = 3) Then
            clothesChange("Naked")
            Game.pushLblEvent("Your clothes don't fit!")
            Game.lstLog.Items.Add("Your clothes don't fit!")
            If p.sexBool Then
                p.iArrInd(3) = New Tuple(Of Integer, Boolean)(47, True)
            Else
                p.iArrInd(3) = New Tuple(Of Integer, Boolean)(5, False)
            End If
        End If
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
    End Sub
    Public Sub cclothesUpdate()
        Select Case p.breastSize
            Case -1
                p.iArrInd(3) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(3).Item1, p.iArrInd(2).Item2)
            Case 0
                p.iArrInd(3) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(3).Item1, p.iArrInd(2).Item2)
            Case 1
                p.iArrInd(3) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(3).Item1, p.iArrInd(2).Item2)
            Case 2
                p.iArrInd(3) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(3).Item1 + 99, p.iArrInd(2).Item2)
            Case Else
                clothesChange("Naked")
                Game.lstLog.Items.Add("Your clothes don't fit!")
                If p.sexBool Then
                    p.iArrInd(3) = New Tuple(Of Integer, Boolean)(47, True)
                Else
                    p.iArrInd(3) = New Tuple(Of Integer, Boolean)(5, False)
                End If
        End Select
    End Sub
    Public Sub compressBreasts()
        If p.iArrInd(2).Item1 <> 10 And p.iArrInd(2).Item1 <> 16 And p.iArrInd(2).Item1 <> 21 Then
            Select Case p.breastSize
                Case -1
                    p.iArrInd(2) = New Tuple(Of Integer, Boolean)(0, False)
                Case 0
                    p.iArrInd(2) = New Tuple(Of Integer, Boolean)(2, False)
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
                Case 6
                    p.iArrInd(2) = New Tuple(Of Integer, Boolean)(18, True)
                Case 7
                    p.iArrInd(2) = New Tuple(Of Integer, Boolean)(20, True)
            End Select
        End If
    End Sub
    Public Sub notcompress()
        If p.iArrInd(2).Item1 <> 4 And p.iArrInd(2).Item1 <> 16 And p.iArrInd(2).Item1 <> 21 Then
            Select Case p.breastSize
                Case -1
                    p.iArrInd(2) = New Tuple(Of Integer, Boolean)(0, False)
                Case 0
                    p.iArrInd(2) = New Tuple(Of Integer, Boolean)(2, False)
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
                Case 6
                    p.iArrInd(2) = New Tuple(Of Integer, Boolean)(17, True)
                Case 7
                    p.iArrInd(2) = New Tuple(Of Integer, Boolean)(19, True)
            End Select
        End If
    End Sub
End Class