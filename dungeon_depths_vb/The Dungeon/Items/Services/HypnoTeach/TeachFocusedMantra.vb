Public Class TeachFocusedMantra
    Inherits HypnoService

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
        MyBase.onBuy = Sub() teach(h_ind.learnspecial)

        '|Stats|
        count = 0
        value = 1000

        '|Description|
        setDesc("""Rather than fighting off the succubine hordes for all time just because you saw something you found slightly attractive, I can teach you to better control your sexual desires.  Well, so long as you have the mental fortitude to concentrate, at least...""")
    End Sub

    '| - OUTCOMES - |
    Protected Overrides Sub doTrigger(ByRef p As Player, ByVal i As h_ind)
        HypnosisEffect.trigger(p, i, "Focus Up")
    End Sub
    Protected Overrides Sub wakeup(ByRef p As Player, Optional ByVal noticedChanges As String = "")
        TextEvent.fpush("*SNAP!*" & DDUtils.RNRN &
                       "Startled, you jerk back to your senses; settling your focus on the teacher's fingers.  ""Well then, " & Game.player1.name & ", it seems like we're done for the day."" she says with a smirk." & DDUtils.RNRN &
                       "Your knees turn to jelly as one of the most intense waves of arousal you've ever felt burns through your body, and you let out a small moan as you collapse to your knees at your mistress's feet." & DDUtils.RNRN &
                       """Your assignment for next time is to deal with *that*..."" she curtly pivots, facing away from you, ""...without giving in to your..."" she pauses, breifly glancing backwards over her shoulder, ""...'baser'...desires..." & DDUtils.RNRN &
                       "You now know the 'Focus Up' special!", AddressOf CType(Game.hteach, HypnoTeach).back)

        Game.player1.learnSpecial("Focus Up")
        Game.player1.lust = 100

        Game.player1.UIupdate()
        Game.player1.drawPort()
    End Sub

    '| - MISC - |
    Protected Overrides Function canHypnotize(ByRef p As Player) As Boolean
        Return Not p.knownSpecials.Contains("Focus Up")
    End Function
End Class
