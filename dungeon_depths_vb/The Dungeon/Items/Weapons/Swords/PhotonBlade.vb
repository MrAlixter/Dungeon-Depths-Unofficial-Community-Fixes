Public Class PhotonBlade
    Inherits Sword
    Sub New()
        MyBase.setName("Photon_Blade")
        MyBase.setDesc("A shimmering red-orange blade made of pure light.  While it can deal quite a bit of damage, it also requires a fair amount of mana to remain useful. +37 ATK")
        id = 112
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 37
        count = 0
        value = 2224

        MyBase.isRandoTFAcceptable = False
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then
            Return -1
        ElseIf p.mana < 5 Then '+ ((p.lust Mod 20)) Then
            Game.pushLblEvent("Your blade, lacking energy, fades into non-existance.")
            Return -1
        ElseIf dmg >= 11 Then
            Return -2
        End If
        dmg += (p.getATK) + (Me.aBoost)
        p.mana -= 5
        Return Player.calcDamage(dmg, m.defence)
    End Function
End Class
