Public Class CouponTrap
    Inherits Trap

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.coupon
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        If Transformation.canBeTFed(Game.player1) Then
            TextEvent.push("Looking down, you see some sort of paper flyer laying on the ground." & DDUtils.RNRN &
                           "You bend over to pick it up, and it reads...", AddressOf activateP2)
        Else
            TextEvent.push("You spot a slip of paper on the floor, although a gust of wind blows it away before you can investigate further...")
        End If
    End Sub

    Public Sub activateP2()
        Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(149), """Need powerful magic artifacts, with no questions asked?" & DDUtils.RNRN &
                                                              "Swing by BROWN HAT MYSTICAL ODDITIES for MIND-MELTING, LIFECHANGING, VERY-NOT-CURSED savings on quality curio!" & DDUtils.RNRN &
                                                              "[See the back for a free sample]""", AddressOf activateP3)
    End Sub
    Public Sub activateP3()
        TextEvent.push("You flip the ad over, and your fingers brush against a rune that begins to glow in response." & DDUtils.RNRN &
                       "With a sudden pulse of mana, you find yourself unable to move as your body collapses into a sheet of folded vinyl." & DDUtils.RNRN &
                       "A rush of magical air puffs you up into the form of a busty lady, allowing you to get back on your feet with a quiet *squeak*.  You try to put your scattered gear back on; only to find that you can barely even hold a weapon, let alone wear armor." & DDUtils.RNRN &
                       "This ""free sample"" seems to have turned you into a living sex doll!" & DDUtils.RNRN &
                       "'Brown Hat', huh...")

        Game.player1.ongoingTFs.add(New BUDollTF())
        Game.player1.update()
    End Sub
End Class
