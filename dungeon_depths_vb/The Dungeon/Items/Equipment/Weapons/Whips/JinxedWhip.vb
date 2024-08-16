Public Class JinxedWhip
    Inherits Whip

    Public Const ITEM_NAME As String = "Jinxed_Whip"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 260
        tier = Nothing

        '|Item Flags|
        usable = false
        droppable = False
        cursed = True
        can_hit_flying = True

        '|Stats|
        MyBase.a_boost = 37
        count = 0
        value = 3500

        '|Description|
        setDesc("A sleek golden whip that seems as though it should be worth far more than " & value & " gold.  Occasionally it seems as though the whip is moving on its own." & DDUtils.RNRN &
                "Each hit carries a 1 in 4 chance of an additional attack, and a 1 in 4 chance of backfiring." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer

        If Int(Rnd() * 4) = 0 Then
            'Additonal Attack
            Dim dmgAA As Integer = Int(Rnd() * 4 + 1) + Int(Rnd() * 4 + 1) + Int(Rnd() * 4 + 1)

            If dmgAA <= 5 Then
                p.miss(m)
            ElseIf dmgAA >= 10 Then
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
        Dim dmg As Integer = Int(Rnd() * 4 + 1) + Int(Rnd() * 4 + 1) + Int(Rnd() * 4 + 1)

        If dmg <= 5 Then
            Return -1
        ElseIf dmg >= 10 Then
            Return -2
        End If

        dmg += (p.getATK)

        Return Player.calcDamage(dmg, m.defense)
    End Function

    Public Sub backfire(ByRef p As Player, ByRef m As Entity)
        Dim dmgBF As Integer = Int(Rnd() * 4 + 1) + Int(Rnd() * 4 + 1) + Int(Rnd() * 4 + 1)

        dmgBF += (p.getATK)

        TextEvent.pushLog("Backfire - The whip cracks back in your direction!")
        TextEvent.pushCombat("Backfire - The whip cracks back in your direction!")
        p.takeDMG(Math.Min(Player.calcDamage(dmgBF, m.defense), p.getIntHealth - 1), m)
    End Sub
End Class
