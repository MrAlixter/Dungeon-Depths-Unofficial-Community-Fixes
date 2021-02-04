Public Class PhaseRifle
    Inherits Weapon

    Sub New()
        '|ID Info|
        MyBase.setName("Phase_Rifle")
        id = 274
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.isRandoTFAcceptable = False

        '|Stats|
        MyBase.aBoost = 100
        MyBase.sBoost = -25
        count = 0
        value = 3799

        '|Description|
        MyBase.setDesc("A slender, scoped chrome-plated weapon that converts the meager energy contained in an AAAAAA Battery into a powerful plasma blast.  Batteries not included." & DDUtils.RNRN &
                       "Scales to the user's SPD, not ATK" & DDUtils.RNRN &
                       getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        If p.inv.getCountAt("AAAAAA_Battery") < 1 Then
            Game.pushLogAndEvent("You don't have the ammo!")
            Return -1
        End If

        Dim dmg As Integer = Int(Rnd() * 12) + 1

        If dmg <= 2 Then
            Return -1
        ElseIf dmg >= 8 Then
            Return -2
        End If

        p.inv.add("AAAAAA_Battery", -1)
        Game.pushLogAndEvent("The rifle ejects a smoldering battery shell.  " & p.inv.getCountAt("AAAAAA_Battery") & " shots left!")

        dmg += (p.getSPD) + (Me.aBoost)

        Return Player.calcDamage(dmg, m.getWIL)
    End Function
End Class
