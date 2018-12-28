Public Class TargaxSword
    Inherits Weapon

    Sub New()
        MyBase.setName("Sword_of_the_Brutal")
        MyBase.setDesc("A suspicious sword owned by a brutal despot. +50 ATK")
        id = 24
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 50
        MyBase.count = 0
        MyBase.value = 1250
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
        If dmg <= 4 Then '+ ((p.lust Mod 20)) Then
            Return -1
        End If
        dmg += (p.getATK) + (Me.aBoost)
        Return Player.calcDamage(dmg, m.defence)
    End Function

    Public Overrides Sub onEquip()
        If Not Game.player.perks("swordpossess") > -1 Then Game.player.perks("swordpossess") = 0
    End Sub
    Public Overrides Sub onUnequip()
        If Game.player.perks("swordpossess") > -1 Then Game.player.perks("swordpossess") = -1
    End Sub
End Class
