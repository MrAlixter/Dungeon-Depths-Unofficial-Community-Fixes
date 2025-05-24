Public Class MesThrall
    Inherits Monster

    Public Const BASE_NAME As String = "Mesmerized Thrall"

    Sub New()
        '|ID Info|
        name = BASE_NAME

        '|Stats|
        maxHealth = 85
        attack = 20
        defense = 7
        speed = 9
        will = 5

        '|Inventory|
        setInventory({0, 13})

        '|Dialog Variables|

        '|Misc|
        setupMonsterOnSpawn()
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")

        '| - Cases where the player should not be collared - |
        If p.formName.Equals("Blowup Doll") Or p.formName.Equals("Cake") Or p.formName.Equals("Frog") Or p.formName.Equals("Horse") Or p.formName.Equals("Unicorn") Or p.formName.Equals("Cow") Then
            TextEvent.push("Your enemy sees your pitiful state and leaves you be, deciding that you aren't useful to " & p_pronoun & " master...")
            Exit Sub
        End If

        If p.className.Equals("Thrall") Or p.equippedAcce.getCursed(p) Then
            TextEvent.push("Despite your fatigue, you are able to roll out of the way of the hostile thrall's grasp...")
            Exit Sub
        End If

        If p.passDieRoll(8, 5) Then
            TextEvent.push("You collapse to the ground defeated, as the thrall pulls a metal collar from a loop on its belt." & DDUtils.RNRN &
                           "With the last of your strength, you raise a feeble arm as they lurch towards you with the collar outstretched.  You avert your eyes from the thrall; as its murmurs of submission are cut off by a sharp click." & DDUtils.RNRN &
                           "SNAP!" & DDUtils.RNRN &
                           "The thrall wanders off, happy to have brought another into its master's fold.", AddressOf thrallFleeP2)
            Exit Sub
        End If

        '| - Main player death case - |
        p.inv.add(ThrallCollar.ITEM_NAME, 1)
        EquipmentDialogBackend.equipAcce(p, ThrallCollar.ITEM_NAME)

        p.health = 1.0
        p.mana = p.getMaxMana()
        p.will -= 3
        p.UIupdate()

        TextEvent.pushLog("The thrall snaps a collar around your neck, enslaving you to " & p_pronoun & " master's will!  -3 WIL.")
        TextEvent.push("You collapse to the ground defeated, as the thrall pulls a metal collar from a loop on its belt." & DDUtils.RNRN &
                       "Lacking any strength to resist, you lie powerless as they snap it around your neck whilst murmuring the joys of submission into your ear.  Once the collar is fitted properly, a small array of runes blazes with violet energy." & DDUtils.RNRN &
                       "SNAP!" & DDUtils.RNRN &
                       "Your mind goes blank in an instant, and your surroundings fade away into unimportantance.", AddressOf thrallLN2)
    End Sub
    Private Sub thrallLN2()
        TextEvent.push("""LISTEN UP, NEW SLAVE!"" a new voice booms in your head," & DDUtils.RNRN &
                       """In this dungeon, there is a cluster of arcane glyph arrays scrawled into magic gemstones.  Rumor has it that one amongst them is capable of bestowing the power of a demon lord onto whomever activates it." & DDUtils.RNRN &
                       "Your sole purpose is now to find and inspect as many of these arrays as you can, and to report back to me with your findings.""" & DDUtils.RNRN &
                       "Arcs of black lightning crackle across your body, and you jolt to your feet as the voice continues," & DDUtils.RNRN &
                       """I'm sure you won't let me down, but I'm going to need to make a few changes to make you more- hmm... uniform... with the rest of my minions.""", AddressOf thrallLN3)
    End Sub
    Private Sub thrallLN3()
        Dim ptype = If(Int(Rnd() * 2) = 0, "sister", "brother")

        TextEvent.push("With a final warning not to fail them, the foreign presence exits your mind." & DDUtils.RNRN &
                       "Once again you are alone in the dungeon, aside from your new " & ptype & " and your collective task.")
    End Sub

    Private Sub thrallFleeP2()
        Game.player1.inv.add(ThrallCollar.ITEM_NAME, 1)
        Game.player1.UIupdate()

        TextEvent.push("The thrall's collar is wrapped around your wrist." & DDUtils.RNRN &
                       "Looks like this thrall wasn't a very good minion...")
    End Sub
End Class
