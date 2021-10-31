Public Class SigSpear
    Inherits Spear

    Sub New()
        '|ID Info|
        setName("Signature_Spear")
        id = 158
        tier = Nothing

        '|Item Flags|
        usable = true
        MyBase.droppable = False

        '|Stats|
        MyBase.a_boost = 35
        MyBase.s_boost = -2
        count = 0
        value = 3300

        '|Description|
        setDesc("A finely crafted spear bearing a trademarked signature.  This spear is specifically designed to be thrown and will not take damage from doing so." & DDUtils.RNRN &
                       "Can be thrown using the ""Use"" button." & vbCrLf &
                       "+35 ATK" & vbCrLf &
                       "-2 SPD")
    End Sub

    Overrides Sub wThrow(ByRef p As Player, ByRef m As Entity)
        If m Is Nothing Then
            TextEvent.push("You throw the spear across the dungeon at nothing in particular.")
            TextEvent.pushLog("You throw the spear across the dungeon at nothing in particular.")
        Else
            TextEvent.pushLog("You throw the spear!")
            Dim dmg As Integer = 2 * (p.getATK) + (Me.a_boost) + Int(Rnd() * 3 + 1)
            p.hit(dmg, m)
        End If
    End Sub
End Class
