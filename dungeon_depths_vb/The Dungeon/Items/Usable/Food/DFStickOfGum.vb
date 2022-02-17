Public Class DFStickOfGum
    Inherits Food

    Public Const ITEM_NAME As String = "Dragonfruit_S._of_Gum"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 268
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 250
        setCalories(15)

        '|Description|
        setDesc("An rosy red piece of gum with a faint chemical smell.  Supposedly, it tastes like dragonfruit. " & DDUtils.RNRN &
                "+15 Stamina")
    End Sub

    Overrides Sub effect(ByRef p As Player)
        If (p.perks(perk.bimbotf) = -1 And Not p.className.Equals("Bimbo")) Or (p.className.Equals("Bimbo") And Not p.formName.Equals("Half-Dragon (R)")) Then
            TextEvent.push("Chewing the gum causes a dizzy calm wash to over you.")
            p.ongoingTFs.add(New DragonfruitBimboTF(2, 5, 0.25, True))
            p.perks(perk.bimbotf) = 0

        ElseIf p.className.Equals("Bimbo") And p.formName.Equals("Half-Dragon (R)") Then
            TextEvent.push("Chewing the gum sends a tingly shock through your mouth. You like, totally, love this gum!" & DDUtils.RNRN &
                              "+" & CInt(p.getMaxMana * 0.25) & " Max Mana" & vbCrLf &
                              "+25 XP")
            p.addXP(25)
            p.mana += CInt(p.getMaxMana * 0.25)
            p.update()

        Else
            TextEvent.push("Chewing the gum make your head feel warm and fuzzy.")

        End If
    End Sub
End Class
