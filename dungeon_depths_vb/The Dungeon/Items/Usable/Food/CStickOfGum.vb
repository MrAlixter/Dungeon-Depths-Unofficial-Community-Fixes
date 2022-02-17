Public Class CStickOfGum
    Inherits Food

    Public Const ITEM_NAME As String = "Cherry_Stick_of_Gum"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 100
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 100
        setCalories(10)

        '|Description|
        setDesc("A red piece of gum with a faint chemical smell.  Supposedly, it tastes like cherry." & DDUtils.RNRN &
                "+10 Stamina")

    End Sub

    Overrides Sub effect(ByRef p As Player)
        If p.perks(perk.bimbotf) = -1 Then
            TextEvent.push("Chewing the gum causes a dizzy calm wash to over you.")
            p.ongoingTFs.add(New CBimboTF(2, 5, 0.25, True))
            p.perks(perk.bimbotf) = 0
        ElseIf p.className.Equals("Bimbo") Then
            TextEvent.push("Chewing the gum make your head feel warm and fuzzy and stuff. You like, totally, love this gum!")
        Else
            TextEvent.push("Chewing the gum make your head feel warm and fuzzy.")
        End If
    End Sub
End Class
