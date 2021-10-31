Public Class BewitchedWand
    Inherits Wand

    Sub New()
        '|ID Info|
        setName("Bewitched_Wand")
        id = 259
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False
        cursed = True

        '|Stats|
        count = 0
        value = 3500


        '|Description|
        setDesc("A gnarled wooden wand with an unnatural deep violet finish.  Its flow of mana almost feels like the rhythm of a living being." & DDUtils.RNRN &
                       "Each hit carries a 1 in 4 chance of an additional attack, and a 1 in 4 chance of backfiring." & DDUtils.RNRN &
                       getStatInformation())
    End Sub

    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        If Int(Rnd() * 4) = 0 Then
            'Additonal Attack
            Dim dmgAA As Integer = 65 + Int(Rnd() * 3) + Int(Rnd() * 3)

            m.takeDMG(dmgAA, p)
            TextEvent.pushLog(CStr("You zap the " & m.name & " for " & dmgAA & " damage!"))
            TextEvent.pushCombat(CStr("You zap the " & m.name & " for " & dmgAA & " damage!"))

            If m.isDead Then Exit Sub

            'recursion
            spell(p, m)
        ElseIf Int(Rnd() * 4) = 0 Then
            'Backfire
            Dim dmgBF As Integer = 65 + Int(Rnd() * 3) + Int(Rnd() * 3)

            TextEvent.pushLog("Backfire - The wand zaps you!")
            TextEvent.pushCombat("Backfire - The wand zaps you!")

            p.takeDMG(Math.Max(dmgBF, p.getIntHealth - 1), p)

            'recursion
            spell(p, m)
        End If

        'Main Attack
        Dim dmg As Integer = 65
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 3)

        dmg += d31 + d32

        m.takeDMG(dmg, p)
        TextEvent.pushLog(CStr("You zap the " & m.name & " for " & dmg & " damage!"))
        TextEvent.pushCombat(CStr("You zap the " & m.name & " for " & dmg & " damage!"))

        durability -= Int(Rnd() * 10) + 5
    End Sub
    Public Sub backfire(ByRef p As Player, ByRef m As Entity)
        Dim dmgBF As Integer = 65 + Int(Rnd() * 3) + Int(Rnd() * 3)

        TextEvent.pushLog("Backfire - The wand zaps you!")
        TextEvent.pushCombat("Backfire - The wand zaps you!")

        p.takeDMG(Math.Max(dmgBF, p.getIntHealth - 1), p)
    End Sub
End Class
