Public Class CursedSword
    Inherits Sword

    Sub New()
        '|ID Info|
        MyBase.setName("Accursed_Blade")
        id = 258
        tier = Nothing

        '|Item Flags|
        setUsable(False)
        isCursed = True
        isMonsterDrop = False

        '|Stats|
        MyBase.aBoost = 45
        MyBase.count = 0
        MyBase.value = 3500

        '|Description|
        MyBase.setDesc("A pitch-black sword whose edge reflects no light.  When in use, the reverberations through it's hilt almost feel like the rhythm of a living being." & DDUtils.RNRN &
                       "Each hit carries a 1 in 4 chance of an additional attack, and a 1 in 4 chance of backfiring." & DDUtils.RNRN &
                       getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim roll As Integer = Int(Rnd() * 4)

        If roll = 0 Then
            'Additonal Attack
            Dim dmgAA As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)

            If dmgAA <= 4 Then
                p.miss(m)
            ElseIf dmgAA >= 11 Then
                p.cHit(p.getATK, m)
            Else
                dmgAA += (p.getATK) + (Me.aBoost)
                p.hit(Player.calcDamage(dmgAA, m.defense), m)
            End If

            'recursion
            Return attack(p, m)
        ElseIf roll = 1 Then
            'Backfire
            Dim dmgBF As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)

            dmgBF += (p.getATK) + (Me.aBoost)

            Game.pushLstLog("Backfire - Your grip on the blade slips!")
            Game.pushLblCombatEvent("Backfire - Your grip on the blade slips!")
            p.takeDMG(Math.Min(Player.calcDamage(dmgBF, m.defense), p.getIntHealth - 1), m)

            'recursion
            Return attack(p, m)
        End If

        'Main Attack
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)

        If dmg <= 4 Then
            Return -1
        ElseIf dmg >= 11 Then
            Return -2
        End If

        dmg += (p.getATK) + (Me.aBoost)

        Return Player.calcDamage(dmg, m.defense)
    End Function
End Class
