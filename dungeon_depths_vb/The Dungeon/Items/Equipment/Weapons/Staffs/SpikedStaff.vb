Public Class SpikedStaff
    Inherits Staff

    Public Const ITEM_NAME As String = "Spiked_Staff"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 160
        tier = Nothing

        '|Item Flags|
        m_boost = 46
        a_boost = 23
        count = 0
        value = 1999

        '|Stats|
        usable = False

        '|Description|
        setDesc("A reinforced steel staff covered in rows of wicked looking spikes.  It's as good at smacking things as it is at boosting mana." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 6 + 1) + Int(Rnd() * 6 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 11 Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.a_boost)
        Return Player.calcDamage(dmg, m.defense)
    End Function
End Class
