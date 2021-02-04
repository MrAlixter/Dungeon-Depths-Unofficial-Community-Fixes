Public Class PhaseHammer
    Inherits Weapon

    Sub New()
        '|ID Info|
        MyBase.setName("Phase_Hammer")
        id = 275
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.isRandoTFAcceptable = False

        '|Stats|
        MyBase.aBoost = 69
        count = 0
        value = 3488

        '|Description|
        MyBase.setDesc("A heavy chrome-plated mallet that converts the meager energy contained in an AAAAAA Battery into a powerful impact.  Batteries not included." & DDUtils.RNRN &
                       getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 12) + 1

        If dmg <= 3 Then
            Return -1
        ElseIf dmg >= 9 Then
            Return -2
        End If

        dmg += (p.getATK)

        If p.inv.getCountAt("AAAAAA_Battery") < 1 Then
            Return Player.calcDamage(dmg, m.getDEF)
        Else
            p.inv.add("AAAAAA_Battery", -1)
            Game.pushLogAndEvent("The hammer head ejects a smoldering battery shell.  " & p.inv.getCountAt("AAAAAA_Battery") & " batteries left!")
        End If

        dmg += (getABoost(p))

        Return Player.calcDamage(dmg, m.getDEF)
    End Function
End Class
