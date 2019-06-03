Public Class ValkyrieSword
    Inherits Weapon

    Sub New()
        MyBase.setName("Valkyrie_Sword")
        MyBase.setDesc("A mysterious wand used by a mysterious protector." & vbCrLf & "+22 ATK, +7 Max Mana")
        id = 96
        tier = 3
        MyBase.setUsable(False)
        MyBase.mBoost = 7
        MyBase.aBoost = 22
        MyBase.count = 0
        MyBase.value = 1000
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

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
        If Not Game.player.pClass.name.Equals("Valkyrie") Then
            Dim valkyrieTF = New ValkyrieTF2(1, 0, 0, False)
            Game.player.ongoingTFs.Add(valkyrieTF)
            Game.player.update()
        End If
    End Sub
    Public Overrides Sub onUnequip()
        MyBase.onUnequip()
    End Sub
End Class
