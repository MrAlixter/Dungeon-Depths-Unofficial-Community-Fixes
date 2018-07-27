Public Class Specials
    Shared Sub goSpecial(ByRef m As Monster, ByRef p As Player, ByVal s As String)
        If s.Equals("Berserker Rage") Then
            brage(p)
        ElseIf s.Equals("Risky Decision") Then
            rdec(p)
        ElseIf s.Equals("Massive Mammaries") Then
            mamm(p)
        ElseIf s.Equals("Unholy Seduction") Then
            used(p, m)
        ElseIf s.Equals("Absorbtion") Then
            habs(p, m)
        ElseIf s.Equals("Ironhide Fury") Then
            iron(p)
        End If
    End Sub
    Shared Sub brage(ByRef p As Player)
        p.perks("brage") = 3
        Game.lstLog.Items.Add("BERSERKER RAGE!")
        Game.pushLblCombatEvent("BERSERKER RAGE!" & vbCrLf & "+50% ATK, -25% DEF for 3 turns.")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub rdec(ByRef p As Player)
        Dim mBoost As Integer = (p.maxHealth / 3)
        If p.health <= mBoost Then p.Die() Else p.health -= mBoost / p.getmaxHealth
        p.mana += mBoost
        Game.lstLog.Items.Add("Risky Decision!")
        Game.pushLblCombatEvent("Risky Decision!" & vbCrLf & "Convert 33% Max Health into mana.")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub mamm(ByRef p As Player)
        p.perks("mmammaries") = 1
        Game.lstLog.Items.Add("Massive Mammaries!")
        Game.pushLblCombatEvent("Massive Mammaries!" & vbCrLf & "+80% DEF for 1 turn.")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub used(ByRef p As Player, ByRef m As Monster)
        m.isStunned = True
        m.stunct = 2
        Game.lstLog.Items.Add("Unholy Seduction!")
        Game.pushLblCombatEvent("Unholy Seduction!" & vbCrLf & "Stuns enemy for 3 turns.")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub habs(ByRef p As Player, ByRef m As Monster)
        Dim dmg As Integer = p.attack * 0.75
        Dim rcv As Integer = dmg * 2
        m.takeDMG(dmg)
        p.health += rcv
        If p.health * p.getmaxHealth > p.maxHealth + p.hBuff Then p.health = 1
        Game.lstLog.Items.Add("Absorbtion!")
        Game.pushLblCombatEvent("Absorbtion!" & vbCrLf & "Deals " & dmg & " damage and heals you for " & rcv)
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub iron(ByRef p As Player)
        p.perks("ihfury") = 3
        Game.lstLog.Items.Add("Ironhide Fury!")
        Game.pushLblCombatEvent("Ironhide Fury!" & vbCrLf & "+50% ATK, +60% DEF for 3 turn.")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub

    Shared Function SPCCost(ByVal s As String) As String
        Return ("Useable only once per combat.")
    End Function
End Class
