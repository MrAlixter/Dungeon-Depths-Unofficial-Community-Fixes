Public Class TSpecial
    Inherits Food

    Sub New()
        '|ID Info|
        setName("Tavern_Special")
        id = 135
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 1400
        setCalories(100)

        '|Description|
        setDesc("An entire broasted chicken, served with mashed potatos and bread." & DDUtils.RNRN &
                "+100 Stamina" & DDUtils.RNRN &
                "Low chance to raise Max Health by 5")

    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        If Int(Rnd() * 5) = 0 Or Settings.active(setting.norng) Then
            p.maxHealth += 5
            p.health += 5 / p.getMaxHealth()
            If p.health > 1 Then p.health = 1
            p.UIupdate()
        End If
    End Sub
End Class
