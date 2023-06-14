Public Class RunecursedDagger
    Inherits Dagger

    Public Const ITEM_NAME As String = "Runecursed_Dagger"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 412
        tier = Nothing

        '|Item Flags|
        usable = True
        cursed = True

        '|Stats|
        count = 0
        value = 666
        a_boost = 5
        w_boost = 13

        '|Description|
        setDesc("A jet-black blade lined with gleaming crimson glyphs." & DDUtils.RNRN &
                "Can be thrown using the ""Use"" button." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Overridable Sub wThrow(ByRef p As Player, ByRef m As Entity)
        If m Is Nothing Then
            TextEvent.push("You throw the knife across the dungeon at nothing in particular.")
            TextEvent.pushLog("You throw the knife across the dungeon at nothing in particular.")
        Else
            TextEvent.pushLog("You throw the knife!")
            Dim dmg As Integer = (p.getATK) + (10) + Int(Rnd() * 3 + 1)
            p.hit(dmg, m)
        End If

        durability -= Int(Rnd() * 6 + 1) + Int(Rnd() * 6 + 1) + Int(Rnd() * 6 + 1)
        If durability <= 0 Then break()
    End Sub

    Public Overrides Sub use(ByRef p As Player)
        wThrow(p, p.currTarget)
    End Sub
End Class
