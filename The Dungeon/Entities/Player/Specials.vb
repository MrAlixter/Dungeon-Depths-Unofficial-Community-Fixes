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
        p.perks(9) = True
        p.perksct(9) = 3
        Game.lstLog.Items.Add("BERSERKER RAGE!")
        Game.pushLblEvent("BERSERKER RAGE!" & vbCrLf & "+50% ATK, -25% DEF for 3 turns.")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub rdec(ByRef p As Player)
        Dim mBoost As Integer = (p.maxHealth / 3)
        If p.health <= mBoost Then p.Die() Else p.health -= mBoost
        p.mana += mBoost
        Game.lstLog.Items.Add("Risky Decision!")
        Game.pushLblEvent("Risky Decision!" & vbCrLf & "Convert 33% Max Health into mana.")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub mamm(ByRef p As Player)
        p.perks(10) = True
        p.perksct(10) = 1
        Game.lstLog.Items.Add("Massive Mammaries!")
        Game.pushLblEvent("Massive Mammaries!" & vbCrLf & "+80% DEF for 1 turn.")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub used(ByRef p As Player, ByRef m As Monster)
        m.isStunned = True
        m.stunct = 2
        Game.lstLog.Items.Add("Unholy Seduction!")
        Game.pushLblEvent("Unholy Seduction!" & vbCrLf & "Stuns enemy for 3 turns.")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub habs(ByRef p As Player, ByRef m As Monster)
        Dim dmg As Integer = p.attack * 0.75
        Dim rcv As Integer = dmg * 2
        m.takeDMG(dmg)
        p.health += rcv
        If p.health > p.maxHealth + p.hBuff Then p.health = p.maxHealth + p.hBuff
        Game.lstLog.Items.Add("Absorbtion!")
        Game.pushLblEvent("Absorbtion!" & vbCrLf & "Deals " & dmg & " damage and heals you for " & rcv)
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Shared Sub iron(ByRef p As Player)
        p.perks(11) = True
        p.perksct(11) = 3
        Game.lstLog.Items.Add("Ironhide Fury!")
        Game.pushLblEvent("Ironhide Fury!" & vbCrLf & "+50% ATK, +60% DEF for 3 turn.")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
End Class
