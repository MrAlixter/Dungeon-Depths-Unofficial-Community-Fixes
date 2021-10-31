Public Class DartTrap
    Inherits Trap

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.dart
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        Game.player1.lust += 20
        Game.player1.health -= (2 / Game.player1.getMaxHealth)

        Dim out As String = "pwip! You smack your neck, expecting a bug, only to feel a sharp pain as your smack crushes a small dart and leaks its contents all over your neck.  Initially fearing some sort of poison, the blushing of your cheeks and "

        If Game.player1.prt.sexBool Then
            out += "warmth between your legs "
        Else
            out += "stiffening your cock "
        End If

        out += "is probably a sign that the dart was actually carrying a potent aphrodisiac."

        TextEvent.push(out)
        Game.player1.drawPort()
    End Sub
End Class
