Public Class CursedSword
    Inherits Sword

    Sub New()
        '|ID Info|
        setName("Accursed_Blade")
        id = 258
        tier = Nothing

        '|Item Flags|
        usable = false
        droppable = False
        cursed = True

        '|Stats|
        MyBase.a_boost = 45
        count = 0
        value = 3500

        '|Description|
        setDesc("A pitch-black sword whose edge reflects no light.  When in use, the reverberations through it's hilt almost feel like the rhythm of a living being." & DDUtils.RNRN &
                       "Each hit carries a 1 in 4 chance of an additional attack, and a 1 in 4 chance of backfiring." & DDUtils.RNRN &
                       getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        If Int(Rnd() * 4) = 0 Then
            'Additonal Attack
            Dim dmgAA As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)

            If dmgAA <= 4 Then
                p.miss(m)
            ElseIf dmgAA >= 11 Then
                If (p.getATK * 2) >= m.getIntHealth Then Return -2
                p.cHit(p.getATK, m)
            Else
                dmgAA += (p.getATK)
                If (Player.calcDamage(dmgAA, m.defense)) >= m.getIntHealth Then Return Player.calcDamage(dmgAA, m.defense)
                p.hit(Player.calcDamage(dmgAA, m.defense), m)
            End If

            'recursion
            Return attack(p, m)
        ElseIf Int(Rnd() * 4) = 0 Then
            'Backfire
            backfire(p, m)

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

        dmg += (p.getATK)

        Return Player.calcDamage(dmg, m.defense)
    End Function

    Public Sub backfire(ByRef p As Player, ByRef m As Entity)
        Dim dmgBF As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)

        dmgBF += (p.getATK)

        TextEvent.pushLog("Backfire - Your grip on the blade slips!")
        TextEvent.pushCombat("Backfire - Your grip on the blade slips!")
        p.takeDMG(Math.Min(Player.calcDamage(dmgBF, m.defense), p.getIntHealth - 1), m)
    End Sub
End Class
