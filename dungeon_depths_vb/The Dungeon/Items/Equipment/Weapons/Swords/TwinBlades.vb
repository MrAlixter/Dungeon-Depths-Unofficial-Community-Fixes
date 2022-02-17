Public Class TwinBlades
    Inherits Weapon

    Public Const ITEM_NAME As String = "Twin_Xiphoi"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 150
        tier = Nothing

        '|Item Flags|
        usable = false

        '|Stats|
        MyBase.a_boost = 25
        count = 0
        value = 1820

        '|Description|
        setDesc("Why have one neat curved double-edged blade forged from bronze when you can have 2?" & DDUtils.RNRN &
                       "Hits twice" & vbCrLf &
                       getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        '1st hit
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            p.miss(m)
        ElseIf dmg >= 11 Then
            If (p.getATK * 2) >= m.getIntHealth Then Return -2
            p.cHit(p.getATK, m)
        Else
            dmg += (p.getATK) + (Me.a_boost)
            If (Player.calcDamage(dmg, m.defense)) >= m.getIntHealth Then Return Player.calcDamage(dmg, m.defense)
            p.hit(Player.calcDamage(dmg, m.defense), m)
        End If

        '2nd hit
        dmg = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 11 Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.a_boost)
        Return Player.calcDamage(dmg, m.defense)
    End Function
End Class
