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
        Form1.lstLog.Items.Add("BERSERKER RAGE!")
        Form1.pushLblEvent("BERSERKER RAGE!" & vbCrLf & "+50% ATK, -25% DEF for 3 turns.")
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
    End Sub
    Shared Sub rdec(ByRef p As Player)
        Dim mBoost As Integer = (p.maxHealth / 3)
        If p.health <= mBoost Then p.Die() Else p.health -= mBoost
        p.mana += mBoost
        Form1.lstLog.Items.Add("Risky Decision!")
        Form1.pushLblEvent("Risky Decision!" & vbCrLf & "Convert 33% Max Health into mana.")
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
    End Sub
    Shared Sub mamm(ByRef p As Player)
        p.perks(10) = True
        p.perksct(10) = 1
        Form1.lstLog.Items.Add("Massive Mammaries!")
        Form1.pushLblEvent("Massive Mammaries!" & vbCrLf & "+80% DEF for 1 turn.")
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
    End Sub
    Shared Sub used(ByRef p As Player, ByRef m As Monster)
        m.isStunned = True
        m.stunct = 2
        Form1.lstLog.Items.Add("Unholy Seduction!")
        Form1.pushLblEvent("Unholy Seduction!" & vbCrLf & "Stuns enemy for 3 turns.")
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
    End Sub
    Shared Sub habs(ByRef p As Player, ByRef m As Monster)
        Dim dmg As Integer = p.attack * 0.75
        Dim rcv As Integer = dmg * 2
        m.takeDMG(dmg)
        p.health += rcv
        If p.health > p.maxHealth + p.hBuff Then p.health = p.maxHealth + p.hBuff
        Form1.lstLog.Items.Add("Absorbtion!")
        Form1.pushLblEvent("Absorbtion!" & vbCrLf & "Deals " & dmg & " damage and heals you for " & rcv)
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
    End Sub
    Shared Sub iron(ByRef p As Player)
        p.perks(11) = True
        p.perksct(11) = 3
        Form1.lstLog.Items.Add("Ironhide Fury!")
        Form1.pushLblEvent("Ironhide Fury!" & vbCrLf & "+50% ATK, +60% DEF for 3 turn.")
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
    End Sub
End Class
