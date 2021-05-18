Public Class PhaseVibrator

    Inherits Item
    Sub New()
        '|ID Info|
        setName("Phase_Vibrator")
        id = 280
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 2099

        '|Description|
        setDesc("A sleek chrome ""bullet"" that converts the power of a AAAAAA Battery into several minutes of pleasant vibration.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        If p.inv.getCountAt("AAAAAA_Battery") < 1 Then
            Game.pushLogAndEvent("You need at least one battery!")
        Else
            p.inv.add("AAAAAA_Battery", -1)
            If p.getLust > 90 Then
                p.lust = 0
                Game.pushLogAndEvent("A massive wave of pleasure washes throughout your whole body!" & DDUtils.RNRN &
                                     p.inv.getCountAt("AAAAAA_Battery") & " batteries left!")
            Else
                p.addLust(50)
                Game.pushLogAndEvent("You flush with an arousal..." & DDUtils.RNRN &
                                     p.inv.getCountAt("AAAAAA_Battery") & " batteries left!")
            End If
        End If

        p.drawPort()
    End Sub
End Class
