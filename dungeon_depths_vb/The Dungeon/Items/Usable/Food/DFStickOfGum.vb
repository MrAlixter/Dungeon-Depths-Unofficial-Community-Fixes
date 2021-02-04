Public Class DFStickOfGum
    Inherits Food

    Sub New()
        '|ID Info|
        MyBase.setName("Dragonfruit_S._of_Gum")
        id = 268
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)

        '|Stats|
        MyBase.count = 0
        MyBase.value = 250
        setCalories(15)

        '|Description|
        MyBase.setDesc("An rosy red piece of gum with a faint chemical smell.  Supposedly, it tastes like dragonfruit. " & DDUtils.RNRN & "+15 Stamina")
    End Sub

    Overrides Sub effect()
        If (Game.player1.perks(perk.bimbotf) = -1 And Not Game.player1.className.Equals("Bimbo")) Or (Game.player1.className.Equals("Bimbo") And Not Game.player1.formName.Equals("Half-Dragon (R)")) Then
            Game.pushLblEvent("Chewing the gum causes a dizzy calm wash to over you.")
            Game.player1.ongoingTFs.add(New DragonfruitBimboTF(2, 5, 0.25, True))
            Game.player1.perks(perk.bimbotf) = 0
        ElseIf Game.player1.className.Equals("Bimbo") And Game.player1.formName.Equals("Half-Dragon (R)") Then
            Game.pushLblEvent("Chewing the gum sends a tingly shock through your mouth. You like, totally, love this gum!" & DDUtils.RNRN &
                              "+" & CInt(Game.player1.getMaxMana * 0.25) & " Max Mana" & vbCrLf &
                              "+25 XP")
            Game.player1.xp += 25
            Game.player1.mana += CInt(Game.player1.getMaxMana * 0.25)
            Game.player1.update()
        Else
            Game.pushLblEvent("Chewing the gum make your head feel warm and fuzzy.")
        End If
    End Sub
End Class
