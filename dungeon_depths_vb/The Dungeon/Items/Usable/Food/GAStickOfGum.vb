Public Class GAStickOfGum
    Inherits StickOfGum

    Public Shadows Const ITEM_NAME As String = "G._Apple_Stick_of_Gum"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 334
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 250
        setCalories(15)

        '|Description|
        setDesc("An glowing green piece of gum emblazened with the subtle imprint of crown.  Supposedly, it tastes like green apples. " & DDUtils.RNRN &
                "+15 Stamina")
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f13
                Return 1
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Overrides Sub effect(ByRef p As Player)
        If (p.perks(perk.bimbotf) = -1 And Not p.className.Contains("Bimbo") And Not p.className.Equals("Princess")) Then
            TextEvent.push("Chewing the gum sends a tingly shock through your mouth.  You hear a far-off giggle ring through the air...")
            p.ongoingTFs.add(New GreenAppleBimboTF(2, 5, 0.25, True))
            p.perks(perk.bimbotf) = 0
        Else
            TextEvent.push("Chewing the gum leaves you feeling a little more princess-y. You like, totally, love this gum!" & DDUtils.RNRN &
                           "+10 WIL" & vbCrLf &
                           "+25 XP")
            p.addXP(25)
            p.will += 10
            p.update()
        End If
    End Sub
End Class
