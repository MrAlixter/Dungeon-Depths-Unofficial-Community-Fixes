Public Class TGMirrorTrap
    Inherits Trap

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.mirror
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        Dim out = "As your foot touches down on what looks to be the same ground that you have been walking on, you find that it is not met with any resistance.  Unable to keep your balance, you fall face first into the shiny waterlike facsimile of the floor and are thrown, flipping, into a another room.  As you regain your senses, you notice that you actually just ahead of where you were.  Turning around, you tap the floor you presumably fell out through, only to find it as solid as any other patch of floor you have come across.  Not able to find anything else abnormal with your surroundings, you write your expirience off as some failed illusion and set off on your way."

        If Game.player1.prt.sexBool Then
            Game.player1.FtM()
        Else
            Game.player1.MtF()
        End If

        Game.player1.drawPort()
        Game.player1.UIupdate()

        Game.pushLblEvent(out)
    End Sub
End Class
