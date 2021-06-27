Public Class PhaseDrill
    Inherits Weapon

    Sub New()
        '|ID Info|
        setName("Phase_Drill")
        id = 276
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False

        '|Stats|
        MyBase.a_boost = 15
        count = 0
        value = 5990

        '|Description|
        setDesc("An angular chrome-plated drill that converts the meager energy contained in an AAAAAA Battery into a focused impact.  Batteries not included." & DDUtils.RNRN &
                       "If powered, ignores target's defense" &
                       "If powered, can cut through walls" &
                       getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 7) + 1

        dmg += (p.getATK)

        If p.inv.getCountAt("AAAAAA_Battery") < 1 Then
            Return Player.calcDamage(dmg, m.getDEF)
        Else
            p.inv.add("AAAAAA_Battery", -1)
            Game.pushLogAndEvent("The back casing of the drill ejects a smoldering battery shell.  " & p.inv.getCountAt("AAAAAA_Battery") & " batteries left!")
        End If

        dmg += (getABoost(p))

        Return Player.calcDamage(dmg, 0)
    End Function

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        p.perks(perk.pdrill) = 1
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player, ByRef w As Weapon)
        MyBase.onUnequip(p, w)

        p.perks(perk.pdrill) = -1
    End Sub
End Class
