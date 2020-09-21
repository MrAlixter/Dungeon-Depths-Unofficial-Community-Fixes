Public Class EnthSorc
    Inherits Monster
    Sub New()
        Dim rng = Int(Rnd() * 2)
        If rng = 0 Then
            name = "Enthralling Sorcerer"
        Else
            name = "Enthralling Sorceress"
        End If
        maxHealth = 150
        attack = 40
        defense = 17
        speed = 20
        will = 15
        setInventory({4, 13})
        setupMonsterOnSpawn()
        xpValue = 25
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        If p.formName.Equals("Blowup Doll") Then
            despawn("p-death")
            Game.pushLblEvent("Your enemy, seeing your current state, decides that you likely aren't useful and leaves you alone.")
            Exit Sub
        End If
        Dim out As String = ""
        If p.className.Equals("Thrall") Then
            out = "Despite your fatigue, you are able to roll out of the way of the mage's attempt to restrain you, and make a clumsy escape."

        Else
            out = """Wonderful!"", your opponent exclaims as you collapse, ""You'll make a perfect thrall!""" & vbCrLf & _
                  "𝘛𝘩𝘳𝘢𝘭𝘭!? you think moments before a small metal collar finds its way around your neck and a network of runes inscribed on it begin glowing with your new master's magic.  𝘞𝘢𝘪𝘵 ... 𝘕𝘦𝘸 𝘔𝘈𝘚𝘛𝘌𝘙?!  You don't have a momment to rest before your mind is filled with a booming voice." & vbCrLf & _
                  """LISTEN UP, NEW SLAVE!  I have need of your services."" your new master begins, ""In this dungeon, there are several high-power mana arrays.  Only one of them, however, is capable of bestowing the power of a demon lord onto a mortal such as I.  Your task is to find and inspect these arrays, and report back to me with your findings.""  They snicker,  ""I'm sure you won't let me down, but I'm going to need to make a few changes to make you more ... uniform ... with the rest of your collegues.""" & DDUtils.RNRN & "...       " & DDUtils.RNRN & "With a final warning not to fail them, the foreign presence leaves your mind and you are once again alone with your thoughts and your task."
            p.inv.add(69, 1)
            If Not p.equippedAcce.getName.Equals("Nothing") Then p.equippedAcce.onUnequip(p)
            p.equippedAcce = p.inv.item(69)
            p.equippedAcce.onEquip(p)
            p.health = 1
            p.mana = p.getMaxMana()
            p.prefForm.snapShift(p)
            Game.player1.will -= 3
            If Game.player1.will < 1 Then Game.player1.will = 0
        End If
        If Not p.currTarget Is Nothing Then despawn("p-death")
        Game.pushLblEvent(out)
    End Sub
End Class
