Public Class WFeast
    Inherits Food
    Sub New()
        '|ID Info|
        setName("Warrior's_Feast")
        id = 133
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 2100
        setCalories(90)

        '|Description|
        setDesc("A seared chunk of some sort of meat still on the bone, served with a satisfying amount of bread." & DDUtils.RNRN &
                "+90 Stamina" & DDUtils.RNRN &
                "Low chance to raise ATK and DEF by 3 points each")

    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        If Int(Rnd() * 5) = 0 Or Game.noRNG Then
            p.attack += 3
            p.defense += 3

            p.UIupdate()
        End If
    End Sub
End Class
