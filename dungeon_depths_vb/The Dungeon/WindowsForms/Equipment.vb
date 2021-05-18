Public Class Equipment
    'Form3 is the form that handles the equiping of armor and weapons

    'instance variables for Form3
    'armor
    Public aList As Dictionary(Of String, Armor) = New Dictionary(Of String, Armor)
    'weapons
    Public wList As Dictionary(Of String, Weapon) = New Dictionary(Of String, Weapon)
    'accessories
    Public acList As Dictionary(Of String, Accessory) = New Dictionary(Of String, Accessory)

    'init triggers an initialion Form3's global variables 
    Public Sub init()
        Dim p = Game.player1
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
        Dim p = Game.player1
        Dim needsToUpdate As Boolean = False

        'equip the new equipment
        needsToUpdate = equipArmor(p, cboxArmor.Text)
        needsToUpdate = needsToUpdate Or equipWeapon(p, cboxWeapon.Text)
        needsToUpdate = needsToUpdate Or equipAcce(p, cboxAccessory.Text)

        'updates the player, the stat display, and the portrait before the form closes
        p.drawPort()
        p.UIupdate()

        'update the pnlDescription image too, if necessary
        If Game.pnlDescription.Visible Then
            Game.picDescPort.BackgroundImage = Portrait.CreateFullBodyBMP(p.prt.iArr)
        End If

        Me.Close()
    End Sub
    Public Shared Function equipArmor(ByRef p As Player, ByVal armor As String, Optional ByVal considerCurse As Boolean = True) As Boolean
        If Not p.inv.getArmors.Item1.Contains(armor) Then Return False

        'if clothes offer resistance on the way off, this handles that
        If (Not p.equippedArmor.getName.Equals(armor) And p.equippedArmor.cursed) And considerCurse Then
            If p.inv.item("Anti_Curse_Tag").count > 0 Then
                Game.pushLblEvent("You apply a tag to your clothes, allowing you to remove them.")
                p.inv.add("Anti_Curse_Tag", -1)
            Else
                Game.pushLblEvent("Despite a struggle agaisnt your clothes, you are unable to escape!")
                Return False
            End If
        End If

        'handles any tfs or triggers triggered by equipping of certain armors by certain classes
        If (p.className.Equals("Magical Girl") And p.perks(perk.tfedbyweapon) > 0) And Not (armor.Contains("Outfit") And armor.Contains("Mag")) And p.equippedArmor.fits(p) Then
            Game.pushLstLog("A magical girl needs her uniform!")
            Game.pushLblEvent("A magical girl needs her uniform!")
            Return False
        End If
        If (p.className.Equals("Valkyrie") And p.perks(perk.tfedbyweapon) > 0) And Not armor.Equals("Valkyrie_Armor") And p.equippedArmor.fits(p) Then
            Game.pushLstLog("Your armor magically re-equips!")
            Game.pushLblEvent("Your armor magically re-equips!")
            Return False
        End If

        'unequip the old armor
        If Not p.equippedArmor.getName.Equals(armor) Then
            p.equippedArmor.onUnequip(p)
        Else
            Return False
        End If

        'equip the new armor
        Equipment.clothesChange(p, armor)
        If p.equippedArmor.m_boost > 0 Then p.mana += p.equippedArmor.m_boost
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana

        'if the player has the slut curse, this takes care of it
        If p.perks(perk.slutcurse) > -1 Then
            Equipment.clothingCurse1(p)
        End If

        If p.formName.Equals("Blow-Up Doll") Then
            p.equippedArmor = New Naked
        End If

        'handles any tfs or triggers triggered by equipping of certain armors
        If p.equippedArmor.getName = "Living_Armor" And p.perks(perk.livearm) < 0 Then
            p.perks(perk.livearm) = 1
        ElseIf p.equippedArmor.getName = "Living_Lingerie" And p.perks(perk.livelinge) < 0 Then
            p.perks(perk.livelinge) = 1
        End If

        Return True
    End Function
    Public Shared Function equipWeapon(ByRef p As Player, ByVal weapon As String, Optional ByVal considerCurse As Boolean = True) As Boolean
        If Not p.inv.getWeapons.Item1.Contains(weapon) Then Return False

        'if clothes offer resistance on the way off, this handles that
        If (Not p.equippedWeapon.getName.Equals(weapon) And p.equippedWeapon.cursed) And considerCurse Then
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
            p.equippedWeapon.onUnequip(p, Equipment.wList(weapon))
        Else
            Return False
        End If

        'handles the equiping of weapons
        Equipment.weaponChange(p, weapon)
        If p.equippedWeapon.m_boost > 0 Then p.mana += p.equippedWeapon.m_boost
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana

        Return True
    End Function
    Public Shared Function equipAcce(ByRef p As Player, ByVal acce As String, Optional ByVal considerCurse As Boolean = True) As Boolean
        'if clothes offer resistance on the way off, this handles that
        If (Not p.equippedAcce.getName.Equals(acce) And p.equippedAcce.cursed) And considerCurse Then
            If p.inv.item("Anti_Curse_Tag").count > 0 Then
                Game.pushLblEvent("You take off your accessory, despite the resistance it puts up.")
                p.inv.add("Anti_Curse_Tag", -1)
            Else
                Game.pushLblEvent("Despite a struggle agaisnt your accessory, you are unable to take it off!")
                Return False
            End If
        End If

        Equipment.accChange(p, acce)
        If p.equippedAcce.getMBoost(p) > 0 Then p.mana += p.equippedAcce.getMBoost(p)
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana

        Return True
    End Function
    'handles the loading of this form
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        init()
        Dim p = Game.player1
        DDUtils.resizeForm(Me)

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
    Sub defaultClothesOptions(ByRef options As ComboBox.ObjectCollection)
        Dim p = Game.player1

        If p.formName = "Slime" Then
            options.Add("Gelatinous_Shell")
        ElseIf p.formName = "Goo Girl" Then
            options.Add("Gelatinous_Negligee")
        End If
    End Sub
    Sub defaultClothesOptions(ByRef options As List(Of String))
        Dim p = Game.player1

        If p.formName = "Slime" Then
            options.Add("Gelatinous_Shell")
        ElseIf p.formName = "Goo Girl" Then
            options.Add("Gelatinous_Negligee")
        End If
    End Sub

    'clothingCurse1 routes the normal versions of armors to their slut forms, if they have them.
    Function clothingCurse1(ByRef p As Player) As Boolean
        If p.equippedArmor.getSlutVarInd = -1 Then Return False


        Dim equippedArmorIndex = p.equippedArmor.id
        Dim slut_var_index = p.equippedArmor.getSlutVarInd
        p.inv.add(equippedArmorIndex, -1)
        p.inv.add(slut_var_index, 1)
        clothesChange(p, p.inv.item(slut_var_index).getAName)

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
    Function antiClothingCurse(ByRef p As Player) As Boolean
        If p.equippedArmor.getAntiSlutInd = -1 Then Return False

        Dim equippedArmorIndex = p.equippedArmor.id
        Dim anti_slut_index = p.equippedArmor.getAntiSlutInd
        p.inv.add(equippedArmorIndex, -1)
        p.inv.add(anti_slut_index, 1)
        clothesChange(p, p.inv.item(anti_slut_index).getAName)

        Game.pushLstLog("Your curse changes your clothes.")
        If Not Game.lblEvent.Visible Then Game.pushLblEvent("Suddenly, something seems off.  You look down to see a golden glow beginning to form on your outfit.  You pop off your top, mesmerised by the shimmering light that seems to be getting brighter by the second.  As the light becomes blinding, your top seems to be gaining mass and you drop it to cover your eyes.  Peeking out a few seconds later, you see that your gear is no longer glowing, and pick it back up.  As far as you can tell, it looks the same as it always had, and annoyed at yourself for getting sidetracked, you set back out on your adventure.")
        Return True
    End Function
    'clothesChange handles the equipping and unequipping of armors
    Public Sub clothesChange(ByRef p As Player, ByVal clothes As String, Optional doEquipHandlers As Boolean = True)
        If aList.Count < 1 Then init()
        If Not p.equippedArmor Is Nothing AndAlso clothes.Equals(p.equippedArmor.getName) Then Exit Sub
        Dim sArmor As Armor = Nothing
        If clothes <> "" Then
            For Each k In aList.Keys
                If clothes.Equals(k) Then
                    'MsgBox("{" & cmbobxArmor.SelectedItem & "}&[") ' & aNameList(i) & "]")
                    sArmor = aList(k)
                    If Not p.equippedArmor Is Nothing And doEquipHandlers Then p.equippedArmor.onUnequip(p)
                    Exit For
                End If
            Next
            If sArmor Is Nothing Then Exit Sub
            p.equippedArmor = sArmor
            cboxArmor.Text = clothes
            If doEquipHandlers Then p.equippedArmor.onEquip(p)
        End If
    End Sub
    'clothesChange handles the equipping and unequipping of weapon
    Public Sub weaponChange(ByRef p As Player, ByVal weapon As String, Optional doEquipHandlers As Boolean = True)
        If wList.Count < 1 Then init()
        Dim sWeapon As Weapon = Nothing
        If Not p.equippedWeapon Is Nothing AndAlso weapon.Equals(p.equippedWeapon.getName) Then Exit Sub
        If weapon <> "" Then
            For Each k In wList.Keys
                If weapon.Split()(0).Equals(k) Then
                    sWeapon = wList(k)
                    If Not p.equippedWeapon Is Nothing And doEquipHandlers Then p.equippedWeapon.onUnequip(p, sWeapon)
                    Exit For
                End If
            Next
            If sWeapon Is Nothing Then Exit Sub
            p.equippedWeapon = sWeapon
            If doEquipHandlers Then p.equippedWeapon.onEquip(p)
            If p.perks(perk.amazon) > -15 Then PerkEffects.amazon(p)
        End If
    End Sub
    'accChange handles the equipping and unequipping of accessories
    Public Sub accChange(ByRef p As Player, ByVal acc As String, Optional doEquipHandlers As Boolean = True)
        If acList.Count < 1 Then init()
        If Not p.equippedAcce Is Nothing AndAlso acc.Equals(p.equippedAcce.getName) Then Exit Sub
        Dim sAcc As Accessory = Nothing
        If acc <> "" Then
            For Each k In acList.Keys
                If acc.Equals(k) Then
                    'MsgBox("{" & acList(i).getName & "}&[" & acNameList(i) & "]")
                    sAcc = acList(k)
                    If Not p.equippedAcce Is Nothing And doEquipHandlers Then p.equippedAcce.onUnequip(p)
                    Exit For
                End If
            Next
            If sAcc Is Nothing Then Exit Sub
            p.equippedAcce = sAcc
            If doEquipHandlers Then p.equippedAcce.onEquip(p)
        End If
    End Sub
End Class