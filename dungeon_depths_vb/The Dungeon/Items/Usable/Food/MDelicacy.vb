Public Class MDelicacy
    Inherits Food
    Sub New()
        '|ID Info|
        setName("Mage's_Delicacy")
        id = 134
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 2100
        setCalories(90)

        '|Description|

        setDesc("Three pieces of baked haddock served with wild rice and a selection of grilled vegetables.  Some of the spices glow with a dim azure light." & DDUtils.RNRN &
                "+90 Stamina" & DDUtils.RNRN &
                "Low chance to raise Max Mana and WILL by 3 points each")

    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        If Int(Rnd() * 5) = 0 Or Settings.active(setting.norng) Then
            p.maxMana += 3
            p.mana += 3

            p.will += 3

            p.UIupdate()
        End If
    End Sub
End Class
