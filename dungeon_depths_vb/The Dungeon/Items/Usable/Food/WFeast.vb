Public Class WFeast
    Inherits Food

    Public Const ITEM_NAME As String = "Warrior's_Feast"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
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
        If Int(Rnd() * 5) = 0 Or Settings.active(setting.norng) Then
            p.attack += 3
            p.defense += 3

            p.UIupdate()
        End If
    End Sub
End Class
