Public Class TeachFocusedMantra
    Inherits Item

    Public Const ITEM_NAME As String = "Learn_'Focus_Up'"
        
    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 249
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False
        can_be_stolen = False
        MyBase.onBuy = AddressOf teach

        '|Stats|
        count = 0
        value = 1000

        '|Description|
        setDesc("""Rather than fighting off the succubine hordes for all time just because you saw something you found slightly attractive, I can teach you to better control your sexual desires.  Well, so long as you have the mental fortitude to concentrate, at least...""")
    End Sub

    Sub teach()
        Game.hideNPCButtons()

        If Game.player1.knownSpecials.Contains("Focus Up") Then
            Game.player1.gold += (value - (value * Game.hteach.discount))
            TextEvent.pushNPCDialog("Well, it looks like you already know 'Focus Up'.", AddressOf CType(Game.hteach, HypnoTeach).back)
            Exit Sub
        End If

        count -= 1
        CType(Game.hteach, HypnoTeach).hypnotize("Perfect!" & DDUtils.RNRN &
                                                 "Speaking of perfection, have you seen my pendant?  I know it may seem a bit clichéd, but does seeing it swing back and forth not just relax you so... perfectly?" & DDUtils.RNRN &
                                                 "Back... and forth... watch it glisten in the light..." & DDUtils.RNRN &
                                                 "Feel yourself go deeper and deeper... deeper... and deeper... until you just..." & DDUtils.RNRN &
                                                 "*SNAP*" & DDUtils.RNRN &
                                                 "...drift away...", AddressOf wakeup)
    End Sub
    Sub wakeup()
        Game.player1.learnSpecial("Focus Up")

        Game.player1.UIupdate()
        Game.player1.lust = 100
        Game.player1.drawPort()
        TextEvent.push("You wake up to the teacher's snap." & DDUtils.RNRN & """Well then, " & Game.player1.name & ", it seems like we're done for the day."" she says with a smirk." & DDUtils.RNRN &
                          "Your knees turn to jelly as one of the most intense waves of arousal you've ever felt burns through your body, and you let out a small moan as you collapse to your knees at your mistress's feet." & DDUtils.RNRN &
                          """Your assignment for next time is to deal with *that*..."" she curtly pivots, facing away from you, ""...without giving in to your..."" she pauses, breifly glancing backwards over her shoulder, ""...'baser'...desires..." & DDUtils.RNRN &
                          "You now know the 'Focus Up' special!", AddressOf CType(Game.hteach, HypnoTeach).back)
    End Sub
End Class
