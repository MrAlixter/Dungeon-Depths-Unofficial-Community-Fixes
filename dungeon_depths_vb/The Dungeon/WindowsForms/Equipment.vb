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
        Dim needsToUpdate As Boolean = False

        'equip the new equipment
        needsToUpdate = equipArmor(cboxArmor.Text)
        needsToUpdate = needsToUpdate Or equipWeapon(cboxWeapon.Text)
        needsToUpdate = needsToUpdate Or equipAcce(cboxAccessory.Text)

        'updates the player, the stat display, and the portrait before the form closes
        p.drawPort()
        p.UIupdate()

        Me.Close()
    End Sub
    Public Shared Function equipArmor(ByVal armor As String) As Boolean
        Dim p = Game.player

        'if clothes offer resistance on the way off, this handles that
        If (Not p.equippedArmor.getName.Equals(armor) And p.equippedArmor.isCursed) Then
            If p.inv.item("Anti_Curse_Tag").count > 0 Then
                Game.pushLblEvent("You apply a tag to your clothes, allowing you to remove them.")
                p.inv.add("Anti_Curse_Tag", -1)
            Else
                Game.pushLblEvent("Despite a struggle agaisnt your clothes, you are unable to escape!")
                Return False
            End If
        End If

        'unequip the old armor
        If Not p.equippedArmor.getName.Equals(armor) Then
            p.equippedArmor.onUnequip()
        Else
            Return False
        End If

        'equip the new armor
        Equipment.clothesChange(armor)
        If p.equippedArmor.mBoost > 0 Then p.mana += p.equippedArmor.mBoost
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana

        'if the player has the slut curse, this takes care of it
        If p.perks("slutcurse") > -1 Then
            Equipment.clothingCurse1()
        End If

        'handles any tfs or triggers triggered by equipping of certain armors by certain classes
        If p.pClass.name.Equals("Magical Girl") And p.equippedArmor.getName.Equals("Magical_Girl_Outfit") Then
            p.equippedArmor = p.inv.item(10)
            Game.pushLstLog("A magical girl needs her uniform!")
            Game.pushLblEvent("A magical girl needs her uniform!")
        End If
        If p.pClass.name.Equals("Valkyrie") And Not p.equippedArmor.getName.Equals("Valkyrie_Armor") Then
            p.equippedArmor = p.inv.item(95)
            Game.pushLstLog("Your armor magically re-equips!")
            Game.pushLblEvent("Your armor magically re-equips!")
        End If

        If p.pForm.name.Equals("Blow-Up Doll") Then
            p.equippedArmor = New Naked
        End If

        'handles any tfs or triggers triggered by equipping of certain armors
        If p.equippedArmor.getName = "Living_Armor" And Not p.perks("livearm") > -1 Then
            p.perks("livearm") = 0
        ElseIf p.equippedArmor.getName = "Living_Lingerie" And Not p.perks("livelinge") > -1 Then
            p.perks("livelinge") = 0
        End If

        Return True
    End Function
    Public Shared Function equipWeapon(ByVal weapon As String) As Boolean
        Dim p = Game.player

        'if clothes offer resistance on the way off, this handles that
        If (Not p.equippedWeapon.getName.Equals(weapon) And p.equippedWeapon.isCursed) Then
            If p.inv.item("Anti_Curse_Tag").count > 0 Then
                Game.pushLblEvent("You sheath your weapon, despite the resistance it puts up.")
                p.inv.add("Anti_Curse_Tag", -1)
            Else
                Game.pushLblEvent("Despite a struggle agaisnt your weapon, you are unable to put it away!")
                Return False
            End If
        End If


        'unequip the old weapon
        If Not p.equippedWeapon.getName.Equals(weapon) Then
            p.equippedWeapon.onUnequip()
        Else
            Return False
        End If

        'this handles the revert from the magical girl form, if needed
        If p.equippedWeapon.getName.Equals("Magical_Girl_Wand") And p.pClass.name.Equals("Magical Girl") And Not weapon.Equals("Magical_Girl_Wand") Then
            Game.pushLstLog("Putting away your wand causes you to change into your regular self!")
            p.inv.add(10, -1)
            p.magGState.save(p)
            p.revertToPState()
        ElseIf p.equippedWeapon.getName.Equals("Valkyrie_Sword") And p.pClass.name.Equals("Valkyrie") And Not weapon.Equals("Valkyrie_Sword") Then
            Game.pushLstLog("Putting away your sword causes you to change into your regular self!")
            p.inv.add(95, -1)
            p.revertToPState()
        End If

        'handles the equiping of weapons
        Equipment.weaponChange(weapon)
        If p.equippedWeapon.mBoost > 0 Then p.mana += p.equippedWeapon.mBoost
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana

        Return True
    End Function
    Public Shared Function equipAcce(ByVal acce As String) As Boolean
        Dim p = Game.player

        'if clothes offer resistance on the way off, this handles that
        If (Not p.equippedAcce.getName.Equals(acce) And p.equippedAcce.isCursed) Then
            If p.inv.item("Anti_Curse_Tag").count > 0 Then
                Game.pushLblEvent("You take off your accessory, despite the resistance it puts up.")
                p.inv.add("Anti_Curse_Tag", -1)
            Else
                Game.pushLblEvent("Despite a struggle agaisnt your accessory, you are unable to take it off!")
                Return False
            End If
        End If

        Equipment.accChange(acce)
        If p.equippedAcce.mBoost > 0 Then p.mana += p.equippedAcce.mBoost
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana

        Return True
    End Function
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
        cboxArmor.Items.Add("Naked")
        defaultClothesOptions(cboxArmor.Items)

        'adds the default weapon (fists)
        cboxWeapon.Items.Add("Fists")

        'adds the default accessory (nothing)
        cboxAccessory.Items.Add("Nothing")

        'adds all weapons and armors that the player posesses to their respective menus
        For Each v In aList.Values
            If v.count > 0 Then cboxArmor.Items.Add(v.getName())
        Next
        For Each v In wList.Values
            If v.count > 0 Then cboxWeapon.Items.Add(v.getName())
        Next
        For Each v In acList.Values
            If v.count > 0 Then cboxAccessory.Items.Add(v.getName())
        Next

        'sets the text of the drop-downs to the player's equipment
        cboxWeapon.SelectedItem = p.equippedWeapon.getName()
        cboxArmor.SelectedItem = p.equippedArmor.getName()
        cboxAccessory.SelectedItem = p.equippedAcce.getName()
    End Sub
    Sub defaultClothesOptions(ByVal options As ComboBox.ObjectCollection)
        If p.pClass.name = "Bimbo" Or p.perks("slutcurse") > -1 Or p.equippedArmor.getName.Equals("Skimpy_Clothes") Then
            options.Add("Skimpy_Clothes")
        ElseIf (p.perks("slutcurse") > -1 And p.equippedArmor.getName.Equals("Skimpy_Clothes")) Or p.equippedArmor.getName.Equals("Very_Skimpy_Clothes") Then
            options.Add("Very_Skimpy_Clothes")
        ElseIf p.pClass.name = "Princess" Then
            options.Add("Regal_Gown")
        ElseIf p.pClass.name = "Maid" Then
            options.Add("Maid_Outfit")
        ElseIf p.pForm.name = "Succubus" Or p.pForm.name = "Half-Succubus" Then
            options.Add("Succubus_Garb")
        ElseIf p.pForm.name = "Slime" Then
            options.Add("Gelatinous_Shell")
        ElseIf p.pForm.name = "Goo Girl" Then
            options.Add("Gelatinous_Negligee")
        ElseIf p.pClass.name = "Goddess" Then
            options.Add("Goddess_Gown")
        Else
            options.Add("Common_Clothes")
        End If
    End Sub
    Sub defaultClothesOptionsAlt(ByVal options As ListBox.ObjectCollection)
        If p.pClass.name = "Bimbo" Or p.perks("slutcurse") > -1 Or p.equippedArmor.getName.Equals("Skimpy_Clothes") Then
            options.Add("b - Skimpy_Clothes")
        ElseIf (p.perks("slutcurse") > -1 And p.equippedArmor.getName.Equals("Skimpy_Clothes")) Or p.equippedArmor.getName.Equals("Very_Skimpy_Clothes") Then
            options.Add("b - Very_Skimpy_Clothes")
        ElseIf p.pClass.name = "Princess" Then
            options.Add("b - Regal_Gown")
        ElseIf p.pClass.name = "Maid" Then
            options.Add("b - Maid_Outfit")
        ElseIf p.pForm.name = "Succubus" Or p.pForm.name = "Half-Succubus" Then
            options.Add("b - Succubus_Garb")
        ElseIf p.pForm.name = "Slime" Then
            options.Add("b - Gelatinous_Shell")
        ElseIf p.pForm.name = "Goo Girl" Then
            options.Add("b - Gelatinous_Negligee")
        ElseIf p.pClass.name = "Goddess" Then
            options.Add("b - Goddess_Gown")
        Else
            options.Add("b - Common_Clothes")
        End If
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
            cboxArmor.Text = clothes
            p.equippedArmor.onEquip()
        End If

        'ring of the love goddess stat changes
        If p.perks("rotlg") > -1 Then
            PerkEffects.ROTLGRoute()
        End If
        'bowtie stat changes
        If p.perks("bowtie") > -1 Then
            PerkEffects.BowTieRoute()
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