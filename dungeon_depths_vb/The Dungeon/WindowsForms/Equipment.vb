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

        a = p.inv.getArmors
        w = p.inv.getWeapons
        ac = p.inv.getAccesories

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
            Game.pushLstLog("Putting away your wand causes you to change into your regular self!")
            p.inv.add(10, -1)
            p.magGState.save(p)
            p.revertToPState()
            revertFlag = True
        ElseIf p.equippedWeapon.getName.Equals("Valkyrie_Sword") And p.pClass.name.Equals("Valkyrie") And Not cmbobxWeapon.Text.Equals("Valkyrie_Sword") Then
            Game.pushLstLog("Putting away your sword causes you to change into your regular self!")
            p.inv.add(95, -1)
            p.revertToPState()
            revertFlag = True
        End If

        'equip the new armor
        If Not revertFlag Then
            If Not cmbobxArmor.Text.Equals(p.equippedArmor.getName) Then
                If p.equippedArmor.mBoost > 0 Then p.mana += p.equippedArmor.mBoost
            End If
            clothesChange(cmbobxArmor.Text)
        End If

        'handles the equiping of weapons
        If Not cmbobxWeapon.Text.Equals(p.equippedWeapon.getName) Then
            If p.equippedWeapon.mBoost > 0 Then p.mana += p.equippedWeapon.mBoost
        End If
        weaponChange(cmbobxWeapon.Text)

        'equip the new accessory
        If Not revertFlag Then accChange(cboxAccessory.Text)
        If p.equippedAcce.mBoost > 0 Then p.mana += p.equippedAcce.mBoost

        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana

        'if the player has the slutty dress curse, this takes care of it
        If p.perks("slutcurse") > -1 Then
            clothingCurse1()
        End If
        'handles any tfs or triggers triggered by equipping of certain weapons
        If p.pClass.name.Equals("Magic Girl") And Not p.equippedArmor.getName.Equals("Magic_Girl_Outfit") And Not revertFlag Then
            p.equippedArmor = p.inv.item(10)
            Game.pushLstLog("A magic girl needs her uniform!")
        End If
        If p.pClass.name.Equals("Valkyrie") And Not p.equippedArmor.getName.Equals("Valkyrie_Armor") And Not revertFlag Then
            p.equippedArmor = p.inv.item(95)
            Game.pushLstLog("Your armor magically re-equips!")
        End If

        If p.pForm.name.Equals("Blow-Up Doll") Then
            p.equippedArmor = New Naked
        End If

        'updates the player, the stat display, and the portrait before the form closes
        p.createP()
        'ring of the love goddess
        If p.perks("rotlg") > -1 Then
            PerkEffects.ROTLGRoute()
        End If
        p.UIupdate()

        Me.Close()
    End Sub
    'handles the loading of this form
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        If p.pClass.name = "Bimbo" Or p.perks("slutcurse") > -1 Or p.equippedArmor.getName.Equals("Skimpy_Clothes") Then
            cmbobxArmor.Items.Add("Skimpy_Clothes")
        ElseIf (p.perks("slutcurse") > -1 And p.equippedArmor.getName.Equals("Skimpy_Clothes")) Or p.equippedArmor.getName.Equals("Very_Skimpy_Clothes") Then
            cmbobxArmor.Items.Add("Very_Skimpy_Clothes")
        ElseIf p.pClass.name = "Princess" Then
            cmbobxArmor.Items.Add("Regal_Gown")
        ElseIf p.pClass.name = "Maid" Then
            cmbobxArmor.Items.Add("Maid_Outfit")
        ElseIf p.pForm.name = "Succubus" Or p.pForm.name = "Half-Succubus" Then
            cmbobxArmor.Items.Add("Succubus_Garb")
        ElseIf p.pForm.name = "Slime" Then
            cmbobxArmor.Items.Add("Gelatinous_Shell")
        ElseIf p.pForm.name = "Goo Girl" Then
            cmbobxArmor.Items.Add("Gelatinous_Negligee")
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
        If p.equippedArmor.slutVarInd = -1 Then Return False

        If p.equippedArmor.getName.Equals("Common_Clothes") Then
            p.equippedArmor.onUnequip()
            p.equippedArmor = New SkimpyClothes
        ElseIf p.equippedArmor.getName.Equals("Skimpy_Clothes") Then
            p.equippedArmor.onUnequip()
            p.equippedArmor = New VSkimpyClothes
        Else
            Dim equippedArmorIndex = p.equippedArmor.id
            Dim slutVarIndex = p.equippedArmor.slutVarInd
            p.inv.add(equippedArmorIndex, -1)
            p.inv.add(slutVarIndex, 1)
            clothesChange(p.inv.item(slutVarIndex).getAName)
        End If
        Game.pushLstLog("Your curse changes your clothes.")
        If Not Game.lblEvent.Visible Then
            If p.isUnwilling Then
                'Author Credit: Big Iron Red
                Game.pushLblEvent("As you adjust your clothes, a crackling pink lightning coats them and they begin to shift across your body.  The flashes of magic intensify, and despite your panic, you find yourself forced to close your eyes at the risk of being overwhelmed by the blaze erupting from your equipment. As soon as it started, the curse finishes its work and you hesitantly open your eyes, feeling an oddly cold draft as you do so. You look down in abject horror as you find your previously protective armor has become a humiliatingly feminine facsimile of itself.\n" &
                                  "You quickly remove the outfit in a vain attempt to regain your former equipment, yet it remains the same embarrassingly useless ensemble that serves only to show the world your feminine body. Tears welling in your eyes, you slip back on what used to be your original armor, feeling incredibly exposed and vulnerable. ""How will anyone take me seriously wearing this?"" you think, as you wobble unsteadily ahead, followed by the unmistakable sound of high heels clicking on the dungeon floor.")
            Else
                Game.pushLblEvent("As you adust your clothes, a crackling pink lightning coats them and they begin to shift across your body.  As the flashes of magic intensify, and despite your panic, you find yourself forced to close your eyes at the risk of being overwhelmed by the blaze erupting from your equipment.  As soon as it started, the curse finishes its work and you hesitantly open your eyes only to find nothing seems to be amiss after all.  You take off and inspect the outfit which, as far as you can tell, doesn't seem any different after all.  Unconcerned by your brief nudity, you get dressed again and with a twirl you set back out on your adventure.")
            End If
        End If
        Return True
    End Function
    Function antiClothingCurse() As Boolean
        If p.equippedArmor.antiSlutVarInd = -1 Then Return False

        If p.equippedArmor.getName.Equals("Skimpy_Clothes") Then
            p.equippedArmor.onUnequip()
            p.equippedArmor = New CommonClothes
        ElseIf p.equippedArmor.getName.Equals("Very_Skimpy_Clothes") Then
            p.equippedArmor.onUnequip()
            p.equippedArmor = New SkimpyClothes
        Else
            Dim equippedArmorIndex = p.equippedArmor.id
            Dim antiSlutVarIndex = p.equippedArmor.antiSlutVarInd
            p.inv.add(equippedArmorIndex, -1)
            p.inv.add(antiSlutVarIndex, 1)
            clothesChange(p.inv.item(antiSlutVarIndex).getAName)
        End If

        Game.pushLstLog("Your curse changes your clothes.")
        If Not Game.lblEvent.Visible Then Game.pushLblEvent("Suddenly, something seems off.  You look down to see a golden glow beginning to form on your outfit.  You pop off your top, mesmerised by the shimmering light that seems to be getting brighter by the second.  As the light becomes blinding, your top seems to be gaining mass and you drop it to cover your eyes.  Peeking out a few seconds later, you see that your gear is no longer glowing, and pick it back up.  As far as you can tell, it looks the same as it always had, and annoyed at yourself for getting sidetracked, you set back out on your adventure.")
        Return True
    End Function
    'clothesChange handles the equipping and unequipping of armors
    Public Sub clothesChange(ByVal clothes As String)
        If aList.Count < 1 Then init()
        If Not p.equippedArmor Is Nothing AndAlso clothes.Equals(p.equippedArmor.getName) Then Exit Sub
        Dim sArmor As Armor = Nothing
        If clothes <> "" Then
            For Each k In aList.Keys
                If clothes.Equals(k) Then
                    'MsgBox("{" & cmbobxArmor.SelectedItem & "}&[") ' & aNameList(i) & "]")
                    sArmor = aList(k)
                    If Not p.equippedArmor Is Nothing Then p.equippedArmor.onUnequip()
                    Exit For
                End If
            Next
            If sArmor Is Nothing Then Exit Sub
            p.equippedArmor = sArmor
            cmbobxArmor.Text = clothes
            p.equippedArmor.onEquip()
        End If
    End Sub
    'clothesChange handles the equipping and unequipping of weapon
    Public Sub weaponChange(ByVal weapon As String)
        If wList.Count < 1 Then init()
        Dim sWeapon As Weapon = Nothing
        If Not p.equippedWeapon Is Nothing AndAlso weapon.Equals(p.equippedWeapon.getName) Then Exit Sub
        If weapon <> "" Then
            For Each k In wList.Keys
                If weapon.Split()(0).Equals(k) Then
                    sWeapon = wList(k)
                    If Not p.equippedWeapon Is Nothing Then p.equippedWeapon.onUnequip()
                    Exit For
                End If
            Next
            If sWeapon Is Nothing Then Exit Sub
            p.equippedWeapon = sWeapon
            p.equippedWeapon.onEquip()
            If p.perks("amazon") > -15 Then PerkEffects.amazon()
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
    Public Sub setP(ByRef ply As Player)
        p = ply
    End Sub
End Class