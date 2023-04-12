Public Class SigDagger
    Inherits Dagger

    Public Const ITEM_NAME As String = "Signature_Dagger"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 163
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False

        '|Stats|
        a_boost = 10
        s_boost = 5
        count = 0
        value = 235

        '|Description|
        setDesc("A finely crafted dagger bearing a trademarked signature.  Despite its sturdy construction, the blade is also light enough to allow its bearer to strike thrice in the same time as a sword-swing." & DDUtils.RNRN &
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
            dmg += (p.getATK) + (Me.getABoost(p))
            If (Player.calcDamage(dmg, m.defense)) >= m.getIntHealth Then Return Player.calcDamage(dmg, m.defense)
            p.hit(Player.calcDamage(dmg, m.defense), m)
        End If

        '2nd hit
        dmg = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            p.miss(m)
        ElseIf dmg >= 11 Then
            If (p.getATK * 2) >= m.getIntHealth Then Return -2
            p.cHit(p.getATK, m)
        Else
            dmg += (p.getATK) + (Me.getABoost(p))
            If (Player.calcDamage(dmg, m.defense)) >= m.getIntHealth Then Return Player.calcDamage(dmg, m.defense)
            p.hit(Player.calcDamage(dmg, m.defense), m)
        End If

        '3rd hit
        dmg = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            Return -1
        ElseIf dmg >= 11 Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.getABoost(p))
        Return Player.calcDamage(dmg, m.defense)
    End Function
End Class
