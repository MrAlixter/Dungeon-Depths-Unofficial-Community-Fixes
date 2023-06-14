Public Class GoldenGum
    Inherits StickOfGum

    Public Shadows Const ITEM_NAME As String = "Golden_Gum"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 291
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False
        droppable = False

        '|Stats|
        count = 0
        value = 888
        setCalories(33)

        '|Description|
        setDesc("A glittery yellow piece of gum with a overpoweringly sweet smell.  There are legends that tell of its flavor, and some say that even the gods are moved by its taste." & DDUtils.RNRN &
                "Even holding this gum exposes one to the magic that saturates it..." & DDUtils.RNRN &
                "+33 Stamina")
    End Sub

    Public Overrides Sub tfEffect(ByRef p As Player)
        GBimboTF.snapTF(p)

        TextEvent.push("As you unwrap the stick of gum, you can feel your hair growing out.  As your bangs, now a bright blonde, drop in front of your eyes, you pop the gum into your mouth and begin to chew.  Almost immediately, a massive rush of magical energy staggers you and a glittery cloud settling into your mind." & DDUtils.RNRN &
                       "Through the mental haze, you look down at your tits. You, like, never noticed how round and big they had got. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine and your clothing shifts into a skimpy outfit." & DDUtils.RNRN &
                       "You are now a bimbo!")
    End Sub

    Public Overrides Sub bimboEffect(ByRef p As Player)
        p.addXP(1000)
    End Sub
End Class
