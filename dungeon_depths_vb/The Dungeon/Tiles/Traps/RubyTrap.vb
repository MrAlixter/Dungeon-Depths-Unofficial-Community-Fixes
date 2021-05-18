Public Class RubyTrap
    Inherits Trap

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.ruby
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        Dim rubyTF As Color = Color.FromArgb(185, 200, 55, 55)

        Dim r As Integer = Game.player1.prt.skincolor.R + 10
        Dim g = Game.player1.prt.skincolor.G
        Dim b = Game.player1.prt.skincolor.B
        If r > 255 Then
            r = 255
            If g > 50 Then g -= 10
            If g < 200 Then b -= 10
        End If

        Game.player1.prt.skincolor = Color.FromArgb(Game.player1.prt.skincolor.A, r, g, b)

        If Transformation.canBeTFed(Game.player1) Then
            Game.player1.pState.save(Game.player1)
        End If

        Game.player1.petrify(rubyTF, 1)

        Dim out As String = "As you walk through the dungeon, you see what looks like a valuable ruby on the ground, and you bend down to pick it up.  As soon as you touch it, a shock runs through your body, and starting with the hand you have on the gem your body is turned into ruby.  Shit!  Looks like that ruby was probably cursed..."

        Game.currFloor.statueList.Add(New Statue(Game.player1, True))

        Game.pushLblEvent(out, AddressOf rubyRevert)
        Game.player1.drawPort()
    End Sub

    Sub rubyRevert()
        Game.player1.revertToPState()

        Game.player1.canMoveFlag = True

        Game.pushLblEvent("Several days pass..." & DDUtils.RNRN &
                          "As you stand frozen in the same position you've held since you touched the cursed stone, suddenly you fall flat faced onto the ground.  Springing to your feet, you are exited to find yourself as you were, albiet redder than before, and another explorer frozen in your place.  From their pose, it seems that they were going through your stuff, and must have accidently touched you.  What's more, the original ruby you touched is nowhere to be found.  You muse on the nature of the curse for a bit, before grabbing your things and moving on." & DDUtils.RNRN &
                          "Your stomach rumbles loudly, and you can tell that your time as a statue hasn't been kind to you.")

        Game.player1.mana = 0
        Game.player1.stamina -= 60
    End Sub
End Class
