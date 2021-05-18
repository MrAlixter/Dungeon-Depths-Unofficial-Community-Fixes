Public Class RopeTrap
    Inherits Trap

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.rope
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        Dim n As String = Game.player1.equippedArmor.getName()
        Dim rng As Integer = Int(Rnd() * Game.currFloor.chestList.Count)

        Dim out As String = "A beam fires out of the wall to your left, striking you in the chest."

        If n <> "Ropes" Then
            If n <> "Naked" Then
                out += "  Your clothes glow a bright purple, before vanishing into the Æther, leaving you naked.  You look around frantically, before a quick check confirms that they are tucked away with your other gear."
            Else
                out += "  Since you're already naked, the beam doesn't seem to have done much."
            End If
            out += "  Shortly after, a bundle of rope drops from the ceiling, ensnaring you, and as it is pulled taut, you find yourself in a rather unique, less mobile, position."
            If Game.player1.breastSize > 5 Then
                out += "  However, the ropes are not able to contain your massive breasts, and they quickly burst apart leaving you naked."
                Equipment.equipArmor(Game.player1, "Naked", False)
                pos = New Point(-1, -1)
                Game.pushLblEvent(out)
                Exit Sub
            End If
        Else
            out += "  It doesn't seem to have done anything.  Weird..."
        End If

        Game.player1.inv.add(54, 1)

        Equipment.equipArmor(Game.player1, "Ropes", False)

        Game.player1.drawPort()
        Game.player1.savePState()
        Game.player1.UIupdate()

        Game.pushLblEvent(out)
    End Sub
End Class
