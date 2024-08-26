Public Class EquipmentDialogBackend
    Public Shared armor_list As Dictionary(Of String, Armor) = New Dictionary(Of String, Armor)
    Public Shared weapon_list As Dictionary(Of String, Weapon) = New Dictionary(Of String, Weapon)
    Public Shared accessory_list As Dictionary(Of String, Accessory) = New Dictionary(Of String, Accessory)
    Public Shared glasses_list As Dictionary(Of String, Glasses) = New Dictionary(Of String, Glasses)

    Private Shared sArmor As String = "N/a"
    Private Shared sAccessory As String = "N/a"
    Private Shared sGlasses As String = "N/a"

    Private Shared skipInvUpdate = False

    Shared Sub New()
        Refresh()
    End Sub
    Shared Sub Refresh()
        init()
    End Sub
    Private Shared Sub init()
        Dim p = Game.player1
        Dim a As Tuple(Of String(), Armor())
        Dim w As Tuple(Of String(), Weapon())
        Dim ac As Tuple(Of String(), Accessory())
        Dim g As Tuple(Of String(), Glasses())

        a = p.inv.getArmors
        w = p.inv.getWeapons
        ac = p.inv.getAccesories
        g = p.inv.getGlasses

        armor_list.Clear()
        weapon_list.Clear()
        accessory_list.Clear()
        glasses_list.Clear()

        For i = 0 To UBound(a.Item1)
            armor_list.Add(a.Item1(i), a.Item2(i))
        Next

        For i = 0 To UBound(w.Item1)
            weapon_list.Add(w.Item1(i), w.Item2(i))
        Next

        For i = 0 To UBound(ac.Item1)
            accessory_list.Add(ac.Item1(i), ac.Item2(i))
        Next

        For i = 0 To UBound(g.Item1)
            glasses_list.Add(g.Item1(i), g.Item2(i))
        Next
    End Sub

    '| - To/From Dialog Handlers - |
    Public Shared Sub showEquipDialog(ByRef p As Player)
        init()

        skipInvUpdate = True

        sArmor = p.equippedArmor.getAName
        sAccessory = p.equippedAcce.getAName
        sGlasses = p.equippedGlasses.getAName

        Game.cboxArmor.Items.Clear()
        Game.cboxWeapon.Items.Clear()
        Game.cboxAccessory.Items.Clear()
        Game.cboxGlasses.Items.Clear()

        'adds the default clothes for various forms
        Game.cboxArmor.Items.Add("Naked")
        defaultArmorOptions(Game.cboxArmor.Items)

        'adds the default weapon (fists)
        Game.cboxWeapon.Items.Add("Fists")

        'adds the default accessory (nothing)
        Game.cboxAccessory.Items.Add("Nothing")

        'adds the default glasses (nothing)
        Game.cboxGlasses.Items.Add("Nothing")

        'adds all armors, weapons, and accessories that the player posesses to their respective menus
        For Each item In armor_list.Values
            If item.count > 0 Then Game.cboxArmor.Items.Add(item.getName())
        Next
        For Each item In weapon_list.Values
            If item.count > 0 Then Game.cboxWeapon.Items.Add(item.getName())
        Next
        For Each item In accessory_list.Values
            If item.count > 0 Then Game.cboxAccessory.Items.Add(item.getName())
        Next
        For Each item In glasses_list.Values
            If item.count > 0 Then Game.cboxGlasses.Items.Add(item.getName())
        Next

        'sets the text of the drop-downs to the player's equipment
        Game.cboxWeapon.SelectedItem = p.equippedWeapon.getName()
        Game.cboxArmor.SelectedItem = p.equippedArmor.getName()
        Game.cboxAccessory.SelectedItem = p.equippedAcce.getName()
        Game.cboxGlasses.SelectedItem = p.equippedGlasses.getName()

        'scale label size
        Game.lblEquippedArmor.Font = New Font(Game.lblEquippedArmor.Font.Name, 9)
        Game.lblEquippedWeapon.Font = New Font(Game.lblEquippedWeapon.Font.Name, 9)
        Game.lblEquippedAccessory.Font = New Font(Game.lblEquippedAccessory.Font.Name, 9)
        Game.lblEquippedGlasses.Font = New Font(Game.lblEquippedGlasses.Font.Name, 9)

        'make the equipment dialog visible, stick it in the right spot
        Game.cleanupPanels()
        p.canMoveFlag = False

        drawImg(p)
        Game.pnlEquip.Location = New Point(250, Game.pnlEquip.Location.Y)
        Game.pnlEquip.Visible = True
        Game.pnlEquip.BringToFront()

        If p.perks(perk.hidehat) < 0 Then
            Game.chkShowHat.Checked = True
        Else
            Game.chkShowHat.Checked = False
        End If

        skipInvUpdate = False
    End Sub
    Public Shared Sub fromEquipDialog(ByRef p As Player)
        'hide the equipment dialog box
        Game.pnlEquip.Visible = False

        'draw the player's portrait
        p.UIupdate()
        p.drawPort()

        p.canMoveFlag = True
    End Sub

    ' - Image Handler - |
    Public Shared Sub drawImg(ByRef p As Player)
        Dim pImg = p.prt.oneLayerImgCheck(p.formName, p.className)

        If p.prt.oneLayerImgCheck(p.formName, p.className) Is Nothing Then
            pImg = p.prt.drawFull
        End If

        Game.picEquipPort.BackgroundImage = pImg
    End Sub
    Public Shared Sub changeCBoxIndex(ByRef p As Player)
        If String.IsNullOrEmpty(Game.cboxArmor.SelectedItem) Or String.IsNullOrEmpty(Game.cboxAccessory.SelectedItem) Or String.IsNullOrEmpty(Game.cboxGlasses.SelectedItem) Or skipInvUpdate Then Exit Sub

        If sArmor.Equals("N/a") Then sArmor = p.equippedArmor.getAName
        If sAccessory.Equals("N/a") Then sAccessory = p.equippedAcce.getAName
        If sGlasses.Equals("N/a") Then sGlasses = p.equippedGlasses.getAName

        armorChange(p, Game.cboxArmor.SelectedItem, False)
        accessoryChange(p, Game.cboxAccessory.SelectedItem, False)
        glassesChange(p, Game.cboxGlasses.SelectedItem, False)

        p.prt.portraitUDate()
        drawImg(p)
        p.UIupdate()
    End Sub

    '| - Button Handlers - |
    Public Shared Sub btnEquipConfirmOnClick(ByRef p As Player, sender As Object, e As EventArgs)
        armorChange(p, sArmor, False)
        accessoryChange(p, sAccessory, False)
        glassesChange(p, sGlasses, False)

        Dim needsToUpdate As Boolean = False

        'equip the new equipment
        needsToUpdate = equipArmor(p, Game.cboxArmor.Text)
        needsToUpdate = needsToUpdate Or equipWeapon(p, Game.cboxWeapon.Text)
        needsToUpdate = needsToUpdate Or equipAcce(p, Game.cboxAccessory.Text)
        needsToUpdate = needsToUpdate Or equipGlasses(p, Game.cboxGlasses.Text)

        'updates the player, the stat display, and the portrait before the form closes
        p.drawPort()
        p.UIupdate()

        'update the pnlDescription image too, if necessary
        If Game.pnlDescription.Visible Then
            Game.picDescPort.BackgroundImage = Portrait.CreateFullBodyBMP(p.prt.iArr)
        End If

        fromEquipDialog(p)
    End Sub
    Public Shared Sub btnEquipCancelOnClick(ByRef p As Player, sender As Object, e As EventArgs)
        armorChange(p, sArmor, False)
        accessoryChange(p, sAccessory, False)
        glassesChange(p, sGlasses, False)

        fromEquipDialog(p)
    End Sub

    '| - Default Armor Options - |
    Public Shared Sub defaultArmorOptions(ByRef options As ComboBox.ObjectCollection)
        Dim p = Game.player1

        'These armors are availible for the player when specific conditions are met (regardless of whether they are in the inventory)
        If p.formName = "Slime" Then
            options.Add("Gelatinous_Shell")
        ElseIf p.formName = "Goo Girl" Then
            options.Add("Gelatinous_Negligee")
        End If
    End Sub
    Public Shared Sub defaultArmorOptions(ByRef options As List(Of String))
        Dim p = Game.player1

        'These armors are availible for the player when specific conditions are met (regardless of whether they are in the inventory)
        If p.formName = "Slime" Then
            options.Add("Gelatinous_Shell")
        ElseIf p.formName = "Goo Girl" Then
            options.Add("Gelatinous_Negligee")
        End If
    End Sub

    '| - Clothing Curses - |
    Public Shared Function clothingCurse(ByRef p As Player, Optional ByVal push_text As Boolean = True) As Boolean
        'If this curse cannot be applied to the player's current armor, no action is needed
        If p.equippedArmor.getSlutVarInd = -1 Then Return False

        'Push a text dialog
        TextEvent.pushLog("Your curse twists and changes your clothing.")
        If Not Game.lblEvent.Visible And Not Game.combat_engaged And push_text Then
            If p.isUnwilling Then
                'Author Credit: Big Iron Red
                TextEvent.push("Suddenly, something seems... off..." & DDUtils.RNRN &
                               "You look down to see an aura of pink lightning beginning to crackle across the surface of your gear.  The arcs of twisting energy force you to shield your face, as the glow coming off your equipment flares bright enough blind you." & DDUtils.RNRN &
                               "The flashes of magic intensify, and your clothing seems to be getting lighter as its shape is reweaved by the whims of the curse.  With a final corrupting surge of rose electricity, the curse finishes its work and you hesitantly open your eyes again, feeling an oddly cold draft as you do so." & DDUtils.RNRN &
                               "You look down in abject horror as you find your previously protective armor has become a humiliatingly feminine facsimile of itself.  You quickly remove the outfit it's become in an attempt to somehow undo the transformation, though alas it remains the same embarrassingly useless ensemble that serves only to show the world your feminine body." & DDUtils.RNRN &
                               "Tears welling in your eyes, you slip back into what used to be your original " & If(p.equippedArmor.getAName.Contains("Armor"), "armor", "clothes") & ", feeling incredibly exposed and vulnerable. ""How will anyone take me seriously wearing this?"" you think, as you wobble unsteadily ahead, followed by the unmistakable sound of high heels clicking on the dungeon floor.")
            Else
                TextEvent.push("Suddenly, something seems... off..." & DDUtils.RNRN &
                               "You look down to see an aura of pink lightning beginning to crackle across the surface of your gear.  The arcs of twisting energy force you to shield your face, as the glow coming off your equipment flares bright enough blind you." & DDUtils.RNRN &
                               "The flashes of magic intensify, and your clothing seems to be getting lighter as its shape is reweaved by the whims of the curse.  With a final corrupting surge of rose electricity, the curse finishes its work and you hesitantly open your eyes again." & DDUtils.RNRN &
                               "You strip down and inspect your outfit which, as far as you can tell, seems just as skimpy as it has always been.  With a vacant smile, you get dressed again and with a twirl you set back out on your adventure.")
            End If
        ElseIf Game.combat_engaged And push_text Then
            TextEvent.push("Arcs of blinding pink lightning crackle across your body, and your clothing becomes lighter as its shape is reweaved by the whims of a curse!" & DDUtils.RNRN &
                           "Your outfit has been corrupted into a slutty perversion of its original form!")
        End If

        'Otherwise, change the player's equipped armor to the slut variant
        Dim equippedArmorIndex = p.equippedArmor.id
        Dim slut_var_index = p.equippedArmor.getSlutVarInd

        p.inv.add(equippedArmorIndex, -1)
        p.inv.add(slut_var_index, 1)

        armorChange(p, p.inv.item(slut_var_index).getAName)

        Return True
    End Function
    Public Shared Function antiClothingCurse(ByRef p As Player, Optional ByVal push_text As Boolean = True) As Boolean
        'If this curse cannot be applied to the player's current armor, no action is needed
        If p.equippedArmor.getAntiSlutInd = -1 Then Return False

        'Otherwise, revert the player's equipped armor to the non-slut variant
        Dim equippedArmorIndex = p.equippedArmor.id
        Dim anti_slut_index = p.equippedArmor.getAntiSlutInd()

        p.inv.add(equippedArmorIndex, -1)
        p.inv.add(anti_slut_index, 1)

        armorChange(p, p.inv.item(anti_slut_index).getAName)

        'Push a text dialog
        TextEvent.pushLog("The curse is lifted from your clothing.")
        If Not Game.lblEvent.Visible And Not Game.combat_engaged And push_text Then
            If Not Game.lblEvent.Visible Then TextEvent.push("Suddenly, something seems... off..." & DDUtils.RNRN &
                                                             "You look down to see a golden glow beginning to ripple across your outfit.  Mesmerized by the shimmering light, you strip off your clothes as their aura becomes brighter and brighter." & DDUtils.RNRN &
                                                             "As the glow becomes blinding, your gear gains mass and you shield your eyes as it twists and morphs.  A few seconds later, you peek out to find that the glow has died down and your " & DDUtils.amrOrClth(p) & "... looks the same as it always had." & DDUtils.RNRN &
                                                             "Annoyed at yourself for getting sidetracked by nothing, you re-equip the " & p.equippedArmor.getAName.Replace("_", " ") & " and set back out on your adventure.")
        ElseIf Game.combat_engaged And push_text Then
            TextEvent.push("A blinding golden glow ripples across your body, and your outfit gains mass as its shape is restored to a more practical arrangement!" & DDUtils.RNRN &
                           "Your " & If(p.equippedArmor.getAName.Contains("Armor"), "armor", "clothes") & " has been shifted into a less slutty version of itself!")
        End If

        Return True
    End Function

    '| - Equipment Change Methods - |
    Public Shared Sub armorChange(ByRef p As Player, ByVal armor As String, Optional doEquipHandlers As Boolean = True)
        'If the player is already wearing the armor, no action is needed
        If Not p.equippedArmor Is Nothing AndAlso armor.Equals(p.equippedArmor.getName) Then Exit Sub

        'Otherwise, change the player's armor to the specified item
        Dim sArmor As Armor = Nothing
        If armor <> "" Then
            For Each k In armor_list.Keys
                If armor.Equals(k) Then
                    'MsgBox("{" & cmbobxArmor.SelectedItem & "}&[") ' & aNameList(i) & "]")
                    sArmor = armor_list(k)
                    If Not p.equippedArmor Is Nothing And doEquipHandlers Then p.equippedArmor.onUnequip(p)
                    Exit For
                End If
            Next

            'If we have not changed armors, end the function early
            If sArmor Is Nothing Then Exit Sub

            'equip the specified armor
            p.equippedArmor = sArmor
            If doEquipHandlers Then p.equippedArmor.onEquip(p)
        End If
    End Sub
    Public Shared Sub weaponChange(ByRef p As Player, ByVal weapon As String, Optional doEquipHandlers As Boolean = True)
        'If the player is already wearing the weapon, no action is needed
        If Not p.equippedWeapon Is Nothing AndAlso weapon.Equals(p.equippedWeapon.getName) Then Exit Sub

        'Otherwise, change the player's weapon to the specified item
        Dim sWeapon As Weapon = Nothing
        If weapon <> "" Then
            For Each k In weapon_list.Keys
                If weapon.Equals(k) Then
                    'MsgBox("{" & cmbobxweapon.SelectedItem & "}&[") ' & aNameList(i) & "]")
                    sWeapon = weapon_list(k)
                    If Not p.equippedWeapon Is Nothing And doEquipHandlers Then p.equippedWeapon.onUnequip(p, sWeapon)
                    Exit For
                End If
            Next

            'If we have not changed weapons, end the function early
            If sWeapon Is Nothing Then Exit Sub

            'equip the specified weapon
            p.perks(perk.prevweapon) = p.equippedWeapon.getId
            p.equippedWeapon = sWeapon
            If doEquipHandlers Then p.equippedWeapon.onEquip(p)
            If p.perks(perk.amazon) > -15 Then PerkEffects.amazon(p)
        End If
    End Sub
    Public Shared Sub accessoryChange(ByRef p As Player, ByVal accessory As String, Optional doEquipHandlers As Boolean = True)
        'If the player is already wearing the accessory, no action is needed
        If Not p.equippedAcce Is Nothing AndAlso accessory.Equals(p.equippedAcce.getName) Then Exit Sub

        'Otherwise, change the player's accessory to the specified item
        Dim sAccessory As Accessory = Nothing
        If accessory <> "" Then
            For Each k In accessory_list.Keys
                If accessory.Equals(k) Then
                    'MsgBox("{" & cmbobxaccessory.SelectedItem & "}&[") ' & aNameList(i) & "]")
                    sAccessory = accessory_list(k)
                    'MsgBox(doEquipHandlers & DDUtils.RNRN & accessory)
                    If Not p.equippedAcce Is Nothing And doEquipHandlers Then p.equippedAcce.onUnequip(p)
                    Exit For
                End If
            Next

            'If we have not changed accessories, end the function early
            If sAccessory Is Nothing Then Exit Sub

            'equip the specified accessory
            p.equippedAcce = sAccessory
            If doEquipHandlers Then p.equippedAcce.onEquip(p)
        End If
    End Sub
    Public Shared Sub glassesChange(ByRef p As Player, ByVal glasses As String, Optional doEquipHandlers As Boolean = True)
        'If the player is already wearing the glasses, no action is needed
        If Not p.equippedGlasses Is Nothing AndAlso glasses.Equals(p.equippedGlasses.getName) Then Exit Sub

        'Otherwise, change the player's glasses to the specified item
        Dim sGlasses As Glasses = Nothing
        If glasses <> "" Then
            For Each k In glasses_list.Keys
                If glasses.Equals(k) Then
                    'MsgBox("{" & cmbobxglasses.SelectedItem & "}&[") ' & aNameList(i) & "]")
                    sGlasses = glasses_list(k)
                    If Not p.equippedGlasses Is Nothing And doEquipHandlers Then p.equippedGlasses.onUnequip(p)
                    Exit For
                End If
            Next

            'If we have not changed accessories, end the function early
            If sGlasses Is Nothing Then Exit Sub

            'equip the specified glasses
            p.equippedGlasses = sGlasses
            If doEquipHandlers Then p.equippedGlasses.onEquip(p)
        End If
    End Sub

    Public Shared Function equipArmor(ByRef p As Player, ByVal armor As String, Optional ByVal considerCurse As Boolean = True) As Boolean
        If Not p.inv.getArmors.Item1.Contains(armor) Then Return False

        'if clothes offer resistance on the way off, this handles that
        If (Not p.equippedArmor.getName.Equals(armor) And p.equippedArmor.getCursed(p)) And considerCurse Then
            If p.inv.item("Anti_Curse_Tag").count > 0 Then
                TextEvent.push("You apply a tag to your clothes, allowing you to remove them.")
                p.inv.add("Anti_Curse_Tag", -1)
                p.inv.invNeedsUDate = True
            Else
                TextEvent.push("Despite a struggle agaisnt your clothes, you are unable to escape!")
                Return False
            End If
        End If

        'handles any tfs or triggers triggered by equipping of certain armors by certain classes
        If (p.className.Equals("Magical Girl") And p.perks(perk.tfedbyweapon) > 0) AndAlso Not (armor.Contains("Outfit") And armor.Contains("Mag")) AndAlso p.equippedArmor.fits(p) Then
            TextEvent.pushLog("A magical girl needs her uniform!")
            TextEvent.push("A magical girl needs her uniform!")
            Return False
        End If
        If (p.className.Contains("Valkyrie") And p.perks(perk.tfedbyweapon) > 0) AndAlso Not armor.Contains("Valkyrie_Armor") AndAlso p.equippedArmor.fits(p) Then
            TextEvent.pushLog("Your armor magically re-equips!")
            TextEvent.push("Your armor magically re-equips!")
            Return False
        End If

        'unequip the old armor
        If p.equippedArmor.getName.Equals(armor) Then Return False

        'equip the new armor
        armorChange(p, armor)
        If p.equippedArmor.m_boost > 0 Then p.mana += p.equippedArmor.m_boost
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana

        'if the player has the slut curse, this takes care of it
        If p.perks(perk.slutcurse) > -1 AndAlso Not p.equippedArmor.is_sexy Then
            clothingCurse(p)
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
        If (Not p.equippedWeapon.getName.Equals(weapon) And p.equippedWeapon.getCursed(p)) And considerCurse Then
            If p.inv.item("Anti_Curse_Tag").count > 0 Then
                TextEvent.push("You sheath your weapon, despite the resistance it puts up.")
                p.inv.add("Anti_Curse_Tag", -1)
                p.inv.invNeedsUDate = True
            Else
                TextEvent.push("Despite a struggle agaisnt your weapon, you are unable to put it away!")
                Return False
            End If
        End If


        'unequip the old weapon
        If p.equippedWeapon.getName.Equals(weapon) Then Return False

        'handles the equiping of weapons
        weaponChange(p, weapon)
        If p.equippedWeapon.m_boost > 0 Then p.mana += p.equippedWeapon.m_boost
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana

        Return True
    End Function
    Public Shared Function equipLastWeapon(ByRef p As Player, Optional ByVal considerCurse As Boolean = True) As Boolean
        Dim last_weapon As Item = p.inv.item(CInt(p.perks(perk.prevweapon)))

        If p.inv.getCountAt(last_weapon.getName) < 1 Then last_weapon = New BareFists

        Return equipWeapon(p, last_weapon.getAName(), considerCurse)
    End Function
    Public Shared Function equipAcce(ByRef p As Player, ByVal acce As String, Optional ByVal considerCurse As Boolean = True) As Boolean
        'if clothes offer resistance on the way off, this handles that
        If (Not p.equippedAcce.getName.Equals(acce) And p.equippedAcce.getCursed(p)) And considerCurse Then
            If p.inv.item("Anti_Curse_Tag").count > 0 Then
                TextEvent.push("You take off your accessory, despite the resistance it puts up.")
                p.inv.add("Anti_Curse_Tag", -1)
                p.inv.invNeedsUDate = True
            Else
                TextEvent.push("Despite a struggle agaisnt your accessory, you are unable to take it off!")
                Return False
            End If
        End If

        accessoryChange(p, acce)
        If p.equippedAcce.getMBoost(p) > 0 Then p.mana += p.equippedAcce.getMBoost(p)
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana

        Return True
    End Function
    Public Shared Function equipGlasses(ByRef p As Player, ByVal glasses As String, Optional ByVal considerCurse As Boolean = True) As Boolean
        'if clothes offer resistance on the way off, this handles that
        If (Not p.equippedGlasses.getName.Equals(glasses) And p.equippedGlasses.getCursed(p)) And considerCurse Then
            If p.inv.item("Anti_Curse_Tag").count > 0 Then
                TextEvent.push("You take off your glasses, despite the resistance they put up.")
                p.inv.add("Anti_Curse_Tag", -1)
                p.inv.invNeedsUDate = True
            Else
                TextEvent.push("Despite a struggle agaisnt your glasses, you are unable to take them off!")
                Return False
            End If
        End If

        glassesChange(p, glasses)
        If p.equippedGlasses.getMBoost(p) > 0 Then p.mana += p.equippedGlasses.getMBoost(p)
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana

        Return True
    End Function
End Class
