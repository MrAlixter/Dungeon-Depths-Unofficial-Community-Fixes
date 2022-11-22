Public Class TGMirrorTrap
    Inherits Trap

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.mirror
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        If Game.player1.prt.sexBool Then
            Game.player1.FtM()
        Else
            Game.player1.MtF()
        End If

        Game.player1.drawPort()
        Game.player1.UIupdate()

        TextEvent.push("In the middle of a stride, your foot passes effortlessly through what seems to be nothing more than another part of the floor.  Unable to keep your balance, you fall face first through a shiny waterlike facsimile of your surroundings and are thrown, flipping, into a another room." & DDUtils.RNRN &
                       "As you regain your senses, you notice that you ended up just slightly ahead of where you were.  Turning around, you tap the ground you presumably fell out through, only to find it as solid as any other patch of floor you have come across." & DDUtils.RNRN &
                       "Not able to find anything else abnormal with your surroundings, you write your expirience off as some failed illusion and set off on your way.")
    End Sub
End Class
