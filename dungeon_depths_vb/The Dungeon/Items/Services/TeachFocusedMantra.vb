Public Class TeachFocusedMantra
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("Learn_'Focus_Up'")
        id = 249
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)
        MyBase.isRandoTFAcceptable = False
        MyBase.onBuy = AddressOf teach

        '|Stats|
        MyBase.count = 0
        MyBase.value = 1000

        '|Description|
        MyBase.setDesc("""Rather than fighting off the succubine hordes for all time just because you saw something you found slightly attractive, I can teach you to better control your sexual desires.  Well, so long as you have the mental fortitude to concentrate, at least...""")
    End Sub

    Sub teach()
        Game.hideNPCButtons()

        If Game.player1.knownSpecials.Contains("Focus Up") Then
            Game.player1.gold += value * Game.hteach.getDiscount
            Game.pushNPCDialog("Well, it looks like you already know 'Focus Up'.", AddressOf CType(Game.hteach, HTeach).back)
            Exit Sub
        End If

        count -= 1
        CType(Game.hteach, HTeach).hypnotize("Have you seen my pendant?  I know it is a bit of a cliche, but doesn't seeing it swing back and forth just relax you so perfectly?  Back...and forth...watch it glisten in the light...feel yourself go deeper and deeper...deeper...and deeper...until you just...*SNAP*...drift away...", AddressOf wakeup)
    End Sub
    Sub wakeup()
        If Not Game.player1.knownSpecials.Contains("Focus Up") Then Game.player1.knownSpecials.Add("Focus Up")

        Game.player1.UIupdate()
        Game.player1.lust = 100
        Game.player1.drawPort()
        Game.pushLblEvent("You wake up to the teacher's snap." & DDUtils.RNRN & """Well then, " & Game.player1.name & ", it seems like we're done for the day."" she says with a smirk." & DDUtils.RNRN &
                          "Your knees turn to jelly as one of the most intense waves of arousal you've ever felt burns through your body, and you let out a small moan as you collapse to your knees at your mistress's feet." & DDUtils.RNRN &
                          """Your assignment for next time is to deal with *that*..."" she curtly pivots, facing away from you, ""...without giving in to your..."" she pauses, breifly glancing backwards over her shoulder, ""...'baser'...desires..." & DDUtils.RNRN &
                          "You now know the 'Focus Up' special!", AddressOf CType(Game.hteach, HTeach).back)
    End Sub
End Class
