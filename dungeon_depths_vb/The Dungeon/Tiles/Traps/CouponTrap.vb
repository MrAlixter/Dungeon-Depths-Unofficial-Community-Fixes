Public Class CouponTrap
    Inherits Trap

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.coupon
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        If Transformation.canBeTFed(Game.player1) Then
            Game.player1.ongoingTFs.add(New BUDollTF())
            Game.player1.update()
        Else
            TextEvent.push("You spot a slip of paper on the floor, although a gust of wind blows it away before you can investigate further...")
        End If
    End Sub
End Class
