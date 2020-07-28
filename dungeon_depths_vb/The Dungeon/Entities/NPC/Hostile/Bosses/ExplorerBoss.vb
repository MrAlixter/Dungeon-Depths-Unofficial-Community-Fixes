Public Class ExplorerBoss
    Inherits MiniBoss

    Sub New()
        name = "Explorer"
        maxHealth = 300
        attack = 15
        defense = 15
        speed = 15
        Randomize()
        For i = 0 To 5
            Dim invInd As Integer = 8
            While Not inv.item(invInd).isRandoTFAcceptable
                invInd = Int(Rnd() * (Game.player1.inv.upperBound + 1))
            End While
            inv.add(invInd, CInt(Rnd() * 2) + 1)
        Next

        setupMonsterOnSpawn()
        xpValue = 200
    End Sub

    Public Overrides Sub die(ByRef cause As Entity)
        MyBase.die(cause)
        If MessageBox.Show("Would you like to do the Explorer's body swap?", "Body Swap?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then 'Int(Rnd() * 3) = 0 Then '
            Try
                bodySwap(Game.player1)
            Catch ex As Exception
                Game.pushLblEvent("The body swap fails!")
            End Try
        End If
    End Sub

    Public Sub bodySwap(ByRef p As Player)
        p.ongoingTFs.Add(New RandoTF())
        p.update()
        p.health = 0.1
        Game.pushLblEvent("As the explorer is defeated, they mumble some arcane poem and make a hand gesture which causes the two of you to begin glowing.  With a flash, you suddenly find yourself looking at the dungeon from a slightly different angle.  As you black out and collapse, the last thing you see is your grinning face standing over you." & vbCrLf & "The Explorer has taken your body!")
    End Sub
End Class
