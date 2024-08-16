Public Class Mimic
    Inherits Monster

    Public Const BASE_NAME As String = "Mimic"

    Dim potions_spat As Integer = 0

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 175
        attack = 35
        defense = 20
        speed = 50
        will = 15
        setupMonsterOnSpawn()

        '|Inventory|
        setInventory({443})

        '|Misc|

    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If Int(Rnd() * 6) = 0 And potions_spat < 5 And Not target.getPlayer() Is Nothing Then
            Dim potions() As Integer = {233, 193, 61, 28, 29, 234, 62, 194, 60, 25, 247, 27, 26, 26, 26, 26}
            Dim potion As MysteryPotion = target.inv.item(potions(Int(Rnd() * potions.Length)))

            TextEvent.pushAndLog("The mimic spits a " & potion.getName & " at you!")

            potion.mimicThrow(target.getPlayer)

            potions_spat += 1
        Else
            TextEvent.pushAndLog("The mimic lunges at you, chomping the lid of its chest!")
            MyBase.attackCMD(target)
        End If
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")
        Dim out As String = "You collapse to the ground, defeated.  At the corner of your fading vision, you can see thick tendrils unfurling out of the chest.  That's the body of the mimic, you realize..." & DDUtils.RNRN &
                            "Several of the tendrils wrap around your wrist and ankles, while others work their way around your body, aggressively groping your thighs." & DDUtils.RNRN & "You black out as the Mimic draws you into the chest " & r_pronoun & " inhabits, the interior far larger than you would have expected.  "

        'roll a d10, which gives results between 0 and 9
        Dim d10 As Integer = Int(Rnd() * 10)

        If d10 < 4 Then
            'for rolls 0-3, give the +lust end
            out += "As the darkness takes you, so does the orgasmic bliss of the mimic's magic touch." & DDUtils.RNRN &
                   "Some time passes, and you spring up from the floor.  The mimic is nowhere in sight, and while you can't find anything missing from your gear you do seem to be covered in a fair amount of residue..." & DDUtils.RNRN &
                   "+50 LUST"
            p.lust += 50

        ElseIf d10 = 4 Or d10 = 5 Or d10 = 6 Then
            'for rolls 4-5, give the living armor end
            out += "As the darkness takes you, so does the orgasmic bliss of the mimic's magic touch." & DDUtils.RNRN &
                   "Some time passes, and you spring up from the floor.  The mimic is nowhere in sight, although your armor seems a little more grabby than usual... and seems to have changed in design..." & DDUtils.RNRN &
                   "Living Armor equipped"
            Dim x As Integer = p.equippedArmor.getId
            p.inv.add(x, -1)
            p.inv.add("Living_Armor", 1)

            EquipmentDialogBackend.equipArmor(p, "Living_Armor", False)

            p.inv.invNeedsUDate = True

        ElseIf d10 = 7 Then
            'for roll 7, give the golden gum end
            out += "As the darkness takes you, so does the orgasmic bliss of the mimic's magic touch." & DDUtils.RNRN &
                  "Some time passes, and you spring up from the floor.  The mimic is nowhere in sight, and while you can't find anything missing from your gear you do seem to be covered in a fair amount of residue..." & DDUtils.RNRN &
                  "Yep, nothing out of the ordinary..."

            p.inv.add("Golden_Gum", 1)
            p.inv.invNeedsUDate = True

        ElseIf d10 = 8 Then
            'for roll 8, give the cursed magical girl end
            out += "As the darkness takes you, so does the orgasmic bliss of the mimic's magic touch." & DDUtils.RNRN &
                   "Some time passes, and you spring up from the floor.  The mimic is nowhere in sight... although the wand bound to your hand with a suspiciously familiar tendril might be related..." & DDUtils.RNRN &
                   "Magical Mimic Wand equipped!"

            If p.inv.getCountAt("Magical_Mimic_Wand​") < 1 Then p.inv.add("Magical_Mimic_Wand​", 1)

            Dim tf = New MagMimicTF(2, 0, 0, False)
            tf.fullTF(p)

            p.inv.invNeedsUDate = True
        ElseIf d10 = 9 Then
            'for roll 9, give the cursed cowbell end
            out += "As the darkness takes you, so does the orgasmic bliss of the mimic's magic touch." & DDUtils.RNRN &
                   "Some time passes, and you spring up from the floor.  The mimic is nowhere in sight, although it looks like the a cowbell has been fastened around your neck.  You give it a hesitant tug, and suddenly a tendril shoots out from the bell and smacking your hand." & DDUtils.RNRN &
                   "Imitation Cowbell equipped!"

            If p.inv.getCountAt("Imitation_Cowbell") < 1 Then p.inv.add("Imitation_Cowbell", 1)
            EquipmentDialogBackend.equipAcce(p, "Imitation_Cowbell", False)

            p.inv.invNeedsUDate = True
        End If

        p.drawPort()
        TextEvent.push(out)
        p.UIupdate()
    End Sub
End Class
