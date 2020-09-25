Public Class Mimic
    Inherits Monster
    Sub New()
        name = "Mimic"
        maxHealth = 175
        attack = 35
        defense = 20
        speed = 50
        will = 15
        setInventory({0})
        setupMonsterOnSpawn()
        xpValue = 50
    End Sub

    Public Overrides Sub playerDeath(ByRef p As Player)
        despawn("p-death")
        Dim out As String = "As you collapse, out of the corner of your eye you can see thick tendrils flowing out of the chest that could only be the body of the mimic.  Some of the tendrils wrap around your wrist and ankles, while others work their way up your thighs, aggressively groping your thighs."
        If p.equippedArmor.getName.Equals("Naked") Then
            out += "  As you black out, you can feel the tendrils writhing around you crotch.  As the darkness takes you, so does the orgasmic bliss of the mimic's magic touch."
            p.lust += 50
            p.drawPort()
            Game.pushLblEvent(out)

            Exit Sub
        End If
        out += "  As you black out, you can see the mimic working its way into your armor.  As the darkness takes you, so does the orgasmic bliss of the mimic's magic touch."
        Dim x As Integer = p.equippedArmor.getId
        p.inv.add(x, -1)
        p.inv.add(55, 1)
        p.inv.invNeedsUDate = True
        Equipment.clothesChange("Living_Armor")
        p.perks(12) = True
        p.drawPort()
        Game.pushLblEvent(out)
        p.UIupdate()
    End Sub
End Class
