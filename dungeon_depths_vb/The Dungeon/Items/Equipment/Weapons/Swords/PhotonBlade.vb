Public Class PhotonBlade
    Inherits Sword

    Public Const ITEM_NAME As String = "Photon_Blade"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 112
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False

        '|Stats|
        MyBase.a_boost = 37
        count = 0
        value = 4320

        '|Description|
        setDesc("A shimmering red-orange blade made of pure light.  While it can deal quite a bit of damage, it also requires a fair amount of mana to remain useful." & DDUtils.RNRN &
                       getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then
            Return -1
        ElseIf p.mana < 5 Then '+ ((p.lust Mod 20)) Then
            TextEvent.push("Your blade, lacking energy, fades into non-existence.")
            Return -1
        ElseIf dmg >= 11 Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.a_boost)
        p.mana -= 5
        Return Player.calcDamage(dmg, m.defense)
    End Function
End Class
