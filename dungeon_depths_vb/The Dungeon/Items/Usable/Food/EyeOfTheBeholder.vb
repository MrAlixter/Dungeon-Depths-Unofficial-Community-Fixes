Public Class EyeOfTheBeholder
    Inherits Food

    Public Const ITEM_NAME As String = "Eye_of_the_Beholder"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 386
        tier = 4

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 2250
        setCalories(5)

        '|Description|
        setDesc("A disembodied eyeball, slathered in slimey goo.  Food?  Technically yes, but it doesn't seem particularly edible..." & DDUtils.RNRN &
                "+5 Stamina")
    End Sub

    Overrides Sub effect(ByRef p As Player)
        If p.perks(perk.esper) < 0 Then
            p.perks(perk.esper) = 1
            TextEvent.pushLog("The eye tastes disgusting... but eating it grants you psychic powers!")
            TextEvent.pushLog("Blindness no longer restricts your sight.")
        Else
            TextEvent.pushLog("The eye tastes disgusting...")
        End If
    End Sub
End Class
